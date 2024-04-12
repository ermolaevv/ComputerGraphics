using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Filters
{
    internal class LinearCorrection : Filter
    {
        int minSrcIntensity = 255;
        int maxSrcIntensity = 0;

        public LinearCorrection(Bitmap sourceImage)
        {
            int intensity;
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    Color color = sourceImage.GetPixel(i, j);
                    intensity = GetIntensity(color);

                    if (minSrcIntensity > intensity) minSrcIntensity = intensity;
                    if (maxSrcIntensity < intensity) maxSrcIntensity = intensity;
                }
            }
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color color = sourceImage.GetPixel(x, y);
            int intensity = GetIntensity(color);
            int newIntensity = (intensity - minSrcIntensity) * 255 / (maxSrcIntensity - minSrcIntensity);

            float coef = newIntensity / (float)intensity;

            return Color.FromArgb(
                Clamp((int)(color.R * coef), 0, 255),
                Clamp((int)(color.G * coef), 0, 255),
                Clamp((int)(color.B * coef), 0, 255)
            );

        }
    }
}

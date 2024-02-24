using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Filters
{
    internal class PerfectReflector : Filter
    {
        float coefR = 0;
        float coefG = 0;
        float coefB = 0;

        public PerfectReflector(Bitmap sourceImage)
        {
            int mxR = 0;
            int mxG = 0;
            int mxB = 0;

            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    Color color = sourceImage.GetPixel(i, j);

                    if (mxR < color.R) mxR = color.R;
                    if (mxG < color.G) mxG = color.G;
                    if (mxB < color.B) mxB = color.B;
                }
            }

            coefR = 255f / mxR;
            coefG = 255f / mxG;
            coefB = 255f / mxB;
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color color = sourceImage.GetPixel(x, y);
            return Color.FromArgb(
                Clamp((int)(color.R * coefR), 0, 255),    
                Clamp((int)(color.G * coefG), 0, 255),    
                Clamp((int)(color.B * coefB), 0, 255)    
            );
        }
    }
}

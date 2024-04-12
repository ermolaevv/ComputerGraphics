using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Filters
{
    internal class GrayWorld : Filter
    {
        protected float coefR = 0;
        protected float coefG = 0;
        protected float coefB = 0;

        public GrayWorld(Bitmap sourceImage)
        {
            int n  = sourceImage.Width * sourceImage.Width;

            int R = 0;
            int G = 0;
            int B = 0;

            for (int i = 0; i < sourceImage.Width; i++) {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    Color color = sourceImage.GetPixel(i, j);
                    R += color.R;
                    G += color.G;
                    B += color.B;
                }
            }

            float avgR = (float)R / (float)n;
            float avgG = (float)G / (float)n;
            float avgB = (float)B / (float)n;

            float avg = (avgR + avgB + avgG) / 3;

            coefR = avg / avgR;
            coefG = avg / avgG;
            coefB = avg / avgB;
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

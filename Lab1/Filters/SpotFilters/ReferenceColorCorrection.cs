using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Filters
{
    internal class ReferenceColorCorrection : Filter
    {
        float coefR;
        float coefB;
        float coefG;
        public ReferenceColorCorrection(Color source, Color result)
        {
            coefR = (float)result.R / source.R;
            coefB = (float)result.B / source.B;
            coefG = (float)result.G / source.G;
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color color = sourceImage.GetPixel(x, y);
            return Color.FromArgb(
                Clamp((int)(color.R * coefR), 0, 255),
                Clamp((int)(color.B * coefB), 0, 255),
                Clamp((int)(color.G * coefG), 0, 255)
            );
        }
    }
}

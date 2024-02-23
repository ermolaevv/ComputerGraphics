using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Filters
{
    internal class SepiaFilter : Filter
    {
        private int k = 15;
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int intensity = GetIntesity(sourceImage.GetPixel(x,y));
            int R = Clamp(intensity + 2 * k, 0, 255);
            int G = Clamp((int)(intensity + 0.5 * k), 0, 255);
            int B = Clamp(intensity - k, 0, 255);
            return Color.FromArgb(R, G, B);
        }
    }
}

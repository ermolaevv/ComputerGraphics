using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Filters
{
    internal class Binarization : Filter
    {
        int threshold;
        public Binarization(int threshold) { this.threshold = threshold; }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int intensity = GetIntensity(sourceImage.GetPixel(x, y));
            if (intensity < threshold) { return Color.Black; }
            return Color.White;
        }
    }
}

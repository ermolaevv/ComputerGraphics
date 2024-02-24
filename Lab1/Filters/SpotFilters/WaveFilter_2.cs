using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Filters
{
    internal class WaveFilter_2: Filter
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            double radians = (2 * Math.PI * x) / 30;

            int newX = x + (int)(20 * Math.Sin(radians));
            int newY = y;
            if (newX < 0 || newX >= sourceImage.Width || newY < 0 || newY >= sourceImage.Height)
                return Color.Black;
            return sourceImage.GetPixel(newX, newY);
        }
    }
}

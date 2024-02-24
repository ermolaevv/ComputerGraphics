using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Filters
{
    internal class GlassFilter: Filter
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Random rand = new Random();
            int shiftX = rand.Next(-5, 6);
            int shiftY = rand.Next(-5, 6);
            int newX = x + shiftX;
            int newY = y + shiftY;

            if (newX < 0 || newX >= sourceImage.Width || newY < 0 || newY >= sourceImage.Height) return Color.Black;

            return sourceImage.GetPixel(newX, newY);
        }
    }
}

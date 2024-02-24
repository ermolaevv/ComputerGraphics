using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Filters
{
    internal class Transfer : Filter
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int newX = x + 50;
            int newY = y;
            if (newX < 0 || newX >= sourceImage.Width ||
                newY < 0 || newY >= sourceImage.Height)
                return Color.Black;
            
            return sourceImage.GetPixel(newX, newY);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Filters
{
    internal class Rotation : Filter
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int x0 = (int)Math.Round((double)sourceImage.Width / 2d);
            int y0 = (int)Math.Round((double)sourceImage.Height / 2d);

            double angle = Clamp(45, 0, 360);

            int newX = (int)((x - x0) * Math.Cos(angle) - (y - y0) * Math.Sin(angle) + x0);
            int newY = (int)((x - x0) * Math.Sin(angle) + (y - y0) * Math.Cos(angle) + y0);

            if (newX < 0 || newX >= sourceImage.Width ||
                newY < 0 || newY >= sourceImage.Height)
                return Color.Black;

            return sourceImage.GetPixel(
                    Clamp(newX, 0, sourceImage.Width-1),
                    Clamp(newY, 0, sourceImage.Height-1)
                );
        }
    }
}

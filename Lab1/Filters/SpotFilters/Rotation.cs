using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Filters
{
    internal class Rotation : Filter
    {
        private int angle_const;

        public Rotation(int angle_const)
        {
            this.angle_const = angle_const;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int x0 = (int)Math.Round((double)sourceImage.Width / 2d);
            int y0 = (int)Math.Round((double)sourceImage.Height / 2d);

            double angle_deg = Clamp(angle_const, 0, 360);
            double angle_rad = angle_deg * (Math.PI / 180);

            int newX = (int)((x - x0) * Math.Cos(angle_rad) - (y - y0) * Math.Sin(angle_rad) + x0);
            int newY = (int)((x - x0) * Math.Sin(angle_rad) + (y - y0) * Math.Cos(angle_rad) + y0);

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

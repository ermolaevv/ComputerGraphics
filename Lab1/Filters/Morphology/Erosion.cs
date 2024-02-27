using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Filters
{
    internal class Erosion : MorphOperation
    {
        public Erosion(bool[,] mask, int threshold) : base(mask, threshold) { }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int min = 255;
            for (int j = -MH / 2; j < MH / 2; j++)
                for (int i = -MW / 2; i < MW / 2; i++)
                    if ((kernel[i + MW / 2, j + MH / 2]) &&
                            (sourceImage.GetPixel(Clamp(x + i, 0, sourceImage.Width - 1), Clamp(y + j, 0, sourceImage.Width - 1)).R < min))
                    {
                        min = sourceImage.GetPixel(x + i, y + j).R;
                    }

            return Color.FromArgb(min, min, min);
        }
    }
}

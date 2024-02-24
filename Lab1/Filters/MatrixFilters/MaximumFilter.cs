using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Filters
{
    internal class MaximumFilter : MatrixFilter
    {
        int size;
        public MaximumFilter(int size)
        {
            kernel = new float[size, size];
            this.size = size;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;

            int[] r = new int[size * size];
            int[] g = new int[size * size];
            int[] b = new int[size * size];
            int i = 0;

            for (int l = -radiusY; l <= radiusX; l++)
            {
                for (int k = -radiusX; k <= radiusY; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);

                    Color color = sourceImage.GetPixel(idX, idY);

                    r[i] = color.R;
                    g[i] = color.G;
                    b[i] = color.B;
                    i++;
                }
            }

            Array.Sort(r);
            Array.Sort(g);
            Array.Sort(b);

            return Color.FromArgb(r[r.Length-1], g[g.Length-1], b[b.Length-1]);
        }
    }
}

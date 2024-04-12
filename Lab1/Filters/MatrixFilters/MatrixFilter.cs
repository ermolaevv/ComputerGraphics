using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Filters
{
    internal class MatrixFilter : Filter
    {
        protected float[,] kernel = null;
        protected MatrixFilter() { }
        public MatrixFilter(float[,] kernel)
        {
            this.kernel = kernel;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;

            float resultR = 0;
            float resultG = 0;
            float resultB = 0;

            for (int l = -radiusY;  l <= radiusX; l++)
            {
                for (int k = -radiusX;  k <= radiusY; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);

                    Color neighborColor = sourceImage.GetPixel(idX, idY);

                    resultR += neighborColor.R * kernel[k + radiusX, l + radiusY];
                    resultG += neighborColor.G * kernel[k + radiusX, l + radiusY];
                    resultB += neighborColor.B * kernel[k + radiusX, l + radiusY];
                }
            }

            return Color.FromArgb(
                Clamp((int)resultR, 0, 255),
                Clamp((int)resultG, 0, 255),
                Clamp((int)resultB, 0, 255)
                );
        }
        protected Color ApplyKernel(Bitmap sourceImage, int x, int y, float[,] kernel)
        {
            float resultR = 0;
            float resultG = 0;
            float resultB = 0;

            int kernelWidth = kernel.GetLength(0);
            int kernelHeight = kernel.GetLength(1);
            int halfKernelWidth = kernelWidth / 2;
            int halfKernelHeight = kernelHeight / 2;

            for (int i = -halfKernelHeight; i <= halfKernelHeight; i++){
                for (int j = -halfKernelWidth; j <= halfKernelWidth; j++){
                    int pixelX = Clamp(x + j, 0, sourceImage.Width - 1);
                    int pixelY = Clamp(y + i, 0, sourceImage.Height - 1);
                    Color pixelColor = sourceImage.GetPixel(pixelX, pixelY);

                    resultR += pixelColor.R * kernel[j + halfKernelWidth, i + halfKernelHeight];
                    resultG += pixelColor.G * kernel[j + halfKernelWidth, i + halfKernelHeight];
                    resultB += pixelColor.B * kernel[j + halfKernelWidth, i + halfKernelHeight];
                }
            }
            return Color.FromArgb(
                Clamp((int)resultR, 0, 255),
                Clamp((int)resultG, 0, 255),
                Clamp((int)resultB, 0, 255)
           );
        }
    }
}

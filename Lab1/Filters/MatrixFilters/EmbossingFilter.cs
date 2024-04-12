using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Filters
{
    internal class EmbossingFilter : MatrixFilter
    {
        public EmbossingFilter()
        {
            kernel = new float[3, 3] {
                { 0, 1, 0 },
                { 1, 0, -1 },
                { 0, -1, 0 }
            };
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;

            float resultR = 0;
            float resultG = 0;
            float resultB = 0;

            for (int l = -radiusY; l <= radiusX; l++)
            {
                for (int k = -radiusX; k <= radiusY; k++)
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
                Clamp((int)(resultR + 255) / 2, 0, 255),
                Clamp((int)(resultG + 255) / 2, 0, 255),
                Clamp((int)(resultB + 255) / 2, 0, 255)
                );
        }
        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker backgroundWorker)
        {
            Filter grayScale = new Filters.GrayScaleFilter();
            sourceImage = grayScale.processImage(sourceImage, backgroundWorker);
            return base.processImage(sourceImage, backgroundWorker );
        }
    }
}

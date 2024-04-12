using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Filters
{  
    internal class SobelFilter: MatrixFilter
    {
        private float[,] horizontalKernel = new float[,]
        {
            {-1, 0, 1},
            {-2, 0, 2},
            {-1, 0, 1}
        };

        private float[,] verticalKernel = new float[,]
        {
            {-1, -2, -1},
            { 0,  0,  0},
            { 1,  2,  1}
        };

        public SobelFilter() : base(null) { }
        public Bitmap ProcessImage(Bitmap sourceImage)
        {
            Bitmap result = new Bitmap(sourceImage.Width, sourceImage.Height);

            for (int y = 0; y < sourceImage.Height; y++)
            {
                for (int x = 0; x < sourceImage.Width; x++)
                {
                    Color newPixelColor = calculateNewPixelColor(sourceImage, x, y);
                    result.SetPixel(x, y, newPixelColor);
                }
            }

            return result;
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color gx = ApplyKernel(sourceImage, x, y, horizontalKernel);
            Color gy = ApplyKernel(sourceImage, x, y, verticalKernel);

            int resultR = (int)Math.Sqrt(gx.R * gx.R + gy.R * gy.R);
            int resultG = (int)Math.Sqrt(gx.G * gx.G + gy.G * gy.G);
            int resultB = (int)Math.Sqrt(gx.B * gx.B + gy.B * gy.B);

            return Color.FromArgb(
                Clamp((int)resultR, 0, 255),
                Clamp((int)resultG, 0, 255),
                Clamp((int)resultB, 0, 255)
           );
        }

    }
}


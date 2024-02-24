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

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            float gx = ApplyKernel(sourceImage, x, y, horizontalKernel);
            float gy = ApplyKernel(sourceImage, x, y, verticalKernel);
            int intensity = (int)Math.Sqrt(gx * gx + gy * gy);
            intensity = Clamp(intensity, 0, 255);

            return Color.FromArgb(intensity, intensity, intensity);
        }

    }
}


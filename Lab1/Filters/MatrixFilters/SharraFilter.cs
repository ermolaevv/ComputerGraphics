using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Filters
{
    internal class SharraFilter: MatrixFilter
    {
        private float[,] horizontalKernel = new float[,]
        {
            { 3,  10,  3},
            { 0,   0,  0},
            {-3, -10, -3}
        };

        private float[,] verticalKernel = new float[,]
        {
            { 3, 0, -3},
            {10, 0,-10},
            { 3, 0, -3}
        };

        public SharraFilter() : base(null) { }

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

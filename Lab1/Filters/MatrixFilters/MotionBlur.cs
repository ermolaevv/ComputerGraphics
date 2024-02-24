using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Filters
{
    internal class MotionBlur : MatrixFilter
    {
        public MotionBlur()
        {
            int n = 7;

            kernel = new float[n,n];
            for (int i = 0; i < n; i++)
            {
                kernel[i, i] = 1f / (float)n;
            }
        }
    }
}

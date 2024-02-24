using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Filters
{
    internal class PruittFilter: MatrixFilter
    {
        public PruittFilter() {
            float[,] horizontalKernel = new float[,]
            {
                {-1, -1, -1},
                {0, 0, 0},
                {1, 1, 1}
            };
            float[,] verticalKernel = new float[,]
            {
                {-1, 0, 1},
                {-1, 0, 1},
                {-1, 0, 1}
            };
            kernel = CombineKernels(horizontalKernel, verticalKernel);
        }

        private float[,] CombineKernels(float[,] kernel1, float[,] kernel2)
        {
            int size = kernel1.GetLength(0);
            float[,] combinedKernel = new float[size, size];

            for (int i = 0; i < size; i++){
                for (int j = 0; j < size; j++){
                    combinedKernel[i, j] = kernel1[i, j] * kernel2[i, j];
                }
            }
            return combinedKernel;
        }
    }
}

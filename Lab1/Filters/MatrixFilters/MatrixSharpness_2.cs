using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Filters
{
    internal class MatrixSharpness_2: MatrixFilter
    {
        public MatrixSharpness_2(): base(new float[,] { {-1,-1,-1 }, {-1, 9, -1 }, { -1, -1, -1} }) {}
    }
}

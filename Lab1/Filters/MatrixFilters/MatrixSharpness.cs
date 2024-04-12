using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Filters
{
    internal class MatrixSharpness: MatrixFilter
    {
        public MatrixSharpness() : base(new float[,] { { 0, -1, 0 }, { -1, 5, -1 }, { 0, -1, 0 } }) {}
    }
}

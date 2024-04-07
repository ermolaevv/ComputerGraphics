using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public struct TransferFunctionRange
    {
        public int Min;
        public int Max;
        public Color Color;

        public TransferFunctionRange(int min, int max, Color color)
        {
            Min = min;
            Max = max;
            Color = color;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Forms
{
    internal class MaskElement : Button
    {
        protected int x, y;

        public MaskElement(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int GetX() { return x; }
        public int GetY() { return y; }
    }
}

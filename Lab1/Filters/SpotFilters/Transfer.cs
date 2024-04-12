using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Filters
{
    internal class Transfer : Filter
    {
        private int transfer_constant;
        public Transfer(int transfer_constant)
        {
            this.transfer_constant = transfer_constant;
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int newX = x + transfer_constant;
            int newY = y;
            if (newX < 0 || newX >= sourceImage.Width ||
                newY < 0 || newY >= sourceImage.Height)
                return Color.Black;
            
            return sourceImage.GetPixel(newX, newY);
        }
    }
}

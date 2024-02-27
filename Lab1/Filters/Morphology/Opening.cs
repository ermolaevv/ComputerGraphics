using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Filters
{
    internal class Opening : MorphOperation
    {
        public Opening(bool[,] mask) : base(mask) { }

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker backgroundWorker)
        {
            sourceImage = new Erosion(kernel).processImage(sourceImage, backgroundWorker);
            return new Dilation(kernel).processImage(sourceImage, backgroundWorker);
        }


        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}

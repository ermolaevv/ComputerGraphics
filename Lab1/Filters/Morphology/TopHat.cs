using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Filters
{
    internal class TopHat : MorphOperation
    {
        public TopHat(bool[,] mask, int threshold = 128) : base(mask, threshold) { }

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker backgroundWorker)
        {
            Bitmap newImage = new Opening(kernel, threshold).processImage(sourceImage, backgroundWorker);
            sourceImage = new Binarization(threshold).processImage(sourceImage, backgroundWorker);
            return Difference(sourceImage, newImage);
        }


        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            throw new NotImplementedException();
        }
    
    }
}

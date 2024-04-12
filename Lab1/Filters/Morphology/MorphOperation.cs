using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Filters
{
    abstract class MorphOperation : Filter
    {
        protected bool[,] kernel;
        protected int MW, MH;
        protected int threshold;
        public MorphOperation(bool[,] mask, int threshold = 128)
        {
            kernel = mask;
            MW = mask.GetLength(0);
            MH = mask.GetLength(1);
            this.threshold = threshold; 
        }
        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker backgroundWorker)
        {
            sourceImage = new Binarization(threshold).processImage(sourceImage, backgroundWorker);
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);

            for (int j = MH/2; j < sourceImage.Height - MH/2; j++)
            {
                backgroundWorker.ReportProgress((int)((float)j / resultImage.Width * 100));
                if (backgroundWorker.CancellationPending)
                    return null;

                for (int i = MW/2; i < sourceImage.Width - MW/2; i++)   
                {
                    resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));
                }
            }   
            return resultImage;
        }
    }
}

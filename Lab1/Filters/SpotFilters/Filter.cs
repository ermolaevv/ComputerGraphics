using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Filters
{
    abstract class Filter
    {
        protected abstract Color calculateNewPixelColor(Bitmap sourceImage, int x, int y);
        public virtual Bitmap processImage(Bitmap sourceImage, BackgroundWorker backgroundWorker)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);

            for (int i = 0; i < sourceImage.Width; i++)
            {
                backgroundWorker.ReportProgress((int)((float)i / resultImage.Width * 100));
                if (backgroundWorker.CancellationPending)
                    return null;

                for (int j = 0; j < sourceImage.Height; j++) 
                {
                    resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));
                }
            }
            return resultImage;
        }
        protected int Clamp(int value, int min, int max)
        {
            if (value < min) 
            { 
                return min;
            }
            if (value > max)
            {
                return max;
            }
            return value;
        }
        protected int GetIntesity(Color sourceColor)
        {
            return (int)(0.299 * sourceColor.R +
                                0.587 * sourceColor.G +
                                0.114 * sourceColor.B);
        }
    }
}

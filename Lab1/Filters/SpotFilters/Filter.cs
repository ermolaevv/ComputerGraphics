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
        protected int GetIntensity(Color sourceColor)
        {
            return (int)(0.299 * sourceColor.R +
                                0.587 * sourceColor.G +
                                0.114 * sourceColor.B);
        }

        protected Bitmap Difference(Bitmap src1, Bitmap src2)
        {
            int width = Math.Max(src1.Width, src2.Width);
            int height = Math.Max(src1.Height, src2.Height);

            Bitmap result = new Bitmap(width, height);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; (j < height); j++)
                {
                    Color color;
                    if (src1.GetPixel(i, j) == src2.GetPixel(i, j))
                        color = Color.Black;
                    else
                        color = Color.White;
                    result.SetPixel(i, j, color);
                }
            }

            return result;
        }
    }
}

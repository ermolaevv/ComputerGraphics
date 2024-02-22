using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Filters
{
    internal class GrayScaleFilter : Filter
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            int intesity = (int)(0.299 * sourceColor.R +
                                0.587 * sourceColor.G +
                                0.114 * sourceColor.B);
            Color resultColor = Color.FromArgb(intesity, intesity, intesity);
            return resultColor;
        }
    }
}

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

            int intesity = GetIntesity(sourceColor);

            Color resultColor = Color.FromArgb(intesity, intesity, intesity);
            return resultColor;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Filters
{
    internal class IncreaceBrightness: Filter
    {
        private int brightnessIncrease; 
        public IncreaceBrightness(int brightnessIncrease)
        {
            this.brightnessIncrease = brightnessIncrease;
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            int newRed = sourceColor.R + brightnessIncrease;
            int newGreen = sourceColor.G + brightnessIncrease;
            int newBlue = sourceColor.B + brightnessIncrease;
            Color resultColor = Color.FromArgb(Clamp(newRed, 0 ,255), Clamp(newGreen, 0, 255), Clamp(newBlue, 0, 255));
            return resultColor;
        }
    }
}

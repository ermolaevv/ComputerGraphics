using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Filters
{
    internal class GlowingEdges : Filter
    {
        public GlowingEdges() { }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            throw new NotImplementedException();
        }
        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker backgroundWorker)
        {
            Filter median = new Filters.MedianFilter(5);
            Filter pruitt = new Filters.SobelFilter();
            Filter maximum = new Filters.MaximumFilter(5);

            sourceImage = median.processImage(sourceImage, backgroundWorker);
            sourceImage = pruitt.processImage(sourceImage, backgroundWorker);
            return maximum.processImage(sourceImage, backgroundWorker);
        }
    }
}

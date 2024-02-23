namespace Lab1
{
    public partial class Form1 : Form
    {
        private static Bitmap src;
        private static Bitmap reference;
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            string filename = openFileDialog1.FileName;

            src = Service.CreateNonIndexedImage(new Bitmap(filename));
            reference = src;

            pictureBox1.Image = src;

            ôèëüòðûToolStripMenuItem.Enabled = true;
            âîññòàíîâèòüToolStripMenuItem.Enabled = true;
            saveToolStripMenuItem.Enabled = true;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                saveFileDialog1.FileName = DateTimeOffset.Now.ToUnixTimeSeconds().ToString() + ".png";
                saveFileDialog1.OverwritePrompt = true;
                saveFileDialog1.CheckPathExists = true;
                saveFileDialog1.Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|" +
                    "Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";

                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;

                pictureBox1.Image.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        private void èíâåðñèÿToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters.Filter filter = new Filters.InvertFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            cancelButton.Enabled = true;
            Bitmap newImage = ((Filters.Filter)e.Argument).processImage(src, backgroundWorker1);
            if (!backgroundWorker1.CancellationPending)
            {
                src = newImage;
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                cancelButton.Enabled = false;
                pictureBox1.Image = src;
                pictureBox1.Refresh();
            }
            progressBar1.Value = 0;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            cancelButton.Enabled = false;
            backgroundWorker1.CancelAsync();
        }

        private void grayScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters.Filter filter = new Filters.GrayScaleFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void ðàçìûòèåToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters.Filter filter = new Filters.BlurFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void ðàçìûòèåÏîÃàóññóToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters.Filter filter = new Filters.GaussianFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void ñåïèÿToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters.Filter filter = new Filters.SepiaFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void âîññòàíîâèòüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            src = reference;
            pictureBox1.Image = src;
            pictureBox1.Refresh();
        }
    }
}
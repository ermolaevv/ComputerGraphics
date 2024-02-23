namespace Lab1
{
    public partial class Form1 : Form
    {
        private static Bitmap src;
        private static Bitmap reference;
        private static LinkedList<Bitmap> history;
        private const int maxHistorySize = 10;
        public Form1()
        {
            InitializeComponent();
            history = new LinkedList<Bitmap>();
        }

        #region File
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            string filename = openFileDialog1.FileName;

            src = Service.CreateNonIndexedImage(new Bitmap(filename));
            reference = src;

            pictureBox1.Image = src;

            �������ToolStripMenuItem.Enabled = true;
            ������������ToolStripMenuItem.Enabled = true;
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
        #endregion
        private void ������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateHistory();
            src = reference;
            pictureBox1.Image = src;
            pictureBox1.Refresh();
        }
        private void undo()
        {
            if (history.Count > 0)
            {
                src = history.Last();
                history.RemoveLast();

                pictureBox1.Image = src;
                pictureBox1.Refresh();
            }
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            cancelButton.Enabled = false;
            backgroundWorker1.CancelAsync();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                switch(e.KeyCode)
                {
                    case Keys.S:
                        saveToolStripMenuItem_Click(sender, e);
                        break;
                    case Keys.O:
                        openToolStripMenuItem_Click(sender, e);
                        break;
                    case Keys.Z:
                        undo();
                        break;
                    case Keys.R:
                        ������������ToolStripMenuItem_Click(sender, e);
                        break;
                }
            }
        }

        #region BackgroundWorker
        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            cancelButton.Enabled = true;
            Bitmap newImage = ((Filters.Filter)e.Argument).processImage(src, backgroundWorker1);
            if (!backgroundWorker1.CancellationPending)
            {
                updateHistory();

                src = newImage;
            }
        }

        private void updateHistory()
        {
            if (history.Count == maxHistorySize)
                history.RemoveFirst();

            history.AddLast(src);
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
        #endregion

        #region FilterItem_Click
        private void ��������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters.Filter filter = new Filters.InvertFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }
        private void grayScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters.Filter filter = new Filters.GrayScaleFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void ��������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters.Filter filter = new Filters.BlurFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void ����������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters.Filter filter = new Filters.GaussianFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void �����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters.Filter filter = new Filters.SepiaFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }
        #endregion
    }
}
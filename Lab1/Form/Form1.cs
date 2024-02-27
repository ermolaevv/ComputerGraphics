using Lab1.Filters;
using Microsoft.VisualBasic;

namespace Lab1
{
    public partial class Form1 : Form
    {
        private static Bitmap src;
        private static Bitmap reference;
        private static Bitmap newImage;
        private static LinkedList<Bitmap> history;
        private const int maxHistorySize = 10;
        private Size originalPictureBoxSize;
        private Point originalPictureBoxLocation;
        private int bottomControlsHeight;
        public Form1()
        {
            InitializeComponent();
            history = new LinkedList<Bitmap>();

            originalPictureBoxSize = pictureBox1.Size;
            originalPictureBoxLocation = pictureBox1.Location;

            bottomControlsHeight = this.ClientSize.Height - (pictureBox1.Location.Y + pictureBox1.Height) + progressBar1.Height + cancelButton.Height + 1; 
            this.Resize += Form1_Resize;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            ResizeControlKeepingBottomSpace(pictureBox1, originalPictureBoxSize, originalPictureBoxLocation, bottomControlsHeight);
        }

        private void ResizeControlKeepingBottomSpace(Control control, Size originalSize, Point originalLocation, int bottomSpace)
        {
            int availableHeight = this.ClientSize.Height - bottomSpace - originalLocation.Y;
            float widthRatio = (float)this.ClientSize.Width / originalPictureBoxSize.Width;
            float heightRatio = (float)availableHeight / originalPictureBoxSize.Height;
            control.Size = new Size((int)(originalSize.Width * widthRatio), (int)(originalSize.Height * heightRatio));
            control.Location = new Point(originalLocation.X, originalLocation.Y); 
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

            фильтрыToolStripMenuItem.Enabled = true;
            восстановитьToolStripMenuItem.Enabled = true;
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

        private void восстановитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stopBackgroundWorkers();

            updateHistory();
            src = reference;
            pictureBox1.Image = src;
            pictureBox1.Refresh();
        }

        private void undo()
        {
            if (history.Count > 0)
            {
                stopBackgroundWorkers();

                src = history.Last();
                history.RemoveLast();

                pictureBox1.Image = src;
                pictureBox1.Refresh();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
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
                        восстановитьToolStripMenuItem_Click(sender, e);
                        break;
                }
            }
        }

        #region BackgroundWorker
        private void cancelButton_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }
        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            cancelButton.Enabled = true;

            Bitmap processImage = ((Filters.Filter)e.Argument).processImage(src, backgroundWorker1);
            if (!backgroundWorker1.CancellationPending)
            {
                newImage = processImage;
            }
            else
            {
                newImage = src;
            }
        }

        private void updateHistory()
        {
            if (history.Count == maxHistorySize)
                history.RemoveFirst();

            history.AddLast(src);
        }

        private void backgroundWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar1.Value = Math.Max(Math.Min(e.ProgressPercentage, 100), 0);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                updateHistory();
                src = newImage;

                pictureBox1.Image = src;
                pictureBox1.Refresh();
            }
            cancelButton.Enabled = false;
            progressBar1.Value = 0;
        }
        private void stopBackgroundWorkers()
        {
            if (backgroundWorker1.IsBusy)
                backgroundWorker1.CancelAsync();
            while (backgroundWorker1.IsBusy)
            {
                Thread.Sleep(200);
                Application.DoEvents();
            }
        }
        #endregion

        #region FilterItem_Click
        private void инверсияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters.Filter filter = new Filters.InvertFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }
        private void grayScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters.Filter filter = new Filters.GrayScaleFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void размытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters.Filter filter = new Filters.BlurFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void размытиеПоГауссуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters.Filter filter = new Filters.GaussianFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void сепияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters.Filter filter = new Filters.SepiaFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void тиснениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters.Filter filter = new Filters.EmbossingFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }
        private void увеличениеЯркостиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string string_constant = Interaction.InputBox("Введите константу: ");
            int string_To_Int_constant = Convert.ToInt32(string_constant);
            Filters.Filter filter = new Filters.IncreaceBrightness(string_To_Int_constant);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void собельToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters.Filter filter = new Filters.SobelFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void резкостьматричнаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters.Filter filter = new Filters.MatrixSharpness();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void motionBlurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters.Filter filter = new Filters.MotionBlur();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void переносToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string string_constant = Interaction.InputBox("Введите константу: ");
            int string_To_Int_constant = Convert.ToInt32(string_constant);
            Filters.Filter filter = new Filters.Transfer(string_To_Int_constant);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void поворотToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string string_constant = Interaction.InputBox("Введите константу: ");
            int string_To_Int_constant = Convert.ToInt32(string_constant);
            Filters.Filter filter = new Filters.Rotation(string_To_Int_constant);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void серыйМирToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters.Filter filter = new Filters.GrayWorld(src);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void идеальныйОтражательToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters.Filter filter = new Filters.PerfectReflector(src);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void линейнаяКоррекцияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters.Filter filter = new Filters.LinearCorrection(src);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void коррекцияСОпорнымЦветомToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialogSource = new ColorDialog();
            if (colorDialogSource.ShowDialog() == DialogResult.OK)
            {
                Color sourceColor = colorDialogSource.Color;
                ColorDialog colorDialogResult = new ColorDialog();
                if (colorDialogResult.ShowDialog() == DialogResult.OK)
                {
                    Color resultColor = colorDialogResult.Color;
                    Filters.Filter filter = new Filters.ReferenceColorCorrection(sourceColor, resultColor);
                    backgroundWorker1.RunWorkerAsync(filter);
                }
            }
        }


        private void резкость2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters.Filter filter = new Filters.MatrixSharpness_2();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void щерраToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters.Filter filter = new Filters.SharraFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void прюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters.Filter filter = new Filters.PruittFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void волны1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters.Filter filter = new Filters.WaveFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void волны2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters.Filter filter = new Filters.WaveFilter_2();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void стеклоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters.Filter filter = new Filters.GlassFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void медианныйФильтрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters.Filter filter = new Filters.MedianFilter(5);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void фильтрМаксмимумToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters.Filter filter = new Filters.MaximumFilter(5);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void фильтрминимумToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters.Filter filter = new Filters.MinimumFilter(5);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void светящиесяКраяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters.Filter filter = new Filters.GlowingEdges();
            backgroundWorker1.RunWorkerAsync(filter);
        }


        private void бинаризацияПоПорогуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string string_constant = Interaction.InputBox("Введите константу: ");
            int string_To_Int_constant = Convert.ToInt32(string_constant);
            Filters.Filter filter = new Filters.Binarization(string_To_Int_constant);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void расширениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            processMorphOperation(typeof(Dilation));
        }

        private void сужениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            processMorphOperation(typeof(Erosion));
        }

        private void открытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            processMorphOperation(typeof(Opening));
        }

        private void закрытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            processMorphOperation(typeof(Closing));
        }

        private void градиентToolStripMenuItem_Click(object sender, EventArgs e)
        {
            processMorphOperation(typeof(MorphGradient));
        }

        private void topHatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            processMorphOperation(typeof(TopHat));
        }

        private void blackHatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            processMorphOperation(typeof(BlackHat));
        }

        private void processMorphOperation(Type operation)
        {
            MaskInput maskInput = new MaskInput();
            maskInput.ShowDialog();
            if (maskInput.DialogResult != DialogResult.OK) return;

            bool[,] mask = maskInput.mask;
            int threshold = maskInput.threshold;
            Filters.Filter filter = (Filters.Filter)Activator.CreateInstance(operation, mask, threshold);

            backgroundWorker1.RunWorkerAsync(filter);
        }
        #endregion
    }
}

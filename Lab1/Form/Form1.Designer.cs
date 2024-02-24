namespace Lab1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            восстановитьToolStripMenuItem = new ToolStripMenuItem();
            фильтрыToolStripMenuItem = new ToolStripMenuItem();
            точечныеToolStripMenuItem = new ToolStripMenuItem();
            инверсияToolStripMenuItem = new ToolStripMenuItem();
            grayScaleToolStripMenuItem = new ToolStripMenuItem();
            увеличениеЯркостиToolStripMenuItem = new ToolStripMenuItem();
            сепияToolStripMenuItem = new ToolStripMenuItem();
            матричныеToolStripMenuItem = new ToolStripMenuItem();
            размытиеToolStripMenuItem = new ToolStripMenuItem();
            размытиеПоГауссуToolStripMenuItem = new ToolStripMenuItem();
            собельToolStripMenuItem = new ToolStripMenuItem();
            резкостьматричнаяToolStripMenuItem = new ToolStripMenuItem();
            тиснениеToolStripMenuItem = new ToolStripMenuItem();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            pictureBox1 = new PictureBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            progressBar1 = new ProgressBar();
            cancelButton = new Button();
            backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            резкость2ToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, фильтрыToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.Size = new Size(1262, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem, saveToolStripMenuItem, восстановитьToolStripMenuItem });
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(59, 24);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(224, 26);
            openToolStripMenuItem.Text = "Открыть";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Enabled = false;
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(224, 26);
            saveToolStripMenuItem.Text = "Сохранить";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // восстановитьToolStripMenuItem
            // 
            восстановитьToolStripMenuItem.Enabled = false;
            восстановитьToolStripMenuItem.Name = "восстановитьToolStripMenuItem";
            восстановитьToolStripMenuItem.Size = new Size(224, 26);
            восстановитьToolStripMenuItem.Text = "Восстановить";
            восстановитьToolStripMenuItem.Click += восстановитьToolStripMenuItem_Click;
            // 
            // фильтрыToolStripMenuItem
            // 
            фильтрыToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { точечныеToolStripMenuItem, матричныеToolStripMenuItem });
            фильтрыToolStripMenuItem.Enabled = false;
            фильтрыToolStripMenuItem.Name = "фильтрыToolStripMenuItem";
            фильтрыToolStripMenuItem.Size = new Size(85, 24);
            фильтрыToolStripMenuItem.Text = "Фильтры";
            // 
            // точечныеToolStripMenuItem
            // 
            точечныеToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { инверсияToolStripMenuItem, grayScaleToolStripMenuItem, увеличениеЯркостиToolStripMenuItem, сепияToolStripMenuItem });
            точечныеToolStripMenuItem.Name = "точечныеToolStripMenuItem";
            точечныеToolStripMenuItem.Size = new Size(224, 26);
            точечныеToolStripMenuItem.Text = "Точечные";
            // 
            // инверсияToolStripMenuItem
            // 
            инверсияToolStripMenuItem.Name = "инверсияToolStripMenuItem";
            инверсияToolStripMenuItem.Size = new Size(235, 26);
            инверсияToolStripMenuItem.Text = "Инверсия";
            инверсияToolStripMenuItem.Click += инверсияToolStripMenuItem_Click;
            // 
            // grayScaleToolStripMenuItem
            // 
            grayScaleToolStripMenuItem.Name = "grayScaleToolStripMenuItem";
            grayScaleToolStripMenuItem.Size = new Size(235, 26);
            grayScaleToolStripMenuItem.Text = "GrayScale";
            grayScaleToolStripMenuItem.Click += grayScaleToolStripMenuItem_Click;
            // 
            // увеличениеЯркостиToolStripMenuItem
            // 
            увеличениеЯркостиToolStripMenuItem.Name = "увеличениеЯркостиToolStripMenuItem";
            увеличениеЯркостиToolStripMenuItem.Size = new Size(235, 26);
            увеличениеЯркостиToolStripMenuItem.Text = "Увеличение яркости";
            увеличениеЯркостиToolStripMenuItem.Click += увеличениеЯркостиToolStripMenuItem_Click;
            // 
            // сепияToolStripMenuItem
            // 
            сепияToolStripMenuItem.Name = "сепияToolStripMenuItem";
            сепияToolStripMenuItem.Size = new Size(235, 26);
            сепияToolStripMenuItem.Text = "Сепия";
            сепияToolStripMenuItem.Click += сепияToolStripMenuItem_Click;
            // 
            // матричныеToolStripMenuItem
            // 
            матричныеToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { размытиеToolStripMenuItem, размытиеПоГауссуToolStripMenuItem, собельToolStripMenuItem, резкостьматричнаяToolStripMenuItem, тиснениеToolStripMenuItem, резкость2ToolStripMenuItem });
            матричныеToolStripMenuItem.Name = "матричныеToolStripMenuItem";
            матричныеToolStripMenuItem.Size = new Size(224, 26);
            матричныеToolStripMenuItem.Text = "Матричные";
            // 
            // размытиеToolStripMenuItem
            // 
            размытиеToolStripMenuItem.Name = "размытиеToolStripMenuItem";
            размытиеToolStripMenuItem.Size = new Size(229, 26);
            размытиеToolStripMenuItem.Text = "Размытие";
            размытиеToolStripMenuItem.Click += размытиеToolStripMenuItem_Click;
            // 
            // размытиеПоГауссуToolStripMenuItem
            // 
            размытиеПоГауссуToolStripMenuItem.Name = "размытиеПоГауссуToolStripMenuItem";
            размытиеПоГауссуToolStripMenuItem.Size = new Size(229, 26);
            размытиеПоГауссуToolStripMenuItem.Text = "Размытие по Гауссу";
            размытиеПоГауссуToolStripMenuItem.Click += размытиеПоГауссуToolStripMenuItem_Click;
            // 
            // собельToolStripMenuItem
            // 
            собельToolStripMenuItem.Name = "собельToolStripMenuItem";
            собельToolStripMenuItem.Size = new Size(229, 26);
            собельToolStripMenuItem.Text = "Собель";
            собельToolStripMenuItem.Click += собельToolStripMenuItem_Click;
            // 
            // резкостьматричнаяToolStripMenuItem
            // 
            резкостьматричнаяToolStripMenuItem.Name = "резкостьматричнаяToolStripMenuItem";
            резкостьматричнаяToolStripMenuItem.Size = new Size(229, 26);
            резкостьматричнаяToolStripMenuItem.Text = "Резкость 1";
            резкостьматричнаяToolStripMenuItem.Click += резкостьматричнаяToolStripMenuItem_Click;
            // 
            // тиснениеToolStripMenuItem
            // 
            тиснениеToolStripMenuItem.Name = "тиснениеToolStripMenuItem";
            тиснениеToolStripMenuItem.Size = new Size(229, 26);
            тиснениеToolStripMenuItem.Text = "Тиснение";
            тиснениеToolStripMenuItem.Click += тиснениеToolStripMenuItem_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(0, 29);
            pictureBox1.Margin = new Padding(2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1262, 519);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += backgroundWorker_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(10, 559);
            progressBar1.Margin = new Padding(2);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(1108, 28);
            progressBar1.TabIndex = 2;
            // 
            // cancelButton
            // 
            cancelButton.Enabled = false;
            cancelButton.Location = new Point(1128, 558);
            cancelButton.Margin = new Padding(2);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(122, 29);
            cancelButton.TabIndex = 3;
            cancelButton.Text = "Отмена";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // backgroundWorker2
            // 
            backgroundWorker2.DoWork += backgroundWorker_DoWork;
            backgroundWorker2.ProgressChanged += backgroundWorker_ProgressChanged;
            backgroundWorker2.RunWorkerCompleted += backgroundWorker2_RunWorkerCompleted;
            // 
            // резкость2ToolStripMenuItem
            // 
            резкость2ToolStripMenuItem.Name = "резкость2ToolStripMenuItem";
            резкость2ToolStripMenuItem.Size = new Size(229, 26);
            резкость2ToolStripMenuItem.Text = "Резкость 2";
            резкость2ToolStripMenuItem.Click += резкость2ToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1262, 595);
            Controls.Add(cancelButton);
            Controls.Add(progressBar1);
            Controls.Add(pictureBox1);
            Controls.Add(menuStrip1);
            KeyPreview = true;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(2);
            Name = "Form1";
            Text = "Лабораторная работа 1";
            KeyDown += Form1_KeyDown;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem фильтрыToolStripMenuItem;
        private ToolStripMenuItem точечныеToolStripMenuItem;
        private ToolStripMenuItem инверсияToolStripMenuItem;
        private ToolStripMenuItem матричныеToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private PictureBox pictureBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ProgressBar progressBar1;
        private Button cancelButton;
        private ToolStripMenuItem grayScaleToolStripMenuItem;
        private ToolStripMenuItem размытиеToolStripMenuItem;
        private ToolStripMenuItem размытиеПоГауссуToolStripMenuItem;
        private ToolStripMenuItem увеличениеЯркостиToolStripMenuItem;
        private ToolStripMenuItem собельToolStripMenuItem;
        private ToolStripMenuItem резкостьматричнаяToolStripMenuItem;
        private ToolStripMenuItem сепияToolStripMenuItem;
        private ToolStripMenuItem восстановитьToolStripMenuItem;
        private ToolStripMenuItem тиснениеToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private ToolStripMenuItem резкость2ToolStripMenuItem;
    }
}

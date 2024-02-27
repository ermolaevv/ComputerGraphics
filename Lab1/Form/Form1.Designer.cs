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
            переносToolStripMenuItem = new ToolStripMenuItem();
            поворотToolStripMenuItem = new ToolStripMenuItem();
            серыйМирToolStripMenuItem = new ToolStripMenuItem();
            идеальныйОтражательToolStripMenuItem = new ToolStripMenuItem();
            линейнаяКоррекцияToolStripMenuItem = new ToolStripMenuItem();
            коррекцияСОпорнымЦветомToolStripMenuItem = new ToolStripMenuItem();
            волны1ToolStripMenuItem = new ToolStripMenuItem();
            волны2ToolStripMenuItem = new ToolStripMenuItem();
            стеклоToolStripMenuItem = new ToolStripMenuItem();
            бинаризацияПоПорогуToolStripMenuItem = new ToolStripMenuItem();
            матричныеToolStripMenuItem = new ToolStripMenuItem();
            размытиеToolStripMenuItem = new ToolStripMenuItem();
            размытиеПоГауссуToolStripMenuItem = new ToolStripMenuItem();
            собельToolStripMenuItem = new ToolStripMenuItem();
            резкостьматричнаяToolStripMenuItem = new ToolStripMenuItem();
            тиснениеToolStripMenuItem = new ToolStripMenuItem();
            motionBlurToolStripMenuItem = new ToolStripMenuItem();
            резкость2ToolStripMenuItem = new ToolStripMenuItem();
            щерраToolStripMenuItem = new ToolStripMenuItem();
            прюToolStripMenuItem = new ToolStripMenuItem();
            медианныйФильтрToolStripMenuItem = new ToolStripMenuItem();
            фильтрминимумToolStripMenuItem = new ToolStripMenuItem();
            фильтрМаксмимумToolStripMenuItem = new ToolStripMenuItem();
            светящиесяКраяToolStripMenuItem = new ToolStripMenuItem();
            морфологияToolStripMenuItem = new ToolStripMenuItem();
            расширениеToolStripMenuItem = new ToolStripMenuItem();
            сужениеToolStripMenuItem = new ToolStripMenuItem();
            открытиеToolStripMenuItem = new ToolStripMenuItem();
            закрытиеToolStripMenuItem = new ToolStripMenuItem();
            градиентToolStripMenuItem = new ToolStripMenuItem();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            pictureBox1 = new PictureBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            progressBar1 = new ProgressBar();
            cancelButton = new Button();
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
            openToolStripMenuItem.Size = new Size(187, 26);
            openToolStripMenuItem.Text = "Открыть";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Enabled = false;
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(187, 26);
            saveToolStripMenuItem.Text = "Сохранить";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // восстановитьToolStripMenuItem
            // 
            восстановитьToolStripMenuItem.Enabled = false;
            восстановитьToolStripMenuItem.Name = "восстановитьToolStripMenuItem";
            восстановитьToolStripMenuItem.Size = new Size(187, 26);
            восстановитьToolStripMenuItem.Text = "Восстановить";
            восстановитьToolStripMenuItem.Click += восстановитьToolStripMenuItem_Click;
            // 
            // фильтрыToolStripMenuItem
            // 
            фильтрыToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { точечныеToolStripMenuItem, матричныеToolStripMenuItem, морфологияToolStripMenuItem });
            фильтрыToolStripMenuItem.Enabled = false;
            фильтрыToolStripMenuItem.Name = "фильтрыToolStripMenuItem";
            фильтрыToolStripMenuItem.Size = new Size(85, 24);
            фильтрыToolStripMenuItem.Text = "Фильтры";
            // 
            // точечныеToolStripMenuItem
            // 
            точечныеToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { инверсияToolStripMenuItem, grayScaleToolStripMenuItem, увеличениеЯркостиToolStripMenuItem, сепияToolStripMenuItem, переносToolStripMenuItem, поворотToolStripMenuItem, серыйМирToolStripMenuItem, идеальныйОтражательToolStripMenuItem, линейнаяКоррекцияToolStripMenuItem, коррекцияСОпорнымЦветомToolStripMenuItem, волны1ToolStripMenuItem, волны2ToolStripMenuItem, стеклоToolStripMenuItem, бинаризацияПоПорогуToolStripMenuItem });
            точечныеToolStripMenuItem.Name = "точечныеToolStripMenuItem";
            точечныеToolStripMenuItem.Size = new Size(173, 26);
            точечныеToolStripMenuItem.Text = "Точечные";
            // 
            // инверсияToolStripMenuItem
            // 
            инверсияToolStripMenuItem.Name = "инверсияToolStripMenuItem";
            инверсияToolStripMenuItem.Size = new Size(306, 26);
            инверсияToolStripMenuItem.Text = "Инверсия";
            инверсияToolStripMenuItem.Click += инверсияToolStripMenuItem_Click;
            // 
            // grayScaleToolStripMenuItem
            // 
            grayScaleToolStripMenuItem.Name = "grayScaleToolStripMenuItem";
            grayScaleToolStripMenuItem.Size = new Size(306, 26);
            grayScaleToolStripMenuItem.Text = "GrayScale";
            grayScaleToolStripMenuItem.Click += grayScaleToolStripMenuItem_Click;
            // 
            // увеличениеЯркостиToolStripMenuItem
            // 
            увеличениеЯркостиToolStripMenuItem.Name = "увеличениеЯркостиToolStripMenuItem";
            увеличениеЯркостиToolStripMenuItem.Size = new Size(306, 26);
            увеличениеЯркостиToolStripMenuItem.Text = "Увеличение яркости";
            увеличениеЯркостиToolStripMenuItem.Click += увеличениеЯркостиToolStripMenuItem_Click;
            // 
            // сепияToolStripMenuItem
            // 
            сепияToolStripMenuItem.Name = "сепияToolStripMenuItem";
            сепияToolStripMenuItem.Size = new Size(306, 26);
            сепияToolStripMenuItem.Text = "Сепия";
            сепияToolStripMenuItem.Click += сепияToolStripMenuItem_Click;
            // 
            // переносToolStripMenuItem
            // 
            переносToolStripMenuItem.Name = "переносToolStripMenuItem";
            переносToolStripMenuItem.Size = new Size(306, 26);
            переносToolStripMenuItem.Text = "Перенос";
            переносToolStripMenuItem.Click += переносToolStripMenuItem_Click;
            // 
            // поворотToolStripMenuItem
            // 
            поворотToolStripMenuItem.Name = "поворотToolStripMenuItem";
            поворотToolStripMenuItem.Size = new Size(306, 26);
            поворотToolStripMenuItem.Text = "Поворот";
            поворотToolStripMenuItem.Click += поворотToolStripMenuItem_Click;
            // 
            // серыйМирToolStripMenuItem
            // 
            серыйМирToolStripMenuItem.Name = "серыйМирToolStripMenuItem";
            серыйМирToolStripMenuItem.Size = new Size(306, 26);
            серыйМирToolStripMenuItem.Text = "«Серый мир»";
            серыйМирToolStripMenuItem.Click += серыйМирToolStripMenuItem_Click;
            // 
            // идеальныйОтражательToolStripMenuItem
            // 
            идеальныйОтражательToolStripMenuItem.Name = "идеальныйОтражательToolStripMenuItem";
            идеальныйОтражательToolStripMenuItem.Size = new Size(306, 26);
            идеальныйОтражательToolStripMenuItem.Text = "«Идеальный отражатель»";
            идеальныйОтражательToolStripMenuItem.Click += идеальныйОтражательToolStripMenuItem_Click;
            // 
            // линейнаяКоррекцияToolStripMenuItem
            // 
            линейнаяКоррекцияToolStripMenuItem.Name = "линейнаяКоррекцияToolStripMenuItem";
            линейнаяКоррекцияToolStripMenuItem.Size = new Size(306, 26);
            линейнаяКоррекцияToolStripMenuItem.Text = "Линейная коррекция";
            линейнаяКоррекцияToolStripMenuItem.Click += линейнаяКоррекцияToolStripMenuItem_Click;
            // 
            // коррекцияСОпорнымЦветомToolStripMenuItem
            // 
            коррекцияСОпорнымЦветомToolStripMenuItem.Name = "коррекцияСОпорнымЦветомToolStripMenuItem";
            коррекцияСОпорнымЦветомToolStripMenuItem.Size = new Size(306, 26);
            коррекцияСОпорнымЦветомToolStripMenuItem.Text = "Коррекция с опорным цветом";
            коррекцияСОпорнымЦветомToolStripMenuItem.Click += коррекцияСОпорнымЦветомToolStripMenuItem_Click;
            // 
            // волны1ToolStripMenuItem
            // 
            волны1ToolStripMenuItem.Name = "волны1ToolStripMenuItem";
            волны1ToolStripMenuItem.Size = new Size(306, 26);
            волны1ToolStripMenuItem.Text = "Волны 1";
            волны1ToolStripMenuItem.Click += волны1ToolStripMenuItem_Click;
            // 
            // волны2ToolStripMenuItem
            // 
            волны2ToolStripMenuItem.Name = "волны2ToolStripMenuItem";
            волны2ToolStripMenuItem.Size = new Size(306, 26);
            волны2ToolStripMenuItem.Text = "Волны 2";
            волны2ToolStripMenuItem.Click += волны2ToolStripMenuItem_Click;
            // 
            // стеклоToolStripMenuItem
            // 
            стеклоToolStripMenuItem.Name = "стеклоToolStripMenuItem";
            стеклоToolStripMenuItem.Size = new Size(306, 26);
            стеклоToolStripMenuItem.Text = "Стекло";
            стеклоToolStripMenuItem.Click += стеклоToolStripMenuItem_Click;
            // 
            // бинаризацияПоПорогуToolStripMenuItem
            // 
            бинаризацияПоПорогуToolStripMenuItem.Name = "бинаризацияПоПорогуToolStripMenuItem";
            бинаризацияПоПорогуToolStripMenuItem.Size = new Size(368, 34);
            бинаризацияПоПорогуToolStripMenuItem.Text = "Бинаризация по порогу";
            бинаризацияПоПорогуToolStripMenuItem.Click += бинаризацияПоПорогуToolStripMenuItem_Click;
            // 
            // матричныеToolStripMenuItem
            // 
            матричныеToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { размытиеToolStripMenuItem, размытиеПоГауссуToolStripMenuItem, собельToolStripMenuItem, резкостьматричнаяToolStripMenuItem, тиснениеToolStripMenuItem, motionBlurToolStripMenuItem, резкость2ToolStripMenuItem, щерраToolStripMenuItem, прюToolStripMenuItem, медианныйФильтрToolStripMenuItem, фильтрминимумToolStripMenuItem, фильтрМаксмимумToolStripMenuItem, светящиесяКраяToolStripMenuItem });
            матричныеToolStripMenuItem.Name = "матричныеToolStripMenuItem";
            матричныеToolStripMenuItem.Size = new Size(173, 26);
            матричныеToolStripMenuItem.Text = "Матричные";
            // 
            // размытиеToolStripMenuItem
            // 
            размытиеToolStripMenuItem.Name = "размытиеToolStripMenuItem";
            размытиеToolStripMenuItem.Size = new Size(234, 26);
            размытиеToolStripMenuItem.Text = "Размытие";
            размытиеToolStripMenuItem.Click += размытиеToolStripMenuItem_Click;
            // 
            // размытиеПоГауссуToolStripMenuItem
            // 
            размытиеПоГауссуToolStripMenuItem.Name = "размытиеПоГауссуToolStripMenuItem";
            размытиеПоГауссуToolStripMenuItem.Size = new Size(234, 26);
            размытиеПоГауссуToolStripMenuItem.Text = "Размытие по Гауссу";
            размытиеПоГауссуToolStripMenuItem.Click += размытиеПоГауссуToolStripMenuItem_Click;
            // 
            // собельToolStripMenuItem
            // 
            собельToolStripMenuItem.Name = "собельToolStripMenuItem";
            собельToolStripMenuItem.Size = new Size(234, 26);
            собельToolStripMenuItem.Text = "Собель";
            собельToolStripMenuItem.Click += собельToolStripMenuItem_Click;
            // 
            // резкостьматричнаяToolStripMenuItem
            // 
            резкостьматричнаяToolStripMenuItem.Name = "резкостьматричнаяToolStripMenuItem";
            резкостьматричнаяToolStripMenuItem.Size = new Size(234, 26);
            резкостьматричнаяToolStripMenuItem.Text = "Резкость 1";
            резкостьматричнаяToolStripMenuItem.Click += резкостьматричнаяToolStripMenuItem_Click;
            // 
            // тиснениеToolStripMenuItem
            // 
            тиснениеToolStripMenuItem.Name = "тиснениеToolStripMenuItem";
            тиснениеToolStripMenuItem.Size = new Size(234, 26);
            тиснениеToolStripMenuItem.Text = "Тиснение";
            тиснениеToolStripMenuItem.Click += тиснениеToolStripMenuItem_Click;
            // 
            // motionBlurToolStripMenuItem
            // 
            motionBlurToolStripMenuItem.Name = "motionBlurToolStripMenuItem";
            motionBlurToolStripMenuItem.Size = new Size(234, 26);
            motionBlurToolStripMenuItem.Text = "Motion Blur";
            motionBlurToolStripMenuItem.Click += motionBlurToolStripMenuItem_Click;
            // 
            // резкость2ToolStripMenuItem
            // 
            резкость2ToolStripMenuItem.Name = "резкость2ToolStripMenuItem";
            резкость2ToolStripMenuItem.Size = new Size(234, 26);
            резкость2ToolStripMenuItem.Text = "Резкость 2";
            резкость2ToolStripMenuItem.Click += резкость2ToolStripMenuItem_Click;
            // 
            // щерраToolStripMenuItem
            // 
            щерраToolStripMenuItem.Name = "щерраToolStripMenuItem";
            щерраToolStripMenuItem.Size = new Size(234, 26);
            щерраToolStripMenuItem.Text = "Щерра";
            щерраToolStripMenuItem.Click += щерраToolStripMenuItem_Click;
            // 
            // прюToolStripMenuItem
            // 
            прюToolStripMenuItem.Name = "прюToolStripMenuItem";
            прюToolStripMenuItem.Size = new Size(234, 26);
            прюToolStripMenuItem.Text = "Прюитт";
            прюToolStripMenuItem.Click += прюToolStripMenuItem_Click;
            // 
            // медианныйФильтрToolStripMenuItem
            // 
            медианныйФильтрToolStripMenuItem.Name = "медианныйФильтрToolStripMenuItem";
            медианныйФильтрToolStripMenuItem.Size = new Size(234, 26);
            медианныйФильтрToolStripMenuItem.Text = "Медианный фильтр";
            медианныйФильтрToolStripMenuItem.Click += медианныйФильтрToolStripMenuItem_Click;
            // 
            // фильтрминимумToolStripMenuItem
            // 
            фильтрминимумToolStripMenuItem.Name = "фильтрминимумToolStripMenuItem";
            фильтрминимумToolStripMenuItem.Size = new Size(234, 26);
            фильтрминимумToolStripMenuItem.Text = "Фильтр «минимум»";
            фильтрминимумToolStripMenuItem.Click += фильтрминимумToolStripMenuItem_Click;
            // 
            // фильтрМаксмимумToolStripMenuItem
            // 
            фильтрМаксмимумToolStripMenuItem.Name = "фильтрМаксмимумToolStripMenuItem";
            фильтрМаксмимумToolStripMenuItem.Size = new Size(234, 26);
            фильтрМаксмимумToolStripMenuItem.Text = "Фильтр «максимум»";
            фильтрМаксмимумToolStripMenuItem.Click += фильтрМаксмимумToolStripMenuItem_Click;
            // 
            // светящиесяКраяToolStripMenuItem
            // 
            светящиесяКраяToolStripMenuItem.Name = "светящиесяКраяToolStripMenuItem";
            светящиесяКраяToolStripMenuItem.Size = new Size(234, 26);
            светящиесяКраяToolStripMenuItem.Text = "Светящиеся края";
            светящиесяКраяToolStripMenuItem.Click += светящиесяКраяToolStripMenuItem_Click;
            // 
            // морфологияToolStripMenuItem
            // 
            морфологияToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { расширениеToolStripMenuItem, сужениеToolStripMenuItem, открытиеToolStripMenuItem, закрытиеToolStripMenuItem, градиентToolStripMenuItem });
            морфологияToolStripMenuItem.Name = "морфологияToolStripMenuItem";
            морфологияToolStripMenuItem.Size = new Size(270, 34);
            морфологияToolStripMenuItem.Text = "Морфология";
            // 
            // расширениеToolStripMenuItem
            // 
            расширениеToolStripMenuItem.Name = "расширениеToolStripMenuItem";
            расширениеToolStripMenuItem.Size = new Size(270, 34);
            расширениеToolStripMenuItem.Text = "Расширение";
            расширениеToolStripMenuItem.Click += расширениеToolStripMenuItem_Click;
            // 
            // сужениеToolStripMenuItem
            // 
            сужениеToolStripMenuItem.Name = "сужениеToolStripMenuItem";
            сужениеToolStripMenuItem.Size = new Size(270, 34);
            сужениеToolStripMenuItem.Text = "Сужение";
            сужениеToolStripMenuItem.Click += сужениеToolStripMenuItem_Click;
            // 
            // открытиеToolStripMenuItem
            // 
            открытиеToolStripMenuItem.Name = "открытиеToolStripMenuItem";
            открытиеToolStripMenuItem.Size = new Size(270, 34);
            открытиеToolStripMenuItem.Text = "Открытие";
            открытиеToolStripMenuItem.Click += открытиеToolStripMenuItem_Click;
            // 
            // закрытиеToolStripMenuItem
            // 
            закрытиеToolStripMenuItem.Name = "закрытиеToolStripMenuItem";
            закрытиеToolStripMenuItem.Size = new Size(270, 34);
            закрытиеToolStripMenuItem.Text = "Закрытие";
            закрытиеToolStripMenuItem.Click += закрытиеToolStripMenuItem_Click;
            // 
            // градиентToolStripMenuItem
            // 
            градиентToolStripMenuItem.Name = "градиентToolStripMenuItem";
            градиентToolStripMenuItem.Size = new Size(270, 34);
            градиентToolStripMenuItem.Text = "Градиент";
            градиентToolStripMenuItem.Click += градиентToolStripMenuItem_Click;
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
            progressBar1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            progressBar1.Location = new Point(10, 559);
            progressBar1.Margin = new Padding(2);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(1108, 28);
            progressBar1.TabIndex = 2;
            // 
            // cancelButton
            // 
            cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
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
        private ToolStripMenuItem motionBlurToolStripMenuItem;
        private ToolStripMenuItem переносToolStripMenuItem;
        private ToolStripMenuItem поворотToolStripMenuItem;
        private ToolStripMenuItem серыйМирToolStripMenuItem;
        private ToolStripMenuItem идеальныйОтражательToolStripMenuItem;
        private ToolStripMenuItem линейнаяКоррекцияToolStripMenuItem;
        private ToolStripMenuItem коррекцияСОпорнымЦветомToolStripMenuItem;
        private ToolStripMenuItem медианныйФильтрToolStripMenuItem;
        private ToolStripMenuItem резкость2ToolStripMenuItem;
        private ToolStripMenuItem щерраToolStripMenuItem;
        private ToolStripMenuItem прюToolStripMenuItem;
        private ToolStripMenuItem волны1ToolStripMenuItem;
        private ToolStripMenuItem волны2ToolStripMenuItem;
        private ToolStripMenuItem стеклоToolStripMenuItem;
        private ToolStripMenuItem светящиесяКраяToolStripMenuItem;
        private ToolStripMenuItem фильтрМаксмимумToolStripMenuItem;
        private ToolStripMenuItem фильтрминимумToolStripMenuItem;
        private ToolStripMenuItem бинаризацияПоПорогуToolStripMenuItem;
        private ToolStripMenuItem морфологияToolStripMenuItem;
        private ToolStripMenuItem расширениеToolStripMenuItem;
        private ToolStripMenuItem сужениеToolStripMenuItem;
        private ToolStripMenuItem открытиеToolStripMenuItem;
        private ToolStripMenuItem закрытиеToolStripMenuItem;
        private ToolStripMenuItem градиентToolStripMenuItem;
    }
}

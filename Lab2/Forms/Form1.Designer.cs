using System.Drawing;
using System.Windows.Forms;

namespace Lab2.Forms
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.режимРендераToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quadStripToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.эToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.объёмныйРендерингToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.glControl1 = new OpenTK.GLControl();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.цветТрансферфункцииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.режимРендераToolStripMenuItem,
            this.эToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1529, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(98, 29);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // режимРендераToolStripMenuItem
            // 
            this.режимРендераToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quadToolStripMenuItem,
            this.quadStripToolStripMenuItem,
            this.textureToolStripMenuItem});
            this.режимРендераToolStripMenuItem.Enabled = false;
            this.режимРендераToolStripMenuItem.Name = "режимРендераToolStripMenuItem";
            this.режимРендераToolStripMenuItem.Size = new System.Drawing.Size(157, 29);
            this.режимРендераToolStripMenuItem.Text = "Режим рендера";
            // 
            // quadToolStripMenuItem
            // 
            this.quadToolStripMenuItem.Name = "quadToolStripMenuItem";
            this.quadToolStripMenuItem.Size = new System.Drawing.Size(194, 34);
            this.quadToolStripMenuItem.Text = "Quad";
            this.quadToolStripMenuItem.Click += new System.EventHandler(this.quadToolStripMenuItem_Click);
            // 
            // quadStripToolStripMenuItem
            // 
            this.quadStripToolStripMenuItem.Name = "quadStripToolStripMenuItem";
            this.quadStripToolStripMenuItem.Size = new System.Drawing.Size(194, 34);
            this.quadStripToolStripMenuItem.Text = "QuadStrip";
            this.quadStripToolStripMenuItem.Click += new System.EventHandler(this.quadStripToolStripMenuItem_Click);
            // 
            // textureToolStripMenuItem
            // 
            this.textureToolStripMenuItem.Name = "textureToolStripMenuItem";
            this.textureToolStripMenuItem.Size = new System.Drawing.Size(194, 34);
            this.textureToolStripMenuItem.Text = "Texture";
            this.textureToolStripMenuItem.Click += new System.EventHandler(this.textureToolStripMenuItem_Click);
            // 
            // эToolStripMenuItem
            // 
            this.эToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.объёмныйРендерингToolStripMenuItem, this.цветТрансферфункцииToolStripMenuItem});
            this.эToolStripMenuItem.Enabled = false;
            this.эToolStripMenuItem.Name = "эToolStripMenuItem";
            this.эToolStripMenuItem.Size = new System.Drawing.Size(101, 29);
            this.эToolStripMenuItem.Text = "Эффекты";
            // 
            // объёмныйРендерингToolStripMenuItem
            // 
            this.объёмныйРендерингToolStripMenuItem.Name = "объёмныйРендерингToolStripMenuItem";
            this.объёмныйРендерингToolStripMenuItem.Size = new System.Drawing.Size(296, 34);
            this.объёмныйРендерингToolStripMenuItem.Text = "Объёмный рендеринг";
            this.объёмныйРендерингToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.объёмныйРендерингToolStripMenuItem_Click);
            // 
            // glControl1
            // 
            this.glControl1.BackColor = System.Drawing.Color.Black;
            this.glControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glControl1.Location = new System.Drawing.Point(0, 0);
            this.glControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.glControl1.Name = "glControl1";
            this.glControl1.Size = new System.Drawing.Size(1529, 548);
            this.glControl1.TabIndex = 1;
            this.glControl1.VSync = false;
            this.glControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.GlControl1_Paint);
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar1.Enabled = false;
            this.trackBar1.Location = new System.Drawing.Point(0, 33);
            this.trackBar1.Maximum = 0;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(1529, 69);
            this.trackBar1.TabIndex = 2;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.glControl1);
            this.panel1.Location = new System.Drawing.Point(4, 212);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1529, 548);
            this.panel1.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.trackBar3);
            this.groupBox1.Controls.Add(this.trackBar2);
            this.groupBox1.Location = new System.Drawing.Point(4, 102);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1525, 110);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Transfer Function";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(765, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Ширина TF";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Минимум";
            // 
            // trackBar3
            // 
            this.trackBar3.Location = new System.Drawing.Point(861, 35);
            this.trackBar3.Maximum = 2000;
            this.trackBar3.Minimum = 100;
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Size = new System.Drawing.Size(652, 69);
            this.trackBar3.TabIndex = 6;
            this.trackBar3.TickFrequency = 100;
            this.trackBar3.Value = 2000;
            this.trackBar3.Scroll += new System.EventHandler(this.trackBar3_Scroll);
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(92, 35);
            this.trackBar2.Maximum = 1999;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(667, 69);
            this.trackBar2.TabIndex = 5;
            this.trackBar2.TickFrequency = 100;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            //
            // цветТрансферфункцииToolStripMenuItem
            //
            this.цветТрансферфункцииToolStripMenuItem.Name = "цветТрансферфункцииToolStripMenuItem";
            this.цветТрансферфункцииToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.цветТрансферфункцииToolStripMenuItem.Text = "Цвет трансфер-функции";
            this.цветТрансферфункцииToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.цветТрансферфункцииToolStripMenuItem_Click);
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1529, 764);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Лабораторная работа 2";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem открытьToolStripMenuItem;
        private OpenTK.GLControl glControl1;
        private TrackBar trackBar1;
        private Panel panel1;
        private ToolStripMenuItem режимРендераToolStripMenuItem;
        private ToolStripMenuItem quadToolStripMenuItem;
        private ToolStripMenuItem quadStripToolStripMenuItem;
        private ToolStripMenuItem textureToolStripMenuItem;
        private GroupBox groupBox1;
        private TrackBar trackBar3;
        private TrackBar trackBar2;
        private Label label1;
        private Label label2;
        private ToolStripMenuItem эToolStripMenuItem;
        private ToolStripMenuItem объёмныйРендерингToolStripMenuItem;
        private ToolStripMenuItem цветТрансферфункцииToolStripMenuItem;
    }
}

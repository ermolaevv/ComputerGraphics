namespace Lab1
{
    partial class MaskInput
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            numericUpDown1 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            tableLayoutPanel1 = new TableLayoutPanel();
            numericUpDown3 = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            SuspendLayout();
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(141, 17);
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(76, 31);
            numericUpDown1.TabIndex = 0;
            numericUpDown1.Value = new decimal(new int[] { 3, 0, 0, 0 });
            numericUpDown1.TextChanged += numericUpDown1_TextChanged;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(243, 17);
            numericUpDown2.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(73, 31);
            numericUpDown2.TabIndex = 1;
            numericUpDown2.Value = new decimal(new int[] { 3, 0, 0, 0 });
            numericUpDown2.TextChanged += numericUpDown2_TextChanged;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Location = new Point(12, 64);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(776, 374);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // numericUpDown3
            // 
            numericUpDown3.Location = new Point(533, 17);
            numericUpDown3.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(73, 31);
            numericUpDown3.TabIndex = 3;
            numericUpDown3.Value = new decimal(new int[] { 128, 0, 0, 0 });
            numericUpDown3.TextChanged += numericUpDown3_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(130, 25);
            label1.TabIndex = 4;
            label1.Text = "Размер маски:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(220, 19);
            label2.Name = "label2";
            label2.Size = new Size(23, 25);
            label2.TabIndex = 5;
            label2.Text = "Х";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(350, 19);
            label3.Name = "label3";
            label3.Size = new Size(182, 25);
            label3.TabIndex = 6;
            label3.Text = "Порог бинаризации:";
            // 
            // button1
            // 
            button1.Location = new Point(643, 17);
            button1.Name = "button1";
            button1.Size = new Size(145, 34);
            button1.TabIndex = 7;
            button1.Text = "Ок";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // MaskInput
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(numericUpDown3);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(numericUpDown2);
            Controls.Add(numericUpDown1);
            Name = "MaskInput";
            Text = "MaskInput";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown2;
        private TableLayoutPanel tableLayoutPanel1;
        private NumericUpDown numericUpDown3;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button1;
    }
}

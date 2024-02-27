using Lab1.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab1
{
    public partial class MaskInput : Form
    {
        public int n = 3, m = 3;
        public bool[,] mask = new bool[3, 3];
        public int threshold = 128;
        public MaskInput()
        {
            InitializeComponent();
        }

        private void updateMatrix()
        {
            bool[,] tmp = new bool[n, m];

            for (int i = 0; i < n && i < mask.GetLength(0); i++)
            {
                for (int j = 0; j < m && j < mask.GetLength(1); j++)
                {
                    tmp[i, j] = mask[i, j];
                }
            }

            mask = tmp;

            tableLayoutPanel1.ColumnCount = m;
            tableLayoutPanel1.RowCount = n;

            tableLayoutPanel1.Controls.Clear();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    var button = new MaskElement(i, j);
                    button.Margin = new Padding(0, 0, 0, 0);
                    button.Size = new Size(30, 30);
                    button.Text = "";
                    button.Click += Button_Click;
                    if (mask[i, j])
                        button.BackColor = Color.Black;
                    else
                        button.BackColor = Color.White;

                    tableLayoutPanel1.Controls.Add(button);
                }
            }
        }

        private void Button_Click(object? sender, EventArgs e)
        {
            MaskElement element = (sender as MaskElement);
            if (element.BackColor == Color.Black)
            {
                element.BackColor = Color.White;
                mask[element.GetX(), element.GetY()] = false;
            }
            else
            {
                element.BackColor = Color.Black;
                mask[element.GetX(), element.GetY()] = true;

            }
        }

        private void numericUpDown1_TextChanged(object sender, EventArgs e)
        {
            n = Int32.Parse(numericUpDown1.Text);

            updateMatrix();
        }

        private void numericUpDown2_TextChanged(object sender, EventArgs e)
        {
            m = Int32.Parse(numericUpDown2.Text);

            updateMatrix();
        }
        private void numericUpDown3_TextChanged(object sender, EventArgs e)
        {
            threshold = Int32.Parse(numericUpDown3.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

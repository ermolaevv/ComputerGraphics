using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2.Forms
{
    public partial class VolumeRenderView : Form
    {
        public double[] weights;
        public double sigma, mu;

        private int deep;
        private double[] x;
        private bool isRecalculate = false;
        public VolumeRenderView(double[] weights, double sigma, double mu)
        {
            InitializeComponent();

            this.weights = weights;
            this.sigma = sigma;
            this.mu = mu;

            deep = weights.Length;
            
            numericUpDown1.Value = deep;
            numericUpDown2.Value = (decimal)sigma;
            numericUpDown3.Value = (decimal)mu;

            updateChart();
        }
        private void updateChart()
        {
            if (isRecalculate)
            {
                weights = View.GetWeights(deep, sigma, mu);
            }

            if (x == null || weights.Length != x.Length)
            {
                x = new double[this.weights.Length];
                for (int i = 0; i < this.weights.Length; i++)
                {
                    x[i] = i * 0.1;
                }

                chart1.ChartAreas[0].AxisX.Minimum = 0;
                chart1.ChartAreas[0].AxisX.Maximum = x.Max();
            }

            chart1.Series[0].Points.DataBindXY(x, weights);
            chart1.ChartAreas[0].AxisY.Maximum = weights.Max() + 0.2;
        }
        #region WinForms EventHandlers
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            deep = (int)numericUpDown1.Value;
            isRecalculate = true;
            updateChart();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            sigma = (double)numericUpDown2.Value;
            isRecalculate = true;
            updateChart();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            mu = (double)numericUpDown3.Value;
            isRecalculate = true;
            updateChart();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion

    }
}

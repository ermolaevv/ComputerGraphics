using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Lab2.Forms
{
    public partial class ColorInputForm : Form
    {
        public List<TransferFunctionRange> transferFunctionRanges = new List<TransferFunctionRange>();

        private Dictionary<int, int> intensitys = new Dictionary<int, int>();
        private int[] x, counts;
        private int layerNumber;
        private int min = 0, max = 0;
        private int minTransfer, maxTransfer;

        public ColorInputForm(int layerNumber, List<TransferFunctionRange> ranges, int minTranfer, int maxTransfer)
        {
            InitializeComponent();
            this.layerNumber = layerNumber;
            this.transferFunctionRanges = ranges;
            this.minTransfer = minTranfer;
            this.maxTransfer = maxTransfer;

            listView1.Items.Clear();
            foreach (var range in transferFunctionRanges)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = String.Format("[{0},{1}], Color({2},{3},{4})", range.Min, range.Max, range.Color.R, range.Color.G, range.Color.B);
                listView1.Items.Add(lvi);
            }


            chart1.ChartAreas[0].AxisX.Maximum = maxTransfer + 1;
            chart1.ChartAreas[0].AxisX.Minimum = 0;

            updateChart();
        }
        private void updateChart()
        {
            for (int i = 0; i < Bin.X; i++)
            {
                for (int j = 0; j < Bin.Y; j++)
                {
                    int value = Math.Min(Bin.GetValue(layerNumber, i, j), maxTransfer);
                    int count;
                    intensitys.TryGetValue(value, out count);
                    intensitys[value] =  count + 1;
                }
            }

            int max = intensitys.Keys.Max();

            numericUpDown2.Maximum = max;
            numericUpDown1.Maximum = max;


            x = Enumerable.Range(0, max).ToArray();
            counts = new int[x.Length];
            for (int i = 0; i < x.Length; i++)
            {
                int count = 0;
                intensitys.TryGetValue(x[i], out count);
                counts[i] = count;
            }

            chart1.Series[0].Points.DataBindXY(x, counts);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            max = (int)numericUpDown1.Value;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            min = (int)numericUpDown2.Value;
            numericUpDown1.Minimum = min;
            numericUpDown1.Value = Math.Max(min, numericUpDown1.Value);
            max = (int)numericUpDown1.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Color selectedColor = colorDialog.Color;


                transferFunctionRanges.Add(new TransferFunctionRange(min, max, selectedColor));
                ListViewItem lvi = new ListViewItem();
                lvi.Text = String.Format("[{0},{1}], Color({2},{3},{4})", min, max, selectedColor.R, selectedColor.G, selectedColor.B);
                listView1.Items.Add(lvi);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var focusedItem = listView1.FocusedItem;
                if (focusedItem != null && focusedItem.Bounds.Contains(e.Location))
                {
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
        }

        private void удалитьДиапазонToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var focusedItem = listView1.FocusedItem;
            int index = listView1.Items.IndexOf(focusedItem);
            listView1.Items.RemoveAt(index);
            transferFunctionRanges.RemoveAt(index);
        }

    }
}

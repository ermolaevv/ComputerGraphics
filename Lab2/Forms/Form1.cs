using System;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL;

namespace Lab2.Forms
{
    public partial class Form1 : Form
    {
        private Bin bin;
        private View view;
        private bool loaded = false;
        private int currentLayer = 0;
        private int frameCounter;
        private DateTime nextFPSUpdate = DateTime.Now.AddSeconds(1);
        private bool needReload = true;
        private int minTransfer;
        private int maxTransfer;
        private RenderMode renderMode = RenderMode.Quad;

        public Form1()
        {
            InitializeComponent();
            bin = new Bin();
            view = new View();

            this.minTransfer = trackBar2.Value;
            this.maxTransfer = trackBar3.Value;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Application.Idle += Application_Idle;
        }

        private void Application_Idle(object sender, EventArgs e)
        {
            while (glControl1.IsIdle)
            {
                displayFPS();
                glControl1.Invalidate();
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            { 

                string str = dialog.FileName;
                bin.readBIN(str);

                режимРендераToolStripMenuItem.Enabled = true;
                trackBar1.Maximum = Bin.Z - 1;
                trackBar1.Enabled = true;

                view.SetupView(glControl1.Width, glControl1.Height);
                loaded = true;
                glControl1.Invalidate();
            }
        }

        private void GlControl1_Paint(object sender, PaintEventArgs e)
        {
            if (!loaded)
            {
                view.FillBlack();
            }
            else
            {
                switch (renderMode)
                {
                    case RenderMode.Quad:
                        view.DrawQuads(currentLayer, minTransfer, maxTransfer);
                        break;
                    case RenderMode.QuadStrip:
                        view.DrawQuadStrip(currentLayer, minTransfer, maxTransfer);
                        break;
                    case RenderMode.Texture:
                        if (needReload)
                        {
                            view.generateTextureImage(currentLayer, minTransfer, maxTransfer);
                            view.Load2DTexture();
                            needReload = false;
                        }
                        view.DrawTexture();
                        break;
                    default:
                        return;
                }
            }

            glControl1.SwapBuffers();
        }

        void displayFPS()
        {
            if (DateTime.Now >= nextFPSUpdate)
            {
                if (loaded)
                {
                    string mode = "";
                    switch (renderMode)
                    {
                        case RenderMode.Quad:
                            mode = "Quads";
                            break;
                        case RenderMode.QuadStrip:
                            mode = "QuadStrip";
                            break;
                        case RenderMode.Texture:
                            mode = "Texture";
                            break;
                    }
                    this.Text = String.Format("Лабораторная работа 2 (FPS={0}, режим {1})", frameCounter, mode);
                }
                nextFPSUpdate = DateTime.Now.AddSeconds(1);
                frameCounter = 0;
            }
            frameCounter++;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            currentLayer = trackBar1.Value;
            needReload = true;
        }
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            minTransfer = trackBar2.Value;
            needReload = true;
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            maxTransfer = minTransfer + trackBar3.Value;
            needReload = true;
        }

        private void quadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            renderMode = RenderMode.Quad;
        }

        private void quadStripToolStripMenuItem_Click(object sender, EventArgs e)
        {
            renderMode = RenderMode.QuadStrip;
        }

        private void textureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            renderMode = RenderMode.Texture;
        }
    }
}

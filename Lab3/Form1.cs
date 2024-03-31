using System;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;
using System.Xml.Schema;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Lab3
{
    public partial class Form1 : Form
    {
        private View view;
        private bool loaded = false;
        private int _vertexArray;

        public Form1()
        {
            InitializeComponent();
            view = new View();
        }

        private void glControl1_Load(object sender, EventArgs e)
        {
            loaded = true;
            GL.Viewport(0, 0, glControl1.Width, glControl1.Height);
            //view.Setup(glControl1.Width, glControl1.Height);
            view.InitShaders();
            view.InitBuffer();
        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            if (loaded)
            {
                view.Update();
                GL.UseProgram(view.BasicProgramID);
                glControl1.SwapBuffers();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

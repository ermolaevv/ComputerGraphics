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
            glControl1.Height = this.Height;    
            glControl1.Width = this.Width;
            view = new View();
        }

        private void glControl1_Load(object sender, EventArgs e)
        {
            loaded = true;
            //view.Setup(glControl1.Width, glControl1.Height);
            view.InitShaders();
            view.InitBuffer();

            GL.UseProgram(view.BasicProgramID);
            GL.Viewport(new Size(glControl1.Width, glControl1.Height));

            int k = GL.GetUniformLocation(view.BasicProgramID, "iResolution");
            GL.Uniform2(k, new OpenTK.Vector2() { X = glControl1.Width, Y = glControl1.Height });            
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

        private void glControl1_Resize(object sender, EventArgs e)
        {
            GL.UseProgram(view.BasicProgramID);
            GL.Viewport(new Size(glControl1.Width, glControl1.Height));
            int k = GL.GetUniformLocation(view.BasicProgramID, "iResolution");
            GL.Uniform2(k, new OpenTK.Vector2() { X = glControl1.Width, Y = glControl1.Height });
        }
    }
}

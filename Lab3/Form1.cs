using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Schema;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace Lab3
{
    public partial class Form1 : Form
    {

        private View view;
        private bool loaded = false;

        private bool captured = false;
        private bool updatePos = false;
        private bool updateDir = false;
        private OpenTK.Vector3 camPos = new OpenTK.Vector3(0.0f, 0.0f, -12.0f);
        private OpenTK.Vector2 mouseDir = new OpenTK.Vector2(0.0f, 0.0f);

        private Dictionary<Keys, bool> control;
        private float mouseSensitivity = 3.5f;
        private float speed = 0.1f;

        private int frameCounter;
        private DateTime nextFPSUpdate = DateTime.Now.AddSeconds(1);

        private bool updateDepth = false;
        private int MAX_TRACE_DEPTH = 8;

        private bool reloadRandomMaterial = false;
        private System.Threading.Timer materialUpdateTimer;
        private int periodTimer = 5000;
        private Random rnd = new Random();
        private OpenTK.Vector3 randomColor;
        private float randomTransparency;
        private float randomReflectivity;

        public Form1()
        {
            InitializeComponent();
            glControl1.Height = this.Height;
            glControl1.Width = this.Width;
            view = new View();
            control = new Dictionary<Keys, bool> {
                // Position
                { Keys.W, false },
                { Keys.A, false },
                { Keys.S, false },
                { Keys.D, false },
                { Keys.Q, false },
                { Keys.E, false },
                // Direciton
                { Keys.U, false },
                { Keys.J, false },
                { Keys.H, false },
                { Keys.K, false },
            };

        }
        private void Application_Idle(object sender, EventArgs e)
        {
            while (glControl1.IsIdle)
            {
                GL.UseProgram(view.BasicProgramID);
                if (updatePos)
                {
                    int k = GL.GetUniformLocation(view.BasicProgramID, "iCamPos");
                    GL.Uniform3(k, camPos);
                    updatePos = false;
                }
                if (updateDir)
                {
                    int k = GL.GetUniformLocation(view.BasicProgramID, "iMouseDir");
                    GL.Uniform2(k, mouseDir);
                    updateDir = false;
                }
                if (updateDepth)
                {
                    int k = GL.GetUniformLocation(view.BasicProgramID, "uMaxTraceDepth");
                    GL.Uniform1(k, MAX_TRACE_DEPTH);
                    updateDir = false;

                    if (MAX_TRACE_DEPTH != 8)
                    {
                        label1.Text = MAX_TRACE_DEPTH.ToString();
                        label1.Visible = true;
                    }
                    else
                    {
                        label1.Visible = false;
                    }
                }
                if (reloadRandomMaterial)
                {
                    SetMaterialProperties(randomColor, randomTransparency, randomReflectivity);
                    reloadRandomMaterial = false;
                }

                displayFPS();
                glControl1.Invalidate();
            }
        }

        void displayFPS()
        {
            if (DateTime.Now >= nextFPSUpdate)
            {
                if (loaded)
                {
                    this.Text = String.Format("Лабораторная работа 3 (FPS={0})", frameCounter);
                }
                nextFPSUpdate = DateTime.Now.AddSeconds(1);
                frameCounter = 0;
            }
            frameCounter++;
        }

        private void glControl1_Load(object sender, EventArgs e)
        {
            loaded = true;
            view.InitShaders();
            view.InitBuffer();
            view.Setup(camPos, mouseDir, MAX_TRACE_DEPTH);

            GL.UseProgram(view.BasicProgramID);
            GL.Viewport(new Size(glControl1.Width, glControl1.Height));

            int k = GL.GetUniformLocation(view.BasicProgramID, "iResolution");
            GL.Uniform2(k, new OpenTK.Vector2() { X = glControl1.Width, Y = glControl1.Height });

            StartMaterialUpdateTimer();
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

        private void glControl1_Resize(object sender, EventArgs e)
        {
            GL.UseProgram(view.BasicProgramID);
            GL.Viewport(new Size(glControl1.Width, glControl1.Height));
            int k = GL.GetUniformLocation(view.BasicProgramID, "iResolution");
            GL.Uniform2(k, new OpenTK.Vector2() { X = glControl1.Width, Y = glControl1.Height });

            if (captured)
                Cursor.Clip = RectangleToScreen(new Rectangle(0, 0, glControl1.Width, glControl1.Height));
        }

        private void gl_HideCursor(object sender, EventArgs e)
        {
            captured = true;
            Cursor.Position = new Point(glControl1.Width / 2, glControl1.Height / 2);
            Cursor.Clip = RectangleToScreen(new Rectangle(0, 0, glControl1.Width, glControl1.Height));
            Cursor.Hide();
        }

        private void glControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape) && captured)
            {
                captured = false;
                Cursor.Show();
                Cursor.Clip = Rectangle.Empty;
                Cursor.Position = new Point(glControl1.Width / 2, glControl1.Height / 2);
            }            
            if ((e.KeyChar == '+' || e.KeyChar == '=') && captured)
            {
                MAX_TRACE_DEPTH++;
                updateDepth = true;
            }            
            if (e.KeyChar == '-' && captured)
            {
                if (MAX_TRACE_DEPTH > 0)
                {
                    MAX_TRACE_DEPTH--;
                    updateDepth = true;
                }
            }
        }

        private void glControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (captured && control.Keys.Contains(e.KeyCode))
            {
                control[e.KeyCode] = true;

                if (!backgroundWorker1.IsBusy)
                    backgroundWorker1.RunWorkerAsync();
            }
        }

        private void MoveCam(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Func<float, OpenTK.Matrix2> rotate = (angle) =>
            {
                angle *= ((float)Math.PI / 180);
                return new OpenTK.Matrix2(
                    (float)Math.Cos(angle), (float)-Math.Sin(angle),
                    (float)Math.Sin(angle), (float)Math.Cos(angle)
                );
            };

            while (control.Values.Contains(true))
            {
                float degX = 180f / glControl1.Width;
                float degY = 180f / glControl1.Height;

                if (control[Keys.U])
                {
                    mouseDir.X -= degY * mouseSensitivity;
                    updateDir = true;
                }
                else if (control[Keys.J])
                {
                    mouseDir.X += degY * mouseSensitivity;
                    updateDir = true;
                }

                if (control[Keys.H])
                {
                    mouseDir.Y += degX * mouseSensitivity;
                    updateDir = true;
                }
                else if (control[Keys.K])
                {
                    mouseDir.Y -= degX * mouseSensitivity;
                    updateDir = true;
                }

                OpenTK.Vector3 dir = new OpenTK.Vector3(0.0f, 0.0f, 0.0f);

                if (control[Keys.A])
                {
                    dir += new OpenTK.Vector3(-1.0f, 0.0f, 0.0f);
                    updatePos = true;
                }
                else if (control[Keys.D])
                {
                    dir += new OpenTK.Vector3(1.0f, 0.0f, 0.0f);
                    updatePos = true;
                }

                if (control[Keys.E])
                {
                    dir += new OpenTK.Vector3(0.0f, -1.0f, 0.0f);
                    updatePos = true;
                }
                else if (control[Keys.Q])
                {
                    dir += new OpenTK.Vector3(0.0f, 1.0f, 0.0f);
                    updatePos = true;
                }

                if (control[Keys.W])
                {
                    dir += new OpenTK.Vector3(0.0f, 0.0f, 1.0f);
                    updatePos = true;
                }
                else if (control[Keys.S])
                {
                    dir += new OpenTK.Vector3(0.0f, 0.0f, -1.0f);
                    updatePos = true;
                }

                var MatX = rotate(-mouseDir.X);
                var MatY = rotate(-mouseDir.Y);

                dir.X = MatY.M11 * dir.X + MatY.M21 * dir.Z;
                dir.Z = MatY.M12 * dir.X + MatY.M22 * dir.Z;
                
                dir.Y = MatX.M11 * dir.Y + MatX.M21 * dir.Z;
                dir.Z = MatX.M12 * dir.Y + MatX.M22 * dir.Z;

                camPos += dir * speed;

                Thread.Sleep(50);
            }
        }

        private void glControl1_KeyUp(object sender, KeyEventArgs e)
        {
            if (captured && control.Keys.Contains(e.KeyCode))
            {
                control[e.KeyCode] = false;
            }
        }

        private void StartMaterialUpdateTimer()
        {
            materialUpdateTimer = new System.Threading.Timer((state) =>
            {
                randomColor = new OpenTK.Vector3((float)rnd.NextDouble(), (float)rnd.NextDouble(), (float)rnd.NextDouble());
                randomTransparency = (float)rnd.NextDouble();
                randomReflectivity = (float)rnd.NextDouble();
                reloadRandomMaterial = true;
            },
            null, 0, periodTimer);
        }

        private void SetMaterialProperties(OpenTK.Vector3 color, float transparency, float reflectivity)
        {
            GL.UseProgram(view.BasicProgramID);
            GL.Uniform3(GL.GetUniformLocation(view.BasicProgramID, "uMaterialColor"), color);
            GL.Uniform1(GL.GetUniformLocation(view.BasicProgramID, "uMaterialTransparency"), transparency);
            GL.Uniform1(GL.GetUniformLocation(view.BasicProgramID, "uMaterialReflectivity"), reflectivity);
        }

    private void Form1_Load(object sender, EventArgs e)
        {
            Application.Idle += Application_Idle;
        }
    }
}

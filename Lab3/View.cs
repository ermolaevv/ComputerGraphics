using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Lab3
{
    internal class View
    {
        public int BasicProgramID;
        private int BasicFragmentShader;
        private int BasicVertexShader;
        private Vector3[] vertdata;
        private int vbo_position;
        private int attribute_vpos;
        private int uniform_pos;
        private Vector3 campos;
        private double aspect;
        private int uniform_aspect;

        private void loadShader(String filename, ShaderType type, int program, out int address)
        {
            address = GL.CreateShader(type);
            GL.ShaderSource(address, File.ReadAllText(filename));
            GL.CompileShader(address);
            GL.AttachShader(program, address);
            Console.WriteLine(GL.GetShaderInfoLog(address));
        }

        public void InitShaders()
        {
            BasicProgramID = GL.CreateProgram(); // создание объекта программы 
            loadShader("..\\..\\..\\Shaders\\raytracing.vert", ShaderType.VertexShader, BasicProgramID,
            out BasicVertexShader);
            loadShader("..\\..\\..\\Shaders\\raytracing.frag", ShaderType.FragmentShader, BasicProgramID,
            out BasicFragmentShader);
            GL.LinkProgram(BasicProgramID);
            GL.ValidateProgram(BasicProgramID);
            // Проверяем успех компоновки
            int status = 0;
            GL.GetProgram(BasicProgramID, GetProgramParameterName.LinkStatus, out status);
            Console.WriteLine(GL.GetProgramInfoLog(BasicProgramID));

            GL.DetachShader(BasicProgramID, BasicVertexShader);
            GL.DetachShader(BasicProgramID, BasicFragmentShader);
            GL.DeleteShader(BasicVertexShader);
            GL.DeleteShader(BasicFragmentShader);
        }
        public void InitBuffer()
        {
            vertdata = new Vector3[] {
                new Vector3(-1f, -1f, 0f),
                new Vector3( 1f, -1f, 0f),
                new Vector3( 1f, 1f, 0f),
                new Vector3(-1f, 1f, 0f)
            };

            GL.GenBuffers(1, out vbo_position);
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo_position);

            GL.BufferData<Vector3>(BufferTarget.ArrayBuffer, (IntPtr)(vertdata.Length *
             Vector3.SizeInBytes), vertdata, BufferUsageHint.StaticDraw);

            GL.VertexAttribPointer(attribute_vpos, 3, VertexAttribPointerType.Float, false, 0, 0);
            GL.EnableVertexAttribArray(0);

            GL.Uniform3(uniform_pos, campos);
            GL.Uniform1(uniform_aspect, aspect);
            GL.UseProgram(BasicProgramID);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }

        public void Update()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Enable(EnableCap.DepthTest);
            GL.EnableVertexAttribArray(attribute_vpos);
            GL.DrawArrays(PrimitiveType.Quads, 0, 4);
            GL.DisableVertexAttribArray(attribute_vpos);
        }

        public void Setup(int width, int height)
        {
            string str = GL.GetString(StringName.ShadingLanguageVersion);
            GL.ClearColor(Color.DarkGray);
            GL.ShadeModel(ShadingModel.Smooth);

            Matrix4 perspMat = Matrix4.CreatePerspectiveFieldOfView(
                MathHelper.PiOver4, width / (float)height, 1, 64);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspMat);

            Matrix4 viewMat = Matrix4.LookAt(0, 0, 3, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref viewMat);
        }
    }
}

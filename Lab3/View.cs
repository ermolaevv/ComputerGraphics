using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Windows.Forms;
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

        private void loadShader(String filename, ShaderType type, int program, out int address)
        {
            address = GL.CreateShader(type);
            GL.ShaderSource(address, File.ReadAllText(filename));
            GL.CompileShader(address);

            int isCompiled = -1;
            GL.GetShader(address, ShaderParameter.CompileStatus, out isCompiled);
            if (isCompiled == 0)
            {
                int maxLength = 0;
                GL.GetShader(address, ShaderParameter.InfoLogLength, out maxLength);

                string errorLog;
                GL.GetShaderInfoLog(address, maxLength, out maxLength, out errorLog);
                Console.WriteLine(errorLog);

                GL.DeleteShader(address);
                return;
            }

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

            GL.UseProgram(BasicProgramID);

            GL.GenBuffers(1, out vbo_position);
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo_position);

            GL.BufferData<Vector3>(BufferTarget.ArrayBuffer, (IntPtr)(vertdata.Length *
             Vector3.SizeInBytes), vertdata, BufferUsageHint.StaticDraw);

            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

        }

        public void Update()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo_position);
                GL.VertexPointer(3, VertexPointerType.Float, Vector3.SizeInBytes, 0);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

            GL.EnableClientState(ArrayCap.VertexArray);
                GL.DrawArrays(PrimitiveType.Quads, 0, 4);
            GL.DisableClientState(ArrayCap.VertexArray);
        }

        public void Setup(OpenTK.Vector3 pos, OpenTK.Vector2 dir, int depth)
        {
            int k = GL.GetUniformLocation(BasicProgramID, "iCamPos");
            GL.Uniform3(k, pos);
            k = GL.GetUniformLocation(BasicProgramID, "iMouseDir");
            GL.Uniform2(k, dir);
            k = GL.GetUniformLocation(BasicProgramID, "uMaxTraceDepth");
            GL.Uniform1(k, depth);
            GL.Uniform3(GL.GetUniformLocation(BasicProgramID, "uMaterialColor"), new OpenTK.Vector3(0.5f));
            GL.Uniform1(GL.GetUniformLocation(BasicProgramID, "uMaterialTransparency"), 0.5f);
            GL.Uniform1(GL.GetUniformLocation(BasicProgramID, "uMaterialReflectivity"), 0.5f);
        }
    }
}

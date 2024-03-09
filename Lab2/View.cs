using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL;

namespace Lab2
{
    internal class View
    {
        private int VBOtexture;
        private Bitmap textureImage;
        public double[] volumeWeigths;
        public double sigma, mu = 0;
        public List<TransferFunctionRange> transferFunctionRanges = new List<TransferFunctionRange>();
        public View() {
            int deep = 5;
            sigma = 1 / Math.Sqrt(2 * Math.PI);
            volumeWeigths = GetWeights(deep, sigma, mu);

            SetupTransferFunctions();
        }
        public void SetupView(int width, int  height)
        {
            GL.ShadeModel(ShadingModel.Smooth);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, Bin.X, 0, Bin.Y, -1, 1);
            GL.Viewport(0, 0, width, height);
        }
        public void DrawQuads(int layerNumber, int minTransfer, int maxTransfer, bool isVolume, bool isColoring)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Begin(BeginMode.Quads);
            for (int x_coord = 0; x_coord < Bin.X - 1; x_coord++)
            {
                for (int y_coord = 0; y_coord < Bin.Y - 1; y_coord++)
                {
                    short value;

                    for (int i = 0; i < 2; i++) // Костыльные циклы, которые проходят по вершинам: (0,0), (0,1), (1,1), (1,0)
                    {
                        int j = i;
                        while ((i == 1) && (j >= 0) || (i == 0) && (j < 2))
                        {
                            if (isVolume)
                            {
                                GL.Color3(VolumeTransferFunction(layerNumber, x_coord + i, y_coord + j, minTransfer, maxTransfer, isColoring));
                            }
                            else
                            {
                                value = Bin.GetValue(layerNumber, x_coord + i, y_coord + j);
                                GL.Color3(TransferFunction(value, minTransfer, maxTransfer, isColoring));
                            }

                            GL.Vertex2(x_coord + i, y_coord + j);

                            if (i == 1)
                                j--;
                            else
                                j++;
                        }
                    }
                }
            }
            GL.End();
        }
        public void DrawQuadStrip(int layerNumber, int minTransfer, int maxTransfer, bool isVolume, bool isColoring)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            for (int y_coord = 0; y_coord < Bin.Y - 1; y_coord++)
            {
                GL.Begin(BeginMode.QuadStrip);
                for (int x_coord = 0; x_coord < Bin.X; x_coord++)
                {
                    short value;
                    // 1 вершина
                    if (isVolume)
                    {
                        GL.Color3(VolumeTransferFunction(layerNumber, x_coord, y_coord, minTransfer, maxTransfer, isColoring));
                    }
                    else
                    {
                        value = Bin.GetValue(layerNumber, x_coord, y_coord);
                        GL.Color3(TransferFunction(value, minTransfer, maxTransfer, isColoring));
                    }
                    GL.Vertex2(x_coord, y_coord);

                    // 2 вершина
                    if (isVolume)
                    {
                        GL.Color3(VolumeTransferFunction(layerNumber, x_coord, y_coord + 1, minTransfer, maxTransfer, isColoring));
                    }
                    else
                    {
                        value = Bin.GetValue(layerNumber, x_coord, y_coord + 1);
                        GL.Color3(TransferFunction(value, minTransfer, maxTransfer, isColoring));
                    }
                    GL.Vertex2(x_coord, y_coord + 1);
                }
                GL.End();
            }
        }
        public void FillBlack()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Begin(BeginMode.Quads);
            GL.End();
        }
        #region Texture
        public void Load2DTexture()
        {
            GL.BindTexture(TextureTarget.Texture2D, VBOtexture);
            BitmapData data = textureImage.LockBits(
                new System.Drawing.Rectangle(0, 0, textureImage.Width, textureImage.Height),
                ImageLockMode.ReadOnly,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb
            );

            GL.TexImage2D(
                TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba,
                data.Width, data.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Rgba,
                PixelType.UnsignedByte, data.Scan0
            );

            textureImage.UnlockBits(data);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

            ErrorCode Er = GL.GetError();
            string str = Er.ToString();
        }
        public void generateTextureImage(int layerNumber, int minTransfer, int maxTransfer, bool isVolume, bool isColoring)
        {
            textureImage = new Bitmap(Bin.X, Bin.Y);
            for (int i = 0; i < Bin.X; i++)
            {
                for (int j = 0; j < Bin.Y; j++)
                {
                    if (isVolume)
                        textureImage.SetPixel(i, j, VolumeTransferFunction(layerNumber, i, j, minTransfer, maxTransfer, isColoring));
                    else
                        textureImage.SetPixel(i, j, TransferFunction(Bin.GetValue(layerNumber, i, j), minTransfer, maxTransfer, isColoring));
                }
            }
        }
        public void DrawTexture()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, VBOtexture);

            GL.Begin(BeginMode.Quads);
            GL.Color3(Color.White);
            GL.TexCoord2(0f, 0f);
            GL.Vertex2(0, 0);
            GL.TexCoord2(0f, 1f);
            GL.Vertex2(0, Bin.Y);
            GL.TexCoord2(1f, 1f);
            GL.Vertex2(Bin.X, Bin.Y);
            GL.TexCoord2(1f, 0f);
            GL.Vertex2(Bin.X, 0);
            GL.End();

            GL.Disable(EnableCap.Texture2D);
        }
        #endregion
        private Color TransferFunction(short value, int min, int max, bool isColoring)
        {
            if (isColoring)
                foreach (var range in transferFunctionRanges)
                {
                    if (value >= range.Min && value <= range.Max)
                    {
                        return range.Color;
                    }
                }

            int newVal = clamp((value - min) * 255 / (max - min), 0, 255);
            return Color.FromArgb(255, newVal, newVal, newVal);
        }
        private Color VolumeTransferFunction(int layer, int x_coord, int y_coord, int min, int max, bool isColoring)
        {
            double sumIntensity = 0;
            double sumWeight = 0;

            for (int i = 0; i < volumeWeigths.Length && layer < Bin.Z; i++, layer++) // Взвешенное среднее
            {
                int value = Bin.GetValue(layer, x_coord, y_coord);
                int intensity = clamp((value - min) * 255 / (max - min), 0, 255);

                sumIntensity += intensity * volumeWeigths[i];
                sumWeight += volumeWeigths[i];
            }


            int newVal = clamp((int)(sumIntensity / sumWeight), 0, 255);

            if (isColoring)
                foreach (var range in transferFunctionRanges)
                {
                    if (newVal >= range.Min && newVal <= range.Max)
                    {
                        return range.Color;
                    }
                }

            return Color.FromArgb(255, newVal, newVal, newVal);
        }

        private int clamp(int value, int min, int max)
        {
            return Math.Max(Math.Min(value, max), min);
        }
        public static double[] GetWeights(int count, double sigma = 1, double mu=0)
        {
            double[] weights = new double[count];
            for (int i = 0; i < count; i++)
            {
                double x = i / 10d;

                // Нормальное распределение
                weights[i] = 1 / (sigma * Math.Sqrt(2 * Math.PI)) * Math.Pow(
                    Math.E,
                    -1 / 2d * Math.Pow((x - mu) / sigma, 2)
                ); 
            }

            return weights;
        }
        public void AddTransferFunctionRange(int min, int max, Color color)
        {
            transferFunctionRanges.Add(new TransferFunctionRange(min, max, color));
        }
        public void SetupTransferFunctions()
        {
            AddTransferFunctionRange(0, 10, Color.Black); 
            AddTransferFunctionRange(30, 70, Color.FromArgb(255,0,128)); // Мышцы
            AddTransferFunctionRange(200, 10000, Color.White); // Кости
        }

        public void ClearTransferFunctionRanges()
        {
            transferFunctionRanges.Clear();
        }
    }
}

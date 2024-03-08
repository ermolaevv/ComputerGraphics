using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using OpenTK.Graphics.OpenGL;

namespace Lab2
{
    internal class View
    {
        private int VBOtexture;
        private Bitmap textureImage;
        public double[] volumeWeigths;
        public double sigma, mu = 0;
        private Color transferColor = Color.White;
        private int transferMin = 0, transferMax = 255;
        private List<TransferFunctionRange> transferFunctionRanges = new List<TransferFunctionRange>();

        public View() {
            int depth = 5;
            sigma = 1 / Math.Sqrt(2 * Math.PI);
            volumeWeigths = GetWeights(depth, sigma, mu);
        }

        public void SetupView(int width, int height) {
            GL.ShadeModel(ShadingModel.Smooth);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, Bin.X, 0, Bin.Y, -1, 1);
            GL.Viewport(0, 0, width, height);
        }

        public void DrawQuads(int layerNumber, int minTransfer, int maxTransfer, bool isVolume) {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Begin(BeginMode.Quads);
            for (int x_coord = 0; x_coord < Bin.X - 1; x_coord++)
            {
                for (int y_coord = 0; y_coord < Bin.Y - 1; y_coord++)
                {
                    short value;
                    for (int i = 0; i < 2; i++)
                    {
                        int j = i;
                        while ((i == 1) && (j >= 0) || (i == 0) && (j < 2))
                        {
                            value = Bin.GetValue(layerNumber, x_coord + i, y_coord + j);
                            if (isVolume)
                            {
                                GL.Color3(VolumeTransferFunction(layerNumber, x_coord + i, y_coord + j, minTransfer, maxTransfer));
                            }
                            else
                            {
                                GL.Color3(TransferFunction(value, minTransfer, maxTransfer));
                            }
                            GL.Vertex2(x_coord + i, y_coord + j);
                            if (i == 1) j--; else j++;
                        }
                    }
                }
            }
            GL.End();
        }

        public void DrawQuadStrip(int layerNumber, int minTransfer, int maxTransfer, bool isVolume) {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Begin(BeginMode.QuadStrip);
            for (int y_coord = 0; y_coord < Bin.Y - 1; y_coord++)
            {
                for (int x_coord = 0; x_coord < Bin.X; x_coord++)
                {
                    short value = Bin.GetValue(layerNumber, x_coord, y_coord);
                    if (isVolume)
                    {
                        GL.Color3(VolumeTransferFunction(layerNumber, x_coord, y_coord, minTransfer, maxTransfer));
                    }
                    else
                    {
                        GL.Color3(TransferFunction(value, minTransfer, maxTransfer));
                    }
                    GL.Vertex2(x_coord, y_coord);
                    value = Bin.GetValue(layerNumber, x_coord, y_coord + 1);
                    if (isVolume)
                    {
                        GL.Color3(VolumeTransferFunction(layerNumber, x_coord, y_coord + 1, minTransfer, maxTransfer));
                    }
                    else
                    {
                        GL.Color3(TransferFunction(value, minTransfer, maxTransfer));
                    }
                    GL.Vertex2(x_coord, y_coord + 1);
                }
            }
            GL.End();
        }

        public void FillBlack() {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Begin(BeginMode.Quads);
            GL.End();
        }

        public void Load2DTexture() {
            GL.BindTexture(TextureTarget.Texture2D, VBOtexture);
            BitmapData data = textureImage.LockBits(new Rectangle(0, 0, textureImage.Width, textureImage.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
            textureImage.UnlockBits(data);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
        }

        public void generateTextureImage(int layerNumber, int minTransfer, int maxTransfer, bool isVolume) {
            textureImage = new Bitmap(Bin.X, Bin.Y);
            for (int i = 0; i < Bin.X; i++)
            {
                for (int j = 0; j < Bin.Y; j++)
                {
                    short value = Bin.GetValue(layerNumber, i, j);
                    textureImage.SetPixel(i, j, TransferFunction(value, minTransfer, maxTransfer));
                }
            }
        }

        public void DrawTexture() {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, VBOtexture);
            GL.Begin(BeginMode.Quads);
            GL.Color3(Color.White);
            GL.TexCoord2(0f, 0f); GL.Vertex2(0, 0);
            GL.TexCoord2(0f, 1f); GL.Vertex2(0, Bin.Y);
            GL.TexCoord2(1f, 1f); GL.Vertex2(Bin.X, Bin.Y);
            GL.TexCoord2(1f, 0f); GL.Vertex2(Bin.X, 0);
            GL.End();
            GL.Disable(EnableCap.Texture2D);
        }

        public void AddTransferFunctionRange(int min, int max, Color color) {
            transferFunctionRanges.Add(new TransferFunctionRange(min, max, color));
        }

        private Color TransferFunction(short value, int min, int max) {
            foreach (var range in transferFunctionRanges)
            {
                if (value >= range.Min && value <= range.Max)
                {
                    return range.Color;
                }
            }
            int newVal = Clamp((value - min) * 255 / (max - min), 0, 255);
            return Color.FromArgb(255, newVal, newVal, newVal);
        }

        private Color VolumeTransferFunction(int layer, int x_coord, int y_coord, int min, int max) {
            double sumIntensity = 0;
            double sumWeight = 0;
            for (int i = 0; i < volumeWeigths.Length && layer + i < Bin.Z; i++)
            {
                int value = Bin.GetValue(layer + i, x_coord, y_coord);
                int intensity = Clamp((value - min) * 255 / (max - min), 0, 255);
                sumIntensity += intensity * volumeWeigths[i];
                sumWeight += volumeWeigths[i];
            }
            int newVal = Clamp((int)(sumIntensity / sumWeight), 0, 255);
            return Color.FromArgb(255, newVal, newVal, newVal);
        }

        private int Clamp(int value, int min, int max) {
            return Math.Max(min, Math.Min(max, value));
        }

        public static double[] GetWeights(int count, double sigma = 1, double mu = 0) {
            double[] weights = new double[count];
            for (int i = 0; i < count; i++)
            {
                double x = i / 10d;
                weights[i] = 1 / (sigma * Math.Sqrt(2 * Math.PI)) * Math.Exp(-0.5 * Math.Pow((x - mu) / sigma, 2));
            }
            return weights;
        }

        public void SetupTransferFunctions() {
            AddTransferFunctionRange(-1000, -900, Color.Blue); // Воздух
            AddTransferFunctionRange(-100, -50, Color.Yellow); // Жир
            AddTransferFunctionRange(-10, 10, Color.LightGreen); // Вода/мягкие ткани
            AddTransferFunctionRange(10, 40, Color.Red); // Мышцы
            AddTransferFunctionRange(700, 3000, Color.White); // Кости
        }

        public void SetTransferFunctionColor(Color color, int min, int max) {
            transferColor = color;
            transferMin = min;
            transferMax = max;
        }

        public void ClearTransferFunctionRanges() {
            transferFunctionRanges.Clear();
        }

        public struct TransferFunctionRange
        {
            public int Min;
            public int Max;
            public Color Color;

            public TransferFunctionRange(int min, int max, Color color) {
                Min = min;
                Max = max;
                Color = color;
            }
        }
    }
}

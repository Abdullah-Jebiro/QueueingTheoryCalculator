using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace QueueTh
{
    public partial class SimulationPointer : Form
    {
        int kmax, kmin;
        int wid, hgt;
        int lowX,lowY,highX,highY;
        public SimulationPointer()
        {
            InitializeComponent();
        }
        private void SimulationPointer_Load(object sender, EventArgs e)
        {
            kmin = Form1.kminP;
            kmax = Form1.kmaxP;
            wid = picSimP.ClientSize.Width;
            hgt = picSimP.ClientSize.Height;
            lowX = -1;
            lowY = -1;
            highX = kmax;
            highY = kmax;
            plotCurves(lowX, highX, lowY, highY);
        }
        private void plotCurves(float xmin, float xmax,float ymin , float ymax)
        {
            Bitmap bm = new Bitmap(wid, hgt);
            ImageBackColor(ref bm);
            DrawLineP(ref bm, xmin, 0, xmax, 0);
            DrawLineP(ref bm, 0, ymin, 0, ymax);
            drawCurve(ref bm);
            picSimP.Image = bm;
        }
        void ImageBackColor(ref Bitmap bm)
        {
            GraphicsUnit mnn = GraphicsUnit.Pixel;
            RectangleF bounds = bm.GetBounds(ref mnn);
            BitmapData bmpData = bm.LockBits(new Rectangle(0, 0, bm.Width, bm.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            unsafe
            {
                byte* pixel;
                int rowWidth = (int)bounds.Width * sizeof(Pixel);
                if (rowWidth % 4 != 0)
                {
                    rowWidth = 4 * (rowWidth / 4 + 1);
                }
                for (int i = 0; i < bounds.Width; i++)
                {
                    for (int j = 0; j < bounds.Height; j++)
                    {
                        pixel = (byte*)bmpData.Scan0.ToPointer();
                        Pixel* MyP = (Pixel*)(pixel + i * sizeof(Pixel) + j * rowWidth);
                        MyP->red = 255;
                        MyP->green = 255;
                        MyP->blue = 255;
                    }
                }
            }
            bm.UnlockBits(bmpData);
        }
        void DrawLineP(ref Bitmap bm, float x1, float y1, float x2, float y2)
        {
            x1 = wid * (x1 - lowX) / (highX - lowX);
            y1 = hgt * (1 - ((y1 - lowY) / (highY - lowY)));
            x2 = wid * (x2 - lowX) / (highX - lowX);
            y2 = hgt * (1 - ((y2 - lowY) / (highY - lowY)));
            GraphicsUnit mnn = GraphicsUnit.Pixel;
            RectangleF bounds = bm.GetBounds(ref mnn);
            BitmapData bmpData = bm.LockBits(new Rectangle(0, 0, wid, hgt), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            unsafe
            {
                byte* pixel;
                int rowWidth = (int)bounds.Width * sizeof(Pixel);
                if (rowWidth % 4 != 0)
                {
                    rowWidth = 4 * (rowWidth / 4 + 1);
                }
                pixel = (byte*)bmpData.Scan0.ToPointer();
                int x11 = (int)(x1);
                int y11 = (int)(y1);
                int x22 = (int)(x2);
                int y22 = (int)(y2);
                if (x11 < x22)
                {
                    for (int i = x11; i <= x22; i++)
                    {
                        int rY = (y22 - y11) / (x22 - x11) * (i - x11) + y11;
                        Pixel* MyP = (Pixel*)(pixel + i * sizeof(Pixel) + rY * rowWidth);
                        (*MyP).red = 0;
                        (*MyP).green = 0;
                        (*MyP).blue = 255;
                    }
                }
                else if (x11 == x22)
                {
                    for (int j = y22; j <= y11; j++)
                    {
                        int rX = (x22 - x11) / (y22 - y11) * (j - y11) + x11;
                        Pixel* MyP = (Pixel*)(pixel + rX * sizeof(Pixel) + j * rowWidth);
                        (*MyP).red = 0;
                        (*MyP).green = 0;
                        (*MyP).blue = 255;
                    }
                }
            }
            bm.UnlockBits(bmpData);
        }
        void drawCurve(ref Bitmap bm)
        {
            double ls = 0.0f;
            GraphicsUnit mnn = GraphicsUnit.Pixel;
            RectangleF bounds = bm.GetBounds(ref mnn);
            BitmapData bmpData = bm.LockBits(new Rectangle(0, 0, wid, hgt), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            Random rnd = new Random();
            unsafe
            {
                byte* pixel;
                pixel = (byte*)bmpData.Scan0.ToPointer();
                int rowWidth = (int)bounds.Width * sizeof(Pixel);
                if (rowWidth % 4 != 0)
                {
                    rowWidth = 4 * (rowWidth / 4 + 1);
                }
                for (int k = kmin; k <= kmax; k ++)
                {
                    byte r= (byte)rnd.Next(0, 255);
                    byte g = (byte)rnd.Next(0, 255);
                    byte b = (byte)rnd.Next(0, 255);
                    for (float ro = 0; ro <= highX; ro+=0.001f)
                    {
                       if(ro!=1)
                            ls = ((ro / (1 - ro)) - ((k + 1) * Math.Pow(ro, k + 1) / (1 - Math.Pow(ro, k + 1))));
                        int x11 = (int)(wid * (ro - lowX) / (highX - lowX));
                        int y11 = (int)( hgt * (1 - ((ls - lowY) / (highY - lowY))));
                        Pixel* MyP = (Pixel*)(pixel + x11 * sizeof(Pixel) + y11 * rowWidth);
                        (*MyP).red =r;
                        (*MyP).green = g;
                        (*MyP).blue = b;
                    }
                }
            }
            bm.UnlockBits(bmpData);
        }
        public struct Pixel
        {
            public byte blue;
            public byte green;
            public byte red;
        }        
    }
}

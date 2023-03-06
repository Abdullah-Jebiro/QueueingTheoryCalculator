using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QueueTh
{
    public partial class Simulation : Form
    {
         int kmin, kmax;
        public Simulation()
        {
            InitializeComponent();
        }
        public Simulation(int kmin, int kmax)
        {
            InitializeComponent();
            this.kmin = kmin;
            this.kmax = kmax;
        }
        private void Simulation_Load(object sender, EventArgs e)
        {
            plotCurves(-1, kmax, -kmax, 1);
        }
        private void plotCurves(float xmin, float xmax, float ymin, float ymax)
        {
            int wid = picSim.ClientSize.Width;
            int hgt = picSim.ClientSize.Height;
            Bitmap bm = new Bitmap(wid, hgt);
            Graphics g = Graphics.FromImage(bm);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            RectangleF rect = new RectangleF(xmin, ymin, xmax - xmin, ymax - ymin);
            PointF[] pts = { new PointF(0, 0), new PointF(wid, 0), new PointF(0, hgt) };
            g.Transform = new Matrix(rect, pts);
            Pen graph_pen = new Pen(Color.Blue, 0);
            g.DrawLine(graph_pen, xmin, 0, xmax, 0);
            g.DrawLine(graph_pen, 0, ymin, 0, ymax);
            for (int x = (int)xmin; x <= xmax; x++)
            {
                g.DrawLine(graph_pen, x, -0.1f, x, 0.1f);
            }
            for (int y = (int)ymin; y <= ymax; y++)
            {
                g.DrawLine(graph_pen, -0.1f, y, 0.1f, y);
            }
            g.DrawString("ρ", new Font(FontFamily.GenericMonospace, xmax / 15, FontStyle.Italic), new SolidBrush(Color.Green), new PointF(9f * xmax / 10, -xmax / 10));
            g.DrawString("Ls", new Font(FontFamily.GenericMonospace, xmax / 15, FontStyle.Regular), new SolidBrush(Color.Green), new PointF(0, ymin));
            ///////////
            float dx = 0.01f;   
            List<PointF> points = new List<PointF>();
            Random rnd = new Random();
            float ls = 0.0f;
            for (int k = kmin; k <= kmax; k += 1)
            {
                graph_pen.Color = Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
                points.Clear();
                for (float ro = 0; ro <= xmax; ro += dx)
                {
                    if (ro != 1)
                        ls = (float)(-(ro / (1 - ro) - ((k + 1) * Math.Pow(ro, k + 1) / (1 - Math.Pow(ro, k + 1)))));
                    points.Add(new PointF(ro, ls));
                    if (ro >= xmax - dx)
                        g.DrawString("K=" + k.ToString(), new Font(FontFamily.GenericSansSerif, xmax / 30, FontStyle.Regular), new SolidBrush(Color.Green), new PointF(xmax / 2, ls));

                }
                if (points.Count > 1)
                    g.DrawLines(graph_pen, points.ToArray());
            }
            //////////////
            picSim.Image = bm;
        }
    }
}

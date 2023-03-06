using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QueueT.QueueCalc;
namespace QueueTh
{
    public partial class Form1 : Form
    {
        #region init Form
        public Form1()
        {
            InitializeComponent();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("queue");
        }
        #endregion		
        #region init Var
        ClacQueueT a = new ClacQueueT();
        public static int kminP, kmaxP;
        #endregion
        #region roucalc
        private void btnCalc_Clk(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
            double rou = 0;
            int s = 1;
            double lam = Convert.ToDouble(txtLam.Text);
            double meu = Convert.ToDouble(txtMeu.Text);
            a.RouCalc(ref rou, lam, meu, s);
            txtResult.Text = rou.ToString();
        }
        #endregion
        #region CalcQueue
        private void mM1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
            clearTextBox(tabPage2);
            double rou = 0, p0 = 0, pn = 0, ls = 0, lq = 0, ws = 0, wq = 0;
            int s = 1;
            int n = Convert.ToInt32(txtn.Text);
            double lam = Convert.ToDouble(txtLam.Text);
            double meu = Convert.ToDouble(txtMeu.Text);
            a.RouCalc(ref rou, lam, meu, s);
            a.CalcMm1(ref p0, ref pn, ref ls, ref lq, ref ws, ref wq, s, n);
            double[] aa = new double[6];
            aa[0] = p0; aa[1] = pn; aa[2] = ls; aa[3] = lq; aa[4] = ws; aa[5] = wq;
            ShowResults(tabPage2, aa);
        }


        private void mMsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
            clearTextBox(tabPage3);
            double rou = 0, p0 = 0, pn = 0, ls = 0, lq = 0, ws = 0, wq = 0;
            int s = Convert.ToInt32(txts.Text);
            int n = Convert.ToInt32(txtn.Text);
            double lam = Convert.ToDouble(txtLam.Text);
            double meu = Convert.ToDouble(txtMeu.Text);
            a.RouCalc(ref rou, lam, meu, s);
            a.CalcMms(ref p0, ref pn, ref ls, ref lq, ref ws, ref wq, s, n);
            double[] aa = new double[6];
            aa[0] = p0; aa[1] = pn; aa[2] = ls; aa[3] = lq; aa[4] = ws; aa[5] = wq;
            ShowResults(tabPage3, aa);
        }
        private void mMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage4;
            clearTextBox(tabPage4);
            double rou = 0, p0 = 0, pn = 0, ls = 0, lq = 0, ws = 0, wq = 0;
            int s = 1;
            int n = Convert.ToInt32(txtn.Text);
            double lam = Convert.ToDouble(txtLam.Text);
            double meu = Convert.ToDouble(txtMeu.Text);
            a.RouCalc(ref rou, lam, meu, s);
            a.CalcMmInf(ref p0, ref pn, ref ls, ref lq, ref ws, ref wq, s, n);
            double[] aa = new double[6];
            aa[0] = p0; aa[1] = pn; aa[2] = ls; aa[3] = lq; aa[4] = ws; aa[5] = wq;
            ShowResults(tabPage4, aa);
        }
        private void mM1kToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage5;
            clearTextBox(tabPage5);
            double rou = 0, p0 = 0, pn = 0, ls = 0, lq = 0, ws = 0, wq = 0;
            int s = 1;
            int n = Convert.ToInt32(txtn.Text);
            double lam = Convert.ToDouble(txtLam.Text);
            double meu = Convert.ToDouble(txtMeu.Text);
            int k = Convert.ToInt32(txtk.Text);
            a.RouCalc(ref rou, lam, meu, s);
            a.CalcMm1k(ref p0, ref pn, ref ls, ref lq, ref ws, ref wq, s, n, k);
            double[] aa = new double[6];
            aa[0] = p0; aa[1] = pn; aa[2] = ls; aa[3] = lq; aa[4] = ws; aa[5] = wq;
            ShowResults(tabPage5, aa);
        }
        private void mD1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage6;
            clearTextBox(tabPage6);
            double rou = 0, p0 = 0, pn = 0, ls = 0, lq = 0, ws = 0, wq = 0;
            int s = 1;
            int n = Convert.ToInt32(txtn.Text);
            double lam = Convert.ToDouble(txtLam.Text);
            double meu = Convert.ToDouble(txtMeu.Text);
            a.RouCalc(ref rou, lam, meu, s);
            a.CalcMd1(ref p0, ref pn, ref ls, ref lq, ref ws, ref wq, s, n);
            double[] aa = new double[6];
            aa[0] = p0; aa[1] = pn; aa[2] = ls; aa[3] = lq; aa[4] = ws; aa[5] = wq;
            ShowResults(tabPage6, aa);
        }

        private void mEk1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage7;
            clearTextBox(tabPage7);
            double rou = 0, p0 = 0, pn = 0, ls = 0, lq = 0, ws = 0, wq = 0;
            int s = 1;
            int n = Convert.ToInt32(txtn.Text);
            double lam = Convert.ToDouble(txtLam.Text);
            double meu = Convert.ToDouble(txtMeu.Text);
            a.RouCalc(ref rou, lam, meu, s);
            a.CalcMek1(ref p0, ref pn, ref ls, ref lq, ref ws, ref wq, s, n);
            double[] aa = new double[6];
            aa[0] = p0; aa[1] = pn; aa[2] = ls; aa[3] = lq; aa[4] = ws; aa[5] = wq;
            ShowResults(tabPage7, aa);           
        }
        #endregion
        #region helper
        private void ShowResults(TextBox T1, TextBox T2, TextBox T3, TextBox T4, TextBox T5, TextBox T6, double p0, double pn, double ls, double lq, double ws, double wq)
        {
            T1.Text = p0.ToString();
            T2.Text = pn.ToString();
            T3.Text = ls.ToString();
            T4.Text = lq.ToString();
            T5.Text = ws.ToString();
            T6.Text = wq.ToString();
        }
        private void ShowResults(TabPage TP, double[] aa)
        {
            int i = 0;
            foreach (Control a in TP.Controls)
            {
                if (a.GetType() == typeof(TextBox))
                {
                    a.Text = aa[i].ToString();
                    i++;
                }
            }
        }
        private void clearTextBox(TabPage TP)
        {

            foreach (Control a in TP.Controls)
            {
                if (a.GetType() == typeof(TextBox))
                    a.Text = "0";
            }
        }
        void GetObjectByString(int i)
        {
            TextBox textBox = new TextBox();
            var name = string.Format("textBox{0}", i); //or write //var name ="textBox" + i.ToString();
            textBox = this.Controls[name] as TextBox;
            textBox.Text = "here you can access to text of textbox1";
        }
        #endregion
        #region Simulation
        private void btnSimulate_Click(object sender, EventArgs e)
        {
            int kmin = Convert.ToInt32(txtKmin.Text);
            int kmax = Convert.ToInt32(txtKmax.Text);
            Simulation sDraw = new Simulation(kmin, kmax);
            sDraw.ShowDialog();
        }
        private void btnSimulatePointer_Click(object sender, EventArgs e)
        {
            kminP = Convert.ToInt32(txtKmin.Text);
            kmaxP = Convert.ToInt32(txtKmax.Text);
            SimulationPointer sDraw = new SimulationPointer();
            sDraw.ShowDialog();
        }
        #endregion 
    }
}

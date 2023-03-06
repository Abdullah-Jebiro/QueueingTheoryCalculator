
namespace QueueTh
{
    partial class Simulation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picSim = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picSim)).BeginInit();
            this.SuspendLayout();
            // 
            // picSim
            // 
            this.picSim.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.picSim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picSim.Location = new System.Drawing.Point(0, 0);
            this.picSim.Name = "picSim";
            this.picSim.Size = new System.Drawing.Size(684, 661);
            this.picSim.TabIndex = 0;
            this.picSim.TabStop = false;
            // 
            // Simulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 661);
            this.Controls.Add(this.picSim);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Simulation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simulation";
            this.Load += new System.EventHandler(this.Simulation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picSim)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picSim;
    }
}
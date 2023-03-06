
namespace QueueTh
{
    partial class SimulationPointer
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
            this.picSimP = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picSimP)).BeginInit();
            this.SuspendLayout();
            // 
            // picSimP
            // 
            this.picSimP.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.picSimP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picSimP.Location = new System.Drawing.Point(0, 0);
            this.picSimP.Name = "picSimP";
            this.picSimP.Size = new System.Drawing.Size(684, 661);
            this.picSimP.TabIndex = 0;
            this.picSimP.TabStop = false;
            // 
            // SimulationPointer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 661);
            this.Controls.Add(this.picSimP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SimulationPointer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SimulationPointer";
            this.Load += new System.EventHandler(this.SimulationPointer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picSimP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picSimP;
    }
}
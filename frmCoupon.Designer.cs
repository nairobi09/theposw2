namespace thepos
{
    partial class frmCoupon
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
            this.pbGate1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbGate1)).BeginInit();
            this.SuspendLayout();
            // 
            // pbGate1
            // 
            this.pbGate1.Location = new System.Drawing.Point(0, 0);
            this.pbGate1.Margin = new System.Windows.Forms.Padding(0);
            this.pbGate1.Name = "pbGate1";
            this.pbGate1.Size = new System.Drawing.Size(1080, 1920);
            this.pbGate1.TabIndex = 1;
            this.pbGate1.TabStop = false;
            this.pbGate1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbGate1_MouseClick);
            // 
            // frmCoupon
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(1080, 1920);
            this.Controls.Add(this.pbGate1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCoupon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmCoupon";
            ((System.ComponentModel.ISupportInitialize)(this.pbGate1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pbGate1;
    }
}
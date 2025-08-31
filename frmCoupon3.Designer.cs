namespace thepos
{
    partial class frmCoupon3
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCoupon3));
            this.btnOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblText2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblText1 = new System.Windows.Forms.Label();
            this.timerHome = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Red;
            this.btnOK.Font = new System.Drawing.Font("맑은 고딕", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(348, 1515);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(350, 150);
            this.btnOK.TabIndex = 1;
            this.btnOK.TabStop = false;
            this.btnOK.Text = "완료";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(385, 737);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 78);
            this.label1.TabIndex = 3;
            this.label1.Text = "발권완료";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(20, 480);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1000, 140);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // lblText2
            // 
            this.lblText2.BackColor = System.Drawing.Color.Transparent;
            this.lblText2.Font = new System.Drawing.Font("맑은 고딕", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblText2.ForeColor = System.Drawing.Color.Red;
            this.lblText2.Location = new System.Drawing.Point(36, 167);
            this.lblText2.Name = "lblText2";
            this.lblText2.Size = new System.Drawing.Size(761, 81);
            this.lblText2.TabIndex = 12;
            this.lblText2.Text = "출력되는 티켓을 챙겨가세요";
            this.lblText2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.lblText1);
            this.panel1.Controls.Add(this.lblText2);
            this.panel1.Location = new System.Drawing.Point(94, 907);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(835, 466);
            this.panel1.TabIndex = 13;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(368, 292);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 100);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // lblText1
            // 
            this.lblText1.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblText1.Location = new System.Drawing.Point(103, 70);
            this.lblText1.Name = "lblText1";
            this.lblText1.Size = new System.Drawing.Size(616, 75);
            this.lblText1.TabIndex = 13;
            this.lblText1.Text = "티켓발권이 완료되었습니다.";
            this.lblText1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerHome
            // 
            this.timerHome.Tick += new System.EventHandler(this.timerHome_Tick);
            // 
            // frmCoupon3
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(1040, 1880);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCoupon3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCoupon3";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblText2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblText1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Timer timerHome;
    }
}
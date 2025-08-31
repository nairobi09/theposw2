namespace thepos
{
    partial class frmPayKakao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayKakao));
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblNetAmount = new System.Windows.Forms.Label();
            this.lblAmountTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tbCouponScan = new System.Windows.Forms.TextBox();
            this.lblCouponImageText = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblNetAmount);
            this.panel3.Controls.Add(this.lblAmountTitle);
            this.panel3.Location = new System.Drawing.Point(124, 40);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(332, 79);
            this.panel3.TabIndex = 72;
            // 
            // lblNetAmount
            // 
            this.lblNetAmount.BackColor = System.Drawing.Color.White;
            this.lblNetAmount.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblNetAmount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblNetAmount.Font = new System.Drawing.Font("맑은 고딕", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblNetAmount.ForeColor = System.Drawing.Color.Blue;
            this.lblNetAmount.Location = new System.Drawing.Point(0, 36);
            this.lblNetAmount.Margin = new System.Windows.Forms.Padding(0);
            this.lblNetAmount.Name = "lblNetAmount";
            this.lblNetAmount.Size = new System.Drawing.Size(330, 41);
            this.lblNetAmount.TabIndex = 69;
            this.lblNetAmount.Text = "\\ 5,000";
            this.lblNetAmount.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblAmountTitle
            // 
            this.lblAmountTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblAmountTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAmountTitle.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAmountTitle.ForeColor = System.Drawing.Color.Black;
            this.lblAmountTitle.Location = new System.Drawing.Point(0, 0);
            this.lblAmountTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblAmountTitle.Name = "lblAmountTitle";
            this.lblAmountTitle.Size = new System.Drawing.Size(330, 31);
            this.lblAmountTitle.TabIndex = 68;
            this.lblAmountTitle.Text = "결제금액";
            this.lblAmountTitle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ForeColor = System.Drawing.Color.DimGray;
            this.btnClose.Location = new System.Drawing.Point(44, 616);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(97, 66);
            this.btnClose.TabIndex = 62;
            this.btnClose.Text = "취소";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.DarkOrange;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(4);
            this.lblTitle.Size = new System.Drawing.Size(570, 30);
            this.lblTitle.TabIndex = 74;
            this.lblTitle.Text = "간편결제";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.tbCouponScan);
            this.panel4.Controls.Add(this.lblCouponImageText);
            this.panel4.Controls.Add(this.pictureBox3);
            this.panel4.Controls.Add(this.pictureBox2);
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Controls.Add(this.btnClose);
            this.panel4.Location = new System.Drawing.Point(4, 31);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(562, 713);
            this.panel4.TabIndex = 75;
            // 
            // tbCouponScan
            // 
            this.tbCouponScan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbCouponScan.ForeColor = System.Drawing.Color.White;
            this.tbCouponScan.Location = new System.Drawing.Point(144, 170);
            this.tbCouponScan.Name = "tbCouponScan";
            this.tbCouponScan.Size = new System.Drawing.Size(300, 14);
            this.tbCouponScan.TabIndex = 0;
            this.tbCouponScan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbCouponScan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCouponScan_KeyDown);
            this.tbCouponScan.Leave += new System.EventHandler(this.tbCouponScan_Leave);
            // 
            // lblCouponImageText
            // 
            this.lblCouponImageText.Font = new System.Drawing.Font("맑은 고딕", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCouponImageText.ForeColor = System.Drawing.Color.Red;
            this.lblCouponImageText.Location = new System.Drawing.Point(64, 433);
            this.lblCouponImageText.Name = "lblCouponImageText";
            this.lblCouponImageText.Size = new System.Drawing.Size(431, 39);
            this.lblCouponImageText.TabIndex = 75;
            this.lblCouponImageText.Text = "바코드를 스캐너에 인식해주세요";
            this.lblCouponImageText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(234, 487);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(100, 100);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 74;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(208, 242);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(161, 167);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 73;
            this.pictureBox2.TabStop = false;
            // 
            // frmPayKakao
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(570, 750);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPayKakao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmPayKakao";
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblNetAmount;
        private System.Windows.Forms.Label lblAmountTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblCouponImageText;
        private System.Windows.Forms.TextBox tbCouponScan;
    }
}
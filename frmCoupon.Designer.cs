namespace thepos2
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCouponCancel = new System.Windows.Forms.Button();
            this.tbNo = new System.Windows.Forms.TextBox();
            this.lblNoMemo = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnCouponCancel);
            this.panel1.Controls.Add(this.tbNo);
            this.panel1.Controls.Add(this.lblNoMemo);
            this.panel1.Controls.Add(this.btnView);
            this.panel1.Location = new System.Drawing.Point(9, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(482, 331);
            this.panel1.TabIndex = 80;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::theposw2.Properties.Resources.scanbar21;
            this.pictureBox1.Location = new System.Drawing.Point(189, 67);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(93, 81);
            this.pictureBox1.TabIndex = 81;
            this.pictureBox1.TabStop = false;
            // 
            // btnCouponCancel
            // 
            this.btnCouponCancel.BackColor = System.Drawing.Color.SaddleBrown;
            this.btnCouponCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCouponCancel.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCouponCancel.ForeColor = System.Drawing.Color.White;
            this.btnCouponCancel.Location = new System.Drawing.Point(131, 257);
            this.btnCouponCancel.Name = "btnCouponCancel";
            this.btnCouponCancel.Size = new System.Drawing.Size(83, 50);
            this.btnCouponCancel.TabIndex = 80;
            this.btnCouponCancel.TabStop = false;
            this.btnCouponCancel.Text = "취소";
            this.btnCouponCancel.UseVisualStyleBackColor = false;
            this.btnCouponCancel.Click += new System.EventHandler(this.btnCouponCancel_Click);
            // 
            // tbNo
            // 
            this.tbNo.BackColor = System.Drawing.Color.LemonChiffon;
            this.tbNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNo.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbNo.Location = new System.Drawing.Point(131, 211);
            this.tbNo.MaxLength = 20;
            this.tbNo.Name = "tbNo";
            this.tbNo.Size = new System.Drawing.Size(221, 22);
            this.tbNo.TabIndex = 0;
            // 
            // lblNoMemo
            // 
            this.lblNoMemo.AutoSize = true;
            this.lblNoMemo.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblNoMemo.ForeColor = System.Drawing.Color.White;
            this.lblNoMemo.Location = new System.Drawing.Point(50, 167);
            this.lblNoMemo.Name = "lblNoMemo";
            this.lblNoMemo.Size = new System.Drawing.Size(377, 19);
            this.lblNoMemo.TabIndex = 71;
            this.lblNoMemo.Text = "바코드 리더기에 쿠폰번호를 스캔하세요.";
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.SaddleBrown;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnView.ForeColor = System.Drawing.Color.White;
            this.btnView.Location = new System.Drawing.Point(220, 257);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(132, 50);
            this.btnView.TabIndex = 1;
            this.btnView.TabStop = false;
            this.btnView.Text = "조회";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.SaddleBrown;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(452, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 40);
            this.btnClose.TabIndex = 79;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "✕";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.SaddleBrown;
            this.lblTitle.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(9, 9);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(4);
            this.lblTitle.Size = new System.Drawing.Size(483, 40);
            this.lblTitle.TabIndex = 78;
            this.lblTitle.Text = "쿠폰인증";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmCoupon
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(504, 400);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCoupon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmCoupon";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbNo;
        private System.Windows.Forms.Label lblNoMemo;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnCouponCancel;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
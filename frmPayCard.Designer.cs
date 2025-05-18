namespace thepos2
{
    partial class frmPayCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayCard));
            this.btnPayRequest = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbCUP = new System.Windows.Forms.RadioButton();
            this.rbCredit = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbInstall00 = new System.Windows.Forms.RadioButton();
            this.rbInstall03 = new System.Windows.Forms.RadioButton();
            this.rbInstall06 = new System.Windows.Forms.RadioButton();
            this.rbInstall12 = new System.Windows.Forms.RadioButton();
            this.lblNetAmount = new System.Windows.Forms.Label();
            this.lblMethodTitle = new System.Windows.Forms.Label();
            this.lblInstallTitle = new System.Windows.Forms.Label();
            this.lblAmountTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPayRequest
            // 
            this.btnPayRequest.BackColor = System.Drawing.Color.Blue;
            this.btnPayRequest.FlatAppearance.BorderSize = 0;
            this.btnPayRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPayRequest.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPayRequest.ForeColor = System.Drawing.Color.White;
            this.btnPayRequest.Location = new System.Drawing.Point(262, 341);
            this.btnPayRequest.Name = "btnPayRequest";
            this.btnPayRequest.Size = new System.Drawing.Size(186, 78);
            this.btnPayRequest.TabIndex = 47;
            this.btnPayRequest.Text = "결제";
            this.btnPayRequest.UseVisualStyleBackColor = false;
            this.btnPayRequest.Click += new System.EventHandler(this.btnPayRequest_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(4);
            this.lblTitle.Size = new System.Drawing.Size(570, 30);
            this.lblTitle.TabIndex = 40;
            this.lblTitle.Text = "카드결제";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbCUP);
            this.panel2.Controls.Add(this.rbCredit);
            this.panel2.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panel2.Location = new System.Drawing.Point(116, 228);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(350, 61);
            this.panel2.TabIndex = 71;
            // 
            // rbCUP
            // 
            this.rbCUP.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbCUP.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rbCUP.Location = new System.Drawing.Point(215, 0);
            this.rbCUP.Name = "rbCUP";
            this.rbCUP.Size = new System.Drawing.Size(117, 53);
            this.rbCUP.TabIndex = 1;
            this.rbCUP.Text = "은련카드";
            this.rbCUP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbCUP.UseVisualStyleBackColor = true;
            // 
            // rbCredit
            // 
            this.rbCredit.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbCredit.Checked = true;
            this.rbCredit.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rbCredit.Location = new System.Drawing.Point(0, 0);
            this.rbCredit.Name = "rbCredit";
            this.rbCredit.Size = new System.Drawing.Size(209, 53);
            this.rbCredit.TabIndex = 0;
            this.rbCredit.TabStop = true;
            this.rbCredit.Text = "신용카드 / 삼성페이";
            this.rbCredit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbCredit.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbInstall00);
            this.panel1.Controls.Add(this.rbInstall03);
            this.panel1.Controls.Add(this.rbInstall06);
            this.panel1.Controls.Add(this.rbInstall12);
            this.panel1.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panel1.Location = new System.Drawing.Point(116, 159);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 58);
            this.panel1.TabIndex = 70;
            // 
            // rbInstall00
            // 
            this.rbInstall00.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbInstall00.Checked = true;
            this.rbInstall00.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rbInstall00.Location = new System.Drawing.Point(0, 0);
            this.rbInstall00.Name = "rbInstall00";
            this.rbInstall00.Size = new System.Drawing.Size(103, 53);
            this.rbInstall00.TabIndex = 58;
            this.rbInstall00.TabStop = true;
            this.rbInstall00.Text = "00";
            this.rbInstall00.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbInstall00.UseVisualStyleBackColor = true;
            // 
            // rbInstall03
            // 
            this.rbInstall03.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbInstall03.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rbInstall03.Location = new System.Drawing.Point(109, 0);
            this.rbInstall03.Name = "rbInstall03";
            this.rbInstall03.Size = new System.Drawing.Size(70, 53);
            this.rbInstall03.TabIndex = 59;
            this.rbInstall03.Text = "03";
            this.rbInstall03.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbInstall03.UseVisualStyleBackColor = true;
            // 
            // rbInstall06
            // 
            this.rbInstall06.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbInstall06.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rbInstall06.Location = new System.Drawing.Point(185, 0);
            this.rbInstall06.Name = "rbInstall06";
            this.rbInstall06.Size = new System.Drawing.Size(70, 53);
            this.rbInstall06.TabIndex = 60;
            this.rbInstall06.Text = "06";
            this.rbInstall06.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbInstall06.UseVisualStyleBackColor = true;
            // 
            // rbInstall12
            // 
            this.rbInstall12.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbInstall12.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rbInstall12.Location = new System.Drawing.Point(261, 0);
            this.rbInstall12.Name = "rbInstall12";
            this.rbInstall12.Size = new System.Drawing.Size(70, 53);
            this.rbInstall12.TabIndex = 61;
            this.rbInstall12.Text = "12";
            this.rbInstall12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbInstall12.UseVisualStyleBackColor = true;
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
            // lblMethodTitle
            // 
            this.lblMethodTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblMethodTitle.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMethodTitle.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lblMethodTitle.Location = new System.Drawing.Point(23, 231);
            this.lblMethodTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblMethodTitle.Name = "lblMethodTitle";
            this.lblMethodTitle.Size = new System.Drawing.Size(85, 46);
            this.lblMethodTitle.TabIndex = 68;
            this.lblMethodTitle.Text = "결제수단";
            this.lblMethodTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblInstallTitle
            // 
            this.lblInstallTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblInstallTitle.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblInstallTitle.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lblInstallTitle.Location = new System.Drawing.Point(23, 162);
            this.lblInstallTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblInstallTitle.Name = "lblInstallTitle";
            this.lblInstallTitle.Size = new System.Drawing.Size(85, 46);
            this.lblInstallTitle.TabIndex = 68;
            this.lblInstallTitle.Text = "할부개월";
            this.lblInstallTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.btnClose.BackColor = System.Drawing.Color.Gray;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(116, 341);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(140, 78);
            this.btnClose.TabIndex = 62;
            this.btnClose.Text = "취소";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblNetAmount);
            this.panel3.Controls.Add(this.lblAmountTitle);
            this.panel3.Location = new System.Drawing.Point(116, 40);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(332, 79);
            this.panel3.TabIndex = 72;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Controls.Add(this.btnClose);
            this.panel4.Controls.Add(this.lblInstallTitle);
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Controls.Add(this.lblMethodTitle);
            this.panel4.Controls.Add(this.btnPayRequest);
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Location = new System.Drawing.Point(4, 31);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(562, 715);
            this.panel4.TabIndex = 73;
            // 
            // frmPayCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.ClientSize = new System.Drawing.Size(570, 750);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPayCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmPayCard";
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPayRequest;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.RadioButton rbInstall12;
        private System.Windows.Forms.RadioButton rbInstall06;
        private System.Windows.Forms.RadioButton rbInstall03;
        private System.Windows.Forms.RadioButton rbInstall00;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblNetAmount;
        private System.Windows.Forms.Label lblAmountTitle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbCUP;
        private System.Windows.Forms.RadioButton rbCredit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblMethodTitle;
        private System.Windows.Forms.Label lblInstallTitle;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
    }
}
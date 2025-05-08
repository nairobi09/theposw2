namespace thepos2
{
    partial class frmDevAdmin
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
            this.btnLoginDev = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.cbTest = new System.Windows.Forms.CheckBox();
            this.tbPosNo = new System.Windows.Forms.TextBox();
            this.tbSiteID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLoginDev
            // 
            this.btnLoginDev.Location = new System.Drawing.Point(130, 59);
            this.btnLoginDev.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoginDev.Name = "btnLoginDev";
            this.btnLoginDev.Size = new System.Drawing.Size(70, 25);
            this.btnLoginDev.TabIndex = 3;
            this.btnLoginDev.Text = "loginDev";
            this.btnLoginDev.UseVisualStyleBackColor = true;
            this.btnLoginDev.Click += new System.EventHandler(this.btnLoginDev_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(130, 86);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(70, 25);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(130, 113);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(70, 25);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cbTest
            // 
            this.cbTest.AutoSize = true;
            this.cbTest.Checked = true;
            this.cbTest.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTest.ForeColor = System.Drawing.Color.LightGray;
            this.cbTest.Location = new System.Drawing.Point(49, 111);
            this.cbTest.Margin = new System.Windows.Forms.Padding(4);
            this.cbTest.Name = "cbTest";
            this.cbTest.Size = new System.Drawing.Size(56, 16);
            this.cbTest.TabIndex = 2;
            this.cbTest.Text = "TEST";
            this.cbTest.UseVisualStyleBackColor = true;
            // 
            // tbPosNo
            // 
            this.tbPosNo.BackColor = System.Drawing.Color.DarkGray;
            this.tbPosNo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPosNo.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbPosNo.Location = new System.Drawing.Point(49, 81);
            this.tbPosNo.Margin = new System.Windows.Forms.Padding(4);
            this.tbPosNo.Name = "tbPosNo";
            this.tbPosNo.Size = new System.Drawing.Size(68, 15);
            this.tbPosNo.TabIndex = 1;
            // 
            // tbSiteID
            // 
            this.tbSiteID.BackColor = System.Drawing.Color.DarkGray;
            this.tbSiteID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSiteID.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbSiteID.Location = new System.Drawing.Point(49, 59);
            this.tbSiteID.Margin = new System.Windows.Forms.Padding(4);
            this.tbSiteID.Name = "tbSiteID";
            this.tbSiteID.Size = new System.Drawing.Size(68, 15);
            this.tbSiteID.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Gold;
            this.label2.Location = new System.Drawing.Point(11, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "DevLogin은 앱로그를 남기지 않음";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(143, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "DevLogin";
            // 
            // frmDevAdmin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.ClientSize = new System.Drawing.Size(250, 210);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLoginDev);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cbTest);
            this.Controls.Add(this.tbPosNo);
            this.Controls.Add(this.tbSiteID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDevAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmDevAdmin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoginDev;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox cbTest;
        public System.Windows.Forms.TextBox tbPosNo;
        public System.Windows.Forms.TextBox tbSiteID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
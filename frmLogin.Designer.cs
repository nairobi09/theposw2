namespace thepos2
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.lblPW = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tbID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelKeyDisplayWhite = new System.Windows.Forms.Panel();
            this.tbPW = new System.Windows.Forms.TextBox();
            this.lblKeyDisplayXX = new System.Windows.Forms.Label();
            this.panelNumpad = new System.Windows.Forms.Panel();
            this.btnKey1 = new System.Windows.Forms.Button();
            this.btnKey2 = new System.Windows.Forms.Button();
            this.btnKey0 = new System.Windows.Forms.Button();
            this.btnKey3 = new System.Windows.Forms.Button();
            this.btnKey4 = new System.Windows.Forms.Button();
            this.btnKeyLogin = new System.Windows.Forms.Button();
            this.btnKeyBS = new System.Windows.Forms.Button();
            this.btnKey5 = new System.Windows.Forms.Button();
            this.btnKey9 = new System.Windows.Forms.Button();
            this.btnKey6 = new System.Windows.Forms.Button();
            this.btnKey8 = new System.Windows.Forms.Button();
            this.btnKey7 = new System.Windows.Forms.Button();
            this.btnKeyClear = new System.Windows.Forms.Button();
            this.btnReqSupport = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblCallCenterNo = new System.Windows.Forms.Label();
            this.btnPos = new System.Windows.Forms.Button();
            this.panel4.SuspendLayout();
            this.panelKeyDisplayWhite.SuspendLayout();
            this.panelNumpad.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPW
            // 
            this.lblPW.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPW.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPW.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblPW.Location = new System.Drawing.Point(50, 190);
            this.lblPW.Name = "lblPW";
            this.lblPW.Size = new System.Drawing.Size(74, 48);
            this.lblPW.TabIndex = 42;
            this.lblPW.Text = "패스워드";
            this.lblPW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblID
            // 
            this.lblID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblID.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblID.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblID.Location = new System.Drawing.Point(50, 135);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(74, 48);
            this.lblID.TabIndex = 43;
            this.lblID.Text = "아이디";
            this.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.tbID);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Location = new System.Drawing.Point(129, 135);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(174, 48);
            this.panel4.TabIndex = 40;
            // 
            // tbID
            // 
            this.tbID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.tbID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbID.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbID.ForeColor = System.Drawing.Color.Gold;
            this.tbID.Location = new System.Drawing.Point(10, 13);
            this.tbID.MaxLength = 4;
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(156, 23);
            this.tbID.TabIndex = 38;
            this.tbID.TabStop = false;
            this.tbID.Text = "1120";
            this.tbID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbID.Click += new System.EventHandler(this.tbID_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(1, 1);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.label1.Size = new System.Drawing.Size(172, 46);
            this.label1.TabIndex = 3;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelKeyDisplayWhite
            // 
            this.panelKeyDisplayWhite.BackColor = System.Drawing.Color.White;
            this.panelKeyDisplayWhite.Controls.Add(this.tbPW);
            this.panelKeyDisplayWhite.Controls.Add(this.lblKeyDisplayXX);
            this.panelKeyDisplayWhite.Location = new System.Drawing.Point(129, 189);
            this.panelKeyDisplayWhite.Name = "panelKeyDisplayWhite";
            this.panelKeyDisplayWhite.Size = new System.Drawing.Size(174, 48);
            this.panelKeyDisplayWhite.TabIndex = 41;
            // 
            // tbPW
            // 
            this.tbPW.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.tbPW.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPW.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbPW.ForeColor = System.Drawing.Color.Gold;
            this.tbPW.Location = new System.Drawing.Point(10, 13);
            this.tbPW.MaxLength = 4;
            this.tbPW.Name = "tbPW";
            this.tbPW.PasswordChar = '*';
            this.tbPW.Size = new System.Drawing.Size(156, 23);
            this.tbPW.TabIndex = 38;
            this.tbPW.TabStop = false;
            this.tbPW.Text = "4089";
            this.tbPW.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbPW.Click += new System.EventHandler(this.tbPW_Click);
            // 
            // lblKeyDisplayXX
            // 
            this.lblKeyDisplayXX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.lblKeyDisplayXX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblKeyDisplayXX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblKeyDisplayXX.ForeColor = System.Drawing.Color.Gold;
            this.lblKeyDisplayXX.Location = new System.Drawing.Point(1, 1);
            this.lblKeyDisplayXX.Name = "lblKeyDisplayXX";
            this.lblKeyDisplayXX.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.lblKeyDisplayXX.Size = new System.Drawing.Size(172, 46);
            this.lblKeyDisplayXX.TabIndex = 3;
            this.lblKeyDisplayXX.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelNumpad
            // 
            this.panelNumpad.Controls.Add(this.btnKey1);
            this.panelNumpad.Controls.Add(this.btnKey2);
            this.panelNumpad.Controls.Add(this.btnKey0);
            this.panelNumpad.Controls.Add(this.btnKey3);
            this.panelNumpad.Controls.Add(this.btnKey4);
            this.panelNumpad.Controls.Add(this.btnKeyLogin);
            this.panelNumpad.Controls.Add(this.btnKeyBS);
            this.panelNumpad.Controls.Add(this.btnKey5);
            this.panelNumpad.Controls.Add(this.btnKey9);
            this.panelNumpad.Controls.Add(this.btnKey6);
            this.panelNumpad.Controls.Add(this.btnKey8);
            this.panelNumpad.Controls.Add(this.btnKey7);
            this.panelNumpad.Controls.Add(this.btnKeyClear);
            this.panelNumpad.Location = new System.Drawing.Point(384, 131);
            this.panelNumpad.Margin = new System.Windows.Forms.Padding(30);
            this.panelNumpad.Name = "panelNumpad";
            this.panelNumpad.Padding = new System.Windows.Forms.Padding(30);
            this.panelNumpad.Size = new System.Drawing.Size(190, 278);
            this.panelNumpad.TabIndex = 44;
            // 
            // btnKey1
            // 
            this.btnKey1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.btnKey1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnKey1.ForeColor = System.Drawing.Color.White;
            this.btnKey1.Location = new System.Drawing.Point(0, 3);
            this.btnKey1.Margin = new System.Windows.Forms.Padding(0);
            this.btnKey1.Name = "btnKey1";
            this.btnKey1.Size = new System.Drawing.Size(60, 48);
            this.btnKey1.TabIndex = 1;
            this.btnKey1.TabStop = false;
            this.btnKey1.Text = "1";
            this.btnKey1.UseVisualStyleBackColor = false;
            // 
            // btnKey2
            // 
            this.btnKey2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.btnKey2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnKey2.ForeColor = System.Drawing.Color.White;
            this.btnKey2.Location = new System.Drawing.Point(64, 3);
            this.btnKey2.Name = "btnKey2";
            this.btnKey2.Size = new System.Drawing.Size(60, 48);
            this.btnKey2.TabIndex = 1;
            this.btnKey2.TabStop = false;
            this.btnKey2.Text = "2";
            this.btnKey2.UseVisualStyleBackColor = false;
            // 
            // btnKey0
            // 
            this.btnKey0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.btnKey0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey0.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnKey0.ForeColor = System.Drawing.Color.White;
            this.btnKey0.Location = new System.Drawing.Point(128, 159);
            this.btnKey0.Name = "btnKey0";
            this.btnKey0.Size = new System.Drawing.Size(60, 48);
            this.btnKey0.TabIndex = 1;
            this.btnKey0.TabStop = false;
            this.btnKey0.Text = "0";
            this.btnKey0.UseVisualStyleBackColor = false;
            // 
            // btnKey3
            // 
            this.btnKey3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.btnKey3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnKey3.ForeColor = System.Drawing.Color.White;
            this.btnKey3.Location = new System.Drawing.Point(128, 3);
            this.btnKey3.Name = "btnKey3";
            this.btnKey3.Size = new System.Drawing.Size(60, 48);
            this.btnKey3.TabIndex = 1;
            this.btnKey3.TabStop = false;
            this.btnKey3.Text = "3";
            this.btnKey3.UseVisualStyleBackColor = false;
            // 
            // btnKey4
            // 
            this.btnKey4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.btnKey4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnKey4.ForeColor = System.Drawing.Color.White;
            this.btnKey4.Location = new System.Drawing.Point(0, 55);
            this.btnKey4.Name = "btnKey4";
            this.btnKey4.Size = new System.Drawing.Size(60, 48);
            this.btnKey4.TabIndex = 1;
            this.btnKey4.TabStop = false;
            this.btnKey4.Text = "4";
            this.btnKey4.UseVisualStyleBackColor = false;
            // 
            // btnKeyLogin
            // 
            this.btnKeyLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.btnKeyLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeyLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnKeyLogin.ForeColor = System.Drawing.Color.White;
            this.btnKeyLogin.Location = new System.Drawing.Point(0, 211);
            this.btnKeyLogin.Name = "btnKeyLogin";
            this.btnKeyLogin.Size = new System.Drawing.Size(188, 48);
            this.btnKeyLogin.TabIndex = 1;
            this.btnKeyLogin.TabStop = false;
            this.btnKeyLogin.Text = "로그인";
            this.btnKeyLogin.UseVisualStyleBackColor = false;
            this.btnKeyLogin.Click += new System.EventHandler(this.btnKeyLogin_Click);
            // 
            // btnKeyBS
            // 
            this.btnKeyBS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.btnKeyBS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeyBS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnKeyBS.ForeColor = System.Drawing.Color.White;
            this.btnKeyBS.Location = new System.Drawing.Point(64, 159);
            this.btnKeyBS.Name = "btnKeyBS";
            this.btnKeyBS.Size = new System.Drawing.Size(60, 48);
            this.btnKeyBS.TabIndex = 1;
            this.btnKeyBS.TabStop = false;
            this.btnKeyBS.Text = "<";
            this.btnKeyBS.UseVisualStyleBackColor = false;
            // 
            // btnKey5
            // 
            this.btnKey5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.btnKey5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnKey5.ForeColor = System.Drawing.Color.White;
            this.btnKey5.Location = new System.Drawing.Point(64, 55);
            this.btnKey5.Name = "btnKey5";
            this.btnKey5.Size = new System.Drawing.Size(60, 48);
            this.btnKey5.TabIndex = 1;
            this.btnKey5.TabStop = false;
            this.btnKey5.Text = "5";
            this.btnKey5.UseVisualStyleBackColor = false;
            // 
            // btnKey9
            // 
            this.btnKey9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.btnKey9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnKey9.ForeColor = System.Drawing.Color.White;
            this.btnKey9.Location = new System.Drawing.Point(128, 107);
            this.btnKey9.Name = "btnKey9";
            this.btnKey9.Size = new System.Drawing.Size(60, 48);
            this.btnKey9.TabIndex = 1;
            this.btnKey9.TabStop = false;
            this.btnKey9.Text = "9";
            this.btnKey9.UseVisualStyleBackColor = false;
            // 
            // btnKey6
            // 
            this.btnKey6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.btnKey6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnKey6.ForeColor = System.Drawing.Color.White;
            this.btnKey6.Location = new System.Drawing.Point(128, 55);
            this.btnKey6.Name = "btnKey6";
            this.btnKey6.Size = new System.Drawing.Size(60, 48);
            this.btnKey6.TabIndex = 1;
            this.btnKey6.TabStop = false;
            this.btnKey6.Text = "6";
            this.btnKey6.UseVisualStyleBackColor = false;
            // 
            // btnKey8
            // 
            this.btnKey8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.btnKey8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnKey8.ForeColor = System.Drawing.Color.White;
            this.btnKey8.Location = new System.Drawing.Point(64, 107);
            this.btnKey8.Name = "btnKey8";
            this.btnKey8.Size = new System.Drawing.Size(60, 48);
            this.btnKey8.TabIndex = 1;
            this.btnKey8.TabStop = false;
            this.btnKey8.Text = "8";
            this.btnKey8.UseVisualStyleBackColor = false;
            // 
            // btnKey7
            // 
            this.btnKey7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.btnKey7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnKey7.ForeColor = System.Drawing.Color.White;
            this.btnKey7.Location = new System.Drawing.Point(0, 107);
            this.btnKey7.Name = "btnKey7";
            this.btnKey7.Size = new System.Drawing.Size(60, 48);
            this.btnKey7.TabIndex = 1;
            this.btnKey7.TabStop = false;
            this.btnKey7.Text = "7";
            this.btnKey7.UseVisualStyleBackColor = false;
            // 
            // btnKeyClear
            // 
            this.btnKeyClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.btnKeyClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeyClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnKeyClear.ForeColor = System.Drawing.Color.White;
            this.btnKeyClear.Location = new System.Drawing.Point(0, 159);
            this.btnKeyClear.Name = "btnKeyClear";
            this.btnKeyClear.Size = new System.Drawing.Size(60, 48);
            this.btnKeyClear.TabIndex = 1;
            this.btnKeyClear.TabStop = false;
            this.btnKeyClear.Text = "C";
            this.btnKeyClear.UseVisualStyleBackColor = false;
            // 
            // btnReqSupport
            // 
            this.btnReqSupport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReqSupport.ForeColor = System.Drawing.Color.DarkGray;
            this.btnReqSupport.Location = new System.Drawing.Point(146, 337);
            this.btnReqSupport.Name = "btnReqSupport";
            this.btnReqSupport.Size = new System.Drawing.Size(157, 53);
            this.btnReqSupport.TabIndex = 45;
            this.btnReqSupport.TabStop = false;
            this.btnReqSupport.Text = "원격지원";
            this.btnReqSupport.UseVisualStyleBackColor = true;
            this.btnReqSupport.Click += new System.EventHandler(this.btnReqSupport_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ForeColor = System.Drawing.Color.DarkGray;
            this.btnClose.Location = new System.Drawing.Point(514, 26);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(58, 53);
            this.btnClose.TabIndex = 47;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "✕";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblCallCenterNo
            // 
            this.lblCallCenterNo.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCallCenterNo.ForeColor = System.Drawing.Color.LightGray;
            this.lblCallCenterNo.Location = new System.Drawing.Point(47, 42);
            this.lblCallCenterNo.Name = "lblCallCenterNo";
            this.lblCallCenterNo.Size = new System.Drawing.Size(313, 22);
            this.lblCallCenterNo.TabIndex = 48;
            this.lblCallCenterNo.Text = "고객지원 1522-9926";
            this.lblCallCenterNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCallCenterNo.Click += new System.EventHandler(this.lblCallCenterNo_Click);
            // 
            // btnPos
            // 
            this.btnPos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPos.ForeColor = System.Drawing.Color.DarkGray;
            this.btnPos.Location = new System.Drawing.Point(50, 337);
            this.btnPos.Name = "btnPos";
            this.btnPos.Size = new System.Drawing.Size(90, 53);
            this.btnPos.TabIndex = 49;
            this.btnPos.TabStop = false;
            this.btnPos.Text = "기기등록신청";
            this.btnPos.UseVisualStyleBackColor = true;
            this.btnPos.Click += new System.EventHandler(this.btnPos_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.ClientSize = new System.Drawing.Size(635, 446);
            this.Controls.Add(this.btnPos);
            this.Controls.Add(this.lblCallCenterNo);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnReqSupport);
            this.Controls.Add(this.panelNumpad);
            this.Controls.Add(this.lblPW);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panelKeyDisplayWhite);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLogin";
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panelKeyDisplayWhite.ResumeLayout(false);
            this.panelKeyDisplayWhite.PerformLayout();
            this.panelNumpad.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblPW;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelKeyDisplayWhite;
        private System.Windows.Forms.TextBox tbPW;
        private System.Windows.Forms.Label lblKeyDisplayXX;
        private System.Windows.Forms.Panel panelNumpad;
        private System.Windows.Forms.Button btnKey1;
        private System.Windows.Forms.Button btnKey2;
        private System.Windows.Forms.Button btnKey0;
        private System.Windows.Forms.Button btnKey3;
        private System.Windows.Forms.Button btnKey4;
        private System.Windows.Forms.Button btnKeyLogin;
        private System.Windows.Forms.Button btnKeyBS;
        private System.Windows.Forms.Button btnKey5;
        private System.Windows.Forms.Button btnKey9;
        private System.Windows.Forms.Button btnKey6;
        private System.Windows.Forms.Button btnKey8;
        private System.Windows.Forms.Button btnKey7;
        private System.Windows.Forms.Button btnKeyClear;
        private System.Windows.Forms.Button btnReqSupport;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblCallCenterNo;
        private System.Windows.Forms.Button btnPos;
    }
}
namespace thepos2
{
    partial class frmAllimOR
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAllimOR));
            this.lblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbTelNo = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.allimPad = new System.Windows.Forms.Panel();
            this.btnKey1 = new System.Windows.Forms.Button();
            this.btnKey2 = new System.Windows.Forms.Button();
            this.btnKey0 = new System.Windows.Forms.Button();
            this.btnKey3 = new System.Windows.Forms.Button();
            this.btnKey4 = new System.Windows.Forms.Button();
            this.btnKeyBS = new System.Windows.Forms.Button();
            this.btnKey5 = new System.Windows.Forms.Button();
            this.btnKey9 = new System.Windows.Forms.Button();
            this.btnKey6 = new System.Windows.Forms.Button();
            this.btnKey8 = new System.Windows.Forms.Button();
            this.btnKey7 = new System.Windows.Forms.Button();
            this.btnKeyClear = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.allimPad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("맑은 고딕", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(285, 23);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(262, 54);
            this.lblTitle.TabIndex = 53;
            this.lblTitle.Text = "주문알림발송";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(211, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(320, 33);
            this.label1.TabIndex = 54;
            this.label1.Text = "휴대폰 번호를 입력해주세요";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbTelNo
            // 
            this.tbTelNo.BackColor = System.Drawing.Color.Gold;
            this.tbTelNo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbTelNo.CausesValidation = false;
            this.tbTelNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbTelNo.HideSelection = false;
            this.tbTelNo.Location = new System.Drawing.Point(337, 159);
            this.tbTelNo.MaxLength = 8;
            this.tbTelNo.Name = "tbTelNo";
            this.tbTelNo.Size = new System.Drawing.Size(194, 42);
            this.tbTelNo.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Black;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(359, 479);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(175, 64);
            this.btnOK.TabIndex = 58;
            this.btnOK.Text = "입력";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnNo
            // 
            this.btnNo.BackColor = System.Drawing.Color.White;
            this.btnNo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNo.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnNo.ForeColor = System.Drawing.Color.Black;
            this.btnNo.Location = new System.Drawing.Point(242, 479);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(111, 64);
            this.btnNo.TabIndex = 59;
            this.btnNo.Text = "건너뛰기";
            this.btnNo.UseVisualStyleBackColor = false;
            this.btnNo.Visible = false;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(209, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 39);
            this.label2.TabIndex = 61;
            this.label2.Text = "010-";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // allimPad
            // 
            this.allimPad.Controls.Add(this.btnKey1);
            this.allimPad.Controls.Add(this.btnKey2);
            this.allimPad.Controls.Add(this.btnKey0);
            this.allimPad.Controls.Add(this.btnKey3);
            this.allimPad.Controls.Add(this.btnKey4);
            this.allimPad.Controls.Add(this.btnKeyBS);
            this.allimPad.Controls.Add(this.btnKey5);
            this.allimPad.Controls.Add(this.btnKey9);
            this.allimPad.Controls.Add(this.btnKey6);
            this.allimPad.Controls.Add(this.btnKey8);
            this.allimPad.Controls.Add(this.btnKey7);
            this.allimPad.Controls.Add(this.btnKeyClear);
            this.allimPad.Location = new System.Drawing.Point(227, 232);
            this.allimPad.Margin = new System.Windows.Forms.Padding(30);
            this.allimPad.Name = "allimPad";
            this.allimPad.Padding = new System.Windows.Forms.Padding(30);
            this.allimPad.Size = new System.Drawing.Size(325, 226);
            this.allimPad.TabIndex = 62;
            // 
            // btnKey1
            // 
            this.btnKey1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.btnKey1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKey1.ForeColor = System.Drawing.Color.White;
            this.btnKey1.Location = new System.Drawing.Point(15, 13);
            this.btnKey1.Margin = new System.Windows.Forms.Padding(0);
            this.btnKey1.Name = "btnKey1";
            this.btnKey1.Size = new System.Drawing.Size(69, 62);
            this.btnKey1.TabIndex = 1;
            this.btnKey1.TabStop = false;
            this.btnKey1.Text = "1";
            this.btnKey1.UseVisualStyleBackColor = false;
            this.btnKey1.Click += new System.EventHandler(this.btnKey1_Click);
            // 
            // btnKey2
            // 
            this.btnKey2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.btnKey2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKey2.ForeColor = System.Drawing.Color.White;
            this.btnKey2.Location = new System.Drawing.Point(90, 13);
            this.btnKey2.Name = "btnKey2";
            this.btnKey2.Size = new System.Drawing.Size(69, 62);
            this.btnKey2.TabIndex = 1;
            this.btnKey2.TabStop = false;
            this.btnKey2.Text = "2";
            this.btnKey2.UseVisualStyleBackColor = false;
            this.btnKey2.Click += new System.EventHandler(this.btnKey2_Click);
            // 
            // btnKey0
            // 
            this.btnKey0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.btnKey0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey0.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKey0.ForeColor = System.Drawing.Color.White;
            this.btnKey0.Location = new System.Drawing.Point(239, 147);
            this.btnKey0.Name = "btnKey0";
            this.btnKey0.Size = new System.Drawing.Size(69, 62);
            this.btnKey0.TabIndex = 1;
            this.btnKey0.TabStop = false;
            this.btnKey0.Text = "0";
            this.btnKey0.UseVisualStyleBackColor = false;
            this.btnKey0.Click += new System.EventHandler(this.btnKey0_Click);
            // 
            // btnKey3
            // 
            this.btnKey3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.btnKey3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKey3.ForeColor = System.Drawing.Color.White;
            this.btnKey3.Location = new System.Drawing.Point(164, 13);
            this.btnKey3.Name = "btnKey3";
            this.btnKey3.Size = new System.Drawing.Size(69, 62);
            this.btnKey3.TabIndex = 1;
            this.btnKey3.TabStop = false;
            this.btnKey3.Text = "3";
            this.btnKey3.UseVisualStyleBackColor = false;
            this.btnKey3.Click += new System.EventHandler(this.btnKey3_Click);
            // 
            // btnKey4
            // 
            this.btnKey4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.btnKey4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKey4.ForeColor = System.Drawing.Color.White;
            this.btnKey4.Location = new System.Drawing.Point(238, 13);
            this.btnKey4.Name = "btnKey4";
            this.btnKey4.Size = new System.Drawing.Size(69, 62);
            this.btnKey4.TabIndex = 1;
            this.btnKey4.TabStop = false;
            this.btnKey4.Text = "4";
            this.btnKey4.UseVisualStyleBackColor = false;
            this.btnKey4.Click += new System.EventHandler(this.btnKey4_Click);
            // 
            // btnKeyBS
            // 
            this.btnKeyBS.BackColor = System.Drawing.Color.Brown;
            this.btnKeyBS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeyBS.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKeyBS.ForeColor = System.Drawing.Color.White;
            this.btnKeyBS.Location = new System.Drawing.Point(89, 147);
            this.btnKeyBS.Name = "btnKeyBS";
            this.btnKeyBS.Size = new System.Drawing.Size(69, 62);
            this.btnKeyBS.TabIndex = 1;
            this.btnKeyBS.TabStop = false;
            this.btnKeyBS.Text = "<";
            this.btnKeyBS.UseVisualStyleBackColor = false;
            this.btnKeyBS.Click += new System.EventHandler(this.btnKeyBS_Click);
            // 
            // btnKey5
            // 
            this.btnKey5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.btnKey5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKey5.ForeColor = System.Drawing.Color.White;
            this.btnKey5.Location = new System.Drawing.Point(15, 80);
            this.btnKey5.Name = "btnKey5";
            this.btnKey5.Size = new System.Drawing.Size(69, 62);
            this.btnKey5.TabIndex = 1;
            this.btnKey5.TabStop = false;
            this.btnKey5.Text = "5";
            this.btnKey5.UseVisualStyleBackColor = false;
            this.btnKey5.Click += new System.EventHandler(this.btnKey5_Click);
            // 
            // btnKey9
            // 
            this.btnKey9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.btnKey9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKey9.ForeColor = System.Drawing.Color.White;
            this.btnKey9.Location = new System.Drawing.Point(164, 147);
            this.btnKey9.Name = "btnKey9";
            this.btnKey9.Size = new System.Drawing.Size(69, 62);
            this.btnKey9.TabIndex = 1;
            this.btnKey9.TabStop = false;
            this.btnKey9.Text = "9";
            this.btnKey9.UseVisualStyleBackColor = false;
            this.btnKey9.Click += new System.EventHandler(this.btnKey9_Click);
            // 
            // btnKey6
            // 
            this.btnKey6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.btnKey6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKey6.ForeColor = System.Drawing.Color.White;
            this.btnKey6.Location = new System.Drawing.Point(89, 80);
            this.btnKey6.Name = "btnKey6";
            this.btnKey6.Size = new System.Drawing.Size(69, 62);
            this.btnKey6.TabIndex = 1;
            this.btnKey6.TabStop = false;
            this.btnKey6.Text = "6";
            this.btnKey6.UseVisualStyleBackColor = false;
            this.btnKey6.Click += new System.EventHandler(this.btnKey6_Click);
            // 
            // btnKey8
            // 
            this.btnKey8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.btnKey8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKey8.ForeColor = System.Drawing.Color.White;
            this.btnKey8.Location = new System.Drawing.Point(239, 80);
            this.btnKey8.Name = "btnKey8";
            this.btnKey8.Size = new System.Drawing.Size(69, 62);
            this.btnKey8.TabIndex = 1;
            this.btnKey8.TabStop = false;
            this.btnKey8.Text = "8";
            this.btnKey8.UseVisualStyleBackColor = false;
            this.btnKey8.Click += new System.EventHandler(this.btnKey8_Click);
            // 
            // btnKey7
            // 
            this.btnKey7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.btnKey7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKey7.ForeColor = System.Drawing.Color.White;
            this.btnKey7.Location = new System.Drawing.Point(164, 80);
            this.btnKey7.Name = "btnKey7";
            this.btnKey7.Size = new System.Drawing.Size(69, 62);
            this.btnKey7.TabIndex = 1;
            this.btnKey7.TabStop = false;
            this.btnKey7.Text = "7";
            this.btnKey7.UseVisualStyleBackColor = false;
            this.btnKey7.Click += new System.EventHandler(this.btnKey7_Click);
            // 
            // btnKeyClear
            // 
            this.btnKeyClear.BackColor = System.Drawing.Color.Brown;
            this.btnKeyClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeyClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKeyClear.ForeColor = System.Drawing.Color.White;
            this.btnKeyClear.Location = new System.Drawing.Point(15, 147);
            this.btnKeyClear.Name = "btnKeyClear";
            this.btnKeyClear.Size = new System.Drawing.Size(69, 62);
            this.btnKeyClear.TabIndex = 1;
            this.btnKeyClear.TabStop = false;
            this.btnKeyClear.Text = "C";
            this.btnKeyClear.UseVisualStyleBackColor = false;
            this.btnKeyClear.Click += new System.EventHandler(this.btnKeyClear_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Black;
            this.pictureBox2.Location = new System.Drawing.Point(241, 203);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(286, 2);
            this.pictureBox2.TabIndex = 60;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(218, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(61, 54);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 55;
            this.pictureBox1.TabStop = false;
            // 
            // frmAllimOR
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Gold;
            this.CancelButton = this.btnNo;
            this.ClientSize = new System.Drawing.Size(790, 577);
            this.Controls.Add(this.allimPad);
            this.Controls.Add(this.tbTelNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAllimOR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmAllim";
            this.allimPad.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tbTelNo;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel allimPad;
        private System.Windows.Forms.Button btnKey1;
        private System.Windows.Forms.Button btnKey2;
        private System.Windows.Forms.Button btnKey0;
        private System.Windows.Forms.Button btnKey3;
        private System.Windows.Forms.Button btnKey4;
        private System.Windows.Forms.Button btnKeyBS;
        private System.Windows.Forms.Button btnKey5;
        private System.Windows.Forms.Button btnKey9;
        private System.Windows.Forms.Button btnKey6;
        private System.Windows.Forms.Button btnKey8;
        private System.Windows.Forms.Button btnKey7;
        private System.Windows.Forms.Button btnKeyClear;
    }
}
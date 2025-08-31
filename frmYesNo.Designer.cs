namespace thepos
{
    partial class frmYesNo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmYesNo));
            this.lblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblOrderNo = new System.Windows.Forms.Label();
            this.lblOrderNo2 = new System.Windows.Forms.Label();
            this.lblFromToChar = new System.Windows.Forms.Label();
            this.btnNo = new System.Windows.Forms.Button();
            this.btnYes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("맑은 고딕", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(171, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(401, 130);
            this.lblTitle.TabIndex = 46;
            this.lblTitle.Text = "주문완료";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(354, 260);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(308, 48);
            this.label1.TabIndex = 46;
            this.label1.Text = "영수증을 출력할까요?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(69, 262);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 48);
            this.label2.TabIndex = 46;
            this.label2.Text = "주문번호";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOrderNo
            // 
            this.lblOrderNo.Font = new System.Drawing.Font("맑은 고딕", 50F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderNo.ForeColor = System.Drawing.Color.White;
            this.lblOrderNo.Location = new System.Drawing.Point(39, 310);
            this.lblOrderNo.Margin = new System.Windows.Forms.Padding(0);
            this.lblOrderNo.Name = "lblOrderNo";
            this.lblOrderNo.Size = new System.Drawing.Size(248, 92);
            this.lblOrderNo.TabIndex = 46;
            this.lblOrderNo.Text = "0002";
            this.lblOrderNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOrderNo2
            // 
            this.lblOrderNo2.Font = new System.Drawing.Font("맑은 고딕", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderNo2.ForeColor = System.Drawing.Color.White;
            this.lblOrderNo2.Location = new System.Drawing.Point(80, 416);
            this.lblOrderNo2.Name = "lblOrderNo2";
            this.lblOrderNo2.Size = new System.Drawing.Size(166, 57);
            this.lblOrderNo2.TabIndex = 46;
            this.lblOrderNo2.Text = "0003";
            this.lblOrderNo2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblOrderNo2.Visible = false;
            // 
            // lblFromToChar
            // 
            this.lblFromToChar.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblFromToChar.ForeColor = System.Drawing.Color.White;
            this.lblFromToChar.Location = new System.Drawing.Point(128, 397);
            this.lblFromToChar.Name = "lblFromToChar";
            this.lblFromToChar.Size = new System.Drawing.Size(65, 20);
            this.lblFromToChar.TabIndex = 46;
            this.lblFromToChar.Text = "~";
            this.lblFromToChar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFromToChar.Visible = false;
            // 
            // btnNo
            // 
            this.btnNo.BackColor = System.Drawing.Color.SaddleBrown;
            this.btnNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNo.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnNo.ForeColor = System.Drawing.Color.White;
            this.btnNo.Image = ((System.Drawing.Image)(resources.GetObject("btnNo.Image")));
            this.btnNo.Location = new System.Drawing.Point(501, 324);
            this.btnNo.Name = "btnNo";
            this.btnNo.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.btnNo.Size = new System.Drawing.Size(142, 146);
            this.btnNo.TabIndex = 45;
            this.btnNo.Text = "안함";
            this.btnNo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNo.UseVisualStyleBackColor = false;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // btnYes
            // 
            this.btnYes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.btnYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYes.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnYes.ForeColor = System.Drawing.Color.White;
            this.btnYes.Image = ((System.Drawing.Image)(resources.GetObject("btnYes.Image")));
            this.btnYes.Location = new System.Drawing.Point(359, 324);
            this.btnYes.Name = "btnYes";
            this.btnYes.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.btnYes.Size = new System.Drawing.Size(136, 146);
            this.btnYes.TabIndex = 44;
            this.btnYes.Text = "출력";
            this.btnYes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnYes.UseVisualStyleBackColor = false;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // frmYesNo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(738, 561);
            this.Controls.Add(this.lblFromToChar);
            this.Controls.Add(this.lblOrderNo2);
            this.Controls.Add(this.lblOrderNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnYes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmYesNo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmYesNo";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblOrderNo;
        private System.Windows.Forms.Label lblOrderNo2;
        private System.Windows.Forms.Label lblFromToChar;
    }
}
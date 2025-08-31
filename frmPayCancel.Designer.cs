namespace thepos
{
    partial class frmPayCancel
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
            this.panelback = new System.Windows.Forms.Panel();
            this.lblNestAmount = new System.Windows.Forms.Label();
            this.lblCancelAmount = new System.Windows.Forms.Label();
            this.lblT3 = new System.Windows.Forms.Label();
            this.lblNetAmount = new System.Windows.Forms.Label();
            this.lblT2 = new System.Windows.Forms.Label();
            this.lblT1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lvwList = new System.Windows.Forms.ListView();
            this.no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pay_dt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pay_type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.theno = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.paytype = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnClose1 = new System.Windows.Forms.Button();
            this.panelback.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelback
            // 
            this.panelback.BackColor = System.Drawing.Color.LightGray;
            this.panelback.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelback.Controls.Add(this.btnClose1);
            this.panelback.Controls.Add(this.lblNestAmount);
            this.panelback.Controls.Add(this.lblCancelAmount);
            this.panelback.Controls.Add(this.lblT3);
            this.panelback.Controls.Add(this.lblNetAmount);
            this.panelback.Controls.Add(this.lblT2);
            this.panelback.Controls.Add(this.lblT1);
            this.panelback.Controls.Add(this.btnClose);
            this.panelback.Controls.Add(this.lblTitle);
            this.panelback.Controls.Add(this.btnCancel);
            this.panelback.Controls.Add(this.lvwList);
            this.panelback.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panelback.Location = new System.Drawing.Point(3, 3);
            this.panelback.Name = "panelback";
            this.panelback.Size = new System.Drawing.Size(523, 698);
            this.panelback.TabIndex = 4;
            // 
            // lblNestAmount
            // 
            this.lblNestAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNestAmount.Location = new System.Drawing.Point(122, 133);
            this.lblNestAmount.Margin = new System.Windows.Forms.Padding(0);
            this.lblNestAmount.Name = "lblNestAmount";
            this.lblNestAmount.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.lblNestAmount.Size = new System.Drawing.Size(141, 24);
            this.lblNestAmount.TabIndex = 54;
            this.lblNestAmount.Tag = "0";
            this.lblNestAmount.Text = "0";
            this.lblNestAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCancelAmount
            // 
            this.lblCancelAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCancelAmount.Location = new System.Drawing.Point(122, 105);
            this.lblCancelAmount.Margin = new System.Windows.Forms.Padding(0);
            this.lblCancelAmount.Name = "lblCancelAmount";
            this.lblCancelAmount.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.lblCancelAmount.Size = new System.Drawing.Size(141, 24);
            this.lblCancelAmount.TabIndex = 54;
            this.lblCancelAmount.Tag = "0";
            this.lblCancelAmount.Text = "0";
            this.lblCancelAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblT3
            // 
            this.lblT3.AutoSize = true;
            this.lblT3.Location = new System.Drawing.Point(28, 140);
            this.lblT3.Name = "lblT3";
            this.lblT3.Size = new System.Drawing.Size(77, 14);
            this.lblT3.TabIndex = 52;
            this.lblT3.Text = "미취소금액";
            // 
            // lblNetAmount
            // 
            this.lblNetAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNetAmount.Location = new System.Drawing.Point(122, 77);
            this.lblNetAmount.Margin = new System.Windows.Forms.Padding(0);
            this.lblNetAmount.Name = "lblNetAmount";
            this.lblNetAmount.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.lblNetAmount.Size = new System.Drawing.Size(141, 24);
            this.lblNetAmount.TabIndex = 55;
            this.lblNetAmount.Tag = "0";
            this.lblNetAmount.Text = "0";
            this.lblNetAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblT2
            // 
            this.lblT2.AutoSize = true;
            this.lblT2.Location = new System.Drawing.Point(28, 112);
            this.lblT2.Name = "lblT2";
            this.lblT2.Size = new System.Drawing.Size(63, 14);
            this.lblT2.TabIndex = 52;
            this.lblT2.Text = "취소금액";
            // 
            // lblT1
            // 
            this.lblT1.AutoSize = true;
            this.lblT1.Location = new System.Drawing.Point(28, 82);
            this.lblT1.Name = "lblT1";
            this.lblT1.Size = new System.Drawing.Size(91, 14);
            this.lblT1.TabIndex = 53;
            this.lblT1.Text = "취소대상금액";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(460, 20);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 40);
            this.btnClose.TabIndex = 43;
            this.btnClose.Text = "✕";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(17, 20);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(4);
            this.lblTitle.Size = new System.Drawing.Size(485, 40);
            this.lblTitle.TabIndex = 40;
            this.lblTitle.Text = "반품/취소";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(239, 580);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(140, 50);
            this.btnCancel.TabIndex = 48;
            this.btnCancel.Text = "취소처리";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lvwList
            // 
            this.lvwList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.no,
            this.pay_dt,
            this.pay_type,
            this.amount,
            this.cc,
            this.theno,
            this.paytype});
            this.lvwList.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lvwList.FullRowSelect = true;
            this.lvwList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwList.HideSelection = false;
            this.lvwList.Location = new System.Drawing.Point(17, 178);
            this.lvwList.MultiSelect = false;
            this.lvwList.Name = "lvwList";
            this.lvwList.Size = new System.Drawing.Size(485, 346);
            this.lvwList.TabIndex = 44;
            this.lvwList.UseCompatibleStateImageBehavior = false;
            this.lvwList.View = System.Windows.Forms.View.Details;
            // 
            // no
            // 
            this.no.Text = "#";
            this.no.Width = 30;
            // 
            // pay_dt
            // 
            this.pay_dt.Text = "결제시간";
            this.pay_dt.Width = 90;
            // 
            // pay_type
            // 
            this.pay_type.Text = "결제";
            this.pay_type.Width = 100;
            // 
            // amount
            // 
            this.amount.Text = "금액";
            this.amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.amount.Width = 90;
            // 
            // cc
            // 
            this.cc.Text = "취소";
            // 
            // theno
            // 
            this.theno.Text = "";
            this.theno.Width = 0;
            // 
            // paytype
            // 
            this.paytype.Text = "";
            this.paytype.Width = 0;
            // 
            // btnClose1
            // 
            this.btnClose1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose1.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClose1.Location = new System.Drawing.Point(121, 581);
            this.btnClose1.Name = "btnClose1";
            this.btnClose1.Size = new System.Drawing.Size(112, 48);
            this.btnClose1.TabIndex = 182;
            this.btnClose1.Text = "닫기";
            this.btnClose1.UseVisualStyleBackColor = false;
            this.btnClose1.Click += new System.EventHandler(this.btnClose1_Click);
            // 
            // frmPayCancel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(529, 704);
            this.Controls.Add(this.panelback);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPayCancel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPayCancel";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPayCancel_FormClosed);
            this.Shown += new System.EventHandler(this.frmPayCancel_Shown);
            this.panelback.ResumeLayout(false);
            this.panelback.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelback;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ListView lvwList;
        private System.Windows.Forms.ColumnHeader no;
        private System.Windows.Forms.ColumnHeader pay_dt;
        private System.Windows.Forms.ColumnHeader pay_type;
        private System.Windows.Forms.ColumnHeader amount;
        private System.Windows.Forms.ColumnHeader cc;
        private System.Windows.Forms.ColumnHeader theno;
        private System.Windows.Forms.ColumnHeader paytype;
        private System.Windows.Forms.Label lblCancelAmount;
        private System.Windows.Forms.Label lblNetAmount;
        private System.Windows.Forms.Label lblT2;
        private System.Windows.Forms.Label lblT1;
        private System.Windows.Forms.Label lblNestAmount;
        private System.Windows.Forms.Label lblT3;
        private System.Windows.Forms.Button btnClose1;
    }
}
namespace thepos
{
    partial class frmPayManager
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lvwPayOrder = new System.Windows.Forms.ListView();
            this.no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pay_goods = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cnt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dc_shop = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnCancel = new System.Windows.Forms.Button();
            this.lvwPayManager = new System.Windows.Forms.ListView();
            this.bill_no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pay_class = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pay_type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.order_dt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pos_no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cancel_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.paykeep = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pay_calss = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cancel_code = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnBill = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(17, 19);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(5);
            this.lblTitle.Size = new System.Drawing.Size(648, 40);
            this.lblTitle.TabIndex = 128;
            this.lblTitle.Text = "결제관리";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lvwPayOrder
            // 
            this.lvwPayOrder.BackColor = System.Drawing.Color.White;
            this.lvwPayOrder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.no,
            this.pay_goods,
            this.cnt,
            this.dc_shop});
            this.lvwPayOrder.Font = new System.Drawing.Font("굴림체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lvwPayOrder.ForeColor = System.Drawing.Color.Black;
            this.lvwPayOrder.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwPayOrder.HideSelection = false;
            this.lvwPayOrder.Location = new System.Drawing.Point(20, 597);
            this.lvwPayOrder.MultiSelect = false;
            this.lvwPayOrder.Name = "lvwPayOrder";
            this.lvwPayOrder.Size = new System.Drawing.Size(519, 237);
            this.lvwPayOrder.TabIndex = 131;
            this.lvwPayOrder.TabStop = false;
            this.lvwPayOrder.UseCompatibleStateImageBehavior = false;
            this.lvwPayOrder.View = System.Windows.Forms.View.Details;
            // 
            // no
            // 
            this.no.Text = "#주문";
            this.no.Width = 78;
            // 
            // pay_goods
            // 
            this.pay_goods.Text = "상품/결제";
            this.pay_goods.Width = 247;
            // 
            // cnt
            // 
            this.cnt.Text = "수량";
            this.cnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.cnt.Width = 75;
            // 
            // dc_shop
            // 
            this.dc_shop.Text = "업장";
            this.dc_shop.Width = 90;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(553, 597);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(114, 71);
            this.btnCancel.TabIndex = 130;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "결제취소";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lvwPayManager
            // 
            this.lvwPayManager.BackColor = System.Drawing.Color.White;
            this.lvwPayManager.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.bill_no,
            this.pay_class,
            this.pay_type,
            this.order_dt,
            this.pos_no,
            this.amount,
            this.dc,
            this.cancel_name,
            this.paykeep,
            this.pay_calss,
            this.cancel_code});
            this.lvwPayManager.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lvwPayManager.ForeColor = System.Drawing.Color.Black;
            this.lvwPayManager.FullRowSelect = true;
            this.lvwPayManager.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwPayManager.HideSelection = false;
            this.lvwPayManager.Location = new System.Drawing.Point(19, 72);
            this.lvwPayManager.MultiSelect = false;
            this.lvwPayManager.Name = "lvwPayManager";
            this.lvwPayManager.Size = new System.Drawing.Size(646, 506);
            this.lvwPayManager.TabIndex = 129;
            this.lvwPayManager.UseCompatibleStateImageBehavior = false;
            this.lvwPayManager.View = System.Windows.Forms.View.Details;
            this.lvwPayManager.SelectedIndexChanged += new System.EventHandler(this.lvwPayManager_SelectedIndexChanged);
            // 
            // bill_no
            // 
            this.bill_no.Text = "영수증";
            this.bill_no.Width = 75;
            // 
            // pay_class
            // 
            this.pay_class.Text = "유형";
            this.pay_class.Width = 59;
            // 
            // pay_type
            // 
            this.pay_type.Text = "결제";
            this.pay_type.Width = 73;
            // 
            // order_dt
            // 
            this.order_dt.Text = "거래시간";
            this.order_dt.Width = 103;
            // 
            // pos_no
            // 
            this.pos_no.Text = "포스";
            this.pos_no.Width = 54;
            // 
            // amount
            // 
            this.amount.Text = "금액";
            this.amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.amount.Width = 81;
            // 
            // dc
            // 
            this.dc.Text = "할인";
            this.dc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dc.Width = 76;
            // 
            // cancel_name
            // 
            this.cancel_name.Text = "취소";
            this.cancel_name.Width = 70;
            // 
            // paykeep
            // 
            this.paykeep.Text = "";
            this.paykeep.Width = 0;
            // 
            // pay_calss
            // 
            this.pay_calss.Text = "";
            this.pay_calss.Width = 0;
            // 
            // cancel_code
            // 
            this.cancel_code.Text = "";
            this.cancel_code.Width = 0;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClose.Location = new System.Drawing.Point(554, 785);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 48);
            this.btnClose.TabIndex = 181;
            this.btnClose.Text = "닫기";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnBill
            // 
            this.btnBill.BackColor = System.Drawing.SystemColors.Control;
            this.btnBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBill.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnBill.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnBill.Location = new System.Drawing.Point(554, 677);
            this.btnBill.Name = "btnBill";
            this.btnBill.Size = new System.Drawing.Size(112, 68);
            this.btnBill.TabIndex = 182;
            this.btnBill.Text = "영수증";
            this.btnBill.UseVisualStyleBackColor = false;
            this.btnBill.Click += new System.EventHandler(this.btnBill_Click);
            // 
            // frmPayManager
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(681, 855);
            this.Controls.Add(this.btnBill);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lvwPayOrder);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lvwPayManager);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPayManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmBizClose";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ListView lvwPayOrder;
        private System.Windows.Forms.ColumnHeader no;
        private System.Windows.Forms.ColumnHeader pay_goods;
        private System.Windows.Forms.ColumnHeader cnt;
        private System.Windows.Forms.ColumnHeader dc_shop;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ListView lvwPayManager;
        private System.Windows.Forms.ColumnHeader bill_no;
        private System.Windows.Forms.ColumnHeader pay_class;
        private System.Windows.Forms.ColumnHeader pay_type;
        private System.Windows.Forms.ColumnHeader order_dt;
        private System.Windows.Forms.ColumnHeader pos_no;
        private System.Windows.Forms.ColumnHeader amount;
        private System.Windows.Forms.ColumnHeader dc;
        private System.Windows.Forms.ColumnHeader cancel_name;
        private System.Windows.Forms.ColumnHeader paykeep;
        private System.Windows.Forms.ColumnHeader pay_calss;
        private System.Windows.Forms.ColumnHeader cancel_code;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnBill;
    }
}
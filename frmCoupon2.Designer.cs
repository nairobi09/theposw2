namespace thepos2
{
    partial class frmCoupon2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCoupon2));
            this.btnOK = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnHome = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lvwCoupon = new BrightIdeasSoftware.ObjectListView();
            this.coupon_bar = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.tbCouponScan = new System.Windows.Forms.TextBox();
            this.timerHome = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvwCoupon)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Red;
            this.btnOK.Font = new System.Drawing.Font("맑은 고딕", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(344, 1531);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(350, 150);
            this.btnOK.TabIndex = 70;
            this.btnOK.TabStop = false;
            this.btnOK.Text = "쿠폰사용\r\n발권";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.Font = new System.Drawing.Font("굴림", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPrev.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.btnPrev.Image = ((System.Drawing.Image)(resources.GetObject("btnPrev.Image")));
            this.btnPrev.Location = new System.Drawing.Point(70, 650);
            this.btnPrev.Margin = new System.Windows.Forms.Padding(0);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(90, 90);
            this.btnPrev.TabIndex = 2;
            this.btnPrev.TabStop = false;
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "ticket_on");
            this.imageList1.Images.SetKeyName(1, "ticket_off");
            // 
            // btnHome
            // 
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("굴림", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnHome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.Location = new System.Drawing.Point(881, 650);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(90, 90);
            this.btnHome.TabIndex = 7;
            this.btnHome.TabStop = false;
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(409, 664);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 65);
            this.label1.TabIndex = 3;
            this.label1.Text = "쿠폰선택";
            // 
            // lvwCoupon
            // 
            this.lvwCoupon.AllColumns.Add(this.coupon_bar);
            this.lvwCoupon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvwCoupon.CellEditUseWholeCell = false;
            this.lvwCoupon.CellPadding = new System.Drawing.Rectangle(3, 3, 3, 3);
            this.lvwCoupon.CheckBoxes = true;
            this.lvwCoupon.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.coupon_bar});
            this.lvwCoupon.CopySelectionOnControlCUsesDragSource = false;
            this.lvwCoupon.Cursor = System.Windows.Forms.Cursors.Default;
            this.lvwCoupon.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lvwCoupon.ForeColor = System.Drawing.Color.Black;
            this.lvwCoupon.FullRowSelect = true;
            this.lvwCoupon.GridLines = true;
            this.lvwCoupon.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwCoupon.HideSelection = false;
            this.lvwCoupon.Location = new System.Drawing.Point(70, 900);
            this.lvwCoupon.MultiSelect = false;
            this.lvwCoupon.Name = "lvwCoupon";
            this.lvwCoupon.RowHeight = 100;
            this.lvwCoupon.SelectAllOnControlA = false;
            this.lvwCoupon.ShowGroups = false;
            this.lvwCoupon.ShowImagesOnSubItems = true;
            this.lvwCoupon.Size = new System.Drawing.Size(900, 525);
            this.lvwCoupon.SmallImageList = this.imageList1;
            this.lvwCoupon.TabIndex = 60;
            this.lvwCoupon.TabStop = false;
            this.lvwCoupon.TriStateCheckBoxes = true;
            this.lvwCoupon.UseCompatibleStateImageBehavior = false;
            this.lvwCoupon.UseHotControls = false;
            this.lvwCoupon.View = System.Windows.Forms.View.Details;
            // 
            // coupon_bar
            // 
            this.coupon_bar.AspectName = "coupon_bar";
            this.coupon_bar.CellPadding = new System.Drawing.Rectangle(0, 16, 0, 0);
            this.coupon_bar.ImageAspectName = "image_ticket";
            this.coupon_bar.Text = "　";
            this.coupon_bar.Width = 900;
            this.coupon_bar.WordWrap = true;
            // 
            // tbCouponScan
            // 
            this.tbCouponScan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.tbCouponScan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbCouponScan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.tbCouponScan.Location = new System.Drawing.Point(161, 1857);
            this.tbCouponScan.Name = "tbCouponScan";
            this.tbCouponScan.Size = new System.Drawing.Size(729, 14);
            this.tbCouponScan.TabIndex = 0;
            this.tbCouponScan.Text = "123";
            this.tbCouponScan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timerHome
            // 
            this.timerHome.Tick += new System.EventHandler(this.timerHome_Tick);
            // 
            // frmCoupon2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(1040, 1880);
            this.Controls.Add(this.tbCouponScan);
            this.Controls.Add(this.lvwCoupon);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCoupon2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCoupon";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvwCoupon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private BrightIdeasSoftware.ObjectListView lvwCoupon;
        private BrightIdeasSoftware.OLVColumn coupon_bar;
        private System.Windows.Forms.TextBox tbCouponScan;
        private System.Windows.Forms.Timer timerHome;
    }
}
﻿namespace thepos2
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
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnUnselect = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lvwCoupon = new BrightIdeasSoftware.ObjectListView();
            this.lv_coupon = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.lv_checked = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvwCoupon)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Red;
            this.btnOK.Font = new System.Drawing.Font("굴림", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(520, 1550);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(350, 150);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "발권";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.Font = new System.Drawing.Font("굴림", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPrev.Image = ((System.Drawing.Image)(resources.GetObject("btnPrev.Image")));
            this.btnPrev.Location = new System.Drawing.Point(50, 650);
            this.btnPrev.Margin = new System.Windows.Forms.Padding(0);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(90, 90);
            this.btnPrev.TabIndex = 2;
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "unchecked");
            this.imageList1.Images.SetKeyName(1, "checked");
            // 
            // btnHome
            // 
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("굴림", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.Location = new System.Drawing.Point(861, 650);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(90, 90);
            this.btnHome.TabIndex = 7;
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.BackColor = System.Drawing.Color.DimGray;
            this.btnSelect.Font = new System.Drawing.Font("굴림", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSelect.ForeColor = System.Drawing.Color.White;
            this.btnSelect.Location = new System.Drawing.Point(141, 1550);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(180, 150);
            this.btnSelect.TabIndex = 8;
            this.btnSelect.Text = "전체\r\n선택";
            this.btnSelect.UseVisualStyleBackColor = false;
            // 
            // btnUnselect
            // 
            this.btnUnselect.BackColor = System.Drawing.Color.DimGray;
            this.btnUnselect.Font = new System.Drawing.Font("굴림", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnUnselect.ForeColor = System.Drawing.Color.White;
            this.btnUnselect.Location = new System.Drawing.Point(327, 1550);
            this.btnUnselect.Name = "btnUnselect";
            this.btnUnselect.Size = new System.Drawing.Size(180, 150);
            this.btnUnselect.TabIndex = 9;
            this.btnUnselect.Text = "전체\r\n해제";
            this.btnUnselect.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 480);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1000, 140);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // lvwCoupon
            // 
            this.lvwCoupon.AllColumns.Add(this.lv_coupon);
            this.lvwCoupon.AllColumns.Add(this.lv_checked);
            this.lvwCoupon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvwCoupon.CellEditUseWholeCell = false;
            this.lvwCoupon.CheckBoxes = true;
            this.lvwCoupon.CheckedAspectName = "";
            this.lvwCoupon.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lv_coupon,
            this.lv_checked});
            this.lvwCoupon.Cursor = System.Windows.Forms.Cursors.Default;
            this.lvwCoupon.Font = new System.Drawing.Font("맑은 고딕", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lvwCoupon.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lvwCoupon.GridLines = true;
            this.lvwCoupon.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwCoupon.HideSelection = false;
            this.lvwCoupon.Location = new System.Drawing.Point(50, 800);
            this.lvwCoupon.MultiSelect = false;
            this.lvwCoupon.Name = "lvwCoupon";
            this.lvwCoupon.RowHeight = 80;
            this.lvwCoupon.SelectAllOnControlA = false;
            this.lvwCoupon.ShowGroups = false;
            this.lvwCoupon.ShowImagesOnSubItems = true;
            this.lvwCoupon.Size = new System.Drawing.Size(900, 600);
            this.lvwCoupon.SmallImageList = this.imageList1;
            this.lvwCoupon.TabIndex = 70;
            this.lvwCoupon.TabStop = false;
            this.lvwCoupon.UseCompatibleStateImageBehavior = false;
            this.lvwCoupon.UseHotControls = false;
            this.lvwCoupon.UseSubItemCheckBoxes = true;
            this.lvwCoupon.View = System.Windows.Forms.View.Details;
            // 
            // lv_coupon
            // 
            this.lv_coupon.AspectName = "lv_coupon";
            this.lv_coupon.CellPadding = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.lv_coupon.Text = "상품명";
            this.lv_coupon.Width = 600;
            this.lv_coupon.WordWrap = true;
            // 
            // lv_checked
            // 
            this.lv_checked.AspectName = "lv_checked";
            this.lv_checked.CheckBoxes = true;
            this.lv_checked.ImageAspectName = "";
            this.lv_checked.Text = "선택";
            this.lv_checked.Width = 87;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(380, 676);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 48);
            this.label1.TabIndex = 3;
            this.label1.Text = "쿠폰선택";
            // 
            // frmCoupon2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(1000, 1800);
            this.Controls.Add(this.lvwCoupon);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnUnselect);
            this.Controls.Add(this.btnSelect);
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
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnUnselect;
        private System.Windows.Forms.PictureBox pictureBox1;
        private BrightIdeasSoftware.ObjectListView lvwCoupon;
        private BrightIdeasSoftware.OLVColumn lv_coupon;
        private BrightIdeasSoftware.OLVColumn lv_checked;
        private System.Windows.Forms.Label label1;
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static thepos.thepos;

namespace thepos
{
    public partial class frmCoupon : Form
    {

        String sysadmin_pw_patern = "";


        public frmCoupon()
        {
            InitializeComponent();

            //
            thepos_app_log(1, this.Name, "Open", "");



            // 기본 대기화면
            if (mCouponDisplayImage.Length > 0)
            {
                try
                {
                    byte[] imgBytes = Convert.FromBase64String(mCouponDisplayImage);
                    MemoryStream ms = new MemoryStream(imgBytes, 0, imgBytes.Length);
                    ms.Write(imgBytes, 0, imgBytes.Length);
                    pbGate1.Image = System.Drawing.Image.FromStream(ms, true);
                }
                catch(Exception ex)
                {
                    //
                    thepos_app_log(3, this.Name, "mCouponDisplayImage", ex.Message);
                }
            }
        }



        private void pbGate1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Y > 100)
            {
                frmCoupon1 frm = new frmCoupon1();
                frm.ShowDialog();

                thepos_app_log(1, this.Name, "Return", "");

                return;
            }


            sysadmin_pw_patern += "1";

            if (sysadmin_pw_patern.Length >= 4)
            {

                //
                thepos_app_log(1, this.Name, "GateImage 4-click", "");


                ContextMenuStrip m = new ContextMenuStrip();

                ToolStripMenuItem m0 = new ToolStripMenuItem(mAppVersion);
                ToolStripMenuItem m1 = new ToolStripMenuItem("내기기설정");
                ToolStripMenuItem m2 = new ToolStripMenuItem("원격지원");
                ToolStripMenuItem m3 = new ToolStripMenuItem("종료");

                ToolStripSeparator separator = new ToolStripSeparator();


                m0.Font = new System.Drawing.Font("v1.02K", 12F);

                m1.Font = new System.Drawing.Font("내기기설정", 20F);
                m1.Click += (senders, es) =>
                {
                    frmSetupPos frm = new frmSetupPos();
                    frm.ShowDialog();
                };


                m2.Font = new System.Drawing.Font("원격지원", 20F);
                m2.Click += (senders, es) =>
                {
                    //
                    thepos_app_log(1, this.Name, "원격지원", "");

                    //원격지원
                    System.Diagnostics.Process.Start("http://786.co.kr");
                };


                m3.Font = new System.Drawing.Font("종료", 30F);
                m3.Click += (senders, es) =>
                {
                    //
                    thepos_app_log(2, this.Name, "Close", "appVersion=TPW2-" + mAppVersion + ", mac=" + mMacAddr);

                    this.Close();
                };


                m.Items.Add(m0);
                m.Items.Add(m1);
                m.Items.Add(m2);
                m.Items.Add(separator);
                m.Items.Add(m3);


                Point p = new Point(pbGate1.Location.X + 20, pbGate1.Location.Y);

                m.Show(this, p);

                //
                sysadmin_pw_patern = "";
            }
        }
    }
}

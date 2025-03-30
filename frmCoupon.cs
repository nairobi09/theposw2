using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static thepos2.thepos;

namespace thepos2
{
    public partial class frmCoupon : Form
    {

        String sysadmin_pw_patern = "";


        public frmCoupon()
        {
            InitializeComponent();





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
                catch
                {

                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            frmCoupon1 frm = new frmCoupon1();
            frm.ShowDialog();
        }


        private void pbGate1_Click(object sender, EventArgs e)
        {
            sysadmin_pw_patern += "1";


            if (sysadmin_pw_patern.Length >= 4)
            {


                ContextMenuStrip m = new ContextMenuStrip();

                ToolStripMenuItem m0 = new ToolStripMenuItem("v1.02K");
                ToolStripMenuItem m1 = new ToolStripMenuItem("내기기설정");
                ToolStripMenuItem m3 = new ToolStripMenuItem("종료");

                m0.Font = new System.Drawing.Font("v1.02K", 12F);

                m1.Font = new System.Drawing.Font("내기기설정", 20F);
                m1.Click += (senders, es) =>
                {
                    frmSetupPos frm = new frmSetupPos();
                    frm.ShowDialog();
                };


                m3.Font = new System.Drawing.Font("종료", 20F);
                m3.Click += (senders, es) =>
                {
                    this.Close();
                };


                m.Items.Add(m0);
                m.Items.Add(m1);
                m.Items.Add(m3);


                Point p = new Point(pbGate1.Location.X + 400, pbGate1.Location.Y);

                m.Show(this, p);

                //
                sysadmin_pw_patern = "";
            }
        }
    }
}

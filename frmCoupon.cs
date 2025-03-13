using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static thepos2.thepos;

namespace thepos2
{
    public partial class frmCoupon : Form
    {
        public frmCoupon()
        {
            InitializeComponent();

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            String coupon_no = tbNo.Text;

            if (mCouponChPM == "")
            {
                MessageBox.Show("쿠픈판매 업체코드 미등록상태입니다.", "thepos");
                return;
            }


            couponPM p = new couponPM();
            int ret = p.requestPmCertView(tbNo.Text);

            if (ret == 0)
            {
                if (mCertOrders.Count == 1)
                {
                    // mCertOrders 전달
                }
                else if (mCertOrders.Count == 0)
                {
                    MessageBox.Show("쿠폰정보가 없습니다.");
                    return;
                }
                else
                {
                    MessageBox.Show("쿠폰정보 오류.");
                    return;
                }
            }
            else
            {
                return;
            }


            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void btnCouponCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}

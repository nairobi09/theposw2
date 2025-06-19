using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using theposw2;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static thepos2.thepos;

namespace thepos2
{
    public partial class frmCoupon1 : Form
    {

        public frmCoupon1()
        {
            InitializeComponent();

            initialize_the();

            tbCouponScan.Text = "";
            tbCouponScan.Focus();

            //
            thepos_app_log(1, this.Name, "Open", "");
        }


        private void initialize_the()
        {

            //
            //   스캐너에서 영문자 인식오류 발생 대응.
            //
            //  .NET 입력 처리에 IME 설정 고려
            //  만약 IME를 통해 한글 입력 등이 간섭된다면 IME를 꺼보는 것도 방법입니다.
            //  IME나 시스템 구성 요소 누락 (LTSB에서 자주 발생)
            //
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("en-US"));



            btn1.Click += (sender, args) => ClickedKey("1");
            btn2.Click += (sender, args) => ClickedKey("2");
            btn3.Click += (sender, args) => ClickedKey("3");
            btn4.Click += (sender, args) => ClickedKey("4");
            btn5.Click += (sender, args) => ClickedKey("5");
            btn6.Click += (sender, args) => ClickedKey("6");
            btn7.Click += (sender, args) => ClickedKey("7");
            btn8.Click += (sender, args) => ClickedKey("8");
            btn9.Click += (sender, args) => ClickedKey("9");
            btn0.Click += (sender, args) => ClickedKey("0");

            btnBS.Click += (sender, args) => ClickedKey("BS");
            btnClear.Click += (sender, args) => ClickedKey("Clear");

            btnA.Click += (sender, args) => ClickedKey("A");
            btnB.Click += (sender, args) => ClickedKey("B");
            btnC.Click += (sender, args) => ClickedKey("C");
            btnD.Click += (sender, args) => ClickedKey("D");
            btnE.Click += (sender, args) => ClickedKey("E");
            btnF.Click += (sender, args) => ClickedKey("F");
            btnG.Click += (sender, args) => ClickedKey("G");
            btnH.Click += (sender, args) => ClickedKey("H");
            btnI.Click += (sender, args) => ClickedKey("I");
            btnJ.Click += (sender, args) => ClickedKey("J");
            btnK.Click += (sender, args) => ClickedKey("K");
            btnL.Click += (sender, args) => ClickedKey("L");
            btnM.Click += (sender, args) => ClickedKey("M");
            btnN.Click += (sender, args) => ClickedKey("N");
            btnO.Click += (sender, args) => ClickedKey("O");
            btnP.Click += (sender, args) => ClickedKey("P");
            btnQ.Click += (sender, args) => ClickedKey("Q");
            btnR.Click += (sender, args) => ClickedKey("R");
            btnS.Click += (sender, args) => ClickedKey("S");
            btnT.Click += (sender, args) => ClickedKey("T");
            btnU.Click += (sender, args) => ClickedKey("U");
            btnV.Click += (sender, args) => ClickedKey("V");
            btnW.Click += (sender, args) => ClickedKey("W");
            btnX.Click += (sender, args) => ClickedKey("X");
            btnY.Click += (sender, args) => ClickedKey("Y");
            btnZ.Click += (sender, args) => ClickedKey("Z");

            btnDash.Click += (sender, args) => ClickedKey("-");
            btn_.Click += (sender, args) => ClickedKey("_");

        }



        private void tbCouponScan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                
                String cpn = tbCouponScan.Text;
                tbCouponScan.Clear();

                if (cpn.Length < 10)
                {
                    thepos_app_log(3, this.Name, "scanner", "skip. coupon_no=" + cpn);
                    return;
                }


                request_tm_cert(cpn);
                
                tbCouponScan.Focus();
            }
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lblCouponText.Text == "")
            {
                return;
            }

            request_tm_cert(lblCouponText.Text);

        }



        private void request_tm_cert(String t_coupon_no)
        {
            //? 쿠폰업체 추가시 아래 구분필요
            if (mCouponMID == "")
            {
                //
                thepos_app_log(3, this.Name, "view_reload()", "쿠픈판매 업체코드(MID) 미등록상태입니다.");

                MessageBox.Show("쿠픈판매 업체코드(MID) 미등록상태입니다.", "thepos");
                return;
            }


            couponTM p = new couponTM();
            int ret = p.requestTmCertView(t_coupon_no);

            if (ret == 0)
            {
                if (mObj["result"].ToString() == "1000")
                {

                }
                else
                {
                    //
                    thepos_app_log(3, this.Name, "requestTmCertView()", "오류 " + mObj["msg"].ToString() + " no=" + t_coupon_no);

                    tpMessageBox tpMessageBox = new tpMessageBox("오류\r\n" + mObj["msg"].ToString() );
                    tpMessageBox.ShowDialog();
                    return;
                }
            }
            else
            {
                //
                thepos_app_log(3, this.Name, "requestTmCertView()", "쿠폰조회중에 오류가 발생했습니다. " + mErrorMsg);

                tpMessageBox tpMessageBox = new tpMessageBox("쿠폰조회중에 오류가 발생했습니다.\r\n" + mErrorMsg + "\r\n\r\n관리자에게 문의바랍니다.");
                tpMessageBox.ShowDialog();
                return;

            }



            //
            String data = mObj["info"].ToString();
            JArray info = JArray.Parse(data);

            for (int i = 0; i < info.Count; i++)
            {
                // 다음 화면에서 에러날지 미리 해본다..
                try 
                { 
                    string coupon_no = info[i]["barcode_no"].ToString();
                    string ustate_code = info[i]["ustate"].ToString();
                    string coupon_name = info[i]["cusitem"].ToString();
                    string coupon_link_no = info[i]["cusitemId"].ToString();   // 상품코드 매칭용   TM + 0000

                    string cus_nm = info[i]["cusnm"].ToString();
                    string cus_hp = info[i]["cushp"].ToString();
                    string exp_date = info[i]["expdate"].ToString();

                    string state = info[i]["state"].ToString();
                    string ch_name = info[i]["cuschnm"].ToString();
                }
                catch (Exception e)
                {
                    //
                    thepos_app_log(3, this.Name, "requestTmCertView()", "쿠폰조회중에 오류가 발생했습니다. " + e.Message);

                    tpMessageBox tpMessageBox = new tpMessageBox("쿠폰조회중에 오류가 발생했습니다.\r\n" + e.Message + "\r\n\r\n관리자에게 문의바랍니다.");
                    tpMessageBox.ShowDialog();
                    return;
                }
            }



            //
            thepos_app_log(1, this.Name, "requestTmCertView()", "정상. coupon_no=[" + t_coupon_no + "]");



            frmCoupon2 frm = new frmCoupon2(mObj);
            DialogResult res = frm.ShowDialog();

            if (res == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else if(res == DialogResult.Cancel)
            {
                //
                tbCouponScan.Text = "";
                tbCouponScan.Focus();

                //
                lblCouponText.Text = "";

            }

        }

        private void ClickedKey(string sKey)
        {
            if (sKey == "BS")
            {
                if (lblCouponText.Text.Length > 0)
                {
                    lblCouponText.Text = lblCouponText.Text.Substring(0, lblCouponText.Text.Length - 1);
                }
            }
            else if (sKey == "Clear")
            {
                lblCouponText.Text = "";
            }
            else
            {
                lblCouponText.Text += sKey;
            }
        }


        private void btnCouponImage_Click(object sender, EventArgs e)
        {

            btnCouponImage.ForeColor = Color.Red;
            btnCouponNo.ForeColor = Color.Gray;

            panelCouponImage.Visible = true;
            panelCouponNo.Visible = false;

            tbCouponScan.Text = "";
            tbCouponScan.Focus();


            //
            thepos_app_log(1, this.Name, "click btnCouponImage", "");

        }

        private void btnCouponNo_Click(object sender, EventArgs e)
        {

            btnCouponImage.ForeColor = Color.Gray;
            btnCouponNo.ForeColor = Color.Red;

            panelCouponImage.Visible = false;
            panelCouponNo.Visible = true;

            //
            thepos_app_log(1, this.Name, "click btnCouponNo", "");

        }

        private void tbCouponScan_Leave(object sender, EventArgs e)
        {
            tbCouponScan.Focus();
        }


        private void btnHome_Click(object sender, EventArgs e)
        {
            //
            thepos_app_log(1, this.Name, "click toHome", "");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            //
            thepos_app_log(1, this.Name, "click toPrev", "");

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }


    }
}

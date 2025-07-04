using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static thepos2.ClsWin32Api;
using static thepos2.thepos;

namespace thepos2
{
    public partial class frmLogin : Form
    {
        TextBox mTbKeyDisplayController;  // 공용컨트롤러



        public frmLogin()
        {
            InitializeComponent();
            initialize_the();


            // 시작이 1회성 세팅. 이후 로그인 이후 다시 세팅

#if DEBUG
    mBaseUri = uri_test;
#else
    mBaseUri = uri_real;
#endif


            //
            thepos_app_log(2, "theposw2", "start...", "appVersion=" + mAppVersion + ", mac=" + mMacAddr);
        }



        private void initialize_the()
        {
            btnKey1.Click += (sender, args) => ClickedKey("1");
            btnKey2.Click += (sender, args) => ClickedKey("2");
            btnKey3.Click += (sender, args) => ClickedKey("3");
            btnKey4.Click += (sender, args) => ClickedKey("4");
            btnKey5.Click += (sender, args) => ClickedKey("5");
            btnKey6.Click += (sender, args) => ClickedKey("6");
            btnKey7.Click += (sender, args) => ClickedKey("7");
            btnKey8.Click += (sender, args) => ClickedKey("8");
            btnKey9.Click += (sender, args) => ClickedKey("9");
            btnKey0.Click += (sender, args) => ClickedKey("0");
            btnKeyBS.Click += (sender, args) => ClickedKey("BS");
            btnKeyClear.Click += (sender, args) => ClickedKey("Clear");

            mTbKeyDisplayController = tbID;


            try
            {
                // 기동시 MAC값 구하기 및 보관
                var nics = NetworkInterface.GetAllNetworkInterfaces();
                var selectedNic = nics.First();
                mMacAddr = selectedNic.GetPhysicalAddress().ToString();

            }
            catch
            {
                MessageBox.Show("기기 MAC 인식 불가.\r\n관리자에 요청바랍니다.", "thepos");
                return;
            }



            // Session key 로그인관련 
            handler.CookieContainer = cookies;
            mHttpClient = new HttpClient(handler);




        }




        private void ClickedKey(string sKey)
        {
            if (sKey == "BS")
            {
                if (mTbKeyDisplayController.Text.Length > 0)
                {
                    mTbKeyDisplayController.Text = mTbKeyDisplayController.Text.Substring(0, mTbKeyDisplayController.Text.Length - 1);
                }
            }
            else if (sKey == "Clear")
            {
                mTbKeyDisplayController.Text = "";
            }
            else
            {
                mTbKeyDisplayController.Text += sKey;
            }
        }


        private void btnKeyLogin_Click(object sender, EventArgs e)
        {
            mIsDevLogin = "";

            mIsTestPayMode = "";

            // 
            if (tbID.Text == "1120" & tbPW.Text == "4089")
            {
                // 개발자 전용 로그인
                frmDevAdmin frm2 = new frmDevAdmin();
                DialogResult ret = frm2.ShowDialog();

                if (ret == DialogResult.OK)  // Real
                {
                    //
                    mIsDevLogin = "Y";  // 개발자 로그인은 로그를 남기지 않기위해
                }
                else if (ret == DialogResult.Yes) // TEST
                {
                    //
                    mIsDevLogin = "Y";  // 개발자 로그인은 로그를 남기지 않기위해

                    //lblIsTest.Visible = true;
                    mIsTestPayMode = "Test";
                }
                else
                {
                    return;
                }

            }
            else
            {
                mBaseUri = uri_real;

                // 로그인
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters["userId"] = tbID.Text;
                parameters["userPw"] = SHA1HashCrypt(tbPW.Text);
                parameters["macAddr"] = mMacAddr;

                if (mRequestPost("login", parameters))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        mSiteId = mObj["siteId"].ToString();
                        mUserID = tbID.Text;
                        mUserName = mObj["userName"].ToString();
                        myPosNo = mObj["posNo"].ToString();
                        myShopCode = mObj["shopCode"].ToString();

                        //
                        thepos_app_log(2, this.Name, "login", "appVersion=" + mAppVersion + ", mac=" + mMacAddr);
                    }
                    else
                    {
                        String msg = mObj["resultMsg"].ToString();

                        //
                        thepos_app_log(3, this.Name, "login", "로그인오류. " + msg);

                        //
                        MessageBox.Show("로그인오류\n\n" + msg, "thepos");
                        return;
                    }
                }
                else
                {
                    //
                    thepos_app_log(3, this.Name, "login", "시스템오류. " + mErrorMsg);

                    //
                    MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                    return;
                }
            }


            //////////////////////////////////
            //? 개시마감 
            String biz_date = "";
            String biz_status = "";
            mBizDate = "";

            if (get_bizdate_status(ref biz_status, ref biz_date))
            {
                if (biz_status == "A")   // A영업중 F영업마감
                {
                    mBizDate = biz_date;

                    //
                    thepos_app_log(2,this.Name, "get_bizdate_status", "biz_status=" + biz_status + ", biz_date=" + biz_date);
                }
                else if (biz_status == "F" | biz_status == "Y")  // 마감 
                {
                    //? 개시화면으로 이동?

                    //
                    thepos_app_log(3, this.Name, "get_bizdate_status", "실패. 영업개시전입니다. 영업개시 입력후 다시 로그인바랍니다. biz_status=" + biz_status);

                    MessageBox.Show("영업개시전입니다.\n영업개시 입력후 다시 로그인바랍니다.", "thepos");
                    return;
                }
            }
            else
            {
                //
                thepos_app_log(3, this.Name, "get_bizdate_status", "실패. 개시마감관리 오류. 서버에서 정보를 읽어오지 못했습니다.");

                MessageBox.Show("개시마감관리 오류\n서버에서 정보를 읽어오지 못했습니다.", "thepos");
                return;
            }


            //
            sync_data_server_to_memory();


            // 쿠폰인증
            mHttpClientCoupon = new HttpClient();
            mHttpClientCoupon.DefaultRequestHeaders.TryAddWithoutValidation("authorization", mCouponMID);  // 최초 한번




            // 
            this.Hide();


            if (mKioskType.Equals("인증전용"))
            {
                frmCoupon frm = new frmCoupon();
                frm.ShowDialog();
            }
            else if (mKioskType.Equals("콤보"))
            {
                frmSalesCombo frm = new frmSalesCombo();
                frm.ShowDialog();
            }
            else
            {
                frmSalesMenu frm = new frmSalesMenu();
                frm.ShowDialog();
            }


            this.Close();


        }

        private void lblCallCenterNo_Click(object sender, EventArgs e)
        {
            frmSysAdminPos frm = new frmSysAdminPos();
            frm.ShowDialog();
        }

        private void tbID_Click(object sender, EventArgs e)
        {
            mTbKeyDisplayController = tbID;
        }

        private void tbPW_Click(object sender, EventArgs e)
        {
            mTbKeyDisplayController = tbPW;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //
            thepos_app_log(2, this.Name, "Close", "");

            this.Close();
        }

        private void btnPos_Click(object sender, EventArgs e)
        {
            frmSysAdminPos frm = new frmSysAdminPos();
            frm.ShowDialog();
        }

        private void btnReqSupport_Click(object sender, EventArgs e)
        {
            //
            thepos_app_log(1, this.Name, "call 원격지원", "");

            //원격지원
            System.Diagnostics.Process.Start("http://786.co.kr");
        }





    }
}

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
    public partial class frmDevAdmin : Form
    {
        public frmDevAdmin()
        {
            InitializeComponent();
        }

        private void btnLoginDev_Click(object sender, EventArgs e)
        {
            if (cbTest.Checked)
            {
                mBaseUri = uri_test;
                DialogResult = DialogResult.Yes;  // TEST
            }
            else
            {
                mBaseUri = uri_real;
                DialogResult = DialogResult.OK;  // REAL
            }


            // 로그인
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = tbSiteID.Text;
            parameters["posNo"] = tbPosNo.Text;

            if (mRequestPost("loginDev", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    mSiteId = mObj["siteId"].ToString();
                    mUserID = "";
                    mUserName = "";
                    mPosNo = mObj["posNo"].ToString();

                    //
                    thepos_app_log(1, this.Name, "login", "성공");

                    Close();
                }
                else
                {
                    //
                    thepos_app_log(2, this.Name, "login", "로그인오류. " + mObj["resultMsg"].ToString());
                    MessageBox.Show("로그인오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                }
            }
            else
            {
                //
                thepos_app_log(2, this.Name, "login", "로그인오류. " + mObj["resultMsg"].ToString());
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (cbTest.Checked)
            {
                mBaseUri = uri_test;
                DialogResult = DialogResult.Yes;  // TEST
            }
            else
            {
                mBaseUri = uri_real;
                DialogResult = DialogResult.OK;  // REAL
            }

            // 로그인
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["userId"] = tbSiteID.Text;
            parameters["userPw"] = SHA1HashCrypt(tbPosNo.Text);
            parameters["macAddr"] = mMacAddr;

            if (mRequestPost("login", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    mSiteId = mObj["siteId"].ToString();
                    mUserID = tbSiteID.Text;
                    mUserName = mObj["userName"].ToString();
                    mPosNo = mObj["posNo"].ToString();

                    //
                    thepos_app_log(1, this.Name, "login", "성공");
                }
                else
                {
                    //
                    thepos_app_log(2, this.Name, "login", "로그인오류. " + mObj["resultMsg"].ToString());

                    MessageBox.Show("로그인오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                //
                thepos_app_log(2, this.Name, "login", "시스템오류. " + mErrorMsg);

                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

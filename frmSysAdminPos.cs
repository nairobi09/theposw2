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
    public partial class frmSysAdminPos : Form
    {
        public frmSysAdminPos()
        {
            InitializeComponent();

            initialize_the();
        }

        private void initialize_the()
        {


        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (tbSiteId.Text.Length != 4)
            {
                MessageBox.Show("기관코드.(4자리)", "thepos");
                return;
            }


            if (tbPosNo.Text.Length < 2)
            {
                MessageBox.Show("포스번호 입력오류.(2자리)", "thepos");
                return;
            }


            // 사용자 등록 신청
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = tbSiteId.Text;
            parameters["posNo"] = tbPosNo.Text;
            parameters["macAddr"] = mMacAddr;
            parameters["posStatus"] = "0";
            parameters["initDt"] = get_today_date() + get_today_time();
            parameters["conCnt"] = "0";


            if (mRequestPost("pos", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    MessageBox.Show("포스기기등록신청완료\n\n" + "관리자의 인증심사 후 사용가능합니다.", "thepos");
                    return;
                }
                else
                {
                    MessageBox.Show("등록신청오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

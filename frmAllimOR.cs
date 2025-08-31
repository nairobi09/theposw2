using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static thepos.frmSalesMenu;
using static thepos.thepos;

namespace thepos
{
    public partial class frmAllimOR : Form
    {

        List<shop_order_pack> shopOrderPackList;

        public frmAllimOR(List<shop_order_pack> list)
        {
            InitializeComponent();

            if (mMobileExchangeType == "알림톡-선택")
            {
                btnNo.Visible = true;
            }

            shopOrderPackList = list;

        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < shopOrderPackList.Count; i++)
            {
                // 알림톡 발송
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters["siteId"] = mSiteId;
                parameters["posNo"] = myPosNo;
                parameters["bizDt"] = mBizDate;
                parameters["theNo"] = mTheNo;
                parameters["senderProfile"] = mAllimSenderProfile;
                parameters["allimType"] = "OR";
                parameters["allimTelNo"] = "010" + tbTelNo.Text.ToString();
                parameters["siteName"] = get_shop_name(shopOrderPackList[i].shop_code);
                parameters["orderDate"] = get_today_date();
                parameters["orderTime"] = get_today_time();
                parameters["orderNo"] = shopOrderPackList[i].order_no;
                parameters["shopCode"] = shopOrderPackList[i].shop_code;

                String is_allim = "";
                String t_detail = "\r\n";

                for (int j = 0; j < shopOrderPackList[i].orderPackList.Count; j++)
                {
                    if (shopOrderPackList[i].orderPackList[j].allim == "Y")
                    {
                        int len = encodelen(shopOrderPackList[i].orderPackList[j].goods_name + shopOrderPackList[i].orderPackList[j].goods_cnt);
                        t_detail += "    " + shopOrderPackList[i].orderPackList[j].goods_name + Space(30 - len) + shopOrderPackList[i].orderPackList[j].goods_cnt + "\r\n";

                        for (int k = 0; k < shopOrderPackList[i].orderPackList[j].option_name.Count; k++)
                        {
                            len = encodelen(shopOrderPackList[i].orderPackList[j].option_name[k] + shopOrderPackList[i].orderPackList[j].option_item_name[k]);
                            t_detail += "    " + "  - " + shopOrderPackList[i].orderPackList[j].option_name[k] + Space(30 - len) + shopOrderPackList[i].orderPackList[j].option_item_name[k] + "\r\n";
                        }

                        is_allim = "Y";
                    }
                }

                //
                if (is_allim == "Y")
                {
                    parameters["orderDetail"] = t_detail;

                    if (mRequestPost("allim", parameters))
                    {
                        if (mObj["resultCode"].ToString() == "200")
                        {

                        }
                        else
                        {
                            MessageBox.Show("오류 allim\n\n" + mObj["resultMsg"].ToString(), "thepos");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                        return;
                    }


                    // orderShop UPDATE
                    parameters.Clear();
                    parameters["siteId"] = mSiteId;
                    parameters["bizDt"] = mBizDate;
                    parameters["theNo"] = mTheNo;
                    parameters["shopOrderNo"] = shopOrderPackList[i].order_no;
                    parameters["orderAllimType"] = "AT";
                    parameters["orderAllimStatus"] = "0";   // 0주문 1알림전송 2완료
                    parameters["orderAllimMemo"] = tbTelNo.Text.ToString().Substring(4, 4);

                    if (mRequestPatch("orderShop", parameters))
                    {
                        if (mObj["resultCode"].ToString() == "200")
                        {
                        
                        }
                        else
                        {
                            MessageBox.Show("오류. orderItem\n\n" + mObj["resultMsg"].ToString(), "thepos");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("시스템오류. orderItem\n\n" + mErrorMsg, "thepos");
                        return;
                    }
                }    

            }


            this.Close();
        }


        private void btnKey1_Click(object sender, EventArgs e)
        {
            tbTelNo.Text += "1";
        }

        private void btnKey2_Click(object sender, EventArgs e)
        {
            tbTelNo.Text += "2";
        }

        private void btnKey3_Click(object sender, EventArgs e)
        {
            tbTelNo.Text += "3";
        }

        private void btnKey4_Click(object sender, EventArgs e)
        {
            tbTelNo.Text += "4";
        }

        private void btnKey5_Click(object sender, EventArgs e)
        {
            tbTelNo.Text += "5";
        }

        private void btnKey6_Click(object sender, EventArgs e)
        {
            tbTelNo.Text += "6";
        }

        private void btnKey7_Click(object sender, EventArgs e)
        {
            tbTelNo.Text += "7";
        }

        private void btnKey8_Click(object sender, EventArgs e)
        {
            tbTelNo.Text += "8";
        }

        private void btnKey9_Click(object sender, EventArgs e)
        {
            tbTelNo.Text += "9";
        }

        private void btnKey0_Click(object sender, EventArgs e)
        {
            tbTelNo.Text += "0";
        }

        private void btnKeyClear_Click(object sender, EventArgs e)
        {
            tbTelNo.Text = "";
        }

        private void btnKeyBS_Click(object sender, EventArgs e)
        {
            int len = tbTelNo.Text.Length;

            if (len > 0)
            {
                tbTelNo.Text = tbTelNo.Text.Substring(0, len - 1);
            }
        }

        
    }
}

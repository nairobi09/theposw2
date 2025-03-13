using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static thepos2.thepos;

namespace thepos2
{
    internal class couponPM
    {
        String PLACEM_URL = "https://gateway.sparo.cc/extra/kiosk/v1/";

        String sUrl = "";
        String rcode = "";
        String rmsg = "";
        String rcnt = "";




        public int requestPmCertView(String tNo)
        {
            mCertOrders.Clear();


            sUrl = PLACEM_URL + "req.php?pc=SS&pval=" + tNo + "&ch=" + mCouponChPM + "&fcno=" + mPosNo;

            try
            {
                var response = mHttpClient.GetAsync(sUrl).Result;

                var responseContent = response.Content;
                string responseString = responseContent.ReadAsStringAsync().Result;

                XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml(responseString);

                XmlNodeList nodes = xdoc.SelectNodes("/RESULT");
                foreach (XmlNode res in nodes)
                {
                    rcode = res.SelectSingleNode("RCODE").InnerText;
                    rmsg = res.SelectSingleNode("RMSG").InnerText;
                    rcnt = res.SelectSingleNode("RCNT").InnerText;
                }


                if (rcode == "E")
                {
                    MessageBox.Show(rmsg, "thepos");
                    return -1;
                }


                if (rcode != "S" | rcnt == "0")
                {
                    return -1;
                }


                nodes = xdoc.SelectNodes("/RESULT/ORDERS/ORDER");

                foreach (XmlNode order in nodes)
                {
                    CertOrder certOrder = new CertOrder();
                    
                    certOrder.order_no = order.SelectSingleNode("ORDERNO").InnerText;
                    certOrder.coupon_no = order.SelectSingleNode("COUPONNO").InnerText;
                    certOrder.menu_code = order.SelectSingleNode("MENUCODE").InnerText;
                    certOrder.menu_name = order.SelectSingleNode("MENUNAME").InnerText;
                    certOrder.qty = convert_number(order.SelectSingleNode("QTY").InnerText);
                    certOrder.exp_date = order.SelectSingleNode("EXPDATE").InnerText;
                    certOrder.state = order.SelectSingleNode("STATE").InnerText;
                    certOrder.ustate = order.SelectSingleNode("USTATE").InnerText;
                    certOrder.cus_nm = order.SelectSingleNode("CUSNM").InnerText;
                    certOrder.cus_hp = order.SelectSingleNode("CUSHP").InnerText;
                    certOrder.cus_opt = order.SelectSingleNode("CUSOPT").InnerText;


                    if (certOrder.state == "예약완료" & certOrder.ustate == "2" & certOrder.coupon_no == tNo)  // 2 미사용
                    {

                        certOrder.is_usage = "Y";

                        mCertOrders.Add(certOrder);
                    }


                }
            }
            catch (Exception ex)
            {
                mErrorMsg = ex.Message;
                return -1;
            }

            return 0;
        }




        public int requestPmCertAuth(String tCouponNo)
        {
            String sUrl = PLACEM_URL + "req.php?pc=US&pval=" + tCouponNo + "&ch=" + mCouponChPM + "&fcno=POS_" + mPosNo;

            try
            {
                var response = mHttpClient.GetAsync(sUrl).Result;

                var responseContent = response.Content;
                string responseString = responseContent.ReadAsStringAsync().Result;

                XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml(responseString);


                XmlNodeList nodes = xdoc.SelectNodes("/RESULT");
                foreach (XmlNode res in nodes)
                {
                    rcode = res.SelectSingleNode("RCODE").InnerText;
                    rmsg = res.SelectSingleNode("RMSG").InnerText;
                }


                if (rcode == "S")  // 성공
                {
                    return 0;
                }
                else
                {
                    MessageBox.Show("쿠폰사용요청 실패응답. \r\n\r\n" + rmsg, "thepos");
                    return -1;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("아래 메시지를 관리자에게 전달바랍니다. \r\n\r\n" + ex.Message, "시스템오류");
                return -1;
            }

        }



    }
}

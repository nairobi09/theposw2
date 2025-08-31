using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using thepos;
using static thepos.thepos;
using static thepos.frmPayManager;

namespace thepos
{
    public partial class frmPayCancel : Form
    {
        String the_no;
        String pos_no;
        String selected_biz_date;
        String pay_keep = "";

        int netAmount = 0;
        int cancelAmount = 0;
        int nestAmount = 0;

        bool is_apply = false;
        int select_idx;

        public frmPayCancel(String the_no, String pos_no, String selected_biz_date, String pay_keep, int select_idx)
        {
            InitializeComponent();
            initial_the();

            //
            thepos_app_log(1, this.Name, "Open", "");


            this.the_no = the_no;
            this.pos_no = pos_no;
            this.selected_biz_date = selected_biz_date;
            this.pay_keep = pay_keep;
            this.select_idx= select_idx;

            viewList();

        }

        private void frmPayCancel_Shown(object sender, EventArgs e)
        {
            if (pay_keep.Substring(4, 1) == "1")
            {
                // 테이블메니저 취소
                //MessageBox.Show("본 취소는 주문, 발권티켓 및 사용쿠폰의 취소를 실행합니다..", "쿠폰취소");
            }
        }


        private void initial_the()
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 30);
            lvwList.SmallImageList = imgList;
        }


        private void viewList()
        {
            netAmount = 0;
            cancelAmount = 0;
            nestAmount = 0;
            lvwList.Items.Clear();

            

            if (pay_keep.Substring(1, 1) == "1") // card
            {
                //
                String url = "paymentCard?siteId=" + mSiteId + "&bizDt=" + selected_biz_date + "&theNo=" + the_no + "&tranType=A";
                if (mRequestGet(url))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["paymentCards"].ToString();
                        add_listview(data);
                    }
                    else
                    {
                        //
                        thepos_app_log(3, this.Name, "viewList()", "결제 데이터 오류. paymentCard " + mObj["resultMsg"].ToString());

                        MessageBox.Show("결제 데이터 오류. paymentCard\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    }
                }
                else
                {
                    //
                    thepos_app_log(3, this.Name, "viewList()", "시스템오류. paymentCard " + mErrorMsg);

                    MessageBox.Show("시스템오류. paymentCard\n\n" + mErrorMsg, "thepos");
                }
            }




            nestAmount = netAmount - cancelAmount;

            lblNetAmount.Text = netAmount.ToString("N0");
            lblCancelAmount.Text = cancelAmount.ToString("N0");
            lblNestAmount.Text = nestAmount.ToString("N0");


            // 한건이면 선택한걸로
            if (lvwList.Items.Count == 1)
            {
                lvwList.Items[0].Selected = true;
            }



            //
            void add_listview(String data)
            {
                JArray arr = JArray.Parse(data);

                for (int i = 0; i < arr.Count; i++)
                {
                    ListViewItem lvItem = new ListViewItem();
                    lvItem.Tag = arr[i]["theNo"].ToString();

                    lvItem.SubItems.Add(get_MMddHHmm(arr[i]["payDate"].ToString(), arr[i]["payTime"].ToString()));
                    lvItem.SubItems.Add(get_pay_type_name(arr[i]["payType"].ToString()));
                    lvItem.SubItems.Add(convert_number(arr[i]["amount"].ToString()).ToString("N0"));


                    if (arr[i]["isCancel"].ToString() == "Y" | arr[i]["isCancel"].ToString() == "y")
                        lvItem.SubItems.Add("취소됨");
                    else if (arr[i]["isCancel"].ToString() == "0")
                        lvItem.SubItems.Add("취소중");
                    else
                        lvItem.SubItems.Add("");


                    lvItem.SubItems.Add(arr[i]["theNo"].ToString());
                    lvItem.SubItems.Add(arr[i]["payType"].ToString());


                    if (arr[i]["payType"].ToString() == "PA" | arr[i]["payType"].ToString() == "PD")
                        lvItem.Text = "1";
                    else
                        lvItem.Text = arr[i]["paySeq"].ToString();



                    if (arr[i]["isCancel"].ToString() == "Y" | arr[i]["isCancel"].ToString() == "y")
                    {
                        lvItem.ForeColor = Color.Gray;
                        lvItem.SubItems[1].ForeColor = Color.Gray;
                        lvItem.SubItems[2].ForeColor = Color.Gray;
                        lvItem.SubItems[3].ForeColor = Color.Gray;
                        lvItem.SubItems[4].ForeColor = Color.Gray;
                        lvItem.SubItems[5].ForeColor = Color.Gray;
                        lvItem.SubItems[6].ForeColor = Color.Gray;
                    }

                    lvwList.Items.Add(lvItem);

                    netAmount += convert_number(arr[i]["amount"].ToString());

                    if (arr[i]["isCancel"].ToString() == "Y" | arr[i]["isCancel"].ToString() == "y")
                    {
                        cancelAmount += convert_number(arr[i]["amount"].ToString()); 
                    }
                }
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count == 0) { return; }

            the_no = lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(theno)].Text.ToString();
            String pay_type = lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(paytype)].Text.ToString();
            int pay_seq = int.Parse(lvwList.SelectedItems[0].Text);
            int cancel_amt = convert_number(lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(amount)].Text.ToString().Replace(",",""));



            // 이창을 닫으면 기존화면의 목록을 갱신하기 위해서?
            int selected_idx = 0;


            if (lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(cc)].Text == "Y" | lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(cc)].Text == "취소됨")
            {
                return;  // 취소건, 취소된 승인건 - 제외
            }



            //
            btnCancel.Enabled = false;


            // 최종 마지막 취소건인지 

            String is_cancel_stat = "1";

            if (nestAmount == cancel_amt) is_cancel_stat = "Y";


            //
            if (pay_type == "C1" | pay_type == "C0")
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                PaymentCard pCardAuth = new PaymentCard();


                String sUrl = "paymentCard?siteId=" + mSiteId + "&bizDt=" + selected_biz_date + "&theNo=" + the_no + "&tranType=A&paySeq=" + pay_seq;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["paymentCards"].ToString();
                        JArray arr = JArray.Parse(data);

                        if (arr.Count == 1)
                        {
                            pCardAuth.site_id = arr[0]["siteId"].ToString();
                            pCardAuth.biz_dt = arr[0]["bizDt"].ToString();
                            pCardAuth.pos_no = arr[0]["posNo"].ToString();
                            pCardAuth.the_no = arr[0]["theNo"].ToString();
                            pCardAuth.ref_no = arr[0]["refNo"].ToString();

                            pCardAuth.pay_date = arr[0]["payDate"].ToString();
                            pCardAuth.pay_time = arr[0]["payTime"].ToString();
                            pCardAuth.pay_type = arr[0]["payType"].ToString();
                            pCardAuth.tran_type = arr[0]["tranType"].ToString();
                            pCardAuth.pay_class = arr[0]["payClass"].ToString();

                            pCardAuth.ticket_no = arr[0]["ticketNo"].ToString();
                            pCardAuth.pay_seq = convert_number(arr[0]["paySeq"].ToString());
                            pCardAuth.tran_date = arr[0]["tranDate"].ToString();
                            pCardAuth.amount = convert_number(arr[0]["amount"].ToString());
                            pCardAuth.install = arr[0]["install"].ToString();

                            pCardAuth.auth_no = arr[0]["authNo"].ToString();
                            pCardAuth.card_no = arr[0]["cardNo"].ToString();

                            pCardAuth.card_name = arr[0]["cardName"].ToString();
                            pCardAuth.isu_code = arr[0]["isuCode"].ToString();
                            pCardAuth.acq_code = arr[0]["acqCode"].ToString();
                            pCardAuth.merchant_no = arr[0]["merchantNo"].ToString();
                            pCardAuth.tran_serial = arr[0]["tranSerial"].ToString();

                            pCardAuth.is_cup = arr[0]["isCup"].ToString();

                            pCardAuth.tax_amount = 0;
                            pCardAuth.tfree_amount = 0;
                            pCardAuth.service_amount = 0;
                            pCardAuth.tax = 0;
                        }
                        else
                        {
                            //
                            thepos_app_log(3, this.Name, "btnCancel_Click()", "결제자료 오류. paymentCard");
                            MessageBox.Show("결제자료 오류. paymentCard\n\n", "thepos");
                            btnCancel.Enabled = true;
                            return;
                        }
                    }
                    else
                    {
                        //
                        thepos_app_log(3, this.Name, "btnCancel_Click()", "결제자료 오류. paymentCard" + mObj["resultMsg"].ToString());
                        MessageBox.Show("결제자료 오류. paymentCard\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        btnCancel.Enabled = true;
                        return;
                    }
                }
                else
                {
                    //
                    thepos_app_log(3, this.Name, "btnCancel_Click()", "시스템오류. paymentCard\n\n" + mErrorMsg);
                    MessageBox.Show("시스템오류. paymentCard\n\n" + mErrorMsg, "thepos");
                    btnCancel.Enabled = true;
                    return;
                }
                


                if (pCardAuth.pay_type == "C1")  // 카드결제취소
                {
                    //
                    PaymentCard pCardCancel = new PaymentCard();

                    if (requestCardCancel(pCardAuth, out pCardCancel) != 0)  // Toss process
                    {
                        MessageBox.Show(mErrorMsg, "thepos");
                        btnCancel.Enabled = true;
                        return;
                    }
                    else
                    {
                        cancel_orders(pay_seq, pCardAuth.amount);

                        cancel_payment(pay_seq, pCardAuth.amount, pay_type, is_cancel_stat);


                        parameters["siteId"] = mSiteId;
                        parameters["posNo"] = myPosNo;
                        parameters["bizDt"] = mBizDate;
                        parameters["theNo"] = pCardAuth.the_no;
                        parameters["refNo"] = pCardAuth.ref_no;
                        parameters["payDate"] = get_today_date();
                        parameters["payTime"] = get_today_time();
                        parameters["payType"] = "C1";       // 결제구분 : , 카드승인(C1), 임의등록(C0)
                        parameters["tranType"] = "C";       // 승인 A 취소 C
                        parameters["payClass"] = pCardAuth.pay_class;
                        parameters["ticketNo"] = pCardAuth.ticket_no;
                        parameters["paySeq"] = pCardAuth.pay_seq + "";
                        parameters["tranDate"] = pCardCancel.tran_date;
                        parameters["amount"] = pCardAuth.amount + "";
                        parameters["install"] = pCardAuth.install;
                        parameters["authNo"] = pCardCancel.auth_no;
                        parameters["cardNo"] = pCardCancel.card_no;
                        parameters["cardName"] = pCardCancel.card_name;
                        parameters["isuCode"] = pCardCancel.isu_code;
                        parameters["acqCode"] = pCardCancel.acq_code;
                        parameters["merchantNo"] = pCardCancel.merchant_no;
                        parameters["tranSerial"] = pCardCancel.tran_serial;     // tran_serial -> 취소시 tid입력
                        parameters["signPath"] = "";
                        parameters["giftChange"] = "";
                        parameters["isCancel"] = "Y";
                        parameters["vanCode"] = mVanCode;

                        if (mRequestPost("paymentCard", parameters))
                        {
                            if (mObj["resultCode"].ToString() == "200")
                            {
                                is_apply = true;
                            }
                            else
                            {
                                thepos_app_log(3, this.Name, "btnCancel_Click()", "오류 paymentCard " + mObj["resultMsg"].ToString());
                                //MessageBox.Show("오류 paymentCard\n\n" + mObj["resultMsg"].ToString(), "thepos");
                                //return;
                            }
                        }
                        else
                        {
                            thepos_app_log(3, this.Name, "btnCancel_Click()", "시스템오류 paymentCard. " + mErrorMsg);
                            //MessageBox.Show("시스템오류 paymentCard\n\n" + mErrorMsg, "thepos");
                            //return;
                        }



                        //! 승인건에 취소마킹
                        parameters.Clear();
                        parameters["siteId"] = mSiteId;
                        parameters["bizDt"] = selected_biz_date;
                        parameters["theNo"] = pCardAuth.the_no;
                        parameters["payType"] = "C1";
                        parameters["tranType"] = "A";
                        parameters["paySeq"] = pCardAuth.pay_seq + "";
                        parameters["isCancel"] = "Y";

                        if (mRequestPatch("paymentCard", parameters))
                        {
                            if (mObj["resultCode"].ToString() == "200")
                            {
                                is_apply = true;
                            }
                            else
                            {
                                thepos_app_log(3, this.Name, "btnCancel_Click()", "오류. paymentCash " + mObj["resultMsg"].ToString());
                                //MessageBox.Show("오류. paymentCash\n\n" + mObj["resultMsg"].ToString(), "thepos");
                                //return;
                            }
                        }
                        else
                        {
                            thepos_app_log(3, this.Name, "btnCancel_Click()", "시스템오류. paymentCash " + mErrorMsg);
                            //MessageBox.Show("시스템오류. paymentCash\n\n" + mErrorMsg, "thepos");
                            //return;
                        }

                        thepos_app_log(1, this.Name, "btnCancel_Click()", "카드결제 취소 성공");
                        //MessageBox.Show("카드결제 취소 성공", "thepos");
                    }
                }
                


                // 영수증인쇄
                if (is_cancel_stat == "Y")
                {
                    _print_bill(pCardAuth.the_no, "C", "", "01000", true);
                }

            }
            


            if (is_cancel_stat == "Y")
            {
                // 키오스크에서 주문서 제외 - 이후 필요시 다시 개발해야함.
                //print_cancel_order(the_no);
            }


            // 다시 불러오기
            if (is_apply == true)
            {
                viewList();
            }

            btnCancel.Enabled = true;

        }


        public static void _print_bill(String the_no, String tran_type, String except_order, String pay_keep, bool isQuestion)
        {
            String[] order_no_from_to = new String[2];

            order_no_from_to[0] = "";
            order_no_from_to[1] = "";

            print_bill(the_no, tran_type, except_order, pay_keep, isQuestion, order_no_from_to);
        }


        void cancel_orders(int pay_seq, int amount)
        {
            if (pay_seq != 1)  // 복합결제 취소인 경우 첫번째 건만
            {
                return;
            }


            // orders
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            // 승인건 취소 마킹
            parameters.Clear();
            parameters["siteId"] = mSiteId;
            parameters["bizDt"] = selected_biz_date;
            parameters["theNo"] = the_no;
            parameters["tranType"] = "A";
            parameters["isCancel"] = "Y";
            if (mRequestPatch("orders", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                }
                else
                {
                    MessageBox.Show("오류. orders\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. orders\n\n" + mErrorMsg, "thepos");
                return;
            }


            // orders 취소건 추가
            String sUrl = "orders?siteId=" + mSiteId + "&bizDt=" + selected_biz_date + "&theNo=" + the_no + "&tranType=A";
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["orders"].ToString();
                    JArray arr = JArray.Parse(data);

                    if (arr.Count == 1)
                    {
                        parameters.Clear();
                        parameters["siteId"] = mSiteId;
                        parameters["posNo"] = myPosNo;
                        parameters["bizDt"] = mBizDate;
                        parameters["theNo"] = the_no;
                        parameters["refNo"] = arr[0]["refNo"].ToString();
                        parameters["tranType"] = "C";
                        parameters["orderDate"] = get_today_date();
                        parameters["orderTime"] = get_today_time();
                        parameters["cnt"] = arr[0]["cnt"].ToString();
                        parameters["isCancel"] = "Y";
                        parameters["userId"] = mUserID;

                        if (mRequestPost("orders", parameters))
                        {
                            if (mObj["resultCode"].ToString() == "200")
                            {
                            }
                            else
                            {
                                MessageBox.Show("오류 order\n\n" + mObj["resultMsg"].ToString(), "thepos");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("주문자료 오류. orders\n\n", "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("주문자료 오류. orders\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. orders\n\n" + mErrorMsg, "thepos");
                return;
            }



            // orderShop 취소마킹 - 별도 취소건 추가는 없다.
            parameters.Clear();
            parameters["siteId"] = mSiteId;
            parameters["bizDt"] = selected_biz_date;
            parameters["theNo"] = the_no;
            parameters["isCancel"] = "Y";
            if (mRequestPatch("orderShop", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                }
                else
                {
                    MessageBox.Show("오류. orderShop\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. orderShop\n\n" + mErrorMsg, "thepos");
                return;
            }



            // orderItem


            // orderItem 승인건 취소마킹
            parameters.Clear();
            parameters["siteId"] = mSiteId;
            parameters["bizDt"] = selected_biz_date;
            parameters["theNo"] = the_no;
            parameters["isCancel"] = "Y";

            if (mRequestPatch("orderItem", parameters))
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



            // orderItem 취소건 추가
            sUrl = "orderItem?siteId=" + mSiteId + "&bizDt=" + selected_biz_date + "&theNo=" + the_no + "&tranType=A";
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["orderItems"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        parameters.Clear();
                        parameters["siteId"] = mSiteId;
                        parameters["posNo"] = myPosNo;
                        parameters["bizDt"] = mBizDate;
                        parameters["theNo"] = the_no;
                        parameters["refNo"] = arr[i]["refNo"].ToString();

                        parameters["tranType"] = "C";
                        parameters["orderDate"] = get_today_date();
                        parameters["orderTime"] = get_today_time();

                        parameters["goodsCode"] = arr[i]["goodsCode"].ToString();
                        parameters["goodsName"] = arr[i]["goodsName"].ToString();

                        parameters["cnt"] = arr[i]["cnt"].ToString();
                        parameters["amt"] = arr[i]["amt"].ToString();
                        parameters["optionAmt"] = arr[i]["optionAmt"].ToString();  // 

                        parameters["ticketYn"] = arr[i]["ticketYn"].ToString();
                        parameters["taxFree"] = arr[i]["taxFree"].ToString();
                        parameters["dcAmount"] = arr[i]["dcAmount"].ToString();

                        parameters["dcrType"] = arr[i]["dcrType"].ToString();
                        parameters["dcrDes"] = arr[i]["dcrDes"].ToString();
                        parameters["dcrValue"] = arr[i]["dcrValue"].ToString();

                        parameters["payClass"] = arr[i]["payClass"].ToString();
                        parameters["ticketNo"] = arr[i]["ticketNo"].ToString();

                        parameters["isCancel"] = "Y";
                        parameters["shopCode"] = arr[i]["shopCode"].ToString();
                        parameters["nodCode1"] = arr[i]["nodCode1"].ToString();
                        parameters["nodCode2"] = arr[i]["nodCode2"].ToString();

                        parameters["shopOrderNo"] = arr[i]["shopOrderNo"].ToString();
                        parameters["optionNo"] = arr[i]["optionNo"].ToString();

                        if (mRequestPost("orderItem", parameters))
                        {
                            if (mObj["resultCode"].ToString() == "200")
                            {
                            }
                            else
                            {
                                MessageBox.Show("오류 orderItem\n\n" + mObj["resultMsg"].ToString(), "thepos");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("주문자료 오류. orderItem\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. orderItem\n\n" + mErrorMsg, "thepos");
                return;
            }
            

            //?? 옵션항목이 있을경우만 취소요청을 해야하는데 구분하는 방법 - 서버에서 업데이트 항목이 0건이면 정상응답주기로 함.  20250422
            // orderOptionItem 승인건 취소마킹
            parameters.Clear();
            parameters["siteId"] = mSiteId;
            parameters["bizDt"] = selected_biz_date;
            parameters["theNo"] = the_no;
            parameters["isCancel"] = "Y";

            if (mRequestPatch("orderOptionItem", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {

                }
                else
                {
                    MessageBox.Show("오류. orderOptionItem\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. orderOptionItem\n\n" + mErrorMsg, "thepos");
                return;
            }
            
        }


        void cancel_payment(int pay_seq, int amount, String pay_type, String is_cancel)
        {
            // payment
            Payment paymentAuth = new Payment();

            if (get_payment("A", selected_biz_date,  the_no, out paymentAuth) == 1)  // 선택일자의 승인건
            {
                // 승인건 취소마킹
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Clear();
                parameters["siteId"] = mSiteId;
                parameters["bizDt"] = selected_biz_date;
                parameters["theNo"] = the_no;
                parameters["tranType"] = "A";

                if (netAmount == cancelAmount + amount)
                    parameters["isCancel"] = "Y";
                else
                    parameters["isCancel"] = "1";

                if (mRequestPatch("payment", parameters))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                    }
                    else
                    {
                        MessageBox.Show("오류. payment\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류. payment\n\n" + mErrorMsg, "thepos");
                    return;
                }
            }
            


            //
            Payment paymentCancel = new Payment();
            int c_cnt = get_payment("C", mBizDate, the_no, out paymentCancel);  // 오늘자의 취소건
            
            if (c_cnt == 0) 
            {
                int amount_cash = 0, amount_card = 0, amount_easy = 0, amount_point = 0, amount_cert = 0;
                String pay_type1 = pay_type.Substring(0, 1);

                if (pay_type1 == "R") amount_cash = amount;
                else if (pay_type1 == "C") amount_card = amount;
                else if (pay_type1 == "E") amount_easy = amount;
                else if (pay_type1 == "P") amount_point = amount;
                else if (pay_type1 == "M") amount_cert = amount;

                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Clear();
                parameters["siteId"] = mSiteId;
                parameters["bizDt"] = mBizDate;
                parameters["shopCode"] = myShopCode;
                parameters["posNo"] = myPosNo;
                parameters["theNo"] = paymentAuth.the_no;
                parameters["refNo"] = paymentAuth.ref_no;
                parameters["payDate"] = get_today_date();
                parameters["payTime"] = get_today_time();
                parameters["tranType"] = "C";
                parameters["payClass"] = paymentAuth.pay_class;
                parameters["billNo"] = paymentAuth.bill_no;

                parameters["netAmount"] = amount + "";
                parameters["amountCash"] = amount_cash + "";
                parameters["amountCard"] = amount_card + "";
                parameters["amountEasy"] = amount_easy + "";
                parameters["amountPoint"] = amount_point + "";

                parameters["isCash"] = paymentAuth.is_cash;
                parameters["isCard"] = paymentAuth.is_card;
                parameters["isEasy"] = paymentAuth.is_easy;
                parameters["isPoint"] = paymentAuth.is_point;
                parameters["isCert"] = paymentAuth.is_cert;

                parameters["dcAmount"] = paymentAuth.dc_amount + "";
                parameters["isCancel"] = is_cancel;
                if (mRequestPost("payment", parameters))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                    }
                    else
                    {
                        MessageBox.Show("오류 payment\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류 payment\n\n" + mErrorMsg, "thepos");
                    return;
                }
                
            }
            else if (c_cnt == 1) 
            {
                int t_net_amount = paymentCancel.net_amount + amount;
                int t_amount_cash = paymentCancel.amount_cash;
                int t_amount_card = paymentCancel.amount_card;
                int t_amount_easy = paymentCancel.amount_easy;
                int t_amount_point = paymentCancel.amount_point;

                String pay_type1 = pay_type.Substring(0, 1);

                if (pay_type1 == "R") t_amount_cash += amount;
                else if (pay_type1 == "C") t_amount_card += amount;
                else if (pay_type1 == "E") t_amount_easy += amount;
                else if (pay_type1 == "P") t_amount_point += amount;


                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Clear();
                parameters["siteId"] = mSiteId;
                parameters["bizDt"] = mBizDate;
                parameters["theNo"] = paymentAuth.the_no;
                parameters["tranType"] = "C";

                parameters["netAmount"] = t_net_amount.ToString();
                parameters["amountCash"] = t_amount_cash.ToString();
                parameters["amountCard"] = t_amount_card.ToString();
                parameters["amountEasy"] = t_amount_easy.ToString();
                parameters["amountPoint"] = t_amount_point.ToString();
                parameters["isCancel"] = is_cancel;
                if (mRequestPatch("payment", parameters))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                    }
                    else
                    {
                        MessageBox.Show("오류 payment\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류 payment\n\n" + mErrorMsg, "thepos");
                    return;
                }
                
            }

        }
        


        // //////////////////////////////////////////////////////////////////
        private int get_payment(String tran_type, String biz_date, String tho_no, out Payment payment)
        {
            payment = new Payment();

            String sUrl = "payment?siteId=" + mSiteId + "&bizDt=" + biz_date + "&theNo=" + tho_no + "&tranType=" + tran_type;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["payments"].ToString();
                    JArray arr = JArray.Parse(data);

                    if (arr.Count == 0)
                    {
                        return 0;
                    }
                    else if (arr.Count == 1)
                    {
                        payment.site_id = arr[0]["siteId"].ToString();
                        payment.biz_dt = arr[0]["bizDt"].ToString();
                        payment.shop_code = arr[0]["shopCode"].ToString();
                        payment.pos_no = arr[0]["posNo"].ToString();
                        payment.the_no = arr[0]["theNo"].ToString();
                        payment.ref_no = arr[0]["refNo"].ToString();

                        payment.pay_date = arr[0]["payDate"].ToString();
                        payment.pay_time = arr[0]["payTime"].ToString();
                        payment.tran_type = arr[0]["tranType"].ToString();
                        payment.pay_class = arr[0]["payClass"].ToString();
                        payment.bill_no = arr[0]["billNo"].ToString();

                        payment.net_amount = convert_number(arr[0]["netAmount"].ToString());
                        payment.amount_cash = convert_number(arr[0]["amountCash"].ToString());
                        payment.amount_card = convert_number(arr[0]["amountCard"].ToString());
                        payment.amount_easy = convert_number(arr[0]["amountEasy"].ToString());
                        payment.amount_point = convert_number(arr[0]["amountPoint"].ToString());
                        payment.amount_cert = convert_number(arr[0]["amountCert"].ToString());

                        payment.is_cash = arr[0]["isCash"].ToString();
                        payment.is_card = arr[0]["isCard"].ToString();
                        payment.is_easy = arr[0]["isEasy"].ToString();
                        payment.is_point = arr[0]["isPoint"].ToString();
                        payment.is_cert = arr[0]["isCert"].ToString();

                        payment.dc_amount = convert_number(arr[0]["dcAmount"].ToString());
                        payment.is_cancel = arr[0]["isCancel"].ToString();

                        return 1;
                    }
                    else
                    {
                        MessageBox.Show("오류. payment\n\n" + "arr.Count=" + arr.Count, "thepos");
                        return -1;
                    }
                }
                else
                {
                    MessageBox.Show("오류. payment\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return -1;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. payment\n\n" + mErrorMsg, "thepos");
                return -1;
            }

        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPayCancel_FormClosed(object sender, FormClosedEventArgs e)
        {

            // 취소action이 있었으면 manager화면의 갱신이 필요하다.
            if (is_apply == true)
            {
                reviewList(selected_biz_date, pos_no, the_no, select_idx);
            }
        }

        public static int requestCardCancel(PaymentCard pCardAuth, out PaymentCard pCardCancel)
        {
            int ret = 0;
            PaymentCard cardCancel = new PaymentCard();
            pCardCancel = cardCancel;

            if (mVanCode == "KCP")
            {
                paymentKCP p = new paymentKCP();
                ret = p.requestKcpCardCancel(pCardAuth, out pCardCancel);
            }
            else if (mVanCode == "NICE")
            {
                paymentNice p = new paymentNice();
                ret = p.requestNiceCardCancel(pCardAuth, out pCardCancel);
            }
            else if (mVanCode == "KOVAN")
            {
                paymentKovan p = new paymentKovan();
                ret = p.requestKovanCardCancel(pCardAuth, out pCardCancel);
            }



            return ret;
        }

        private void btnClose1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

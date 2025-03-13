using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static thepos2.thepos;
using static thepos2.frmSales;
using static thepos2.ClsWin32Api;

namespace thepos2
{
    public partial class frmPayCard : Form
    {
        int netAmount = 0;

        int t과세금액 = 0;
        int t면세금액 = 0;


        String[] mLangTitleArr = new string[4];
        String[] mLangAmountArr = new string[4];
        String[] mLangInstallArr = new string[4];
        String[] mLangMethodArr = new string[4];
        String[] mLangCreditArr = new string[4];
        String[] mLangCupArr = new string[4];
        String[] mLangOKArr = new string[4];
        String[] mLangCloseArr = new string[4];

        public frmPayCard(int net_amount, int r과세금액, int r면세금액, bool is_complex, int seq, bool is_last, int select_index)
        {
            InitializeComponent();

            initialize_the();

            lblTitle.Text = mLangTitleArr[mLanguageNo];
            lblAmountTitle.Text = mLangAmountArr[mLanguageNo];



            netAmount = net_amount;

            t과세금액 = r과세금액;
            t면세금액 = r면세금액;


            lblNetAmount.Text = "₩ " + netAmount.ToString("N0");


        }

        private void initialize_the()
        {

            mLangTitleArr[0] = "결제하기";
            mLangTitleArr[1] = "Payment";
            mLangTitleArr[2] = "決濟";
            mLangTitleArr[3] = "支払";

            mLangAmountArr[0] = "결제금액";
            mLangAmountArr[1] = "Price";
            mLangAmountArr[2] = "價格";
            mLangAmountArr[3] = "支払金額";

            mLangInstallArr[0] = "할부개월";
            mLangInstallArr[1] = "instalment";
            mLangInstallArr[2] = "割賦";
            mLangInstallArr[3] = "分割払い";

            mLangMethodArr[0] = "결제수단";
            mLangMethodArr[1] = "Mothod";
            mLangMethodArr[2] = "清算手段";
            mLangMethodArr[3] = "支払い方法";

            mLangCreditArr[0] = "신용카드 / 삼성페이";
            mLangCreditArr[1] = "Credit Card / Samsung Pay";
            mLangCreditArr[2] = "信用card / Samsung Pay";
            mLangCreditArr[3] = "クレジットカード / Samsung Pay";

            mLangCupArr[0] = "은련카드";
            mLangCupArr[1] = "UnionPay";
            mLangCupArr[2] = "UnionPay银联";
            mLangCupArr[3] = "UnionPay";

            mLangOKArr[0] = "결제";
            mLangOKArr[1] = "Pay";
            mLangOKArr[2] = "決濟";
            mLangOKArr[3] = "支払";

            mLangCloseArr[0] = "취소";
            mLangCloseArr[1] = "Close";
            mLangCloseArr[2] = "Close";
            mLangCloseArr[3] = "Close";



            lblTitle.Text = mLangTitleArr[mLanguageNo];
            lblAmountTitle.Text = mLangAmountArr[mLanguageNo];
            lblInstallTitle.Text = mLangInstallArr[mLanguageNo];
            lblMethodTitle.Text = mLangMethodArr[mLanguageNo];
            rbCredit.Text = mLangCreditArr[mLanguageNo];
            rbCUP.Text = mLangCupArr[mLanguageNo];


            btnPayRequest.Text = mLangOKArr[mLanguageNo];
            btnClose.Text = mLangCloseArr[mLanguageNo];



        }


        private void btnPayRequest_Click(object sender, EventArgs e)
        {
            String t할부 = "00";


            if (rbInstall03.Checked)
            {
                t할부 = "03";
            }
            else if (rbInstall06.Checked)
            {
                t할부 = "06";
            }
            else if (rbInstall12.Checked)
            {
                t할부 = "12";
            }


            String is_cup = "0";

            if (rbCUP.Checked == true) { is_cup = "1"; }


            //

            int tAmount = netAmount;    // 결제금액
            int tFreeAmount = 0;        // 면세금액
            int tTaxAmount = 0;         // 과세금액
            int tTax = 0;               // 세금
            int tServiceAmt = 0;
            int install = int.Parse(t할부);
            PaymentCard mPaymentCard = new PaymentCard();


            tTax = t과세금액 / 11;
            tTaxAmount = t과세금액 - tTax;
            tFreeAmount = t면세금액;




            // 리뷰시에만 별로로 마킹...
            /*
             * 
             * 

            if (requestCardAuth(tAmount, tFreeAmount, tTaxAmount, tTax, tServiceAmt, install, is_cup, out mPaymentCard) != 0)
            {
                add_thepos_log("Error", "requestCardAuth", mErrorMsg);
                MessageBox.Show(mErrorMsg, "thepos");
            }
            else
            {



            */

                //정상승인
                int order_cnt = 0;


                // 리스트뷰 -> 메모리배열 생성 : [ 업장코드로 정렬 + 업장주문번호 부여 ]
                set_shop_order_no_on_orderitem();


                // orders, orderItem 
                order_cnt = SaveOrder("");  // order. orderitem  ->  업장주문서 출력은 제외
                if (order_cnt == -1)
                {
                    return; // 재로그인 요구
                }


                //  payment
                if (!SavePayment(1, "Card", netAmount, 0))
                {
                    return;
                }

                // 서버저장 paymentCard
                mPaymentCard.site_id = mSiteId;
                mPaymentCard.biz_dt = mBizDate;
                mPaymentCard.pos_no = mPosNo;
                mPaymentCard.the_no = mTheNo;
                mPaymentCard.ref_no = mRefNo;
                mPaymentCard.pay_date = get_today_date();
                mPaymentCard.pay_time = get_today_time();
                mPaymentCard.pay_type = "C1";       // 결제구분 : , 카드결제(C1), 임의등록(C0)
                mPaymentCard.tran_type = "A";       // 승인 A 취소 C
                mPaymentCard.pay_class = mPayClass;
                mPaymentCard.ticket_no = "";
                mPaymentCard.pay_seq = 1;
                mPaymentCard.sign_path = "";
                mPaymentCard.is_cancel = "";
                mPaymentCard.van_code = mVanCode;
                mPaymentCard.is_cup = is_cup;

                // 밴에서 응답으로 받은건 payChannel 모듈에서 세팅
                if (!SavePaymentCard_Server(mPaymentCard))
                {
                    return;
                }


                // 주문서 출력
                String[] order_no_arr = print_order(ref shopOrderPackList);





                // 영수증 출력
                print_bill(mTheNo, "A", "", "01000", true, order_no_arr); // card


                DialogResult = DialogResult.OK;

                this.Close();

        /*
            }





        */



        }


        private bool SavePaymentCard_Server(PaymentCard mPaymentCard)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();


            try
            {
                parameters.Clear();
                parameters["siteId"] = mPaymentCard.site_id;
                parameters["posNo"] = mPaymentCard.pos_no;
                parameters["bizDt"] = mPaymentCard.biz_dt;
                parameters["theNo"] = mPaymentCard.the_no;
                parameters["refNo"] = mPaymentCard.ref_no;

                parameters["payDate"] = mPaymentCard.pay_date;
                parameters["payTime"] = mPaymentCard.pay_time;
                parameters["payType"] = mPaymentCard.pay_type;
                parameters["tranType"] = mPaymentCard.tran_type;
                parameters["payClass"] = mPaymentCard.pay_class;

                parameters["ticketNo"] = mPaymentCard.ticket_no;
                parameters["paySeq"] = mPaymentCard.pay_seq + "";
                parameters["tranDate"] = mPaymentCard.tran_date;
                parameters["amount"] = mPaymentCard.amount + "";
                parameters["taxAmount"] = mPaymentCard.tax_amount + "";

                parameters["freeAmount"] = mPaymentCard.tfree_amount + "";
                parameters["serviceAmt"] = mPaymentCard.service_amount + "";
                parameters["tax"] = mPaymentCard.tax + "";
                parameters["install"] = mPaymentCard.install;
                parameters["authNo"] = mPaymentCard.auth_no;

                parameters["cardNo"] = mPaymentCard.card_no;
                parameters["cardName"] = mPaymentCard.card_name;
                parameters["isuCode"] = mPaymentCard.isu_code;
                parameters["acqCode"] = mPaymentCard.acq_code;
                parameters["merchantNo"] = mPaymentCard.merchant_no;

                parameters["tranSerial"] = mPaymentCard.tran_serial;
                parameters["signPath"] = mPaymentCard.sign_path;
                parameters["giftChange"] = mPaymentCard.gift_change + "";
                parameters["isCancel"] = mPaymentCard.is_cancel;
                parameters["vanCode"] = mPaymentCard.van_code; ;
                parameters["isCup"] = mPaymentCard.is_cup;

                if (mRequestPost("paymentCard", parameters))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {

                    }
                    else
                    {
                        add_thepos_log("Error", "POST-1 paymentCard", mObj["resultMsg"].ToString());
                        MessageBox.Show("오류 paymentCard\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return false;
                    }
                }
                else 
                {
                    add_thepos_log("Error", "POST-2 paymentCard", mErrorMsg);
                    MessageBox.Show("시스템오류 paymentCard\n\n" + mErrorMsg, "thepos");
                    return false;
                }
            }
            catch (Exception e) 
            {
                add_thepos_log("Error", "CATCH POST paymentCard", e.Message);
                return false;
            }



            return true;

        }


        private static int requestCardAuth(int tAmount, int tFreeAmount, int tTaxAmount, int tTax, int tServiceAmt, int install, String is_cup, out PaymentCard mPaymentCard)
        {
            int ret = 0;


            PaymentCard mPaymentCard2 = new PaymentCard();

            if (mVanCode == "NICE")
            {
                paymentNice p = new paymentNice();
                ret = p.requestNiceCardAuth(tAmount, tFreeAmount, tTaxAmount, tTax, tServiceAmt, install, is_cup, out mPaymentCard2);
            }
            else if (mVanCode == "KCP")
            {
                paymentKCP p = new paymentKCP();
                ret = p.requestKcpCardAuth(tAmount, tFreeAmount, tTaxAmount, tTax, tServiceAmt, install, is_cup, out mPaymentCard2);
            }
            else if (mVanCode == "KOVAN")
            {
                paymentKovan p = new paymentKovan();
                ret = p.requestKovanCardAuth(tAmount, tFreeAmount, tTaxAmount, tTax, tServiceAmt, install, is_cup, out mPaymentCard2);
            }

            mPaymentCard = mPaymentCard2;

            return ret;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            this.Close();
        }


    }
}

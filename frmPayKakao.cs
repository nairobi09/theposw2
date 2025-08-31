using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static thepos.thepos;
using static thepos.frmSalesMenu;
using thepos;

namespace thepos
{
    public partial class frmPayKakao : Form
    {
        int netAmount = 0;

        int t과세금액 = 0;
        int t면세금액 = 0;


        public frmPayKakao(int net_amount, int r과세금액, int r면세금액, bool is_complex, int seq, bool is_last, int select_index)
        {
            InitializeComponent();

            initialize_the();

            netAmount = net_amount;

            t과세금액 = r과세금액;
            t면세금액 = r면세금액;


            lblNetAmount.Text = "₩ " + netAmount.ToString("N0");

        }


        private void initialize_the()
        {



        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbCouponScan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                String barcode_no = tbCouponScan.Text;
                tbCouponScan.Clear();

                if (barcode_no.Length < 3)
                {
                    thepos_app_log(3, this.Name, "scanner", "skip. coupon_no=" + barcode_no);
                    return;
                }

                if (barcode_no.Substring(0, 3) == "000")
                {
                    thepos_app_log(3, this.Name, "scanner", "skip. coupon_no=" + barcode_no);
                    return;
                }

                //
                int tAmount = netAmount;    // 결제금액
                int tFreeAmount = 0;        // 면세금액
                int tTaxAmount = 0;         // 과세금액
                int tTax = 0;               // 세금
                int tServiceAmt = 0;

                PaymentEasy mPaymentEasy = new PaymentEasy();


                tTax = t과세금액 / 11;
                tTaxAmount = t과세금액 - tTax;
                tFreeAmount = t면세금액;

                String is_kakaopay = "1";

                //
                if (requestEasyAuth(tAmount, tFreeAmount, tTaxAmount, tTax, tServiceAmt, barcode_no, is_kakaopay, out mPaymentEasy) != 0)
                {
                    //
                    thepos_app_log(3, this.Name, "requestEasyAuth()", mErrorMsg);

                    tpMessageBox tpMessageBox = new tpMessageBox("오류가 발생했습니다.\r\n" + mErrorMsg + "\r\n관리자에게 문의바랍니다.");
                    tpMessageBox.ShowDialog();
                    return;
                }



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
                if (!SavePayment(1, "Easy", netAmount, 0))
                {
                    return;
                }

                // 서버저장 paymentEasy
                mPaymentEasy.site_id = mSiteId;
                mPaymentEasy.biz_dt = mBizDate;
                mPaymentEasy.pos_no = myPosNo;
                mPaymentEasy.the_no = mTheNo;
                mPaymentEasy.ref_no = mRefNo;

                mPaymentEasy.pay_date = get_today_date();
                mPaymentEasy.pay_time = get_today_time();
                mPaymentEasy.pay_type = "E1";       // 결제구분 : , 간편결제(E1)
                mPaymentEasy.tran_type = "A";       // 승인 A 취소 C
                mPaymentEasy.pay_class = mPayClass;

                mPaymentEasy.ticket_no = "";
                mPaymentEasy.pay_seq = 1;
                mPaymentEasy.amount = netAmount;
                mPaymentEasy.sign_path = "";
                mPaymentEasy.is_cancel = "";
                mPaymentEasy.van_code = mVanCode;

                // 밴에서 응답으로 받은건 payChannel 모듈에서 세팅
                if (!SavePaymentEasy(mPaymentEasy))
                {
                    return;
                }



                // 티켓 저장/출력
                int ticket_cnt = SaveTicketFlow("", mPayClass, "", 0);



                // 주문서 출력
                String[] order_no_arr = print_order(ref shopOrderPackList);



                // 알림톡 발송
                if (mAllimYn == "Y")   // 알림톡 사용여부
                {
                    // 알림톡 보내기 위한 알림상품이 있는지 검사
                    String is_allim = "";

                    for (int i = 0; i < shopOrderPackList.Count; i++)
                    {
                        for (int j = 0; j < shopOrderPackList[i].orderPackList.Count; j++)
                        {
                            if (shopOrderPackList[i].orderPackList[j].allim == "Y")
                            {
                                is_allim = "Y";
                            }
                        }
                    }

                    if (is_allim == "Y")
                    {
                        frmAllimOR fAllim = new frmAllimOR(shopOrderPackList);
                        fAllim.ShowDialog();
                    }
                }


                // 영수증 출력
                print_bill(mTheNo, "A", "", "00010", true, order_no_arr); // easy


                DialogResult = DialogResult.OK;

                this.Close();

            }
        }

        private void tbCouponScan_Leave(object sender, EventArgs e)
        {
            tbCouponScan.Focus();
        }


        private static int requestEasyAuth(int tAmount, int tFreeAmount, int tTaxAmount, int tTax, int tServiceAmt, String barcode_no, String is_kakaoPay, out PaymentEasy mPaymentEasy)
        {
            int ret = 0;


            PaymentEasy mPaymentEasy2 = new PaymentEasy();

            if (mVanCode == "NICE")
            {
                paymentNice p = new paymentNice();
                ret = p.requestNiceEasyAuth(tAmount, tFreeAmount, tTaxAmount, tTax, tServiceAmt, barcode_no, out mPaymentEasy2);
            }
            else if (mVanCode == "KCP")
            {
                //
            }
            else if (mVanCode == "KOVAN")
            {
                //
            }
            else if (mVanCode == "TOSS")
            {
                //
            }

            mPaymentEasy = mPaymentEasy2;

            return ret;

        }


        private bool SavePaymentEasy(PaymentEasy mPaymentEasy)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Clear();
            parameters["siteId"] = mPaymentEasy.site_id;
            parameters["posNo"] = mPaymentEasy.pos_no;
            parameters["bizDt"] = mPaymentEasy.biz_dt;
            parameters["theNo"] = mPaymentEasy.the_no;
            parameters["refNo"] = mPaymentEasy.ref_no;

            parameters["payDate"] = mPaymentEasy.pay_date;
            parameters["payTime"] = mPaymentEasy.pay_time;
            parameters["payType"] = mPaymentEasy.pay_type;
            parameters["tranType"] = mPaymentEasy.tran_type;
            parameters["payClass"] = mPaymentEasy.pay_class;

            parameters["ticketNo"] = mPaymentEasy.ticket_no;
            parameters["paySeq"] = mPaymentEasy.pay_seq + "";
            parameters["tranDate"] = mPaymentEasy.tran_date;
            parameters["amount"] = mPaymentEasy.amount + "";

            parameters["authNo"] = mPaymentEasy.auth_no;
            parameters["cardNo"] = mPaymentEasy.card_no;
            parameters["cardName"] = mPaymentEasy.card_name;
            parameters["isuCode"] = mPaymentEasy.isu_code;
            parameters["acqCode"] = mPaymentEasy.acq_code;

            parameters["merchantNo"] = mPaymentEasy.merchant_no;
            parameters["tranSerial"] = mPaymentEasy.tran_serial;
            parameters["signPath"] = mPaymentEasy.sign_path;
            parameters["giftChange"] = mPaymentEasy.gift_change + "";
            parameters["isCancel"] = mPaymentEasy.is_cancel;
            parameters["vanCode"] = mPaymentEasy.van_code;
            parameters["payType2"] = mPaymentEasy.pay_type2;
            parameters["barcodeNo"] = mPaymentEasy.barcode_no;

            if (mRequestPost("paymentEasy", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {

                }
                else
                {
                    //
                    thepos_app_log(3, this.Name, "SavePaymentEasy()", "오류 paymentEasy " + mObj["resultMsg"].ToString());

                    MessageBox.Show("오류 paymentEasy\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return false;
                }
            }
            else
            {
                //
                thepos_app_log(3, this.Name, "SavePaymentEasy()", "시스템오류 paymentEasy " + mErrorMsg);

                MessageBox.Show("시스템오류 paymentEasy\n\n" + mErrorMsg, "thepos");
                return false;
            }

            return true;

        }
    }
}

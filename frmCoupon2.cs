using BrightIdeasSoftware;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using theposw2;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static thepos2.thepos;
using static thepos2.frmSales;

namespace thepos2
{

    public partial class frmCoupon2 : Form
    {
        public struct coupon
        {
            public String is_pass;
            public String image_ticket;
            public String coupon_no;
            public String coupon_name;
            public int coupon_cnt;
            public int coupon_amt;
            public String ustate_code;
            public String ustate_name;
            public String coupon_link_no;
            public String coupon_bar;
            public String coupon_description;

            public String goods_name;
            public int goods_amt;

        }
        public List<coupon> mCouponItemList = new List<coupon>();

        
        int link_goods_idx = -1;


        public frmCoupon2(JObject mObj)
        {
            InitializeComponent();


            //
            thepos_app_log(1, this.Name, "Open", "");



            String data = mObj["info"].ToString();
            JObject info = JObject.Parse(data);

            string coupon_no = info["barcode_no"].ToString();
            string ustate_code = info["ustate"].ToString();
            string coupon_name = info["cusitem"].ToString();
            string coupon_link_no = info["cusitemId"].ToString();   // 상품코드 매칭용   TM + 0000
            string qty = "1";
            string cus_nm = info["cusnm"].ToString();
            string cus_hp = info["cushp"].ToString();
            string exp_date = info["expdate"].ToString();
            string state = info["state"].ToString();
            string ch_name = info["cuschnm"].ToString();


            // (0:취소 1: 사용, 2: 미사용)
            String ustate_name = "";
            if (ustate_code == "2")
                ustate_name = "사용가능";
            else if (ustate_code == "1")
                ustate_name = "기사용티켓";
            else if (ustate_code == "0")
                ustate_name = "취소티켓";
            else
                ustate_name = "";


            //
            this.coupon_bar.Renderer = rendererCoupon();


            // 쿠폰 -> 상품 매칭
            for (int i = 0; i < mGoodsItem.Length; i++)
            {
                if (coupon_link_no == mGoodsItem[i].coupon_link_no)
                {
                    link_goods_idx = i;
                }
            }


            String is_pass = "";
            int goods_amt = 0;
            String goods_name = "";

            if (link_goods_idx == -1)
            {
                is_pass = "N";
                goods_amt = 0;
                goods_name = "[쿠폰사용 불가]";

                //
                thepos_app_log(2, this.Name, "상품매칭못함", "[쿠폰사용 불가] coupon_link_no=" + coupon_link_no);

            }
            else
            {
                // 정상
                is_pass = "Y";
                goods_amt = mGoodsItem[link_goods_idx].amt;
                goods_name = mGoodsItem[link_goods_idx].goods_name[0];
            }

            
            coupon couponItem = new coupon();
            couponItem.is_pass = is_pass;  // 매칭상품코드 찾기
            couponItem.coupon_no = coupon_no;
            couponItem.coupon_name = coupon_name;
            couponItem.coupon_cnt = 1;
            couponItem.coupon_amt = 0;
            couponItem.ustate_code = ustate_code;
            couponItem.ustate_name = ustate_name;
            couponItem.coupon_link_no = coupon_link_no;
            couponItem.goods_amt = goods_amt;
            couponItem.goods_name = goods_name;
            couponItem.coupon_bar = goods_name + " / @" + goods_amt + " / " + couponItem.coupon_cnt;
            couponItem.coupon_description = ustate_name + " / " + coupon_no + " / " + coupon_name + " / " + exp_date;


            if (is_pass == "Y")
            {
                if (ustate_code != "2")
                {
                    couponItem.image_ticket = "ticket_off";
                }
                else
                {
                    couponItem.image_ticket = "ticket_on";
                }
            }
            else
            {
                couponItem.image_ticket = "ticket_off";
            }

            mCouponItemList.Add(couponItem);
            lvwCoupon.SetObjects(mCouponItemList);


            //
            timerHome_reset();



        }


        public DescribedTaskRenderer rendererCoupon()
        {
            DescribedTaskRenderer renderer = new DescribedTaskRenderer();
            renderer.DescriptionAspectName = "coupon_description";

            renderer.TitleFont = new Font(lvwCoupon.Font.FontFamily, 24, FontStyle.Bold);
            renderer.DescriptionFont = new Font(lvwCoupon.Font.FontFamily, 13, FontStyle.Regular);
            renderer.DescriptionColor = Color.Blue;

            renderer.ImageTextSpace = 0;
            renderer.TitleDescriptionSpace = 0;

            renderer.UseGdiTextRendering = false;

            return (renderer);
        }


        private void btnOK_Click(object sender, EventArgs e)
        {

            //
            timerHome_reset();


            if (mCouponItemList.Count == 0)
            {
                return;
            }

            if (mCouponItemList[0].ustate_code != "2")  // 2 사용가능 
            {
                //
                thepos_app_log(1, this.Name, "btnOK", "이쿠폰은 사용할 수 없습니다.");

                tpMessageBox tpMessageBox = new tpMessageBox("이쿠폰은 사용할 수 없습니다.");
                tpMessageBox.ShowDialog();
                return;
            }

            if (mCouponItemList[0].is_pass != "Y")
            {
                //
                thepos_app_log(1, this.Name, "btnOK", "쿠폰에 해당하는 상품정보를 찾을수 없습니다. 관리자 문의 바랍니다.");

                tpMessageBox tpMessageBox = new tpMessageBox("쿠폰에 해당하는 상품정보를 찾을수 없습니다.\r\n관리자 문의 바랍니다.");
                tpMessageBox.ShowDialog();
                return;
            }



            string t_ustate_code = mCouponItemList[0].ustate_code;
            string t_coupon_no = mCouponItemList[0].coupon_no;
            String t_coupon_link_no = mCouponItemList[0].coupon_link_no;


            //
            couponTM p = new couponTM();
            int ret = p.requestPmCertAuth(t_coupon_no);

            if (ret == 0)
            {
                if (mObj["result"].ToString() == "1000")
                {
                    // 
                    order_pay_cert(t_coupon_no, link_goods_idx);


                    // 타이머 중지
                    timerHome.Enabled = false;


                    //
                    frmCoupon3 frm = new frmCoupon3();
                    frm.ShowDialog();

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    //
                    thepos_app_log(2, this.Name, "requestPmCertAuth()", "오류" + mObj["msg"].ToString());

                    tpMessageBox tpMessageBox = new tpMessageBox("오류\n\n" + mObj["msg"].ToString());
                    tpMessageBox.ShowDialog();
                    return;
                }
            }
            else
            {
                //
                thepos_app_log(2, this.Name, "requestPmCertAuth()", mErrorMsg);

                tpMessageBox tpMessageBox = new tpMessageBox(mErrorMsg);
                tpMessageBox.ShowDialog();
                return;
            }
        }

        private void order_pay_cert(string t_coupon_no, int link_goods_idx)
        {
            //
            String ticketNo = "";
            int order_cnt = 1;
            int mNetAmount = 0;

            //
            // 옵션항목 목록: frmOrderOption에서 채운다.
            mOrderOptionItemList.Clear();


            MemOrderItem orderItem = new MemOrderItem();

            orderItem.option_name_description = "";   // 리스트뷰 상품항목 아랫줄에 표시
            orderItem.option_amt_description = "";    // 리스트뷰 단가항목 아랫줄에 표시

            orderItem.option_item_cnt = mOrderOptionItemList.Count;
            orderItem.option_no = "";
            orderItem.orderOptionItemList = mOrderOptionItemList.ToList();  // ToList() : 리스트 복사, 참조가 아니고..

            orderItem.order_no = mOrderItemList.Count + 1;
            orderItem.goods_code = mGoodsItem[link_goods_idx].goods_code.ToString();
            orderItem.goods_name = mGoodsItem[link_goods_idx].goods_name[0];
            orderItem.ticket = mGoodsItem[link_goods_idx].ticket;
            orderItem.taxfree = mGoodsItem[link_goods_idx].taxfree;
            orderItem.allim = mGoodsItem[link_goods_idx].allim;

            orderItem.cnt = order_cnt;
            orderItem.amt = mGoodsItem[link_goods_idx].amt;
            //orderItem.option_amt    // 위에서 세팅

            orderItem.dcr_type = "";
            orderItem.dcr_des = "";
            orderItem.dcr_value = 0;
            orderItem.shop_code = mGoodsItem[link_goods_idx].shop_code;

            orderItem.coupon_no = t_coupon_no;


            //
            //replace_mem_order_item(ref orderItem, "add");

            mOrderItemList.Add(orderItem);


            mNetAmount = orderItem.cnt * orderItem.amt;



            //
            countup_the_no();


            int dcAmount = 0;

            set_shop_order_no_on_orderitem(out dcAmount);


            // orders, orderItem 
            order_cnt = SaveOrder(ticketNo);  // order. orderitem  ->  업장주문서 출력은 제외
            if (order_cnt == -1)
            {
                return; // 재로그인 요구
            }


            //  payment
            if (!SavePayment(1, "Cert", mNetAmount, dcAmount))
            {
                return;
            }


            PaymentCert mPaymentCert = new PaymentCert();
            mPaymentCert.site_id = mSiteId;
            mPaymentCert.biz_dt = mBizDate;
            mPaymentCert.pos_no = mPosNo;
            mPaymentCert.the_no = mTheNo;
            mPaymentCert.ref_no = mRefNo; // 

            mPaymentCert.pay_date = get_today_date();
            mPaymentCert.pay_time = get_today_time();
            mPaymentCert.pay_type = "M0";       // 결제구분 : 쿠폰인증(M0)
            mPaymentCert.tran_type = "A";       // 승인 A 취소 C
            mPaymentCert.pay_class = mPayClass;

            mPaymentCert.ticket_no = ticketNo;
            mPaymentCert.pay_seq = 1; // 
            mPaymentCert.tran_date = get_today_date() + get_today_time();
            mPaymentCert.amount = mNetAmount;    // 결제금액
            mPaymentCert.coupon_no = mOrderItemList[0].coupon_no;   //?  쿠폰인증 멀티 발권가능하도록 할것인가?
            mPaymentCert.is_cancel = "";         // 취소여부
            mPaymentCert.van_code = "TM";        // TM : 테이블메니저
            mPaymentCert.cnt = mOrderItemList[0].cnt;
            mPaymentCert.coupon_link_no = mCouponItemList[0].coupon_link_no;

            // 결제 항목 저장
            if (!SavePaymentCert(mPaymentCert))
            {
                return;
            }



            int settel_amt = mNetAmount;


            // 티켓 저장
            int ticket_cnt = SaveTicketFlow(ticketNo, mPayClass, "US", settel_amt);

            if (ticket_cnt > 0)
            {

            }


            // 주문서 출력 : 업장용 + 고객용
            // 주문서 출력
            String[] order_no_from_to = new String[2];

            order_no_from_to[0] = "";
            order_no_from_to[1] = "";


            List<shop_order_pack> shopOrderPackList = new List<shop_order_pack>();

            order_no_from_to = print_order(ref shopOrderPackList);


            // 영수증 출력
            //print_bill(mTheNo, "A", "", "00001", true, order_no_from_to); // cert



            //
            mOrderItemList.Clear();
            lvwCoupon.SetObjects(mOrderItemList);
        }


        private bool SavePaymentCert(PaymentCert mPaymentCert)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Clear();
            parameters["siteId"] = mPaymentCert.site_id;
            parameters["posNo"] = mPaymentCert.pos_no;
            parameters["bizDt"] = mPaymentCert.biz_dt;
            parameters["theNo"] = mPaymentCert.the_no;
            parameters["refNo"] = mPaymentCert.ref_no;

            parameters["payDate"] = mPaymentCert.pay_date;
            parameters["payTime"] = mPaymentCert.pay_time;
            parameters["payType"] = mPaymentCert.pay_type;
            parameters["tranType"] = mPaymentCert.tran_type;
            parameters["payClass"] = mPaymentCert.pay_class;

            parameters["ticketNo"] = mPaymentCert.ticket_no;
            parameters["paySeq"] = mPaymentCert.pay_seq + "";
            parameters["tranDate"] = mPaymentCert.tran_date;
            parameters["amount"] = mPaymentCert.amount + "";

            parameters["couponNo"] = mPaymentCert.coupon_no;
            parameters["isCancel"] = mPaymentCert.is_cancel;
            parameters["vanCode"] = mPaymentCert.van_code;

            parameters["couponLinkNo"] = mPaymentCert.coupon_link_no;
            parameters["cnt"] = mPaymentCert.cnt + "";

            if (mRequestPost("paymentCert", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {

                }
                else
                {
                    tpMessageBox tpMessageBox = new tpMessageBox("오류 paymentCert\n\n" + mObj["resultMsg"].ToString());
                    tpMessageBox.ShowDialog();
                    return false;
                }
            }
            else
            {
                tpMessageBox tpMessageBox = new tpMessageBox("시스템오류 paymentCert\n\n" + mErrorMsg);
                tpMessageBox.ShowDialog();
                return false;
            }

            return true;

        }


        private void set_shop_order_no_on_orderitem(out int dcAmount)
        {
            dcAmount = 0;

            List<String> shop_code_list = new List<String>();
            List<String> order_no_list = new List<String>();


            for (int i = 0; i < mOrderItemList.Count; i++)
            {
                if (mOrderItemList[i].dcr_des != "E")  // 키오스크는 전체할인이 없지만...
                {
                    shop_code_list.Add(mOrderItemList[i].shop_code);
                }

                dcAmount += mOrderItemList[i].dc_amount;
            }

            //#  이거때문에 주문번호가 시리얼하지않고 중간에 빈다. 2024-03-07
            //shop_code_list.Distinct().ToList();
            shop_code_list = shop_code_list.Distinct().ToList();


            for (int i = 0; i < shop_code_list.Count; i++)
            {
                order_no_list.Add(get_new_order_no());
            }


            for (int i = 0; i < mOrderItemList.Count; i++)
            {
                for (int k = 0; k < order_no_list.Count; k++)
                {
                    if (mOrderItemList[i].shop_code == shop_code_list[k])
                    {
                        MemOrderItem orderItem = mOrderItemList[i];
                        orderItem.shop_order_no = order_no_list[k];
                        mOrderItemList[i] = orderItem;
                    }
                }
            }
        }

        private static String get_new_order_no()
        {
            String order_no = "";


            String sUrl = "orderNo?siteId=" + mSiteId + "&bizDt=" + mBizDate;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["orderNo"].ToString();
                    JArray arr = JArray.Parse(data);
                    order_no = convert_number(arr[0]["orderNo"].ToString()).ToString("0000");
                }
                else
                {
                    tpMessageBox tpMessageBox = new tpMessageBox("데이터 오류. orderNo\n\n" + mObj["resultMsg"].ToString());
                    tpMessageBox.ShowDialog();
                }
            }
            else
            {
                tpMessageBox tpMessageBox = new tpMessageBox("시스템오류. orderNo\n\n" + mErrorMsg);
                tpMessageBox.ShowDialog();
            }


            //
            return order_no;
        }


        private void btnHome_Click(object sender, EventArgs e)
        {
            //
            thepos_app_log(1, this.Name, "click toHome", "");

            timerHome.Enabled = false;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            //
            thepos_app_log(1, this.Name, "click toPrev", "");

            timerHome.Enabled = false;

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }


        private void timerHome_Tick(object sender, EventArgs e)
        {
            //
            thepos_app_log(1, this.Name, "timeout toHome", "");

            timerHome.Enabled = false;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void timerHome_reset()
        {
            timerHome.Enabled = false;
            timerHome.Enabled = true;
            timerHome.Interval = 1000 * mWaitingSecond;
        }
    }
}

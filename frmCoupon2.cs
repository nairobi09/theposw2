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
using System.Reflection;

namespace thepos2
{

    public partial class frmCoupon2 : Form
    {
        public struct coupon
        {
            public String is_pass;
            public String image_checked;
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

            public int link_goods_idx;

            public String result;

        }
        public List<coupon> mCouponItemList = new List<coupon>();

        



        public frmCoupon2(JObject mObj)
        {
            InitializeComponent();


            //
            thepos_app_log(1, this.Name, "Open", "");



            String data = mObj["info"].ToString();
            JArray info = JArray.Parse(data);

            for (int i = 0; i < info.Count; i++)
            {

                string coupon_no = info[i]["barcode_no"].ToString();
                string ustate_code = info[i]["ustate"].ToString();
                string coupon_name = info[i]["cusitem"].ToString();
                string coupon_link_no = info[i]["cusitemId"].ToString();   // 상품코드 매칭용   TM + 0000
                string qty = "1";
                string cus_nm = info[i]["cusnm"].ToString();
                string cus_hp = info[i]["cushp"].ToString();
                string exp_date = info[i]["expdate"].ToString();
                string state = info[i]["state"].ToString();
                string ch_name = info[i]["cuschnm"].ToString();


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
                int link_goods_idx = -1;

                for (int k = 0; k < mGoodsItem.Length; k++)
                {
                    if (coupon_link_no == mGoodsItem[k].coupon_link_no)
                    {
                        link_goods_idx = k;
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
                couponItem.link_goods_idx = link_goods_idx;


                if (is_pass == "Y")
                {
                    if (ustate_code != "2")
                    {
                        couponItem.image_checked = "checked_off";

                    }
                    else
                    {
                        couponItem.image_checked = "checked_on";
                    }
                }
                else
                {
                    couponItem.image_checked = "checked_off";
                }


                thepos_app_log(1, this.Name, "쿠폰조회", couponItem.coupon_bar + " " + couponItem.coupon_description);

                mCouponItemList.Add(couponItem);
            }

            lvwCoupon.SetObjects(mCouponItemList);

        }


        public DescribedTaskRenderer rendererCoupon()
        {
            DescribedTaskRenderer renderer = new DescribedTaskRenderer();
            renderer.DescriptionAspectName = "coupon_description";

            renderer.TitleFont = new Font(lvwCoupon.Font.FontFamily, 20, FontStyle.Bold);
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
            thepos_app_log(1, this.Name, "btnOK", "");


            if (mCouponItemList.Count == 0)
            {
                return;
            }


            int checked_cnt = 0;

            for (int i = 0; i < mCouponItemList.Count; i++)
            {
                if (mCouponItemList[i].image_checked == "checked_on")
                {
                    checked_cnt++;
                }
            }

            if (checked_cnt == 0)
            {
                return;
            }





            for (int i = 0; i < mCouponItemList.Count; i++)
            {
                if (mCouponItemList[i].image_checked == "checked_on")
                {
                    
                    string t_coupon_no = mCouponItemList[i].coupon_no;



                    /*

                    coupon cp = mCouponItemList[i];
                    cp.result = "1";                    // 인증사용 OK
                    mCouponItemList[i] = cp;


                    */


                    couponTM p = new couponTM();
                    int ret = p.requestTmCertAuth(t_coupon_no);
                    if (ret == 0)
                    {
                        if (mObj["result"].ToString() == "1000")
                        {
                            //
                            thepos_app_log(1, this.Name, "requestTmCertAuth()", "정상. coupon_no=" + t_coupon_no);

                            coupon cp = mCouponItemList[i];
                            cp.result = "1";                    // 인증사용 OK
                            mCouponItemList[i] = cp;

                        }
                        else
                        {
                            String msg = mObj["msg"].ToString();
                            //
                            thepos_app_log(3, this.Name, "requestTmCertAuth()", "오류 " + msg + " coupon_no=" + t_coupon_no);

                        }
                    }
                    else
                    {
                        //
                        thepos_app_log(3, this.Name, "requestTmCertAuth()", mErrorMsg);
                    }


                }
            }


            //
            bool isExist = false;
            for (int i = 0; i < mCouponItemList.Count; i++)
            {
                if (mCouponItemList[i].result == "1")
                {
                    isExist = true;
                }
            }

            if (!isExist)
            {
                return;
            }



            order_pay_cert();


            //
            frmCoupon3 frm = new frmCoupon3();
            frm.ShowDialog();

            this.DialogResult = DialogResult.OK;
            this.Close();



        }

        private void order_pay_cert()
        {
            //
            countup_the_no();

            mOrderItemList.Clear();

            int mNetAmount = 0;

            for (int i = 0; i < mCouponItemList.Count; i++)
            {
                if (mCouponItemList[i].result != "1")
                {
                    continue;
                }


                int link_goods_idx = mCouponItemList[i].link_goods_idx;

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

                orderItem.cnt = mCouponItemList[i].coupon_cnt;
                orderItem.amt = mGoodsItem[link_goods_idx].amt;
                //orderItem.option_amt    // 위에서 세팅
                orderItem.dcr_type = "";
                orderItem.dcr_des = "";
                orderItem.dcr_value = 0;
                orderItem.shop_code = mGoodsItem[link_goods_idx].shop_code;
                orderItem.nod_code1 = mGoodsItem[link_goods_idx].nod_code1;
                orderItem.nod_code2 = mGoodsItem[link_goods_idx].nod_code2;
                orderItem.coupon_no = mCouponItemList[i].coupon_no;
                mOrderItemList.Add(orderItem);

                mNetAmount += orderItem.cnt * orderItem.amt;

            }

            
            if (mSiteId == "2501")  //  동춘
            {
                // 1장씩 인증받았지만 동일상품이면 묶는다.
                get_order_grouping_goods();  // mOrderItemList
            }
            




            int order_cnt = 0;
            int dcAmount = 0;

            set_shop_order_no_on_orderitem(out dcAmount);


            // orders, orderItem 
            order_cnt = SaveOrder("");  // order. orderitem  ->  업장주문서 출력은 제외
            if (order_cnt == -1)
            {
                return; // 재로그인 요구
            }


            //  payment
            if (!SavePayment(1, "Cert", mNetAmount, dcAmount))
            {
                return;
            }



            for (int i = 0; i < mCouponItemList.Count; i++)
            {
                if (mCouponItemList[i].result != "1")
                {
                    continue;
                }

                PaymentCert mPaymentCert = new PaymentCert();
                mPaymentCert.site_id = mSiteId;
                mPaymentCert.biz_dt = mBizDate;
                mPaymentCert.pos_no = myPosNo;
                mPaymentCert.the_no = mTheNo;
                mPaymentCert.ref_no = mRefNo; // 

                mPaymentCert.pay_date = get_today_date();
                mPaymentCert.pay_time = get_today_time();
                mPaymentCert.pay_type = "M0";       // 결제구분 : 쿠폰인증(M0)
                mPaymentCert.tran_type = "A";       // 승인 A 취소 C
                mPaymentCert.pay_class = mPayClass;

                mPaymentCert.ticket_no = mTheNo;
                mPaymentCert.pay_seq = i;           //
                mPaymentCert.tran_date = get_today_date() + get_today_time();
                mPaymentCert.amount = mCouponItemList[i].goods_amt;    // 결제금액
                mPaymentCert.coupon_no = mCouponItemList[i].coupon_no;   //?  쿠폰인증 멀티 발권가능하도록 할것인가?
                mPaymentCert.is_cancel = "";         // 취소여부
                mPaymentCert.van_code = "TM";        // TM : 테이블메니저
                mPaymentCert.cnt = 1;
                mPaymentCert.coupon_link_no = mCouponItemList[i].coupon_link_no;

                // 결제 항목 저장
                if (!SavePaymentCert(mPaymentCert))
                {
                    //return;
                }
            }





            int settel_amt = mNetAmount;


            // 티켓 저장
            int ticket_cnt = SaveTicketFlow("", mPayClass, "US", settel_amt);

            if (ticket_cnt > 0)
            {

            }


            // 주문서 출력 : 업장용 + 고객용
            // 주문서 출력
            /* 쿠폰인증/티켓교환은 교환권,영수증 출력 안함.
            String[] order_no_from_to = new String[2];

            order_no_from_to[0] = "";
            order_no_from_to[1] = "";


            List<shop_order_pack> shopOrderPackList = new List<shop_order_pack>();

            order_no_from_to = print_order(ref shopOrderPackList);


            // 영수증 출력 - 제외
            print_bill(mTheNo, "A", "", "00001", true, order_no_from_to); // cert
            */


            //
            mOrderItemList.Clear();
            lvwCoupon.SetObjects(mOrderItemList);
        }


        private void get_order_grouping_goods()
        {
            List<MemOrderItem> result = mOrderItemList
                .GroupBy(item => item.goods_code)
                .Select(group =>
                {
                    // 첫 번째 항목을 복사해서 사용
                    MemOrderItem item = group.First();
                    item.cnt = group.Count(); // 동일한 goods_code 개수로 cnt 설정
                    return item;
                })
                .ToList();

            // 결과를 다시 mOrderItemList에 저장
            mOrderItemList = result;

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
                    //tpMessageBox tpMessageBox = new tpMessageBox("데이터 오류. orderNo\n\n" + mObj["resultMsg"].ToString());
                    //tpMessageBox.ShowDialog();
                }
            }
            else
            {
                //tpMessageBox tpMessageBox = new tpMessageBox("시스템오류. orderNo\n\n" + mErrorMsg);
                //tpMessageBox.ShowDialog();
            }


            //
            return order_no;
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


        private void lvwCoupon_MouseClick(object sender, MouseEventArgs e)
        {
            var olv = sender as ObjectListView;

            var hitTestInfo = olv.OlvHitTest(e.X, e.Y);


            if (hitTestInfo?.Item != null)
            {
                int index = hitTestInfo.Item.Index;

                coupon cp = mCouponItemList[index];


                if (cp.is_pass == "Y" & cp.ustate_code == "2")
                {
                    if (cp.image_checked == "checked_off")
                    {
                        cp.image_checked = "checked_on";
                    }
                    else
                    {
                        cp.image_checked = "checked_off";
                    }
                }
                else
                {
                    cp.image_checked = "checked_off";
                }


                mCouponItemList[index] = cp;
                lvwCoupon.SetObjects(mCouponItemList);

            }

        }

    }
}

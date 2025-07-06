using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Drawing;
using System.Drawing.Text;
using static thepos2.frmSalesMenu;
using System.Security.Policy;
using static thepos2.thepos;
using System.IO;
using System.Collections;
using PrinterUtility;
using System.IO.Ports;
using System.Net.Sockets;


namespace thepos2
{
    public class thepos
    {


        // 배포시 버전관리 - 로그와 연동

        public static String mAppVersion = "TPW2-2025-010";





        // //////////////////////////////////////////////////////////////////////////////////////////////////
        //
        // 로그인후 다운로드되어야할 환경값들
        //
        // //////////////////////////////////////////////////////////////////////////////////////////


        // 사이트 설정값
        public static String mSiteId = "";
        public static String mSiteName;         // 매장명
        public static String mSiteAlias;        // 매장명
        public static String mCapName;          // 대표자명
        public static String mRegistNo;         // 사업자번호
        public static String mBizAddr;          // 주소
        public static String mBizTelNo;         // 대표전화

        // (후불) 발권  사용  정산 [락커]
        // (선불) 발권 [충전] 사용  정산
        public static String mTicketType;   //발권형태: ""미사용, "PA"선불, "PD"후불// 발권형태 : 선불형 AP-advanced payment  후불형 DP-deferred payment
        public static String mTicketMedia;  // 띠지BC   팔찌RF
        public static String mVanCode = "";


        // 알림톡
        public static String mAllimYn = "";
        public static String mAllimSenderProfile = "";
        public static String mAllimSenderProfileKey = "";
        public static String mAllimSiteName = "";
        public static String mAllimUserId = "";
        public static String mAllimCorpCode = "";
        public static String mAllimOrCode = "";
        public static String mAllimCpCode = "";
        public static String mAllimEtcCode = "";




        // 콜센터 연락처
        public static String mCallCenterNo = "";
        public static String mServerDbVer = "";


        public static String myShopCode = "";       // 내 업장코드
        //public static String myShopName = "";       // 내 업장명

        public static String myPosNo = "";       // 내 포스번호
        public static String[] mPosNoList;      // Site내 포스번호 목록


        // 주문서 - 상품정보 필드관리
        //? 코너타입은 사이트별 or 포스별??
        public static String mCornerType;  // 주문서 관리 - ""미사용, "E"단순일체형, "P"분리형
        public static String[] mCornerCode; // 코너 코드
        public static String[] mCornerName; // 코너 명


        // 영수증 출력 상단 이미지
        public static byte[] mByteLogoImage;


        public static int mLanguageNo = 0; // 0 1 2 3 - KR EN CH JP





        // //////////////////////////////////////////////////////////////////////////////////////////
        // 실행시 로컬 생성데이터
        public static String mBizDate = "";
        public static String mMacAddr = "";
        public static String mTheNo = "";  // 결제단위
        public static String mRefNo = "";  // 주문단위 입장단위

        // 실행중 로컬 운영
        public static String mScanString;
        public static bool mIsScanOK;


        public static string mUserID = "";
        public static string mUserName = "";


        public static CookieContainer cookies = new CookieContainer();
        public static HttpClientHandler handler = new HttpClientHandler();
        public static HttpClient mHttpClient;

        public static HttpClient mHttpClientCoupon;


        //??
        public static String mBaseUri = "";
        public static String uri_real = "http://211.45.170.55:8080/";
        public static String uri_test = "http://211.42.156.219:8080/";


        public static Panel mPanelOrderInfo;
        public static ListView mSublvwOrderItem;

        public static Label mSublblOrderAmount;
        public static Label mSublblOrderAmountDC;
        public static Label mSublblOrderAmountNet;
        public static Label mSublblOrderAmountReceive;
        public static Label mSublblOrderAmountRest;




        // //////////////////////////////////////////////////////////////////////////////////////////
        // 로컬 + 서버

        public struct OptionTemplate
        {
            public string option_template_id;
            public string option_template_name;
        }
        public static OptionTemplate[] mOptionTemplate;

        public struct TempOption
        {
            public string option_template_id;
            public string option_id;
            public int option_seq;
            public string is_turnoff;
            public string next_option_id;
            public string[] option_name;
        }
        public static TempOption[] mTempOption;


        public struct TempOptionItem
        {
            public string option_template_id;
            public string option_id;
            public string option_item_id;
            public int option_item_seq;
            public string link_option_id;
            public string[] option_item_name;
            public int option_item_amt;
        }
        public static TempOptionItem[] mTempOptionItem;



        public struct Shop
        {
            public string shop_code;
            public string shop_name;
            public string printer_type;
            public string network_printer_name;
        }
        public static Shop[] mShop;



        public struct GoodsGroup
        {
            public string group_code;
            public string[] group_name;
            public string soldout;
            public string cutout;
            public int column;
        }
        public static GoodsGroup[] mGoodsGroup1;
        public static List<GoodsGroup> mGoodsGroup = new List<GoodsGroup>();
        



        public struct GoodsItem
        {
            public string group_code;
            public string goods_code;
            public string[] goods_name;
            public string goods_notice;
            public string badges_id;
            public string image_path;
            public int amt;
            public String online_coupon;
            public String ticket; // 일반상품 0. 티켓상품 1
            public String taxfree; // 과세품 0, 면세품 1
            public String shop_code;
            public String nod_code1;
            public String nod_code2;
            public String cutout;   // 중지
            public String soldout;  // Y품절
            public String allim;
            public int column;
            public int row;
            public int columnspan;
            public int rowspan;
            public String option_template_id;
            public String coupon_link_no;
        }
        public static GoodsItem[] mGoodsItem;

        public struct Goods
        {
            public string goods_code;
            public string goods_name;
            public int amt;
            public String online_coupon;
            public String ticket; // 일반상품 0. 티켓상품 1
            public String taxfree; // 과세품 0, 면세품 1
            public String shop_code;
            public String nod_code1;
            public String nod_code2;
            public String cutout;   // 중지
            public String soldout;  // Y품절
            public String allim;
            public String bar_code;
        }
        public static List<Goods> mGoodsBarcodeList;




        /*
        public struct GoodsOption
        {
            public string goods_code;
            public string option_code;
            public int option_seq;
            public string[] option_name;
        }
        public static GoodsOption[] mGoodsOption;

        public struct GoodsOptionItem
        {
            public string goods_code;
            public string option_code;
            public int option_item_no;
            public string[] option_item_name;
            public int option_item_amt;
        }
        public static GoodsOptionItem[] mGoodsOptionItem;
        */

        // 로컬
        public struct MemOrder
        {
            public int order_no;        // 대기번호 [대기]을 위해
            public DateTime dt;         // 대기일시
            public int cnt;             // 항목수
            public int amount;          // 합계
        }
        public static List<MemOrder> listWaiting = new List<MemOrder>();

        public struct MemOrderItem
        {
            public int lv_order_no;             // 
            public String lv_goods_name;        // 상품name or 전체할인명("할인")
            public String lv_cnt;
            public String lv_amt;
            public String lv_dc_amount;         // 실할인금액
            public String lv_net_amount;        // 결제금액
            public String lv_cnt_dn;
            public String lv_cnt_up;
            public String lv_cnt_del;


            public String option_name_description;          // render를 통한 옵션 표시
            public String option_amt_description;          // render를 통한 옵션 표시
            public String option_dc_amount_description;          // render를 통한 옵션 표시

            public int option_item_cnt;
            public String option_no;   // option_item 연결번호
            public List<orderOptionItem> orderOptionItemList;

            public int order_no;                // 대기번호 [대기]을 위해

            public String goods_code;           // 상품code(6) or 전체할인코드고정("EDC")
            public String goods_name;           // 상품name or 전체할인명("할인")

            public int cnt;
            public int amt;                     // 상품단가
            public int option_amt;              // 옵션단가
            public int dc_amount;               // 실할인금액
            public int net_amount;              // 결제금액

            public String ticket;
            public String taxfree;
            public String allim;
            public String shop_code;
            public String nod_code1;
            public String nod_code2;

            public String dcr_code;     // 
            public String dcr_type;     // type - "A" : 정액, "R" : 정율 
            public String dcr_des;      // 전체"E", 선택"S"
            public int dcr_value;       // 할인금액 or 할인율
            public String pay_class;
            public String ticket_no;     // 충전, 사용인경우
            public String shop_order_no;

            public String coupon_no;


            public String lv_memo;
        }
        public static List<MemOrderItem> mOrderItemList = new List<MemOrderItem>();

        public struct orderOptionItem
        {
            public String option_code;
            public String option_name;
            public int option_item_no;
            public String option_item_name;
            public int amt;
        }
        public static List<orderOptionItem> mOrderOptionItemList = new List<orderOptionItem>();

        public static int mOrderCntInOption = 1;



        public struct shop_order_pack
        {
            public string shop_code;
            public string order_no;
            public string order_dt;
            public List<order_pack> orderPackList;
        }

        public struct order_pack
        {
            public string goods_code;
            public string allim;
            public string goods_name;
            public int goods_cnt;
            public string nod_code1;  //???? 키벤저스 F&B 레스토랑 만 주문서 출력을 위해서 nod_code1=41 만 출력
            public List<string> option_name;
            public List<string> option_item_name;
        }

        public static List<shop_order_pack> shopOrderPackList = new List<shop_order_pack>();


        //? 서버
        public struct dbOrder
        {
            public String site_id;
            public String biz_dt;       // yyyyMMdd
            public String pos_no;
            public String the_no;       // 
            public String ref_no;       // 
            public String tran_type;
            public String order_date;
            public String order_time;
            public int cnt;             // 항목수
            public String is_cancel;    // Y
        }
        public static List<dbOrder> listOrder = new List<dbOrder>();




        // 서버
        public struct Payment
        {
            public String site_id;
            public String biz_dt;  // yyyyMMdd
            public string pos_no;
            public String the_no;   // 결제단위
            public String ref_no;   // 입장단위
            public String pay_date;
            public String pay_time;
            public String tran_type;    // 승인 A, 취소 C
            public String pay_class;    // Order 0, charge 1, settlement 2
            public String bill_no;    // 4자리 
            public int net_amount;
            public int amount_cash;
            public int amount_card;
            public int amount_easy;
            public int amount_point;
            public int dc_amount;       // 할인금액
            public String is_cancel;   // 취소여부 : 미취소"", 취소중0, 취소1
        }
        public static List<Payment> mPayments = new List<Payment>();

        public struct PaymentCard
        {
            public String site_id;
            public String biz_dt;  // yyyyMMdd
            public string pos_no;
            public String the_no;   // 결제단위
            public String ref_no;   // 입장단위
            public String pay_date;
            public String pay_time;
            public String pay_type;     // 결제구분 : 신용카드(C1), 임의등록(C0)
            public String tran_type;    // 승인 A 취소 C
            public String pay_class;
            public String ticket_no;
            public int pay_seq;
            public String tran_date;
            public int amount;          // 결제금액 과세금액 면세금액 봉사료 세금
            public int tax_amount;
            public int tfree_amount;
            public int service_amount;
            public int tax;

            public String install;      // 할부개월 00 03
            public String auth_no;      // 승인번호
            public String card_no;      // 카드번호
            public String card_name;    // 카드종류
            public String isu_code;     // 발급사코드
            public String acq_code;     // 매입사코드
            public String merchant_no;  // 가맹점번호
            public String tran_serial;  // tran_serial -> 취소시 tid입력
            public String sign_path;
            public int gift_change;     // 기프트 잔액
            public String is_cancel;    // 취소여부 : "" or "1"
            public String van_code;
            public String is_cup;
        }
        public static List<PaymentCard> mPaymentCards = new List<PaymentCard>();

        public struct PaymentEasy
        {
            public String site_id;
            public String biz_dt;  // yyyyMMdd
            public string pos_no;
            public String the_no;   // 결제단위
            public String ref_no;   // 입장단위
            public String pay_date;
            public String pay_time;
            public String pay_type;     // 결제구분 : 간편결제(ㄸ1)
            public String tran_type;    // 승인 A 취소 C
            public String pay_class;
            public String ticket_no;
            public int pay_seq;
            public String tran_date;
            public int amount;          // 결제금액 과세금액 면세금액 봉사료 세금
            public int tax_amount;
            public int tfree_amount;
            public int service_amount;
            public int tax;

            public String install;      // 할부개월 00 03
            public String auth_no;      // 승인번호
            public String card_no;      // 카드번호
            public String card_name;    // 카드종류
            public String isu_code;     // 발급사코드
            public String acq_code;     // 매입사코드
            public String merchant_no;  // 가맹점번호
            public String tran_serial;  // tran_serial -> 취소시 tid입력
            public String sign_path;
            public int gift_change;     // 기프트 잔액
            public String is_cancel;    // 취소여부 : "" or "1"
            public String van_code;

            public String pay_type2;  // KKP

            public String barcode_no;
        }
        public static List<PaymentEasy> mPaymentEasys = new List<PaymentEasy>();


        public struct PaymentCert
        {
            public String site_id;
            public String biz_dt;  // yyyyMMdd
            public string pos_no;
            public String the_no;   // 결제단위
            public String ref_no;   // 입장단위
            public String pay_date;
            public String pay_time;
            public String pay_type;     // 결제구분 : 신용카드(C1), 임의등록(C0)
            public String tran_type;    // 승인 A 취소 C
            public String pay_class;
            public String ticket_no;

            public int pay_seq;
            public String tran_date;
            public int amount;          // 결제금액
            public String coupon_no;    // 
            public String is_cancel;    // 취소여부
            public String van_code;

            public int cnt;
            public String coupon_link_no;

        }
        public static List<PaymentCert> mPaymentCerts = new List<PaymentCert>();



        public struct CertOrder
        {
            public string state;
            public string ustaten;
            public string order_no;
            public string coupon_no;
            public string menu_code;
            public string menu_name;
            public int qty;
            public string exp_date;

            public string ustate;
            public string cus_nm;
            public string cus_hp;
            public string cus_opt;

            public string is_usage;
        }
        public static List<CertOrder> mCertOrders = new List<CertOrder>();




        // 발권상품(Order), 인증(Cert)시점 -> TicketFlow 레코드 생성(초기값)
        public struct TicketFlow
        {
            public String site_id;
            public String biz_dt;
            public String the_no;   // 결제단위
            public String ref_no;   // 입장단위

            public String ticket_no;
            public String ticketing_dt;   // 발권일시
            public String charge_dt;      // 충전일시
            public String settlement_dt;  // 정산일시

            public int point_charge_cnt;        // 충전횟수
            public int point_usage_cnt;         // 사용횟수

            public int point_charge;        // 충전금액
            public int point_usage;         // 사용금액(누적)

            public int settle_point_charge;        // 충전금액
            public int settle_point_usage;         // 사용금액(누적)

            public String goods_code;
            public String flow_step;      // 진행상황 : 접수0 - 발급1 - *충전2 - 사용3 - 정산(완료)4 : 사용중인 경우 locker close, 정산완료 locker open.

            public String locker_no;        // 추가
            public String open_locker;      // 락커 수동 설정 : 0 폐쇄(기본값), 1 개방
                                            // 정산완료  or 수동 개방상태 -> 락커오픈
        }
        public static List<TicketFlow> mTicketFlowList = new List<TicketFlow>();





        public static bool mNetworkState;
        public static bool mPrevNetworkState;

        public static String mTheMode = "";  // Server Local


        public static String mIsLogin = "N";


        public static String mPayClass = "OR"; // order

        public static Boolean mReturn = false;
        public static String mReturnValue = "";
        public static string mErrorMsg = "";

        public static JObject mObj = new JObject();



        // 포스별 설정
        public static String mPosType = ""; // 기종 : POS PC KIOSK

        public static String mMobileExchangeType = "";  // 모바일교환권 
        public static String mPrintExchangeType = "";  // 인쇄교환권 

        public static String mBillPrinterPort = "";
        public static String mBillPrinterSpeed = "";

        public static String mTicketPrinterPort = "";
        public static String mTicketPrinterSpeed = "";

        public static String mVanTID = "";    // 결제밴 T-ID

        // 앞으로 쿠폰 채널 
        public static String mCouponMID = "";   // 

        public static String mTicketAddText = "";
        public static String mBillAddText = "";

        //
        public static String mWaitingDisplay = "";  // 대기화면 사용여부
        public static String mWaitingDisplayImage = "";         //  대기화면 이미지
        public static int mWaitingSecond = 30;             //  대기화면 전환시간(초)

        public static String mKioskLogoImage = "";       // 키오스크 본화면 상단로고

        public static String mMultiLanguage = "";

        public static String mKioskType = "";

        // 인증 대문화면
        public static String mCouponDisplayImage = "";



        // 로그
        public static int mAppLogLevel = 1;
        // log_input :  1(info), 2(IMPORTANT), 3(error만)   >=  app_log_level :  1(ALL), 2(IMPORTANT), 3(ERROR), 4(NONE)

        //
        public static String mIsDevLogin = "";  


        public static String mIsTestPayMode = "";   // TEST LOGIN


        public static String get_MMddHHmm(String d, String t)
        {
            return d.Substring(4, 2) + "-" + d.Substring(6, 2) + " " + t.Substring(0, 2) + ":" + t.Substring(2, 2);
        }

        public static String get_today_date()
        {
            return DateTime.Now.ToString("yyyyMMdd");
        }

        public static String get_today_time()
        {
            return DateTime.Now.ToString("HHmmss");
        }



        public static String get_pay_class_name(String code)
        {
            String name = "";
            if (code == "OR") name = "구매";
            else if (code == "CH") name = "충전";
            else if (code == "US")
            {
                if (mTicketType == "PA") name = "선불";
                else if (mTicketType == "PD") name = "후불";
                else name = code;
            }
            else if (code == "ST") name = "정산:";
            else name = code;

            return name;
        }



        public static String get_pay_type_group_name(String group)
        {
            //is_cash + is_card + is_point + is_easy;
            if (group == "1000") return "현금";
            else if (group == "0100") return "카드";
            else if (group == "0010") return "포인트";
            else if (group == "0001") return "간편";
            else if (group == "0000") return "";
            else return "복합";
        }


        public static String get_pay_type_name(String code)
        {
            String name = "";
            if (code == "C1") name = "카드승인결제";
            else if (code == "C0") name = "카드임의등록";
            else if (code == "R0") name = "단순현금";
            else if (code == "R1") name = "현금영수증";
            else if (code == "R9") name = "임의등록";
            else if (code == "PA") name = "포인트선불";
            else if (code == "PD") name = "포인트후불";
            else if (code == "E1") name = "간편";
            else name = code;

            return name;
        }

        public static String get_tran_type_name(String code)
        {
            String name = "";
            if (code == "A") name = "승인";
            else if (code == "C") name = "취소";
            else name = code;

            return name;
        }


        public static String get_ticket_type_name(String code)
        {
            String name = "";
            if (code == "PA") name = "선불";
            else if (code == "PD") name = "후불";
            else name = code;

            return name;
        }


        public static String get_receipt_type_name(String code)
        {
            String name = "";
            if (code == "1") name = "개인소득공제";
            else if (code == "2") name = "사업지출증빙";
            else if (code == "3") name = "자진발급";
            else name = code;

            return name;
        }



        public static String get_dcr_des_name(String code)
        {
            String name = "";
            if (code == "E") name = "전체";
            else if (code == "S") name = "선택";
            else name = code;

            return name;
        }

        public static String get_dcr_type_name(String code)
        {
            String name = "";
            if (code == "A") name = "정액(W)";
            else if (code == "R") name = "정율(%)";
            else name = code;

            return name;
        }

        public static String get_is_cancel_name(String code)
        {
            String name = "";
            if (code == "1") name = "취소중";
            else if (code == "Y") name = "취소됨";
            else name = code;

            return name;
        }


        public static int get_goods_index(String code)
        {
            for (int i = 0; i < mGoodsItem.Length; i++)
            {
                if (mGoodsItem[i].goods_code == code)
                {
                    return i;
                }
            }

            return -1;
        }

        public static String get_goods_name(String code)
        {
            if (code == "CHARGE")
                return "충전";

            for (int i = 0; i < mGoodsItem.Length; i++)
            {
                if (mGoodsItem[i].goods_code == code)
                {
                    return mGoodsItem[i].goods_name[0];
                }
            }



            for (int i = 0; i < mGoodsBarcodeList.Count; i++)
            {
                if (mGoodsBarcodeList[i].goods_code == code)
                {
                    return mGoodsBarcodeList[i].goods_name;
                }
            }


            return code;
        }

        public static String get_goods_option_name(String goods_code, String option_code)
        {
            String goods_template_id = "";

            for (int i = 0; i < mGoodsItem.Length; i++)
            {
                if (mGoodsItem[i].goods_code == goods_code)
                {
                    goods_template_id =  mGoodsItem[i].option_template_id;
                    break;
                }
            }


            for (int i = 0; i < mTempOption.Length; i++)
            {
                if (mTempOption[i].option_template_id == goods_template_id & mTempOption[i].option_id == option_code)
                {
                    return mTempOption[i].option_name[0];
                }
            }

            return goods_code + "-" + option_code;
        }

        public static String get_goods_option_item_name(String goods_code, String option_code, int option_item_no)
        {
            String goods_template_id = "";

            for (int i = 0; i < mGoodsItem.Length; i++)
            {
                if (mGoodsItem[i].goods_code == goods_code)
                {
                    goods_template_id = mGoodsItem[i].option_template_id;
                    break;
                }
            }


            for (int i = 0; i < mTempOptionItem.Length; i++)
            {
                if (mTempOptionItem[i].option_template_id == goods_template_id & mTempOptionItem[i].option_id == option_code & mTempOptionItem[i].option_item_id == option_item_no.ToString())
                {
                    return mTempOptionItem[i].option_item_name[0];
                }
            }

            return goods_code + "-" + option_code + "-" + option_item_no;
        }





        public static String get_shop_name(String shop_code)
        {
            if (shop_code == "CHARGE")
                return "충전";


            for (int i = 0; i < mShop.Length; i++)
            {
                if (mShop[i].shop_code == shop_code)
                {
                    return mShop[i].shop_name;
                }
            }

            return shop_code;
        }



        public static bool is_number(String str)
        {
            int tNum;
            if (int.TryParse(str, out tNum))
            {
                return true;
            }

            return false;
        }

        public static bool get_number(String str, ref int num)
        {
            if (int.TryParse(str, out num))
            {
                return true;
            }

            return false;
        }

        public static int convert_number(String str)
        {
            int out_number;
            if (int.TryParse(str.Replace(",", ""), out out_number))
            {
                return out_number;
            }

            return -1;
        }

        public static bool mRequestGet(String sUrl)
        {
            try
            {
                var response = mHttpClient.GetAsync(mBaseUri + sUrl).Result;

                var responseContent = response.Content;
                string responseString = responseContent.ReadAsStringAsync().Result;

                mObj = JObject.Parse(responseString);

                return true;
            }
            catch (Exception ex)
            {
                mErrorMsg = ex.Message;
                return false;
            }
        }

        public static bool mRequestPost(String sUrl, Dictionary<string, string> parameters)
        {
            try
            {
                var json = JsonConvert.SerializeObject(parameters);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = mHttpClient.PostAsync(mBaseUri + sUrl, data).Result;

                var responseContent = response.Content;
                string responseString = responseContent.ReadAsStringAsync().Result;

                mObj = JObject.Parse(responseString);

                return true;
            }
            catch (Exception ex)
            {
                mErrorMsg = ex.Message;
                return false;
            }
        }


        public static bool mRequestPatch(String sUrl, Dictionary<string, string> parameters)
        {
            try
            {
                var json = JsonConvert.SerializeObject(parameters);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var method = new HttpMethod("PATCH");
                var request = new HttpRequestMessage(method, mBaseUri + sUrl);
                request.Content = data;


                var response = mHttpClient.SendAsync(request).Result;

                var responseContent = response.Content;
                string responseString = responseContent.ReadAsStringAsync().Result;

                mObj = JObject.Parse(responseString);

                return true;
            }
            catch (Exception ex)
            {
                mErrorMsg = ex.Message;
                return false;
            }
        }

        public static bool mRequestDelete(String sUrl, Dictionary<string, string> parameters)
        {
            try
            {
                var json = JsonConvert.SerializeObject(parameters);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var method = new HttpMethod("DELETE");
                var request = new HttpRequestMessage(method, mBaseUri + sUrl);
                request.Content = data;


                var response = mHttpClient.SendAsync(request).Result;

                var responseContent = response.Content;
                string responseString = responseContent.ReadAsStringAsync().Result;

                mObj = JObject.Parse(responseString);

                return true;
            }
            catch (Exception ex)
            {
                mErrorMsg = ex.Message;
                return false;
            }
        }


        public static string SHA1HashCrypt(string val)
        {
            //고정로직
            byte[] data = Encoding.ASCII.GetBytes(val);
            SHA1 sha = new SHA1CryptoServiceProvider();
            byte[] result = sha.ComputeHash(data);
            return Convert.ToBase64String(result);
        }


        public static bool get_bizdate_status(ref String biz_status, ref String biz_date)
        {
            String sUrl = "bizDateLast?siteId=" + mSiteId;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String cnt = mObj["bizDateCnt"].ToString();

                    if (cnt == "0")
                    {
                        biz_date = "";
                        biz_status = "X";
                    }
                    else
                    {
                        String data = mObj["bizDate"].ToString();
                        JArray arr = JArray.Parse(data);

                        biz_date = arr[0]["bizDt"].ToString();
                        biz_status = arr[0]["bizStatus"].ToString();
                    }
                    return true;
                }
                else
                {
                    MessageBox.Show("영업개시마감 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    //MessageBox.Show("영업개시마감 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return false;
            }

        }




        public static void sync_data_server_to_memory()
        {
            // 1. 사이트
            if (true)
            {
                String sUrl = "site?siteId=" + mSiteId;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["sites"].ToString();
                        JArray arr = JArray.Parse(data);

                        if (arr.Count == 1)
                        {
                            mSiteName = arr[0]["siteName"].ToString();
                            mSiteAlias = arr[0]["siteAlias"].ToString();
                            mRegistNo = arr[0]["registNo"].ToString();
                            mCapName = arr[0]["capName"].ToString();
                            mBizAddr = arr[0]["bizAddr"].ToString();
                            mBizTelNo = arr[0]["bizTelNo"].ToString();
                            mTicketType = arr[0]["ticketType"].ToString();
                            mTicketMedia = arr[0]["ticketMedia"].ToString();
                            mVanCode = arr[0]["vanCode"].ToString();
                            mCallCenterNo = arr[0]["callCenterNo"].ToString();

                            // 알림톡
                            mAllimYn = arr[0]["allimYn"].ToString();
                            mAllimSenderProfile = arr[0]["senderProfile"].ToString();


                            //
                            String image_str = arr[0]["billImage"].ToString();
                            if (image_str == "")
                            {
                                mByteLogoImage = null;
                            }
                            else
                            {
                                try
                                {
                                    byte[] mBillImageByte = Convert.FromBase64String(image_str);

                                    MemoryStream ms = new MemoryStream(mBillImageByte, 0, mBillImageByte.Length);
                                    ms.Write(mBillImageByte, 0, mBillImageByte.Length);

                                    Bitmap bitmap_bill = new Bitmap(ms);

                                    mByteLogoImage = GetImage(bitmap_bill, 400);
                                }
                                catch
                                {
                                    mByteLogoImage = null;
                                }
                            }

                            // site -> setupPos 설정으로 이동
                            //mKioskImagePath = arr[0]["kioskLogoImage"].ToString();
                        }
                    }
                    else
                    {
                        MessageBox.Show("사이트정보 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                    return;
                }
            }

            // 1-2. site_allim
            if (mAllimYn == "Y")
            {
                String sUrl = "siteAllim?siteId=" + mSiteId;

                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["sites"].ToString();
                        JArray arr = JArray.Parse(data);

                        if (arr.Count > 0)
                        {
                            mAllimSenderProfile = arr[0]["senderProfile"].ToString();
                            mAllimSenderProfileKey = arr[0]["senderProfileKey"].ToString();
                            mAllimSiteName = arr[0]["siteName"].ToString();
                            mAllimUserId = arr[0]["allimUserId"].ToString();
                            mAllimCorpCode = arr[0]["allimCorpCode"].ToString();
                            mAllimOrCode = arr[0]["orAllimCode"].ToString();
                            mAllimCpCode = arr[0]["cpAllimCode"].ToString();
                            mAllimEtcCode = arr[0]["etcAllimCode"].ToString();
                        }
                    }
                    else
                    {
                        MessageBox.Show("알림톡정보 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                    return;
                }
            }


            // 2. goodsGroup
            if (true)
            {
                String sUrl = "goodsGroup?siteId=" + mSiteId + "&posNo=" + myPosNo;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["goodsGroups"].ToString();
                        JArray arr = JArray.Parse(data);

                        mGoodsGroup.Clear();

                        for (int i = 0; i < arr.Count; i++)
                        {
                            if (arr[i]["cutout"].ToString() != "Y")
                            {
                                GoodsGroup goodsGroup = new GoodsGroup();
                                goodsGroup.group_code = arr[i]["groupCode"].ToString();
                                goodsGroup.group_name = new string[4];
                                goodsGroup.group_name[0] = arr[i]["groupName"].ToString();
                                goodsGroup.group_name[1] = arr[i]["groupNameEn"].ToString();
                                goodsGroup.group_name[2] = arr[i]["groupNameCh"].ToString();
                                goodsGroup.group_name[3] = arr[i]["groupNameJp"].ToString();
                                goodsGroup.soldout = arr[i]["soldout"].ToString();
                                goodsGroup.column = int.Parse(arr[i]["locateX"].ToString());
                                mGoodsGroup.Add(goodsGroup);
                            }
                        }

                        // 정렬
                        bool sort_complete = false;
                        GoodsGroup goodsGroupTemp = new GoodsGroup();


                        while (!sort_complete)
                        {
                            sort_complete = true;

                            for (int i = 0; i < mGoodsGroup.Count - 1; i++)
                            {
                                if (mGoodsGroup[i].column > mGoodsGroup[i + 1].column)  // ascending
                                {
                                    goodsGroupTemp = mGoodsGroup[i];
                                    mGoodsGroup[i] = mGoodsGroup[i + 1];
                                    mGoodsGroup[i + 1] = goodsGroupTemp;

                                    sort_complete = false;
                                }
                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("상품그룹정보 오류. goodsGroup\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                    return;
                }
            }


            // 3. goodsItemAndGoods
            if (true)
            {
                String sUrl = "goodsItemAndGoods?siteId=" + mSiteId + "&posNo=" + myPosNo + "&imageYn=Y";
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String goods_item = mObj["goodsItems"].ToString();
                        JArray arr = JArray.Parse(goods_item);

                        mGoodsItem = new GoodsItem[arr.Count];

                        for (int i = 0; i < arr.Count; i++)
                        {
                            mGoodsItem[i].group_code = arr[i]["groupCode"].ToString();
                            mGoodsItem[i].goods_code = arr[i]["goodsCode"].ToString();

                            mGoodsItem[i].goods_name = new string[4];

                            mGoodsItem[i].goods_name[0] = arr[i]["goodsName"].ToString();
                            mGoodsItem[i].goods_name[1] = arr[i]["goodsNameEn"].ToString();
                            mGoodsItem[i].goods_name[2] = arr[i]["goodsNameCh"].ToString();
                            mGoodsItem[i].goods_name[3] = arr[i]["goodsNameJp"].ToString();

                            mGoodsItem[i].goods_notice = arr[i]["goodsNotice"].ToString();
                            mGoodsItem[i].badges_id = arr[i]["badgesId"].ToString();

                            mGoodsItem[i].shop_code = arr[i]["shopCode"].ToString();
                            mGoodsItem[i].nod_code1 = arr[i]["nodCode1"].ToString();
                            mGoodsItem[i].nod_code2 = arr[i]["nodCode2"].ToString();

                            mGoodsItem[i].amt = int.Parse(arr[i]["amt"].ToString());
                            mGoodsItem[i].online_coupon = arr[i]["onlineCoupon"].ToString();
                            mGoodsItem[i].ticket = arr[i]["ticketYn"].ToString();
                            mGoodsItem[i].taxfree = arr[i]["taxFree"].ToString();
                            mGoodsItem[i].cutout = arr[i]["cutout"].ToString();
                            mGoodsItem[i].soldout = arr[i]["soldout"].ToString();
                            mGoodsItem[i].allim = arr[i]["allim"].ToString();
                            mGoodsItem[i].column = int.Parse(arr[i]["locateX"].ToString());  // 배치순번
                            mGoodsItem[i].option_template_id = arr[i]["optionTemplateId"].ToString();
                            mGoodsItem[i].coupon_link_no = arr[i]["couponLinkNo"].ToString();

                            mGoodsItem[i].image_path = arr[i]["imagePath"].ToString();

                            // 면세상픔은 상품명앞에 *을 붙인다.
                            if (mGoodsItem[i].taxfree == "1")
                            {
                                mGoodsItem[i].goods_name[0] = "*" + mGoodsItem[i].goods_name[0];
                                mGoodsItem[i].goods_name[1] = "*" + mGoodsItem[i].goods_name[1];
                                mGoodsItem[i].goods_name[2] = "*" + mGoodsItem[i].goods_name[2];
                                mGoodsItem[i].goods_name[3] = "*" + mGoodsItem[i].goods_name[3];
                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("상품정보 오류. goodsItemAndGoods\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                    return;
                }
            }


            // 3-1. optionTemplate
            if (true)
            {
                String sUrl = "optionTemplate?siteId=" + mSiteId;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["optionTemp"].ToString();
                        JArray arr = JArray.Parse(data);

                        mOptionTemplate = new OptionTemplate[arr.Count];

                        for (int i = 0; i < arr.Count; i++)
                        {
                            mOptionTemplate[i].option_template_id = arr[i]["optionTemplateId"].ToString();
                            mOptionTemplate[i].option_template_name = arr[i]["optionTemplateName"].ToString();
                        }
                    }
                    else
                    {
                        MessageBox.Show("옵션템플릿정보 오류. optionTemplate\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                    return;
                }
            }

            // 3-2. tempOption
            if (true)
            {
                String sUrl = "tempOption?siteId=" + mSiteId;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["tempOption"].ToString();
                        JArray arr = JArray.Parse(data);

                        mTempOption = new TempOption[arr.Count];

                        for (int i = 0; i < arr.Count; i++)
                        {
                            mTempOption[i].option_template_id = arr[i]["optionTemplateId"].ToString();
                            mTempOption[i].option_id = arr[i]["optionId"].ToString();
                            mTempOption[i].option_seq = convert_number(arr[i]["optionSeq"].ToString());
                            mTempOption[i].is_turnoff = arr[i]["isTurnoff"].ToString();
                            mTempOption[i].next_option_id = arr[i]["nextOptionId"].ToString();

                            mTempOption[i].option_name = new string[4];

                            mTempOption[i].option_name[0] = arr[i]["optionName"].ToString();
                            mTempOption[i].option_name[1] = arr[i]["optionNameEn"].ToString();
                            mTempOption[i].option_name[2] = arr[i]["optionNameCh"].ToString();
                            mTempOption[i].option_name[3] = arr[i]["optionNameJp"].ToString();
                        }
                    }
                    else
                    {
                        MessageBox.Show("옵션정보 오류. tempOption\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                    return;
                }
            }

            // 3-3. tempOptionItem
            if (true)
            {
                String sUrl = "tempOptionItem?siteId=" + mSiteId;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["optionItem"].ToString();
                        JArray arr = JArray.Parse(data);

                        mTempOptionItem = new TempOptionItem[arr.Count];

                        for (int i = 0; i < arr.Count; i++)
                        {
                            mTempOptionItem[i].option_template_id = arr[i]["optionTemplateId"].ToString();
                            mTempOptionItem[i].option_id = arr[i]["optionId"].ToString();
                            mTempOptionItem[i].option_item_id = arr[i]["optionItemId"].ToString();
                            mTempOptionItem[i].option_item_seq = convert_number(arr[i]["optionItemSeq"].ToString());
                            mTempOptionItem[i].link_option_id = arr[i]["linkOptionId"].ToString();

                            mTempOptionItem[i].option_item_name = new string[4];

                            mTempOptionItem[i].option_item_name[0] = arr[i]["optionItemName"].ToString();
                            mTempOptionItem[i].option_item_name[1] = arr[i]["optionItemNameEn"].ToString();
                            mTempOptionItem[i].option_item_name[2] = arr[i]["optionItemNameCh"].ToString();
                            mTempOptionItem[i].option_item_name[3] = arr[i]["optionItemNameJp"].ToString();


                            mTempOptionItem[i].option_item_amt = convert_number(arr[i]["optionItemAmt"].ToString());
                        }
                    }
                    else
                    {
                        MessageBox.Show("옵션정보 오류. tempOption\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                    return;
                }
            }


            // 4. 샵
            if (true)
            {
                String sUrl = "shop?siteId=" + mSiteId;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["shops"].ToString();
                        JArray arr = JArray.Parse(data);

                        mShop = new Shop[arr.Count];

                        for (int i = 0; i < arr.Count; i++)
                        {
                            mShop[i].shop_code = arr[i]["shopCode"].ToString();
                            mShop[i].shop_name = arr[i]["shopName"].ToString();
                            mShop[i].printer_type = arr[i]["printerType"].ToString();
                            mShop[i].network_printer_name = arr[i]["networkPrinterName"].ToString();
                        }
                    }
                    else
                    {
                        MessageBox.Show("샵정보 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                    return;
                }
            }


            // 6. setupPos
            if (true)
            {
                String sUrl = "setupPos?siteId=" + mSiteId + "&posNo=" + myPosNo;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["setupPos"].ToString();
                        JArray arr = JArray.Parse(data);

                        for (int i = 0; i < arr.Count; i++)
                        {
                            if (arr[i]["setupCode"].ToString() == "BillPrinterPort") mBillPrinterPort = arr[i]["setupValue"].ToString();
                            else if (arr[i]["setupCode"].ToString() == "BillPrinterSpeed") mBillPrinterSpeed = arr[i]["setupValue"].ToString();

                            else if (arr[i]["setupCode"].ToString() == "MobileExchangeType") mMobileExchangeType = arr[i]["setupValue"].ToString();
                            else if (arr[i]["setupCode"].ToString() == "PrintExchangeType") mPrintExchangeType = arr[i]["setupValue"].ToString();

                            else if (arr[i]["setupCode"].ToString() == "TicketPrinterPort") mTicketPrinterPort = arr[i]["setupValue"].ToString();
                            else if (arr[i]["setupCode"].ToString() == "TicketPrinterSpeed") mTicketPrinterSpeed = arr[i]["setupValue"].ToString();

                            else if (arr[i]["setupCode"].ToString() == "PosType") mPosType = arr[i]["setupValue"].ToString();
                            else if (arr[i]["setupCode"].ToString() == "VanTID") mVanTID = arr[i]["setupValue"].ToString();

                            else if (arr[i]["setupCode"].ToString() == "CouponMID") mCouponMID = arr[i]["setupValue"].ToString();


                            //
                            else if (arr[i]["setupCode"].ToString() == "WaitingDisplay") mWaitingDisplay = arr[i]["setupValue"].ToString();
                            else if (arr[i]["setupCode"].ToString() == "WaitingDisplayImage") mWaitingDisplayImage = arr[i]["setupValue"].ToString();
                            else if (arr[i]["setupCode"].ToString() == "WaitingSecond") mWaitingSecond = convert_number(arr[i]["setupValue"].ToString());

                            else if (arr[i]["setupCode"].ToString() == "KioskLogoImage") mKioskLogoImage = arr[i]["setupValue"].ToString();

                            else if (arr[i]["setupCode"].ToString() == "MultiLanguage") mMultiLanguage = arr[i]["setupValue"].ToString();

                            else if (arr[i]["setupCode"].ToString() == "KioskType") mKioskType = arr[i]["setupValue"].ToString();

                            else if (arr[i]["setupCode"].ToString() == "CouponDisplayImage") mCouponDisplayImage = arr[i]["setupValue"].ToString();

                            else if (arr[i]["setupCode"].ToString() == "TicketAddText") mTicketAddText = arr[i]["setupValue"].ToString();
                            else if (arr[i]["setupCode"].ToString() == "BillAddText") mBillAddText = arr[i]["setupValue"].ToString();

                            else if (arr[i]["setupCode"].ToString() == "AppLogLevel")
                            {
                                //  mLogLevel -  1: ALL  2: ERROR  3: NONE
                                String t_level = arr[i]["setupValue"].ToString();

                                if (t_level == "ALL") mAppLogLevel = 1;
                                else if (t_level == "IMPORTANT") mAppLogLevel = 2;
                                else if (t_level == "ERROR") mAppLogLevel = 3;
                                else if (t_level == "NONE") mAppLogLevel = 4;
                                else mAppLogLevel = 4;
                            }

                        }
                    }
                }
            }

        }


        public static byte[] GetImage(Bitmap bill_image, int printWidth)
        {
            List<byte> byteList = new List<byte>();

            BitmapData data = GetBitmapData(bill_image, printWidth);


            BitArray dots = data.Dots;
            byte[] width = BitConverter.GetBytes(data.Width);

            int offset = 0;
            //byteList.Add(Convert.ToByte(Convert.ToChar(0x1B)));
            //byteList.Add(Convert.ToByte('@'));
            byteList.Add(Convert.ToByte(Convert.ToChar(0x1B)));
            byteList.Add(Convert.ToByte('3'));
            byteList.Add((byte)24);
            while (offset < data.Height)
            {
                byteList.Add(Convert.ToByte(Convert.ToChar(0x1B)));
                byteList.Add(Convert.ToByte('*'));
                byteList.Add((byte)33);
                byteList.Add(width[0]);
                byteList.Add(width[1]);

                for (int x = 0; x < data.Width; ++x)
                {
                    for (int k = 0; k < 3; ++k)
                    {
                        byte slice = 0;
                        for (int b = 0; b < 8; ++b)
                        {
                            int y = (((offset / 8) + k) * 8) + b;
                            int i = (y * data.Width) + x;

                            bool v = false;
                            if (i < dots.Length)
                                v = dots[i];

                            slice |= (byte)((v ? 1 : 0) << (7 - b));
                        }
                        byteList.Add(slice);
                    }
                }
                offset += 24;
                byteList.Add(Convert.ToByte(0x0A));
            }
            byteList.Add(Convert.ToByte(0x1B));
            byteList.Add(Convert.ToByte('3'));
            byteList.Add((byte)30);
            return byteList.ToArray();
        }

        private static BitmapData GetBitmapData(Bitmap bill_image, int width)
        {
            using (var bitmap = bill_image)
            {
                var threshold = 127;
                var index = 0;
                double multiplier = width; // 이미지 width조정
                double scale = (double)(multiplier / (double)bitmap.Width);
                int xheight = (int)(bitmap.Height * scale);
                int xwidth = (int)(bitmap.Width * scale);
                var dimensions = xwidth * xheight;
                var dots = new BitArray(dimensions);

                for (var y = 0; y < xheight; y++)
                {
                    for (var x = 0; x < xwidth; x++)
                    {
                        var _x = (int)(x / scale);
                        var _y = (int)(y / scale);
                        var color = bitmap.GetPixel(_x, _y);
                        var luminance = (int)(color.R * 0.3 + color.G * 0.59 + color.B * 0.11);
                        dots[index] = (luminance < threshold);
                        index++;
                    }
                }

                return new BitmapData()
                {
                    Dots = dots,
                    Height = (int)(bitmap.Height * scale),
                    Width = (int)(bitmap.Width * scale)
                };
            }
        }

        private class BitmapData
        {
            public BitArray Dots
            {
                get;
                set;
            }

            public int Height
            {
                get;
                set;
            }

            public int Width
            {
                get;
                set;
            }
        }

        public static void thepos_app_log(int log_input, String form_name, String form_action, string form_memo)
        {
            //  log_input
            //  1 : 단순로그
            //  2 : 로그인 등
            //  3 : error - 에러

            //  mLogLevel 
            // 1 : ALL
            // 2 : INFO  - 로그인 로그아웃 종료
            // 3 : ERROR
            // 4 : NONE



            // 개발자로그인은 앱로그를 안남긴다.
            if (mIsDevLogin == "Y")
            {
                if (mIsTestPayMode == "Test")
                {
                    //

                }
                else
                {
                    return;
                }
            }



            //
            if (log_input >= mAppLogLevel)
            {
                try
                {
                    String sUrl = "theposAppLog";

                    Dictionary<string, string> parameters = new Dictionary<string, string>();
                    parameters["logDate"] = get_today_date();
                    parameters["logTime"] = get_today_time();
                    parameters["logLevel"] = log_input + "";
                    parameters["siteId"] = mSiteId;
                    parameters["posNo"] = myPosNo;
                    parameters["formName"] = form_name;
                    parameters["formAction"] = form_action;
                    parameters["formMemo"] = form_memo;

                    var json = JsonConvert.SerializeObject(parameters);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = mHttpClient.PostAsync(mBaseUri + sUrl, data).Result;

                    //var responseContent = response.Content;
                    //string responseString = responseContent.ReadAsStringAsync().Result;

                }
                catch (Exception e)
                {
                    //
                }
            }
        }



        public static String make_bill_header()
        {
            String strPrint = "";

            String tStr = mSiteName + " " + mBizTelNo;
            strPrint += tStr;
            strPrint += "\r\n";

            tStr = mBizAddr;
            strPrint += tStr;
            strPrint += "\r\n";

            tStr = mCapName + " ";

            if (mRegistNo.Length == 10)
            {
                tStr += mRegistNo.Substring(0, 3) + "-" + mRegistNo.Substring(3, 2) + "-" + mRegistNo.Substring(5, 5);
            }
            else
            {
                tStr += mRegistNo;
            }

            strPrint += tStr;
            strPrint += "\r\n";
            strPrint += "\r\n";


            return strPrint;
        }

        public static String make_bill_trailer()
        {
            String strPrint = "";

            String tStr = "  물품반품시 본 영수증을 필히 지참하여";
            strPrint += tStr;
            strPrint += "\r\n";

            tStr = "  주시기 바랍니다.";
            strPrint += tStr;
            strPrint += "\r\n";

            return strPrint;

        }

        public static String make_bill_body(String tTheNo, String tranType, String except_order, String pay_keep)
        {
            String strPrintHeader = "";
            String strPrintOrder = "";
            String strPrintPayment = "";

            String tOrderDt = "";
            int t과세가액 = 0;
            int t면세가액 = 0;
            int t할인금액 = 0;

            String pay_keep_cash = pay_keep.Substring(0, 1);
            String pay_keep_card = pay_keep.Substring(1, 1);
            String pay_keep_point = pay_keep.Substring(2, 1);
            String pay_keep_easy = pay_keep.Substring(3, 1);
            String pay_keep_cert = pay_keep.Substring(4, 1); //?# 쿠폰인증


            //!
            String sUrl = "orders?siteId=" + mSiteId + "&theNo=" + tTheNo;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["orders"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        String d = arr[i]["orderDate"].ToString();
                        String t = arr[i]["orderTime"].ToString();
                        tOrderDt = d.Substring(0, 4) + "/" + d.Substring(4, 2) + "/" + d.Substring(6, 2) + " " +
                                   t.Substring(0, 2) + ":" + t.Substring(2, 2) + ":" + t.Substring(4, 2);
                    }
                }
                else
                {
                    MessageBox.Show("주문 데이터 오류. orders\n\n" + mObj["resultMsg"].ToString(), "thepos");
                }
            }
            else
            {
                MessageBox.Show("시스템오류. orders\n\n" + mErrorMsg, "thepos");
            }


            String tStr = tTheNo.Substring(4, 8) + "-" + tTheNo.Substring(12, 2) + "-" + tTheNo.Substring(14, 6);
            int space_cnt = 42 - (encodelen(tOrderDt) + encodelen(tStr));
            strPrintHeader = tOrderDt + Space(space_cnt) + tStr;
            strPrintHeader += "\r\n";



            //!
            strPrintOrder = "==========================================\r\n";  // 42
            strPrintOrder += "상품명                 단가  수량     금액\r\n";
            strPrintOrder += "------------------------------------------\r\n";  // 42

            sUrl = "orderItem?siteId=" + mSiteId + "&theNo=" + tTheNo + "&tranType=" + tranType;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["orderItems"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        int amt = convert_number(arr[i]["amt"].ToString());
                        int option_amt = convert_number(arr[i]["optionAmt"].ToString());
                        int cnt = convert_number(arr[i]["cnt"].ToString());
                        int dc_amt = convert_number(arr[i]["dcAmount"].ToString());
                        String dcr_des = arr[i]["dcrDes"].ToString();
                        String dcr_type = arr[i]["dcrType"].ToString();
                        String dcr_value = arr[i]["dcrValue"].ToString();

                        if (dcr_des == "E") // 전체할인
                        {
                            if (dcr_type == "A")
                            {
                                tStr = arr[i]["goodsName"].ToString();
                                strPrintOrder += tStr + Space(21 - encodelen(tStr));

                                tStr = (-dc_amt).ToString("N0");        // 할인 정액
                                strPrintOrder += Space(21 - encodelen(tStr)) + tStr;
                            }
                            else if (dcr_type == "R")
                            {
                                tStr = arr[i]["goodsName"].ToString() + "-" + dcr_value + "%";
                                strPrintOrder += tStr + Space(21 - encodelen(tStr));

                                tStr = (-dc_amt).ToString("N0");        // 할인 정액
                                strPrintOrder += Space(21 - encodelen(tStr)) + tStr;
                            }
                            strPrintOrder += "\r\n";
                        }
                        else                                 // 일반상품항목
                        {
                            // 상품아이템

                            String tGoodsName = "";

                            if (arr[i]["taxFree"].ToString() == "Y")
                                tGoodsName = "*" + arr[i]["goodsName"].ToString();
                            else
                                tGoodsName = arr[i]["goodsName"].ToString();

                            String tGoodsAmt = amt.ToString("N0");     //단가


                            int tLenGoodsNameAmt = encodelen(tGoodsName) + encodelen(tGoodsAmt);

                            if (tLenGoodsNameAmt > 26)
                            {
                                strPrintOrder += tGoodsName + "\r\n";
                                strPrintOrder += Space(18) + Space(9 - encodelen(tGoodsAmt)) + tGoodsAmt;
                            }
                            else
                            {
                                strPrintOrder += tGoodsName + Space(27 - tLenGoodsNameAmt) + tGoodsAmt;
                            }


                            tStr = cnt.ToString("N0");     // 수량
                            strPrintOrder += Space(6 - encodelen(tStr)) + tStr;

                            tStr = (amt * cnt).ToString("N0");     // 금액 = 단가*수량

                            if (encodelen(tStr) > 9)
                            {
                                strPrintOrder += Space(9) + "\r\n";
                                strPrintOrder += Space(42 - encodelen(tStr)) + tStr;
                            }
                            else
                            {
                                strPrintOrder += Space(9 - encodelen(tStr)) + tStr;
                            }

                            strPrintOrder += "\r\n";


                            // 옵션아이템
                            if (arr[i]["optionNo"].ToString() != "")
                            {
                                sUrl = "orderOptionItem?siteId=" + mSiteId + "&optionNo=" + arr[i]["optionNo"].ToString();
                                if (mRequestGet(sUrl))
                                {
                                    if (mObj["resultCode"].ToString() == "200")
                                    {
                                        String data2 = mObj["orderOptionItems"].ToString();
                                        JArray arr2 = JArray.Parse(data2);


                                        String tOptionName = "  ";
                                        for (int k = 0; k < arr2.Count; k++)
                                        {
                                            tOptionName += arr2[k]["optionItemName"].ToString() + " ";
                                        }

                                        String tOptionAmt = option_amt.ToString("N0");     //단가


                                        int tLenOptionNameAmt = encodelen(tOptionName) + encodelen(tOptionAmt);


                                        if (tLenOptionNameAmt > 27)
                                        {
                                            if (encodelen(tOptionName) > 42)
                                                strPrintOrder += tOptionName + "\r\n";
                                            else
                                                strPrintOrder += tOptionName + Space(42 - encodelen(tOptionName)) + "\r\n";


                                            strPrintOrder += Space(18) + Space(9 - encodelen(tOptionAmt)) + tOptionAmt;
                                        }
                                        else
                                        {
                                            strPrintOrder += tOptionName + Space(27 - tLenOptionNameAmt) + tOptionAmt;
                                        }


                                        tStr = cnt.ToString("N0");     // 수량
                                        strPrintOrder += Space(6 - encodelen(tStr)) + tStr;

                                        tStr = (option_amt * cnt).ToString("N0");     // 금액 = 단가*수량
                                        strPrintOrder += Space(9 - encodelen(tStr)) + tStr;

                                        strPrintOrder += "\r\n";
                                    }
                                }
                            }


                            // 할인
                            if (dcr_type == "A")
                            {
                                tStr = "  할인";
                                strPrintOrder += tStr + Space(21 - encodelen(tStr));

                                tStr = (-dc_amt).ToString("N0");        // 할인 정액
                                strPrintOrder += Space(21 - encodelen(tStr)) + tStr;

                                strPrintOrder += "\r\n";
                            }
                            else if (arr[i]["dcrType"].ToString() == "R")
                            {
                                tStr = "  할인-" + arr[i]["dcrValue"].ToString() + "%";
                                strPrintOrder += tStr + Space(21 - encodelen(tStr));

                                tStr = (-dc_amt).ToString("N0");        // 할인 정액
                                strPrintOrder += Space(21 - encodelen(tStr)) + tStr;

                                strPrintOrder += "\r\n";
                            }

                            // [여기]
                        }


                        //?  전체할인인 경우 과세가액 계산.. 아래로직을 [여기]로 옮겨야하나??
                        if (arr[i]["taxFree"].ToString() == "Y") t면세가액 += ((cnt * (amt + option_amt)) - dc_amt);
                        else t과세가액 += ((cnt * (amt + option_amt)) - dc_amt);

                        //
                        t할인금액 += dc_amt;
                    }
                }
                else
                {
                    MessageBox.Show("주문 데이터 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                }
            }
            else
            {
                MessageBox.Show("시스템오류. orderItem\n\n" + mErrorMsg, "thepos");
            }


            //
            strPrintPayment = "------------------------------------------\r\n";  // 42

            if (t면세가액 > 0)
            {
                tStr = "*면세품목가액";
                strPrintPayment += tStr + Space(21 - encodelen(tStr));

                tStr = (t면세가액).ToString("N0");
                strPrintPayment += Space(21 - encodelen(tStr)) + tStr;

                strPrintPayment += "\r\n";
            }

            if (t과세가액 > 0)  // 공급가액
            {
                int t_tax = t과세가액 / 11;   // 부가세액
                int t_amt = t과세가액 - t_tax; // 공급가액

                tStr = "과세품목가액";
                strPrintPayment += tStr + Space(21 - encodelen(tStr));
                tStr = (t_amt).ToString("N0");
                strPrintPayment += Space(21 - encodelen(tStr)) + tStr;
                strPrintPayment += "\r\n";

                tStr = "부가세액";
                strPrintPayment += tStr + Space(21 - encodelen(tStr));
                tStr = (t_tax).ToString("N0");
                strPrintPayment += Space(21 - encodelen(tStr)) + tStr;
                strPrintPayment += "\r\n";
            }

            strPrintPayment += "------------------------------------------\r\n";  // 42

            int tsum = t과세가액 + t면세가액 + t할인금액;
            int tnet = tsum - t할인금액;


            tStr = "총합계";
            strPrintPayment += tStr + Space(21 - encodelen(tStr));
            tStr = (tsum).ToString("N0");
            strPrintPayment += Space(21 - encodelen(tStr)) + tStr;
            strPrintPayment += "\r\n";

            tStr = "할인계";
            strPrintPayment += tStr + Space(21 - encodelen(tStr));
            tStr = (-t할인금액).ToString("N0");
            strPrintPayment += Space(21 - encodelen(tStr)) + tStr;
            strPrintPayment += "\r\n";

            tStr = "결제대상금액";
            strPrintPayment += tStr + Space(21 - encodelen(tStr));
            tStr = (tnet).ToString("N0");
            strPrintPayment += Space(21 - encodelen(tStr)) + tStr;
            strPrintPayment += "\r\n";

            strPrintPayment += "------------------------------------------\r\n";  // 42



            //! 현금결제
            if (pay_keep_cash == "1")
            {
                sUrl = "paymentCash?siteId=" + mSiteId + "&theNo=" + tTheNo;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["paymentCashs"].ToString();
                        JArray arr = JArray.Parse(data);

                        for (int i = 0; i < arr.Count; i++)
                        {
                            if (arr[i]["tranType"].ToString() == tranType)
                            {
                                int amount = convert_number(arr[i]["amount"].ToString());


                                if (arr[i]["payType"].ToString() == "R0") // 단순현금
                                {

                                    tStr = "현금";

                                    if (tranType == "C")
                                    {
                                        tStr += "취소";
                                    }

                                    strPrintPayment += tStr + Space(21 - encodelen(tStr));

                                    if (tranType == "C")
                                        tStr = (-amount).ToString("N0");
                                    else
                                        tStr = amount.ToString("N0");

                                    strPrintPayment += Space(21 - encodelen(tStr)) + tStr;

                                }
                                else if (arr[i]["payType"].ToString() == "R1") // 현금영수증
                                {
                                    tStr = "현금영수증";

                                    if (tranType == "C")
                                    {
                                        tStr += "취소";
                                    }

                                    strPrintPayment += tStr + Space(21 - encodelen(tStr));

                                    if (tranType == "C")
                                        tStr = (-amount).ToString("N0");
                                    else
                                        tStr = amount.ToString("N0");

                                    strPrintPayment += Space(21 - encodelen(tStr)) + tStr;
                                    strPrintPayment += "\r\n";

                                    if (arr[i]["receiptType"].ToString() == "1") // 소득공제
                                    {
                                        tStr = "소득공제";
                                    }
                                    else if (arr[i]["receiptType"].ToString() == "2") // 지출증빙
                                    {
                                        tStr = "지출증빙";
                                    }
                                    else if (arr[i]["receiptType"].ToString() == "S") //? 자진밝급
                                    {
                                        tStr = "자진발급";
                                    }

                                    strPrintPayment += tStr + Space(21 - encodelen(tStr));

                                    String no = arr[i]["issuedMethodNo"].ToString() + "";

                                    if (no.Contains('*'))
                                    {
                                        tStr = no;
                                    }
                                    else if (no.Length == 16)
                                    {
                                        tStr = no.Substring(0, 4) + "-" + no.Substring(4, 4) + "-****-" + no.Substring(12, 3) + "*";
                                    }
                                    else if (no.Length == 11)
                                    {
                                        if (no.Substring(0, 3) == "010")
                                        {
                                            tStr = no.Substring(0, 3) + "-****-" + no.Substring(6, 4);
                                        }
                                        else
                                        {
                                            tStr = no.Substring(0, 8) + CharCount('*', no.Length - 8);
                                        }
                                    }
                                    else if (no.Length > 8)
                                    {
                                        tStr = no.Substring(0, 8) + CharCount('*', no.Length - 8);
                                    }
                                    else
                                    {
                                        tStr = no;
                                    }

                                    strPrintPayment += Space(21 - encodelen(tStr)) + tStr;
                                }

                                strPrintPayment += "\r\n";
                                strPrintPayment += "\r\n";
                            }
                        }
                    }
                }
            }


            //! 카드결제
            if (pay_keep_card == "1")
            {
                sUrl = "paymentCard?siteId=" + mSiteId + "&theNo=" + tTheNo;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["paymentCards"].ToString();
                        JArray arr = JArray.Parse(data);

                        for (int i = 0; i < arr.Count; i++)
                        {
                            if (arr[i]["tranType"].ToString() == tranType)
                            {
                                if (arr[i]["payType"].ToString() == "C1") tStr = "카드결제";
                                else if (arr[i]["payType"].ToString() == "C0") tStr = "카드결제";  // 임의등록

                                if (tranType == "C")
                                {
                                    tStr += "취소";
                                }

                                int amount = convert_number(arr[i]["amount"].ToString());


                                strPrintPayment += tStr + Space(21 - encodelen(tStr));

                                if (tranType == "C")
                                    tStr = (-amount).ToString("N0");
                                else
                                    tStr = amount.ToString("N0");

                                strPrintPayment += Space(21 - encodelen(tStr)) + tStr;
                                strPrintPayment += "\r\n";

                                tStr = arr[i]["cardName"].ToString().Trim();
                                strPrintPayment += tStr + Space(21 - encodelen(tStr));

                                String no = arr[i]["cardNo"].ToString();


                                if (no.Contains('*'))
                                {
                                    tStr = no;
                                }
                                else if (no.Length == 16)
                                {
                                    tStr = no.Substring(0, 4) + "-" + no.Substring(4, 4) + "-****-" + no.Substring(12, 3) + "*";
                                }
                                else if (no.Length > 8)
                                {
                                    tStr = no.Substring(0, 8) + CharCount('*', no.Length - 8);
                                }
                                else
                                {
                                    tStr = no;
                                }

                                strPrintPayment += Space(21 - encodelen(tStr)) + tStr;
                                strPrintPayment += "\r\n";

                                if (arr[i]["install"].ToString() == "00")
                                    tStr = "할부개월:일시불";
                                else
                                    tStr = "할부개월:" + arr[i]["install"].ToString();

                                strPrintPayment += tStr + Space(21 - encodelen(tStr));
                                tStr = "승인번호:" + arr[i]["authNo"].ToString().Trim();
                                strPrintPayment += Space(21 - encodelen(tStr)) + tStr;
                                strPrintPayment += "\r\n";
                                strPrintPayment += "\r\n";

                            }

                        }
                    }
                }
            }


            //! 포인트
            if (pay_keep_point == "1")
            {
                sUrl = "paymentPoint?siteId=" + mSiteId + "&theNo=" + tTheNo;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["paymentPoints"].ToString();
                        JArray arr = JArray.Parse(data);

                        for (int i = 0; i < arr.Count; i++)
                        {

                            //? 포인트 취소인 경우 잘되는지 다시 확인바람
                            int amount = convert_number(arr[i]["amount"].ToString());

                            if (arr[i]["payType"].ToString() == "PA") // 선불 포인트
                            {
                                tStr = "포인트";
                            }
                            else if (arr[i]["payType"].ToString() == "PD") // 후불 포인트
                            {
                                tStr = "포인트";
                            }

                            if (arr[i]["isCancel"].ToString() == "Y")
                            {
                                tStr += "취소";
                            }

                            strPrintPayment += tStr + Space(21 - encodelen(tStr));

                            if (arr[i]["isCancel"].ToString() == "Y")
                                tStr = (-amount).ToString("N0");
                            else
                                tStr = amount.ToString("N0");

                            strPrintPayment += Space(21 - encodelen(tStr)) + tStr;

                            strPrintPayment += "\r\n";
                            strPrintPayment += "\r\n";

                        }
                    }
                }
            }


            //? 간편결제
            if (pay_keep_easy == "1")
            {
                sUrl = "paymentEasy?siteId=" + mSiteId + "&theNo=" + tTheNo;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["paymentEasys"].ToString();
                        JArray arr = JArray.Parse(data);

                        for (int i = 0; i < arr.Count; i++)
                        {
                            if (arr[i]["tranType"].ToString() == tranType)
                            {
                                tStr = "";
                                if (arr[i]["payType"].ToString() == "E1") tStr = "간편결제";

                                if (tranType == "C")
                                {
                                    tStr += "취소";
                                }

                                int amount = convert_number(arr[i]["amount"].ToString());


                                strPrintPayment += tStr + Space(21 - encodelen(tStr));

                                if (tranType == "C")
                                    tStr = (-amount).ToString("N0");
                                else
                                    tStr = amount.ToString("N0");

                                strPrintPayment += Space(21 - encodelen(tStr)) + tStr;
                                strPrintPayment += "\r\n";

                                tStr = arr[i]["cardName"].ToString();
                                strPrintPayment += tStr + Space(21 - encodelen(tStr));

                                String no = arr[i]["cardNo"].ToString();


                                if (no.Contains('*'))
                                {
                                    tStr = no;
                                }
                                else if (no.Length == 16)
                                {
                                    tStr = no.Substring(0, 4) + "-" + no.Substring(4, 4) + "-****-" + no.Substring(12, 3) + "*";
                                }
                                else if (no.Length > 8)
                                {
                                    tStr = no.Substring(0, 8) + CharCount('*', no.Length - 8);
                                }
                                else
                                {
                                    tStr = no;
                                }

                                strPrintPayment += Space(21 - encodelen(tStr)) + tStr;
                                strPrintPayment += "\r\n";


                                tStr = "";
                                strPrintPayment += tStr + Space(21 - encodelen(tStr));
                                tStr = "승인번호:" + arr[i]["authNo"].ToString();
                                strPrintPayment += Space(21 - encodelen(tStr)) + tStr;
                                strPrintPayment += "\r\n";
                                strPrintPayment += "\r\n";

                            }
                        }
                    }
                }
            }

            //?#  쿠폰인증 추가개발 필요
            if (pay_keep_cert == "1")
            {
                sUrl = "paymentCert?siteId=" + mSiteId + "&theNo=" + tTheNo;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["paymentCerts"].ToString();
                        JArray arr = JArray.Parse(data);

                        for (int i = 0; i < arr.Count; i++)
                        {
                            if (arr[i]["tranType"].ToString() == tranType)
                            {
                                tStr = "";
                                if (arr[i]["payType"].ToString() == "M0") tStr = "쿠폰";

                                if (tranType == "C")
                                {
                                    tStr += "취소";
                                }

                                int amount = convert_number(arr[i]["amount"].ToString());


                                strPrintPayment += tStr + Space(21 - encodelen(tStr));

                                if (tranType == "C")
                                    tStr = (-amount).ToString("N0");
                                else
                                    tStr = amount.ToString("N0");

                                strPrintPayment += Space(21 - encodelen(tStr)) + tStr;
                                strPrintPayment += "\r\n";


                                tStr = arr[i]["vanCode"].ToString();
                                strPrintPayment += tStr + Space(21 - encodelen(tStr));

                                tStr = arr[i]["couponNo"].ToString();
                                strPrintPayment += Space(21 - encodelen(tStr)) + tStr;
                                strPrintPayment += "\r\n";

                            }
                        }
                    }
                }
            }


            strPrintPayment += "------------------------------------------\r\n";  // 42

            if (except_order == "Y")
            {
                return strPrintHeader + strPrintPayment;
            }
            else
            {
                return strPrintHeader + strPrintOrder + strPrintPayment;
            }
        }



        public static Boolean isPreCheck(out String error_msg)
        {
            error_msg = "";

            String sUrl = "preCheck?siteId=" + mSiteId + "&posNo=" + myPosNo + "&bizDt=" + mBizDate;

            try
            {
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["preCheck"].ToString();
                        JArray arr = JArray.Parse(data);

                        String resp_code = arr[0]["respCode"].ToString();

                        if (resp_code == "00")
                        {
                            return true;
                        }
                        else
                        {
                            error_msg = "관리자 문의바랍니다.\r\n" + arr[0]["respMsg"].ToString(); // 99 : 마감후 집계완료상태입니다.
                            return false;
                        }
                    }
                    else if (mObj["resultCode"].ToString() == "660")
                    {
                        error_msg = "관리자 문의바랍니다.\r\n영업일자 검증 오류. 재로그인 필요합니다.";
                        return false;
                    }
                    else
                    {
                        error_msg = "관리자 문의바랍니다.\r\n시스템오류. 영업개시 검증 오류";
                        return false;
                    }
                }
                else
                {
                    error_msg = "관리자 문의바랍니다.\r\n시스템오류. 영업개시 검증 오류";
                    return false;
                }
            }
            catch (Exception e)
            {
                error_msg = e.Message;

                return false;
            }


        }


        public static void countup_the_no()
        {
            //! 재기동시 초기화된 이후의 연속성. -> 서버에 물어본다.  last_the_no(); xxxxx
            //mTheNo = mSiteId + mBizDate + mPosNo + (++mBillTheNo).ToString("0000"); XXXX
            //mTheNo = mSiteId + mBizDate + mPosNo + get_today_time();  xxxx

            // 일련번호 -> Time(6) 변경
            // 일련번호 -> 일초누적(5) + 1/10초(1)


            var timeSpan = (DateTime.Now - new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0, 0));
            String seconddiff = ((long)timeSpan.TotalMilliseconds).ToString("00000000").Substring(0, 6);


            mTheNo = mSiteId + mBizDate + myPosNo + seconddiff;


            // 동잀하게 세팅후 -> 이후 필요시 별도세팅
            mRefNo = mTheNo;
            // the_no : 결제단위 - cash card complex point easy 결제버튼을 누른경우 새로운 the_no부여
            // ref_no : 입장단위 - 포인트 충전 정산의 경우 티켓번호 18자리로 세트
        }


        public static bool get_amounts(out int t과세금액, out int t면세금액)
        {
            // 결제진행시 과세 면세 부가세 계산을 위해서..
            // 주문금액 과세금액 부가세액 면세금액

            t과세금액 = 0;// 부가세 포함 금액
            t면세금액 = 0;
            int t전체할인금액 = 0;

            for (int i = 0; i < mOrderItemList.Count; i++)
            {
                MemOrderItem orderItemInfo = mOrderItemList[i];

                if (orderItemInfo.dcr_des == "E") // 전체할인
                {
                    t전체할인금액 = orderItemInfo.dc_amount;
                }
                else
                {
                    if (orderItemInfo.taxfree == "Y")
                    {
                        t면세금액 += (((orderItemInfo.amt + orderItemInfo.option_amt) * orderItemInfo.cnt) - orderItemInfo.dc_amount);
                    }
                    else
                    {
                        t과세금액 += (((orderItemInfo.amt + orderItemInfo.option_amt) * orderItemInfo.cnt) - orderItemInfo.dc_amount);
                    }
                }
            }

            if (t전체할인금액 > 0)
            {
                if (t전체할인금액 < t과세금액)
                {
                    t과세금액 -= t전체할인금액;
                }
                else
                {
                    t면세금액 -= (t전체할인금액 - t과세금액);
                    t과세금액 = 0;
                }
            }

            return true;
        }


        public static bool isExistOrderPrinter(String shop_code)
        {
            if (shop_code == "")
            {
                return false;
            }

            //
            for (int i = 0; i < mShop.Length; i++)
            {
                if (mShop[i].shop_code == shop_code)
                {
                    if (mShop[i].printer_type == "")
                        return false;
                    else
                        return true;
                }
            }

            return false;
        }


        public static bool set_shop_order_no_on_orderitem()
        {

            List<String> shop_code_list = new List<String>();
            List<String> order_no_list = new List<String>();


            try
            {
                for (int i = 0; i < mOrderItemList.Count; i++)
                {
                    if (mOrderItemList[i].dcr_des != "E")
                    {
                        shop_code_list.Add(mOrderItemList[i].shop_code);
                    }
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
                        if (mOrderItemList[i].shop_code == shop_code_list[k] & mOrderItemList[i].ticket != "Y")
                        {
                            MemOrderItem orderItem = mOrderItemList[i];
                            orderItem.shop_order_no = order_no_list[k];
                            mOrderItemList[i] = orderItem;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                thepos_app_log(3, "frmSales", "set_shop_order_no_on_orderitem()", e.Message);



                return false;
            }

            return true;


        }

        private static String get_new_order_no()
        {
            String order_no = "";

            try
            {
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
                        MessageBox.Show("데이터 오류. orderNo\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류. orderNo\n\n" + mErrorMsg, "thepos");
                }

                return order_no;
            }
            catch (Exception e)
            {
                thepos_app_log(1, "frmSales", "get_new_order_no()", e.Message);

                return order_no;
            }

        }



        public static int SaveOrder(String ticket_no)  // Server
        {

            Dictionary<string, string> parameters = new Dictionary<string, string>();

            // order
            try
            {
                parameters.Clear();
                parameters["siteId"] = mSiteId;
                parameters["posNo"] = myPosNo;
                parameters["bizDt"] = mBizDate;
                parameters["theNo"] = mTheNo;
                parameters["refNo"] = mRefNo;
                parameters["tranType"] = "A";
                parameters["orderDate"] = get_today_date();
                parameters["orderTime"] = get_today_time();
                parameters["cnt"] = mOrderItemList.Count + "";
                parameters["isCancel"] = "";
                parameters["userId"] = mUserID;
                if (mRequestPost("orders", parameters))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                    }
                    else
                    {
                        MessageBox.Show("오류 order\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return -1;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                    return -1;
                }
            }
            catch (Exception e)
            {
                thepos_app_log(1, "frmSales", "SaveOrder() orders", e.Message);

                return -1;
            }


            // orderShop
            try
            {
                List<string> shop_code_list = new List<string>();

                for (int i = 0; i < mOrderItemList.Count; i++)
                {
                    shop_code_list.Add(mOrderItemList[i].shop_code);
                }

                shop_code_list = shop_code_list.Distinct().ToList();


                int order_shop_cnt = 0;
                int allim_cnt = 0;
                String shop_order_no = "";
                String is_allim = "";

                for (int i = 0; i < shop_code_list.Count; i++)
                {
                    order_shop_cnt = 0;
                    shop_order_no = "";
                    allim_cnt = 0;

                    for (int k = 0; k < mOrderItemList.Count; k++)
                    {
                        if (mOrderItemList[k].shop_code == shop_code_list[i])
                        {
                            order_shop_cnt++;
                            shop_order_no = mOrderItemList[k].shop_order_no + "";

                            if (mOrderItemList[k].allim == "Y")
                            {
                                is_allim = "Y";
                                allim_cnt++;
                            }
                        }
                    }

                    parameters.Clear();
                    parameters["siteId"] = mSiteId;
                    parameters["posNo"] = myPosNo;
                    parameters["bizDt"] = mBizDate;
                    parameters["theNo"] = mTheNo;
                    parameters["refNo"] = mRefNo;
                    parameters["orderDate"] = get_today_date();
                    parameters["orderTime"] = get_today_time();
                    parameters["order_cnt"] = order_shop_cnt + "";
                    parameters["cnt"] = allim_cnt + "";
                    parameters["isCancel"] = "";
                    parameters["shopCode"] = shop_code_list[i] + "";
                    parameters["shopOrderNo"] = shop_order_no;

                    parameters["allim"] = is_allim;

                    parameters["orderAllimType"] = "";
                    parameters["orderAllimStatus"] = "0";
                    parameters["orderAllimMemo"] = "";

                    if (mRequestPost("orderShop", parameters))
                    {
                        if (mObj["resultCode"].ToString() == "200")
                        {
                        }
                        else
                        {
                            MessageBox.Show("오류 order\n\n" + mObj["resultMsg"].ToString(), "thepos");
                            return -1;
                        }
                    }
                    else
                    {
                        MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                        return -1;
                    }
                }
            }
            catch (Exception e)
            {
                thepos_app_log(1, "frmSales", "SaveOrder() orderShop", e.Message);
                return -1;
            }



            // orderItem
            for (int i = 0; i < mOrderItemList.Count; i++)
            {
                String t_option_no = "";

                if (mOrderItemList[i].option_item_cnt > 0)
                {
                    if (mOrderItemList[i].orderOptionItemList.Count > 0)
                    {
                        t_option_no = mTheNo + i.ToString("00");
                    }
                }


                try
                {
                    parameters.Clear();
                    parameters["siteId"] = mSiteId;
                    parameters["posNo"] = myPosNo;
                    parameters["bizDt"] = mBizDate;
                    parameters["theNo"] = mTheNo;
                    parameters["refNo"] = mRefNo;
                    parameters["tranType"] = "A";
                    parameters["orderDate"] = get_today_date();
                    parameters["orderTime"] = get_today_time();
                    parameters["goodsCode"] = mOrderItemList[i].goods_code;

                    //#
                    if (mLanguageNo == 0)
                        parameters["goodsName"] = mOrderItemList[i].goods_name;
                    else
                        parameters["goodsName"] = get_goods_name(mOrderItemList[i].goods_code);

                    parameters["cnt"] = mOrderItemList[i].cnt + "";
                    parameters["amt"] = mOrderItemList[i].amt + "";
                    parameters["optionAmt"] = mOrderItemList[i].option_amt + "";   //
                    parameters["ticketYn"] = mOrderItemList[i].ticket;
                    parameters["taxFree"] = mOrderItemList[i].taxfree;
                    parameters["allim"] = mOrderItemList[i].allim;
                    parameters["dcAmount"] = mOrderItemList[i].dc_amount + "";
                    parameters["dcrType"] = mOrderItemList[i].dcr_type;
                    parameters["dcrDes"] = mOrderItemList[i].dcr_des;
                    parameters["dcrValue"] = mOrderItemList[i].dcr_value + "";
                    parameters["payClass"] = mPayClass;  //

                    parameters["ticketNo"] = ticket_no;  //

                    parameters["isCancel"] = "";
                    parameters["shopCode"] = mOrderItemList[i].shop_code;
                    parameters["nodCode1"] = mOrderItemList[i].nod_code1;
                    parameters["nodCode2"] = mOrderItemList[i].nod_code2;

                    parameters["shopOrderNo"] = mOrderItemList[i].shop_order_no;  // 업장주문번호
                    parameters["optionNo"] = t_option_no;

                    if (mRequestPost("orderItem", parameters))
                    {
                        if (mObj["resultCode"].ToString() == "200")
                        {
                        }
                        else
                        {
                            MessageBox.Show("오류 orderItem\n\n" + mObj["resultMsg"].ToString(), "thepos");
                            return -1;
                        }
                    }
                    else
                    {
                        MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                        return -1;
                    }
                }
                catch (Exception e)
                {
                    thepos_app_log(1, "frmSales", "SaveOrder() orderItem", e.Message);
                    return -1;
                }





                // 옵션상품 경우
                for (int k = 0; k < mOrderItemList[i].orderOptionItemList.Count; k++)
                {
                    try
                    {
                        parameters.Clear();
                        parameters["siteId"] = mSiteId;
                        parameters["posNo"] = myPosNo;
                        parameters["bizDt"] = mBizDate;
                        parameters["theNo"] = mTheNo;
                        parameters["refNo"] = mRefNo;
                        parameters["optionNo"] = t_option_no;

                        parameters["orderDate"] = get_today_date();
                        parameters["orderTime"] = get_today_time();

                        parameters["goodsCode"] = mOrderItemList[i].goods_code;
                        parameters["optionCode"] = mOrderItemList[i].orderOptionItemList[k].option_code;
                        parameters["optionItemNo"] = mOrderItemList[i].orderOptionItemList[k].option_item_no + "";

                        //#
                        if (mLanguageNo == 0)
                        {
                            parameters["optionName"] = mOrderItemList[i].orderOptionItemList[k].option_name;
                            parameters["optionItemName"] = mOrderItemList[i].orderOptionItemList[k].option_item_name;
                        }
                        else
                        {
                            parameters["optionName"] = get_goods_option_name(mOrderItemList[i].goods_code, mOrderItemList[i].orderOptionItemList[k].option_code);
                            parameters["optionItemName"] = get_goods_option_item_name(mOrderItemList[i].goods_code, mOrderItemList[i].orderOptionItemList[k].option_code, mOrderItemList[i].orderOptionItemList[k].option_item_no);
                        }

                        parameters["cnt"] = mOrderItemList[i].cnt + "";
                        parameters["amt"] = mOrderItemList[i].orderOptionItemList[k].amt + "";
                        parameters["isCancel"] = "";

                        if (mRequestPost("orderOptionItem", parameters))
                        {
                            if (mObj["resultCode"].ToString() == "200")
                            {
                            }
                            else
                            {
                                MessageBox.Show("오류 orderOptionItem\n\n" + mObj["resultMsg"].ToString(), "thepos");
                                return -1;
                            }
                        }
                        else
                        {
                            MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                            return -1;
                        }
                    }
                    catch (Exception e)
                    {
                        thepos_app_log(1, "frmSales", "SaveOrder() orderOptionItem", e.Message);
                        return -1;
                    }

                }
            }

            return mOrderItemList.Count;
        }


        public static bool SavePayment(int paySeq, String payType, int amount, int dcAmount) // server
        {
            //
            Dictionary<string, string> parameters = new Dictionary<string, string>();


            try
            {
                parameters.Clear();
                parameters["siteId"] = mSiteId;
                parameters["shopCode"] = myShopCode;
                parameters["posNo"] = myPosNo;
                parameters["bizDt"] = mBizDate;
                parameters["theNo"] = mTheNo;
                parameters["refNo"] = mRefNo;
                parameters["payDate"] = get_today_date();
                parameters["payTime"] = get_today_time();
                parameters["tranType"] = "A";
                parameters["payClass"] = mPayClass;
                parameters["billNo"] = mTheNo.Substring(14, 6);
                parameters["netAmount"] = amount + "";


                String is_cash = "0", is_card = "0", is_easy = "0", is_point = "0", is_cert = "0";
                int amount_cash = 0, amount_card = 0, amount_easy = 0, amount_point = 0, amount_cert = 0;

                if (payType == "Cash") { is_cash = "1"; amount_cash = amount; }
                else if (payType == "Card") { is_card = "1"; amount_card = amount; }
                else if (payType == "Easy") { is_easy = "1"; amount_easy = amount; }
                else if (payType == "Point") { is_point = "1"; amount_point = amount; }
                else if (payType == "Cert") { is_cert = "1"; amount_cert = amount; }

                parameters["amountCash"] = amount_cash + "";
                parameters["amountCard"] = amount_card + "";
                parameters["amountEasy"] = amount_easy + "";
                parameters["amountPoint"] = amount_point + "";
                parameters["amountCert"] = amount_cert + "";

                parameters["isCash"] = is_cash;
                parameters["isCard"] = is_card;
                parameters["isEasy"] = is_easy;
                parameters["isPoint"] = is_point;
                parameters["isCert"] = is_cert;

                parameters["dcAmount"] = dcAmount + "";
                parameters["isCancel"] = "";


                if (mRequestPost("payment", parameters))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {

                    }
                    else
                    {
                        MessageBox.Show("오류 payment\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류 payment\n\n" + mErrorMsg, "thepos");
                    return false;
                }
            }
            catch (Exception e)
            {
                thepos_app_log(1, "frmSales", "SavePayment()", e.Message);
                return false;
            }



            return true;

        }


        public static String[] print_order(ref List<shop_order_pack> shopOrderPackList)
        {
            shopOrderPackList.Clear();

            String[] return_order_no_arr = new string[2];

            return_order_no_arr[0] = "";   // 첫주문번호
            return_order_no_arr[1] = "";   // 마지막주문번호

            int shop_order_count = 0;


            for (int i = 0; i < mOrderItemList.Count; i++)
            {
                if (mOrderItemList[i].dcr_des != "E")  // "E" 전체할인
                {
                    shop_order_count++;


                    //???? 임시 하드코딩 : 
                    /*
                    if (mSiteId == "2502")
                    {
                        if (mOrderItemList[i].shop_code == "FB")
                        {
                            if (mOrderItemList[i].nod_code1 == "41")
                            {
                                shop_order_count++;
                            }
                            else
                            {
                                // 레스토랑외 제외
                            }
                        }
                        else
                        {
                            shop_order_count++;
                        }
                    }
                    else
                    {
                        shop_order_count++;
                    }
                    */
                }
            }



            MemOrderItem[] orderItemArr = new MemOrderItem[shop_order_count];

            int t_cnt = 0;

            for (int i = 0; i < mOrderItemList.Count; i++)
            {
                if (mOrderItemList[i].dcr_des != "E")  // "E" 전체할인
                {

                    //???? 임시 하드코딩 : 
                    /*
                    if (mSiteId == "2502")
                    {
                        if (mOrderItemList[i].shop_code == "FB")
                        {
                            if (mOrderItemList[i].nod_code1 == "41")
                            {
                                orderItemArr[t_cnt] = mOrderItemList[i];
                                t_cnt++;
                            }
                            else
                            {
                                // 레스토랑외 제외
                            }
                        }
                        else
                        {
                            orderItemArr[t_cnt] = mOrderItemList[i];
                            t_cnt++;
                        }
                    }
                    else
                    {
                        orderItemArr[t_cnt] = mOrderItemList[i];
                        t_cnt++;
                    }
                    */

                    orderItemArr[t_cnt] = mOrderItemList[i];
                    t_cnt++;

                }
            }


            if (orderItemArr.Length == 0)
                return return_order_no_arr;



            // 업장코드별로 정렬
            bool order_sort_complete = false;
            MemOrderItem memOrderItemTemp;

            while (!order_sort_complete)
            {
                order_sort_complete = true;
                for (int i = 0; i < orderItemArr.Length - 1; i++)
                {
                    if (string.Compare(orderItemArr[i].shop_order_no, orderItemArr[i + 1].shop_order_no) == 1)  // ascending
                    {
                        memOrderItemTemp = orderItemArr[i];
                        orderItemArr[i] = orderItemArr[i + 1];
                        orderItemArr[i + 1] = memOrderItemTemp;

                        order_sort_complete = false;
                    }
                }
            }



            // 



            List<order_pack> orderPackList = new List<order_pack>();


            List<String> option_name_list = new List<String>();
            List<String> option_item_name_list = new List<String>();

            String t_shop_code = "";
            String t_order_no = "";
            String t_order_dt = get_today_date() + get_today_time();

            t_shop_code = orderItemArr[0].shop_code;
            t_order_no = orderItemArr[0].shop_order_no;

            // 첫주문번호
            return_order_no_arr[0] = t_order_no;

            //
            order_pack orderPack1 = new order_pack();
            orderPack1.goods_name = orderItemArr[0].goods_name;
            orderPack1.goods_code = orderItemArr[0].goods_code;
            orderPack1.allim = orderItemArr[0].allim;
            orderPack1.goods_cnt = orderItemArr[0].cnt;
            orderPack1.nod_code1 = orderItemArr[0].nod_code1;  //????

            for (int k = 0; k < orderItemArr[0].orderOptionItemList.Count; k++)
            {
                option_name_list.Add(orderItemArr[0].orderOptionItemList[k].option_name);
                option_item_name_list.Add(orderItemArr[0].orderOptionItemList[k].option_item_name);
            }

            orderPack1.option_name = option_name_list.ToList();
            orderPack1.option_item_name = option_item_name_list.ToList();

            orderPackList.Add(orderPack1);



            for (int i = 0; i < orderItemArr.Length - 1; i++)
            {
                if (string.Compare(orderItemArr[i].shop_order_no, orderItemArr[i + 1].shop_order_no) == 0)
                {

                }
                else
                {
                    shop_order_pack shopOrderPack1 = new shop_order_pack();
                    shopOrderPack1.shop_code = t_shop_code;
                    shopOrderPack1.order_no = t_order_no;
                    shopOrderPack1.order_dt = t_order_dt;
                    shopOrderPack1.orderPackList = orderPackList.ToList();

                    shopOrderPackList.Add(shopOrderPack1);



                    //
                    orderPackList.Clear();
                    t_shop_code = orderItemArr[i + 1].shop_code;
                    t_order_no = orderItemArr[i + 1].shop_order_no;

                }



                //
                order_pack orderPack2 = new order_pack();
                orderPack2.goods_name = orderItemArr[i + 1].goods_name;
                orderPack2.goods_code = orderItemArr[i + 1].goods_code;
                orderPack2.allim = orderItemArr[i + 1].allim;
                orderPack2.goods_cnt = orderItemArr[i + 1].cnt;

                option_name_list.Clear();
                option_item_name_list.Clear();

                for (int k = 0; k < orderItemArr[i + 1].orderOptionItemList.Count; k++)
                {
                    option_name_list.Add(orderItemArr[i + 1].orderOptionItemList[k].option_name);
                    option_item_name_list.Add(orderItemArr[i + 1].orderOptionItemList[k].option_item_name);
                }

                orderPack2.option_name = option_name_list.ToList();
                orderPack2.option_item_name = option_item_name_list.ToList();

                orderPackList.Add(orderPack2);
            }



            shop_order_pack shopOrderPack2 = new shop_order_pack();
            shopOrderPack2.shop_code = t_shop_code;
            shopOrderPack2.order_no = t_order_no;
            shopOrderPack2.order_dt = t_order_dt;
            shopOrderPack2.orderPackList = orderPackList.ToList();

            shopOrderPackList.Add(shopOrderPack2);




            // 마지막주문번호
            return_order_no_arr[1] = t_order_no;



            for (int i = 0; i < shopOrderPackList.Count; i++)
            {
                String is_allim = "";

                for (int k = 0; k < shopOrderPackList[i].orderPackList.Count; k++)
                {
                    if (shopOrderPackList[i].orderPackList[k].allim == "Y")
                    {
                        is_allim = "Y";
                    }
                }


                if (is_allim == "Y")  // 상품중에 하나이상의 알림상품이 있어야 출력
                {
                    // 업장주문서 출력 -> shop 등록정보 프린터
                    print_order_str("to_shop", "주문서", shopOrderPackList[i]);


                    // 주문교환권 출력 -> 영수증프린터 : 함수내부에서 출력타입 Print Display 구분한다. 
                    print_order_str("to_local", "교환권", shopOrderPackList[i]);
                }


            }


            return return_order_no_arr;

        }

        public static void print_order_str(String to_printer, String title, shop_order_pack shopOrderPack)  // 주문서
        {
            String printer_type = "";
            String printer_name = "";



            shop_order_pack shopOrderPackPrint = JsonConvert.DeserializeObject<shop_order_pack>(
                JsonConvert.SerializeObject(shopOrderPack)
            );



            try
            {
                if (to_printer == "to_shop")  // 주문서
                {
                    for (int i = 0; i < mShop.Length; i++)
                    {
                        if (mShop[i].shop_code == shopOrderPackPrint.shop_code)
                        {
                            printer_type = mShop[i].printer_type;

                            if (mShop[i].printer_type == "N") printer_name = mShop[i].network_printer_name;    // Network
                            else if (mShop[i].printer_type == "L") printer_name = mBillPrinterPort;                 // Local
                            else
                            {
                                return;
                            }
                        }
                    }

                    //???? 하드코딩 : 키벤저스 F&B 주문서 출력 예외처리 - 레스토랑 메뉴만 주방주문서 출력한다.
                    if (mSiteId == "2502" & shopOrderPackPrint.shop_code == "FB")
                    {
                        for (int i = shopOrderPackPrint.orderPackList.Count - 1; i >= 0; i--)
                        {
                            if (shopOrderPackPrint.orderPackList[i].nod_code1 + "" != "41")
                            {
                                shopOrderPackPrint.orderPackList.RemoveAt(i);
                            }
                        }
                    }

                    if (shopOrderPackPrint.orderPackList.Count == 0)
                    {
                        return;
                    }
                    //????



                }
                else if (to_printer == "to_local")  // 교환권
                {
                    if (mPrintExchangeType == "로컬프린터")
                    {
                        printer_name = mBillPrinterPort;
                    }
                    else
                    {
                        return;  // "" 출력없음.
                    }
                }


                // 프린터를 못핮으면 패스
                if (printer_name.Trim().Length == 0)
                {
                    MessageBox.Show("프린터 미설정.");
                    return;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("주문서 출력 오류. \r\n 카운터로 문의바랍니다.");
                return;
            }



            // 프린터를 못핮으면 패스
            if (printer_name.Trim().Length == 0)
            {
                return;
            }



            //
            try
            {
                //
                const string ESC = "\u001B";
                const string InitializePrinter = ESC + "@";

                PrinterUtility.EscPosEpsonCommands.EscPosEpson obj = new PrinterUtility.EscPosEpsonCommands.EscPosEpson();

                byte[] BytesValue = new byte[0];

                BytesValue = PrintExtensions.AddBytes(BytesValue, InitializePrinter);
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Center());

                BytesValue = PrintExtensions.AddBytes(BytesValue, sizeCharMedium());
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(title));
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());

                BytesValue = PrintExtensions.AddBytes(BytesValue, sizeCharLarge());   // 주문번호 크게 인쇄
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(shopOrderPackPrint.order_no));
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());


                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Left());


                /* 삼삼공카페 : 단독업장이기에 일단 코너명 제외. 추후 멀티업장인 경우 업장명 출력 개발예정

                // 멀티업장인 경우만 코너명을 출력한다.
                if (mShop.Length > 2)  // 콤보박스 첫칸 공백을 주기위해 [0]번 포함해서 단독업장이면 배열 2가 됨.
                {
                    BytesValue = PrintExtensions.AddBytes(BytesValue, sizeCharMedium());
                    BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes("코너 : " + get_shop_name(shop)));
                    BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                }

                */


                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.CharSize.Nomarl());
                String strPrint = "------------------------------------------\r\n";  // 21 * 2
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(strPrint));


                for (int i = 0; i < shopOrderPackPrint.orderPackList.Count; i++)
                {
                    //
                    BytesValue = PrintExtensions.AddBytes(BytesValue, sizeCharMedium());


                    String strName = shopOrderPackPrint.orderPackList[i].goods_name;
                    String strCnt = shopOrderPackPrint.orderPackList[i].goods_cnt.ToString("N0");     // 수량

                    int len = encodelen(shopOrderPackPrint.orderPackList[i].goods_name) + encodelen(strCnt);

                    if (len > 20)
                    {
                        strPrint = strName + Space(41 - len) + strCnt; // 2줄
                    }
                    else
                    {
                        strPrint = strName + Space(21 - len) + strCnt;
                    }


                    strPrint += "\r\n";

                    BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(strPrint));


                    //
                    BytesValue = PrintExtensions.AddBytes(BytesValue, obj.CharSize.Nomarl());

                    for (int k = 0; k < shopOrderPackPrint.orderPackList[i].option_name.Count; k++)
                    {
                        strPrint = "     [" + shopOrderPackPrint.orderPackList[i].option_name[k] + "]" + Space(18 - encodelen(shopOrderPackPrint.orderPackList[i].option_name[k]));
                        String strTmp = shopOrderPackPrint.orderPackList[i].option_item_name[k];     // 수량
                        strPrint += strTmp;
                        strPrint += "\r\n";

                        BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(strPrint));
                    }
                }


                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.CharSize.Nomarl());
                strPrint = "------------------------------------------\r\n";  // 21 * 2
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(strPrint));



                strPrint = "주문시간 : " + shopOrderPackPrint.order_dt.Substring(0, 4) + "-" + shopOrderPackPrint.order_dt.Substring(4, 2) + "-" + shopOrderPackPrint.order_dt.Substring(6, 2) + " " + shopOrderPackPrint.order_dt.Substring(8, 2) + ":" + shopOrderPackPrint.order_dt.Substring(10, 2) + "\r\n";
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(strPrint));


                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());

                BytesValue = PrintExtensions.AddBytes(BytesValue, CutPage());


                if (printer_type == "N")
                {
                    try
                    {
                        TcpClient client = new TcpClient();

                        var result = client.BeginConnect(printer_name, 9100, null, null);
                        var success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(1));
                        if (!success)
                        {
                            throw new Exception("Failed to connect.");
                        }

                        //client.Connect(printer_name, 9100);

                        NetworkStream stream = client.GetStream();
                        stream.Write(BytesValue, 0, BytesValue.Length);

                        stream.Flush();
                        stream.Close();

                        //client.EndConnect(result);
                        client.Close();
                    }
                    catch
                    {
                        MessageBox.Show("주문서 출력 오류. \r\n 헬프데스크로 문의바랍니다.");
                    }
                }
                else
                {
                    try
                    {
                        SerialPort mySerialPort = new SerialPort();
                        mySerialPort.PortName = mBillPrinterPort;
                        mySerialPort.BaudRate = convert_number(mBillPrinterSpeed);
                        mySerialPort.Parity = Parity.None;
                        mySerialPort.StopBits = StopBits.One;
                        mySerialPort.DataBits = 8;
                        mySerialPort.Handshake = Handshake.None;

                        mySerialPort.Open();

                        mySerialPort.Write(BytesValue, 0, BytesValue.Length);
                        mySerialPort.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("프린터 출력 오류.\r\n" + ex.Message);
                        return;
                    }

                }
            }
            catch (Exception e)
            {
                MessageBox.Show("주문서 전달 오류. \r\n 카운터로 필히 확인바랍니다.");
                return;
            }
        }


        public static string Space(int count)
        {
            return new String(' ', count);
        }

        public static string CharCount(char c, int count)
        {
            return new String(c, count);
        }

        public static int encodelen(string str)
        {
            return Encoding.Default.GetBytes(str).Length;
        }

        public static byte[] CutPage()
        {
            byte[] partial_cut = new byte[3] { 0x1D, 0x56, 0x00 };
            return partial_cut;
        }

        public static byte[] sizeLine()
        {
            byte[] charSize = new byte[3] { 0x1B, Convert.ToByte('3'), 0x30 };
            return charSize;
        }

        public static byte[] sizeCharLarge()
        {
            byte[] charSize = new byte[3] { 0x1D, Convert.ToByte('!'), 0x33 };
            return charSize;
        }

        public static byte[] sizeCharMedium()
        {
            byte[] charSize = new byte[3] { 0x1D, Convert.ToByte('!'), 0x11 };
            return charSize;
        }

        public static byte[] sizeCharMedium2()
        {
            byte[] charSize = new byte[3] { 0x1D, Convert.ToByte('!'), 16 };
            return charSize;
        }

        public static void print_bill(String the_no, String tran_type, String except_order, String pay_keep, bool isQuestion, String[] order_no_arr)
        {

            if (mBillPrinterPort.Trim().Length == 0)
            {
                //MessageBox.Show("영수증프린터 미설정으로 영수증출력불가..", "thepos");
                return;
            }


            if (isQuestion == true)
            {
                frmYesNo fYesNo = new frmYesNo(order_no_arr, shopOrderPackList);
                var result = fYesNo.ShowDialog();
                if (result == DialogResult.Yes)
                {

                }
                else
                {
                    return;
                }
            }


            String headerBill = "";
            String bodyBill = "";
            String trailerBill = "";

            byte[] BytesValue = new byte[0];

            try
            {
                headerBill = make_bill_header();
                bodyBill = make_bill_body(the_no, tran_type, except_order, pay_keep);
                trailerBill = make_bill_trailer();
            }
            catch (Exception e)
            {
                MessageBox.Show("영수증 출력 오류.\r\n카운터로 문의바랍니다..\r\n" + e.Message);
                return;
            }




            try
            {
                const string ESC = "\u001B";
                const string InitializePrinter = ESC + "@";

                PrinterUtility.EscPosEpsonCommands.EscPosEpson obj = new PrinterUtility.EscPosEpsonCommands.EscPosEpson();



                BytesValue = PrintExtensions.AddBytes(BytesValue, InitializePrinter);

                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Center());
                //BytesValue = PrintExtensions.AddBytes(BytesValue, sizeLine());


                // 로고이미지 서버등록 이미지로 교체
                if (mByteLogoImage == null)
                {

                }
                else
                {
                    BytesValue = PrintExtensions.AddBytes(BytesValue, mByteLogoImage);
                    BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                }


                //

                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(headerBill));
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Left());

                //              
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(bodyBill));

                //
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(trailerBill));

                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());


                // 바코드
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Center());

                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.BarCode.Code128(the_no));

                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());


                // 티켓 추가 텍스트                
                if (mBillAddText != "")
                {
                    String strPrint = "------------------------------------------";
                    BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(strPrint));
                    BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                    BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());

                    BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Left());
                    BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(mBillAddText));
                }


                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());

                BytesValue = PrintExtensions.AddBytes(BytesValue, CutPage());

            }
            catch (Exception e)
            {
                MessageBox.Show("영수증 출력 오류.\r\n카운터로 문의바랍니다.");  // 파일이 이미 있으므로 만들 수 없습니다.
                return;
            }


            try
            {
                SerialPort mySerialPort = new SerialPort();
                mySerialPort.PortName = mBillPrinterPort;
                mySerialPort.BaudRate = convert_number(mBillPrinterSpeed);
                mySerialPort.Parity = Parity.None;
                mySerialPort.StopBits = StopBits.One;
                mySerialPort.DataBits = 8;
                mySerialPort.Handshake = Handshake.None;

                mySerialPort.Open();

                mySerialPort.Write(BytesValue, 0, BytesValue.Length);
                mySerialPort.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show("영수증 출력 오류.\r\n카운터로 문의바랍니다..\r\n" + e.Message);
                return;
            }


        }



    }
}

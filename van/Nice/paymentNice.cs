using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static thepos2.thepos;
using static thepos2.frmSales;
using static thepos2.ClsWin32Api;

namespace thepos2
{
    internal class paymentNice
    {
        [DllImport("C:\\NICEVCAT\\NVCAT.dll", CharSet = CharSet.Unicode)]
        public static extern int NICEVCAT(byte[] SendBuf, byte[] RecvBuf);
        [DllImport("C:\\NICEVCAT\\NVCAT.dll", CharSet = CharSet.Unicode)]
        public static extern int REQ_STOP();
        [DllImport("C:\\NICEVCAT\\NVCAT.dll", CharSet = CharSet.Unicode)]
        public static extern int RESTART();
        [DllImport("C:\\NICEVCAT\\NVCAT.dll", CharSet = CharSet.Unicode)]
        public static extern int READER_RESET(string time);
        [DllImport("C:\\NICEVCAT\\NVCAT.dll", CharSet = CharSet.Unicode)]
        public static extern int GET_APPR(byte[] RecvBuf);
        [DllImport("C:\\NICEVCAT\\NVCAT.dll", CharSet = CharSet.Unicode)]
        public static extern int CHK_CARDBIN(byte[] RecvBuf);
        [DllImport("C:\\NICEVCAT\\NVCAT.dll", CharSet = CharSet.Unicode)]
        public static extern int CHK_CASHIC();
        [DllImport("C:\\NICEVCAT\\NVCAT.dll", CharSet = CharSet.Unicode)]
        public static extern int CHK_CASHIC_MP();
        [DllImport("C:\\NICEVCAT\\NVCAT.dll", CharSet = CharSet.Unicode)]
        public static extern int CHK_CARDIN_MP(byte[] RecvBuf);
        [DllImport("C:\\NICEVCAT\\NVCAT.dll", CharSet = CharSet.Unicode)]
        public static extern int REQ_BARCODE(byte[] hwtype, byte[] RecvBuf);
        [DllImport("C:\\NICEVCAT\\NVCAT.dll", CharSet = CharSet.Unicode)]
        public static extern int CHK_CASHIC2();
        [DllImport("C:\\NICEVCAT\\NVCAT.dll", CharSet = CharSet.Unicode)]
        public static extern int NVCATSHUTDOWN();
        [DllImport("C:\\NICEVCAT\\NVCAT.dll", CharSet = CharSet.Unicode)]
        public static extern int SetCnlDisableYN(byte[] NiceDownYN, byte[] CustomCnl);
        [DllImport("C:\\NICEVCAT\\NVCAT.dll", CharSet = CharSet.Unicode)]
        public static extern int GetMac(byte[] Mac);
        [DllImport("C:\\NICEVCAT\\NVCAT.dll", CharSet = CharSet.Unicode)]
        public static extern int REQ_TITLOCK();
        [DllImport("C:\\NICEVCAT\\NVCAT.dll", CharSet = CharSet.Unicode)]
        public static extern int REQ_CASHIC_AL(byte[] bReaderType, byte[] bRecvBuf);
        [DllImport("C:\\NICEVCAT\\NVCAT.dll", CharSet = CharSet.Unicode)]
        public static extern int GetDecSignData(int signtype, byte[] bDir, byte[] bOutdata);


        [DllImport("C:\\NICEVCAT\\NVCAT.dll", CharSet = CharSet.Unicode)]
        public static extern int NICEVCATB(byte[] SendBuf, byte[] RecvBuf);




        public struct NiceResponse
        {
            public String t거래구분;
            public String t거래유형;
            public String t응답코드;
            public String t거래금액;
            public String t부가세;
            public String t봉사료;
            public String t할부;
            public String t승인번호;
            public String t승인일시;
            public String t발급사코드;
            public String t발급사명;
            public String t매입사코드;
            public String t매입사명;
            public String t가맹점번호;
            public String t승인CATID;
            public String t잔액;
            public String t응답메시지;
            public String t카드BIN;
            public String t카드구분;
            public String t전문관리번호;
            public String t거래일련번호;
            public String t발생포인트;
            public String t가용포인트;
            public String t누적포인트;
            public String t캐시백가맹점포멧;
            public String t캐시백승인번호;
            public String t기기번호;
        }
        public static NiceResponse mNiceResponse = new NiceResponse();




        public int requestNiceCardAuth(int tAmount, int tFreeAmount, int tTaxAmount, int tTax, int tServiceAmt, int install, String is_cup, out PaymentCard pCard)
        {
            PaymentCard paymentCard = new PaymentCard();
            pCard = paymentCard;

            try
            {
                string FS = ((char)28).ToString();
                string Halbu = String.Format("{0:00}", install);
                string SendData = "";

                if (is_cup == "1") //은련
                    SendData = "0200" + FS + "UP" + FS + "C" + FS + tAmount + FS + tTax + FS + tServiceAmt + FS + Halbu + FS + "" + FS + "" + FS + "" + FS + FS + FS + FS + FS + FS + FS + FS + "해외은련승인요청" + FS;
                else
                    SendData = "0200" + FS + "10" + FS + "C" + FS + tAmount + FS + tTax + FS + tServiceAmt + FS + Halbu + FS + "" + FS + "" + FS + "" + FS + FS + FS + FS + "" + FS + FS + FS + FS + "신용승인" + FS;


                byte[] mSend = System.Text.Encoding.GetEncoding(1252).GetBytes(SendData);
                byte[] mRecv = new byte[2048];

                int ret = NICEVCAT(mSend, mRecv);

                if (ret != 1)
                {

                    mErrorMsg = "NICE VCAT 오류.";

                    thepos_app_log(3, "paymentNice", "requestNiceCardAuth()", mErrorMsg + " ret=" + ret);

                    return -1;
                }


                //
                mNiceResponse = parse_response(mRecv);


                // 응답 코드
                String ResCd = mNiceResponse.t응답코드;
                // 응답 메세지
                String ResMag = mNiceResponse.t응답메시지;

                // 정상 응답
                if (ResCd == "0000")
                {
                    // 마스킹 카드번호
                    paymentCard.card_no = mNiceResponse.t카드BIN;
                    // 거래번호
                    paymentCard.tran_serial = mNiceResponse.t거래일련번호;

                    // 할부개월
                    paymentCard.install = mNiceResponse.t할부;
                    // 총거래 금액
                    paymentCard.amount = int.Parse(mNiceResponse.t거래금액);

                    // 거래일시
                    paymentCard.tran_date = mNiceResponse.t승인일시;
                    // 승인번호
                    paymentCard.auth_no = mNiceResponse.t승인번호;


                    //? 발급사,매입사 코드 -> 공통관리코드로 변환 필요
                    // 매입사 코드
                    paymentCard.acq_code = mNiceResponse.t매입사코드;
                    // 발급사 코드
                    paymentCard.isu_code = mNiceResponse.t발급사코드;


                    // 발급사 명
                    paymentCard.card_name = mNiceResponse.t발급사명;
                    // 가맹점 번호
                    paymentCard.merchant_no = mNiceResponse.t가맹점번호;
                    // 기프트잔액
                    if (is_number(mNiceResponse.t잔액))
                        paymentCard.gift_change = int.Parse(mNiceResponse.t잔액);
                    else
                        paymentCard.gift_change = 0;

                    pCard = paymentCard;

                    return 0;
                }
                else
                {
                    mErrorMsg = ResMag;
                    return -1;
                }
            }
            catch (Exception e) 
            {
                thepos_app_log(3, "paymentNice", "requestNiceCardAuth()", e.Message);

                mErrorMsg = e.Message;
                return -1;
            }


        }

        public int requestNiceCardCancel(PaymentCard pCardAuth, out PaymentCard pCardCancel)
        {
            pCardCancel = pCardAuth;

            string FS = ((char)28).ToString();
            string Halbu = String.Format("{0:00}", pCardAuth.install);
            string SendData = "";


            // 은련구분
            if (pCardAuth.is_cup == "1'")
            {
                SendData = "0420" + FS + "UP" + FS + "C" + FS + pCardAuth.amount + FS + pCardAuth.tax + FS + pCardAuth.service_amount + FS + Halbu + FS + pCardAuth.auth_no + FS + pCardAuth.tran_date + FS + "" + FS + FS + FS + FS + "" + FS + FS + FS + FS + "해외은련취소요청" + FS;
            }
            else
            {
                SendData = "0420" + FS + "10" + FS + "C" + FS + pCardAuth.amount + FS + pCardAuth.tax + FS + pCardAuth.service_amount + FS + Halbu + FS + pCardAuth.auth_no + FS + pCardAuth.tran_date + FS + "" + FS + FS + FS + FS + "" + FS + FS + FS + FS + "신용취소" + FS;
            }



            byte[] mSend = System.Text.Encoding.GetEncoding(1252).GetBytes(SendData);
            byte[] mRecv = new byte[2048];

            int ret = NICEVCAT(mSend, mRecv);

            if (ret != 1)
            {
                mErrorMsg = "NICE VCAT 오류.";
                return -1;
            }


            //
            mNiceResponse = parse_response(mRecv);


            // 응답 코드
            String ResCd = mNiceResponse.t응답코드;
            // 응답 메세지
            String ResMag = mNiceResponse.t응답메시지;

            // 정상 응답
            if (ResCd == "0000")
            {
                pCardCancel.tran_date = mNiceResponse.t승인일시;

                if (is_number(mNiceResponse.t잔액))
                    pCardCancel.gift_change = int.Parse(mNiceResponse.t잔액);
                else
                    pCardCancel.gift_change = 0;


                return 0;
            }
            else
            {
                mErrorMsg = ResMag;
                return -1;
            }
        }




        private NiceResponse parse_response(byte[] mRecv)
        {
            string FS = ((char)28).ToString();

            int i = 0, j = 0, k = 0;
            string recvdata = Encoding.Default.GetString(mRecv);


            while (true)
            {
                if (recvdata.Substring(i, 1) == FS)
                {
                    j = j + 1;

                    switch (j)
                    {
                        case 1:
                            mNiceResponse.t거래구분 = recvdata.Substring(k, i - k);  // 거래구분
                            break;
                        case 2:
                            mNiceResponse.t거래유형 = recvdata.Substring(k, i - k);  // 거래유형
                            break;
                        case 3:
                            mNiceResponse.t응답코드 = recvdata.Substring(k, i - k);  // 응답코드
                            break;
                        case 4:
                            mNiceResponse.t거래금액 = recvdata.Substring(k, i - k);  // 거래금액
                            break;
                        case 5:
                            mNiceResponse.t부가세 = recvdata.Substring(k, i - k);  // 부가세
                            break;
                        case 6:
                            mNiceResponse.t봉사료 = recvdata.Substring(k, i - k);  // 봉사료
                            break;
                        case 7:
                            mNiceResponse.t할부 = recvdata.Substring(k, i - k);  // 할부
                            break;
                        case 8:
                            mNiceResponse.t승인번호 = recvdata.Substring(k, i - k);  // 승인번호
                            mNiceResponse.t승인번호.Trim();
                            break;
                        case 9:
                            mNiceResponse.t승인일시 = recvdata.Substring(k, i - k);  // 승인일시
                            break;
                        case 10:
                            mNiceResponse.t발급사코드 = recvdata.Substring(k, i - k);  // 발급사코드
                            break;
                        case 11:
                            mNiceResponse.t발급사명 = recvdata.Substring(k, i - k);  // 발급사명
                            break;
                        case 12:
                            mNiceResponse.t매입사코드 = recvdata.Substring(k, i - k);  // 매입사코드
                            break;
                        case 13:
                            mNiceResponse.t매입사명 = recvdata.Substring(k, i - k);  // 매입사명
                            break;
                        case 14:
                            mNiceResponse.t가맹점번호 = recvdata.Substring(k, i - k);  // 가맹점번호
                            break;
                        case 15:
                            mNiceResponse.t승인CATID = recvdata.Substring(k, i - k);  // 승인CATID
                            break;
                        case 16:
                            mNiceResponse.t잔액 = recvdata.Substring(k, i - k);  // 잔액
                            break;
                        case 17:
                            mNiceResponse.t응답메시지 = recvdata.Substring(k, i - k);  // 응답메시지
                            break;
                        case 18:
                            mNiceResponse.t카드BIN = recvdata.Substring(k, i - k);  // 카드BIN
                            break;
                        case 19:
                            mNiceResponse.t카드구분 = recvdata.Substring(k, i - k);  // 카드구분
                            break;
                        case 20:
                            mNiceResponse.t전문관리번호 = recvdata.Substring(k, i - k);  // 전문관리번호
                            break;
                        case 21:
                            mNiceResponse.t거래일련번호 = recvdata.Substring(k, i - k);  // 거래일련번호
                            break;
                        case 22:
                            mNiceResponse.t발생포인트 = recvdata.Substring(k, i - k);  //
                            break;
                        case 23:
                            mNiceResponse.t가용포인트 = recvdata.Substring(k, i - k);  //
                            break;
                        case 24:
                            mNiceResponse.t누적포인트 = recvdata.Substring(k, i - k);  //
                            break;
                        case 25:
                            mNiceResponse.t캐시백가맹점포멧 = recvdata.Substring(k, i - k);  //
                            break;
                        case 26:
                            mNiceResponse.t캐시백승인번호 = recvdata.Substring(k, i - k);  //
                            break;
                        case 27:
                            mNiceResponse.t기기번호 = recvdata.Substring(k, i - k);  //
                            break;
                    }
                    k = i + 1;

                    if (j == 27)
                        break;
                }
                i = i + 1;
            }

            return mNiceResponse;
        }

    }
}

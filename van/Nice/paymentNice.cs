﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static thepos2.thepos;
using static thepos2.frmSalesMenu;
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
                    if (ret == -1) mErrorMsg = "NVCAT 실행 중이 아님";
                    else if (ret == -2) mErrorMsg = "거래금액이 존재하지 않음";
                    else if (ret == -6) mErrorMsg = "카드리딩 타임아웃";
                    else if (ret == -7) mErrorMsg = "사용자 및 리더기 요청 취소";
                    else if (ret == -8) mErrorMsg = "FALLBACK 거래 요청 필요";
                    else if (ret == -9) mErrorMsg = "기타 오류";

                    else if (ret == -10) mErrorMsg = "IC 우선 거래 요청 필요 (IC카드 MS리딩시)";
                    else if (ret == -11) mErrorMsg = "FALLBACK 거래 아님";
                    else if (ret == -12) mErrorMsg = "거래 불가 카드";
                    else if (ret == -13) mErrorMsg = "서명 요청 오류";

                    else if (ret == -15) mErrorMsg = "카드리더 PORT OPEN 오류";
                    else if (ret == -16) mErrorMsg = "직전거래 망상취소 불가";
                    else if (ret == -17) mErrorMsg = "중복 요청 불가";
                    else if (ret == -18) mErrorMsg = "지원되지 않는 카드";
                    else if (ret == -19) mErrorMsg = "현금IC카드 복수계좌 미지원";

                    else if (ret == -20) mErrorMsg = "TIT 카드 리더기 오류";
                    else if (ret == -21) mErrorMsg = "NVCAT 내부 망상취소 실패 (해당 카드사 확인요망)";

                    else if (ret == -26) mErrorMsg = "리더기 응답데이터 수신 실패 (결제 재요청 필요)";
                    else if (ret == -27) mErrorMsg = "리더기 요청 실패 (결제 재요청 필요)";
                    else if (ret == -28) mErrorMsg = "서버 연결 실패 (결제 재요청 필요)";
                    else if (ret == -29) mErrorMsg = "요청 전문 송신 실패 (결제 재요청 필요)";
                    else mErrorMsg = "NICE VCAT 오류.";

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


        public int requestNiceEasyAuth(int tAmount, int tFreeAmount, int tTaxAmount, int tTax, int tServiceAmt, String tBarcodeNo, out PaymentEasy pEasy)
        {
            PaymentEasy paymentEasy = new PaymentEasy();
            pEasy = paymentEasy;


            // 나이스는 리더기 스캐너에서 읽는다. 
            // 다른밴은 확인후 개발해야한다.

            if (tBarcodeNo == "")
            {
                byte[] hwType = System.Text.Encoding.GetEncoding(1252).GetBytes("1");
                byte[] recv_barcode = new byte[2048];

                int ret2 = REQ_BARCODE(hwType, recv_barcode);

                if (ret2 == 1)
                {
                    //정상
                    tBarcodeNo = Encoding.Default.GetString(recv_barcode).Trim('\0');
                }
                else
                {
                    mErrorMsg = "NICE VCAT 오류.";

                    thepos_app_log(3, "paymentNice", "requestNiceEasyAuth()", mErrorMsg + "REQ_BARCODE() ret=" + ret2);

                    return -1;
                }

            }



            string FS = ((char)28).ToString();
            string SendData = "";


            //          SendData = "0200" + FS + "10" + FS + "C" + FS + tAmount + FS + tTax + FS + tServiceAmt + FS + Halbu + FS + "" + FS + "" + FS + "" + FS + FS + FS +              FS + "" +  FS + FS + FS +      FS + "신용승인" + FS;
            SendData = "0300" + FS + "10" + FS + "L" + FS + tAmount + FS + tTax + FS + tServiceAmt + FS + "00" + FS + "" + FS + "" + FS + "" + FS + FS + FS + tBarcodeNo.Trim() + FS + FS + FS + FS + "" + FS + "" + FS + FS + "PRO" + FS + "" + FS + "" + FS + FS + FS + "" + FS;



            byte[] mSend = System.Text.Encoding.GetEncoding(1252).GetBytes(SendData);
            byte[] mRecv = new byte[2048];

            int ret = NICEVCATB(mSend, mRecv);

            if (ret != 1)
            {
                mErrorMsg = "NICE VCAT 오류.";

                thepos_app_log(3, "paymentNice", "requestNiceEasyAuth()", mErrorMsg + "NICEVCATB() ret=" + ret);

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
                //
                paymentEasy.barcode_no = tBarcodeNo;
                // 마스킹 카드번호
                paymentEasy.card_no = mNiceResponse.t카드BIN;
                // 거래번호
                paymentEasy.tran_serial = mNiceResponse.t거래일련번호;

                // 총거래 금액
                paymentEasy.amount = int.Parse(mNiceResponse.t거래금액);

                // 거래일시
                paymentEasy.tran_date = mNiceResponse.t승인일시;
                // 승인번호
                paymentEasy.auth_no = mNiceResponse.t승인번호.Trim();


                //? 발급사,매입사 코드 -> 공통관리코드로 변환 필요
                // 매입사 코드
                paymentEasy.acq_code = mNiceResponse.t매입사코드;
                // 발급사 코드
                paymentEasy.isu_code = mNiceResponse.t발급사코드;


                // 발급사 명
                paymentEasy.card_name = mNiceResponse.t발급사명;
                // 가맹점 번호
                paymentEasy.merchant_no = mNiceResponse.t가맹점번호;
                // 기프트잔액
                if (is_number(mNiceResponse.t잔액))
                    paymentEasy.gift_change = int.Parse(mNiceResponse.t잔액);
                else
                    paymentEasy.gift_change = 0;

                paymentEasy.pay_type2 = mNiceResponse.t기기번호;


                pEasy = paymentEasy;

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

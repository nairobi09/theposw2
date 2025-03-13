using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static thepos2.thepos;

namespace thepos2
{
    internal class paymentKovan
    {
        [DllImport(@"C:\KOVAN\VPOS_Client.dll", CharSet = CharSet.Ansi)]

        public static extern int Kovan_Auth(byte[] tcode, byte[] tid, byte[] halbu, byte[] tamt, byte[] ori_date, byte[] ori_authno, byte[] tran_serial, byte[] idno, byte[] amt_flag, byte[] tax_amt, byte[] sfee_amt, byte[] free_amt, byte[] filler, byte[] rTranType, byte[] rErrCode, byte[] rCardno, byte[] rHalbu, byte[] rTamt, byte[] rTranDate, byte[] rTranTime, byte[] rAuthNo, byte[] rMerNo, byte[] rTranSerial, byte[] rIssueCard, byte[] rPurchaseCard, byte[] rSignPath, byte[] rMsg1, byte[] rMsg2, byte[] rMsg3, byte[] rMsg4, byte[] rFiller);



        public int requestKovanCardAuth(int tAmount, int tFreeAmount, int tTaxAmount, int tTax, int tServiceAmt, int install, String is_cup, out PaymentCard pCard)
        {
            PaymentCard paymentCard = new PaymentCard();
            pCard = paymentCard;

            byte[] tcode = new byte[1024];
            byte[] tid = new byte[1024];
            byte[] halbu = new byte[1024];
            byte[] tamt = new byte[1024];
            byte[] ori_date = new byte[1024];
            byte[] ori_authno = new byte[1024];
            byte[] tran_serial = new byte[1024];
            byte[] idno = new byte[1024];
            byte[] amt_flag = new byte[1024];
            byte[] tax_amt = new byte[1024];
            byte[] sfee_amt = new byte[1024];
            byte[] free_amt = new byte[1024];
            byte[] filler = new byte[1024];

            byte[] rTranType = new byte[1024];
            byte[] rErrCode = new byte[1024];
            byte[] rCardno = new byte[1024];
            byte[] rHalbu = new byte[1024];
            byte[] rTamt = new byte[1024];
            byte[] rTranDate = new byte[1024];
            byte[] rTranTime = new byte[1024];
            byte[] rAuthNo = new byte[1024];
            byte[] rMerNo = new byte[1024];
            byte[] rTranSerial = new byte[1024];
            byte[] rIssueCard = new byte[1024];
            byte[] rPurchaseCard = new byte[1024];
            byte[] rSignPath = new byte[1024];
            byte[] rMsg1 = new byte[1024];
            byte[] rMsg2 = new byte[1024];
            byte[] rMsg3 = new byte[1024];
            byte[] rMsg4 = new byte[1024];
            byte[] rFiller = new byte[1024];


            if (is_cup == "1")
                tcode = Encoding.Default.GetBytes("E0");          //은련
            else
                tcode = Encoding.Default.GetBytes("S0");          //


            tid = Encoding.Default.GetBytes(mVanTID);              //tid
            halbu = Encoding.Default.GetBytes(install.ToString("00"));          //할부
            tamt = Encoding.Default.GetBytes(tAmount.ToString("000000000"));   //거래금액:실제 결제되는 금액
            ori_date = Encoding.Default.GetBytes("      ");      //취소시 원거래일자
            ori_authno = Encoding.Default.GetBytes("            ");//취소시 원거래 승인번호 12자리 우측 스페이스 채움
            tran_serial = Encoding.Default.GetBytes(get_today_time() + "      ");//거래일련번호 망취소시 거래일련번호로 사용됨므로 중복되면 망취소 안됨(하루에 중복되는 거래일련번호로 사용시 망취소 에러). 
            idno = Encoding.Default.GetBytes("                                 ");//33 스페이스, 현금영수증거래/ 수표조회시 식별번호

            amt_flag = Encoding.Default.GetBytes("   ");//미사용 스페이스

            //세금 봉사료 비과세 계산해야함. 계산안하면 0원 
            tax_amt = Encoding.Default.GetBytes(tTax.ToString("000000000"));  //세금 
            sfee_amt = Encoding.Default.GetBytes(tServiceAmt.ToString("000000000")); //봉사료 
            free_amt = Encoding.Default.GetBytes(tFreeAmount.ToString("000000000")); //비과세 

            filler = Encoding.Default.GetBytes("                                                                                                    ");//스페이스 100 

            //빌드속성 x86
            int ret = Kovan_Auth(tcode, tid, halbu, tamt, ori_date, ori_authno, tran_serial, idno, amt_flag, tax_amt, sfee_amt, free_amt, filler, rTranType, rErrCode, rCardno, rHalbu, rTamt, rTranDate, rTranTime, rAuthNo, rMerNo, rTranSerial, rIssueCard, rPurchaseCard, rSignPath, rMsg1, rMsg2, rMsg3, rMsg4, rFiller);


            //  0 정상처리
            // -2 프로그램 통신 접속 실패
            // -3 프로그램 통신 전송 실패
            // -4 프로그램 수신 준비 실패
            // -5 프로그램 통신 수신 실패
            // -6 거래구분오류
            // -7 할부개월오류
            // -8 취소 시 원거래일 오류
            // -9 취소 시 원승인번호 오류
            // -10 거래일련번호 오류
            // -11 수표조회정보 오류

            if (ret != 0)
            {
                mErrorMsg = "KOVAN VCAT 오류.";
                return -1;
            }


            String ResCd = Encoding.Default.GetString(rErrCode).Substring(0, 4);

            // 정상 응답
            if (ResCd == "0000")
            {
                paymentCard.card_no = Encoding.Default.GetString(rCardno).Substring(0, 18).Trim();         // 마스킹 카드번호
                paymentCard.tran_serial = Encoding.Default.GetString(rTranSerial).Substring(0, 12).Trim(); // 거래번호
                paymentCard.install = Encoding.Default.GetString(rHalbu).Substring(0, 2);          // 할부개월
                paymentCard.amount = tAmount;   // 총거래 금액
                paymentCard.tran_date = Encoding.Default.GetString(rTranDate).Substring(0, 6);     // 거래일시
                paymentCard.auth_no = Encoding.Default.GetString(rAuthNo).Substring(0, 12).Trim();         // 승인번호
                paymentCard.card_name = Encoding.Default.GetString(rIssueCard).Substring(0, 20).Trim();    // 발급사 명
                paymentCard.merchant_no = Encoding.Default.GetString(rMerNo).Substring(0, 15).Trim();      // 가맹점 번호


                // 필러 내부에 데이터 검사
                String F = Encoding.Default.GetString(rFiller);

                paymentCard.acq_code = F.Substring(2, 2); // 매입사 코드
                paymentCard.isu_code = F.Substring(0, 2); // 발급사 코드


                String gift_balance = Encoding.Default.GetString(rMsg3).Substring(0, 10);
                gift_balance = gift_balance.Trim();

                // 기프트잔액
                if (is_number(gift_balance))
                    paymentCard.gift_change = int.Parse(gift_balance);
                else
                    paymentCard.gift_change = 0;

                pCard = paymentCard;

                return 0;
            }
            else
            {
                mErrorMsg = "거절 : " + Encoding.Default.GetString(rMsg1);
                return -1;
            }


        }


        public int requestKovanCardCancel(PaymentCard pCardAuth, out PaymentCard pCardCancel)
        {
            pCardCancel = pCardAuth;

            byte[] tcode = new byte[1024];
            byte[] tid = new byte[1024];
            byte[] halbu = new byte[1024];
            byte[] tamt = new byte[1024];
            byte[] ori_date = new byte[1024];
            byte[] ori_authno = new byte[1024];
            byte[] tran_serial = new byte[1024];
            byte[] idno = new byte[1024];
            byte[] amt_flag = new byte[1024];
            byte[] tax_amt = new byte[1024];
            byte[] sfee_amt = new byte[1024];
            byte[] free_amt = new byte[1024];
            byte[] filler = new byte[1024];

            byte[] rTranType = new byte[1024];
            byte[] rErrCode = new byte[1024];
            byte[] rCardno = new byte[1024];
            byte[] rHalbu = new byte[1024];
            byte[] rTamt = new byte[1024];
            byte[] rTranDate = new byte[1024];
            byte[] rTranTime = new byte[1024];
            byte[] rAuthNo = new byte[1024];
            byte[] rMerNo = new byte[1024];
            byte[] rTranSerial = new byte[1024];
            byte[] rIssueCard = new byte[1024];
            byte[] rPurchaseCard = new byte[1024];
            byte[] rSignPath = new byte[1024];
            byte[] rMsg1 = new byte[1024];
            byte[] rMsg2 = new byte[1024];
            byte[] rMsg3 = new byte[1024];
            byte[] rMsg4 = new byte[1024];
            byte[] rFiller = new byte[1024];


            string Halbu = String.Format("{0:00}", pCardAuth.install);



            if (pCardAuth.is_cup == "1")
                tcode = Encoding.Default.GetBytes("E1");          //은련
            else
                tcode = Encoding.Default.GetBytes("S1");          //


            tid = Encoding.Default.GetBytes(mVanTID);              //tid
            halbu = Encoding.Default.GetBytes(Halbu);          //할부
            tamt = Encoding.Default.GetBytes(pCardAuth.amount.ToString("000000000"));   //거래금액:실제 결제되는 금액
            ori_date = Encoding.Default.GetBytes(pCardAuth.tran_date);      //취소시 원거래일자
            ori_authno = Encoding.Default.GetBytes(pCardAuth.auth_no + new string(' ', 12 - pCardAuth.auth_no.Length));//취소시 원거래 승인번호 12자리 우측 스페이스 채움
            tran_serial = Encoding.Default.GetBytes(pCardAuth.tran_serial + "      ");//거래일련번호 망취소시 거래일련번호로 사용됨므로 중복되면 망취소 안됨(하루에 중복되는 거래일련번호로 사용시 망취소 에러). 
            idno = Encoding.Default.GetBytes("                                 ");//33 스페이스, 현금영수증거래/ 수표조회시 식별번호

            amt_flag = Encoding.Default.GetBytes("   ");//미사용 스페이스

            //세금 봉사료 비과세 계산해야함. 계산안하면 0원 
            tax_amt = Encoding.Default.GetBytes(pCardAuth.tax.ToString("000000000"));  //세금 
            sfee_amt = Encoding.Default.GetBytes(pCardAuth.service_amount.ToString("000000000")); //봉사료 
            free_amt = Encoding.Default.GetBytes(pCardAuth.tfree_amount.ToString("000000000")); //비과세 

            filler = Encoding.Default.GetBytes("                                                                                                    ");//스페이스 100 

            //빌드속성 x86
            int ret = Kovan_Auth(tcode, tid, halbu, tamt, ori_date, ori_authno, tran_serial, idno, amt_flag, tax_amt, sfee_amt, free_amt, filler, rTranType, rErrCode, rCardno, rHalbu, rTamt, rTranDate, rTranTime, rAuthNo, rMerNo, rTranSerial, rIssueCard, rPurchaseCard, rSignPath, rMsg1, rMsg2, rMsg3, rMsg4, rFiller);

            //  0 정상처리

            if (ret != 0)
            {
                mErrorMsg = "KOVAN VCAT 오류.";
                return -1;
            }

            String ResCd = Encoding.Default.GetString(rErrCode).Substring(0, 4);


            // 정상 응답
            if (ResCd == "0000")
            {
                pCardCancel.card_no = Encoding.Default.GetString(rCardno).Substring(0, 18).Trim();         // 마스킹 카드번호
                pCardCancel.tran_serial = Encoding.Default.GetString(rTranSerial).Substring(0, 12).Trim(); // 거래번호
                pCardCancel.tran_date = Encoding.Default.GetString(rTranDate).Substring(0, 6);     // 거래일시
                pCardCancel.auth_no = Encoding.Default.GetString(rAuthNo).Substring(0, 12).Trim();         // 승인번호
                pCardCancel.card_name = Encoding.Default.GetString(rIssueCard).Substring(0, 20).Trim();    // 발급사 명
                pCardCancel.merchant_no = Encoding.Default.GetString(rMerNo).Substring(0, 15).Trim();      // 가맹점 번호



                // 필러 내부에 데이터 검사
                String F = Encoding.Default.GetString(rFiller);

                pCardCancel.acq_code = F.Substring(2, 2); // 매입사 코드
                pCardCancel.isu_code = F.Substring(0, 2); // 발급사 코드


                String gift_balance = Encoding.Default.GetString(rMsg3).Substring(0, 10);
                gift_balance = gift_balance.Trim();

                // 기프트잔액
                if (is_number(gift_balance))
                    pCardCancel.gift_change = int.Parse(gift_balance);
                else
                    pCardCancel.gift_change = 0;

                return 0;
            }
            else
            {
                mErrorMsg = "거절 : " + Encoding.Default.GetString(rMsg1);
                return -1;
            }

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static thepos.thepos;

namespace thepos
{
    internal class paymentKCP
    {
        ClsSecureDLL clsSecureDLL = new ClsSecureDLL();


        public paymentKCP()
        {


        }


        public int requestKcpCardAuth(int tAmount, int tFreeAmount, int tTaxAmount, int tTax, int tServiceAmt, int install, String is_cup, out PaymentCard pCard)
        {
            PaymentCard mPaymentCard = new PaymentCard();

            pCard = mPaymentCard;


            if (!clsSecureDLL.LoadLibrary())
            {

                mErrorMsg = "KCP DLL LoadLibrary 오류.";
                return -1;
            }


            // 요청 데이터 초기화
            clsSecureDLL.InitData();

            clsSecureDLL.SetData("WORK_CODE", "0100");

            //
            if (is_cup == "1") //은련
                clsSecureDLL.SetData("PROC_CODE", "A02");
            else
                clsSecureDLL.SetData("PROC_CODE", "A01");


            // 총거래 금액
            clsSecureDLL.SetData("TOT_AMT", tAmount + "");
            // 과세 금액
            clsSecureDLL.SetData("ORG_AMT", tTaxAmount + "");
            // 면세 금액
            clsSecureDLL.SetData("DUTY_AMT", tFreeAmount + "");
            // 봉사료
            clsSecureDLL.SetData("SVC_AMT", tServiceAmt + "");
            // 세금
            clsSecureDLL.SetData("TAX_AMT", tTax + "");
            // 신용 할부 설정
            clsSecureDLL.SetData("INS_MON", install + "");



            int nRet = clsSecureDLL.TransData_Modal();

            // TransData 리턴값이 "-99"일 경우 거래중단
            if (nRet == -99)
            {

                mErrorMsg = "KCP TransData_Modal 오류.";
                return -1;
            }



            // 응답


            // 응답 코드
            String ResCd = clsSecureDLL.GetData("RES_CD");
            // 응답 메세지
            String ResMag = clsSecureDLL.GetData("RES_MSG");

            // 정상 응답
            if (ResCd == "0000")
            {
                // 마스킹 카드번호
                mPaymentCard.card_no = clsSecureDLL.GetData("CARD_BIN");
                // 거래번호
                mPaymentCard.tran_serial = clsSecureDLL.GetData("TRANS_NO");  // tran_serial -> 취소시 사용

                // 할부개월
                mPaymentCard.install = clsSecureDLL.GetData("INS_MON");
                // 총거래 금액
                mPaymentCard.amount = int.Parse(clsSecureDLL.GetData("TOT_AMT"));

                // 거래일시
                mPaymentCard.tran_date = clsSecureDLL.GetData("OTX_DT");  // 응답시 12자리 -> 취소시 6자리
                // 승인번호
                mPaymentCard.auth_no = clsSecureDLL.GetData("AUTH_NO");


                //? 발급사,매입사 코드 -> 공통관리코드로 변환 필요
                // 매입사 코드
                mPaymentCard.acq_code = clsSecureDLL.GetData("AC_CODE");
                // 발급사 코드
                mPaymentCard.isu_code = clsSecureDLL.GetData("CC_CODE");


                // 발급사 명
                mPaymentCard.card_name = clsSecureDLL.GetData("CC_NAME");
                // 가맹점 번호
                mPaymentCard.merchant_no = clsSecureDLL.GetData("MCHT_NO");

                pCard = mPaymentCard;

                return 0;
            }
            else
            {
                mErrorMsg = ResMag;
                return -1;
            }
        }


        public int requestKcpCardCancel(PaymentCard pCardAuth, out PaymentCard pCardCancel)
        {
            pCardCancel = pCardAuth;



            // 요청 데이터 초기화
            clsSecureDLL.InitData();

            clsSecureDLL.SetData("WORK_CODE", "0420");


            if (pCardAuth.is_cup == "1")
            {
                clsSecureDLL.SetData("PROC_CODE", "A02");
            }
            else
            {
                clsSecureDLL.SetData("PROC_CODE", "A01");
            }


            clsSecureDLL.SetData("SCREEN_FLAG", "0");  //일반취소

            clsSecureDLL.SetData("TRAN_NO", pCardAuth.tran_serial);

            clsSecureDLL.SetData("TOT_AMT", pCardAuth.amount + "");


            clsSecureDLL.SetData("OTX_DT", pCardAuth.tran_date.Substring(0, 6));

            clsSecureDLL.SetData("AUTH_NO", pCardAuth.auth_no);



            int nRet = clsSecureDLL.TransData_Modal();

            // TransData 리턴값이 "-99"일 경우 거래중단
            if (nRet == -99)
            {

                mErrorMsg = "KCP TransData_Modal 오류.";
                return -1;
            }



            // 응답
            String ResCd = clsSecureDLL.GetData("RES_CD");
            String ResMag = clsSecureDLL.GetData("RES_MSG");


            // 정상 응답
            if (ResCd == "0000")
            {
                pCardCancel.biz_dt = mBizDate;
                pCardCancel.tran_type = "C";

                pCardCancel.tran_date = clsSecureDLL.GetData("OTX_DT");

                return 0;
            }
            else
            {
                mErrorMsg = ResMag;
                return -1;
            }
        }


    }
}

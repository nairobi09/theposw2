using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thepos2
{
    internal class ClsEnum
    {
        /// <summary>
        /// POS 연동
        /// </summary>
        public enum ENUM_PROC_CD
        {
            //값없음
            [Description("")]
            NONE,

            // ======================================
            // VAN 거래 서비스
            // ======================================   
            [Description("D01")]
            // 개시등록
            D01,
            [Description("D03")]
            // 암호화키 인증
            D03,
            [Description("D04")]
            // 암호화키 다운
            D04,
            // 무결성 점검
            [Description("F01")]
            F01,
            // 암호화키 다운로드
            [Description("F02")]
            F02,
            // 가맹점 정보 다운로드
            [Description("F03")]
            F03,
            // 신용거래
            [Description("A01")]
            A01,
            // 신용거래 (은련)
            [Description("A02")]
            A02,
            // MCPAY 페이온거래
            [Description("A11")]
            A11,
            // SSGPAY거래
            [Description("A13")]
            A13,
            // ZEROPAY 거래
            [Description("A14")]
            A14,
            // KAKAOPAY 거래
            [Description("A16")]
            A16,
            // 현금영수증거래
            [Description("C01")]
            C01,
            // 현금IC 거래
            [Description("C02")]
            C02,
            // 수표조회
            [Description("C06")]
            C06,
            // 포인트거래
            [Description("M01")]
            M01,
            // 멥버쉽거래
            [Description("M02")]
            M02,

            // ======================================
            // 리더기 연동 서비스
            // ======================================   

            // 카드번호 조회
            [Description("R01")]
            R01,
            // IC카드 삽입여부 조회
            [Description("R02")]
            R02,
            // 카드 리더기 동작요청
            [Description("R03")]
            R03,
            // 카드번호(마스킹) 조회
            [Description("R04")]
            R04,
            // RF UID 조회
            [Description("R05")]
            R05,

            // ======================================
            // 데몬 자체 서비스
            // ======================================   
            // 데몬 상태감지
            [Description("T01")]
            T01,
            // 직전거래 망취소 조회
            [Description("T02")]
            T02,
            // 결제진행 사용자 취소
            [Description("T03")]
            T03,
            // 서명요청
            [Description("T04")]
            T04,
            // 일반핀요청
            [Description("T05")]
            T05,
        }

        /// <summary>
        /// 단말연동
        /// </summary>
        public enum ENUM_CAT_PROC_CD
        {
            //값없음
            [Description("")]
            NONE,
            // ======================================
            // 영수증 프린터 기능
            // ======================================             
            [Description("PRT")]
            PRT,
            // ======================================
            // 데몬 자체 서비스
            // ====================================== 
            // 데몬 상태감지
            [Description("T01")]
            T01,
            // 결제진행 사용자 취소
            [Description("T03")]
            T03,
            // 직전거래 조회(모듈만사용)
            [Description("T99")]
            T99,
            // ======================================
            // 단말연동 서비스
            // ======================================   
            // 가맹점관련 정보확인
            [Description("E01")]
            E01,
            // 신용카드
            [Description("E02")]
            E02,
            // 현금IC카드
            [Description("E03")]
            E03,
            // 신용IC / 현금IC 카드
            [Description("E04")]
            E04,
            // 현금영수증
            [Description("E05")]
            E05,
            // 마지막 거래 확인
            [Description("E06")]
            E06,
            // 서명데이터 요청
            [Description("E07")]
            E07,
            // 동글(서명)
            [Description("E08")]
            E08,
            // 동글(핀)
            [Description("E09")]
            E09,
            // 동글(핀암호화)
            [Description("E10")]
            E10,
            // 단말기 집계 출력
            [Description("E11")]
            E11,
            // 마지막 거래 출력 (재인쇄)
            [Description("E12")]
            E12,
            // 구매 전용 정보 (ATM 거래인데 서비스 지원종료한다)
            [Description("E13")]
            E13,
            // 포인트 거래
            [Description("E14")]
            E14,
            // 멤버쉽 거래
            [Description("E15")]
            E15,
            // IC카드 삽입 여부 확인
            [Description("E16")]
            E16,
            // 신용거래 (OFFPG)
            [Description("E17")]
            E17,
            // 현금영수증 (OFFPG)
            [Description("E18")]
            E18,
            // 다중 가맹점 정보 확인 < 추후에 요청있으면 개발 >
            [Description("E20")]
            E20,
            // 수표조회
            [Description("E21")]
            E21,
            // 카드번호 조회
            [Description("E22")]
            E22,
        }

        /// <summary>
        /// 요청 구분
        /// </summary>
        public enum ENUM_WORK_CD
        {
            [Description("")]   //값없음
            NONE,
            [Description("0100")]   //승인
            APPROVE,
            [Description("0101")]   //조회 후 승인
            SCH_APPROVE,
            [Description("0420")]   //취소
            CANCEL,
            [Description("0430")]   //망취소
            NET_CANCEL,
            [Description("4100")]   //조회(잔액조회 포함)
            SEARCH,
            [Description("4102")]   //거래내역조회
            DEALSCH,
            [Description("4107")]   //BIN 조회
            BINSCH,
            [Description("1100")]   //적립(승인)
            APPSAVE,
            [Description("2100")]   //사용(승인)
            APPUSE,
            [Description("3100")]   //할인(승인)
            APPSALE,
            [Description("1420")]   //적립(취소)
            CANSAVE,
            [Description("2420")]   //사용(취소)
            CANUSE,
            [Description("3420")]   //할인(취소)
            CANSALE,
        }

        /// <summary>
        /// 프린터 요청 구분
        /// </summary>
        public enum ENUM_PRT_WORK_CD
        {
            [Description("")]       //값없음
            NONE,
            [Description("PRTC")]   // 프린트 명령
            PRTC,
            [Description("BYPS")]   // 프린트 그대로 전송
            BYPS,
            [Description("INIT")]   // 초기화
            INIT,
            [Description("LMSG")]   // 한줄메시지
            LMSG,
            [Description("BARC")]   // 바코드출력
            BARC,
            [Description("PBMP")]   // 비트맵출력
            PBMP,
            [Description("CRLF")]   // 용지올리기
            CRLF,
            [Description("PPCT")]   // 용지절단
            PPCT,
            [Description("OPEN")]   // 금전함열기
            OPEN,
            [Description("PEND")]   // 프린트종료
            PEND,
        }

        public enum POPUP_SETTING
        {
            [Description("NONE")]
            NONE = 0,
            [Description("확인")]
            OK = 1,
            [Description("취소")]
            CANCEL = 2
        }
    }
}

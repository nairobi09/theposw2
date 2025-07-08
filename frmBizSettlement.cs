
using Newtonsoft.Json.Linq;
using PrinterUtility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static thepos2.thepos;

namespace thepos
{
    public partial class frmBizSettlement : Form
    {
        int cash_cnt = 0;
        int card_cnt = 0;
        int easy_cnt = 0;
        int cert_cnt = 0;

        int cash_amount = 0;
        int card_amount = 0;
        int easy_amount = 0;
        int cert_amount = 0;

        int cash_cnt_cncl = 0;
        int card_cnt_cncl = 0;
        int easy_cnt_cncl = 0;
        int cert_cnt_cncl = 0;

        int cash_amount_cncl = 0;
        int card_amount_cncl = 0;
        int easy_amount_cncl = 0;
        int cert_amount_cncl = 0;

        int net_count = 0;
        int net_amount = 0;


        public frmBizSettlement()
        {
            InitializeComponent();

            initialize_the();

            load_card_data();

            load_pay_data();

            load_goods_data();



            //
            thepos_app_log(1, this.Name, "open", "");

        }


        private void initialize_the()
        {
            lblBizDate.Text = mBizDate.Substring(0, 4) + "-" + mBizDate.Substring(4, 2) + "-" + mBizDate.Substring(6, 2);
            lblPosNo.Text = myPosNo;
            lblLoginName.Text = mUserName;

        }


        private void load_card_data()
        {
            String sUrl = "reportDailyCardPos?siteId=" + mSiteId + "&bizDt=" + mBizDate + "&posNo=" + myPosNo;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["dailyArr"].ToString();
                    JArray arr = JArray.Parse(data);

                    if (arr.Count > 0)
                    {
                        int sum_cnt = 0;
                        int sum_amount = 0;

                        for (int i = 0; i < arr.Count; i++)
                        {
                            ListViewItem tItem = new ListViewItem();
                            tItem.Text = arr[i]["cardName"].ToString();

                            int cnt = convert_number(arr[i]["cnt"].ToString());
                            int amount = convert_number(arr[i]["amountCard"].ToString());

                            sum_cnt += cnt;
                            sum_amount += amount;

                            tItem.SubItems.Add(cnt.ToString("N0"));
                            tItem.SubItems.Add(amount.ToString("N0"));

                            lvwCard.Items.Add(tItem);
                        }

                        ListViewItem sItem = new ListViewItem();
                        sItem.Text = "합계";
                        sItem.SubItems.Add(sum_cnt.ToString("N0"));
                        sItem.SubItems.Add(sum_amount.ToString("N0"));
                        lvwCard.Items.Add(sItem);
                    }
                }
                else
                {
                    MessageBox.Show("데이터 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }

        }

        private void load_pay_data()
        {
            String sUrl = "reportDayPos?siteId=" + mSiteId + "&bizDt=" + mBizDate + "&posNo=" + myPosNo;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["dayPos"].ToString();
                    JArray arr = JArray.Parse(data);


                    if (arr.Count > 0)
                    {
                        cash_cnt = convert_number(arr[0]["cntCash"].ToString());
                        card_cnt = convert_number(arr[0]["cntCard"].ToString());
                        easy_cnt = convert_number(arr[0]["cntEasy"].ToString());
                        cert_cnt = convert_number(arr[0]["cntCert"].ToString());

                        cash_amount = convert_number(arr[0]["amountCash"].ToString());
                        card_amount = convert_number(arr[0]["amountCard"].ToString());
                        easy_amount = convert_number(arr[0]["amountEasy"].ToString());
                        cert_amount = convert_number(arr[0]["amountCert"].ToString());

                        cash_cnt_cncl = convert_number(arr[0]["cntCashCncl"].ToString());
                        card_cnt_cncl = convert_number(arr[0]["cntCardCncl"].ToString());
                        easy_cnt_cncl = convert_number(arr[0]["cntEasyCncl"].ToString());
                        cert_cnt_cncl = convert_number(arr[0]["cntCertCncl"].ToString());

                        cash_amount_cncl = convert_number(arr[0]["amountCashCncl"].ToString());
                        card_amount_cncl = convert_number(arr[0]["amountCardCncl"].ToString());
                        easy_amount_cncl = convert_number(arr[0]["amountEasyCncl"].ToString());
                        cert_amount_cncl = convert_number(arr[0]["amountCertCncl"].ToString());

                        net_count = convert_number(arr[0]["netCount"].ToString());
                        net_amount = convert_number(arr[0]["netAmount"].ToString());

                        ListViewItem sItem;

                        sItem = new ListViewItem();
                        sItem.Text = "현금";
                        sItem.SubItems.Add(cash_cnt.ToString("N0"));
                        sItem.SubItems.Add(cash_amount.ToString("N0"));
                        lvwPay.Items.Add(sItem);

                        sItem = new ListViewItem();
                        sItem.Text = "카드";
                        sItem.SubItems.Add(card_cnt.ToString("N0"));
                        sItem.SubItems.Add(card_amount.ToString("N0"));
                        lvwPay.Items.Add(sItem);

                        sItem = new ListViewItem();
                        sItem.Text = "간편";
                        sItem.SubItems.Add(easy_cnt.ToString("N0"));
                        sItem.SubItems.Add(easy_amount.ToString("N0"));
                        lvwPay.Items.Add(sItem);

                        sItem = new ListViewItem();
                        sItem.Text = "쿠폰";
                        sItem.SubItems.Add(cert_cnt.ToString("N0"));
                        sItem.SubItems.Add(cert_amount.ToString("N0"));
                        lvwPay.Items.Add(sItem);


                        sItem = new ListViewItem();
                        sItem.Text = "현금취소";
                        sItem.SubItems.Add(cash_cnt_cncl.ToString("N0"));
                        sItem.SubItems.Add(cash_amount_cncl.ToString("N0"));
                        lvwPay.Items.Add(sItem);

                        sItem = new ListViewItem();
                        sItem.Text = "카드취소";
                        sItem.SubItems.Add(card_cnt_cncl.ToString("N0"));
                        sItem.SubItems.Add(card_amount_cncl.ToString("N0"));
                        lvwPay.Items.Add(sItem);

                        sItem = new ListViewItem();
                        sItem.Text = "간편취소";
                        sItem.SubItems.Add(easy_cnt_cncl.ToString("N0"));
                        sItem.SubItems.Add(easy_amount_cncl.ToString("N0"));
                        lvwPay.Items.Add(sItem);

                        sItem = new ListViewItem();
                        sItem.Text = "쿠폰취소";
                        sItem.SubItems.Add(cert_cnt_cncl.ToString("N0"));
                        sItem.SubItems.Add(cert_amount_cncl.ToString("N0"));
                        lvwPay.Items.Add(sItem);


                        sItem = new ListViewItem();
                        sItem.Text = "합계";
                        sItem.SubItems.Add(net_count.ToString("N0"));
                        sItem.SubItems.Add(net_amount.ToString("N0"));
                        lvwPay.Items.Add(sItem);
                    }
                  

                }
                else
                {
                    MessageBox.Show("데이터 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }

        }

        private void load_goods_data()
        {
            String sUrl = "reportDayPosGoods?siteId=" + mSiteId + "&bizDt=" + mBizDate + "&posNo=" + myPosNo;
            
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["dayPosGoods"].ToString();
                    JArray arr = JArray.Parse(data);

                    ListViewItem sItem;
                    int sum_goods_cnt = 0;
                    int sum_goods_amount = 0;

                    for (int i = 0; i < arr.Count; i++)
                    {
                        String goods_code = arr[i]["goodsCode"].ToString();
                        int goods_cnt = convert_number(arr[i]["cnt"].ToString());
                        int net_amount = convert_number(arr[i]["netAmount"].ToString());

                        sum_goods_cnt += goods_cnt;
                        sum_goods_amount += net_amount;

                        sItem = new ListViewItem();
                        sItem.Text = get_goods_name(goods_code);
                        sItem.SubItems.Add(goods_cnt.ToString("N0"));
                        sItem.SubItems.Add(net_amount.ToString("N0"));
                        lvwGoods.Items.Add(sItem);
                    }

                    sItem = new ListViewItem();
                    sItem.Text = "합계";
                    sItem.SubItems.Add(sum_goods_cnt.ToString("N0"));
                    sItem.SubItems.Add(sum_goods_amount.ToString("N0"));
                    lvwGoods.Items.Add(sItem);

                }
                else
                {
                    MessageBox.Show("데이터 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }

        }



        private void btnPrintGoods_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("일정산 리포트 3종 출력.\r\n\r\n- 정산표\r\n- 카드사별 매출\r\n- 품목별 매출", "thepos", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

            }
            else
            {
                return;
            }



            if (mBillPrinterPort.Trim().Length == 0)
            {
                MessageBox.Show("프린터 미설정으로 출력불가");
                return;
            }


            String strPrint = make_print_card();
            print_data(strPrint);

            Thread.Sleep(1000);

            strPrint = make_print_pay();
            print_data(strPrint);

            Thread.Sleep(1000);

            strPrint = make_print_goods();
            print_data(strPrint);
        }


        private void print_data(String strPrint)
        { 

            try
            {
                const string ESC = "\u001B";
                const string InitializePrinter = ESC + "@";

                PrinterUtility.EscPosEpsonCommands.EscPosEpson obj = new PrinterUtility.EscPosEpsonCommands.EscPosEpson();


                byte[] BytesValue = new byte[0];
                BytesValue = PrintExtensions.AddBytes(BytesValue, InitializePrinter);
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Center());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.CharSize.Nomarl());

                //              
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(strPrint));

                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());


                BytesValue = PrintExtensions.AddBytes(BytesValue, CutPage());


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
                    MessageBox.Show("프린터 출력 오류1.\r\n" + ex.Message);
                    return;
                }
            }
            catch
            {
                MessageBox.Show("프린터 출력 오류2.");  // 파일이 이미 있으므로 만들 수 없습니다.
                return;
            }
        }


        private byte[] CutPage()
        {
            byte[] partial_cut = new byte[3] { 0x1D, 0x56, 0x00 };
            return partial_cut;
        }

        public static int encodelen(string str)
        {
            return Encoding.Default.GetBytes(str).Length;
        }

        public static string Space(int count)
        {
            return new String(' ', count);
        }


        private String make_print_card()
        {
            String str_body = "";
            String str1 = "";
            String str2 = "";
            int space_cnt = 0;

            str_body += "[카드사별 매출]\r\n\r\n";


            str1 = "영업일: " + mBizDate.Substring(0, 4) + "-" + mBizDate.Substring(4, 2) + "-" + mBizDate.Substring(6, 2);
            str2 = "POS No. " + myPosNo;
            space_cnt = 42 - (encodelen(str1) + encodelen(str2));
            str_body += str1 + Space(space_cnt) + str2;

            str_body += "------------------------------------------\r\n";  // 42

            space_cnt = 16 - encodelen("카드사명");
            str_body += "카드사명" + Space(space_cnt);
            space_cnt = 12 - encodelen("건수");
            str_body += Space(space_cnt) + "건수";
            space_cnt = 14 - encodelen("금액");
            str_body += Space(space_cnt) + "금액" + "\r\n";

            str_body += "------------------------------------------\r\n";  // 42


            for (int i = 0; i < lvwCard.Items.Count; i++)
            {
                String card_name = lvwCard.Items[i].Text;
                String cnt = lvwCard.Items[i].SubItems[1].Text;
                String amount = lvwCard.Items[i].SubItems[2].Text;

                space_cnt = 16 - encodelen(card_name);
                str_body += card_name + Space(space_cnt);

                space_cnt = 12 - encodelen(cnt);
                str_body += Space(space_cnt) + cnt;

                space_cnt = 14 - encodelen(amount);
                str_body += Space(space_cnt) + amount + "\r\n";
            }

            str_body += "------------------------------------------\r\n";  // 42


            String yyyymmdd = get_today_date();
            String hhmmss = get_today_time();

            str1 = "출력: " + yyyymmdd.Substring(0, 4) + "-" + yyyymmdd.Substring(4, 2) + "-" + yyyymmdd.Substring(6, 2) + " " + hhmmss.Substring(0, 2) + ":" + hhmmss.Substring(2, 2) + ":" + hhmmss.Substring(2, 2);
            str2 = "담당: " + mUserName;
            space_cnt = 42 - (encodelen(str1) + encodelen(str2));
            str_body += str1 + Space(space_cnt) + str2 + "\r\n";

            return str_body;
        }

        private String make_print_pay()
        { 
            String str_body = "";
            String str1 = "";
            String str2 = "";
            int space_cnt = 0;

            str_body += "[ 정 산 표 ]\r\n\r\n";


            str1 = "영업일: " + mBizDate.Substring(0, 4) + "-" + mBizDate.Substring(4, 2) + "-" + mBizDate.Substring(6, 2);
            str2 = "POS No. " + myPosNo;
            space_cnt = 42 - (encodelen(str1) + encodelen(str2));
            str_body += str1 + Space(space_cnt) + str2;

            str_body += "------------------------------------------\r\n";  // 42

            str_body += "<결제집계내역>\r\n";
            str_body += "------------------------------------------\r\n";  // 42

            space_cnt = 16 - encodelen("종류");
            str_body += "종류" + Space(space_cnt);
            space_cnt = 12 - encodelen("건수");
            str_body += Space(space_cnt) + "건수";
            space_cnt = 14 - encodelen("금액");
            str_body += Space(space_cnt) + "금액" + "\r\n";

            str_body += "------------------------------------------\r\n";  // 42


            space_cnt = 16 - encodelen("현금");       str_body += "현금" + Space(space_cnt);
            str1 = cash_cnt.ToString("N0");             space_cnt = 12 - encodelen(str1);            str_body += Space(space_cnt) + str1;
            str2 = cash_amount.ToString("N0");          space_cnt = 14 - encodelen(str2);            str_body += Space(space_cnt) + str2 + "\r\n";

            space_cnt = 16 - encodelen("카드"); str_body += "카드" + Space(space_cnt);
            str1 = card_cnt.ToString("N0"); space_cnt = 12 - encodelen(str1); str_body += Space(space_cnt) + str1;
            str2 = card_amount.ToString("N0"); space_cnt = 14 - encodelen(str2); str_body += Space(space_cnt) + str2 + "\r\n";

            space_cnt = 16 - encodelen("간편"); str_body += "간편" + Space(space_cnt);
            str1 = easy_cnt.ToString("N0"); space_cnt = 12 - encodelen(str1); str_body += Space(space_cnt) + str1;
            str2 = easy_amount.ToString("N0"); space_cnt = 14 - encodelen(str2); str_body += Space(space_cnt) + str2 + "\r\n";

            space_cnt = 16 - encodelen("쿠폰"); str_body += "쿠폰" + Space(space_cnt);
            str1 = cert_cnt.ToString("N0"); space_cnt = 12 - encodelen(str1); str_body += Space(space_cnt) + str1;
            str2 = cert_amount.ToString("N0"); space_cnt = 14 - encodelen(str2); str_body += Space(space_cnt) + str2 + "\r\n";


            space_cnt = 16 - encodelen("현금취소"); str_body += "현금취소" + Space(space_cnt);
            str1 = cash_cnt_cncl.ToString("N0"); space_cnt = 12 - encodelen(str1); str_body += Space(space_cnt) + str1;
            str2 = cash_amount_cncl.ToString("N0"); space_cnt = 14 - encodelen(str2); str_body += Space(space_cnt) + str2 + "\r\n";

            space_cnt = 16 - encodelen("카드취소"); str_body += "카드취소" + Space(space_cnt);
            str1 = card_cnt_cncl.ToString("N0"); space_cnt = 12 - encodelen(str1); str_body += Space(space_cnt) + str1;
            str2 = card_amount_cncl.ToString("N0"); space_cnt = 14 - encodelen(str2); str_body += Space(space_cnt) + str2 + "\r\n";

            space_cnt = 16 - encodelen("간편취소"); str_body += "간편취소" + Space(space_cnt);
            str1 = easy_cnt_cncl.ToString("N0"); space_cnt = 12 - encodelen(str1); str_body += Space(space_cnt) + str1;
            str2 = easy_amount_cncl.ToString("N0"); space_cnt = 14 - encodelen(str2); str_body += Space(space_cnt) + str2 + "\r\n";

            space_cnt = 16 - encodelen("쿠폰취소"); str_body += "쿠폰취소" + Space(space_cnt);
            str1 = cert_cnt_cncl.ToString("N0"); space_cnt = 12 - encodelen(str1); str_body += Space(space_cnt) + str1;
            str2 = cert_amount_cncl.ToString("N0"); space_cnt = 14 - encodelen(str2); str_body += Space(space_cnt) + str2 + "\r\n";

            str_body += "------------------------------------------\r\n";  // 42

            space_cnt = 16 - encodelen("결제합계"); str_body += "결제합계" + Space(space_cnt);
            str1 = net_count.ToString("N0"); space_cnt = 12 - encodelen(str1); str_body += Space(space_cnt) + str1;
            str2 = net_amount.ToString("N0"); space_cnt = 14 - encodelen(str2); str_body += Space(space_cnt) + str2 + "\r\n";

            str_body += "------------------------------------------\r\n";  // 42


            int tax_amount = net_amount / 11;
            int supply_amount = net_amount - tax_amount;


            String str_amount = supply_amount.ToString("N0");
            space_cnt = 28 - encodelen("공급가액"); str_body += "공급가액" + Space(space_cnt);
            space_cnt = 14 - encodelen(str_amount); str_body += Space(space_cnt) + str_amount;

            str_amount = tax_amount.ToString("N0");
            space_cnt = 28 - encodelen("부가세액"); str_body += "부가세액" + Space(space_cnt);
            space_cnt = 14 - encodelen(str_amount); str_body += Space(space_cnt) + str_amount;

            str_amount = net_amount.ToString("N0");
            space_cnt = 28 - encodelen("실매출액"); str_body += "실매출액" + Space(space_cnt);
            space_cnt = 14 - encodelen(str_amount); str_body += Space(space_cnt) + str_amount;


            str_body += "------------------------------------------\r\n";  // 42



            // 입력권종목록
            int cash_starting = 0;

            int cnt_50000 = 0;
            int cnt_10000 = 0;
            int cnt_5000 = 0;
            int cnt_1000 = 0;
            int cnt_500 = 0;
            int cnt_100 = 0;
            int cnt_50 = 0;
            int cnt_10 = 0;
            int amount_etc = 0;

            int real_cash_amount = 0;


            String sUrl = "reportDailyCash?siteId=" + mSiteId + "&bizDt=" + mBizDate + "&posNo=" + myPosNo;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["dailyCash"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        cash_starting = convert_number(arr[i]["startingCash"].ToString());

                        cnt_50000 = convert_number(arr[i]["fiftyKCnt"].ToString());
                        cnt_10000 = convert_number(arr[i]["tenKCnt"].ToString());
                        cnt_5000 = convert_number(arr[i]["fiveKCnt"].ToString());
                        cnt_1000 = convert_number(arr[i]["oneKCnt"].ToString());
                        cnt_500 = convert_number(arr[i]["fiveHCnt"].ToString());
                        cnt_100 = convert_number(arr[i]["oneHCnt"].ToString());
                        cnt_50 = convert_number(arr[i]["fiftyCnt"].ToString());
                        cnt_10 = convert_number(arr[i]["tenCnt"].ToString());
                        amount_etc = convert_number(arr[i]["etcAmount"].ToString());

                        real_cash_amount = amount_etc + (cnt_50000 * 50000) + (cnt_10000 * 10000) + (cnt_5000 * 5000) + (cnt_1000 * 1000) + (cnt_500 * 500) + (cnt_100 * 100) + (cnt_50 * 50) + (cnt_10 * 10);
                    }
                }
                else
                {
                    //MessageBox.Show("데이터 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
            }



            // 현금매출액
            str_amount = (cash_amount - cash_amount_cncl).ToString("N0");
            space_cnt = 28 - encodelen("현금매출액"); str_body += "현금매출액" + Space(space_cnt);
            space_cnt = 14 - encodelen(str_amount); str_body += Space(space_cnt) + str_amount;

            // 준비금
            str_amount = cash_starting.ToString("N0");
            space_cnt = 28 - encodelen("준비금"); str_body += "준비금" + Space(space_cnt);
            space_cnt = 14 - encodelen(str_amount); str_body += Space(space_cnt) + str_amount;

            // 실현금액
            str_amount = real_cash_amount.ToString("N0");
            space_cnt = 28 - encodelen("실현금액"); str_body += "실현금액" + Space(space_cnt);
            space_cnt = 14 - encodelen(str_amount); str_body += Space(space_cnt) + str_amount;


            // 현금 과부족
            str_amount = (real_cash_amount - (cash_amount - cash_amount_cncl + cash_starting)).ToString("N0");
            space_cnt = 28 - encodelen("현금과부족"); str_body += "현금과부족" + Space(space_cnt);
            space_cnt = 14 - encodelen(str_amount); str_body += Space(space_cnt) + str_amount;


            str_body += "------------------------------------------\r\n\r\n";  // 42




            // 입력권종 합계
            str_body += "<입력권종목록>\r\n";
            str_body += "------------------------------------------\r\n";  // 42
            str_body += "권종                    수량          금액\r\n";  // 42
            str_body += "------------------------------------------\r\n";  // 42

            //
            space_cnt = 22 - encodelen("기타");            str_body += "기타" + Space(space_cnt);
            str_body += Space(6);
            space_cnt = 14 - encodelen(amount_etc + "");            str_body += Space(space_cnt) + amount_etc + "\r\n";
            //
            space_cnt = 22 - encodelen("50,000권");                  str_body += "50,000권" + Space(space_cnt);
            space_cnt = 6 - encodelen(cnt_50000 + "");              str_body += Space(space_cnt) + cnt_50000;
            space_cnt = 14 - encodelen((cnt_50000 * 50000) + "");   str_body += Space(space_cnt) + (cnt_50000 * 50000) + "\r\n";
            //
            space_cnt = 22 - encodelen("10,000권");                  str_body += "10,000권" + Space(space_cnt);
            space_cnt = 6 - encodelen(cnt_10000 + "");              str_body += Space(space_cnt) + cnt_10000;
            space_cnt = 14 - encodelen((cnt_10000 * 10000) + "");   str_body += Space(space_cnt) + (cnt_10000 * 10000) + "" + "\r\n";
            //
            space_cnt = 22 - encodelen("5,000권"); str_body += "5,000권" + Space(space_cnt);
            space_cnt = 6 - encodelen(cnt_5000 + ""); str_body += Space(space_cnt) + cnt_5000;
            space_cnt = 14 - encodelen((cnt_5000 * 5000) + ""); str_body += Space(space_cnt) + (cnt_5000 * 5000) + "" + "\r\n";
            //
            space_cnt = 22 - encodelen("1,000권"); str_body += "1,000권" + Space(space_cnt);
            space_cnt = 6 - encodelen(cnt_1000 + ""); str_body += Space(space_cnt) + cnt_1000;
            space_cnt = 14 - encodelen((cnt_1000 * 1000) + ""); str_body += Space(space_cnt) + (cnt_1000 * 1000) + "" + "\r\n";
            //
            space_cnt = 22 - encodelen("500권"); str_body += "500권" + Space(space_cnt);
            space_cnt = 6 - encodelen(cnt_500 + ""); str_body += Space(space_cnt) + cnt_500;
            space_cnt = 14 - encodelen((cnt_500 * 500) + ""); str_body += Space(space_cnt) + (cnt_500 * 500) + "" + "\r\n";
            //
            space_cnt = 22 - encodelen("100권"); str_body += "100권" + Space(space_cnt);
            space_cnt = 6 - encodelen(cnt_100 + ""); str_body += Space(space_cnt) + cnt_100;
            space_cnt = 14 - encodelen((cnt_100 * 100) + ""); str_body += Space(space_cnt) + (cnt_100 * 100) + "" + "\r\n";
            //
            space_cnt = 22 - encodelen("50권"); str_body += "50권" + Space(space_cnt);
            space_cnt = 6 - encodelen(cnt_50 + ""); str_body += Space(space_cnt) + cnt_50;
            space_cnt = 14 - encodelen((cnt_50 * 500) + ""); str_body += Space(space_cnt) + (cnt_50 * 50) + "" + "\r\n";
            //
            space_cnt = 22 - encodelen("10권"); str_body += "10권" + Space(space_cnt);
            space_cnt = 6 - encodelen(cnt_10 + ""); str_body += Space(space_cnt) + cnt_10;
            space_cnt = 14 - encodelen((cnt_10 * 10) + ""); str_body += Space(space_cnt) + (cnt_10 * 10) + "" + "\r\n";

            str_body += "------------------------------------------\r\n";  // 42
                                                                        
             //
            str_amount = real_cash_amount.ToString("N0");
            space_cnt = 28 - encodelen("입력권종 합계"); str_body += "입력권종 합계" + Space(space_cnt);
            space_cnt = 14 - encodelen(str_amount); str_body += Space(space_cnt) + str_amount;

            str_body += "------------------------------------------\r\n";  // 42


            String yyyymmdd = get_today_date();
            String hhmmss = get_today_time();

            str1 = "출력: " + yyyymmdd.Substring(0, 4) + "-" + yyyymmdd.Substring(4, 2) + "-" + yyyymmdd.Substring(6, 2) + " " + hhmmss.Substring(0, 2) + ":" + hhmmss.Substring(2, 2) + ":" + hhmmss.Substring(2, 2);
            str2 = "담당: " + mUserName;
            space_cnt = 42 - (encodelen(str1) + encodelen(str2));
            str_body += str1 + Space(space_cnt) + str2 + "\r\n";

            return str_body;
        }

        private String make_print_goods()
        {
            String str_body = "";
            String str1 = "";
            String str2 = "";
            int space_cnt = 0;

            str_body += "[ 품목별 매출 ]\r\n\r\n";


            str1 = "영업일: " + mBizDate.Substring(0, 4) + "-" + mBizDate.Substring(4, 2) + "-" + mBizDate.Substring(6, 2);
            str2 = "POS No. " + myPosNo;
            space_cnt = 42 - (encodelen(str1) + encodelen(str2));
            str_body += str1 + Space(space_cnt) + str2;

            str_body += "------------------------------------------\r\n";  // 42

            space_cnt = 22 - encodelen("품 목 명");
            str_body += "품 목 명" + Space(space_cnt);
            space_cnt = 6 - encodelen("건수");
            str_body += Space(space_cnt) + "건수";
            space_cnt = 14 - encodelen("금액");
            str_body += Space(space_cnt) + "금액" + "\r\n";

            str_body += "------------------------------------------\r\n";  // 42


            for (int i = 0; i < lvwGoods.Items.Count; i++)
            {
                String goods_name = lvwGoods.Items[i].Text;
                String cnt = lvwGoods.Items[i].SubItems[1].Text;
                String amount = lvwGoods.Items[i].SubItems[2].Text;


                space_cnt = encodelen(goods_name) + encodelen(cnt);

                if (space_cnt > 28)
                {
                    str_body += goods_name + Space(42 - encodelen(goods_name)) + "\r\n";
                    str_body += Space(22) + Space(6 - encodelen(cnt)) + cnt;
                }
                else
                {
                    str_body += goods_name + Space(28 - space_cnt) + cnt;
                }

                space_cnt = 14 - encodelen(amount);
                str_body += Space(space_cnt) + amount + "\r\n";

            }

            str_body += "------------------------------------------\r\n";  // 42


            String yyyymmdd = get_today_date();
            String hhmmss = get_today_time();

            str1 = "출력: " + yyyymmdd.Substring(0, 4) + "-" + yyyymmdd.Substring(4, 2) + "-" + yyyymmdd.Substring(6, 2) + " " + hhmmss.Substring(0, 2) + ":" + hhmmss.Substring(2, 2) + ":" + hhmmss.Substring(2, 2);
            str2 = "담당: " + mUserName;
            space_cnt = 42 - (encodelen(str1) + encodelen(str2));
            str_body += str1 + Space(space_cnt) + str2 + "\r\n";

            return str_body;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //
            thepos_app_log(1, this.Name, "Close", "");

            Close();
        }
    }
}

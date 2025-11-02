
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
using static thepos.thepos;

namespace thepos
{
    public partial class frmPayManager: Form
    {

        public static System.Windows.Forms.ListView mLvwPayManager;


        public frmPayManager()
        {
            InitializeComponent();

            initialize_the();

            load_pay_data();


            //
            thepos_app_log(1, this.Name, "open", "");

        }


        private void initialize_the()
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 40);
            lvwPayManager.SmallImageList = imgList;

            ImageList imgList2 = new ImageList();
            imgList2.ImageSize = new Size(1, 30);
            lvwPayOrder.SmallImageList = imgList2;


            mLvwPayManager = lvwPayManager;

        }


        private void load_pay_data()
        {
            String sUrl = "payment?siteId=" + mSiteId + "&bizDt=" + mBizDate + "&shopCode=" + myShopCode + "&posNo=" + myPosNo + "&tranType=A";
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["payments"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        String t_theNo = arr[i]["theNo"].ToString();
                        String t_billNo = arr[i]["billNo"].ToString();
                        String t_payClass = arr[i]["payClass"].ToString();

                        String t_cash = arr[i]["isCash"].ToString();
                        String t_card = arr[i]["isCard"].ToString();
                        String t_point = arr[i]["isPoint"].ToString();
                        String t_easy = arr[i]["isEasy"].ToString();
                        String t_cert = arr[i]["isCert"].ToString();


                        String t_payDate = arr[i]["payDate"].ToString();
                        String t_payTime = arr[i]["payTime"].ToString();
                        String t_posNo = arr[i]["posNo"].ToString();
                        int t_netAmount = convert_number(arr[i]["netAmount"].ToString());
                        int t_dcAmount = convert_number(arr[i]["dcAmount"].ToString());
                        String t_isCancel = arr[i]["isCancel"].ToString();

                        add_viewList(t_theNo, t_billNo, t_payClass, t_cash, t_card, t_point, t_easy, t_cert, t_payDate, t_payTime, t_posNo, t_netAmount, t_dcAmount, t_isCancel);
                    }
                }
                else
                {
                    //
                    thepos_app_log(3, this.Name, "viewList()", "데이터 오류. payment " + mObj["resultMsg"].ToString());

                    MessageBox.Show("데이터 오류. payment\n\n" + mObj["resultMsg"].ToString(), "thepos");
                }
            }
            else
            {
                //
                thepos_app_log(3, this.Name, "viewList()", "시스템오류. payment " + mErrorMsg);

                MessageBox.Show("시스템오류. payment\n\n" + mErrorMsg, "thepos");
            }




        }


        private void add_viewList(String t_theNo, String t_billNo, String t_payClass, String is_cash, String is_card, String is_point, String is_easy, String is_cert, String t_payDate, String t_payTime, String t_posNo, int t_netAmount, int t_dcAmount, String t_isCancel)
        {
            ListViewItem lvItem = new ListViewItem();

            lvItem.Tag = t_theNo;
            lvItem.Text = t_billNo;
            lvItem.SubItems.Add(get_pay_class_name(t_payClass));

            String pay_keep = "";

            if (is_cash != "1") is_cash = "0";
            if (is_card != "1") is_card = "0";
            if (is_point != "1") is_point = "0";
            if (is_easy != "1") is_easy = "0";
            if (is_cert != "1") is_cert = "0";


            pay_keep = is_cash + is_card + is_point + is_easy + is_cert;
            lvItem.SubItems.Add(get_pay_type_group_name(pay_keep));


            if (pay_keep == "00000")
            {
                pay_keep = "10001";
            }


            lvItem.SubItems.Add(get_MMddHHmm(t_payDate, t_payTime));
            lvItem.SubItems.Add(t_posNo);
            lvItem.SubItems.Add(t_netAmount.ToString("N0"));


            if (t_dcAmount > 0)
            {
                lvItem.SubItems.Add("Y");
            }
            else
            {
                lvItem.SubItems.Add("");
            }

            if (t_isCancel == "y")
                lvItem.SubItems.Add("취소:");
            else if (t_isCancel == "Y")
                lvItem.SubItems.Add("취소");
            else if (t_isCancel == "0")
                lvItem.SubItems.Add("취소중");
            else
                lvItem.SubItems.Add("");


            lvItem.SubItems.Add(pay_keep);
            lvItem.SubItems.Add(t_payClass);
            lvItem.SubItems.Add(t_isCancel);


            if (t_isCancel == "Y" | t_isCancel == "y")
            {
                lvItem.ForeColor = Color.Gray;
                lvItem.SubItems[1].ForeColor = Color.Gray;
                lvItem.SubItems[2].ForeColor = Color.Gray;
                lvItem.SubItems[3].ForeColor = Color.Gray;
                lvItem.SubItems[4].ForeColor = Color.Gray;
                lvItem.SubItems[5].ForeColor = Color.Gray;
                lvItem.SubItems[6].ForeColor = Color.Gray;
                lvItem.SubItems[7].ForeColor = Color.Gray;
                lvItem.SubItems[8].ForeColor = Color.Gray;
            }

            lvwPayManager.Items.Add(lvItem);

        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            //
            thepos_app_log(1, this.Name, "Close", "");

            Close();
        }

        private void lvwPayManager_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwPayManager.SelectedItems.Count <= 0)
            {
                return;
            }

            String tTheNo = lvwPayManager.SelectedItems[0].Tag.ToString();
            String pay_keep = lvwPayManager.SelectedItems[0].SubItems[lvwPayManager.Columns.IndexOf(paykeep)].Text;

            // 취소된 건을 선택하면 취소전표를 출력한다.. 아래와 동일
            String isCancel = lvwPayManager.SelectedItems[0].SubItems[lvwPayManager.Columns.IndexOf(cancel_code)].Text;


            String tran_type = "A";
            if (isCancel == "Y" | isCancel == "y")
            {
                tran_type = "C";
            }

            view_list_pay_order(tTheNo, tran_type, pay_keep);
        }

        private void view_list_pay_order(String tTheNo, String tranType, String pay_keep)
        {
            lvwPayOrder.Items.Clear();

            //
            view_list_order(tTheNo, tranType, pay_keep);

            //
            view_list_pay(tTheNo, tranType, pay_keep);

        }


        private void view_list_order(String tTheNo, String tranType, String pay_keep)
        {
            String sUrl = "orderItem?siteId=" + mSiteId + "&theNo=" + tTheNo + "&bizDt=" + mBizDate + "&tranType=A";

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["orderItems"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        //
                        ListViewItem lvItem = new ListViewItem();

                        String shop_order_no = arr[i]["shopOrderNo"].ToString();

                        if (shop_order_no.Length >= 4)
                            lvItem.Tag = "O";
                        else
                            lvItem.Tag = "";

                        lvItem.Text = arr[i]["shopOrderNo"].ToString();
                        lvItem.SubItems.Add(arr[i]["goodsName"].ToString());
                        lvItem.SubItems.Add(convert_number(arr[i]["cnt"].ToString()).ToString("N0"));
                        lvItem.SubItems.Add(get_shop_name(arr[i]["shopCode"].ToString()));
                        lvwPayOrder.Items.Add(lvItem);
                    }
                }
                else
                {
                    //
                    thepos_app_log(3, this.Name, "view_list_order()", "주문 데이터 오류 " + mObj["resultMsg"].ToString());

                    MessageBox.Show("주문 데이터 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                }
            }
            else
            {
                //
                thepos_app_log(3, this.Name, "view_list_order()", "시스템오류. orderItem " + mErrorMsg);

                MessageBox.Show("시스템오류. orderItem\n\n" + mErrorMsg, "thepos");
            }
        }

        private void view_list_pay(String tTheNo, String tranType, String pay_keep)
        {
            String pay_keep_cash = pay_keep.Substring(0, 1);
            String pay_keep_card = pay_keep.Substring(1, 1);
            String pay_keep_point = pay_keep.Substring(2, 1);
            String pay_keep_easy = pay_keep.Substring(3, 1);
            String pay_keep_cert = pay_keep.Substring(4, 1);

            String sUrl = "";
            String pay_name = "";
            int pay_amount = 0;



            //! 카드결제
            if (pay_keep_card == "1")
            {
                sUrl = "paymentCard?siteId=" + mSiteId + "&theNo=" + tTheNo + "&tranType=A" + "&bizDt=" + mBizDate;

                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["paymentCards"].ToString();
                        JArray arr = JArray.Parse(data);

                        for (int i = 0; i < arr.Count; i++)
                        {
                            {
                                pay_name = get_pay_type_name(arr[i]["payType"].ToString()) + "[" + arr[i]["cardName"].ToString().Trim() + "]";
                                pay_amount = convert_number(arr[i]["amount"].ToString());

                                if (tranType == "C")
                                    pay_amount = -pay_amount;

                                //
                                ListViewItem lvItem = new ListViewItem();
                                lvItem.Tag = "P";
                                lvItem.Text = "(결제)";
                                lvItem.SubItems.Add(pay_name);
                                lvItem.SubItems.Add(pay_amount.ToString("N0"));
                                lvItem.SubItems.Add("");
                                lvwPayOrder.Items.Add(lvItem);
                            }
                        }
                    }
                }
            }

        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (lvwPayManager.SelectedItems.Count < 1)
            {
                return;
            }

            String the_no = lvwPayManager.SelectedItems[0].Tag.ToString();
            String pay_keep = lvwPayManager.SelectedItems[0].SubItems[lvwPayManager.Columns.IndexOf(paykeep)].Text;
            int select_idx = lvwPayManager.SelectedItems[0].Index;


            frmPayCancel fForm = new frmPayCancel(the_no, myPosNo, mBizDate, pay_keep, select_idx);
            fForm.ShowDialog();



        }


        private void btnBill_Click(object sender, EventArgs e)
        {
            if (lvwPayManager.SelectedItems.Count < 1)
            {
                return;
            }

            String tTheNo = lvwPayManager.SelectedItems[0].Tag.ToString();
            String pay_keep = lvwPayManager.SelectedItems[0].SubItems[lvwPayManager.Columns.IndexOf(paykeep)].Text;


            // 취소된 건을 선택하면 취소전표를 출력한다.. 위와 동일
            String isCancel = lvwPayManager.SelectedItems[0].SubItems[lvwPayManager.Columns.IndexOf(cancel_code)].Text;

            String tran_type = "A";
            if (isCancel == "Y" | isCancel == "y")
            {
                tran_type = "C";
            }


            String[] order_no_from_to = new String[2];

            order_no_from_to[0] = "";
            order_no_from_to[1] = "";


            // 영수증 출력
            print_bill(tTheNo, tran_type, "", pay_keep, false, order_no_from_to); // card
        }



        public static void reviewList(String biz_date, String pos_no, String the_no, int select_index)
        {
            String t_theNo = "";
            //String t_point_theNo = "";
            String t_billNo = "";
            String t_payClass = "";

            String is_cash = "0";
            String is_card = "0";
            String is_point = "0";
            String is_easy = "0";
            String is_cert = "0";

            String t_payDate = "";
            String t_payTime = "";
            String t_posNo = "";
            int t_netAmount = 0;
            int t_dcAmount = 0;
            String t_isCancel = "";



            String sUrl = "payment?siteId=" + mSiteId + "&bizDt=" + biz_date + "&posNo=" + pos_no + "&theNo=" + the_no + "&tranType=A";
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["payments"].ToString();
                    JArray arr = JArray.Parse(data);

                    if (arr.Count > 0)
                    {
                        t_theNo = arr[0]["theNo"].ToString();
                        //t_point_theNo = arr[0]["pointTheNo"].ToString();   //??????????
                        t_billNo = arr[0]["billNo"].ToString();
                        t_payClass = arr[0]["payClass"].ToString();

                        is_cash = arr[0]["isCash"].ToString();
                        is_card = arr[0]["isCard"].ToString();
                        is_point = arr[0]["isPoint"].ToString();
                        is_easy = arr[0]["isEasy"].ToString();
                        is_cert = arr[0]["isCert"].ToString();

                        t_payDate = arr[0]["payDate"].ToString();
                        t_payTime = arr[0]["payTime"].ToString();
                        t_posNo = arr[0]["posNo"].ToString();
                        t_netAmount = convert_number(arr[0]["netAmount"].ToString());
                        t_dcAmount = convert_number(arr[0]["dcAmount"].ToString());
                        t_isCancel = arr[0]["isCancel"].ToString();
                    }
                }
                else
                {
                    //
                    thepos_app_log(3, "frmPayManager", "reviewList()", "데이터 오류. payment " + mObj["resultMsg"].ToString());

                    MessageBox.Show("데이터 오류 payment\n\n" + mObj["resultMsg"].ToString(), "thepos");
                }
            }
            else
            {
                //
                thepos_app_log(3, "frmPayManager", "reviewList()", "시스템오류 payment " + mErrorMsg);

                MessageBox.Show("시스템오류 payment\n\n" + mErrorMsg, "thepos");
            }




            String pay_keep = "";

            if (is_cash != "1") is_cash = "0";
            if (is_card != "1") is_card = "0";
            if (is_point != "1") is_point = "0";
            if (is_easy != "1") is_easy = "0";
            if (is_cert != "1") is_cert = "0";

            pay_keep = is_cash + is_card + is_point + is_easy + is_cert;



            ListViewItem lvItem = new ListViewItem();


            if (is_point == "1")
            {
                //lvItem.Tag = t_point_theNo;
                lvItem.Tag = t_theNo;
            }
            else
            {
                lvItem.Tag = t_theNo;
            }


            lvItem.Text = t_billNo;
            lvItem.SubItems.Add(get_pay_class_name(t_payClass));



            lvItem.SubItems.Add(get_pay_type_group_name(pay_keep));

            if (pay_keep == "00000")
            {
                pay_keep = "10001";
            }



            lvItem.SubItems.Add(get_MMddHHmm(t_payDate, t_payTime));
            lvItem.SubItems.Add(t_posNo);
            lvItem.SubItems.Add(t_netAmount.ToString("N0"));


            //
            if (t_dcAmount > 0)
                lvItem.SubItems.Add("Y");
            else
                lvItem.SubItems.Add("");

            //
            if (t_isCancel == "y")
                lvItem.SubItems.Add("취소:");
            else if (t_isCancel == "Y")
                lvItem.SubItems.Add("취소");
            else if (t_isCancel == "0")
                lvItem.SubItems.Add("취소중");
            else
                lvItem.SubItems.Add("");



            lvItem.SubItems.Add(pay_keep);
            lvItem.SubItems.Add(t_payClass);
            lvItem.SubItems.Add(t_isCancel);


            if (t_isCancel == "Y")
            {
                lvItem.ForeColor = Color.Gray;
                lvItem.SubItems[1].ForeColor = Color.Gray;
                lvItem.SubItems[2].ForeColor = Color.Gray;
                lvItem.SubItems[3].ForeColor = Color.Gray;
                lvItem.SubItems[4].ForeColor = Color.Gray;
                lvItem.SubItems[5].ForeColor = Color.Gray;
                lvItem.SubItems[6].ForeColor = Color.Gray;
                lvItem.SubItems[7].ForeColor = Color.Gray;
                lvItem.SubItems[8].ForeColor = Color.Gray;
            }

            mLvwPayManager.Items[select_index] = lvItem;
            lvItem.Selected = true;
            mLvwPayManager.Select();
            mLvwPayManager.EnsureVisible(select_index);

        }

    }
}

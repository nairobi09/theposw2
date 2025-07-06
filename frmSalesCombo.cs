using BrightIdeasSoftware;
using Newtonsoft.Json.Linq;
using PrinterUtility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using static System.IO.Directory;
using System.IO.Ports;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using theposw2.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Newtonsoft.Json;
using static thepos2.thepos;
using theposw2;
using thepos;

namespace thepos2
{
    public partial class frmSalesCombo : Form
    {

        RadioButton[] mRbGroup = new RadioButton[5];

        String last_groupcode = "";  // 상품그룹을 클릭했을 경우 눌려진버튼을 또 눌렀는지 비교하기 위함.


        Panel[] mP = new Panel[8];
        PictureBox[] mPbGoods = new PictureBox[8];
        PictureBox[] mPbBadges = new PictureBox[8];
        Label[] mLblName = new Label[8];
        Label[] mLblAmt = new Label[8];
        Label[] mLblNotice = new Label[8];



        List<int> lstNo = new List<int>();
        List<String> lstGoodsCode = new List<String>();

        List<String> lstGoodsName = new List<String>();
        List<String> lstGoodsNameEn = new List<String>();
        List<String> lstGoodsNameCh = new List<String>();
        List<String> lstGoodsNameJp = new List<String>();

        List<String> lstGoodsNotice = new List<String>();

        List<String> lstBadgesId = new List<String>();

        List<int> lstGoodsAmt = new List<int>();

        List<String> lstCutout = new List<String>();
        List<String> lstSoldout = new List<String>();
        List<String> lstImage = new List<String>();

        List<int> lstGoodsIndex = new List<int>();


        String NoImage = "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AAAAAAALYAKCAFIACkABSAAAoIDWoAAAAAAAAAAAAAALSkBQCFAIAAUEAABQQALYoIUAAAAhQACFAIUgKA//2gAIAQIAAQUA97fu6ycyIwRkjgYIiIweE4nA5HEiIiIiIiIiIiIiIiIiIiI8R6pEREREREREREREREREREYIiI4GDBgwYI8RGSIyRERERgiIwRERERERERERERERERERERERERERkjJERERGCIiMERERERERERERERERERERERERERERERGCIiMGCIiIiIiIiIiIiIiIiIiIiIiIiIjBwMkcSIwZPAREREYMmCIiMkRzIiIiIiIiIiIiIiIiIiIiIiIiIiIiIiIiIiIiIiIiIiIiMERERERGSIjJERk4EYIiOJEcSMERERERERERERERkiIiIiIiPWMHjPaIiIiIiIiIiIiIiIiIiIj+AewfjzwnEwZI5mDkcCIjh//aAAgBAwABBQD/ABt8jPsM83xPBwzlnizPByzl/SM8mZyzlngzMzM5Z4MzM5ZmZmZn9O8HL/KcvFnLM8WeLPts/n2ZmcszOWZmZmZmZmZmfSf8j//aAAgBAQABBQDe9rudzudzudzudzu7nc7mdzudzudzudzudzud3eHc7tb2712RyIwRERERGSIwRFrXe9dkREREREREREREREREYLX/AHeuyIiIjBEREREREREaiIiLWu967IiIiIiIiIiIiIjBgiIta73rswREREYIiIiIiIiIyRa13vURERERERG43ERERuIiIiIi1rveuzoiIiIiIiIiIiIiIiIiLWu96wRERuNxEXcY7iIiMGDcRu7i7taiIiIiIiIiIiIiIiIiIiIiIjcREbiIiIiIiIiIiIjJEREREREREREYIiIiIiIiIiIiIjcRERERERERERERERdxERERERERERERERERERERERERERERERERERERERERERERERERERERERERERERfMREREaiL5iIiIvmIi+YiIiIiIiIiIiIiIiIiIiIiIwREZIyREYMmDBHAiIiIi+YvmIiIiIvmIiI1EXzERERERF3ERERERERERERERERERERERERERERF1ERERERERERERERERERERERERERERERERERERERERERERERER4CMHA8Rk8pEZIjwEcjznM/vmTJg4EcjgYOP//aAAgBAgIGPwBhP//aAAgBAwIGPwBhP//aAAgBAQEGPwBhP//Z";



        int disp_group_page_no = 0;
        int disp_goods_page_no = 0;

        int mNetAmount = 0;

        String sysadmin_pw_patern = "";


        String[] mLangAmountTitleArr = new string[4];
        String[] mLangPayCardArr = new string[4];


        String[] mLangLvwNameArr = new string[4];
        String[] mLangLvwAmtArr = new string[4];
        String[] mLangLvwQtyArr = new string[4];
        String[] mLangLvwPriceArr = new string[4];



        public frmSalesCombo()
        {
            InitializeComponent();


            //
            Application.DoEvents();

            initialize_the();


            //
            thepos_app_log(1, this.Name, "Open", "");




            // 데이터 로드 및 초기화 작업, 기초원장 리로드도 동일하게
            init_reload();



            // 버튼 클릭
            this.lvwOrderItem.ButtonClick += delegate (object sender, CellClickEventArgs e)
            {
                int rowIndex = e.RowIndex;
                int columnIndex = e.ColumnIndex;


                if (columnIndex == 4)   // 수량 감소
                {
                    if (mOrderItemList[rowIndex].cnt > 1)
                    {
                        set_item_change_ordercnt(rowIndex, "add", -1);
                        lvwOrderItem.Items[rowIndex].EnsureVisible();
                        ReCalculateAmount();
                    }
                }
                else if (columnIndex == 5)  // 수량 증가
                {
                    set_item_change_ordercnt(rowIndex, "add", 1);
                    lvwOrderItem.Items[rowIndex].EnsureVisible();
                    ReCalculateAmount();
                }
                else if (columnIndex == 6)  // 항목 삭제
                {
                    mOrderItemList.RemoveAt(rowIndex);

                    for (int i = 0; i < mOrderItemList.Count; i++)
                    {
                        MemOrderItem oi = mOrderItemList[i];
                        mOrderItemList[i] = oi;
                    }

                    lvwOrderItem.SetObjects(mOrderItemList);
                    ReCalculateAmount();
                }

            };



            // 기본로고
            if (mKioskLogoImage.Length > 0)
            {
                try
                {
                byte[] imgBytes = Convert.FromBase64String(mKioskLogoImage);
                MemoryStream ms = new MemoryStream(imgBytes, 0, imgBytes.Length);
                ms.Write(imgBytes, 0, imgBytes.Length);
                pbLogo.Image = System.Drawing.Image.FromStream(ms, true);
                }
                catch
                {

                }

            }


            // 다국어
            if (mMultiLanguage == "Y")
            {
                panelLang.Visible = true;
            }



            // 대기화면
            if (mWaitingDisplay == "Y")
            {
                panelWelcome.Visible = true;
                panelWelcome.Size = new System.Drawing.Size(1080, 1920);

                timerWelcome.Interval = mWaitingSecond * 1024;


                // 기본 대기화면
                if (mWaitingDisplayImage.Length > 0)
                {
                    try
                    {
                        byte[] imgBytes = Convert.FromBase64String(mWaitingDisplayImage);
                        MemoryStream ms = new MemoryStream(imgBytes, 0, imgBytes.Length);
                        ms.Write(imgBytes, 0, imgBytes.Length);
                        picSlide.Image = System.Drawing.Image.FromStream(ms, true);
                    }
                    catch
                    {

                    }
                }

            }


            tbBarcodeScan.Text = "";
            tbBarcodeScan.Focus();
        }




        private void init_reload()
        {

            //
            disp_group_page_no = 0;

            display_goodsgroup(disp_group_page_no);

            mRbGroup[0].Checked = true;


            String groupcode = mRbGroup[0].Tag.ToString();
            ClickedGoodsGroup(groupcode, "Y");


            // 바코드 상품 로드
            load_goods_barcode();



            // 주문아이템
            mOrderItemList.Clear();
            lvwOrderItem.SetObjects(mOrderItemList);
            ReCalculateAmount();
        }



        private void initialize_the()
        {

            mLanguageNo = 0;


            // 그룹
            mRbGroup[0] = rbGroup0;
            mRbGroup[1] = rbGroup1;
            mRbGroup[2] = rbGroup2;
            mRbGroup[3] = rbGroup3;
            mRbGroup[4] = rbGroup4;


            // 상품패널
            mP[0] = p0;
            mP[1] = p1;
            mP[2] = p2;
            mP[3] = p3;
            mP[4] = p4;
            mP[5] = p5;
            mP[6] = p6;
            mP[7] = p7;


            // 상품 이미지
            mPbGoods[0] = pbGoods0;
            mPbGoods[1] = pbGoods1;
            mPbGoods[2] = pbGoods2;
            mPbGoods[3] = pbGoods3;
            mPbGoods[4] = pbGoods4;
            mPbGoods[5] = pbGoods5;
            mPbGoods[6] = pbGoods6;
            mPbGoods[7] = pbGoods7;


            // 상품 배지
            mPbBadges[0] = pbBadges0;
            mPbBadges[1] = pbBadges1;
            mPbBadges[2] = pbBadges2;
            mPbBadges[3] = pbBadges3;
            mPbBadges[4] = pbBadges4;
            mPbBadges[5] = pbBadges5;
            mPbBadges[6] = pbBadges6;
            mPbBadges[7] = pbBadges7;


            // 상품명
            mLblName[0] = lblGoodsName0;
            mLblName[1] = lblGoodsName1;
            mLblName[2] = lblGoodsName2;
            mLblName[3] = lblGoodsName3;
            mLblName[4] = lblGoodsName4;
            mLblName[5] = lblGoodsName5;
            mLblName[6] = lblGoodsName6;
            mLblName[7] = lblGoodsName7;

            // 상품단가
            mLblAmt[0] = lblGoodsAmt0;
            mLblAmt[1] = lblGoodsAmt1;
            mLblAmt[2] = lblGoodsAmt2;
            mLblAmt[3] = lblGoodsAmt3;
            mLblAmt[4] = lblGoodsAmt4;
            mLblAmt[5] = lblGoodsAmt5;
            mLblAmt[6] = lblGoodsAmt6;
            mLblAmt[7] = lblGoodsAmt7;


            // Notice
            mLblNotice[0] = lblNotice0;
            mLblNotice[1] = lblNotice1;
            mLblNotice[2] = lblNotice2;
            mLblNotice[3] = lblNotice3;
            mLblNotice[4] = lblNotice4;
            mLblNotice[5] = lblNotice5;
            mLblNotice[6] = lblNotice6;
            mLblNotice[7] = lblNotice7;



            this.lv_name.Renderer = rendererName();
            this.lv_amt.Renderer = rendererAmt();


            //?? 리스트뷰 컬럼명
            mLangLvwNameArr[0] = "상품명";
            mLangLvwAmtArr[0] = "단가";
            mLangLvwQtyArr[0] = "수량";
            mLangLvwPriceArr[0] = "금액";

            mLangLvwNameArr[1] = "Name";
            mLangLvwAmtArr[1] = "Amt";
            mLangLvwQtyArr[1] = "Qty";
            mLangLvwPriceArr[1] = "Price";

            mLangLvwNameArr[2] = "品名";
            mLangLvwAmtArr[2] = "單價";
            mLangLvwQtyArr[2] = "數量";
            mLangLvwPriceArr[2] = "價格";

            mLangLvwNameArr[3] = "商品名";
            mLangLvwAmtArr[3] = "単価";
            mLangLvwQtyArr[3] = "数量";
            mLangLvwPriceArr[3] = "金額";




            //??
            mLangAmountTitleArr[0] = "총결제금액";
            mLangAmountTitleArr[1] = "Total Price";
            mLangAmountTitleArr[2] = "價格";
            mLangAmountTitleArr[3] = "支払金額";
            //??
            mLangPayCardArr[0] = "결제하기";
            mLangPayCardArr[1] = "PAY";
            mLangPayCardArr[2] = "決濟";
            mLangPayCardArr[3] = "支払う";

        }



        private void load_goods_barcode()
        {
            String sUrl = "goods?siteId=" + mSiteId;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["goods"].ToString();
                    JArray arr = JArray.Parse(data);

                    mGoodsBarcodeList = new List<Goods>();
                    mGoodsBarcodeList.Clear();

                    for (int i = 0; i < arr.Count; i++)
                    {
                        if (arr[i]["barCode"].ToString().Trim() != "")
                        {
                            Goods goods = new Goods();
                            goods.goods_code = arr[i]["goodsCode"].ToString();
                            goods.goods_name = arr[i]["goodsName"].ToString();
                            goods.amt = int.Parse(arr[i]["amt"].ToString());
                            goods.online_coupon = arr[i]["onlineCoupon"].ToString();
                            goods.ticket = arr[i]["ticketYn"].ToString();
                            goods.taxfree = arr[i]["taxFree"].ToString();
                            goods.shop_code = arr[i]["shopCode"].ToString();
                            goods.nod_code1 = arr[i]["nodCode1"].ToString();
                            goods.nod_code2 = arr[i]["nodCode2"].ToString();
                            goods.cutout = arr[i]["cutout"].ToString();
                            goods.soldout = arr[i]["soldout"].ToString();
                            goods.allim = arr[i]["allim"].ToString();
                            goods.bar_code = arr[i]["barCode"].ToString().Trim();
                            mGoodsBarcodeList.Add(goods);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("상품정보 오류. goods\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }



        }




        private void display_goodsgroup(int group_page_no)
        {
            for (int i = 0; i < 5; i++)
            {
                mRbGroup[i].Tag = "";
                mRbGroup[i].Text = "";
                RemoveClickEvent(mRbGroup[i]);
                mRbGroup[i].Checked = false;
                mRbGroup[i].Enabled = false;
            }


            int last_no = mGoodsGroup.Count - 1;
            int from_no = group_page_no * 5;
            int to_no = group_page_no * 5 + 4;

            if (last_no < to_no)
            {
                to_no = last_no;
            }



            int btn_idx = 0;

            for (int i = from_no; i <= to_no; i++)
            {
                mRbGroup[btn_idx].Enabled = true;
                mRbGroup[btn_idx].Tag = mGoodsGroup[i].group_code;

                mRbGroup[btn_idx].Text = mGoodsGroup[i].group_name[mLanguageNo].Replace("  ", "\r\n");


                // 절판은 로그인다운로드에서 아예 제외시킴.

                // 품절처리
                if (mGoodsGroup[i].soldout == "Y")
                {
                    mRbGroup[btn_idx].ForeColor = Color.Gray;
                }
                else
                {
                    String group_code = mRbGroup[btn_idx].Tag.ToString();

                    if (group_code == last_groupcode)
                    {
                        mRbGroup[btn_idx].Checked = true;
                    }


                    //
                    mRbGroup[btn_idx].Click += (sender, args) => ClickedGoodsGroup(group_code, "N");
                }

                btn_idx++;
            }


            if (from_no == 0)
            {
                btnGroupPrev.Text = "◁";
                btnGroupPrev.Enabled = false;
            }
            else
            {
                btnGroupPrev.Text = "◀";
                btnGroupPrev.Enabled = true;
            }


            if (to_no == last_no)
            {
                btnGroupNext.Text = "▷";
                btnGroupNext.Enabled = false;
            }
            else
            {
                btnGroupNext.Text = "▶";
                btnGroupNext.Enabled = true;
            }

        }


        // 그룹
        private void RemoveClickEvent(RadioButton b)
        {
            FieldInfo f1 = typeof(Control).GetField("EventClick", BindingFlags.Static | BindingFlags.NonPublic);

            object obj = f1.GetValue(b);
            PropertyInfo pi = b.GetType().GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Instance);

            EventHandlerList list = (EventHandlerList)pi.GetValue(b, null);
            list.RemoveHandler(obj, list[obj]);
        }

        // 상품 이미지
        private void RemoveClickEvent(PictureBox b)
        {
            FieldInfo f1 = typeof(Control).GetField("EventClick", BindingFlags.Static | BindingFlags.NonPublic);

            object obj = f1.GetValue(b);
            PropertyInfo pi = b.GetType().GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Instance);

            EventHandlerList list = (EventHandlerList)pi.GetValue(b, null);
            list.RemoveHandler(obj, list[obj]);
        }

        // 상품 명
        private void RemoveClickEvent(Label b)
        {
            FieldInfo f1 = typeof(Control).GetField("EventClick", BindingFlags.Static | BindingFlags.NonPublic);

            object obj = f1.GetValue(b);
            PropertyInfo pi = b.GetType().GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Instance);

            EventHandlerList list = (EventHandlerList)pi.GetValue(b, null);
            list.RemoveHandler(obj, list[obj]);
        }


        private void btnGroupPrev_Click(object sender, EventArgs e)
        {
            disp_group_page_no--;
            display_goodsgroup(disp_group_page_no);
        }

        private void btnGroupNext_Click(object sender, EventArgs e)
        {
            disp_group_page_no++;
            display_goodsgroup(disp_group_page_no);
        }


        private void ClickedGoodsGroup(String groupcode, String rescan)
        {
            if (last_groupcode == groupcode & rescan != "Y")
            {
                return;
            }

            lstNo.Clear();
            lstGoodsCode.Clear();
            lstGoodsName.Clear();
            lstGoodsNameEn.Clear();
            lstGoodsNameCh.Clear();
            lstGoodsNameJp.Clear();

            lstBadgesId.Clear();
            lstGoodsNotice.Clear();

            lstGoodsAmt.Clear();
            lstImage.Clear();
            lstCutout.Clear();
            lstSoldout.Clear();
            lstGoodsIndex.Clear();


            for (int i = 0; i < mGoodsItem.Length; i++)
            {
                if (groupcode == mGoodsItem[i].group_code)
                {
                    lstNo.Add(mGoodsItem[i].column);
                    lstGoodsCode.Add(mGoodsItem[i].goods_code);

                    lstGoodsName.Add(mGoodsItem[i].goods_name[0]);
                    lstGoodsNameEn.Add(mGoodsItem[i].goods_name[1]);
                    lstGoodsNameCh.Add(mGoodsItem[i].goods_name[2]);
                    lstGoodsNameJp.Add(mGoodsItem[i].goods_name[3]);

                    lstGoodsNotice.Add(mGoodsItem[i].goods_notice);

                    lstBadgesId.Add(mGoodsItem[i].badges_id);

                    lstGoodsAmt.Add(mGoodsItem[i].amt);
                    lstImage.Add(mGoodsItem[i].image_path);
                    lstCutout.Add(mGoodsItem[i].cutout);
                    lstSoldout.Add(mGoodsItem[i].soldout);
                    lstGoodsIndex.Add(i);
                }
            }


            // sort
            bool sort_complete = false;
            int t_int;
            String t_str;
            while (!sort_complete)
            {
                sort_complete = true;
                for (int i = 0; i < lstNo.Count - 1; i++)
                {
                    if (lstNo[i] > lstNo[i + 1])  // ascending
                    {
                        t_int = lstNo[i];           lstNo[i] = lstNo[i + 1];                lstNo[i + 1] = t_int;
                        t_str = lstGoodsCode[i];    lstGoodsCode[i] = lstGoodsCode[i + 1];  lstGoodsCode[i + 1] = t_str;
                        
                        t_str = lstGoodsName[i];    lstGoodsName[i] = lstGoodsName[i + 1];  lstGoodsName[i + 1] = t_str;
                        t_str = lstGoodsNameEn[i];  lstGoodsNameEn[i] = lstGoodsNameEn[i + 1]; lstGoodsNameEn[i + 1] = t_str;
                        t_str = lstGoodsNameCh[i];  lstGoodsNameCh[i] = lstGoodsNameCh[i + 1]; lstGoodsNameCh[i + 1] = t_str;
                        t_str = lstGoodsNameJp[i];  lstGoodsNameJp[i] = lstGoodsNameJp[i + 1]; lstGoodsNameJp[i + 1] = t_str;

                        t_str = lstBadgesId[i];     lstBadgesId[i] = lstBadgesId[i + 1];    lstBadgesId[i + 1] = t_str;

                        t_int = lstGoodsAmt[i];     lstGoodsAmt[i] = lstGoodsAmt[i + 1];    lstGoodsAmt[i + 1] = t_int;
                        t_str = lstImage[i];        lstImage[i] = lstImage[i + 1];          lstImage[i + 1] = t_str;
                        t_str = lstCutout[i];       lstCutout[i] = lstCutout[i + 1];        lstCutout[i + 1] = t_str;
                        t_str = lstSoldout[i];      lstSoldout[i] = lstSoldout[i + 1];      lstSoldout[i + 1] = t_str;
                        t_int = lstGoodsIndex[i];   lstGoodsIndex[i] = lstGoodsIndex[i + 1]; lstGoodsIndex[i + 1] = t_int;

                        t_str = lstGoodsNotice[i]; lstGoodsNotice[i] = lstGoodsNotice[i + 1]; lstGoodsNotice[i + 1] = t_str;

                        sort_complete = false;
                    }
                }
            }



            disp_goods_page_no = 0;

            display_goods(disp_goods_page_no);



            last_groupcode = groupcode;


            // 타이머 리셋
            reset_timer_waiting();


        }

        private void display_goods(int goods_page_no)
        {
            // 상품버튼 초기화
            for (int i = 0; i < 8; i++)
            {
                mLblName[i].Tag = "";
                mPbGoods[i].Image = null;
                
                mPbBadges[i].Image = null;
                mPbBadges[i].Visible = false;

                mLblName[i].Text = "";
                mLblAmt[i].Text = "";
                
                mLblNotice[i].Text = "";
                mLblNotice[i].Visible = false;

                mP[i].Enabled = false;

                RemoveClickEvent(mPbGoods[i]);
                RemoveClickEvent(mLblName[i]);

            }


            int last_no = lstGoodsCode.Count - 1;
            int from_no = goods_page_no * 8;
            int to_no = goods_page_no * 8 + 7;

            if (last_no < to_no)
            {
                to_no = last_no;
            }


            int btn_idx = 0;

            for (int i = from_no; i <= to_no; i++)
            {
                mLblName[btn_idx].Tag = lstGoodsIndex[i];
                
                //?
                if (mLanguageNo == 0)   mLblName[btn_idx].Text = lstGoodsName[i];
                else if (mLanguageNo == 1) mLblName[btn_idx].Text = lstGoodsNameEn[i];
                else if (mLanguageNo == 2) mLblName[btn_idx].Text = lstGoodsNameCh[i];
                else if (mLanguageNo == 3) mLblName[btn_idx].Text = lstGoodsNameJp[i];

                mLblAmt[btn_idx].Text = "₩ " + lstGoodsAmt[i].ToString("N0");
                
                //
                try
                {
                    byte[] imgBytes;

                    if (lstImage[i] == "")
                        imgBytes = Convert.FromBase64String(NoImage);
                    else
                        imgBytes = Convert.FromBase64String(lstImage[i]);

                    MemoryStream ms = new MemoryStream(imgBytes, 0, imgBytes.Length);
                    ms.Write(imgBytes, 0, imgBytes.Length);

                    mPbGoods[btn_idx].Image = System.Drawing.Image.FromStream(ms, true);
                }
                catch
                {

                }


                if (lstBadgesId[i] == "new")
                {
                    mPbBadges[btn_idx].Visible = true;
                    mPbBadges[btn_idx].Image = theposw2.Properties.Resources.badges_new3;
                }
                else if(lstBadgesId[i] == "best")
                {
                    mPbBadges[btn_idx].Visible = true;
                    mPbBadges[btn_idx].Image = theposw2.Properties.Resources.badges_best3;
                }
                else if (lstBadgesId[i] == "pick")
                {
                    mPbBadges[btn_idx].Visible = true;
                    mPbBadges[btn_idx].Image = theposw2.Properties.Resources.badges_pick3;
                }
                else
                {
                    mPbBadges[btn_idx].Visible = false;
                    mPbBadges[btn_idx].Image = null;
                }





                if (lstCutout[i] == "Y")  // 중지
                {
                    mLblAmt[btn_idx].Text = "[절판]";
                }
                else if (lstSoldout[i] == "Y")  // 품절
                {
                    //mBtnGoods[btn_idx].ForeColor = Color.Gray;
                    //mBtnGoods[btn_idx].BackColor = Color.White;
                    mLblAmt[btn_idx].Text = "[품절]";
                }
                else
                {
                    mP[btn_idx].Enabled = true;

                    int goods_index = convert_number(mLblName[btn_idx].Tag.ToString());
                    mPbGoods[btn_idx].Click += (sender, args) => ClickedGoodsItem(goods_index);
                    mLblName[btn_idx].Click += (sender, args) => ClickedGoodsItem(goods_index);
                }



                if (lstGoodsNotice[i] != "")
                {
                    mLblNotice[btn_idx].Text = lstGoodsNotice[i];
                    mLblNotice[btn_idx].Visible = true;
                }




                btn_idx++;
            }


            if (from_no == 0)
            {
                btnGoodsPrev.Text = "◁";
                btnGoodsPrev.Enabled = false;
            }
            else
            {
                btnGoodsPrev.Text = "◀";
                btnGoodsPrev.Enabled = true;
            }


            if (to_no == last_no)
            {
                btnGoodsNext.Text = "▷";
                btnGoodsNext.Enabled = false;
            }
            else
            {
                btnGoodsNext.Text = "▶";
                btnGoodsNext.Enabled = true;
            }

        }


        private void ClickedGoodsItem(int goods_index)
        {
            //
            // 온라인 쿠폰 인증 화면
            if (mGoodsItem[goods_index].online_coupon  == "Y")
            {
                //
                timerWelcome.Stop();

                frmCoupon1 fForm = new frmCoupon1();
                fForm.ShowDialog();

                //
                timerWelcome.Start();

                return;
            }
            

            //
            mOrderOptionItemList.Clear();

            int order_cnt = 1;

            if (mGoodsItem[goods_index].option_template_id != "")
            {
                frmOrderOption fForm = new frmOrderOption(mGoodsItem[goods_index]);
                DialogResult ret = fForm.ShowDialog();

                if (ret == DialogResult.Cancel)
                {
                    return;
                }

                // 수량을 전역변수에서 받음 : fk30fgu9w04ufgw
                order_cnt = mOrderCntInOption;

            }



            MemOrderItem orderItem = new MemOrderItem();
            int lv_idx = (get_lvitem_idx(mGoodsItem[goods_index].goods_code));  // 이미  동일 상품이 주문리스트뷰에 있는지

            if (lv_idx == -1)
            {
                //
                orderItem.option_name_description = "";   // 리스트뷰 상품항목 아랫줄에 표시
                orderItem.option_amt_description = "";    // 리스트뷰 단가항목 아랫줄에 표시



                // DB저장후에  : orderItem.optionNo 이 생김...


                if (mOrderOptionItemList.Count > 0)
                {
                    for (int k = 0; k < mOrderOptionItemList.Count; k++)
                    {
                        orderItem.option_name_description += " " + mOrderOptionItemList[k].option_item_name;

                        orderItem.option_amt += (int)mOrderOptionItemList[k].amt;
                    }
                }

                if (mOrderOptionItemList.Count > 0)
                {
                    orderItem.option_amt_description = orderItem.option_amt.ToString("N0");
                }
                else
                {
                    orderItem.option_amt_description = "";
                }

                //
                orderItem.option_item_cnt = mOrderOptionItemList.Count;
                orderItem.option_no = "";
                orderItem.orderOptionItemList = mOrderOptionItemList.ToList();  // ToList() : 리스트 복사, 참조가 아니고..

                orderItem.order_no = mOrderItemList.Count + 1;
                orderItem.goods_code = mGoodsItem[goods_index].goods_code.ToString();
                orderItem.goods_name = mGoodsItem[goods_index].goods_name[mLanguageNo];

                orderItem.ticket = mGoodsItem[goods_index].ticket;
                orderItem.taxfree = mGoodsItem[goods_index].taxfree;
                orderItem.allim = mGoodsItem[goods_index].allim;


                orderItem.cnt = order_cnt;

                orderItem.amt = mGoodsItem[goods_index].amt;
                //orderItem.option_amt    // 위에서 세팅

                orderItem.dcr_type = "";
                orderItem.dcr_des = "";
                orderItem.dcr_value = 0;
                orderItem.shop_code = mGoodsItem[goods_index].shop_code;
                orderItem.nod_code1 = mGoodsItem[goods_index].nod_code1;
                orderItem.nod_code2 = mGoodsItem[goods_index].nod_code2;


                //
                replace_mem_order_item(ref orderItem, "add");

                mOrderItemList.Add(orderItem);
                lvwOrderItem.SetObjects(mOrderItemList);

                lvwOrderItem.Items[lvwOrderItem.Items.Count - 1].EnsureVisible();

            }
            else
            {
                set_item_change_ordercnt(lv_idx, "add", 1);
                lvwOrderItem.Items[lv_idx].EnsureVisible();
            }

            ReCalculateAmount();


            // 타이머 리셋
            reset_timer_waiting();

        }


        public DescribedTaskRenderer rendererName()
        {
            DescribedTaskRenderer renderer = new DescribedTaskRenderer();
            renderer.DescriptionAspectName = "option_name_description";

            renderer.TitleFont = new Font(lvwOrderItem.Font.FontFamily, 16, FontStyle.Bold);
            renderer.DescriptionFont = new Font(lvwOrderItem.Font.FontFamily, 11, FontStyle.Regular);
            renderer.DescriptionColor = Color.Blue;
            renderer.ImageTextSpace = 0;
            renderer.TitleDescriptionSpace = 0;

            renderer.UseGdiTextRendering = false;

            return (renderer);
        }

        public DescribedTaskRenderer rendererAmt()
        {
            DescribedTaskRenderer renderer = new DescribedTaskRenderer();
            renderer.DescriptionAspectName = "option_amt_description";

            renderer.TitleFont = new Font(lvwOrderItem.Font.FontFamily, 16, FontStyle.Bold);
            renderer.DescriptionFont = new Font(lvwOrderItem.Font.FontFamily, 11, FontStyle.Regular);
            renderer.DescriptionColor = Color.Blue;
            renderer.ImageTextSpace = 0;
            renderer.TitleDescriptionSpace = 0;

            renderer.UseGdiTextRendering = false;

            return (renderer);
        }


        public static int get_lvitem_idx(string code)
        {
            // 옵션이 있는 항목은 상품코드가 동일해도 다른 상품으로 간주한다.


            for (int i = 0; i < mOrderItemList.Count; i++)
            {
                if (code == mOrderItemList[i].goods_code & mOrderItemList[i].orderOptionItemList.SequenceEqual(mOrderOptionItemList))
                { 
                    return i; 
                }
            }
            return -1;
        }


        public static void replace_mem_order_item(ref MemOrderItem orderItem, String job)
        {
            //
            if (job == "add")
            {

            }
            else
            {
                // 유지
            }


            orderItem.net_amount = ((orderItem.amt + orderItem.option_amt) * orderItem.cnt) - orderItem.dc_amount;

            orderItem.lv_goods_name = orderItem.goods_name;

            if (orderItem.dcr_des == "E")
            {
                orderItem.lv_cnt = "";
                orderItem.lv_amt = "";
                orderItem.lv_net_amount = "";
            }
            else
            {
                orderItem.lv_cnt = orderItem.cnt.ToString("N0");
                orderItem.lv_amt = orderItem.amt.ToString("N0");
                orderItem.lv_net_amount = orderItem.net_amount.ToString("N0");
            }

            orderItem.lv_dc_amount = orderItem.dc_amount.ToString("N0");

            

            //
            if (orderItem.dcr_type == "A")
            {
                orderItem.option_dc_amount_description = "₩" + orderItem.dcr_value.ToString("N0");
            }
            else if (orderItem.dcr_type == "R")
            {
                orderItem.option_dc_amount_description = orderItem.dcr_value + "%";
            }
            else
            {
                orderItem.option_dc_amount_description = "";
            }

            //
            orderItem.lv_cnt_dn = "‒";
            orderItem.lv_cnt_up = "⧾";
            orderItem.lv_cnt_del = "x";

        }

        private void set_item_change_ordercnt(int lv_idx, String jobtype, int cnt)
        {

            MemOrderItem orderItem = mOrderItemList[lv_idx];

            if (jobtype == "add")
            {
                orderItem.cnt += cnt;
            }
            else if (jobtype == "set")
            {
                orderItem.cnt = cnt;
            }
            else
            {
                return;
            }

            // 
            replace_mem_order_item(ref orderItem, "update");

            mOrderItemList[lv_idx] = orderItem;

            lvwOrderItem.SetObjects(mOrderItemList);



        }


        public void ReCalculateAmount()
        {
            int Amount = 0;

            MemOrderItem orderItem;

            for (int i = 0; i < mOrderItemList.Count; i++)
            {
                orderItem = mOrderItemList[i];
                Amount += (orderItem.amt + orderItem.option_amt) * orderItem.cnt;      // 주문금액
            }

            mNetAmount = Amount;
            lblAmount.Text = "₩ " + Amount.ToString("N0");


        }





        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void btnGoodsPrev_Click(object sender, EventArgs e)
        {
            disp_goods_page_no--;
            display_goods(disp_goods_page_no);
        }

        private void btnGoodsNext_Click(object sender, EventArgs e)
        {
            disp_goods_page_no++;
            display_goods(disp_goods_page_no);
        }





        private void pbLogo_Click(object sender, EventArgs e)
        {
            sysadmin_pw_patern += "1";


            if (sysadmin_pw_patern.Length >= 4)
            {
                
                reset_timer_waiting();



                ContextMenuStrip m = new ContextMenuStrip();

                ToolStripMenuItem m0 = new ToolStripMenuItem(mAppVersion);
                ToolStripMenuItem m1 = new ToolStripMenuItem("내기기설정");
                ToolStripMenuItem m2 = new ToolStripMenuItem("기초원장 리로드");
                ToolStripMenuItem m3 = new ToolStripMenuItem("원격지원");
                ToolStripMenuItem mBizClose = new ToolStripMenuItem("정산");
                ToolStripMenuItem m4 = new ToolStripMenuItem("종료");

                ToolStripSeparator separator = new ToolStripSeparator();


                m0.Font = new System.Drawing.Font("v1.02K", 12F);

                m1.Font = new System.Drawing.Font("내기기설정", 20F);
                m1.Click += (senders, es) =>
                {
                    // 설정창은 타임아웃 없다.
                    timerWelcome.Enabled = false;


                    frmSetupPos frm = new frmSetupPos();
                    frm.ShowDialog();


                    reset_timer_waiting();

                };

                m2.Font = new System.Drawing.Font("기초원장 리로드", 20F);
                m2.Click += (senders, es) =>
                {

                    sync_data_server_to_memory();


                    init_reload();

                    MessageBox.Show("기초원장 리로드 완료.", "thepos");

                    timerWelcome.Enabled = true;
                };

                m3.Font = new System.Drawing.Font("원격지원", 20F);
                m3.Click += (senders, es) =>
                {
                    //원격지원
                    System.Diagnostics.Process.Start("http://786.co.kr");

                    timerWelcome.Enabled = false;
                };

                mBizClose.Font = new System.Drawing.Font("정산", 20F);
                mBizClose.Click += (senders, es) =>
                {
                    // 설정창은 타임아웃 없다.
                    timerWelcome.Enabled = false;

                    frmBizClose frm = new frmBizClose();
                    frm.ShowDialog();

                    reset_timer_waiting();
                };

                m4.Font = new System.Drawing.Font("종료", 30F);
                m4.Click += (senders, es) =>
                {
                    //
                    thepos_app_log(2, this.Name, "Close", "appVersion=TPW2-" + mAppVersion + ", mac=" + mMacAddr);

                    this.Close();
                };


                m.Items.Add(m0);
                m.Items.Add(m1);
                m.Items.Add(m2);
                m.Items.Add(m3);
                m.Items.Add(mBizClose);
                m.Items.Add(separator);
                m.Items.Add(m4);


                Point p = new Point(pbLogo.Location.X + 20, pbLogo.Location.Y);

                m.Show(this, p);

                //
                sysadmin_pw_patern = "";
            }

        }


        // 다국어
        private void btnKR_Click(object sender, EventArgs e)
        {
            mLanguageNo = 0;
            set_language();
        }

        private void btnEN_Click(object sender, EventArgs e)
        {
            mLanguageNo = 1;
            set_language();
        }

        private void btnCH_Click(object sender, EventArgs e)
        {
            mLanguageNo = 2;
            set_language();
        }

        private void btnJP_Click(object sender, EventArgs e)
        {
            mLanguageNo = 3;
            set_language();
        }



        private void set_language()
        {
            // 주문 타이틀
            lvwOrderItem.Columns[0].Text = mLangLvwNameArr[mLanguageNo];
            lvwOrderItem.Columns[1].Text = mLangLvwAmtArr[mLanguageNo];
            lvwOrderItem.Columns[2].Text = mLangLvwQtyArr[mLanguageNo];
            lvwOrderItem.Columns[3].Text = mLangLvwPriceArr[mLanguageNo];


            // 금액타일틀
            lblAmountTitle.Text = mLangAmountTitleArr[mLanguageNo];

            // 총금액
            btnPayCard.Text = mLangPayCardArr[mLanguageNo];


            //
            reset_clear();

        }


        private void reset_clear()
        {
            // 그룹
            disp_group_page_no = 0;
            display_goodsgroup(0);

            // 상품
            String group_code = mRbGroup[0].Tag.ToString();
            ClickedGoodsGroup(group_code, "Y");

            mRbGroup[0].Checked = true;

            // 주문아이템
            mOrderItemList.Clear();
            lvwOrderItem.SetObjects(mOrderItemList);
            ReCalculateAmount();


        }


        private void picSlide_Click(object sender, EventArgs e)
        {
            change_active();
        }


        private void timerWelcome_Tick(object sender, EventArgs e)
        {
            change_waiting();
        }



        private void change_active()
        {
            if (mWaitingDisplay != "Y")
            {
                return;
            }

            panelWelcome.Visible = false;
            timerWelcome.Enabled = true;
        }

        private void change_waiting()
        {
            if (mWaitingDisplay != "Y")
            {
                return;
            }



            // 떠있는 창있으면 강제 Close
            for (int i = Application.OpenForms.Count - 1; i >= 0; i += -1)
            {
                if (Application.OpenForms[i].Name != "frmSalesCombo" & Application.OpenForms[i].Name != "frmLogin")
                {
                    Application.OpenForms[i].Close();
                }
            }


            // 화면 clear
            reset_clear();


            panelWelcome.Visible = true;
            timerWelcome.Enabled = false;
        }



        private void reset_timer_waiting()
        {
            timerWelcome.Stop();
            timerWelcome.Start();
        }


        private void btnPayCard_Click(object sender, EventArgs e)
        {
            //
            thepos_app_log(1, this.Name, "btnPayCard_Click()", "");

            // 샘플 티켓 출력용 - 테스트
            //print_ticket("2501202504180186171301", "100004", "6976680442186471");

            // 타이머 리셋
            reset_timer_waiting();

            if (mOrderItemList.Count == 0)
            {
                return;
            }

            if (mNetAmount <= 0)
            {
                return;
            }


            if (!get_amounts(out int t과세금액, out int t면세금액))
            {
                MessageBox.Show("과세금액, 면세금액 계산오류", "thepos");
                return;
            }


            // 영업일자 등 선체크 
            if (!isPreCheck(out String error_msg))
            {
                MessageBox.Show(error_msg, "thepos");
                return;
            }


            // 결제창은 타임아웃 없음.
            timerWelcome.Enabled = false;


            countup_the_no();

            //#
            int select_idx = -1;

            frmPayCard fForm = new frmPayCard(mNetAmount, t과세금액, t면세금액, false, 1, true, select_idx);
            DialogResult ret = fForm.ShowDialog();

            if (ret == DialogResult.OK)
            {
                // Cleal All
                mOrderItemList.Clear();
                lvwOrderItem.SetObjects(mOrderItemList);
                ReCalculateAmount();
            }

            // 타이머 리셋
            reset_timer_waiting();

        }

        //
        public static int SaveTicketFlow(String ticket_no, String pay_class, String settle_class, int settle_amt)
        {
            // settle_class, settel_amt 는 정상시에만 사용
            // 정산의 경우 subClass : 사용 US,  충전 CH
            // 사용승인, 충전취소 -> 구분하여 업데이트


            if (pay_class == "OR") // 주문(접수-발권)
            {
                int ticket_seq = 0;
                String t_ticket_no = "";

                for (int i = 0; i < mOrderItemList.Count; i++)
                {
                    MemOrderItem orderItem = mOrderItemList[i];

                    if (orderItem.ticket == "Y")
                    {
                        if (mTicketType == "IS")  // 입장전용 - 1장으로 출력 : 써멀로 한정
                        {
                            ticket_seq++;
                            t_ticket_no = mTheNo + ticket_seq.ToString("00");

                            print_bill_ticket(t_ticket_no, orderItem.goods_code, orderItem.cnt, orderItem.coupon_no);
                        }
                        else if (mTicketType == "IN" | mTicketType == "PA" | mTicketType == "PD")  // 입장전용[개별출력], 선불, 후불
                        {
                            for (int k = 0; k < orderItem.cnt; k++)
                            {
                                ticket_seq++;

                                if (mTicketMedia == "RF")   // 팔찌
                                {
                                    //?? 팔찌이면 스케너 입력로직 필요
                                    //t_ticket_no = "";  //? 스캐너로 읽어서 여기에...
                                    //?? 임시
                                    t_ticket_no = mTheNo + ticket_seq.ToString("00");   
                                }
                                else   // BC(서멀), TG(전용폼지)
                                {
                                    t_ticket_no = mTheNo + ticket_seq.ToString("00");
                                }


                                // ticketFlow POST - 선불, 후불 만
                                if (mTicketType == "PA" | mTicketType == "PD")
                                {
                                    Dictionary<string, string> parameters = new Dictionary<string, string>();
                                    parameters.Clear();
                                    parameters["siteId"] = mSiteId;
                                    parameters["bizDt"] = mBizDate;
                                    parameters["posNo"] = myPosNo;
                                    parameters["theNo"] = mTheNo;
                                    parameters["refNo"] = mRefNo;

                                    parameters["ticketNo"] = t_ticket_no;
                                    parameters["bangleNo"] = "";  //? 팔찌인 경우 - 값변경 필요
                                    parameters["ticketingDt"] = get_today_date() + get_today_time();
                                    parameters["chargeDt"] = "";
                                    parameters["settlementDt"] = "";

                                    parameters["pointChargeCnt"] = "0";
                                    parameters["pointUsageCnt"] = "0";

                                    parameters["pointCharge"] = "0";
                                    parameters["pointUsage"] = "0";
                                    parameters["settlePointCharge"] = "0";
                                    parameters["settlePointUsage"] = "0";

                                    parameters["goodsCode"] = orderItem.goods_code;
                                    parameters["flowStep"] = "1";               // 발권1 - *충전2 - 사용중3 - 정산(완료)4
                                    parameters["lockerNo"] = "";
                                    parameters["openLocker"] = "1";             // 선불 :  항상 open
                                                                                // 후불 :  최초 open -> 사용 close -> 정산 open
                                    if (mRequestPost("ticketFlow", parameters))
                                    {
                                        if (mObj["resultCode"].ToString() == "200")
                                        {

                                        }
                                        else
                                        {
                                            MessageBox.Show("오류 ticketFlow\n\n" + mObj["resultMsg"].ToString(), "thepos");
                                            return -1;
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("시스템오류 ticketFlow\n\n" + mErrorMsg, "thepos");
                                        return -1;
                                    }
                                }


                                //
                                // 에러발생에 대비해서 인쇄출력은 가능한 마지막에 순서...
                                // "", "BC", "RF", "TG" };
                                // "", "영수증", "팔찌", "띠지" };
                                if (mTicketMedia == "BC")  // 영수증
                                {
                                    print_bill_ticket(t_ticket_no, orderItem.goods_code, 1, orderItem.coupon_no);
                                }
                                else if (mTicketMedia == "TG")  // 전용폼지(띠지)
                                {
                                    //??

                                }
                                else if (mTicketMedia == "RF")   // 팔찌
                                {
                                    // SKIP..
                                }
                            }
                        }
                    }
                }

                return ticket_seq;

            }
            
            return 0;
        }


        public static void print_bill_ticket(String t_ticket_no, String t_goods_code, int t_goods_cnt, String t_coupon_no)
        {

            // 티켓을 영수증에 출력

            if (mBillPrinterPort.Trim().Length == 0)
            {
                //
                thepos_app_log(3, "ticket", "print_ticket()", "티켓프린터 미설정으로 티켓출력불가.");

                MessageBox.Show("프린터 미설정으로 티켓출력불가.", "thepos");
                return;
            }


            try
            {
                const string ESC = "\u001B";
                const string GS = "\u001D";
                const string InitializePrinter = ESC + "@";

                const string BoldOn = ESC + "E" + "\u0001";
                const string BoldOff = ESC + "E" + "\0";
                const string DoubleOn = GS + "!" + "\u0011";  // 2x sized text (double-high + double-wide)
                const string DoubleOff = GS + "!" + "\0";



                PrinterUtility.EscPosEpsonCommands.EscPosEpson obj = new PrinterUtility.EscPosEpsonCommands.EscPosEpson();

                byte[] BytesValue = new byte[100];

                BytesValue = PrintExtensions.AddBytes(BytesValue, InitializePrinter);

                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());


                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Center());


                //
                String strPrint = mSiteAlias;
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(strPrint));


                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());

                strPrint = "------------------------------------------";
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(strPrint));


                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());



                //
                BytesValue = PrintExtensions.AddBytes(BytesValue, BoldOn);
                BytesValue = PrintExtensions.AddBytes(BytesValue, DoubleOn);
                strPrint = get_goods_name(t_goods_code);
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(strPrint));
                BytesValue = PrintExtensions.AddBytes(BytesValue, DoubleOff);
                BytesValue = PrintExtensions.AddBytes(BytesValue, BoldOff);

                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());


                if (true)
                {
                    BytesValue = PrintExtensions.AddBytes(BytesValue, DoubleOn);
                    strPrint = "- " + t_goods_cnt + " 매 - ";
                    BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(strPrint));
                    BytesValue = PrintExtensions.AddBytes(BytesValue, DoubleOff);

                    BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                    BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                }

                BytesValue = PrintExtensions.AddBytes(BytesValue, DoubleOn);
                strPrint = mBizDate.Substring(0, 4) + "-" + mBizDate.Substring(4, 2) + "-" + mBizDate.Substring(6, 2);
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(strPrint));
                BytesValue = PrintExtensions.AddBytes(BytesValue, DoubleOff);

                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());



                if ((t_coupon_no + "").Length > 0)
                {
                    strPrint = "쿠폰번호 : " + t_coupon_no;
                    BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(strPrint));

                    BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                    BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                }


                // 티켓번호 :  바코드
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.BarCode.Code128(t_ticket_no));


                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());



                // 티켓 추가 텍스트                
                if (mTicketAddText != "")
                {
                    strPrint = "------------------------------------------";
                    BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(strPrint));
                    BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                    BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());

                    BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(mTicketAddText));
                }


                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
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

                    //
                    thepos_app_log(1, "ticket", "print_ticket()", "정상 출력 완료.");

                }
                catch (Exception ex)
                {
                    //
                    thepos_app_log(3, "ticket", "print_ticket()", "영수증프린터 출력 오류. " + ex.Message);

                    MessageBox.Show("영수증프린터 출력 오류.\r\n" + ex.Message);
                    return;
                }

            }
            catch (Exception ex)
            {
                //
                thepos_app_log(3, "ticket", "print_ticket()", "티켓 출력 오류. 헬프데스크로 문의바랍니다.. " + ex.Message);

                MessageBox.Show("티켓 출력 오류.\r\n헬프데스크로 문의바랍니다.");  // 파일이 이미 있으므로 만들 수 없습니다.
                return;
            }
        }

        private void tbBarcodeScan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                String input_barcode = tbBarcodeScan.Text;
                tbBarcodeScan.Clear();

                if (input_barcode.Length < 5)
                {
                    thepos_app_log(3, this.Name, "scanner", "skip. coupon_no=" + input_barcode);
                    return;
                }

                //
                order_goods_barcode(input_barcode);


                tbBarcodeScan.Focus();
            }
        }

        private void tbBarcodeScan_Leave(object sender, EventArgs e)
        {
            tbBarcodeScan.Focus();
        }


        public void order_goods_barcode(String input_barcode)
        {

            int barcode_idx = -1;

            for (int i = 0; i < mGoodsBarcodeList.Count; i++)
            {
                if (mGoodsBarcodeList[i].bar_code == input_barcode)
                {
                    barcode_idx = i;
                    break;
                }
            }


            if (barcode_idx == -1)
            {

                //
                tpMessageBox tpMessageBox = new tpMessageBox("바코드상품을 찾을수 없습니다.\r\n" + input_barcode + "\r\n\r\n관리자에게 문의바랍니다.");
                tpMessageBox.ShowDialog();

                thepos_app_log(3, "order_goods_barcode()", "order_goods_barcode()", " 바코드상품을 찾을수 없습니다. input_barcode=" + input_barcode);
            }
            else
            {


                // 옵션항목 목록: frmOrderOption에서 채운다.
                mOrderOptionItemList.Clear();


                MemOrderItem orderItem = new MemOrderItem();
                int lv_idx = (get_lvitem_idx(mGoodsBarcodeList[barcode_idx].goods_code));  // 이미  동일 상품이 주문리스트뷰에 있는지

                if (lv_idx == -1)
                {
                    //
                    orderItem.option_name_description = "";   // 리스트뷰 상품항목 아랫줄에 표시
                    orderItem.option_amt_description = "";    // 리스트뷰 단가항목 아랫줄에 표시


                    if (mOrderOptionItemList.Count > 0)
                    {
                        for (int k = 0; k < mOrderOptionItemList.Count; k++)
                        {
                            orderItem.option_name_description += " " + mOrderOptionItemList[k].option_item_name;
                            orderItem.option_amt += (int)mOrderOptionItemList[k].amt;
                        }
                    }

                    if (mOrderOptionItemList.Count > 0)
                    {
                        orderItem.option_amt_description = orderItem.option_amt.ToString("N0");
                    }
                    else
                    {
                        orderItem.option_amt_description = "";
                    }

                    //
                    orderItem.option_item_cnt = mOrderOptionItemList.Count;
                    orderItem.option_no = "";
                    orderItem.orderOptionItemList = mOrderOptionItemList.ToList();  // ToList() : 리스트 복사, 참조가 아니고..

                    orderItem.order_no = mOrderItemList.Count + 1;
                    orderItem.goods_code = mGoodsBarcodeList[barcode_idx].goods_code.ToString();
                    orderItem.goods_name = mGoodsBarcodeList[barcode_idx].goods_name;

                    orderItem.ticket = mGoodsBarcodeList[barcode_idx].ticket;
                    orderItem.taxfree = mGoodsBarcodeList[barcode_idx].taxfree;
                    orderItem.allim = mGoodsBarcodeList[barcode_idx].allim;


                    orderItem.cnt = 1;

                    orderItem.amt = mGoodsBarcodeList[barcode_idx].amt;
                    //orderItem.option_amt    // 위에서 세팅

                    orderItem.dcr_type = "";
                    orderItem.dcr_des = "";
                    orderItem.dcr_value = 0;
                    orderItem.shop_code = mGoodsBarcodeList[barcode_idx].shop_code;
                    orderItem.nod_code1 = mGoodsBarcodeList[barcode_idx].nod_code1;
                    orderItem.nod_code2 = mGoodsBarcodeList[barcode_idx].nod_code2;


                    //
                    replace_mem_order_item(ref orderItem, "add");

                    mOrderItemList.Add(orderItem);
                    lvwOrderItem.SetObjects(mOrderItemList);

                    lvwOrderItem.Items[lvwOrderItem.Items.Count - 1].EnsureVisible();

                }
                else
                {
                    set_item_change_ordercnt(lv_idx, "add", 1);
                    lvwOrderItem.Items[lv_idx].EnsureVisible();
                }

                ReCalculateAmount();


                // 타이머 리셋
                reset_timer_waiting();
            }

        }





    }
}


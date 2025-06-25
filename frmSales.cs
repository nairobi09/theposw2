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

namespace thepos2
{
    public partial class frmSales : Form
    {

        RadioButton[] mRbGroup = new RadioButton[5];

        String last_groupcode = "";  // 상품그룹을 클릭했을 경우 눌려진버튼을 또 눌렀는지 비교하기 위함.


        Panel[] mP = new Panel[12];
        PictureBox[] mPbGoods = new PictureBox[12];
        PictureBox[] mPbBadges = new PictureBox[12];
        Label[] mLblName = new Label[12];
        Label[] mLblAmt = new Label[12];
        Label[] mLblNotice = new Label[12];



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



        public frmSales()
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

        }




        private void init_reload()
        {

            //
            disp_group_page_no = 0;

            display_goodsgroup(disp_group_page_no);


            mRbGroup[0].Checked = true;


            //String groupcode = mRbGroup[0].Tag.ToString();
            //ClickedGoodsGroup(groupcode, "Y");


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
            mP[8] = p8;
            mP[9] = p9;
            mP[10] = p10;
            mP[11] = p11;


            // 상품 이미지
            mPbGoods[0] = pbGoods0;
            mPbGoods[1] = pbGoods1;
            mPbGoods[2] = pbGoods2;
            mPbGoods[3] = pbGoods3;
            mPbGoods[4] = pbGoods4;
            mPbGoods[5] = pbGoods5;
            mPbGoods[6] = pbGoods6;
            mPbGoods[7] = pbGoods7;
            mPbGoods[8] = pbGoods8;
            mPbGoods[9] = pbGoods9;
            mPbGoods[10] = pbGoods10;
            mPbGoods[11] = pbGoods11;


            // 상품 배지
            mPbBadges[0] = pbBadges0;
            mPbBadges[1] = pbBadges1;
            mPbBadges[2] = pbBadges2;
            mPbBadges[3] = pbBadges3;
            mPbBadges[4] = pbBadges4;
            mPbBadges[5] = pbBadges5;
            mPbBadges[6] = pbBadges6;
            mPbBadges[7] = pbBadges7;
            mPbBadges[8] = pbBadges8;
            mPbBadges[9] = pbBadges9;
            mPbBadges[10] = pbBadges10;
            mPbBadges[11] = pbBadges11;


            // 상품명
            mLblName[0] = lblGoodsName0;
            mLblName[1] = lblGoodsName1;
            mLblName[2] = lblGoodsName2;
            mLblName[3] = lblGoodsName3;
            mLblName[4] = lblGoodsName4;
            mLblName[5] = lblGoodsName5;
            mLblName[6] = lblGoodsName6;
            mLblName[7] = lblGoodsName7;
            mLblName[8] = lblGoodsName8;
            mLblName[9] = lblGoodsName9;
            mLblName[10] = lblGoodsName10;
            mLblName[11] = lblGoodsName11;

            // 상품단가
            mLblAmt[0] = lblGoodsAmt0;
            mLblAmt[1] = lblGoodsAmt1;
            mLblAmt[2] = lblGoodsAmt2;
            mLblAmt[3] = lblGoodsAmt3;
            mLblAmt[4] = lblGoodsAmt4;
            mLblAmt[5] = lblGoodsAmt5;
            mLblAmt[6] = lblGoodsAmt6;
            mLblAmt[7] = lblGoodsAmt7;
            mLblAmt[8] = lblGoodsAmt8;
            mLblAmt[9] = lblGoodsAmt9;
            mLblAmt[10] = lblGoodsAmt10;
            mLblAmt[11] = lblGoodsAmt11;


            // Notice
            mLblNotice[0] = lblNotice0;
            mLblNotice[1] = lblNotice1;
            mLblNotice[2] = lblNotice2;
            mLblNotice[3] = lblNotice3;
            mLblNotice[4] = lblNotice4;
            mLblNotice[5] = lblNotice5;
            mLblNotice[6] = lblNotice6;
            mLblNotice[7] = lblNotice7;
            mLblNotice[8] = lblNotice8;
            mLblNotice[9] = lblNotice9;
            mLblNotice[10] = lblNotice10;
            mLblNotice[11] = lblNotice11;



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
            for (int i = 0; i < 12; i++)
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
            int from_no = goods_page_no * 12;
            int to_no = goods_page_no * 12 + 11;

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




        private static Boolean isPreCheck(out String error_msg)
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


        private bool get_amounts(out int t과세금액, out int t면세금액)
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
            catch(Exception e) 
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
            //!
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
                            strPrintOrder += Space(9 - encodelen(tStr)) + tStr;

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
                if (Application.OpenForms[i].Name != "frmSales" & Application.OpenForms[i].Name != "frmLogin")
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

        private void btnPayKakao_Click(object sender, EventArgs e)
        {
            //
            thepos_app_log(1, this.Name, "btnPayKakao_Click()", "");

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

            frmPayKakao fForm = new frmPayKakao(mNetAmount, t과세금액, t면세금액, false, 1, true, select_idx);
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


    }
}


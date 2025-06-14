using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static thepos2.ClsWin32Api;
using static thepos2.thepos;

namespace thepos2
{
    public partial class frmLogin : Form
    {
        TextBox mTbKeyDisplayController;  // 공용컨트롤러



        public frmLogin()
        {
            InitializeComponent();
            initialize_the();


            // 시작이 1회성 세팅. 이후 로그인 이후 다시 세팅

#if DEBUG
    mBaseUri = uri_test;
#else
    mBaseUri = uri_real;
#endif


            //
            thepos_app_log(2, "theposw2", "start...", "appVersion=" + mAppVersion + ", mac=" + mMacAddr);
        }



        private void initialize_the()
        {
            btnKey1.Click += (sender, args) => ClickedKey("1");
            btnKey2.Click += (sender, args) => ClickedKey("2");
            btnKey3.Click += (sender, args) => ClickedKey("3");
            btnKey4.Click += (sender, args) => ClickedKey("4");
            btnKey5.Click += (sender, args) => ClickedKey("5");
            btnKey6.Click += (sender, args) => ClickedKey("6");
            btnKey7.Click += (sender, args) => ClickedKey("7");
            btnKey8.Click += (sender, args) => ClickedKey("8");
            btnKey9.Click += (sender, args) => ClickedKey("9");
            btnKey0.Click += (sender, args) => ClickedKey("0");
            btnKeyBS.Click += (sender, args) => ClickedKey("BS");
            btnKeyClear.Click += (sender, args) => ClickedKey("Clear");

            mTbKeyDisplayController = tbID;


            try
            {
                // 기동시 MAC값 구하기 및 보관
                var nics = NetworkInterface.GetAllNetworkInterfaces();
                var selectedNic = nics.First();
                mMacAddr = selectedNic.GetPhysicalAddress().ToString();

            }
            catch
            {
                MessageBox.Show("기기 MAC 인식 불가.\r\n관리자에 요청바랍니다.", "thepos");
                return;
            }



            // Session key 로그인관련 
            handler.CookieContainer = cookies;
            mHttpClient = new HttpClient(handler);




        }




        private void ClickedKey(string sKey)
        {
            if (sKey == "BS")
            {
                if (mTbKeyDisplayController.Text.Length > 0)
                {
                    mTbKeyDisplayController.Text = mTbKeyDisplayController.Text.Substring(0, mTbKeyDisplayController.Text.Length - 1);
                }
            }
            else if (sKey == "Clear")
            {
                mTbKeyDisplayController.Text = "";
            }
            else
            {
                mTbKeyDisplayController.Text += sKey;
            }
        }


        private void btnKeyLogin_Click(object sender, EventArgs e)
        {
            mIsDevLogin = "";

            mIsTestPayMode = "";

            // 
            if (tbID.Text == "1120" & tbPW.Text == "4089")
            {
                // 개발자 전용 로그인
                frmDevAdmin frm2 = new frmDevAdmin();
                DialogResult ret = frm2.ShowDialog();

                if (ret == DialogResult.OK)  // Real
                {
                    //
                    mIsDevLogin = "Y";  // 개발자 로그인은 로그를 남기지 않기위해
                }
                else if (ret == DialogResult.Yes) // TEST
                {
                    //
                    mIsDevLogin = "Y";  // 개발자 로그인은 로그를 남기지 않기위해

                    //lblIsTest.Visible = true;
                    mIsTestPayMode = "Test";
                }
                else
                {
                    return;
                }

            }
            else
            {
                mBaseUri = uri_real;

                // 로그인
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters["userId"] = tbID.Text;
                parameters["userPw"] = SHA1HashCrypt(tbPW.Text);
                parameters["macAddr"] = mMacAddr;

                if (mRequestPost("login", parameters))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        mSiteId = mObj["siteId"].ToString();
                        mUserID = tbID.Text;
                        mUserName = mObj["userName"].ToString();
                        myPosNo = mObj["posNo"].ToString();
                        myShopCode = mObj["shopCode"].ToString();

                        //
                        thepos_app_log(2, this.Name, "login", "appVersion=" + mAppVersion + ", mac=" + mMacAddr);
                    }
                    else
                    {
                        String msg = mObj["resultMsg"].ToString();

                        //
                        thepos_app_log(3, this.Name, "login", "로그인오류. " + msg);

                        //
                        MessageBox.Show("로그인오류\n\n" + msg, "thepos");
                        return;
                    }
                }
                else
                {
                    //
                    thepos_app_log(3, this.Name, "login", "시스템오류. " + mErrorMsg);

                    //
                    MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                    return;
                }
            }


            //////////////////////////////////
            //? 개시마감 
            String biz_date = "";
            String biz_status = "";
            mBizDate = "";

            if (get_bizdate_status(ref biz_status, ref biz_date))
            {
                if (biz_status == "A")   // A영업중 F영업마감
                {
                    mBizDate = biz_date;

                    //
                    thepos_app_log(2,this.Name, "get_bizdate_status", "biz_status=" + biz_status + ", biz_date=" + biz_date);
                }
                else if (biz_status == "F" | biz_status == "Y")  // 마감 
                {
                    //? 개시화면으로 이동?

                    //
                    thepos_app_log(3, this.Name, "get_bizdate_status", "실패. 영업개시전입니다. 영업개시 입력후 다시 로그인바랍니다. biz_status=" + biz_status);

                    MessageBox.Show("영업개시전입니다.\n영업개시 입력후 다시 로그인바랍니다.", "thepos");
                    return;
                }
            }
            else
            {
                //
                thepos_app_log(3, this.Name, "get_bizdate_status", "실패. 개시마감관리 오류. 서버에서 정보를 읽어오지 못했습니다.");

                MessageBox.Show("개시마감관리 오류\n서버에서 정보를 읽어오지 못했습니다.", "thepos");
                return;
            }


            //
            sync_data_server_to_memory();


            // 쿠폰인증
            mHttpClientCoupon = new HttpClient();
            mHttpClientCoupon.DefaultRequestHeaders.TryAddWithoutValidation("authorization", mCouponMID);  // 최초 한번




            // 
            this.Hide();


            if (mKioskType.Equals("인증전용"))
            {
                frmCoupon frm = new frmCoupon();
                frm.ShowDialog();
            }
            else
            {
                frmSales frm = new frmSales();
                frm.ShowDialog();
            }


            this.Close();


        }

        private void lblCallCenterNo_Click(object sender, EventArgs e)
        {
            frmSysAdminPos frm = new frmSysAdminPos();
            frm.ShowDialog();
        }

        private void tbID_Click(object sender, EventArgs e)
        {
            mTbKeyDisplayController = tbID;
        }

        private void tbPW_Click(object sender, EventArgs e)
        {
            mTbKeyDisplayController = tbPW;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //
            thepos_app_log(2, this.Name, "Close", "");

            this.Close();
        }

        private void btnPos_Click(object sender, EventArgs e)
        {
            frmSysAdminPos frm = new frmSysAdminPos();
            frm.ShowDialog();
        }

        private void btnReqSupport_Click(object sender, EventArgs e)
        {
            //
            thepos_app_log(1, this.Name, "call 원격지원", "");

            //원격지원
            System.Diagnostics.Process.Start("http://786.co.kr");
        }


        private void sync_data_server_to_memory()
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
    }
}

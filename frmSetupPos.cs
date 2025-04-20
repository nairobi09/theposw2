using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static thepos2.thepos;

namespace thepos2
{
    public partial class frmSetupPos : Form
    {
        struct Setup
        {
            public String code;
            public String name;
            public String value;
            public String memo;
        }
        Setup[] listSetup = new Setup[17];


        bool isAdd = false;


        public frmSetupPos()
        {
            InitializeComponent();

            initialize_the();

            Setup setupItem = new Setup();

            setupItem.code = "PosType"; setupItem.name = "기기유형"; setupItem.value = ""; setupItem.memo = ""; listSetup[0] = setupItem;

            setupItem.code = "MobileExchangeType"; setupItem.name = "모바일교환권"; setupItem.value = ""; setupItem.memo = ""; listSetup[1] = setupItem;
            setupItem.code = "PrintExchangeType"; setupItem.name = "인쇄교환권"; setupItem.value = ""; setupItem.memo = ""; listSetup[2] = setupItem;

            setupItem.code = "BillPrinterPort"; setupItem.name = "영수증프린터 포트"; setupItem.value = ""; setupItem.memo = ""; listSetup[3] = setupItem;
            setupItem.code = "BillPrinterSpeed"; setupItem.name = "영수증프린터 속도"; setupItem.value = ""; setupItem.memo = ""; listSetup[4] = setupItem;

            setupItem.code = "TicketPrinterPort"; setupItem.name = "티켓전용프린터 포트"; setupItem.value = ""; setupItem.memo = ""; listSetup[5] = setupItem;
            setupItem.code = "TicketPrinterSpeed"; setupItem.name = "티켓전용프린터 속도"; setupItem.value = ""; setupItem.memo = ""; listSetup[6] = setupItem;

            setupItem.code = "VanTID"; setupItem.name = "결제밴 T-ID"; setupItem.value = ""; setupItem.memo = "미입력시 밴결제모듈내 입력된 T-ID로 설정됩니다.\r\nKovan의 경우 필수입력항목입니다."; listSetup[7] = setupItem;

            setupItem.code = "CouponMID"; setupItem.name = "온라인쿠폰 가맹점번호(MID)"; setupItem.value = ""; setupItem.memo = ""; listSetup[8] = setupItem;


            // 키오스크 대문화면(대기화면)
            setupItem.code = "WaitingDisplay"; setupItem.name = "대기화면 사용여부"; setupItem.value = ""; setupItem.memo = ""; listSetup[9] = setupItem;
            setupItem.code = "WaitingDisplayImage"; setupItem.name = "대기화면 이미지"; setupItem.value = ""; setupItem.memo = "1080*1920 jpg"; listSetup[10] = setupItem;
            setupItem.code = "WaitingSecond"; setupItem.name = "대기화면 전환시간(초)"; setupItem.value = ""; setupItem.memo = ""; listSetup[11] = setupItem;


            // 키오스크 본화면
            setupItem.code = "KioskLogoImage"; setupItem.name = "화면 상단이미지"; setupItem.value = ""; setupItem.memo = "1080*120 jpg"; listSetup[12] = setupItem;

            // 언어
            setupItem.code = "MultiLanguage"; setupItem.name = "다국어지원"; setupItem.value = ""; setupItem.memo = ""; listSetup[13] = setupItem;

            // 온라인쿠폰 인증전용 키오스크
            setupItem.code = "KioskType"; setupItem.name = "키오스크유형"; setupItem.value = ""; setupItem.memo = ""; listSetup[14] = setupItem;


            //
            setupItem.code = "CouponDisplayImage"; setupItem.name = "쿠폰인증 대문이미지"; setupItem.value = ""; setupItem.memo = "1080*1920 jpg"; listSetup[15] = setupItem;

            // 티켓출력물 추가 텍스트
            setupItem.code = "TicketAddText"; setupItem.name = "티켓출력물 추가텍스트"; setupItem.value = ""; setupItem.memo = ""; listSetup[16] = setupItem;



            reload_setup_pos();
        }


        private void initialize_the()
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 32);

            lvwList.SmallImageList = imgList;
            lvwList.HideSelection = true;

            lblSiteName.Text = mSiteAlias;
            lblPosNo.Text = mPosNo;

        }


        private void reload_setup_pos()
        {

            String sUrl = "setupPos?siteId=" + mSiteId + "&posNo=" + mPosNo;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["setupPos"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        for (int j = 0; j < listSetup.Length; j++)
                        {
                            if (listSetup[j].code == arr[i]["setupCode"].ToString())
                            {
                                listSetup[j].value = arr[i]["setupValue"].ToString();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("설정정보 오류. setupPos\n\n " + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. setupPos\n\n" + mErrorMsg, "thepos");
                return;
            }



            lvwList.Items.Clear();
            for (int i = 0; i < listSetup.Length; i++)
            {
                ListViewItem lvItem = new ListViewItem();
                lvItem.Text = listSetup[i].name;
                lvItem.SubItems.Add(listSetup[i].value);
                lvItem.SubItems.Add("");
                lvItem.SubItems.Add(listSetup[i].memo);
                lvItem.SubItems.Add("");
                lvItem.Tag = listSetup[i].code;
                lvwList.Items.Add(lvItem);
            }

        }

        private void lvwList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count == 0) return;


            String code = lvwList.SelectedItems[0].Tag.ToString();

            lblName.Text = lvwList.SelectedItems[0].Text;
            lblValue.Text = lvwList.SelectedItems[0].SubItems[1].Text.ToString();
            lblMemo.Text = lvwList.SelectedItems[0].SubItems[3].Text.ToString();

            cbValue.Visible = false;
            tbValue.Visible = false;
            panelImage.Visible = false;
            panelMultiText.Visible = false;


            cbValue.SelectedIndex = -1;


            if (code == listSetup[0].code)  // PosType
            {
                cbValue.Visible = true;

                cbValue.Items.Clear();
                cbValue.Items.Add("");
                cbValue.Items.Add("POS");
                cbValue.Items.Add("POS-Ticket");
                cbValue.Items.Add("PC");
                cbValue.Items.Add("PC-Ticket");
                cbValue.Items.Add("KIOSK");
            }
            else if (code == listSetup[1].code)  // 모바일 교환권
            {
                cbValue.Visible = true;

                cbValue.Items.Clear();
                cbValue.Items.Add(" ");  // 출력없음
                cbValue.Items.Add("알림톡");  // 알림톡
            }
            else if (code == listSetup[2].code)  // 인쇄 교환권
            {
                cbValue.Visible = true;

                cbValue.Items.Clear();
                cbValue.Items.Add(" ");  // 출력없음
                cbValue.Items.Add("로컬프린터");  // 영수증프린터
            }
            else if (code == listSetup[3].code | code == listSetup[5].code) // 
            {
                cbValue.Visible = true;

                cbValue.Items.Clear();
                cbValue.Items.Add(" ");
                foreach (string s in SerialPort.GetPortNames())
                {
                    cbValue.Items.Add(s);
                }
            }
            else if (code == listSetup[4].code | code == listSetup[6].code) // BillPrinterPort TicketPrinterPort ScannerPort
            {
                cbValue.Visible = true;

                cbValue.Items.Clear();
                cbValue.Items.Add(" ");
                cbValue.Items.Add("9600");
                cbValue.Items.Add("19200");
                cbValue.Items.Add("38400");
                cbValue.Items.Add("57600");
                cbValue.Items.Add("115200");
            }
            else if (code == listSetup[7].code | code == listSetup[8].code)  // t-id
            {
                tbValue.Visible = true;

            }
            else if (code == listSetup[9].code | code == listSetup[13].code) // 대기화면 사용여부, 다국어
            {
                cbValue.Visible = true;

                cbValue.Items.Clear();
                cbValue.Items.Add("N");
                cbValue.Items.Add("Y");
            }
            else if (code == listSetup[11].code)  //초
            {
                tbValue.Visible = true;

            }
            else if (code == listSetup[10].code | code == listSetup[12].code | code == listSetup[15].code)
            {
                panelImage.Visible = true;

                if (lvwList.SelectedItems[0].SubItems[1].Text.ToString().Trim() != "")
                {
                    try
                    {
                        byte[] imgBytes = Convert.FromBase64String(lvwList.SelectedItems[0].SubItems[1].Text.ToString());

                        MemoryStream ms = new MemoryStream(imgBytes, 0, imgBytes.Length);
                        ms.Write(imgBytes, 0, imgBytes.Length);

                        pbImage.Image = System.Drawing.Image.FromStream(ms, true);
                    }
                    catch
                    {

                    }
                }
                else
                {
                    pbImage.Image = null;
                }
            }
            else if (code == listSetup[14].code) // 키오스크 유형 : 범용 or 인증전용
            {
                cbValue.Visible = true;

                cbValue.Items.Clear();
                cbValue.Items.Add("범용");
                cbValue.Items.Add("인증전용");
            }
            else if (code == listSetup[16].code)
            {
                panelMultiText.Visible = true;

                tbMultiValue.Text = lblValue.Text;

            }


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbValue.Visible)
            {
                lvwList.SelectedItems[0].SubItems[2].Text = cbValue.Text;
                lvwList.SelectedItems[0].SubItems[4].Text = "변경";
            }
            else if (tbMultiValue.Visible)
            {
                lvwList.SelectedItems[0].SubItems[2].Text = tbMultiValue.Text;
                lvwList.SelectedItems[0].SubItems[4].Text = "변경";
            }
            else
            {
                lvwList.SelectedItems[0].SubItems[2].Text = tbValue.Text;
                lvwList.SelectedItems[0].SubItems[4].Text = "변경";
            }

            isAdd = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isAdd == false) return;

            //
            for (int i = 0; i < lvwList.Items.Count; i++)
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();

                parameters["siteId"] = mSiteId;
                parameters["posNo"] = mPosNo;
                parameters["setupCode"] = lvwList.Items[i].Tag.ToString();
                parameters["setupName"] = lvwList.Items[i].Text;


                if (lvwList.Items[i].SubItems[4].Text == "변경")
                {
                    parameters["setupValue"] = lvwList.Items[i].SubItems[2].Text;
                }
                else
                {
                    parameters["setupValue"] = lvwList.Items[i].SubItems[1].Text;
                }


                parameters["memo"] = "";

                if (mRequestPost("setupPos", parameters))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {

                    }
                    else
                    {
                        MessageBox.Show("포스정보 오류. setupPos\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류. setupPos\n\n" + mErrorMsg, "thepos");
                    return;
                }
            }

            //
            MessageBox.Show("포스정보 저장완료.", "thepos");

            isAdd = false;


            reload_setup_pos();


            for (int i = 0; i < lvwList.Items.Count; i++)
            {
                if (lvwList.Items[i].Tag.ToString() == "PosType") mPosType = lvwList.Items[i].SubItems[1].Text;
                else if (lvwList.Items[i].Tag.ToString() == "BillPrinterPort") mBillPrinterPort = lvwList.Items[i].SubItems[1].Text;
                else if (lvwList.Items[i].Tag.ToString() == "BillPrinterSpeed") mBillPrinterSpeed = lvwList.Items[i].SubItems[1].Text;
                else if (lvwList.Items[i].Tag.ToString() == "TicketPrinterPort") mTicketPrinterPort = lvwList.Items[i].SubItems[1].Text;
                else if (lvwList.Items[i].Tag.ToString() == "TicketPrinterSpeed") mTicketPrinterSpeed = lvwList.Items[i].SubItems[1].Text;
                else if (lvwList.Items[i].Tag.ToString() == "VanTID") mVanTID = lvwList.Items[i].SubItems[1].Text;
                else if (lvwList.Items[i].Tag.ToString() == "CouponMID") mCouponMID = lvwList.Items[i].SubItems[1].Text;

                else if (lvwList.Items[i].Tag.ToString() == "WaitingDisplay") mWaitingDisplay = lvwList.Items[i].SubItems[1].Text;
                else if (lvwList.Items[i].Tag.ToString() == "WaitingDisplayImage") mWaitingDisplayImage = lvwList.Items[i].SubItems[1].Text;
                else if (lvwList.Items[i].Tag.ToString() == "WaitingSecond") mWaitingSecond = convert_number(lvwList.Items[i].SubItems[1].Text);

                else if (lvwList.Items[i].Tag.ToString() == "kioskLogoImage") mKioskLogoImage = lvwList.Items[i].SubItems[1].Text;
                else if (lvwList.Items[i].Tag.ToString() == "MultiLanguage") mMultiLanguage = lvwList.Items[i].SubItems[1].Text;
                else if (lvwList.Items[i].Tag.ToString() == "kioskType") mKioskType = lvwList.Items[i].SubItems[1].Text;
                else if (lvwList.Items[i].Tag.ToString() == "CouponDisplayImage") mCouponDisplayImage = lvwList.Items[i].SubItems[1].Text;

                else if (lvwList.Items[i].Tag.ToString() == "TicketAddText") mTicketAddText = lvwList.Items[i].SubItems[1].Text;
            }

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            reload_setup_pos();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pbImage_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog.ShowDialog();

            //OK버튼 클릭시
            if (dr == DialogResult.OK)
            {
                string fileFullName = openFileDialog.FileName;

                System.Drawing.Image image = System.Drawing.Image.FromFile(fileFullName);
                this.pbImage.Image = image;


                if (pbImage.Image == null)
                {
                    tbValue.Text = "";
                }
                else
                {
                    var ms = new MemoryStream();
                    pbImage.Image.Save(ms, pbImage.Image.RawFormat);
                    tbValue.Text = Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            this.pbImage.Image = null;
            tbValue.Text = "";
        }
    }
}

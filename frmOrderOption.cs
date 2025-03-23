using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using theposw2.Properties;
using static thepos2.thepos;

namespace thepos2
{
    public partial class frmOrderOption : Form
    {
        Panel[] mPanelOption = new Panel[6];

        Label[] mLblOptionName = new Label[6];

        RadioButton[,] mRbOptionItemName = new RadioButton[6, 4];
        Label[,] mLblOrderItemAmt = new Label[6, 4];

        String thisOptionTemplateId = "";

        GoodsItem goodsItem = new GoodsItem();

        int goods_cnt = 0;
        int goods_amount = 0;

        List<TempOption> thisTempOption = new List<TempOption>();


        //??
        String[] mLangTitleArr = new string[4];
        String[] mLangOKBtnArr = new string[4];
        String[] mLangCancelBtnArr = new string[4];


        public frmOrderOption(GoodsItem goods_item)
        {
            InitializeComponent();


            initialize_the();
            initialize_font();

            goodsItem = goods_item;

            thisOptionTemplateId = goodsItem.option_template_id;

            lblTitle.Text = mLangTitleArr[mLanguageNo];
            lblGoodsInfo.Text = goodsItem.goods_name[mLanguageNo];


            btnCancel.Text = mLangCancelBtnArr[mLanguageNo];
            btnOK.Text = mLangOKBtnArr[mLanguageNo];


            lblTitle.Text = mLangTitleArr[mLanguageNo];
            btnOK.Text = mLangOKBtnArr[mLanguageNo];
            btnCancel.Text = mLangCancelBtnArr[mLanguageNo];

        }



        private void initialize_the()
        {

            mLangTitleArr[0] = "옵션선택";
            mLangTitleArr[1] = "Option";
            mLangTitleArr[2] = "选件";
            mLangTitleArr[3] = "オプション";

            mLangOKBtnArr[0] = "선택";
            mLangOKBtnArr[1] = "OK";
            mLangOKBtnArr[2] = "确认";
            mLangOKBtnArr[3] = "かくにん";

            mLangCancelBtnArr[0] = "취소";
            mLangCancelBtnArr[1] = "Cancel";
            mLangCancelBtnArr[2] = "否定";
            mLangCancelBtnArr[3] = "とりけし";




            mPanelOption[0] = panelOption0;
            mPanelOption[1] = panelOption1;
            mPanelOption[2] = panelOption2;
            mPanelOption[3] = panelOption3;
            mPanelOption[4] = panelOption4;
            mPanelOption[5] = panelOption5;

            mLblOptionName[0] = lblOption0Name;
            mLblOptionName[1] = lblOption1Name;
            mLblOptionName[2] = lblOption2Name;
            mLblOptionName[3] = lblOption3Name;
            mLblOptionName[4] = lblOption4Name;
            mLblOptionName[5] = lblOption5Name;


            mRbOptionItemName[0, 0] = rbOption0Item0Name;
            mRbOptionItemName[0, 1] = rbOption0Item1Name;
            mRbOptionItemName[0, 2] = rbOption0Item2Name;
            mRbOptionItemName[0, 3] = rbOption0Item3Name;

            mRbOptionItemName[1, 0] = rbOption1Item0Name;
            mRbOptionItemName[1, 1] = rbOption1Item1Name;
            mRbOptionItemName[1, 2] = rbOption1Item2Name;
            mRbOptionItemName[1, 3] = rbOption1Item3Name;

            mRbOptionItemName[2, 0] = rbOption2Item0Name;
            mRbOptionItemName[2, 1] = rbOption2Item1Name;
            mRbOptionItemName[2, 2] = rbOption2Item2Name;
            mRbOptionItemName[2, 3] = rbOption2Item3Name;

            mRbOptionItemName[3, 0] = rbOption3Item0Name;
            mRbOptionItemName[3, 1] = rbOption3Item1Name;
            mRbOptionItemName[3, 2] = rbOption3Item2Name;
            mRbOptionItemName[3, 3] = rbOption3Item3Name;

            mRbOptionItemName[4, 0] = rbOption4Item0Name;
            mRbOptionItemName[4, 1] = rbOption4Item1Name;
            mRbOptionItemName[4, 2] = rbOption4Item2Name;
            mRbOptionItemName[4, 3] = rbOption4Item3Name;

            mRbOptionItemName[5, 0] = rbOption5Item0Name;
            mRbOptionItemName[5, 1] = rbOption5Item1Name;
            mRbOptionItemName[5, 2] = rbOption5Item2Name;
            mRbOptionItemName[5, 3] = rbOption5Item3Name;


            mLblOrderItemAmt[0, 0] = lblOrder0Item0Amt;
            mLblOrderItemAmt[0, 1] = lblOrder0Item1Amt;
            mLblOrderItemAmt[0, 2] = lblOrder0Item2Amt;
            mLblOrderItemAmt[0, 3] = lblOrder0Item3Amt;

            mLblOrderItemAmt[1, 0] = lblOrder1Item0Amt;
            mLblOrderItemAmt[1, 1] = lblOrder1Item1Amt;
            mLblOrderItemAmt[1, 2] = lblOrder1Item2Amt;
            mLblOrderItemAmt[1, 3] = lblOrder1Item3Amt;

            mLblOrderItemAmt[2, 0] = lblOrder2Item0Amt;
            mLblOrderItemAmt[2, 1] = lblOrder2Item1Amt;
            mLblOrderItemAmt[2, 2] = lblOrder2Item2Amt;
            mLblOrderItemAmt[2, 3] = lblOrder2Item3Amt;

            mLblOrderItemAmt[3, 0] = lblOrder3Item0Amt;
            mLblOrderItemAmt[3, 1] = lblOrder3Item1Amt;
            mLblOrderItemAmt[3, 2] = lblOrder3Item2Amt;
            mLblOrderItemAmt[3, 3] = lblOrder3Item3Amt;

            mLblOrderItemAmt[4, 0] = lblOrder4Item0Amt;
            mLblOrderItemAmt[4, 1] = lblOrder4Item1Amt;
            mLblOrderItemAmt[4, 2] = lblOrder4Item2Amt;
            mLblOrderItemAmt[4, 3] = lblOrder4Item3Amt;

            mLblOrderItemAmt[5, 0] = lblOrder5Item0Amt;
            mLblOrderItemAmt[5, 1] = lblOrder5Item1Amt;
            mLblOrderItemAmt[5, 2] = lblOrder5Item2Amt;
            mLblOrderItemAmt[5, 3] = lblOrder5Item3Amt;


            /*
            for (int i = 0; i < 5; i++)
            {
                for (int k = 0; k < 3; k++)
                {
                    mRbOptionItemName[i, k].Click += (sender, args) => calculate_amount();
                }
            }
            */

        }


        private void initialize_font()
        {
            lblTitle.Font = font12;
            lblGoodsInfo.Font = font14;
            lblCntDn.Font = font14;
            lblCnt.Font = font14;
            lblCntUp.Font = font14;
            lblAmount.Font = font14;


            for (int i = 0; i < 6; i++)
            {
                mLblOptionName[i].Font = font14;

                for (int k = 0; k < 4; k++)
                {
                    mRbOptionItemName[i, k].Font = font12;
                    mLblOrderItemAmt[i, k].Font = font11;
                }
            }

            btnCancel.Font = font12;
            btnOK.Font = font12;

        }

        private void frmOrderOption_Shown(object sender, EventArgs e)
        {

            get_this_option();


            display_option_seq(0);

            //
            goods_cnt = 1;

            calculate_amount();
        }



        private void get_this_option()
        {
            for (int i = 0; i < mTempOption.Length; i++)
            {
                if (mTempOption[i].option_template_id == thisOptionTemplateId)
                {
                    thisTempOption.Add(mTempOption[i]);
                }
            }
        }




        private void display_option_seq(int option_seq)
        {
            String m_next_optionid = "";


            for (int i = 0; i < thisTempOption.Count; i++)
            {
                if (thisTempOption[i].option_seq >= option_seq)
                {
                    if (m_next_optionid != "")
                    {
                        if (thisTempOption[i].option_id == m_next_optionid)
                        {
                            display_option(thisTempOption[i]);

                            if (thisTempOption[i].is_turnoff == "Y")
                            {
                                //
                                btnOK.Visible = false;
                                return;
                            }
                            else
                            {
                                m_next_optionid = thisTempOption[i].next_option_id;
                            }
                        }
                        else
                        {
                            //skip
                        }
                    }
                    else
                    {
                        display_option(thisTempOption[i]);

                        if (thisTempOption[i].is_turnoff == "Y")
                        {
                            //
                            btnOK.Visible = false;
                            return;
                        }
                        else
                        {
                            m_next_optionid = thisTempOption[i].next_option_id;
                        }
                    }
                }
            }

            btnOK.Visible = true;

        }

        private void display_option(TempOption tempOption)
        {
            int option_dsp_idx = -1;
            //
            for (int i = 0; i < 6; i++)
            {
                if (mPanelOption[i].Visible == false)
                {
                    option_dsp_idx = i;
                    break;
                }
            }


            if (option_dsp_idx == -1)
            {
                // 빈칸이 없음. 최대 6칸.
                return;
            }





            mPanelOption[option_dsp_idx].Visible = true;
            mLblOptionName[option_dsp_idx].Text = tempOption.option_name[mLanguageNo];
            mLblOptionName[option_dsp_idx].Tag = tempOption.option_id;


            //
            int item_dsp_idx = 0;

            for (int k = 0; k < mTempOptionItem.Length; k++)
            {
                if (mTempOptionItem[k].option_template_id == tempOption.option_template_id & mTempOptionItem[k].option_id == tempOption.option_id)
                {
                    mRbOptionItemName[option_dsp_idx, item_dsp_idx].Visible = true;
                    mRbOptionItemName[option_dsp_idx, item_dsp_idx].Text = mTempOptionItem[k].option_item_name[mLanguageNo].Replace("  ", "\r\n");
                    mRbOptionItemName[option_dsp_idx, item_dsp_idx].Tag = mTempOptionItem[k].option_item_id;

                    // 종속옵션 이벤트 설정
                    String link_option_id = mTempOptionItem[k].link_option_id;
                    int dsp_idx = option_dsp_idx;
                    mRbOptionItemName[option_dsp_idx, item_dsp_idx].Click += (sender, args) => ClickedOptionItem(link_option_id, dsp_idx);
                    mRbOptionItemName[option_dsp_idx, item_dsp_idx].Click += (sender, args) => calculate_amount();



                    // 분기점 아니면 버튼 체크
                    if (tempOption.is_turnoff != "Y" & item_dsp_idx == 0)
                    {
                        mRbOptionItemName[option_dsp_idx, item_dsp_idx].Checked = true;
                    }



                    if (mTempOptionItem[k].option_item_amt > 0)
                    {
                        mLblOrderItemAmt[option_dsp_idx, item_dsp_idx].Visible = true;
                        mLblOrderItemAmt[option_dsp_idx, item_dsp_idx].Text = "+ " + mTempOptionItem[k].option_item_amt.ToString("N0");
                    }
                    else if (mTempOptionItem[k].option_item_amt < 0)
                    {
                        mLblOrderItemAmt[option_dsp_idx, item_dsp_idx].Visible = true;
                        mLblOrderItemAmt[option_dsp_idx, item_dsp_idx].Text = "" + mTempOptionItem[k].option_item_amt.ToString("N0");
                    }
                    else
                    {
                        mLblOrderItemAmt[option_dsp_idx, item_dsp_idx].Visible = false;
                        mLblOrderItemAmt[option_dsp_idx, item_dsp_idx].Text = "";
                    }

                    mLblOrderItemAmt[option_dsp_idx, item_dsp_idx].Tag = mTempOptionItem[k].option_item_amt;

                    item_dsp_idx++;

                }
            }




            // 첫칸 + 컵 HOT ICE   옵션일 경우 별도 아이콘으로 변형
            if (option_dsp_idx == 0)
            {
                if (mRbOptionItemName[0, 0].Text == "HOT" & mRbOptionItemName[0, 1].Text == "ICE" & mRbOptionItemName[0, 2].Visible == false)
                {
                    mRbOptionItemName[0, 0].Location = new Point(235, 44);
                    mRbOptionItemName[0, 0].Size = new Size(110, 110);
                    mRbOptionItemName[0, 0].TextAlign = ContentAlignment.BottomCenter;
                    mRbOptionItemName[0, 0].Image = Resources.cup_hot;

                    mRbOptionItemName[0, 1].Location = new Point(365, 44);
                    mRbOptionItemName[0, 1].Size = new Size(110, 110);
                    mRbOptionItemName[0, 1].TextAlign = ContentAlignment.BottomCenter;
                    mRbOptionItemName[0, 1].Image = Resources.cup_ice;
                }
            }


            option_dsp_idx++;



        }


        private void ClickedOptionItem(String link_option_id, int dsp_idx)
        {
            if (link_option_id != "")
            {
                for (int i = dsp_idx + 1; i < 6; i++)
                {
                    mPanelOption[i].Visible = false;
                    mLblOptionName[i].Text = "";
                    mLblOptionName[i].Tag = "";

                    // 클릭이벤트 삭제
                    for (int k = 0; k < 4; k++)
                    {
                        FieldInfo f1 = typeof(Control).GetField("EventClick", BindingFlags.Static | BindingFlags.NonPublic);

                        object obj = f1.GetValue(mRbOptionItemName[i, k]);
                        PropertyInfo pi = mRbOptionItemName[i, k].GetType().GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Instance);

                        EventHandlerList list = (EventHandlerList)pi.GetValue(mRbOptionItemName[i, k], null);
                        list.RemoveHandler(obj, list[obj]);

                        mRbOptionItemName[i, k].Checked = false;

                        mRbOptionItemName[i, k].Visible = false;
                        mLblOrderItemAmt[i, k].Visible = false;

                    }
                }


                for (int i = 0; i < thisTempOption.Count; i++)
                {
                    if (thisTempOption[i].option_id == link_option_id)
                    {
                        display_option_seq(thisTempOption[i].option_seq);
                    }
                }

            }

        }


        private void calculate_amount()
        {
            int option_item_amt = 0;

            for (int i = 0; i < 6; i++)
            {
                for (int k = 0; k < 4; k++)
                {
                    if (mRbOptionItemName[i, k].Visible)
                    {
                        if (mRbOptionItemName[i, k].Checked)
                        {
                            if (is_number(mLblOrderItemAmt[i, k].Tag.ToString()))
                            {
                                option_item_amt += (int)mLblOrderItemAmt[i, k].Tag;
                            }
                        }
                    }
                }
            }

            goods_amount = (goodsItem.amt + option_item_amt) * goods_cnt;

            lblAmount.Text = "₩ " + goods_amount.ToString("N0");
        }

        private void lblCntDn_Click(object sender, EventArgs e)
        {
            if (goods_cnt > 1)
            {
                goods_cnt--;
                lblCnt.Text = goods_cnt.ToString();

                calculate_amount();
            }
        }

        private void lblCntUp_Click(object sender, EventArgs e)
        {
            goods_cnt++;
            lblCnt.Text = goods_cnt.ToString();

            calculate_amount();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            mOrderOptionItemList.Clear();

            for (int i = 0; i < 6; i++)
            {
                for (int k = 0; k < 4; k++)
                {
                    if (mRbOptionItemName[i, k].Visible)
                    {
                        if (mRbOptionItemName[i, k].Checked)
                        {
                            orderOptionItem orderOptionItem = new orderOptionItem();
                            orderOptionItem.option_item_no = convert_number(mRbOptionItemName[i, k].Tag.ToString());
                            orderOptionItem.option_item_name = mRbOptionItemName[i, k].Text;
                            orderOptionItem.option_code = mLblOptionName[i].Tag.ToString();
                            orderOptionItem.option_name = mLblOptionName[i].Text;
                            orderOptionItem.amt = (int)mLblOrderItemAmt[i, k].Tag;

                            mOrderOptionItemList.Add(orderOptionItem);
                        }
                    }
                }
            }

            // 수량을 전역변수로 전달 : fk30fgu9w04ufgw
            mOrderCntInOption = goods_cnt;


            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

    }
}

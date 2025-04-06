using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static thepos2.thepos;

namespace thepos2
{
    public partial class frmCoupon1 : Form
    {

        public frmCoupon1()
        {
            InitializeComponent();

            initialize_font();

            initialize_the();

        }

        private void initialize_the()
        { 
            btn1.Click += (sender, args) => ClickedKey("1");
            btn2.Click += (sender, args) => ClickedKey("2");
            btn3.Click += (sender, args) => ClickedKey("3");
            btn4.Click += (sender, args) => ClickedKey("4");
            btn5.Click += (sender, args) => ClickedKey("5");
            btn6.Click += (sender, args) => ClickedKey("6");
            btn7.Click += (sender, args) => ClickedKey("7");
            btn8.Click += (sender, args) => ClickedKey("8");
            btn9.Click += (sender, args) => ClickedKey("9");
            btn0.Click += (sender, args) => ClickedKey("0");

            btnBS.Click += (sender, args) => ClickedKey("BS");
            btnClear.Click += (sender, args) => ClickedKey("Clear");

            btnA.Click += (sender, args) => ClickedKey("A");
            btnB.Click += (sender, args) => ClickedKey("B");
            btnC.Click += (sender, args) => ClickedKey("C");
            btnD.Click += (sender, args) => ClickedKey("D");
            btnE.Click += (sender, args) => ClickedKey("E");
            btnF.Click += (sender, args) => ClickedKey("F");
            btnG.Click += (sender, args) => ClickedKey("G");
            btnH.Click += (sender, args) => ClickedKey("H");
            btnI.Click += (sender, args) => ClickedKey("I");
            btnJ.Click += (sender, args) => ClickedKey("J");
            btnK.Click += (sender, args) => ClickedKey("K");
            btnL.Click += (sender, args) => ClickedKey("L");
            btnM.Click += (sender, args) => ClickedKey("M");
            btnN.Click += (sender, args) => ClickedKey("N");
            btnO.Click += (sender, args) => ClickedKey("O");
            btnP.Click += (sender, args) => ClickedKey("P");
            btnQ.Click += (sender, args) => ClickedKey("Q");
            btnR.Click += (sender, args) => ClickedKey("R");
            btnS.Click += (sender, args) => ClickedKey("S");
            btnT.Click += (sender, args) => ClickedKey("T");
            btnU.Click += (sender, args) => ClickedKey("U");
            btnV.Click += (sender, args) => ClickedKey("V");
            btnW.Click += (sender, args) => ClickedKey("W");
            btnX.Click += (sender, args) => ClickedKey("X");
            btnY.Click += (sender, args) => ClickedKey("Y");
            btnZ.Click += (sender, args) => ClickedKey("Z");

            btnDash.Click += (sender, args) => ClickedKey("-");
            btn_.Click += (sender, args) => ClickedKey("_");

        }


        private void initialize_font()
        {
            btnCouponImage.Font = font20bold;
            btnCouponNo.Font = font20bold;

            lblCouponImageText.Font = font20;

            lblCouponInput.Font = font30bold;

            btnOK.Font = font30bold;

        }


        private void btnHome_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            this.Close();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            String ss = tbCouponNo.Text;




            frmCoupon2 frm = new frmCoupon2();

            DialogResult ret = frm.ShowDialog();

            if (ret == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;

                this.Close();
            }
            else if(ret == DialogResult.Cancel)
            {

            }


        }

        private void ClickedKey(string sKey)
        {
            if (sKey == "BS")
            {
                if (lblCouponInput.Text.Length > 0)
                {
                    lblCouponInput.Text = lblCouponInput.Text.Substring(0, lblCouponInput.Text.Length - 1);
                }
            }
            else if (sKey == "Clear")
            {
                lblCouponInput.Text = "";
            }
            else
            {
                lblCouponInput.Text += sKey;
            }
        }

        private void tbCouponNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbCouponNo_LostFocus(object sender, EventArgs e)
        {
            tbCouponNo.Focus();
        }

        private void btnCouponImage_Click(object sender, EventArgs e)
        {

            btnCouponImage.ForeColor = Color.Red;
            btnCouponNo.ForeColor = Color.Gray;

            panelCouponImage.Visible = true;
            panelCouponNo.Visible = false;
        }

        private void btnCouponNo_Click(object sender, EventArgs e)
        {
            btnCouponImage.ForeColor = Color.Gray;
            btnCouponNo.ForeColor = Color.Red;

            panelCouponImage.Visible = false;
            panelCouponNo.Visible = true;
        }
    }
}

using BrightIdeasSoftware;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using theposw2;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static thepos2.thepos;

namespace thepos2
{

    // ▲ △ ◀ ◁ ▶ ▷ ▼ ▽



    public partial class frmCoupon2 : Form
    {



        public frmCoupon2()
        {
            InitializeComponent();

            initialize_the();

            initialize_font();




            lvwCoupon.Items.Clear();



            for (int i = 0; i < 3; i++)
            {
                ListViewItem item = new ListViewItem("", 1);
                item.SubItems.Add("1000-0000-0001");
                item.SubItems.Add("C_성인_일반 / @25 / 1");
                lvwCoupon.Items.Add(item);
            }

            for (int i = 0; i < 4; i++)
            {
                ListViewItem item = new ListViewItem("", 0);
                item.SubItems.Add("1000-0000-0001");
                item.SubItems.Add("C_성인_일반 / @25 / 1");
                lvwCoupon.Items.Add(item);
            }


        }


        private void initialize_the()
        {

        }

        private void initialize_font()
        {

            btnSelect.Font = font20bold;
            btnUnselect.Font = font20bold;

            btnOK.Font = font30bold;

        }





        private void btnOK_Click(object sender, EventArgs e)
        {
            frmCoupon3 frm = new frmCoupon3();
            DialogResult ret = frm.ShowDialog();

            if (ret == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;

                this.Close();
            }
            else if (ret == DialogResult.Cancel)
            {

            }

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

        private void lvwCoupon_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lvwCoupon.Items.Count; i++)
            {


            }

            

        }

        private void btnUnselect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lvwCoupon.Items.Count; i++)
            {

            }
        }


    }
}

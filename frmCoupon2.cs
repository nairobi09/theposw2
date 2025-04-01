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
using static thepos2.thepos;

namespace thepos2
{

    // ▲ △ ◀ ◁ ▶ ▷ ▼ ▽







    public partial class frmCoupon2 : Form
    {


        public struct CouponItem
        {

            public String lv_coupon;
            public String coupon_description;

            public bool lv_checked;


            public int coupon_cnt;
            public String coupon_no;
            public String coupon_name;
            public String cus_no;
            public String ustate;
            public String is_usage;





        }
        public static List<CouponItem> mCouponItemList = new List<CouponItem>();


        public frmCoupon2()
        {
            InitializeComponent();

            initialize_the();

            initialize_font();




            lvwCoupon.Items.Clear();

            mCouponItemList.Clear();


            for (int i = 0; i < 6; i++)
            {
                CouponItem couponItem = new CouponItem();

                couponItem.coupon_no = "202503000" + i;
                couponItem.coupon_name = "입장권 성인 일반" + i;
                couponItem.coupon_cnt = i;
                couponItem.cus_no = "010-0000-1111";
                couponItem.ustate = "";
                couponItem.is_usage = "";

                couponItem.lv_coupon = couponItem.coupon_no;
                couponItem.coupon_description = couponItem.coupon_name + " / " + couponItem.coupon_cnt + "";

                couponItem.lv_checked = false;


                
                mCouponItemList.Add(couponItem);

            }

            
            lvwCoupon.SetObjects(mCouponItemList);

        }


        private void initialize_the()
        {

            this.lv_coupon.Renderer = rendererCoupon();



        }

        private void initialize_font()
        {

            btnSelect.Font = font20bold;
            btnUnselect.Font = font20bold;

            btnOK.Font = font30bold;

        }


        public DescribedTaskRenderer rendererCoupon()
        {
            DescribedTaskRenderer renderer = new DescribedTaskRenderer();
            renderer.DescriptionAspectName = "coupon_description";

            renderer.TitleColor = Color.Blue;
            renderer.TitleFont = new Font("맑은 고딕", 14, FontStyle.Regular);
            renderer.TitleDescriptionSpace = 0;


            renderer.DescriptionColor = Color.Black;
            renderer.DescriptionFont = new Font("맑은 고딕", 20, FontStyle.Bold);
            

            //renderer.ImageTextSpace = 0;
            

            //renderer.UseGdiTextRendering = false;

            return (renderer);
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


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static thepos.ClsWin32Api;
using static thepos.thepos;

namespace thepos
{
    public partial class frmCoupon3: Form
    {
        public frmCoupon3()
        {
            InitializeComponent();

            timerHome_reset();

            //
            thepos_app_log(1, this.Name, "Open", "");

        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            //
            thepos_app_log(1, this.Name, "btnOK", "");

            timerHome.Enabled = false;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void timerHome_Tick(object sender, EventArgs e)
        {
            //
            thepos_app_log(1, this.Name, "timeout toHome", mWaitingSecond + "초");

            timerHome.Enabled = false;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void timerHome_reset()
        {
            timerHome.Enabled = false;
            timerHome.Enabled = true;
            timerHome.Interval = 1000 * mWaitingSecond;
        }
    }
}

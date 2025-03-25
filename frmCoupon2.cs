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
    public partial class frmCoupon2 : Form
    {
        public frmCoupon2()
        {
            InitializeComponent();

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            frmCoupon3 frm = new frmCoupon3();
            frm.ShowDialog();

            this.Close();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static thepos2.thepos;

namespace thepos2
{
    public partial class frmCoupon1 : Form
    {
        public frmCoupon1()
        {
            InitializeComponent();

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            frmCoupon2 frm = new frmCoupon2();
            frm.ShowDialog();

            this.Close();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

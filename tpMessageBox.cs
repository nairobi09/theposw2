using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace theposw2
{
    public partial class tpMessageBox : Form
    {
        public tpMessageBox(String msg)
        {
            InitializeComponent();

            lblMsg.Text = msg;

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

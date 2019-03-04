using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkAssist
{
    public partial class customMessageBox : Form
    {
        public customMessageBox()
        {
            InitializeComponent();
        }
        static customMessageBox mb;
        static DialogResult result = DialogResult.No;
        public static DialogResult Show(string text)
		{ 
            mb = new customMessageBox();
            mb.lbCMB.Text = text;
            mb.ShowDialog();
            return result;

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
			mb.Close();
        }
    }
}

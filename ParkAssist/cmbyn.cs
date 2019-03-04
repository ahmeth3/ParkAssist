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
	public partial class cmbyn : Form
	{
		public cmbyn()
		{
			InitializeComponent();
		}

		static cmbyn mb;
		static DialogResult result = DialogResult.No;
		public static DialogResult Show(string text)
		{
			mb = new cmbyn();
			mb.lbCMB.Text = text;
			mb.ShowDialog();
			return result;

		}

		private void btnOk_Click_1(object sender, EventArgs e)
		{

		}

		private void btnDa_Click(object sender, EventArgs e)
		{
			result = DialogResult.Yes;
			mb.Close();
		}

		private void btnNe_Click(object sender, EventArgs e)
		{
			result = DialogResult.No;
			mb.Close();
		}
	}
}

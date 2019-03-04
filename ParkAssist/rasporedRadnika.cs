using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ParkAssist.Klase;
using System.IO;

namespace ParkAssist
{
    public partial class rasporedRadnika : UserControl
    {
        DateTime datum = DateTime.Today.AddDays(1 - prviUNedelji());
        public rasporedRadnika()
        {
            InitializeComponent();
            racunaj();
        }

        private static int prviUNedelji()
        {
            if ((int)DateTime.Today.DayOfWeek == 0)
                return 7;
            else return (int)DateTime.Today.DayOfWeek;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnNedeljaNazad_Click(object sender, EventArgs e)
        {
            datum = datum.AddDays(-7);
            racunaj();
            popuniKalendar();
        }

        private void btnNedeljaNapred_Click(object sender, EventArgs e)
        {
            datum = datum.AddDays(7);
            racunaj();
            popuniKalendar();
        }

        private void racunaj()
        {
            lbOpseg.Text = (datum.Day + ". " + datum.ToString("MMMMMMMMMM") + "-" + datum.AddDays(6).Day + ". " + datum.AddDays(6).ToString("MMMMMMMMMM"));
            lbPon.Text = datum.ToShortDateString();
            lbUto.Text = datum.AddDays(1).ToShortDateString();
            lbSre.Text = datum.AddDays(2).ToShortDateString();
            lbCet.Text = datum.AddDays(3).ToShortDateString();
            lbPet.Text = datum.AddDays(4).ToShortDateString();
            lbSub.Text = datum.AddDays(5).ToShortDateString();
            lbNed.Text = datum.AddDays(6).ToShortDateString();
        }

        public void oznaciDanas()
        {
            if (lbPon.Text.Equals(DateTime.Now.ToShortDateString()))
                lbPon.BackColor = Color.FromArgb(70, 130, 180);
            else
                lbPon.BackColor = Color.FromArgb(110, 110, 110);

            if (lbUto.Text.Equals(DateTime.Now.ToShortDateString()))
                lbUto.BackColor = Color.FromArgb(70, 130, 180);
            else
                lbUto.BackColor = Color.FromArgb(110, 110, 110);

            if (lbSre.Text.Equals(DateTime.Now.ToShortDateString()))
                lbSre.BackColor = Color.FromArgb(70, 130, 180);
            else
                lbSre.BackColor = Color.FromArgb(110, 110, 110);

            if (lbCet.Text.Equals(DateTime.Now.ToShortDateString()))
                lbCet.BackColor = Color.FromArgb(70, 130, 180);
            else
                lbCet.BackColor = Color.FromArgb(110, 110, 110);

            if (lbPet.Text.Equals(DateTime.Now.ToShortDateString()))
                lbPet.BackColor = Color.FromArgb(70, 130, 180);
            else
                lbPet.BackColor = Color.FromArgb(110, 110, 110);

            if (lbSub.Text.Equals(DateTime.Now.ToShortDateString()))
                lbSub.BackColor = Color.FromArgb(70, 130, 180);
            else
                lbSub.BackColor = Color.FromArgb(110, 110, 110);

            if (lbNed.Text.Equals(DateTime.Now.ToShortDateString()))
                lbNed.BackColor = Color.FromArgb(70, 130, 180);
            else
                lbNed.BackColor = Color.FromArgb(110, 110, 110);
        }

        public void popuniKalendar()
		{
			try
			{
                oznaciDanas();
				lbPonSmena.Text = null;
				lbUtoSmena.Text = null;
				lbSreSmena.Text = null;
				lbCetSmena.Text = null;
				lbPetSmena.Text = null;
				lbSubSmena.Text = null;

				Smena s = new Smena();
				var forma = Application.OpenForms["formaRadnika"] as formaRadnika;
				if (forma != null) s.ID = int.Parse(forma.lbID.Text);

				Radnik r = new Radnik();
				r.ID = s.ID;
				DataTable dt = r.selectRadnik();
				lbRadnik.Text = dt.Rows[0][3].ToString();
				if (dt.Rows[0][11] != null)
				{
					r.Slika = (byte[])(dt.Rows[0][11]);
					MemoryStream mstream = new MemoryStream(r.Slika);
					pictureBox.Image = System.Drawing.Image.FromStream(mstream);
				}

				DataTable smene = s.selectSmenuPoIDU();

				for (int i = 0; i < smene.Rows.Count; i++)
				{
					if (lbPon.Text.Equals(smene.Rows[i][0].ToString()))
					{
						lbPonSmena.Text = smene.Rows[i][1].ToString() + " smena";
					}

					if (lbUto.Text.Equals(smene.Rows[i][0].ToString()))
					{
						lbUtoSmena.Text = smene.Rows[i][1].ToString() + " smena";
					}

					if (lbSre.Text.Equals(smene.Rows[i][0].ToString()))
					{
						lbSreSmena.Text = smene.Rows[i][1].ToString() + " smena";
					}

					if (lbCet.Text.Equals(smene.Rows[i][0].ToString()))
					{
						lbCetSmena.Text = smene.Rows[i][1].ToString() + " smena";
					}

					if (lbPet.Text.Equals(smene.Rows[i][0].ToString()))
					{
						lbPetSmena.Text = smene.Rows[i][1].ToString() + " smena";
					}

					if (lbSub.Text.Equals(smene.Rows[i][0].ToString()))
					{
						lbSubSmena.Text = smene.Rows[i][1].ToString() + " smena";
					}
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}

using ParkAssist.Klase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkAssist
{
    public partial class formaRadnika : Form
    {
        int p = 0;
        Radnik r = new Radnik();
        public formaRadnika()
        {
            
            InitializeComponent();
            grafickaSema1.Visible = true;
            sidePanel.Top = btnParking.Top;
            sidePanel.Height = btnParking.Height;
			grafickaSema1.BringToFront();
		}

        public void resetsve(int n)
        {
            if(n != 1)
                grafickaSema1.Visible = false;
            if (n != 2)
                mesecneKarte1.Visible = false;
            if (n != 3)
                rasporedRadnika1.Visible = false;
            if (n != 4)
                statistikaRadnika1.Visible = false;
			if (n != 5)
				oAplikaciji1.Visible = false;
        }

        public void btnParking_Click(object sender, EventArgs e)
        {
            resetsve(1);
            grafickaSema1.show();
            sidePanel.Top = btnParking.Top;
            grafickaSema1.BringToFront();
			grafickaSema1.prikazVozila();
			grafickaSema1.popuniTabelu();
            grafickaSema1.Visible = true;
		}

        private void btnMesecneKarte_Click(object sender, EventArgs e)
        {
            resetsve(2);
            mesecneKarte1.prikazi();
            sidePanel.Top = btnMesecneKarte.Top;
			mesecneKarte1.BringToFront();
            mesecneKarte1.Visible = true;
		}

        private void btnRaspored_Click(object sender, EventArgs e)
        {
            resetsve(3);
            sidePanel.Top = btnRaspored.Top;
			rasporedRadnika1.BringToFront();
			rasporedRadnika1.popuniKalendar();
            rasporedRadnika1.Visible = true;
        }

        private void btnPodesavanja_Click(object sender, EventArgs e)
        {
			resetsve(5);
            sidePanel.Top = btnPodesavanja.Top;
			oAplikaciji1.BringToFront();
			oAplikaciji1.Visible = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            for (int i = Application.OpenForms.Count - 1; i != -1; i = Application.OpenForms.Count - 1)
            {
                Application.OpenForms[i].Close();
            }
        }

		public void PrijavljeniKorisnik(Osoba o)
		{
			r.ID = o.ID;
			lbID.Text = r.ID.ToString();

			DataTable dt = r.selectRadnik();

			if (dt.Rows.Count == 1)
			{
				r.VrstaKorisnika = dt.Rows[0][2].ToString();
				r.ImePrezime = dt.Rows[0][3].ToString();
				r.DatumRodjenja = dt.Rows[0][4].ToString();
				r.Adresa = dt.Rows[0][5].ToString();
				r.LokacijaRada = dt.Rows[0][6].ToString();
				r.DatumZaposljenja = dt.Rows[0][7].ToString();
				if (dt.Rows[0][11] != null)
				{
					r.Slika = (byte[])(dt.Rows[0][11]);
					MemoryStream mstream = new MemoryStream(r.Slika);
					pictureBox.Image = System.Drawing.Image.FromStream(mstream);
				}

				lbImePrezime.Text = r.ImePrezime;
				lbVrstaKorisnika.Text = r.VrstaKorisnika;
			}
		}

        private void btnInfo_Click(object sender, EventArgs e)
        {
			Osoba o = new Osoba();
			o.ID = int.Parse(lbID.Text);

			podaciUlogovanog1.popuniFormu(o);
			
            p++;
            if (p == 1)
            {
                podaciUlogovanog1.Visible = true;
                podaciUlogovanog1.BringToFront();
            }
            else if(p > 1)
            {
                podaciUlogovanog1.Visible = false;
                podaciUlogovanog1.SendToBack();
                p = 0;
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnStatistika_Click(object sender, EventArgs e)
        {
            resetsve(4);
            statistikaRadnika1.resetStatistika();
            sidePanel.Top = btnStatistika.Top;
            statistikaRadnika1.BringToFront();
            statistikaRadnika1.Visible = true;
        }

		private void btnOdjaviSe_Click(object sender, EventArgs e)
		{
			this.Hide();
			loginForm f = new loginForm();
			f.Show();
		}

        private void statistikaRadnika1_Load(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class formaDirektora : Form
    {
		Direktor d = new Direktor();
        int p = 0;
        public formaDirektora()
        {
            InitializeComponent();
            sidePanel.Top = btnRaspored.Top;
            sidePanel.Height = btnRaspored.Height;
            raspored1.BringToFront();
            raspored1.Visible = true;
			raspored1.popuniKalendar();
            clanoviSluzbe1.dodajclana = dodajClana1;
			clanoviSluzbe1.bivsiclanovi = bivsiClanovi1;
			clanoviSluzbe1.pojedinacniClan = pojedinacniClan1;
			pojedinacniClan1.clanovisluzbe = clanoviSluzbe1;
			pojedinacniClan1.bivsiclanovi = bivsiClanovi1;
			dodajClana1.clanovisluzbe = clanoviSluzbe1;
			bivsiClanovi1.pojedinacniClan = pojedinacniClan1;
        }

        public void resetsve(int n)
        {
            if (n != 1)
                raspored1.Visible = false;
            if (n != 2)
            {
                clanoviSluzbe1.Visible = false;
                pojedinacniClan1.Visible = false;
				bivsiClanovi1.Visible = false;
                dodajClana1.Visible = false;
            }
            if (n != 3)
                statistikaRadnika1.Visible = false;
			if (n != 4)
				oAplikaciji1.Visible = false;
        }

        private void btnRaspored_Click(object sender, EventArgs e)
        {
            resetsve(1);
            raspored1.odustaj();
            sidePanel.Top = btnRaspored.Top;
            raspored1.BringToFront();
            raspored1.popuniKalendar();
            raspored1.Visible = true;
        }

        private void btnClanovi_Click(object sender, EventArgs e)
        {
            resetsve(2);
            pojedinacniClan1.ukloniSacuvaj();
            sidePanel.Top = btnClanovi.Top;
            clanoviSluzbe1.BringToFront();
            clanoviSluzbe1.Visible = true;
            pojedinacniClan1.Visible = true;
            dodajClana1.Visible = true;
			bivsiClanovi1.Visible = true;
        }

        private void btnStatistika_Click(object sender, EventArgs e)
        {
            resetsve(3);
            statistikaRadnika1.resetStatistika();
            sidePanel.Top = btnStatistika.Top;
            statistikaRadnika1.BringToFront();
            statistikaRadnika1.Visible = true;
            
        }

        private void btnPodesavanja_Click(object sender, EventArgs e)
        {
			resetsve(4);
            sidePanel.Top = btnPodesavanja.Top;
			oAplikaciji1.Visible = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            for (int i = Application.OpenForms.Count - 1; i != -1; i = Application.OpenForms.Count - 1)
            {
                Application.OpenForms[i].Close();
            }
        }

        private void clanoviSluzbe1_Load(object sender, EventArgs e)
        {

        }

        private void bivsiClanovi1_Load(object sender, EventArgs e)
        {

        }

		public void PrijavljeniKorisnik(Osoba o)
		{
			d.ID = o.ID;
			lbID.Text = d.ID.ToString();

			DataTable dt = d.selectDirektor();

			if (dt.Rows.Count == 1)
			{
				d.VrstaKorisnika = dt.Rows[0][2].ToString();
				d.ImePrezime = dt.Rows[0][3].ToString();
				d.DatumRodjenja = dt.Rows[0][4].ToString();
				d.Adresa = dt.Rows[0][5].ToString();
				d.LokacijaRada = dt.Rows[0][6].ToString();
				d.DatumZaposljenja = dt.Rows[0][7].ToString();
				if (dt.Rows[0][11] != null)
				{
					d.Slika = (byte[])(dt.Rows[0][11]);
					MemoryStream mstream = new MemoryStream(d.Slika);
					pictureBox.Image = System.Drawing.Image.FromStream(mstream);
				}

				lbImePrezime.Text = d.ImePrezime;
				lbVrstaKorisnika.Text = d.VrstaKorisnika;
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
                podaciUlogovanog1.BringToFront();
                podaciUlogovanog1.Visible = true;
            }
            else if (p > 1)
            {
                podaciUlogovanog1.Visible = false;
                podaciUlogovanog1.SendToBack();
                p = 0;
            }
        }

		private void btnOdjaviSe_Click(object sender, EventArgs e)
		{
			this.Hide();
			loginForm f = new loginForm();
			f.Show();
		}
	}
}

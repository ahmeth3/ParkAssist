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
using System.Text.RegularExpressions;

namespace ParkAssist
{
    public partial class dodajClana : UserControl
    {
		Direktor d = new Direktor();
		string picLoc = "";
		public clanoviSluzbe clanovisluzbe { get; set; }
        public dodajClana()
        {
            InitializeComponent();
        }

        private void vanish()
        {
            tbVrstaKorisnika.Text = "";
            tbKorisnickoIme.Text = "";
            tbLozinka.Text = "";
            tbImePrezime.Text = "";
            tbDatumRodjenja.Text = "";
            tbAdresa.Text = "";
            tbLokacijaRada.Text = "";
            tbDatumZaposljenja.Text = "";
        }
        private void btnOdustani_Click(object sender, EventArgs e)
        {
            clanovisluzbe.BringToFront();
            vanish();
        }

		private void btnDodajClana_Click(object sender, EventArgs e)
		{
			try
			{
				if (tbVrstaKorisnika.Text == "" || tbKorisnickoIme.Text == "" || tbLozinka.Text == "" || tbImePrezime.Text == "")
					customMessageBox.Show("Vrsta korisnika, korisničko ime, lozinka i ime i prezime ne smeju biti prazni!");
				else
				{
					byte[] imageBt = null;
					if (picLoc != "")
					{
						FileStream fstream = new FileStream(picLoc, FileMode.Open, FileAccess.Read);
						BinaryReader br = new BinaryReader(fstream);
						imageBt = br.ReadBytes((int)fstream.Length);
					}
					else
					{
						FileStream fstream = new FileStream("kontakte.png", FileMode.Open, FileAccess.Read);
						BinaryReader br = new BinaryReader(fstream);
						imageBt = br.ReadBytes((int)fstream.Length);
					}
					Osoba o = new Osoba(tbVrstaKorisnika.Text, tbKorisnickoIme.Text, tbLozinka.Text, tbImePrezime.Text, tbDatumRodjenja.Text, tbAdresa.Text, tbLokacijaRada.Text, tbDatumZaposljenja.Text);
					o.Slika = imageBt;

					if (d.proveraKorisnika(o))
						customMessageBox.Show("Uneto korisničko ime već postoji! Molimo Vas, izaberite drugo.");
					else
					{
						if (d.kreirajKorisnika(o))
						{
							customMessageBox.Show("Uspešno kreiran korisnik!");
							clanovisluzbe.prikazRadnika("Aktivni");
							clanovisluzbe.BringToFront();
                            vanish();
						}

						else customMessageBox.Show("Neuspešno kreiran korisnik!");
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void btnDodajSliku_Click(object sender, EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";
			dlg.Title = "Izaberite sliku";
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				picLoc = dlg.FileName.ToString();
				pictureBox.ImageLocation = picLoc;
				pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
			}
		}

        private void tbVrstaKorisnika_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s\b\.]");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void tbKorisnickoIme_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s\b\.]");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void tbLozinka_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s\b\.]");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void tbImePrezime_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s\b\.\u0161\u0111\u010D\u0107\u017E]+$");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void tbDatumRodjenja_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s\b\.]");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void tbAdresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s\b\.\u0161\u0111\u010D\u0107\u017E]+$");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void tbLokacijaRada_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s\b\.\u0161\u0111\u010D\u0107\u017E]+$");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void tbDatumZaposljenja_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s\b\.]");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

		private void btnMakniSliku_Click(object sender, EventArgs e)
		{
			pictureBox.Image = null;
		}
	}
}

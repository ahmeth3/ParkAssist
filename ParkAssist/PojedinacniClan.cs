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
	public partial class PojedinacniClan : UserControl
	{
		Direktor d = new Direktor();
		public clanoviSluzbe clanovisluzbe { get; set; }
		public bivsiClanovi bivsiclanovi { get; set; }
		public int indeks;
		public int aktivnost; //ako je 0 onda su izabrani aktivni, ako je 1 izabrani su bivsi
		string picLoc = "";
		public PojedinacniClan()
		{
			InitializeComponent();
		}

		public void popuniPodacima()
		{
			try
			{
				Osoba o = d.prikazRadnika(indeks);

				labelImePrezime.Text = o.ImePrezime;
				ImePrezimeEdit.Text = labelImePrezime.Text;
				labelLokacija.Text = "Parkiralište: " + o.LokacijaRada;
				labelVrstaKorisnika.Text = o.VrstaKorisnika;
				tbKorisnickoIme.Text = o.KorisnickoIme;
				tbDatumRodjenja.Text = o.DatumRodjenja;
				tbDatumZaposljenja.Text = o.DatumZaposljenja;
				tbAdresa.Text = o.Adresa;
				lbNapomena.Text = o.Napomena;
				if (o.Slika != null)
				{
					MemoryStream mstream = new MemoryStream(o.Slika);
					pictureBox.Image = System.Drawing.Image.FromStream(mstream);
				}
				else pictureBox.Image = System.Drawing.Image.FromFile("kontakte.png");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		public void prilagodi()
		{
			if (aktivnost == 1)
			{
				btnUredi.Visible = false;
				btnUredi.Enabled = false;
				btnArhiviraj.Text = "Obriši";
				btnArhiviraj.Image = Image.FromFile("brisi.png");
				btnArhiviraj.Padding = new Padding(15, 0, 90, 0);
			}
			else
			{
				btnUredi.Visible = true;
				btnUredi.Enabled = true;
				btnArhiviraj.Text = "     Arhiviraj";
				btnArhiviraj.Image = Image.FromFile("arhiviraj.png");
				btnArhiviraj.Padding = new Padding(0, 0, 80, 0);
			}

		}

		private void btnArhiviraj_Click(object sender, EventArgs e)
		{
			try
			{
				Osoba o = new Osoba();
				o.KorisnickoIme = tbKorisnickoIme.Text;
				if (aktivnost == 0)
				{
					DialogResult result = cmbyn.Show("Jeste li sigurni da želite arhivirati korisnika?");
					if (result == DialogResult.Yes)
					{
						if (d.arhivirajKorisnika(o))
						{
							clanovisluzbe.prikazRadnika("Aktivni");
							bivsiclanovi.prikazRadnika("Bivsi");
							clanovisluzbe.BringToFront();
						}

						else customMessageBox.Show("Došlo je do greške prilikom arhiviranja");
					}
						
				}
				else
				{
					DialogResult result = cmbyn.Show("Jeste li sigurni da želite obrisati korisnika?");
					if (result == DialogResult.Yes)
					{
						if (d.izbrisiKorisnika(o))
						{
							clanovisluzbe.BringToFront();
							clanovisluzbe.btnBivsi_Click(sender, e);
						}
					}
						
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void btnUredi_Click(object sender, EventArgs e)
		{
			try
			{
				panel5.Visible = false;
				tbEditLozinka.Enabled = true;
				tbEditLozinka.Text = null;

				Osoba o = d.prikazRadnika(indeks);

				tbEditImePrezime.Text = o.ImePrezime;
				tbEditLokacija.Text = o.LokacijaRada;
				tbEditVrstaKorisnika.Text = o.VrstaKorisnika;
				tbEditKorisnickoIme.Text = o.KorisnickoIme;
				tbEditDatumRodjenja.Text = o.DatumRodjenja;
				tbEditDatumZaposljenja.Text = o.DatumZaposljenja;
				tbEditAdresa.Text = o.Adresa;
				tbNapomena.Visible = true;
				tbNapomena.Enabled = true;
				tbNapomena.Text = o.Napomena;

				panel3.Visible = false;
				panel3.Enabled = false;
				panelEdit.Visible = true;
				panelEdit.Enabled = true;
				labelImePrezime.Visible = false;
				labelVrstaKorisnika.Visible = false;
				panel3.Visible = false;
				ImePrezimeEdit.Visible = true;
				btnPromeniSliku.Visible = true;


				Button sacuvaj = new Button();
				this.Controls.Add(sacuvaj);
                sacuvaj.FlatStyle = FlatStyle.Flat;
				sacuvaj.Top = btnUredi.Top;
				sacuvaj.Left = btnUredi.Left;
				sacuvaj.Width = btnUredi.Width;
				sacuvaj.Height = btnUredi.Height;
				sacuvaj.BackColor = btnUredi.BackColor;
				sacuvaj.Text = "Sačuvaj";
                sacuvaj.Name = "sacuvaj";
				sacuvaj.Font = btnUredi.Font;
				sacuvaj.ForeColor = btnUredi.ForeColor;
				sacuvaj.FlatAppearance.BorderSize = 0;
				btnUredi.Top = 303;
				btnUredi.Enabled = false;
				btnUredi.Visible = false;

				sacuvaj.Click += new EventHandler(sacuvajPromene);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

        public void ukloniSacuvaj()
        {
            foreach (Control item in this.Controls.OfType<Control>())
            {
                if (item.Name == "sacuvaj")
                    this.Controls.Remove(item);
            }
            tbNapomena.Visible = false;
            tbNapomena.Enabled = false;
            panel3.Visible = true;
            panel3.Enabled = true;
            panelEdit.Visible = false;
            panelEdit.Enabled = false;
            labelImePrezime.Visible = true;
            labelVrstaKorisnika.Visible = true;
            panel3.Visible = true;
            ImePrezimeEdit.Visible = false;
            tbEditLozinka.Enabled = false;
            btnPromeniSliku.Visible = false;
            popuniPodacima();
        }
		private void sacuvajPromene(object sender, EventArgs e)
		{
			try
			{
				Osoba o = d.prikazRadnika(indeks);

				o.ImePrezime = tbEditImePrezime.Text;
				o.LokacijaRada = tbEditLokacija.Text;
				o.VrstaKorisnika = tbEditVrstaKorisnika.Text;
				o.KorisnickoIme = tbEditKorisnickoIme.Text;
				if (tbEditLozinka.Text != "")
					o.Lozinka = tbEditLozinka.Text;
				o.DatumRodjenja = tbEditDatumRodjenja.Text;
				o.DatumZaposljenja = tbEditDatumZaposljenja.Text;
				o.Adresa = tbEditAdresa.Text;
				o.Napomena = tbNapomena.Text;

				byte[] imageBt = null;
				if (picLoc != "")
				{
					FileStream fstream = new FileStream(picLoc, FileMode.Open, FileAccess.Read);
					BinaryReader br = new BinaryReader(fstream);
					imageBt = br.ReadBytes((int)fstream.Length);
				}
				else
				{
					using (var mstream = new MemoryStream())
					{
						pictureBox.Image.Save(mstream, pictureBox.Image.RawFormat);
						imageBt = mstream.ToArray();
					}
				}
				o.Slika = imageBt;

				labelLokacija.Text = "Parkiralište: ";
				d.azurirajRadnika(o);
				Button pom = sender as Button;
				btnUredi.Left = pom.Left;
				btnUredi.Top = pom.Top;
				btnUredi.BackColor = pom.BackColor;
				btnUredi.Enabled = true;
				btnUredi.Visible = true;
				this.Controls.Remove(sender as Button);

				tbNapomena.Visible = false;
				tbNapomena.Enabled = false;
				panel3.Visible = true;
				panel3.Enabled = true;
				panelEdit.Visible = false;
				panelEdit.Enabled = false;
				labelImePrezime.Visible = true;
				labelVrstaKorisnika.Visible = true;
				panel3.Visible = true;
				ImePrezimeEdit.Visible = false;
				tbEditLozinka.Enabled = false;
				btnPromeniSliku.Visible = false;
				panel5.Visible = true;
				popuniPodacima();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void btnNazad_Click(object sender, EventArgs e)
		{
            ukloniSacuvaj();
			labelLokacija.Text = "Parkiralište: ";
			if (aktivnost == 0)
			{
				clanovisluzbe.prikazRadnika("Aktivni");
				clanovisluzbe.BringToFront();
			}
			else
			{
				clanovisluzbe.BringToFront();
				clanovisluzbe.btnBivsi_Click(sender, e);
			}
		}

		private void tbEditLozinka_MouseClick(object sender, MouseEventArgs e)
		{
			tbEditLozinka.Enabled = true;
		}

		private void tbEditLozinka_Leave(object sender, EventArgs e)
		{
			tbEditLozinka.Enabled = false;
		}

		private void btnPromeniSliku_Click_1(object sender, EventArgs e)
		{
			try
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
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

        private void tbEditVrstaKorisnika_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s\b\.]");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void tbEditKorisnickoIme_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s\b\.]");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void tbEditLozinka_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s\b\.]");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void tbEditImePrezime_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s\b\.\u0161\u0111\u010D\u0107\u017E]+$");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void tbEditDatumRodjenja_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s\b\.]");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void tbEditAdresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s\b\.\u0161\u0111\u010D\u0107\u017E]+$");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void tbEditLokacija_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s\b\.\u0161\u0111\u010D\u0107\u017E]+$");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void tbEditDatumZaposljenja_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbDatumRodjenja_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s\b\.]");
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

        private void tbAdresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s\b\.]");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

		private void tbNapomena_KeyPress(object sender, KeyPressEventArgs e)
		{
			var regex = new Regex(@"[^a-zA-Z0-9\s\b\.\u0161\u0111\u010D\u0107\u017E]+$");
			if (regex.IsMatch(e.KeyChar.ToString()))
			{
				e.Handled = true;
			}
		}
	}
}

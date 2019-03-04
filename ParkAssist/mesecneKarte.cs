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
using System.Text.RegularExpressions;

namespace ParkAssist
{
    public partial class mesecneKarte : UserControl
    {
        public mesecneKarte()
        {
            InitializeComponent();
        }

		private void popuniTabelu()
		{
			try
			{
				DataTable karte = Karta.selectKarte();
				tabela.DataSource = karte;
				tabela.Columns[0].HeaderCell.Value = "Ime i Prezime korisnika";
				tabela.Columns[1].HeaderCell.Value = "Registracioni broj tablica";
				tabela.Columns[2].HeaderCell.Value = "Tip karte";
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            sakrij();
			btnDodajClana.Visible = true;
        }

        private void btnAzuriraj_Click(object sender, EventArgs e)
        {
			if (tabela.SelectedRows.Count != 1)
				customMessageBox.Show("Molimo Vas izaberite korisnika!");
			else if(tabela.SelectedRows.Count == 1 && tabela.SelectedRows[0].Cells[0].Value != null)
			{
				tbImePrezime.Text = tabela.SelectedRows[0].Cells[0].Value.ToString();
				string tablica = tabela.SelectedRows[0].Cells[1].Value.ToString();
				tbGrad.Text = tablica[0].ToString() + tablica[1].ToString();
				tbBrojTablica.Text = tablica[3].ToString() + tablica[4].ToString() + tablica[5].ToString();
				tbSlovaTablice.Text = tablica[7].ToString() + tablica[8].ToString();
				cbVrstaKarte.Text = tabela.SelectedRows[0].Cells[2].Value.ToString();
				sakrij();
				btnAzurirajClana.Visible = true;
			}
		}

        private void btnBrisi_Click(object sender, EventArgs e)
        { 
			try
			{
				if (tabela.SelectedRows.Count != 1)
					customMessageBox.Show("Molimo Vas izaberite korisnika!");
				else if(tabela.SelectedRows.Count == 1 && tabela.SelectedRows[0].Cells[0].Value != null)
				{
					Karta k = new Karta();
					k.ID = int.Parse(tabela.SelectedRows[0].Cells[5].Value.ToString());
					DialogResult result = cmbyn.Show("Jeste li sigurni da želite obrisati korisnika?");
					if(result == DialogResult.Yes)
					k.obrisiKartu();
					popuniTabelu();
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
        
        private void sakrij()
        {
            pZaUredjivanje.Visible = true;
            btnDodaj.Visible = false;
            btnAzuriraj.Visible = false;
            btnBrisi.Visible = false;
        }

        public void prikazi()
        {
            pZaUredjivanje.Visible = false;
            btnDodaj.Visible = true;
            btnAzuriraj.Visible = true;
            btnBrisi.Visible = true;
			btnDodajClana.Visible = false;
			btnAzurirajClana.Visible = false;
			
			tbImePrezime.Text = "Unesite ime i prezime korisnika";
			tbGrad.Text = "NP";
			tbBrojTablica.Text = "000";
			tbSlovaTablice.Text = "AA";
			cbVrstaKarte.Text = "Izaberite vrstu karte";
			tbSearch.Text = "";
		}

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            prikazi();
        }

		private void btnDodajClana_MouseClick(object sender, MouseEventArgs e)
		{
			try
			{
				if (tbImePrezime.Text.Equals("Unesite ime i prezime korisnika") && tbGrad.Text.Equals("NP") && tbBrojTablica.Text.Equals("000") && tbSlovaTablice.Text.Equals("AA") && cbVrstaKarte.Text.Equals("Izaberite vrstu karte"))
					customMessageBox.Show("Popunite podatke!");
				else if (tbImePrezime.Text.Equals("Unesite ime i prezime korisnika") || string.IsNullOrEmpty(tbImePrezime.Text))
					customMessageBox.Show("Unesite ime i prezime korisnika!");
				else if ((tbGrad.Text.Equals("NP") && tbBrojTablica.Text.Equals("000") && tbSlovaTablice.Text.Equals("AA")) || (string.IsNullOrEmpty(tbGrad.Text) || string.IsNullOrEmpty(tbBrojTablica.Text) || string.IsNullOrEmpty(tbSlovaTablice.Text)))
					customMessageBox.Show("Unesite registracioni broj tablica vozila korisnika!");
				else if (cbVrstaKarte.Text.Equals("Izaberite vrstu karte") || string.IsNullOrEmpty(cbVrstaKarte.Text))
					customMessageBox.Show("Izaberite vrstu karte korisnika!");
				else
				{
					Karta k = new Karta();
					k.ImePrezime = tbImePrezime.Text;
					k.RegistracioniBrojTablica = tbGrad.Text + "-" + tbBrojTablica.Text + "-" + tbSlovaTablice.Text;
					k.TipKarte = cbVrstaKarte.Text;
					if (k.TipKarte == "mesečna")
						k.Mesec = DateTime.Now.Month.ToString();
					k.Godina = DateTime.Now.Year.ToString();
					DataTable provera = Karta.selectKarteZaProveru(k.RegistracioniBrojTablica);
					if(provera.Rows.Count > 0)
					{
						customMessageBox.Show("Vlasnik ovog vozila već ima ili je imao kartu. Ažurirajte ga!");
					}
					else
					{
						k.unesiKartu();

						Statistika s = new Statistika();
						s.Mesec = DateTime.Now.Month.ToString();
						s.Godina = DateTime.Now.Year.ToString();
						DataTable dt = s.selectStatistika();
						if(dt.Rows.Count != 0)
						{
							s.brojKarti = int.Parse(dt.Rows[0][2].ToString()) + 1;
							if(k.TipKarte == "mesečna")
								s.Prihod = int.Parse(dt.Rows[0][3].ToString()) + 500;
							else if(k.TipKarte == "godišnja")
								s.Prihod = int.Parse(dt.Rows[0][3].ToString()) + 5000;
							s.unosKarteStatistika();
						}
						else
						{
							s.brojKarti = 1;
							if (k.TipKarte == "mesečna")
								s.Prihod = 500;
							else if (k.TipKarte == "godišnja")
								s.Prihod = 5000;
							s.kreiranjeMeseca();
						}
						popuniTabelu();
						prikazi();
					}
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void btnAzurirajClana_Click(object sender, EventArgs e)
		{
			try
			{
				if (tbImePrezime.Text.Equals("Unesite ime i prezime korisnika") && tbGrad.Text.Equals("NP") && tbBrojTablica.Text.Equals("000") && tbSlovaTablice.Text.Equals("AA") && cbVrstaKarte.Text.Equals("Izaberite vrstu karte"))
					customMessageBox.Show("Popunite podatke!");
				else if (tbImePrezime.Text.Equals("Unesite ime i prezime korisnika") || string.IsNullOrEmpty(tbImePrezime.Text))
					customMessageBox.Show("Unesite ime i prezime korisnika!");
				else if ((tbGrad.Text.Equals("NP") && tbBrojTablica.Text.Equals("000") && tbSlovaTablice.Text.Equals("AA")) || (string.IsNullOrEmpty(tbGrad.Text) || string.IsNullOrEmpty(tbBrojTablica.Text) || string.IsNullOrEmpty(tbSlovaTablice.Text)))
					customMessageBox.Show("Unesite registracioni broj tablica vozila korisnika!");
				else if (cbVrstaKarte.Text.Equals("Izaberite vrstu karte") || string.IsNullOrEmpty(cbVrstaKarte.Text))
					customMessageBox.Show("Izaberite vrstu karte korisnika!");
				else
				{
					Karta k = new Karta();
					k.ImePrezime = tbImePrezime.Text;
					k.RegistracioniBrojTablica = tbGrad.Text + "-" + tbBrojTablica.Text + "-" + tbSlovaTablice.Text;
					k.TipKarte = cbVrstaKarte.Text;
					if (k.TipKarte == "mesečna")
						k.Mesec = DateTime.Now.Month.ToString();
					k.Godina = DateTime.Now.Year.ToString();
					k.ID = int.Parse(tabela.SelectedRows[0].Cells[5].Value.ToString());
					DataTable provera = Karta.selectKarteZaProveru(k.RegistracioniBrojTablica);
					if (provera.Rows.Count > 0 && !provera.Rows[0][5].ToString().Equals(k.ID.ToString()))
					{
						customMessageBox.Show("Vlasnik ovog vozila već ima ili je imao kartu. Proverite podatke!");
					}
					else
					{
						k.azurirajKartu();
						popuniTabelu();
						prikazi();
					}
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void mesecneKarte_Load(object sender, EventArgs e)
		{
			popuniTabelu();
		}

		private void tabela_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (pZaUredjivanje.Visible == true && btnAzurirajClana.Visible == true && tabela.SelectedRows.Count == 1 && tabela.SelectedRows[0].Cells[0].Value != null)
			{
				tbImePrezime.Text = tabela.SelectedRows[0].Cells[0].Value.ToString();
				string tablica = tabela.SelectedRows[0].Cells[1].Value.ToString();
				tbGrad.Text = tablica[0].ToString() + tablica[1].ToString();
				tbBrojTablica.Text = tablica[3].ToString() + tablica[4].ToString() + tablica[5].ToString();
				tbSlovaTablice.Text = tablica[7].ToString() + tablica[8].ToString();
				cbVrstaKarte.Text = tabela.SelectedRows[0].Cells[2].Value.ToString();
			}
		}

		private void tbSearch_TextChanged(object sender, EventArgs e)
		{
			DataTable pretraga = Karta.selectKarteZaSearch(tbSearch.Text);
			tabela.DataSource = pretraga;

			tabela.Columns[0].HeaderCell.Value = "Ime i Prezime korisnika";
			tabela.Columns[1].HeaderCell.Value = "Registracioni broj tablica";
			tabela.Columns[2].HeaderCell.Value = "Tip karte";
		}

		private void tbImePrezime_MouseClick(object sender, MouseEventArgs e)
		{
			tbImePrezime.Text = "";
		}

		private void tbGrad_MouseClick(object sender, MouseEventArgs e)
		{
			tbGrad.Text = "";
		}

		private void tbBrojTablica_MouseClick(object sender, MouseEventArgs e)
		{
			tbBrojTablica.Text = "";
		}

		private void tbSlovaTablice_MouseClick(object sender, MouseEventArgs e)
		{
			tbSlovaTablice.Text = "";
		}

		private void tbGrad_TextChanged(object sender, EventArgs e)
		{
			tbGrad.CharacterCasing = CharacterCasing.Upper;
		}

		private void tbBrojTablica_TextChanged(object sender, EventArgs e)
		{
			tbBrojTablica.CharacterCasing = CharacterCasing.Upper;
		}

		private void tbSlovaTablice_TextChanged(object sender, EventArgs e)
		{
			tbSlovaTablice.CharacterCasing = CharacterCasing.Upper;
		}

        private void tbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s\b]");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void tbImePrezime_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s\b\u0161\u0111\u010D\u0107\u017E]+$");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void cbVrstaKarte_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s\b]");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void tbBrojTablica_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s\b]");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

		private void tbGrad_KeyPress(object sender, KeyPressEventArgs e)
		{
			var regex = new Regex(@"[^a-zA-Z0-9\s\b\u0161\u0111\u010D\u0107\u017E]+$");
			if (regex.IsMatch(e.KeyChar.ToString()))
			{
				e.Handled = true;
			}
		}

		private void tbSlovaTablice_KeyPress(object sender, KeyPressEventArgs e)
		{
			var regex = new Regex(@"[^a-zA-Z0-9\s\b\u0161\u0111\u010D\u0107\u017E]+$");
			if (regex.IsMatch(e.KeyChar.ToString()))
			{
				e.Handled = true;
			}
		}
	}
}

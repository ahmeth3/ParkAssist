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
    public partial class statistikaRadnika : UserControl
    {
        public statistikaRadnika()
        {
            InitializeComponent();
        }

        private void btnPrikaziKazne_Click(object sender, EventArgs e)
        {
            pSveKazne.Visible = true;

        }

        public void resetStatistika()
        {
            pSveKazne.Visible = false;
            panelZaKaznu.Visible = false;
            tbSearch.Text = "";
        }
        private void btnOdustani_Click(object sender, EventArgs e)
        {
            resetStatistika();
        }

        private void btnKDodaj_Click(object sender, EventArgs e)
        {
            tbDatum.Text = DateTime.Today.ToShortDateString();
            tbVremeKazna.Text = DateTime.Now.ToShortTimeString();
            tbPMestoKazna.Text = "";
			tbRegistarskiBrojTablica.Text = "";
			tbNapomena.Text = "";
			panelZaKaznu.Visible = true;
        }

        private void btnKAzuriraj_Click(object sender, EventArgs e)
        {
			if (tabela.SelectedRows.Count != 1)
				customMessageBox.Show("Molimo Vas izaberite korisnika!");
			else if (tabela.SelectedRows.Count == 1 && tabela.SelectedRows[0].Cells[0].Value != null)
			{
				tbPMestoKazna.Text = tabela.SelectedRows[0].Cells[0].Value.ToString();
				tbRegistarskiBrojTablica.Text = tabela.SelectedRows[0].Cells[1].Value.ToString();
				tbDatum.Text = tabela.SelectedRows[0].Cells[2].Value.ToString();
				tbVremeKazna.Text = tabela.SelectedRows[0].Cells[3].Value.ToString();
				tbNapomena.Text = tabela.SelectedRows[0].Cells[4].Value.ToString();
				panelZaKaznu.Visible = true;
			}
		}

        private void btnKObrisi_Click(object sender, EventArgs e)
        {
			try
			{
				if (tabela.SelectedRows.Count != 1)
					customMessageBox.Show("Molimo Vas izaberite korisnika!");
				else if (tabela.SelectedRows.Count == 1 && tabela.SelectedRows[0].Cells[0].Value != null)
				{
					Kazna k = new Kazna();
					k.ID = int.Parse(tabela.SelectedRows[0].Cells[5].Value.ToString());
					DialogResult result = cmbyn.Show("Jeste li sigurni da želite obrisati korisnika?");
					if (result == DialogResult.Yes)
						k.obrisiKaznu();
					popuniTabelu();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
        }

		private void btnUnesiKazna_Click(object sender, EventArgs e)
		{
			try
			{
				if (string.IsNullOrEmpty(tbPMestoKazna.Text) || string.IsNullOrEmpty(tbRegistarskiBrojTablica.Text) || string.IsNullOrEmpty(tbDatum.Text) || string.IsNullOrEmpty(tbVremeKazna.Text))
					customMessageBox.Show("Popunite podatke!");
				else
				{
					Kazna k = new Kazna();
					k.ParkingMesto = int.Parse(tbPMestoKazna.Text);
					k.RegistracioniBrojTablica = tbRegistarskiBrojTablica.Text;
					k.Datum = tbDatum.Text;
					k.Vreme = tbVremeKazna.Text;
					k.Napomena = tbNapomena.Text;

					k.unesiKaznu();
					popuniTabelu();

					Statistika s = new Statistika();
					s.Mesec = DateTime.Now.Month.ToString();
					s.Godina = DateTime.Now.Year.ToString();
					DataTable dt = s.selectStatistika();
					if (dt.Rows.Count != 0)
					{
						s.brojKazni = int.Parse(dt.Rows[0][4].ToString()) + 1;
						s.Prihod = int.Parse(dt.Rows[0][3].ToString());
						s.unosKazneStatistika();
					}
					else
					{
						s.brojKazni = 1;
						s.kreiranjeMeseca();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void btnAzurirajKazna_Click(object sender, EventArgs e)
		{
			try
			{
				if (string.IsNullOrEmpty(tbPMestoKazna.Text) || string.IsNullOrEmpty(tbRegistarskiBrojTablica.Text) || string.IsNullOrEmpty(tbDatum.Text) || string.IsNullOrEmpty(tbVremeKazna.Text))
					customMessageBox.Show("Popunite podatke!");
				else
				{
					Kazna k = new Kazna();
					k.ParkingMesto = int.Parse(tbPMestoKazna.Text);
					k.RegistracioniBrojTablica = tbRegistarskiBrojTablica.Text;
					k.Datum = tbDatum.Text;
					k.Vreme = tbVremeKazna.Text;
					k.Napomena = tbNapomena.Text;
					k.ID = int.Parse(tabela.SelectedRows[0].Cells[5].Value.ToString());

					k.azurirajKaznu();
					popuniTabelu();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void btnOdustaniKazna_Click(object sender, EventArgs e)
        {
            panelZaKaznu.Visible = false;
			tbPMestoKazna.Text = "";
			tbRegistarskiBrojTablica.Text = "";
			tbDatum.Text = "";
			tbVremeKazna.Text = "";
			tbNapomena.Text = "";
		}

		public void popuniTabelu()
		{
			try
			{
				DataTable karte = Kazna.selectkazne();
				tabela.DataSource = karte;
				tabela.Columns[0].HeaderCell.Value = "Parking mesto";
				tabela.Columns[1].HeaderCell.Value = "Registracioni broj tablica";
				tabela.Columns[2].HeaderCell.Value = "Datum";
				tabela.Columns[3].HeaderCell.Value = "Vreme";
				tabela.Columns[4].HeaderCell.Value = "Napomena";
				tabela.Columns[5].HeaderCell.Value = "Broj kazne";

				Statistika s = new Statistika();
				s.Mesec = DateTime.Now.Month.ToString();
				s.Godina = DateTime.Now.Year.ToString();
				DataTable dt = s.selectStatistika();
				if (dt.Rows.Count != 0)
				{
					lbKarte.Text = dt.Rows[0][2].ToString();
					lbPrihod.Text = dt.Rows[0][3].ToString();
					lbKazne.Text = dt.Rows[0][4].ToString();
				}
				else
				{
					lbKarte.Text = "0";
					lbPrihod.Text = "0";
					lbKazne.Text = "0";
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void statistikaRadnika_Load(object sender, EventArgs e)
		{
			popuniTabelu();
		}

		private void tabela_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (panelZaKaznu.Visible == true && btnAzurirajKazna.Visible == true && tabela.SelectedRows.Count == 1 && tabela.SelectedRows[0].Cells[0].Value != null)
			{
				tbPMestoKazna.Text = tabela.SelectedRows[0].Cells[0].Value.ToString();
				tbRegistarskiBrojTablica.Text = tabela.SelectedRows[0].Cells[1].Value.ToString();
				tbDatum.Text = tabela.SelectedRows[0].Cells[2].Value.ToString();
				tbVremeKazna.Text = tabela.SelectedRows[0].Cells[3].Value.ToString();
				tbNapomena.Text = tabela.SelectedRows[0].Cells[4].Value.ToString();
			}
		}

		private void tbSearch_TextChanged(object sender, EventArgs e)
		{
			DataTable pretraga = Kazna.selectKazneZaSearch(tbSearch.Text);
			tabela.DataSource = pretraga;

			tabela.Columns[0].HeaderCell.Value = "Parking mesto";
			tabela.Columns[1].HeaderCell.Value = "Registracioni broj tablica";
			tabela.Columns[2].HeaderCell.Value = "Datum";
			tabela.Columns[3].HeaderCell.Value = "Vreme";
			tabela.Columns[4].HeaderCell.Value = "Napomena";
			tabela.Columns[5].HeaderCell.Value = "Broj kazne";
		}

        private void tbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s\b]");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void tbPMestoKazna_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s\b]");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void tbDatum_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s\b\.]");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void tbNapomena_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s\b\u0161\u0111\u010D\u0107\u017E]+$");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

		private void tbRegistarskiBrojTablica_KeyPress(object sender, KeyPressEventArgs e)
		{
			var regex = new Regex(@"[^a-zA-Z0-9\s\b\-\u0161\u0111\u010D\u0107\u017E]+$");
			if (regex.IsMatch(e.KeyChar.ToString()))
			{
				e.Handled = true;
			}
		}

		private void tbVremeKazna_KeyPress(object sender, KeyPressEventArgs e)
		{
			var regex = new Regex(@"[^a-zA-Z0-9\s\b\.\:]");
			if (regex.IsMatch(e.KeyChar.ToString()))
			{
				e.Handled = true;
			}
		}
	}
}

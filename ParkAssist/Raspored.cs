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
    public partial class Raspored : UserControl
    {
        DateTime datum = DateTime.Today.AddDays(1 - prviUNedelji());
		public Raspored()
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbVreme.Text = DateTime.Now.ToLongTimeString();
            lbDatum.Text = DateTime.Now.ToLongDateString();
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

            dtpOdD.MinDate = DateTime.Today;
            dtpDoD.MinDate = DateTime.Today;
        }

        private void lbOpseg_Click(object sender, EventArgs e)
        {

        }

        private void btnDodajR_Click(object sender, EventArgs e)
        {
			lbRD.Location = new Point(115, 29);
			imeRadnikaD.Location = new Point(67, 94);
			prikazDodaj();
			btnDodajD.Visible = true;
		}

        private void btnAzurirajR_Click(object sender, EventArgs e)
        {
			lbRD.Location = new Point(115, 29);
			imeRadnikaD.Location = new Point(67, 94);
			prikazDodaj();
			btnAzurirajD.Visible = true;
		}

        private void btnObrisiR_Click(object sender, EventArgs e)
        {
			lbRD.Location = new Point(244, 29);
			imeRadnikaD.Location = new Point(196, 94);
			prikazDodaj();
			btnObrisiD.Visible = true;
			pDiv1D.Visible = false;
			lbRVD.Visible = false;
			dbSmena.Visible = false;
		}

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void imeRadnikaD_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void lbRD_Click(object sender, EventArgs e)
        {

        }

        private void pDiv1D_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbOdD_Click(object sender, EventArgs e)
        {

        }

        private void tbOdD_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbRVD_Click(object sender, EventArgs e)
        {

        }

        private void lbDoD_Click(object sender, EventArgs e)
        {

        }

        private void panel22_Paint(object sender, PaintEventArgs e)
        {

        }

        private void prikazDodaj()
        {
			btnDodajR.Visible = false;
			btnAzurirajR.Visible = false;
			btnObrisiR.Visible = false;
			lbRD.Visible = true;
			imeRadnikaD.Visible = true;
			pDiv1D.Visible = true;
			pDiv2D.Visible = true;
			pDiv3D.Visible = true;
			lbRVD.Visible = true;
			dbSmena.Visible = true;
			lbDD.Visible = true;
			lbOdD1.Visible = true;
			lbDoD1.Visible = true;
			dtpDoD.Visible = true;
			dtpOdD.Visible = true;
			btnOdustaniD.Visible = true;
			btnAzurirajD.Visible = false;
			btnDodajD.Visible = false;
			btnObrisiD.Visible = false;

			imeRadnikaD.Items.Clear();

			try
			{
				DataTable dt = new DataTable();
				dt = Direktor.selectRadnike();

				for (int i = 0; i < dt.Rows.Count; i++)
					imeRadnikaD.Items.Add(dt.Rows[i][3].ToString());
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			imeRadnikaD.Text = "Izaberite radnika";
			dbSmena.Text = "Izaberite smenu";
			dtpOdD.Text = DateTime.Now.ToLongDateString();
			dtpDoD.Text = DateTime.Now.ToLongDateString();
		}

        public void odustaj()
        {
			btnDodajR.Visible = true;
			btnAzurirajR.Visible = true;
			btnObrisiR.Visible = true;
			lbRD.Visible = false;
			imeRadnikaD.Visible = false;
			pDiv1D.Visible = false;
			pDiv2D.Visible = false;
			pDiv3D.Visible = false;
			lbRVD.Visible = false;
			dbSmena.Visible = false;
			lbDD.Visible = false;
			lbOdD1.Visible = false;
			lbDoD1.Visible = false;
			dtpDoD.Visible = false;
			dtpOdD.Visible = false;
			btnAzurirajD.Visible = false;
			btnDodajD.Visible = false;
			btnObrisiD.Visible = false;
			btnOdustaniD.Visible = false;
		}

        private void btnOdustaniD_Click(object sender, EventArgs e)
        {
            odustaj();
        }

		private void btnDodajD_MouseClick(object sender, MouseEventArgs e)
		{
			try
			{
				if (imeRadnikaD.Text.ToString().Equals("") && dbSmena.Text.ToString().Equals("Izaberite smenu"))
					customMessageBox.Show("Izaberite radnika i smenu!");
				else if (imeRadnikaD.Text.ToString().Equals(""))
					customMessageBox.Show("Izaberite radnika!");
				else if (dbSmena.Text.ToString().Equals("Izaberite smenu"))
					customMessageBox.Show("Izaberite smenu!");
				else if (dtpOdD.Value > dtpDoD.Value)
					customMessageBox.Show("Krajnji datum ne sme biti pre početnog!");
				else
				{
					Smena s = new Smena();
					DataTable dt = new DataTable();
					dt = Direktor.selectRadnike();

					for (int i = 0; i < dt.Rows.Count; i++)
					{
						if (dt.Rows[i][3].ToString().Equals(imeRadnikaD.Text))
							s.ID = int.Parse(dt.Rows[i][10].ToString());
					}

					int razlika = dtpDoD.Value.Day - dtpOdD.Value.Day;
					if (razlika < 0) razlika += 31;

					bool provera = false;
					List<string> zauzetiDani = new List<string> { };
					for (int i = 0; i <= razlika; i++)
					{
						s.Datum = dtpOdD.Value.AddDays(i).ToShortDateString();
						s.izborSmene = dbSmena.Text;
						DataTable smena = s.selectSmenu();

						if (smena.Rows.Count > 0)
						{
							provera = true;
							zauzetiDani.Add(dtpOdD.Value.AddDays(i).ToShortDateString());
						}
					}

					if (!provera)
					{
						for (int i = 0; i <= razlika; i++)
						{
							s.Datum = dtpOdD.Value.AddDays(i).ToShortDateString();
							s.izborSmene = dbSmena.Text;

							s.dodajSmenu();
						}
						popuniKalendar();
					}
					else
					{
						if (zauzetiDani.Count == 1)
							customMessageBox.Show(s.izborSmene.First().ToString().ToUpper() + String.Join("", s.izborSmene.Skip(1)) + " smena " + zauzetiDani[0] + " je već zauzeta.");
						else
							customMessageBox.Show(s.izborSmene.First().ToString().ToUpper() + String.Join("", s.izborSmene.Skip(1)) + " smena od " + zauzetiDani[0] + "-" + zauzetiDani[zauzetiDani.Count - 1] + " je zauzeta.");
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		

		private void btnObrisiD_MouseClick(object sender, MouseEventArgs e)
		{
			try
			{
				if (imeRadnikaD.Text.ToString().Equals(""))
					customMessageBox.Show("Izaberite radnika!");
				else if (dtpOdD.Value > dtpDoD.Value)
					customMessageBox.Show("Krajnji datum ne sme biti pre početnog!");
				else
				{
					bool validacijaPrve = false;
					bool validacijaDruge = false;
					Smena s = new Smena();
					DataTable dt = new DataTable();
					dt = Direktor.selectRadnike();

					for (int i = 0; i < dt.Rows.Count; i++)
					{
						if (dt.Rows[i][3].ToString().Equals(imeRadnikaD.Text))
							s.ID = int.Parse(dt.Rows[i][10].ToString());
					}

					int razlika = dtpDoD.Value.Day - dtpOdD.Value.Day;
					if (razlika < 0) razlika += 31;

					for (int i = 0; i <= razlika; i++)
					{
						s.Datum = dtpOdD.Value.AddDays(i).ToShortDateString();
						s.izborSmene = "prva";

						DataTable provera = s.selectSmenu();
						if (provera.Rows.Count == 0 || s.ID != int.Parse(provera.Rows[0][2].ToString()))
							validacijaPrve = true;

						s.izborSmene = "druga";

						provera = s.selectSmenu();
						if (provera.Rows.Count == 0 || s.ID != int.Parse(provera.Rows[0][2].ToString())) validacijaDruge = true;
					}
					
					if(!(validacijaPrve & validacijaDruge))
					{
						for (int i = 0; i <= razlika; i++)
						{
							s.Datum = dtpOdD.Value.AddDays(i).ToShortDateString();

							s.izbrisiSmenu();
						}
					}
					else customMessageBox.Show("Ne možete obrisati smenu koja je prazna.");
					popuniKalendar();
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			
		}

		private void btnAzurirajD_MouseClick(object sender, MouseEventArgs e)
		{
			try
			{
				if (imeRadnikaD.Text.ToString().Equals("") && dbSmena.Text.ToString().Equals("Izaberite smenu"))
					customMessageBox.Show("Izaberite radnika i smenu!");
				else if (imeRadnikaD.Text.ToString().Equals(""))
					customMessageBox.Show("Izaberite radnika!");
				else if (dbSmena.Text.ToString().Equals("Izaberite smenu"))
					customMessageBox.Show("Izaberite smenu!");
				else if (dtpOdD.Value > dtpDoD.Value)
					customMessageBox.Show("Krajnji datum ne sme biti pre početnog!");
				else
				{
					bool validacija = false;
					Smena s = new Smena();
					DataTable dt = new DataTable();
					dt = Direktor.selectRadnike();

					for (int i = 0; i < dt.Rows.Count; i++)
					{
						if (dt.Rows[i][3].ToString().Equals(imeRadnikaD.Text))
							s.ID = int.Parse(dt.Rows[i][10].ToString());
					}

					int razlika = dtpDoD.Value.Day - dtpOdD.Value.Day;
					if (razlika < 0) razlika += 31;

					for (int i = 0; i <= razlika; i++)
					{
						s.Datum = dtpOdD.Value.AddDays(i).ToShortDateString();
						s.izborSmene = dbSmena.Text;

						DataTable provera = s.selectSmenu();
						if (provera.Rows.Count == 0) validacija = true;
					}

					if (!validacija)
					{
						for (int i = 0; i <= razlika; i++)
						{
							s.Datum = dtpOdD.Value.AddDays(i).ToShortDateString();
							s.izborSmene = dbSmena.Text;
							s.azurirajSmenu();
						}
					}
					else customMessageBox.Show("Ne možete ažurirati smenu koja je prazna.");
					popuniKalendar();
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			
		}

		private void Raspored_Load(object sender, EventArgs e)
		{

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
				lbPonPrva.Text = null;
				lbPonDruga.Text = null;
				lbUtoPrva.Text = null;
				lbUtoDruga.Text = null;
				lbSrePrva.Text = null;
				lbSreDruga.Text = null;
				lbCetPrva.Text = null;
				lbCetDruga.Text = null;
				lbPetPrva.Text = null;
				lbPetDruga.Text = null;
				lbSubPrva.Text = null;
				lbSubDruga.Text = null;
				DataTable radnici = Direktor.selectRadnike();
				DataTable smene = Smena.selectSmene();

				for (int i = 0; i < smene.Rows.Count; i++)
				{
					if (lbPon.Text.Equals(smene.Rows[i][0].ToString()))
					{
						for (int j = 0; j < radnici.Rows.Count; j++)
						{
							if (smene.Rows[i][2].ToString().Equals(radnici.Rows[j][10].ToString()) && smene.Rows[i][1].ToString().Equals("prva"))
							{
								lbPonPrva.Text = radnici.Rows[j][3].ToString();
							}
							else if (smene.Rows[i][2].ToString().Equals(radnici.Rows[j][10].ToString()) && smene.Rows[i][1].ToString().Equals("druga"))
							{
								lbPonDruga.Text = radnici.Rows[j][3].ToString();
							}
						}
					}

					if (lbUto.Text.Equals(smene.Rows[i][0].ToString()))
					{
						for (int j = 0; j < radnici.Rows.Count; j++)
						{
							if (smene.Rows[i][2].ToString().Equals(radnici.Rows[j][10].ToString()) && smene.Rows[i][1].ToString().Equals("prva"))
							{
								lbUtoPrva.Text = radnici.Rows[j][3].ToString();
							}
							else if (smene.Rows[i][2].ToString().Equals(radnici.Rows[j][10].ToString()) && smene.Rows[i][1].ToString().Equals("druga"))
							{
								lbUtoDruga.Text = radnici.Rows[j][3].ToString();
							}
						}
					}

					if (lbSre.Text.Equals(smene.Rows[i][0].ToString()))
					{
						for (int j = 0; j < radnici.Rows.Count; j++)
						{
							if (smene.Rows[i][2].ToString().Equals(radnici.Rows[j][10].ToString()) && smene.Rows[i][1].ToString().Equals("prva"))
							{
								lbSrePrva.Text = radnici.Rows[j][3].ToString();
							}
							else if (smene.Rows[i][2].ToString().Equals(radnici.Rows[j][10].ToString()) && smene.Rows[i][1].ToString().Equals("druga"))
							{
								lbSreDruga.Text = radnici.Rows[j][3].ToString();
							}
						}
					}

					if (lbCet.Text.Equals(smene.Rows[i][0].ToString()))
					{
						for (int j = 0; j < radnici.Rows.Count; j++)
						{
							if (smene.Rows[i][2].ToString().Equals(radnici.Rows[j][10].ToString()) && smene.Rows[i][1].ToString().Equals("prva"))
							{
								lbCetPrva.Text = radnici.Rows[j][3].ToString();
							}
							else if (smene.Rows[i][2].ToString().Equals(radnici.Rows[j][10].ToString()) && smene.Rows[i][1].ToString().Equals("druga"))
							{
								lbCetDruga.Text = radnici.Rows[j][3].ToString();
							}
						}
					}

					if (lbPet.Text.Equals(smene.Rows[i][0].ToString()))
					{
						for (int j = 0; j < radnici.Rows.Count; j++)
						{
							if (smene.Rows[i][2].ToString().Equals(radnici.Rows[j][10].ToString()) && smene.Rows[i][1].ToString().Equals("prva"))
							{
								lbPetPrva.Text = radnici.Rows[j][3].ToString();
							}
							else if (smene.Rows[i][2].ToString().Equals(radnici.Rows[j][10].ToString()) && smene.Rows[i][1].ToString().Equals("druga"))
							{
								lbPetDruga.Text = radnici.Rows[j][3].ToString();
							}
						}
					}

					if (lbSub.Text.Equals(smene.Rows[i][0].ToString()))
					{
						for (int j = 0; j < radnici.Rows.Count; j++)
						{
							if (smene.Rows[i][2].ToString().Equals(radnici.Rows[j][10].ToString()) && smene.Rows[i][1].ToString().Equals("prva"))
							{
								lbSubPrva.Text = radnici.Rows[j][3].ToString();
							}
							else if (smene.Rows[i][2].ToString().Equals(radnici.Rows[j][10].ToString()) && smene.Rows[i][1].ToString().Equals("druga"))
							{
								lbSubDruga.Text = radnici.Rows[j][3].ToString();
							}
						}
					}
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void panel16_Paint(object sender, PaintEventArgs e)
		{

		}

        private void imeRadnikaD_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s\b]");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void dbSmena_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s\b]");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }
    }
}

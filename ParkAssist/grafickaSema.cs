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
using System.Timers;
using System.Text.RegularExpressions;

namespace ParkAssist
{
    public partial class grafickaSema : UserControl
    {
		Radnik r = new Radnik();
        public grafickaSema()
        {
            InitializeComponent();
            cb15min.Appearance = Appearance.Button;
			cb15minAzuriraj.Appearance = Appearance.Button;
			cbSV.Appearance = Appearance.Button;
		}
		System.Timers.Timer t;
		int s;

		private void grafickaSema_Load(object sender, EventArgs e)
		{
			prikazVozila();
			popuniTabelu();
			t = new System.Timers.Timer();
			t.Interval = 1000;
			t.Elapsed += OnTimeEvent;
			t.Start();
		}

		private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btn1523_Click(object sender, EventArgs e)
        {
            hideH(1);
            panel20.BackColor = Color.SteelBlue;
        }

        private void tlp3_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void hideH(int n)
        {
            tlp1.Visible = false;
            tlp2.Visible = false;
            tlp3.Visible = false;
            tlp4.Visible = false;
            tlp5.Visible = false;
            tlp6.Visible = false;
            tlp7.Visible = false;
            tlp8.Visible = false;
            tlp9.Visible = false;
            pNotifikacija.Visible = false;
            panel18.Visible = false;
            panel19.Visible = false;
            panel20.Visible = false;
            panel22.Visible = false;
            panel23.Visible = false;
            panel24.Visible = false;
            panel16.Visible = false;
            panel17.Visible = false;
            panel25.Visible = false;
            panel14.Visible = false;
            panel15.Visible = false;
            panel26.Visible = false;
            panel27.Visible = false;
            panel28.Visible = false;
            panel33.Visible = false;
            panel29.Visible = false;
            panel30.Visible = false;
            panel34.Visible = false;
            panel31.Visible = false;
            panel32.Visible = false;
            panel35.Visible = false;
            btn914.Visible = false;
            btn38.Visible = false;
            btn12.Visible = false;
            btn1523.Visible = false;
            btn2432.Visible = false;
            btn3341.Visible = false;
            btn4250.Visible = false;

            if (n == 1)
            {
                tlp3.Visible = true;
                panel18.Visible = true;
                panel19.Visible = true;
                panel20.Visible = true;
                pVendettaD.Visible = true;
                pVendettaG.Visible = true;
                btnVx.Location = new Point(484, 307);
                btnVx.Visible = true;

            }

            if (n == 2)
            {
                tlp4.Visible = true;
                panel22.Visible = true;
                panel23.Visible = true;
                panel24.Visible = true;
                pVendettaD.Visible = true;
                pVendettaG.Visible = true;
                btnVx.Location = new Point(733, 307);
                btnVx.Visible = true;
            }

            if (n == 3)
            {
                tlp5.Visible = true;
                panel16.Visible = true;
                panel17.Visible = true;
                panel25.Visible = true;
                pVendettaD.Visible = true;
                pVendettaG.Visible = true;
                btnVx.Location = new Point(982, 307);
                btnVx.Visible = true;
            }

            if (n == 4)
            {
                tlp6.Visible = true;
                panel14.Visible = true;
                panel15.Visible = true;
                panel26.Visible = true;
                pVendettaD.Visible = true;
                pVendettaG.Visible = true;
                btnVx.Location = new Point(1230, 307);
                btnVx.Visible = true;
            }
        }

        private void hideV(int n)
        {
            tlp1.Visible = false;
            tlp2.Visible = false;
            tlp3.Visible = false;
            tlp4.Visible = false;
            tlp5.Visible = false;
            tlp6.Visible = false;
            pNotifikacija.Visible = false;
            panel18.Visible = false;
            panel19.Visible = false;
            panel20.Visible = false;
            panel22.Visible = false;
            panel23.Visible = false;
            panel24.Visible = false;
            panel16.Visible = false;
            panel17.Visible = false;
            panel25.Visible = false;
            panel14.Visible = false;
            panel15.Visible = false;
            panel26.Visible = false;
            panel27.Visible = false;
            panel28.Visible = false;
            panel33.Visible = false;
            panel29.Visible = false;
            panel30.Visible = false;
            panel34.Visible = false;
            panel31.Visible = false;
            panel32.Visible = false;
            panel35.Visible = false;
            btn914.Visible = false;
            btn38.Visible = false;
            btn12.Visible = false;
            btn1523.Visible = false;
            btn2432.Visible = false;
            btn3341.Visible = false;
            btn4250.Visible = false;

            if(n == 3)
            {
                tlp9.Visible = true;
                panel33.Visible = true;
                pVendettaVD.Visible = true;
                pVendettaVG.Visible = true;
                btnHx.Location = new Point(339, 349);
                btnHx.Visible = true;

                
            }

            if(n == 2)
            {
                tlp8.Visible = true;
                panel34.Visible = true;
                pVendettaVD.Visible = true;
                pVendettaVG.Visible = true;
                btnHx.Location = new Point(339, 597);
                btnHx.Visible = true;
            }

            if(n == 1)
            {
                tlp7.Visible = true;
                panel35.Visible = true;
                pVendetta2D.Visible = true;
                pVendetta2G.Visible = true;
                btnHx.Location = new Point(339, 781);
                btnHx.Visible = true;
            }
        }

        private void btnVx_Click(object sender, EventArgs e)
        {
            show();
            //btnVx.Visible = false;

        }

        public void show()
        {
			tbStranoVozilo.Visible = false;
			tbStranoVozilo.Text = "";
			cbSV.Checked = false;
			btnVx.Visible = false;
            btnHx.Visible = false;
            tlp1.Visible = true;
            tlp2.Visible = true;
            tlp3.Visible = false;
            tlp4.Visible = false;
            tlp5.Visible = false;
            tlp6.Visible = false;
            tlp7.Visible = false;
            tlp8.Visible = false;
            tlp9.Visible = false;
			popuniTabelu();
			pParkiraj.Visible = false;
            pParkiran.Visible = false;
            pVendettaD.Visible = false;
            pVendettaG.Visible = false;
            pVendettaVD.Visible = false;
            pVendettaVG.Visible = false;
            pVendetta2D.Visible = false;
            pVendetta2G.Visible = false;
            panel18.Visible = true;
            panel19.Visible = true;
            panel20.Visible = true;
            panel22.Visible = true;
            panel23.Visible = true;
            panel24.Visible = true;
            panel16.Visible = true;
            panel17.Visible = true;
            panel25.Visible = true;
            panel14.Visible = true;
            panel15.Visible = true;
            panel26.Visible = true;
            panel27.Visible = true;
            panel28.Visible = true;
            panel33.Visible = true;
            panel29.Visible = true;
            panel30.Visible = true;
            panel34.Visible = true;
            panel31.Visible = true;
            panel32.Visible = true;
            panel35.Visible = true;
            btn914.Visible = true;
            btn38.Visible = true;
            btn12.Visible = true;
            btn1523.Visible = true;
            btn2432.Visible = true;
            btn3341.Visible = true;
            btn4250.Visible = true;
        }

        private void btn2432_Click(object sender, EventArgs e)
        {
            hideH(2);
            panel24.BackColor = Color.SteelBlue;
        }

        private void btn3341_Click(object sender, EventArgs e)
        {
            hideH(3);
            panel25.BackColor = Color.SteelBlue;
        }

        private void btn4250_Click(object sender, EventArgs e)
        {
            hideH(4);
            panel26.BackColor = Color.SteelBlue;
        }

        private void btn12_Click(object sender, EventArgs e)
        {
            hideV(1);
            panel35.BackColor = Color.SteelBlue;
        }

        private void btn38_Click(object sender, EventArgs e)
        {
            hideV(2);
            panel34.BackColor = Color.SteelBlue;
        }

        private void btn914_Click(object sender, EventArgs e)
        {
            hideV(3);
            panel33.BackColor = Color.SteelBlue;
        }

        private void btnHx_Click(object sender, EventArgs e)
        {
            show();
            //btnHx.Visible = false;
        }

        private void btnP42_Click(object sender, EventArgs e)
        {
            parkiraj(42);
        }

		private void popuniAzurirajFormu(int reg)
		{
			try
			{
				tbGradAzuriraj.Enabled = true;
				tbBrojTablicaAzuriraj.Enabled = true;
				tbSlovaTabliceAzuriraj.Enabled = true;
				btnAzuriraj.Enabled = true;

				KartaNotifikacijaAzuriraj.Visible = false;
				tbParkingMestoAzuriraj.Text = reg.ToString();
				stilizovanjeFormeZaKaznu(reg);
				lbVremeAzuriraj.Left = 7;
				lbVremeAzuriraj.Top = 213;
				lbVremeAzuriraj.Text = "Vreme (vozilo ostaje do ";

				Vozilo v = new Vozilo();
				v.ParkingMesto = int.Parse(tbParkingMestoAzuriraj.Text);
				DataTable popuniFormu = v.selectVozilo();
				v.Vreme = popuniFormu.Rows[0][2].ToString();
				v.Dan = popuniFormu.Rows[0][4].ToString();
				v.Stanje = popuniFormu.Rows[0][3].ToString();
				string tablica = popuniFormu.Rows[0][1].ToString();

				if (v.Stanje.Contains("strano"))
				{
					tbStranoVoziloAzuriraj.Visible = true;
					tbStranoVoziloAzuriraj.Text = tablica;
				}
				else
				{
					tbStranoVoziloAzuriraj.Visible = false;
					tbGradAzuriraj.Text = tablica[0].ToString() + tablica[1].ToString();
					tbBrojTablicaAzuriraj.Text = string.Concat(tablica[3].ToString(), tablica[4].ToString(), tablica[5].ToString());
					tbSlovaTabliceAzuriraj.Text = string.Concat(tablica[7].ToString(), tablica[8].ToString());
				}
				

				DataTable karta = Karta.selectKarteZaProveru(tablica);

				string trenutnoVreme = DateTime.Now.ToShortTimeString();
				int trVrMin = int.Parse(trenutnoVreme[0].ToString() + trenutnoVreme[1].ToString()) * 60 + int.Parse(trenutnoVreme[3].ToString() + trenutnoVreme[4].ToString());
				string pom = v.Vreme;
				if (pom != "")
				{
					int VrVoz = int.Parse(pom[0].ToString() + pom[1].ToString()) * 60 + int.Parse(pom[3].ToString() + pom[4].ToString());
					int razlika = VrVoz - trVrMin;
					pom = razlika.ToString();
				}

				lbVremeAzuriraj.Text += v.Vreme + ")";

				if (karta.Rows.Count > 0)
				{
					if (validacijaKarte(v.ParkingMesto))
					{
						KartaNotifikacijaAzuriraj.Text = "Korisnik ";
						if (karta.Rows[0][2].ToString() == "mesečna")
							KartaNotifikacijaAzuriraj.Text += "mesečne karte.";
						else if (karta.Rows[0][2].ToString() == "godišnja")
							KartaNotifikacijaAzuriraj.Text += "godišnje karte.";
						KartaNotifikacijaAzuriraj.AppendText(Environment.NewLine);
						KartaNotifikacijaAzuriraj.Text += "Vlasnik: " + karta.Rows[0][0].ToString();
						KartaNotifikacijaAzuriraj.Visible = true;

						tbGradAzuriraj.Enabled = false;
						tbBrojTablicaAzuriraj.Enabled = false;
						tbSlovaTabliceAzuriraj.Enabled = false;

						btnAzuriraj.Enabled = false;
					}
					else if (!validacijaKarte(v.ParkingMesto) && v.Vreme == "")
					{
						lbVremeAzuriraj.Top -= 13;
						if (karta.Rows[0][2].ToString() == "mesečna")
							lbVremeAzuriraj.Text = "Mesečna";
						else if (karta.Rows[0][2].ToString() == "godišnja")
							lbVremeAzuriraj.Text = "Godišnja";
						lbVremeAzuriraj.Text += " karta je istekla.";
						lbVremeAzuriraj.Text += Environment.NewLine + "Vlasnik: " + karta.Rows[0][0].ToString();

						tbGradAzuriraj.Enabled = false;
						tbBrojTablicaAzuriraj.Enabled = false;
						tbSlovaTabliceAzuriraj.Enabled = false;
					}
				}
				else if (v.Dan != DateTime.Now.ToShortDateString())
				{
					lbVremeAzuriraj.Text = "Vreme isteklo " + v.Dan + " u " + v.Vreme;
				}
				else if (int.Parse(pom) < 0)
				{
					lbVremeAzuriraj.Text = "Vreme isteklo u " + v.Vreme;
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void stilizovanjeFormeZaKaznu(int pm)
		{
			try
			{
				var lista = new List<Button> { btnP1, btnP2, btnP3, btnP4, btnP5, btnP6, btnP7, btnP8, btnP9, btnP10, btnP11, btnP12, btnP13, btnP14, btnP15, btnP16, btnP17, btnP18, btnP19, btnP20, btnP21, btnP22, btnP23, btnP24, btnP25, btnP26, btnP27, btnP28, btnP29, btnP30, btnP31, btnP32, btnP33, btnP34, btnP35, btnP36, btnP37, btnP38, btnP39, btnP40, btnP41, btnP42, btnP43, btnP44, btnP45, btnP46, btnP47, btnP48, btnP49, btnP50 };

				foreach (Button b in lista)
				{
					if (b.Name == "btnP" + pm.ToString() && (uporediSlike(b.Image, Image.FromFile("crveniHorizontalni.png")) || uporediSlike(b.Image, Image.FromFile("crveniVertikalni.png"))))
					{
						pParkiranG.Size = new Size(368, 468);
						pKvadratic.Location = new Point(0, 468);
						pParkiran.Size = new Size(382, 482);
						//ovde ide da dugme kazni bude tu
					}
					else if (b.Name == "btnP" + pm.ToString() && !(uporediSlike(b.Image, Image.FromFile("crveniHorizontalni.png")) || uporediSlike(b.Image, Image.FromFile("crveniVertikalni.png"))))
					{
						pParkiranG.Size = new Size(368, 388);
						pKvadratic.Location = new Point(0, 388);
						pParkiran.Size = new Size(382, 402);
						//ovde ide kod kad dugme treba da se sakrije
					}
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

        private void parkiraj(int reg)
        {
			try
			{
				if (!proveraRadnogVremena())
				{
					cb15min.Enabled = false;
					cb15minAzuriraj.Enabled = false;
					tbVreme.Enabled = false;
					tbVremeAzuriraj.Enabled = false;
				}
				else
				{
					cb15min.Enabled = true;
					cb15minAzuriraj.Enabled = true;
					tbVreme.Enabled = true;
					tbVremeAzuriraj.Enabled = true;
				}
				Console.WriteLine(cb15min.Enabled);
				tbVreme.Items.Clear();
				tbVremeAzuriraj.Items.Clear();
				tbStranoVozilo.Text = "";
				tbGrad.Text = "NP";
				tbBrojTablica.Text = "000";
				tbSlovaTablice.Text = "AA";
				KartaNotifikacija.Visible = false;
				btnPUnesi.Enabled = true;
				Image slika = Image.FromFile("dodaj.png");
				var lista = new List<Button> { btnP1, btnP2, btnP3, btnP4, btnP5, btnP6, btnP7, btnP8, btnP9, btnP10, btnP11, btnP12, btnP13, btnP14, btnP15, btnP16, btnP17, btnP18, btnP19, btnP20, btnP21, btnP22, btnP23, btnP24, btnP25, btnP26, btnP27, btnP28, btnP29, btnP30, btnP31, btnP32, btnP33, btnP34, btnP35, btnP36, btnP37, btnP38, btnP39, btnP40, btnP41, btnP42, btnP43, btnP44, btnP45, btnP46, btnP47, btnP48, btnP49, btnP50 };

				foreach (Button b in lista)
				{
					if (b.Name == "btnP" + reg.ToString())
					{
						if (uporediSlike(slika, b.Image))
						{
							if (reg > 14) pParkiraj.Location = new Point(98, 357);
							else pParkiraj.Location = new Point(468, 371);
							pParkiran.Visible = false;
							pParkiraj.Visible = true;

							if (itemiZaVreme() != 0)
							{
								for (int i = 1; i <= itemiZaVreme(); i++)
									tbVreme.Items.Add(i);
							}
							tbParkingMesto.Text = reg.ToString();
						}
						else
						{
							popuniAzurirajFormu(reg);

							if (reg > 14) pParkiran.Location = new Point(98, 357);
							else pParkiran.Location = new Point(468, 371);

							if (itemiZaVreme() != 0)
							{
								for (int i = 1; i <= itemiZaVreme(); i++)
									tbVremeAzuriraj.Items.Add(i);
							}
							pParkiran.Visible = true;
                            pParkiraj.Visible = false;
						}
					}

				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

        private void btnPUnesi_Click(object sender, EventArgs e)
        {
			try
			{
				if (string.IsNullOrEmpty(tbVreme.Text) && cb15min.Checked == false && KartaNotifikacija.Visible == false)
					customMessageBox.Show("Izaberite vreme!");
				else if (tbStranoVozilo.Visible == false && KartaNotifikacija.Visible == false && ((tbGrad.Text.Equals("NP") && tbBrojTablica.Text.Equals("000") && tbSlovaTablice.Text.Equals("AA")) || (string.IsNullOrEmpty(tbGrad.Text) || string.IsNullOrEmpty(tbBrojTablica.Text) || string.IsNullOrEmpty(tbSlovaTablice.Text))))
					customMessageBox.Show("Unesite registracioni broj tablica vozila!");
				else if(tbStranoVozilo.Visible == true && tbStranoVozilo.Text == "")
					customMessageBox.Show("Unesite registracioni broj tablica vozila!");
				else
				{
					Vozilo v = new Vozilo();
					v.ParkingMesto = int.Parse(tbParkingMesto.Text);
					if (cbSV.Checked)
					{
						tbStranoVozilo.Visible = true;
						v.RegistracioniBrojTablica = tbStranoVozilo.Text;
					}
					else
					{
						tbStranoVozilo.Visible = false;
						v.RegistracioniBrojTablica = tbGrad.Text + "-" + tbBrojTablica.Text + "-" + tbSlovaTablice.Text;
					}
						if (cb15min.Checked)
					{
						v.Vreme = DateTime.Now.AddMinutes(15).ToShortTimeString();
						if (tbStranoVozilo.Visible == true)
							v.Stanje = "privremeno/strano";
						else
						v.Stanje = "privremeno";
						v.Dan = DateTime.Now.ToShortDateString();
						v.unesiVozilo();
					}
					else if (KartaNotifikacija.Visible == false)
					{
						if (tbVreme.Text != "")
							v.Vreme = DateTime.Now.AddHours(int.Parse(tbVreme.Text)).ToShortTimeString();
						v.Dan = DateTime.Now.ToShortDateString();
						if (tbStranoVozilo.Visible == true)
							v.Stanje = "strano";
						v.unesiVozilo();

						Statistika s = new Statistika();
						s.Mesec = DateTime.Now.Month.ToString();
						s.Godina = DateTime.Now.Year.ToString();
						DataTable dt = s.selectStatistika();
						if (dt.Rows.Count != 0)
						{
							s.Prihod = int.Parse(dt.Rows[0][3].ToString()) + int.Parse(tbVreme.Text) * 30;
							s.unosSatiStatistika();
						}
						else
						{
							s.Prihod = int.Parse(tbVreme.Text) * 30;
							s.kreiranjeMeseca();
						}
					}
					else
					{
						v.Stanje = "pretplatnik";
						v.unesiVozilo();
					}
					cb15min.Checked = false;
					pParkiraj.Visible = false;
					tbStranoVozilo.Visible = false;
					tbStranoVozilo.Text = "";
					cbSV.Checked = false;
					prikazVozila();
					popuniTabelu();
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

        private void btnPOdustani_Click(object sender, EventArgs e)
        {
			cb15min.Checked = false;
            pParkiraj.Visible = false;
			tbStranoVozilo.Visible = false;
			tbStranoVozilo.Text = "";
			cbSV.Checked = false;
        }

		private void btnAzuriraj_Click(object sender, EventArgs e)
		{
			try
			{
				if (string.IsNullOrEmpty(tbVremeAzuriraj.Text) && cb15minAzuriraj.Checked == false && KartaNotifikacijaAzuriraj.Visible == false) 
					customMessageBox.Show("Izaberite vreme!");
				else if (tbStranoVoziloAzuriraj.Visible == false && KartaNotifikacijaAzuriraj.Visible == false && (tbGradAzuriraj.Text.Equals("NP") && tbBrojTablicaAzuriraj.Text.Equals("000") && tbSlovaTabliceAzuriraj.Text.Equals("AA")) || (string.IsNullOrEmpty(tbGradAzuriraj.Text) || string.IsNullOrEmpty(tbBrojTablicaAzuriraj.Text) || string.IsNullOrEmpty(tbSlovaTabliceAzuriraj.Text)))
					customMessageBox.Show("Unesite registracioni broj tablica vozila!");
				else if (tbStranoVoziloAzuriraj.Visible == true && tbStranoVoziloAzuriraj.Text == "")
					customMessageBox.Show("Unesite registracioni broj tablica vozila!");
				else
				{
					Vozilo v = new Vozilo();
					v.ParkingMesto = int.Parse(tbParkingMestoAzuriraj.Text);
					if (tbStranoVoziloAzuriraj.Visible == true)
						v.RegistracioniBrojTablica = tbStranoVoziloAzuriraj.Text;
					else
					v.RegistracioniBrojTablica = tbGradAzuriraj.Text + "-" + tbBrojTablicaAzuriraj.Text + "-" + tbSlovaTabliceAzuriraj.Text;
					if (cb15minAzuriraj.Checked)
					{
						v.Vreme = DateTime.Now.AddMinutes(15).ToShortTimeString();
						if (tbStranoVoziloAzuriraj.Visible == true)
							v.Stanje = "privremeno/strano";
						else
						v.Stanje = "privremeno";
						v.Dan = DateTime.Now.ToShortDateString();
						v.azurirajVozilo();
						popuniAzurirajFormu(v.ParkingMesto);
					}
					else
					{
						v.Vreme = DateTime.Now.AddHours(int.Parse(tbVremeAzuriraj.Text)).ToShortTimeString();
						if (tbStranoVoziloAzuriraj.Visible == true)
							v.Stanje = "strano";
						else v.Stanje = "";
						v.Dan = DateTime.Now.ToShortDateString();
						v.azurirajVozilo();
						popuniAzurirajFormu(v.ParkingMesto);

						Statistika s = new Statistika();
						s.Mesec = DateTime.Now.Month.ToString();
						s.Godina = DateTime.Now.Year.ToString();
						DataTable dt = s.selectStatistika();
						if (dt.Rows.Count != 0)
						{
							s.Prihod = int.Parse(dt.Rows[0][3].ToString()) + int.Parse(tbVremeAzuriraj.Text) * 30;
							s.unosSatiStatistika();
						}
						else
						{
							s.Prihod = int.Parse(tbVremeAzuriraj.Text) * 30;
							s.kreiranjeMeseca();
						}
					}
					popuniAzurirajFormu(v.ParkingMesto);
					prikazVozila();
					popuniTabelu();
					pParkiran.Visible = false;
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void btnObrisi_Click(object sender, EventArgs e)
		{
			try
			{
				Vozilo v = new Vozilo();
				v.ParkingMesto = int.Parse(tbParkingMestoAzuriraj.Text);
				v.obrisiVozilo();
				prikazVozila();
				panelPom.Controls.Clear();
				pParkiran.Visible = false;
				prikazVozila();
				popuniTabelu();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void btnP2Odustani_MouseClick(object sender, MouseEventArgs e)
		{
            pParkiran.Visible = false;
            pParkiraj.Visible = false;
		}

		private void btnObrisiSve_Click(object sender, EventArgs e)
		{
			try
			{
				Vozilo v = new Vozilo();

				for (int i = 1; i <= 50; i++)
				{
					v.ParkingMesto = i;
					v.obrisiVozilo();
				}
				prikazVozila();
				popuniTabelu();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			
		}
		
	private int itemiZaVreme()
		{
			int trSati = DateTime.Now.Hour;
			if(21 - trSati > 0)
			return 21 - trSati;

			return 0;
		}

		private bool proveraRadnogVremena()
		{
			switch(DateTime.Now.Hour)
			{
				case 21: return false;
				case 22: return false;
				case 23: return false;
				case 0:  return false;
				case 1:  return false;
				case 2:  return false;
				case 3:  return false;
				case 4:  return false;
				case 5:	 return false;
				case 6:  return false;
				default: return true;
			}

		}
		private void btnP2Odustani_Click(object sender, EventArgs e)
		{
			//pParkiran.Visible = false;
            //pParkiraj.Visible = false;
		}

		private void btnP1_Click(object sender, EventArgs e)
        {
            parkiraj(1);
        }

        private void btnP2_Click(object sender, EventArgs e)
        {
            parkiraj(2);
        }

        private void btnP3_Click_1(object sender, EventArgs e)
        {
            parkiraj(3);
        }

        private void btnP4_Click_1(object sender, EventArgs e)
        {
            parkiraj(4);

        }

        private void btnP5_Click_1(object sender, EventArgs e)
        {
            parkiraj(5);
        }

        private void btnP6_Click_1(object sender, EventArgs e)
        {
            parkiraj(6);
        }

        private void btnP7_Click_1(object sender, EventArgs e)
        {
            parkiraj(7);
        }

        private void btnP8_Click_1(object sender, EventArgs e)
        {
            parkiraj(8);
        }

        private void btnP9_Click_1(object sender, EventArgs e)
        {
            parkiraj(9);

        }

        private void btnP10_Click_1(object sender, EventArgs e)
        {
            parkiraj(10);
        }

        private void btnP11_Click_1(object sender, EventArgs e)
        {
            parkiraj(11);
        }

        private void btnP12_Click_1(object sender, EventArgs e)
        {
            parkiraj(12);
        }

        private void btnP13_Click_1(object sender, EventArgs e)
        {
            parkiraj(13);
        }

        private void btnP14_Click_1(object sender, EventArgs e)
        {
            parkiraj(14);
        }

        private void btnP15_Click_1(object sender, EventArgs e)
        {
            parkiraj(15);
        }

        private void btnP16_Click_1(object sender, EventArgs e)
        {
            parkiraj(16);
        }

        private void btnP17_Click_1(object sender, EventArgs e)
        {
            parkiraj(17);
        }

        private void btnP18_Click_1(object sender, EventArgs e)
        {
            parkiraj(18);
        }

        private void btnP19_Click_1(object sender, EventArgs e)
        {
            parkiraj(19);
        }

        private void btnP20_Click_1(object sender, EventArgs e)
        {
            parkiraj(20);
        }

        private void btnP21_Click_1(object sender, EventArgs e)
        {
            parkiraj(21);
        }

        private void btnP22_Click_1(object sender, EventArgs e)
        {
            parkiraj(22);
        }

        private void btnP23_Click_1(object sender, EventArgs e)
        {
            parkiraj(23);
        }

        private void btnP24_Click_1(object sender, EventArgs e)
        {
            parkiraj(24);
        }

        private void btnP25_Click_1(object sender, EventArgs e)
        {
            parkiraj(25);
        }

        private void btnP26_Click_1(object sender, EventArgs e)
        {
            parkiraj(26);
        }

        private void btnP27_Click_1(object sender, EventArgs e)
        {
            parkiraj(27);
        }

        private void btnP28_Click_1(object sender, EventArgs e)
        {
            parkiraj(28);
        }

        private void btnP29_Click_1(object sender, EventArgs e)
        {
            parkiraj(29);
        }

        private void btnP30_Click_1(object sender, EventArgs e)
        {
            parkiraj(30);
        }

        private void btnP31_Click_1(object sender, EventArgs e)
        {
            parkiraj(31);
        }

        private void btnP32_Click_1(object sender, EventArgs e)
        {
            parkiraj(32);
        }

        private void btnP33_Click_1(object sender, EventArgs e)
        {
            parkiraj(33);
        }

        private void btnP34_Click_1(object sender, EventArgs e)
        {
            parkiraj(34);
        }

        private void btnP35_Click_1(object sender, EventArgs e)
        {
            parkiraj(35);
        }

        private void btnP36_Click_1(object sender, EventArgs e)
        {
            parkiraj(36);
        }

        private void btnP37_Click_1(object sender, EventArgs e)
        {
            parkiraj(37);
        }

        private void btnP38_Click_1(object sender, EventArgs e)
        {
            parkiraj(38);
        }

        private void btnP39_Click_1(object sender, EventArgs e)
        {
            parkiraj(39);
        }

        private void btnP40_Click_1(object sender, EventArgs e)
        {
            parkiraj(40);
        }

        private void btnP41_Click_1(object sender, EventArgs e)
        {
            parkiraj(41);
        }

        private void btnP43_Click_1(object sender, EventArgs e)
        {
            parkiraj(43);
        }

        private void btnP44_Click_1(object sender, EventArgs e)
        {
            parkiraj(44);
        }

        private void btnP45_Click_1(object sender, EventArgs e)
        {
            parkiraj(45);
        }

        private void btnP46_Click_1(object sender, EventArgs e)
        {
            parkiraj(46);
        }

        private void btnP47_Click_1(object sender, EventArgs e)
        {
            parkiraj(47);
        }

        private void btnP48_Click_1(object sender, EventArgs e)
        {
            parkiraj(48);
        }

        private void btnP49_Click_1(object sender, EventArgs e)
        {
            parkiraj(49);
        }

        private void btnP50_Click_1(object sender, EventArgs e)
        {
            parkiraj(50);
        }

		public void popuniTabelu()
		{
			try
			{
				lbJT.Text = "";
				lbDT.Text = "";
				lbTT.Text = "";
				lbCT.Text = "";
				lbPT.Text = "";
				DataTable vozila = Vozilo.selectParking();
				for (int i = 0; i < vozila.Rows.Count; i++)
				{
					string trenutnoVreme = DateTime.Now.ToShortTimeString();
					int trVrMin = int.Parse(trenutnoVreme[0].ToString() + trenutnoVreme[1].ToString()) * 60 + int.Parse(trenutnoVreme[3].ToString() + trenutnoVreme[4].ToString());
					if (vozila.Rows[i][3].ToString() == "pretplatnik" && validacijaKarte(i + 1) == false)
					{
						vozila.Rows[i][2] = "-1000";
					}

					else if (!vozila.Rows[i][4].ToString().Equals(DateTime.Now.ToShortDateString()) && vozila.Rows[i][2].ToString() != "")
					{
						vozila.Rows[i][2] = "-950";
					}

					else if (vozila.Rows[i][2].ToString() != "")
					{
						string pom = vozila.Rows[i][2].ToString();
						int VrVoz = int.Parse(pom[0].ToString() + pom[1].ToString()) * 60 + int.Parse(pom[3].ToString() + pom[4].ToString());
						int razlika = VrVoz - trVrMin;
						vozila.Rows[i][2] = razlika.ToString();
					}
				}
				for (int i = 0; i < vozila.Rows.Count - 1; i++)
				{
					if (vozila.Rows[i][2].ToString() != "")
					{
						for (int j = i + 1; j < vozila.Rows.Count; j++)
						{
							if (vozila.Rows[j][2].ToString() != "")
							{
								if (int.Parse(vozila.Rows[j][2].ToString()) < int.Parse(vozila.Rows[i][2].ToString()))
								{
									DataTable pom = new DataTable();
									pom.Rows.Add();
									pom.Columns.Add();
									pom.Columns.Add();
									pom.Columns.Add();
									pom.Rows[0][0] = vozila.Rows[i][0];
									pom.Rows[0][1] = vozila.Rows[i][1];
									pom.Rows[0][2] = vozila.Rows[i][2];
									for (int k = 0; k < 3; k++)
									{
										vozila.Rows[i][k] = vozila.Rows[j][k];
										vozila.Rows[j][k] = pom.Rows[0][k];
									}
								}
							}

						}
					}

				}
				Vozilo[] niz = new Vozilo[5];
				niz[0] = new Vozilo();
				niz[1] = new Vozilo();
				niz[2] = new Vozilo();
				niz[3] = new Vozilo();
				niz[4] = new Vozilo();
				int p = 0;
				for (int i = 0; i < vozila.Rows.Count; i++)
				{
					if (p == 5)
						break;
					if (!string.IsNullOrEmpty(vozila.Rows[i][2].ToString()))
					{
						niz[p] = new Vozilo();
						niz[p].ParkingMesto = int.Parse(vozila.Rows[i][0].ToString());
						niz[p].RegistracioniBrojTablica = vozila.Rows[i][1].ToString();
						niz[p].Vreme = vozila.Rows[i][2].ToString();
						p++;
					}
				}

				if (niz[0].Vreme != "" && int.Parse(niz[0].Vreme) <= 0)
				{
					pJJ.BackColor = Color.Red;
					pJD.BackColor = Color.Red;
					pJT.BackColor = Color.Red;

					lbJJ.ForeColor = Color.FromArgb(30, 30, 30);
					lbJD.ForeColor = Color.FromArgb(30, 30, 30);
					lbJT.ForeColor = Color.FromArgb(30, 30, 30);
					lbJT.Text = "0 min";
				}
				else
				{
					pJJ.BackColor = Color.FromArgb(60, 60, 60);
					pJD.BackColor = Color.FromArgb(60, 60, 60);
					pJT.BackColor = Color.FromArgb(60, 60, 60);

					lbJJ.ForeColor = Color.FromArgb(224, 224, 224);
					lbJD.ForeColor = Color.FromArgb(224, 224, 224);
					lbJT.ForeColor = Color.FromArgb(224, 224, 224);

					if (niz[0].Vreme != "")
						lbJT.Text = minutUvreme(int.Parse(niz[0].Vreme));
				}
				lbJJ.Text = niz[0].ParkingMesto.ToString();
				lbJD.Text = niz[0].RegistracioniBrojTablica;


				if (niz[1].Vreme != "" && int.Parse(niz[1].Vreme) <= 0)
				{
					pDJ.BackColor = Color.Red;
					pDD.BackColor = Color.Red;
					pDT.BackColor = Color.Red;

					lbDJ.ForeColor = Color.FromArgb(30, 30, 30);
					lbDD.ForeColor = Color.FromArgb(30, 30, 30);
					lbDT.ForeColor = Color.FromArgb(30, 30, 30);
					lbDT.Text = "0 min";
				}
				else
				{
					pDJ.BackColor = Color.FromArgb(60, 60, 60);
					pDD.BackColor = Color.FromArgb(60, 60, 60);
					pDT.BackColor = Color.FromArgb(60, 60, 60);

					lbDJ.ForeColor = Color.FromArgb(224, 224, 224);
					lbDD.ForeColor = Color.FromArgb(224, 224, 224);
					lbDT.ForeColor = Color.FromArgb(224, 224, 224);

					if (niz[1].Vreme != "")
						lbDT.Text = minutUvreme(int.Parse(niz[1].Vreme));
				}
				lbDJ.Text = niz[1].ParkingMesto.ToString();
				lbDD.Text = niz[1].RegistracioniBrojTablica;

				if (niz[2].Vreme != "" && int.Parse(niz[2].Vreme) <= 0)
				{
					pTJ.BackColor = Color.Red;
					pTD.BackColor = Color.Red;
					pTT.BackColor = Color.Red;

					lbTJ.ForeColor = Color.FromArgb(30, 30, 30);
					lbTD.ForeColor = Color.FromArgb(30, 30, 30);
					lbTT.ForeColor = Color.FromArgb(30, 30, 30);
					lbTT.Text = "0 min";
				}
				else
				{
					pTJ.BackColor = Color.FromArgb(60, 60, 60);
					pTD.BackColor = Color.FromArgb(60, 60, 60);
					pTT.BackColor = Color.FromArgb(60, 60, 60);

					lbTJ.ForeColor = Color.FromArgb(224, 224, 224);
					lbTD.ForeColor = Color.FromArgb(224, 224, 224);
					lbTT.ForeColor = Color.FromArgb(224, 224, 224);

					if (niz[2].Vreme != "")
						lbTT.Text = minutUvreme(int.Parse(niz[2].Vreme));
				}
				lbTJ.Text = niz[2].ParkingMesto.ToString();
				lbTD.Text = niz[2].RegistracioniBrojTablica;

				if (niz[3].Vreme != "" && int.Parse(niz[3].Vreme) <= 0)
				{
					pCJ.BackColor = Color.Red;
					pCD.BackColor = Color.Red;
					pCT.BackColor = Color.Red;

					lbCJ.ForeColor = Color.FromArgb(30, 30, 30);
					lbCD.ForeColor = Color.FromArgb(30, 30, 30);
					lbCT.ForeColor = Color.FromArgb(30, 30, 30);
					lbCT.Text = "0 min";
				}
				else
				{
					pCJ.BackColor = Color.FromArgb(60, 60, 60);
					pCD.BackColor = Color.FromArgb(60, 60, 60);
					pCT.BackColor = Color.FromArgb(60, 60, 60);

					lbCJ.ForeColor = Color.FromArgb(224, 224, 224);
					lbCD.ForeColor = Color.FromArgb(224, 224, 224);
					lbCT.ForeColor = Color.FromArgb(224, 224, 224);

					if (niz[3].Vreme != "")
						lbCT.Text = minutUvreme(int.Parse(niz[3].Vreme));
				}
				lbCJ.Text = niz[3].ParkingMesto.ToString();
				lbCD.Text = niz[3].RegistracioniBrojTablica;

				if (niz[4].Vreme != "" && int.Parse(niz[4].Vreme) <= 0)
				{
					pPJ.BackColor = Color.Red;
					pPD.BackColor = Color.Red;
					pPT.BackColor = Color.Red;

					lbPJ.ForeColor = Color.FromArgb(30, 30, 30);
					lbPD.ForeColor = Color.FromArgb(30, 30, 30);
					lbPT.ForeColor = Color.FromArgb(30, 30, 30);
					lbPT.Text = "0 min";
				}
				else
				{
					pPJ.BackColor = Color.FromArgb(60, 60, 60);
					pPD.BackColor = Color.FromArgb(60, 60, 60);
					pPT.BackColor = Color.FromArgb(60, 60, 60);

					lbPJ.ForeColor = Color.FromArgb(224, 224, 224);
					lbPD.ForeColor = Color.FromArgb(224, 224, 224);
					lbPT.ForeColor = Color.FromArgb(224, 224, 224);

					if (niz[4].Vreme != "")
						lbPT.Text = minutUvreme(int.Parse(niz[4].Vreme));
				}
				lbPJ.Text = niz[4].ParkingMesto.ToString();
				lbPD.Text = niz[4].RegistracioniBrojTablica;

				Vozilo[] v = new Vozilo[3];
				int count = 0;
				if (lbJJ.BackColor == Color.Red)
				{
					v[0] = new Vozilo(int.Parse(lbJJ.Text), lbJD.Text, "", "", "");
					count++;
				}
				if (lbDJ.BackColor == Color.Red)
				{
					v[1] = new Vozilo(int.Parse(lbDJ.Text), lbDD.Text, "", "", "");
					count++;
				}
				if (lbTJ.BackColor == Color.Red)
				{
					v[2] = new Vozilo(int.Parse(lbTJ.Text), lbTD.Text, "", "", "");
					count++;
				}
				notifikacije(count, v);
                postaviBoje();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		private void notifikacije(int count, Vozilo[] pom)
		{
			try
			{
				if (count == 0 || btnVx.Visible == true || btnHx.Visible == true)
					pNotifikacija.Visible = false;
				else pNotifikacija.Visible = true;
				panelPom.Controls.Clear();
				pNotifikacija.Height = 39 + count * 35;
				Panel[] paneli = new Panel[count];
				Label[] tablica = new Label[count];
				Panel[] granicnici = new Panel[count];
				Label[] pmesto = new Label[count];

				for (int i = 0; i < count; i++)
				{
					paneli[i] = new Panel();
					panelPom.Controls.Add(paneli[i]);
					paneli[i].Width = 225;
					paneli[i].Height = 29;
					paneli[i].Left = 33;
					paneli[i].Top = 5 + i * 35;
					paneli[i].BackColor = Color.Red;

					paneli[i].Controls.Clear();

					tablica[i] = new Label();
					paneli[i].Controls.Add(tablica[i]);
					tablica[i].Width = 125;
					tablica[i].Height = 29;
					tablica[i].Left = 35;
					tablica[i].Top = 2;
					tablica[i].Font = new Font("Microsoft Sans Serif", 14);
					tablica[i].ForeColor = Color.FromArgb(30, 30, 30);
					tablica[i].Text = pom[i].RegistracioniBrojTablica.ToString();

					granicnici[i] = new Panel();
					paneli[i].Controls.Add(granicnici[i]);
					granicnici[i].Width = 2;
					granicnici[i].Height = 25;
					granicnici[i].Left = 175;
					granicnici[i].Top = 2;
					granicnici[i].BackColor = Color.Black;

					pmesto[i] = new Label();
					paneli[i].Controls.Add(pmesto[i]);
					pmesto[i].Width = 45;
					pmesto[i].Height = 29;
					pmesto[i].Left = 179;
					pmesto[i].Top = 2;
					pmesto[i].Font = new Font("Microsoft Sans Serif", 14);
					pmesto[i].ForeColor = Color.FromArgb(30, 30, 30);
					pmesto[i].Text = "P" + pom[i].ParkingMesto.ToString();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private string minutUvreme(int vreme)
		{
			if (vreme <= 0) return 0.ToString();
			else if (vreme < 60)
				return vreme.ToString() + " min";
			else
			{
				int sati = vreme / 60;
				int minuti = vreme % (60 * sati);
				return sati.ToString() + "h " + minuti.ToString() + " min";
			}
		}

		public void prikazVozila()
		{
			try
			{
				Console.WriteLine(DateTime.Now.Year.ToString());
				DataTable vozila = Vozilo.selectParking();
				var lista = new List<Button> { btnP1, btnP2, btnP3, btnP4, btnP5, btnP6, btnP7, btnP8, btnP9, btnP10, btnP11, btnP12, btnP13, btnP14, btnP15, btnP16, btnP17, btnP18, btnP19, btnP20, btnP21, btnP22, btnP23, btnP24, btnP25, btnP26, btnP27, btnP28, btnP29, btnP30, btnP31, btnP32, btnP33, btnP34, btnP35, btnP36, btnP37, btnP38, btnP39, btnP40, btnP41, btnP42, btnP43, btnP44, btnP45, btnP46, btnP47, btnP48, btnP49, btnP50 };
				int i = 0;
				foreach (Button b in lista)
				{
					string ime = "btnP" + (i + 1).ToString();
					if (!string.IsNullOrEmpty(vozila.Rows[i][2].ToString()))
					{
						string trenutnoVreme = DateTime.Now.ToShortTimeString();
						int trVrMin = int.Parse(trenutnoVreme[0].ToString() + trenutnoVreme[1].ToString()) * 60 + int.Parse(trenutnoVreme[3].ToString() + trenutnoVreme[4].ToString());
						string pom = vozila.Rows[i][2].ToString();
						int VrVoz = int.Parse(pom[0].ToString() + pom[1].ToString()) * 60 + int.Parse(pom[3].ToString() + pom[4].ToString());
						int razlika = VrVoz - trVrMin; // odredjuje razliku izmedju vremena vozila i trenutnog vremena

						if (razlika > 0 && razlika <= 15 && (vozila.Rows[i][3].ToString() == "privremeno" || vozila.Rows[i][3].ToString() == "privremeno/strano") && vozila.Rows[i][4].ToString() == DateTime.Now.ToShortDateString())
						{
							if ((i + 1) < 15) b.Image = Image.FromFile("siviHorizontalni.png");
							else if ((i + 1) >= 15) b.Image = Image.FromFile("siviVertikalni.png");
						}
						else if (razlika > 0 && vozila.Rows[i][4].ToString() == DateTime.Now.ToShortDateString()) // ako je razlika veca od 0 znaci da auto sme jos da ostane na parkingu i slika je plava
						{
							if (!string.IsNullOrEmpty(vozila.Rows[i][1].ToString()) && b.Name == ime && (i + 1) < 15) // ako je manje od 15 ide horizontalna slika(plava)
								b.Image = Image.FromFile("plaviHorizontalni.png");
							else if (!string.IsNullOrEmpty(vozila.Rows[i][1].ToString()) && b.Name == ime && (i + 1) >= 15) // ako je vece od 15 ide vertikalna slika(plava)
								b.Image = Image.FromFile("plaviVertikalni.png");
						}
						else
						{
							if (!string.IsNullOrEmpty(vozila.Rows[i][1].ToString()) && b.Name == ime && (i + 1) < 15) // ako je manje od 15 ide horizontalna slika(plava)
								b.Image = Image.FromFile("crveniHorizontalni.png");
							else if (!string.IsNullOrEmpty(vozila.Rows[i][1].ToString()) && b.Name == ime && (i + 1) >= 15) // ako je vece od 15 ide vertikalna slika(plava)
								b.Image = Image.FromFile("crveniVertikalni.png");
						}
					}
					else if (vozila.Rows[i][3].ToString() == "pretplatnik" && validacijaKarte((i + 1)))
					{
						if (!string.IsNullOrEmpty(vozila.Rows[i][1].ToString()) && b.Name == ime && (i + 1) < 15) // ako je manje od 15 ide horizontalna slika(plava)
							b.Image = Image.FromFile("plaviHorizontalni.png");
						else if (!string.IsNullOrEmpty(vozila.Rows[i][1].ToString()) && b.Name == ime && (i + 1) >= 15) // ako je vece od 15 ide vertikalna slika(plava)
							b.Image = Image.FromFile("plaviVertikalni.png");
					}
					else if (vozila.Rows[i][3].ToString() == "pretplatnik" && validacijaKarte((i + 1)) == false)
					{
						if (!string.IsNullOrEmpty(vozila.Rows[i][1].ToString()) && b.Name == ime && (i + 1) < 15) // ako je manje od 15 ide horizontalna slika(plava)
							b.Image = Image.FromFile("crveniHorizontalni.png");
						else if (!string.IsNullOrEmpty(vozila.Rows[i][1].ToString()) && b.Name == ime && (i + 1) >= 15) // ako je vece od 15 ide vertikalna slika(plava)
							b.Image = Image.FromFile("crveniVertikalni.png");
					}
					else b.Image = Image.FromFile("dodaj.png");
					i++;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private bool validacijaKarte(int pmesto)
		{
			try
			{
				Vozilo v = new Vozilo();
				v.ParkingMesto = pmesto;
				DataTable vozilo = v.selectVozilo();
				if (vozilo.Rows.Count > 0)
				{
					DataTable karta = Karta.selectKarteZaProveru(vozilo.Rows[0][1].ToString());
					if (karta.Rows.Count > 0)
					{
						if (karta.Rows[0][2].ToString() == "mesečna" && karta.Rows[0][3].ToString() == DateTime.Now.Month.ToString() && karta.Rows[0][4].ToString() == DateTime.Now.Year.ToString())
							return true;
						if (karta.Rows[0][2].ToString() == "godišnja" && karta.Rows[0][4].ToString() == DateTime.Now.Year.ToString())
							return true;
						else return false;
					}
					else return false;
				}
				else return false;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return false;
			}
		}

        private void postaviBoje()
        {
            bool b12 = false;
            bool b38 = false;
            bool b914 = false;
            bool b1523 = false;
            bool b2432 = false;
            bool b3341 = false;
            bool b4250 = false;
            var lista = new List<Button> { btnP1, btnP2, btnP3, btnP4, btnP5, btnP6, btnP7, btnP8, btnP9, btnP10, btnP11, btnP12, btnP13, btnP14, btnP15, btnP16, btnP17, btnP18, btnP19, btnP20, btnP21, btnP22, btnP23, btnP24, btnP25, btnP26, btnP27, btnP28, btnP29, btnP30, btnP31, btnP32, btnP33, btnP34, btnP35, btnP36, btnP37, btnP38, btnP39, btnP40, btnP41, btnP42, btnP43, btnP44, btnP45, btnP46, btnP47, btnP48, btnP49, btnP50 };
            int i = 1;

            foreach(Button b in lista)
            {
                if ((i == 1 || i == 2) && uporediSlike(b.Image, Image.FromFile("crveniHorizontalni.png")))
                    b12 = true;
                if ((i >= 3 && i <= 8) && uporediSlike(b.Image, Image.FromFile("crveniHorizontalni.png")))
                    b38 = true;
                if ((i >= 9 && i <= 14) && uporediSlike(b.Image, Image.FromFile("crveniHorizontalni.png")))
                    b914 = true;
                if ((i >= 15 && i <= 23) && uporediSlike(b.Image, Image.FromFile("crveniVertikalni.png")))
                    b1523 = true;
                if ((i >= 24 && i <= 32) && uporediSlike(b.Image, Image.FromFile("crveniVertikalni.png")))
                    b2432 = true;
                if ((i >= 33 && i <= 41) && uporediSlike(b.Image, Image.FromFile("crveniVertikalni.png")))
                    b3341 = true;
                if ((i >= 42 && i <= 50) && uporediSlike(b.Image, Image.FromFile("crveniVertikalni.png")))
                    b4250 = true;
                i++;
            }

            if(b12 == true)
            {
                panel31.BackColor = Color.Firebrick;
                panel35.BackColor = Color.Firebrick;
            }
            else
            {
                panel31.BackColor = Color.SteelBlue;
                panel35.BackColor = Color.SteelBlue;
            }
            if (b38 == true)
            {
                panel29.BackColor = Color.Firebrick;
                panel34.BackColor = Color.Firebrick;
            }
            else
            {
                panel29.BackColor = Color.SteelBlue;
                panel34.BackColor = Color.SteelBlue;
            }
            if (b914 == true)
            {
                panel27.BackColor = Color.Firebrick;
                panel33.BackColor = Color.Firebrick;
            }
            else
            {
                panel27.BackColor = Color.SteelBlue;
                panel33.BackColor = Color.SteelBlue;
            }
            if (b1523 == true)
            {
                panel18.BackColor = Color.Firebrick;
                panel20.BackColor = Color.Firebrick;
            }
            else
            {
                panel18.BackColor = Color.SteelBlue;
                panel20.BackColor = Color.SteelBlue;
            }
            if (b2432 == true)
            {
                panel22.BackColor = Color.Firebrick;
                panel24.BackColor = Color.Firebrick;
            }
            else
            {
                panel22.BackColor = Color.SteelBlue;
                panel24.BackColor = Color.SteelBlue;
            }
            if (b3341 == true)
            {
                panel16.BackColor = Color.Firebrick;
                panel25.BackColor = Color.Firebrick;
            }
            else
            {
                panel16.BackColor = Color.SteelBlue;
                panel25.BackColor = Color.SteelBlue;
            }
            if (b4250 == true)
            {
                panel14.BackColor = Color.Firebrick;
                panel26.BackColor = Color.Firebrick;
            }
            else
            {
                panel14.BackColor = Color.SteelBlue;
                panel26.BackColor = Color.SteelBlue;
            }
        }
		private bool uporediSlike(Image image1, Image image2)
		{
			byte[] image1Bytes;
			byte[] image2Bytes;

			using (var mstream = new MemoryStream())
			{
				image1.Save(mstream, image1.RawFormat);
				image1Bytes = mstream.ToArray();
			}

			using (var mstream = new MemoryStream())
			{
				image2.Save(mstream, image2.RawFormat);
				image2Bytes = mstream.ToArray();
			}

			var image164 = Convert.ToBase64String(image1Bytes);
			var image264 = Convert.ToBase64String(image2Bytes);

			return string.Equals(image164, image264);
		}

		private void cb15min_CheckedChanged(object sender, EventArgs e)
        {
            if(cb15min.Checked)
			{
				panel171.Visible = false;
			}
			else
			{
				panel171.Visible = true;
			}
        }


		private void cb15minAzuriraj_CheckedChanged(object sender, EventArgs e)
		{
			if (cb15minAzuriraj.Checked)
			{
				panel179.Visible = false;
			}
			else
			{
				panel179.Visible = true;
			}
		}

		private void showcb15()
		{
			cb15min.Visible = true;
		}

		private void hidecb15()
		{
			cb15min.Visible = false;
		}

		private void showcb15Azuriraj()
		{
			cb15minAzuriraj.Visible = true;
		}

		private void hidecb15Azuriraj()
		{
			cb15minAzuriraj.Visible = false;
		}
		private void OnTimeEvent(object sender, ElapsedEventArgs e)
		{
			Invoke(new Action(() =>
			{
				s += 1;
				if (s == 60)
				{
					prikazVozila();
					popuniTabelu();
					s = 0;
				}
			}));
		}

		private void tbVreme_DropDown(object sender, EventArgs e)
		{
			hidecb15();
		}

		private void tbVreme_DropDownClosed(object sender, EventArgs e)
		{
			showcb15();
		}

		private void tbVremeAzuriraj_DropDown(object sender, EventArgs e)
		{
			hidecb15Azuriraj();
		}

		private void tbVremeAzuriraj_DropDownClosed(object sender, EventArgs e)
		{
			showcb15Azuriraj();
		}

		private void tbGrad_MouseClick(object sender, MouseEventArgs e)
		{
			tbGrad.Text = "";
			tbBrojTablica.Text = "";
			tbSlovaTablice.Text = "";
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
			tbSlovaTablice_TextChanged(sender, e);
		}

		private void tbBrojTablica_TextChanged(object sender, EventArgs e)
		{
			tbBrojTablica.CharacterCasing = CharacterCasing.Upper;
			tbSlovaTablice_TextChanged(sender,e);
		}

		private void tbSlovaTablice_TextChanged(object sender, EventArgs e)
		{
			try
			{
				KartaNotifikacija.Visible = false;
				btnPUnesi.Enabled = true;
				tbSlovaTablice.CharacterCasing = CharacterCasing.Upper;
				Vozilo v = new Vozilo();
					string tablica = tbGrad.Text + "-" + tbBrojTablica.Text + "-" + tbSlovaTablice.Text;
					v.RegistracioniBrojTablica = tablica;
				if(v.selectVoziloPoTablicama())
				{
					KartaNotifikacija.Visible = true;
					KartaNotifikacija.Text = "Vozilo se već nalazi na parking mestu " + v.ParkingMesto;
					btnPUnesi.Enabled = false;
				}
				else
				{
					DataTable dt = Karta.selectKarteZaProveru(tablica);
					if (dt.Rows.Count > 0)
					{
						if ((dt.Rows[0][2].ToString() == "mesečna" && int.Parse(dt.Rows[0][3].ToString()) == DateTime.Now.Month) || dt.Rows[0][2].ToString() == "godišnja")
							KartaNotifikacija.Visible = true;
						KartaNotifikacija.Text = "Korisnik ";
						if (dt.Rows[0][2].ToString() == "mesečna")
							KartaNotifikacija.Text += "mesečne karte.";
						else if (dt.Rows[0][2].ToString() == "godišnja")
							KartaNotifikacija.Text += "godišnje karte.";
						KartaNotifikacija.AppendText(Environment.NewLine);
						KartaNotifikacija.Text += "Vlasnik: " + dt.Rows[0][0].ToString();
					}
					else KartaNotifikacija.Visible = false;
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnKazni_Click(object sender, EventArgs e)
        {
            panelZaKaznu.Visible = true;
            tbDatum.Text = DateTime.Today.ToShortDateString();
            tbVremeKazna.Text = DateTime.Now.ToShortTimeString();
			tbPMestoKazna.Text = tbParkingMestoAzuriraj.Text;
			tbRegistarskiBrojTablica.Text = tbGradAzuriraj.Text + "-" + tbBrojTablicaAzuriraj.Text + "-" + tbSlovaTabliceAzuriraj.Text;
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
					pParkiran.Visible = false;
					panelZaKaznu.Visible = false;
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

        private void tbBrojTablicaAzuriraj_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s\b]");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void tbGradAzuriraj_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s\b\u0161\u0111\u010D\u0107\u017E]+$");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void tbSlovaTabliceAzuriraj_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s\b\u0161\u0111\u010D\u0107\u017E]+$");
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

        private void tbBrojTablica_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s\b]");
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

        private void btnOdustaniKazna_Click(object sender, EventArgs e)
        {
            panelZaKaznu.Visible = false;
            tbDatum.Text = "";
            tbVremeKazna.Text = "";
            tbNapomena.Text = "";

        }

		private void tbPMestoKazna_KeyPress(object sender, KeyPressEventArgs e)
		{
			var regex = new Regex(@"[^a-zA-Z0-9\s\b]");
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

		private void tbDatum_KeyPress(object sender, KeyPressEventArgs e)
		{
			var regex = new Regex(@"[^a-zA-Z0-9\s\b\.]");
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

		private void tbNapomena_KeyPress(object sender, KeyPressEventArgs e)
		{
			var regex = new Regex(@"[^a-zA-Z0-9\s\b\u0161\u0111\u010D\u0107\u017E]+$");
			if (regex.IsMatch(e.KeyChar.ToString()))
			{
				e.Handled = true;
			}
		}

		private void cbSV_CheckedChanged(object sender, EventArgs e)
		{
			if (cbSV.Checked) tbStranoVozilo.Visible = true;
			else tbStranoVozilo.Visible = false;
		}

		private void tbStranoVozilo_KeyPress(object sender, KeyPressEventArgs e)
		{
			var regex = new Regex(@"[^a-zA-Z0-9\s\b\u0161\u0111\u010D\u0107\u017E\-]+$");
			if (regex.IsMatch(e.KeyChar.ToString()))
			{
				e.Handled = true;
			}
		}

		private void tbStranoVozilo_TextChanged(object sender, EventArgs e)
		{
			try
			{
				tbStranoVozilo.CharacterCasing = CharacterCasing.Upper;
				Vozilo v = new Vozilo();
				v.RegistracioniBrojTablica = tbStranoVozilo.Text;
				if (v.selectVoziloPoTablicama())
				{
					KartaNotifikacija.Visible = true;
					KartaNotifikacija.Text = "Vozilo se već nalazi na parking mestu " + v.ParkingMesto;
					btnPUnesi.Enabled = false;
				}
				else
				{
					KartaNotifikacija.Visible = false;
					btnPUnesi.Enabled = true;
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

        private void tbStranoVoziloAzuriraj_TextChanged(object sender, EventArgs e)
        {
            tbStranoVoziloAzuriraj.CharacterCasing = CharacterCasing.Upper;
        }

        private void tbStranoVoziloAzuriraj_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s\b\u0161\u0111\u010D\u0107\u017E\-]+$");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }
    }
}

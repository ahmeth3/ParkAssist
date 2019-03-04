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
    public partial class clanoviSluzbe : UserControl
    {
		public int izabraniindex;
		public PojedinacniClan pojedinacniClan { get; set; }
        public dodajClana dodajclana { get; set; }
        public bivsiClanovi bivsiclanovi { get; set; }
        public clanoviSluzbe()
        {
            InitializeComponent();
        }

        private void btnAktivni_Click(object sender, EventArgs e)
        {
			pojedinacniClan.aktivnost = 0;
			btnAktivni.BackColor = Color.FromArgb(50, 50, 50);
			btnBivsi.BackColor = Color.FromArgb(30, 30, 30);
			btnAktivni.ForeColor = Color.Silver;
			btnBivsi.ForeColor = Color.Gray;
			this.BringToFront();
			this.prikazRadnika("Aktivni");
		}

        public void btnBivsi_Click(object sender, EventArgs e)
        {
			pojedinacniClan.aktivnost = 1;
			btnBivsi.BackColor = Color.FromArgb(50, 50, 50);
			btnAktivni.BackColor = Color.FromArgb(30, 30, 30);
			btnBivsi.ForeColor = Color.Silver;
			btnAktivni.ForeColor = Color.Gray;
			bivsiclanovi.BringToFront();
			bivsiclanovi.prikazRadnika("Bivsi");
		}

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            dodajclana.BringToFront();
        }

		private void klikNaRadnika(object sender, EventArgs e)
		{
			PictureBox pb = sender as PictureBox;
			pojedinacniClan.indeks = Int32.Parse(pb.Name);
			pojedinacniClan.prilagodi();
			pojedinacniClan.popuniPodacima();
			pojedinacniClan.BringToFront();
		}

		int k = 0;
		int q = 0;

		public void prikazRadnika(String uslov)
		{
			try
			{
				DataTable clanovi = new DataTable();
				clanovi = Direktor.selectRadnike();
				panelZaClanove.Controls.Clear();
				PictureBox[] pb = new PictureBox[clanovi.Rows.Count]; //ovde cemo da dodamo funkciju koja odredjuje koliko clanova imamo. Taj broj se posle prosledi ovde da napravi toliko objekata koliko ima clanova.
				Label[] lb = new Label[clanovi.Rows.Count];

				for (int i = 0; i < clanovi.Rows.Count; i++)
				{
					if (clanovi.Rows[i][8].ToString() == uslov)
					{
						pb[i] = new PictureBox();
						panelZaClanove.Controls.Add(pb[i]);
						pb[i].Name = i.ToString();
						pb[i].Width = 125;
						pb[i].Height = 125;
						pb[i].Top = q + 20;
						pb[i].Left = 135 + k;
						pb[i].BackColor = Color.FromArgb(87, 87, 87);
						if (clanovi.Rows[i][11] != null)
						{
							byte[] imgg = (byte[])(clanovi.Rows[i][11]);
							MemoryStream mstream = new MemoryStream(imgg);
							pb[i].Image = System.Drawing.Image.FromStream(mstream);
							pb[i].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
						}


						pb[i].Click += new EventHandler(klikNaRadnika);


						lb[i] = new Label();
						panelZaClanove.Controls.Add(lb[i]);
						lb[i].Width = 125;
						lb[i].Height = 25;
						lb[i].Top = q + 145;
						lb[i].Left = 135 + k;
						lb[i].BackColor = Color.FromArgb(40, 40, 40);
						lb[i].ForeColor = Color.Silver;
						lb[i].Font = new Font(lb[i].Font.FontFamily, lb[i].Font.Size * 1.5f);
						lb[i].Font = new Font(lb[i].Font, FontStyle.Bold);
						lb[i].TextAlign = ContentAlignment.MiddleCenter;
						lb[i].Text = clanovi.Rows[i][0].ToString();
						k += 200;
						if (k > 1100)
						{
							k = 0;
							q += 200;
						}
					}
				}
				k = 0;
				q = 0;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void clanoviSluzbe_Load(object sender, EventArgs e)
		{
			prikazRadnika("Aktivni");
		}

        private void panelZaClanove_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

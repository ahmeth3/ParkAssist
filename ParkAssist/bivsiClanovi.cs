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
    public partial class bivsiClanovi : UserControl
    {
		public PojedinacniClan pojedinacniClan { get; set; }
        public bivsiClanovi()
        {
            InitializeComponent();
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
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void klikNaRadnika(object sender, EventArgs e)
		{
			PictureBox pb = sender as PictureBox;
			pojedinacniClan.indeks = Int32.Parse(pb.Name);
			pojedinacniClan.prilagodi();
			pojedinacniClan.popuniPodacima();
			pojedinacniClan.BringToFront();
		}
	}
}

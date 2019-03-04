using ParkAssist.Klase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ParkAssist
{
    public partial class promenaLozinke : Form
    {
        public promenaLozinke()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }

        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;

        private void btnPonisti_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new loginForm();
            f.Show();
        }

		private void btnPotvrdi_Click(object sender, EventArgs e)
		{
			try
			{
				if (tbKorisnickoIme.Text == "" || tbLozinka.Text == "" || tbNLozinka.Text == "" || tbPotvrdaNLozinke.Text == "")
					customMessageBox.Show("Molimo Vas popunite sva polja!");
				else
				{
					Osoba o = new Osoba();
					o.KorisnickoIme = tbKorisnickoIme.Text;
					o.Lozinka = tbLozinka.Text;
					if (tbNLozinka.Text.Equals(tbPotvrdaNLozinke.Text))
					{
						if (o.promenaLozinke(tbNLozinka.Text))
							customMessageBox.Show("Lozinka je uspešno promenjena");
						else customMessageBox.Show("Neuspešna promena lozinke");
					}
					else customMessageBox.Show("Nepravilno potvrđena lozinka");
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

        private void tbNLozinka_TextChanged(object sender, EventArgs e)
        {
            Regexp(@"[^a-zA-Z0-9\s]", tbNLozinka, 3);
        }

        private void tbPotvrdaNLozinke_TextChanged(object sender, EventArgs e)
        {
            Regexp(@"[^a-zA-Z0-9\s]", tbPotvrdaNLozinke, 4);
        }

        private void tbLozinka_TextChanged(object sender, EventArgs e)
        {
            Regexp(@"[^a-zA-Z0-9\s]", tbLozinka, 2);
        }

        private void tbKorisnickoIme_TextChanged(object sender, EventArgs e)
        {
            Regexp(@"[^a-zA-Z0-9\s]", tbKorisnickoIme, 1);
        }

        int c1 = 0;
        int c2 = 0;
        int c3 = 0;
        int c4 = 0;
        private void Regexp(string re, TextBox tb, int c)
        {

            Regex regex = new Regex(re);
            if (regex.IsMatch(tb.Text))
            {
                if (c == 1)
                    c1 = 1;
                if (c == 2)
                    c2 = 1;
                if (c == 3)
                    c3 = 1;
                if (c == 4)
                    c4 = 1;
            }

            else
            {
                if (c == 1)
                    c1 = 0;
                if (c == 2)
                    c2 = 0;
                if (c == 3)
                    c3 = 0;
                if (c == 4)
                    c4 = 0;
            }

            if (c1 == 0 && c2 == 0 && c3 == 0 && c4 == 0)
            {
                lbNemoze.Visible = false;
                lbNemoze2.Visible = false;
                btnPotvrdi.Enabled = true;
            }

            else if (c1 > 0 || c2 > 0 || c3 > 0 || c4 > 0)
            {
                lbNemoze.Visible = true;
                lbNemoze2.Visible = true;
                if (c1 == 0 && c2 == 0)
                    lbNemoze.Visible = false;
                else if (c3 == 0 && c4 == 0)
                    lbNemoze2.Visible = false;

                btnPotvrdi.Enabled = false;
            }

        }
    }
}

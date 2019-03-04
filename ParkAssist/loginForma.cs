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
    public partial class loginForm : Form
    {
        public loginForm()
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

        private void btnIzadji_Click(object sender, EventArgs e)
        {
            for(int i=Application.OpenForms.Count-1; i!=-1; i=Application.OpenForms.Count-1)
            {
                Application.OpenForms[i].Close();
            }
        }

        private void lbX_Click(object sender, EventArgs e)
        {
            for (int i = Application.OpenForms.Count - 1; i != -1; i = Application.OpenForms.Count - 1)
            {
                Application.OpenForms[i].Close();
            }
        }

        private void lb__Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void cbPrikaziLozinku_CheckedChanged(object sender, EventArgs e)
        {
            tbLozinka.PasswordChar = cbPrikaziLozinku.Checked ? '\0' : '*';
        }

        private void btnPromenaLozinke_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new promenaLozinke();
            f.Show();
        }

        private void btnUlogujSe_Click(object sender, EventArgs e)
        {
			Osoba o = new Osoba();
			o.KorisnickoIme = tbKorisnickoIme.Text;
			o.Lozinka = tbLozinka.Text;
			DataTable dt = Baza.Login(o);

            try
			{
				if(o.proveraKorisnika())
				{
					if (dt.Rows.Count == 1 && dt.Rows[0][8].ToString().Equals("Aktivni"))
					{
						switch (dt.Rows[0][2] as string)
						{
							case "Direktor":
								{
									o.ID = int.Parse(dt.Rows[0][10].ToString());
									this.Hide();
									formaDirektora f = new formaDirektora();
									f.PrijavljeniKorisnik(o);
									f.Show();
									break;
								}
							case "Radnik":
								{
									o.ID = int.Parse(dt.Rows[0][10].ToString());
									this.Hide();
									formaRadnika f = new formaRadnika();
									f.PrijavljeniKorisnik(o);
									f.Show();
									break;
								}
							default:
								{
									customMessageBox.Show("Neispravno ste uneli korisničko ime ili lozinku.");
									break;
								}
						}
					}
					else
					{
						customMessageBox.Show("Neispravno ste uneli korisničko ime ili lozinku.");
					}
				}
				else
				{
					customMessageBox.Show("Ne postoji korisnik sa unesenim korisničkim imenom");
				}
            }
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}


        }

        private void tbKorisnickoIme_TextChanged(object sender, EventArgs e)
        {
            Regexp(@"[^a-zA-Z0-9\s]", tbKorisnickoIme, 1);
        }

        private void tbKorisnickoIme_KeyPress(object sender, KeyPressEventArgs e)
        {}


        int cki = 0;
        int cl = 0;
        private void Regexp(string re, TextBox tb, int c)
        {
            
            Regex regex = new Regex(re);
            if(regex.IsMatch(tb.Text))
            {
                if(c == 1)
                    cki = 1;
                if (c == 2)
                    cl = 1;
            }

            else
            {
                if (c == 1)
                    cki = 0;
                if (c == 2)
                    cl = 0;
            }

            if(cki == 0 && cl == 0)
            {
                lbNemore.Visible = false;
                btnUlogujSe.Enabled = true;
            }

            else if(cki > 0 || cl > 0)
            {
                lbNemore.Visible = true;
                btnUlogujSe.Enabled = false;
            }

        }

        private void tbLozinka_TextChanged(object sender, EventArgs e)
        {
            Regexp(@"[^a-zA-Z0-9\s]", tbLozinka, 2);
        }
    }
    
}

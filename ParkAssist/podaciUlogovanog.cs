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

namespace ParkAssist
{
    public partial class podaciUlogovanog : UserControl
    {
        public podaciUlogovanog()
        {
            InitializeComponent();
        }

		public void popuniFormu(Osoba o)
		{
			DataTable dt = o.selectOsoba();

			if(dt.Rows.Count == 1)
			{
				lbAdresa.Text = dt.Rows[0][5].ToString();
				lbKorisnickoIme.Text = dt.Rows[0][0].ToString();
				lbDatumZaposljenja.Text = dt.Rows[0][7].ToString();
				lbDatumRodjenja.Text = dt.Rows[0][4].ToString();
				lbLokacijaRada.Text = dt.Rows[0][6].ToString();
			}
		}
    }
}

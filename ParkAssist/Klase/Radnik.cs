using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkAssist.Klase
{
	public class Radnik : Osoba
	{
		public Radnik() : base() { }
		public Radnik(String VrstaKorisnika, String KorisnickoIme, String Lozinka, String ImePrezime, String DatumRodjenja, String Adresa, String LokacijaRada, String DatumZaposljenja) : base(VrstaKorisnika, KorisnickoIme, Lozinka, ImePrezime, DatumRodjenja, Adresa, LokacijaRada, DatumZaposljenja) { }
		
		public DataTable selectRadnik()
		{
			DataTable dt = Baza.SelectRadnika(this);
			return dt;
		}
	}
}

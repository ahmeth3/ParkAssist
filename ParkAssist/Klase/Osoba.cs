using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkAssist.Klase
{
	public class Osoba
	{
		public String VrstaKorisnika { get; set; }
		public String KorisnickoIme { get; set; }
		public String Lozinka { get; set; }
		public String ImePrezime { get; set; }
		public String DatumRodjenja { get; set; }
		public String Adresa { get; set; }
		public String LokacijaRada { get; set; }
		public String DatumZaposljenja { get; set; }
		public String Napomena { get; set; }
		public long ID { get; set; }
		public byte[] Slika { get; set; }

		public Osoba()
		{
			this.VrstaKorisnika = null;
			this.KorisnickoIme = null;
			this.Lozinka = "";
			this.ImePrezime = null;
			this.DatumRodjenja = null;
			this.Adresa = null;
			this.LokacijaRada = null;
			this.DatumZaposljenja = null;
			this.Napomena = null;
			this.Slika = null;
		}
		public Osoba(String VrstaKorisnika, String KorisnickoIme, String Lozinka, String ImePrezime, String DatumRodjenja, String Adresa, String LokacijaRada, String DatumZaposljenja)
		{
			this.VrstaKorisnika = VrstaKorisnika;
			this.KorisnickoIme = KorisnickoIme;
			this.Lozinka = Lozinka;
			this.ImePrezime = ImePrezime;
			this.DatumRodjenja = DatumRodjenja;
			this.Adresa = Adresa;
			this.LokacijaRada = LokacijaRada;
			this.DatumZaposljenja = DatumZaposljenja;
		}

		public bool proveraKorisnika()
		{
			if (Baza.ProveraKorisnika(this))
				return true;
			else return false;
		}
		public DataTable login()
		{
			DataTable dt = Baza.Login(this);
			return dt;
		}

		public bool promenaLozinke(string novasifra)
		{
			if (Baza.resetLozinku(this, novasifra))
				return true;
			return false;
		}

		public DataTable selectOsoba()
		{
			DataTable dt = Baza.SelectOsoba(this);
			return dt;
		}
	}
}

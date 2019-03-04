using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkAssist.Klase
{
	class PrimerOsobe
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

		public PrimerOsobe()
		{
			this.VrstaKorisnika = null;
			this.KorisnickoIme = null;
			this.Lozinka = null;
			this.ImePrezime = null;
			this.DatumRodjenja = null;
			this.Adresa = null;
			this.LokacijaRada = null;
			this.DatumZaposljenja = null;
			this.Napomena = null;
		}
		public PrimerOsobe(String VrstaKorisnika, String KorisnickoIme, String Lozinka, String ImePrezime, String DatumRodjenja, String Adresa, String LokacijaRada, String DatumZaposljenja)
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
			return false;
		}

		public bool login()
		{
			if (Baza.Login(this))
				return true;
			return false;
		}

		public bool kreirajKorisnika()
		{
			if (Baza.KreirajKorisnika(this))
				return true;
			return false;
		}

		public void prikazRadnika(int indeks)
		{
			DataTable clanovi = Baza.Select();

			this.VrstaKorisnika = clanovi.Rows[indeks][2].ToString();
			this.KorisnickoIme = clanovi.Rows[indeks][0].ToString();
			this.Lozinka = clanovi.Rows[indeks][1].ToString();
			this.ImePrezime = clanovi.Rows[indeks][3].ToString();
			this.DatumRodjenja = clanovi.Rows[indeks][4].ToString();
			this.Adresa = clanovi.Rows[indeks][5].ToString();
			this.LokacijaRada = clanovi.Rows[indeks][6].ToString();
			this.DatumZaposljenja = clanovi.Rows[indeks][7].ToString();
			this.Napomena = clanovi.Rows[indeks][9].ToString();
			this.ID = int.Parse(clanovi.Rows[indeks][10].ToString());
			clanovi.Dispose();
		}

		public bool arhivirajKorisnika()
		{
			if (Baza.arhivirajKorisnika(this))
				return true;
			return false;
		}

		public bool izbrisiKorisnika()
		{
			if (Baza.izbrisiKorisnika(this))
				return true;
			return false;
		}

		public void azurirajRadnika()
		{
			Baza.azurirajRadnika(this);
		}

		public static DataTable selectRadnike()
		{
			DataTable dt = new DataTable();
			dt = Baza.Select();
			return dt;
		}

		public bool promenaLozinke(string novasifra)
		{
			if (Baza.resetLozinku(this, novasifra))
				return true;
			return false;
		}

		public void unesiVozilo(Vozilo v)
		{
			Baza.unesiVozilo(v);
		}
	}
}

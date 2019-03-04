using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkAssist.Klase
{
	public class Direktor : Osoba
	{
		public Direktor() : base() { }
		public Direktor(String VrstaKorisnika, String KorisnickoIme, String Lozinka, String ImePrezime, String DatumRodjenja, String Adresa, String LokacijaRada, String DatumZaposljenja) : base(VrstaKorisnika, KorisnickoIme, Lozinka, ImePrezime, DatumRodjenja, Adresa, LokacijaRada, DatumZaposljenja) { }

		public bool proveraKorisnika(Osoba o)
		{
			if (Baza.ProveraKorisnika(o))
				return true;
			return false;
		}

		public bool kreirajKorisnika(Osoba o)
		{
			if (Baza.KreirajKorisnika(o))
				return true;
			return false;
		}

		public Osoba prikazRadnika(int indeks)
		{
			DataTable clanovi = Baza.Select();
			Osoba o = new Osoba();

			o.VrstaKorisnika = clanovi.Rows[indeks][2].ToString();
			o.KorisnickoIme = clanovi.Rows[indeks][0].ToString();
			o.ImePrezime = clanovi.Rows[indeks][3].ToString();
			o.DatumRodjenja = clanovi.Rows[indeks][4].ToString();
			o.Adresa = clanovi.Rows[indeks][5].ToString();
			o.LokacijaRada = clanovi.Rows[indeks][6].ToString();
			o.DatumZaposljenja = clanovi.Rows[indeks][7].ToString();
			o.Napomena = clanovi.Rows[indeks][9].ToString();
			o.ID = int.Parse(clanovi.Rows[indeks][10].ToString());
			o.Slika = (byte[])(clanovi.Rows[indeks][11]);

			return o;
		}

		public bool arhivirajKorisnika(Osoba o)
		{
			if (Baza.arhivirajKorisnika(o))
				return true;
			return false;
		}

		public bool izbrisiKorisnika(Osoba o)
		{
			if (Baza.izbrisiKorisnika(o))
				return true;
			return false;
		}

		public void azurirajRadnika(Osoba o)
		{
			Baza.azurirajRadnika(o);
		}

		public static DataTable selectRadnike()
		{
			DataTable dt = new DataTable();
			dt = Baza.Select();
			return dt;
		}

		public DataTable selectDirektor()
		{
			DataTable dt = Baza.SelectDirektora(this);
			return dt;
		}
	}
}

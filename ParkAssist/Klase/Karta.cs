using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkAssist.Klase
{
	public class Karta
	{
		public string ImePrezime { get; set; }
		public string RegistracioniBrojTablica { get; set; }
		public string TipKarte { get; set; }
		public string Mesec { get; set; }
		public string Godina { get; set; }
		public long ID { get; set; }

		public Karta()
		{
			this.ImePrezime = "";
			this.RegistracioniBrojTablica = "";
			this.TipKarte = "";
			this.Mesec = "";
			this.Godina = "";
			this.ID = -100;
		}

		public Karta(string iP, string rBr, string tP, string M, string G)
		{
			this.ImePrezime = iP;
			this.RegistracioniBrojTablica = rBr;
			this.TipKarte = tP;
			this.Mesec = M;
			this.Godina = G;
		}

		public void unesiKartu()
		{
			Baza.unesiKartu(this);
		}

		public void azurirajKartu()
		{
			Baza.azurirajKartu(this);
		}

		public void obrisiKartu()
		{
			Baza.obrisiKartu(this);
		}

		public static DataTable selectKarte()
		{
			DataTable dt = Baza.selectKarte();
			return dt;
		}

		public static DataTable selectKarteZaSearch(string pretraga)
		{
			DataTable dt = Baza.selectKarteZaSearch(pretraga);
			return dt;
		}

		public static DataTable selectKarteZaProveru(string provera)
		{
			DataTable dt = Baza.selectKartuZaProveru(provera);
			return dt;
		}
	}
}

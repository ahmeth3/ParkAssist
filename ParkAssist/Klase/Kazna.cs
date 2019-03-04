using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkAssist.Klase
{
	class Kazna
	{
		public int ParkingMesto { get; set; }
		public string RegistracioniBrojTablica { get; set; }
		public string Datum { get; set; }
		public string Vreme { get; set; }
		public string Napomena { get; set; }
		public int ID { get; set; }

		public Kazna()
		{
			ParkingMesto = 0;
			RegistracioniBrojTablica = "";
			Datum = "";
			Vreme = "";
			Napomena = "";
		}

		public Kazna(int pM, string rBT, string D, string V, string N)
		{
			ParkingMesto = pM;
			RegistracioniBrojTablica = rBT;
			Datum = D;
			Vreme = V;
			Napomena = N;
		}

		public void unesiKaznu()
		{
			Baza.unesiKaznu(this);
		}

		public void azurirajKaznu()
		{
			Baza.azurirajKaznu(this);
		}

		public void obrisiKaznu()
		{
			Baza.obrisiKaznu(this);
		}

		public static DataTable selectkazne()
		{
			DataTable dt = Baza.selectKazne();
			return dt;
		}

		public static DataTable selectKazneZaSearch(string pretraga)
		{
			DataTable dt = Baza.selectKazneZaSearch(pretraga);
			return dt;
		}
	}
}

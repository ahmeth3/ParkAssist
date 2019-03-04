using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkAssist.Klase
{
	public class Smena
	{
		public string Datum { get; set; }
		public string izborSmene { get; set; }
		public long ID { get; set; }

		public Smena()
		{
			Datum = null;
			izborSmene = null;
		}

		public Smena(string D, string iS, long ID)
		{
			Datum = D;
			izborSmene = iS;
			this.ID = ID;
		}

		public void dodajSmenu()
		{
			Baza.dodajSmenu(this);
		}

		public void azurirajSmenu()
		{
			Baza.azurirajSmenu(this);
		}

		public void izbrisiSmenu()
		{
			Baza.izbrisiSmenu(this);
		}

		public static DataTable selectSmene()
		{
			DataTable dt = new DataTable();
			dt = Baza.SelectSmene();
			return dt;
		}

		public DataTable selectSmenu()
		{
			DataTable dt = new DataTable();
			dt = Baza.SelectSmenu(this);
			return dt;
		}

		public DataTable selectSmenuPoIDU()
		{
			DataTable dt = new DataTable();
			dt = Baza.SelectSmenuPoIDu(this);
			return dt;
		}
	}
}

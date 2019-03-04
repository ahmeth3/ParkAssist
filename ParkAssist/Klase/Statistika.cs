using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkAssist.Klase
{
	class Statistika
	{
		public string Mesec { get; set; }
		public string Godina { get; set; }
		public int brojKarti { get; set; }
		public int Prihod { get; set; }
		public int brojKazni { get; set; }

		public Statistika()
		{
			this.Mesec = "";
			this.Godina = "";
			this.brojKarti = 0;
			this.Prihod = 0;
			this.brojKazni = 0;
		}

		public DataTable selectStatistika()
		{
			DataTable dt = Baza.selectStatistika(this);
			return dt;
		}

		public void kreiranjeMeseca()
		{
			Baza.kreiranjeMeseca(this);
		}

		public void unosKarteStatistika()
		{
			Baza.unosKarteStatistika(this);
		}

		public void unosKazneStatistika()
		{
			Baza.unosKazneStatistika(this);
		}

		public void unosSatiStatistika()
		{
			Baza.unosSatiStatistika(this);
		}
	}
}

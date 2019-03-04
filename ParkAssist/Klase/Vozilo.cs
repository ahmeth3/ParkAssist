using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkAssist.Klase
{
	public class Vozilo
	{
		public int ParkingMesto { get; set; }
		public string RegistracioniBrojTablica { get; set; }
		public string Vreme { get; set; }
		public string Stanje { get; set; }
		public string Dan { get; set; }

		public Vozilo()
		{
			ParkingMesto = 0;
			RegistracioniBrojTablica = "";
			Vreme = "";
			Stanje = "";
			Dan = "";
		}

		public Vozilo(int pM, string rBT, string V, string S, string D)
		{
			ParkingMesto = pM;
			RegistracioniBrojTablica = rBT;
			Vreme = V;
			Stanje = S;
			Dan = D;
		}

		public void unesiVozilo()
		{
			Baza.unesiVozilo(this);
		}

		public void azurirajVozilo()
		{
			Baza.azurirajVozilo(this);
		}

		public void obrisiVozilo()
		{
			Baza.obrisiVozilo(this);
		}

		public static DataTable selectParking()
		{
			DataTable dt = Baza.SelectParking();
			return dt;
		}

		public DataTable selectVozilo()
		{
			DataTable dt = Baza.SelectVozilo(this);
			return dt;
		}

		public bool selectVoziloPoTablicama()
		{
			DataTable dt = Baza.SelectVoziloPoTablicama(this);
			if (dt.Rows.Count != 0)
			{
				this.ParkingMesto = int.Parse(dt.Rows[0][0].ToString());
				return true;
			}
			return false;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ParkAssist.Klase
{
	class Baza
	{
		private static string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=ParkAssist.accdb; Jet OLEDB:Database password=;";
		private static OleDbConnection connect = new OleDbConnection(connectionString);

		private static string hashLozinka(string lozinka)
		{
			using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
			{
				UTF8Encoding utf8 = new UTF8Encoding();
				byte[] data = md5.ComputeHash(utf8.GetBytes(lozinka));
				return Convert.ToBase64String(data);
			}
		}

		public static bool ProveraKorisnika(Osoba o)
		{
			string sql = "SELECT KorisnickoIme FROM Login";
			OleDbCommand cmd = new OleDbCommand(sql, connect);
			OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
			connect.Open();
			DataTable dt = new DataTable();
			adapter.Fill(dt);

			for (int i = 0; i < dt.Rows.Count; i++)
			{
				if (dt.Rows[i][0].ToString() == o.KorisnickoIme)
				{
					connect.Close();
					return true;
				}
			}
			connect.Close();
			return false;
		}

		public static DataTable Login(Osoba o)
		{
			DataTable dt = new DataTable();
			string sql = "SELECT * FROM Login WHERE KorisnickoIme = @KorisnickoIme AND Lozinka = @Lozinka";
			OleDbCommand cmd = new OleDbCommand(sql, connect);
			cmd.Parameters.AddWithValue("@KorisnickoIme", o.KorisnickoIme);
			cmd.Parameters.AddWithValue("@Lozinka", hashLozinka(o.Lozinka));

			OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
			connect.Open();
			adapter.Fill(dt);
			connect.Close();

			return dt;
		}

		public static bool KreirajKorisnika(Osoba o)
		{
			OleDbCommand cmd = new OleDbCommand("INSERT INTO Login (KorisnickoIme, Lozinka, VrstaKorisnika, ImePrezime, DatumRodjenja, Adresa, LokacijaRada, DatumZaposljenja, Aktivnost, Slika) VALUES(@KorisnickoIme, @Lozinka, @VrstaKorisnika, @ImePrezime, @DatumRodjenja, @Adresa, @LokacijaRada, @DatumZaposljenja, @Aktivnost, @Slika)", connect);
			cmd.Parameters.AddWithValue("@KorisnickoIme", o.KorisnickoIme);
			cmd.Parameters.AddWithValue("@Lozinka", hashLozinka(o.Lozinka));
			cmd.Parameters.AddWithValue("@VrstaKorisnika", o.VrstaKorisnika);
			cmd.Parameters.AddWithValue("@ImePrezime", o.ImePrezime);
			cmd.Parameters.AddWithValue("@DatumRodjenja", o.DatumRodjenja);
			cmd.Parameters.AddWithValue("@Adresa", o.Adresa);
			cmd.Parameters.AddWithValue("@LokacijaRada", o.LokacijaRada);
			cmd.Parameters.AddWithValue("@DatumZaposljenja", o.DatumZaposljenja);
			cmd.Parameters.AddWithValue("@Aktivnost", "Aktivni");
			cmd.Parameters.AddWithValue("@Slika", o.Slika);
			connect.Open();

			int rows = cmd.ExecuteNonQuery();
			connect.Close();
			if (rows > 0) return true;
			else return false;
		}

		public static DataTable Select()
		{
			DataTable dt = new DataTable();
			String sql = "SELECT * from Login";
			OleDbCommand cmd = new OleDbCommand(sql, connect);
			OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
			connect.Open();
			adapter.Fill(dt);
			connect.Close();
			return dt;
		}

		public static bool arhivirajKorisnika(Osoba o)
		{
			bool uspesno = false;
			try
			{
				string sql = "UPDATE Login SET Aktivnost = 'Bivsi' WHERE [KorisnickoIme] = @KorisnickoIme";
				OleDbCommand cmd = new OleDbCommand(sql, connect);
				cmd.Parameters.Add("@KorisnickoIme", OleDbType.Char).Value = o.KorisnickoIme;
				connect.Open();
				cmd.ExecuteNonQuery();
				connect.Close();
				uspesno = true;
			}
			catch (Exception ex)
			{
				uspesno = false;
			}
			return uspesno;
		}

		public static bool izbrisiKorisnika(Osoba o)
		{
			bool uspesno = false;
			try
			{
				string sql = "DELETE FROM Login WHERE [KorisnickoIme] = @KorisnickoIme";
				OleDbCommand cmd = new OleDbCommand(sql, connect);
				cmd.Parameters.Add("@KorisnickoIme", OleDbType.Char).Value = o.KorisnickoIme;
				connect.Open();
				cmd.ExecuteNonQuery();
				connect.Close();
				uspesno = true;
			}
			catch (Exception ex)
			{
				uspesno = false;
			}
			return uspesno;
		}

		public static void azurirajRadnika(Osoba o)
		{
			string sql;
			if (o.Lozinka != "")
				sql = "UPDATE Login SET [KorisnickoIme] = @KorisnickoIme, [Lozinka] = @Lozinka, [VrstaKorisnika] = @VrstaKorisnika, [ImePrezime] = @ImePrezime, [DatumRodjenja] = @DatumRodjenja, [Adresa] = @Adresa, [LokacijaRada] = @LokacijaRada, [DatumZaposljenja] = @DatumZaposljenja, [Napomena] = @Napomena, [Slika] = @Slika WHERE [ID] = @ID";
			else sql = "UPDATE Login SET [KorisnickoIme] = @KorisnickoIme, [VrstaKorisnika] = @VrstaKorisnika, [ImePrezime] = @ImePrezime, [DatumRodjenja] = @DatumRodjenja, [Adresa] = @Adresa, [LokacijaRada] = @LokacijaRada, [DatumZaposljenja] = @DatumZaposljenja, [Napomena] = @Napomena, [Slika] = @Slika WHERE [ID] = @ID";

			OleDbCommand cmd = new OleDbCommand(sql, connect);
			cmd.Parameters.AddWithValue("@KorisnickoIme", o.KorisnickoIme);
			if (o.Lozinka != "")
				cmd.Parameters.AddWithValue("@Lozinka", hashLozinka(o.Lozinka));
			cmd.Parameters.AddWithValue("@VrstaKorisnika", o.VrstaKorisnika);
			cmd.Parameters.AddWithValue("@ImePrezime", o.ImePrezime);
			cmd.Parameters.AddWithValue("@DatumRodjenja", o.DatumRodjenja);
			cmd.Parameters.AddWithValue("@Adresa", o.Adresa);
			cmd.Parameters.AddWithValue("@LokacijaRada", o.LokacijaRada);
			cmd.Parameters.AddWithValue("@DatumZaposljenja", o.DatumZaposljenja);
			cmd.Parameters.AddWithValue("@Napomena", o.Napomena);
			cmd.Parameters.AddWithValue("@Slika", o.Slika);
			cmd.Parameters.AddWithValue("@ID", o.ID);

			connect.Open();

			cmd.ExecuteNonQuery();

			connect.Close();
		}

		private static bool proveraKorisnikaZaReset(Osoba o)
		{
			connect.Open();
			string sql = "SELECT * FROM Login WHERE KorisnickoIme = @KorisnickoIme AND Lozinka = @Lozinka";
			OleDbCommand cmd = new OleDbCommand(sql, connect);
			cmd.Parameters.AddWithValue("@KorisnickoIme", o.KorisnickoIme);
			cmd.Parameters.AddWithValue("@Lozinka", hashLozinka(o.Lozinka));

			OleDbDataReader reader = cmd.ExecuteReader();
			if (reader.Read())
			{
				connect.Close();
				return true;
			}
			else
			{
				connect.Close();
				return false;
			}
		}

		public static bool resetLozinku(Osoba o, string novasifra)
		{
			if (proveraKorisnikaZaReset(o))
			{
				string sql = "UPDATE Login SET [Lozinka] = @Lozinka WHERE [KorisnickoIme] = @KorisnickoIme";
				OleDbCommand cmd = new OleDbCommand(sql, connect);
				cmd.Parameters.Add("@Lozinka", OleDbType.Char).Value = hashLozinka(novasifra);
				cmd.Parameters.Add("@KorisnickoIme", OleDbType.Char).Value = o.KorisnickoIme;

				connect.Open();

				int rows = cmd.ExecuteNonQuery();

				connect.Close();

				if (rows > 0)
					return true;
				return false;
			}
			else return false;
		}

		public static void dodajSmenu(Smena s)
		{
			OleDbCommand cmd = new OleDbCommand("INSERT INTO Smena (Datum, IzborSmene, ID) VALUES(@Datum, @IzborSmene, @ID)", connect);
			cmd.Parameters.AddWithValue("@Datum", s.Datum);
			cmd.Parameters.AddWithValue("@IzborSmene", s.izborSmene);
			cmd.Parameters.AddWithValue("@ID", s.ID);
			connect.Open();

			cmd.ExecuteNonQuery();
			connect.Close();
		}

		public static void azurirajSmenu(Smena s)
		{
			OleDbCommand cmd = new OleDbCommand("UPDATE Smena SET [ID] = @ID WHERE [Datum] = @Datum AND [IzborSmene] = @IzborSmene", connect);
			cmd.Parameters.AddWithValue("@ID", s.ID);
			cmd.Parameters.AddWithValue("@Datum", s.Datum);
			cmd.Parameters.AddWithValue("@IzborSmene", s.izborSmene);

			connect.Open();

			cmd.ExecuteNonQuery();
			connect.Close();
		}

		public static void izbrisiSmenu(Smena s)
		{
			OleDbCommand cmd = new OleDbCommand("DELETE FROM Smena WHERE [ID] = @ID AND [Datum] = @Datum", connect);
			cmd.Parameters.AddWithValue("@ID", s.ID);
			cmd.Parameters.AddWithValue("@Datum", s.Datum);
			connect.Open();

			cmd.ExecuteNonQuery();
			connect.Close();
		}

		public static DataTable SelectSmene()
		{
			DataTable dt = new DataTable();
			String sql = "SELECT * from Smena";
			OleDbCommand cmd = new OleDbCommand(sql, connect);
			OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
			connect.Open();
			adapter.Fill(dt);
			connect.Close();
			return dt;
		}

		public static DataTable SelectSmenu(Smena s)
		{
			DataTable dt = new DataTable();
			String sql = "SELECT * from Smena WHERE Datum = @Datum AND [IzborSmene] = @IzborSmene";
			OleDbCommand cmd = new OleDbCommand(sql, connect);
			cmd.Parameters.AddWithValue("@Datum", s.Datum);
			cmd.Parameters.AddWithValue("@IzborSmene", s.izborSmene);
			OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
			connect.Open();
			adapter.Fill(dt);
			connect.Close();
			return dt;
		}

		public static DataTable SelectSmenuPoIDu(Smena s)
		{
			DataTable dt = new DataTable();
			String sql = "SELECT * from Smena WHERE ID = @ID";
			OleDbCommand cmd = new OleDbCommand(sql, connect);
			cmd.Parameters.AddWithValue("@ID", s.ID);
			OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
			connect.Open();
			adapter.Fill(dt);
			connect.Close();
			return dt;
		}

		public static void unesiVozilo(Vozilo v)
		{
			OleDbCommand cmd = new OleDbCommand("UPDATE Parking SET RegistracioniBrojTablica = @RegistracioniBrojTablica, Vreme = @Vreme, Stanje = @Stanje, Dan = @Dan WHERE ParkingMesto = @ParkingMesto", connect);
			cmd.Parameters.AddWithValue("@RegistracioniBrojTablica", v.RegistracioniBrojTablica);
			cmd.Parameters.AddWithValue("@Vreme", v.Vreme);
			cmd.Parameters.AddWithValue("@Stanje", v.Stanje);
			cmd.Parameters.AddWithValue("@Dan", v.Dan);
			cmd.Parameters.AddWithValue("@ParkingMesto", v.ParkingMesto);
			connect.Open();

			cmd.ExecuteNonQuery();
			connect.Close();
		}

		public static void azurirajVozilo(Vozilo v)
		{
			OleDbCommand cmd = new OleDbCommand("UPDATE Parking SET RegistracioniBrojTablica = @RegistracioniBrojTablica, Vreme = @Vreme, Stanje = @Stanje, Dan = @Dan WHERE ParkingMesto = @ParkingMesto", connect);
			cmd.Parameters.AddWithValue("@RegistracioniBrojTablica", v.RegistracioniBrojTablica);
			cmd.Parameters.AddWithValue("@Vreme", v.Vreme);
			cmd.Parameters.AddWithValue("@Stanje", v.Stanje);
			cmd.Parameters.AddWithValue("@Dan", v.Dan);
			cmd.Parameters.AddWithValue("@ParkingMesto", v.ParkingMesto);

			connect.Open();

			cmd.ExecuteNonQuery();
			connect.Close();
		}

		public static void obrisiVozilo(Vozilo v)
		{
			OleDbCommand cmd = new OleDbCommand("UPDATE Parking SET RegistracioniBrojTablica = @RegistracioniBrojTablica, Vreme = @Vreme, Stanje = @Stanje, Dan = @Dan WHERE ParkingMesto = @ParkingMesto", connect);
			cmd.Parameters.AddWithValue("@RegistracioniBrojTablica", "");
			cmd.Parameters.AddWithValue("@Vreme", "");
			cmd.Parameters.AddWithValue("@Stanje", "");
			cmd.Parameters.AddWithValue("@Dan", "");
			cmd.Parameters.AddWithValue("@ParkingMesto", v.ParkingMesto);
			connect.Open();

			cmd.ExecuteNonQuery();
			connect.Close();
		}

		public static DataTable SelectParking()
		{
			DataTable dt = new DataTable();
			String sql = "SELECT * from Parking";
			OleDbCommand cmd = new OleDbCommand(sql, connect);
			OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
			connect.Open();
			adapter.Fill(dt);
			connect.Close();
			return dt;
		}

		public static DataTable SelectVozilo(Vozilo v)
		{
			DataTable dt = new DataTable();
			String sql = "SELECT * from Parking WHERE ParkingMesto = @ParkingMesto";
			OleDbCommand cmd = new OleDbCommand(sql, connect);
			cmd.Parameters.AddWithValue("@ParkingMesto", v.ParkingMesto);
			OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
			connect.Open();
			adapter.Fill(dt);
			connect.Close();
			return dt;
		}

		public static DataTable SelectVoziloPoTablicama(Vozilo v)
		{
			DataTable dt = new DataTable();
			String sql = "SELECT * from Parking WHERE RegistracioniBrojTablica = @RegistracioniBrojTablica";
			OleDbCommand cmd = new OleDbCommand(sql, connect);
			cmd.Parameters.AddWithValue("@RegistracioniBrojTablica", v.RegistracioniBrojTablica);
			OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
			connect.Open();
			adapter.Fill(dt);
			connect.Close();
			return dt;
		}

		public static DataTable SelectRadnika(Radnik r)
		{
			DataTable dt = new DataTable();
			String sql = "SELECT * from Login WHERE ID = @ID";
			OleDbCommand cmd = new OleDbCommand(sql, connect);
			cmd.Parameters.AddWithValue("@ID", r.ID);
			OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
			connect.Open();
			adapter.Fill(dt);
			connect.Close();
			return dt;
		}

		public static DataTable SelectDirektora(Direktor d)
		{
			DataTable dt = new DataTable();
			String sql = "SELECT * from Login WHERE ID = @ID";
			OleDbCommand cmd = new OleDbCommand(sql, connect);
			cmd.Parameters.AddWithValue("@ID", d.ID);
			OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
			connect.Open();
			adapter.Fill(dt);
			connect.Close();
			return dt;
		}

		public static DataTable SelectOsoba(Osoba o)
		{
			DataTable dt = new DataTable();
			String sql = "SELECT * from Login WHERE ID = @ID";
			OleDbCommand cmd = new OleDbCommand(sql, connect);
			cmd.Parameters.AddWithValue("@ID", o.ID);
			OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
			connect.Open();
			adapter.Fill(dt);
			connect.Close();
			return dt;
		}

		public static void unesiKartu(Karta k)
		{
			OleDbCommand cmd = new OleDbCommand("INSERT INTO Karta (ImePrezime, RegistracioniBrojTablica, TipKarte, Mesec, Godina) VALUES(@ImePrezime, @RegistracioniBrojTablica, @TipKarte, @Mesec, @Godina)", connect);
			cmd.Parameters.AddWithValue("@ImePrezime", k.ImePrezime);
			cmd.Parameters.AddWithValue("@RegistracioniBrojTablica", k.RegistracioniBrojTablica);
			cmd.Parameters.AddWithValue("@TipKarte", k.TipKarte);
			cmd.Parameters.AddWithValue("@Mesec", k.Mesec);
			cmd.Parameters.AddWithValue("@Godina", k.Godina);
			connect.Open();

			cmd.ExecuteNonQuery();
			connect.Close();
		}

		public static void azurirajKartu(Karta k)
		{
			OleDbCommand cmd = new OleDbCommand("UPDATE Karta SET ImePrezime = @ImePrezime, RegistracioniBrojTablica = @RegistracioniBrojTablica, TipKarte = @TipKarte, Mesec = @Mesec, Godina = @Godina WHERE ID = @ID", connect);
			cmd.Parameters.AddWithValue("@ImePrezime", k.ImePrezime);
			cmd.Parameters.AddWithValue("@RegistracioniBrojTablica", k.RegistracioniBrojTablica);
			cmd.Parameters.AddWithValue("@TipKarte", k.TipKarte);
			cmd.Parameters.AddWithValue("@Mesec", k.Mesec);
			cmd.Parameters.AddWithValue("@Godina", k.Godina);
			cmd.Parameters.AddWithValue("@ID", k.ID);
			connect.Open();

			cmd.ExecuteNonQuery();
			connect.Close();
		}

		public static void obrisiKartu(Karta k)
		{
			OleDbCommand cmd = new OleDbCommand("DELETE FROM Karta WHERE [ID] = @ID", connect);
			cmd.Parameters.AddWithValue("@ID", k.ID);
			connect.Open();

			cmd.ExecuteNonQuery();
			connect.Close();
		}

		public static DataTable selectKarte()
		{
			DataTable dt = new DataTable();
			String sql = "SELECT * from Karta";
			OleDbCommand cmd = new OleDbCommand(sql, connect);
			OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
			connect.Open();
			adapter.Fill(dt);
			connect.Close();
			return dt;
		}

		public static DataTable selectKarteZaSearch(string pretraga)
		{
			DataTable dt = new DataTable();
			String sql = "SELECT * FROM Karta WHERE ImePrezime LIKE '%" + pretraga + "%' or RegistracioniBrojTablica LIKE '%" + pretraga + "%'";
			OleDbCommand cmd = new OleDbCommand(sql, connect);
			OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
			connect.Open();
			adapter.Fill(dt);
			connect.Close();
			return dt;
		}

		public static DataTable selectKartuZaProveru(string provera)
		{
			DataTable dt = new DataTable();
			String sql = "SELECT * from Karta WHERE RegistracioniBrojTablica = @RegistracioniBrojTablica";
			OleDbCommand cmd = new OleDbCommand(sql, connect);
			cmd.Parameters.AddWithValue("@RegistracioniBrojTablica", provera);
			OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
			connect.Open();
			adapter.Fill(dt);
			connect.Close();
			return dt;
		}

		public static void unesiKaznu(Kazna k)
		{
			OleDbCommand cmd = new OleDbCommand("INSERT INTO Kazna (ParkingMesto, RegistracioniBrojTablica, Datum, Vreme, Napomena) VALUES(@ParkingMesto, @RegistracioniBrojTablica, @Datum, @Vreme, @Napomena)", connect);
			cmd.Parameters.AddWithValue("@ParkingMesto", k.ParkingMesto);
			cmd.Parameters.AddWithValue("@RegistracioniBrojTablica", k.RegistracioniBrojTablica);
			cmd.Parameters.AddWithValue("@Datum", k.Datum);
			cmd.Parameters.AddWithValue("@Vreme", k.Vreme);
			cmd.Parameters.AddWithValue("@Napomena", k.Napomena);
			connect.Open();

			cmd.ExecuteNonQuery();
			connect.Close();
		}

		public static void azurirajKaznu(Kazna k)
		{
			OleDbCommand cmd = new OleDbCommand("UPDATE Kazna SET ParkingMesto = @ParkingMesto, RegistracioniBrojTablica = @RegistracioniBrojTablica , Datum = @Datum, Vreme = @Vreme AND Napomena = @Napomena WHERE ID = @ID", connect);
			cmd.Parameters.AddWithValue("@ParkingMesto", k.ParkingMesto);
			cmd.Parameters.AddWithValue("@RegistracioniBrojTablica", k.RegistracioniBrojTablica);
			cmd.Parameters.AddWithValue("@Datum", k.Datum);
			cmd.Parameters.AddWithValue("@Vreme", k.Vreme);
			cmd.Parameters.AddWithValue("@Napomena", k.Napomena);
			cmd.Parameters.AddWithValue("@ID", k.ID);
			connect.Open();

			cmd.ExecuteNonQuery();
			connect.Close();
		}

		public static void obrisiKaznu(Kazna k)
		{
			OleDbCommand cmd = new OleDbCommand("DELETE FROM Kazna WHERE ID = @ID", connect);
			cmd.Parameters.AddWithValue("@ID", k.ID);
			connect.Open();

			cmd.ExecuteNonQuery();
			connect.Close();
		} 

		public static DataTable selectKazne()
		{
			DataTable dt = new DataTable();
			String sql = "SELECT * from Kazna";
			OleDbCommand cmd = new OleDbCommand(sql, connect);
			OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
			connect.Open();
			adapter.Fill(dt);
			connect.Close();
			return dt;
		}

		public static DataTable selectKazneZaSearch(string pretraga)
		{
			DataTable dt = new DataTable();
			String sql = "SELECT * FROM Kazna WHERE RegistracioniBrojTablica LIKE '%" + pretraga + "%'";
			OleDbCommand cmd = new OleDbCommand(sql, connect);
			OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
			connect.Open();
			adapter.Fill(dt);
			connect.Close();
			return dt;
		}

		public static DataTable selectStatistika(Statistika s)
		{
			DataTable dt = new DataTable();
			String sql = "SELECT * from Statistika WHERE Mesec = @Mesec AND Godina = @Godina";
			OleDbCommand cmd = new OleDbCommand(sql, connect);
			cmd.Parameters.AddWithValue("@Mesec", s.Mesec);
			cmd.Parameters.AddWithValue("@Godina", s.Godina);
			OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
			connect.Open();
			adapter.Fill(dt);
			connect.Close();
			return dt;
		}

		public static void kreiranjeMeseca(Statistika s)
		{
			OleDbCommand cmd = new OleDbCommand("INSERT INTO Statistika (Mesec, Godina, BrojKarti, Prihod, BrojKazni) VALUES(@Mesec, @Godina, @BrojKarti, @Prihod, @BrojKazni)", connect);
			cmd.Parameters.AddWithValue("@Mesec", s.Mesec);
			cmd.Parameters.AddWithValue("@Godina", s.Godina);
			cmd.Parameters.AddWithValue("@BrojKarti", s.brojKarti);
			cmd.Parameters.AddWithValue("@Prihod", s.Prihod);
			cmd.Parameters.AddWithValue("@BrojKazni", s.brojKazni);
			connect.Open();

			cmd.ExecuteNonQuery();
			connect.Close();
		}

		public static void unosKarteStatistika(Statistika s)
		{
				OleDbCommand cmd = new OleDbCommand("UPDATE Statistika SET BrojKarti = @BrojKarti, Prihod = @Prihod WHERE Mesec = @Mesec AND Godina = @Godina", connect);
				cmd.Parameters.AddWithValue("@BrojKarti", s.brojKarti);
				cmd.Parameters.AddWithValue("@Prihod", s.Prihod);
				cmd.Parameters.AddWithValue("@Mesec", s.Mesec);
				cmd.Parameters.AddWithValue("@Godina", s.Godina);
				connect.Open();

				cmd.ExecuteNonQuery();
				connect.Close();
		}

		public static void unosKazneStatistika(Statistika s)
		{
			OleDbCommand cmd = new OleDbCommand("UPDATE Statistika SET BrojKazni = @BrojKazni WHERE Mesec = @Mesec AND Godina = @Godina", connect);
			cmd.Parameters.AddWithValue("@BrojKazni", s.brojKazni);
			cmd.Parameters.AddWithValue("@Mesec", s.Mesec);
			cmd.Parameters.AddWithValue("@Godina", s.Godina);
			connect.Open();

			cmd.ExecuteNonQuery();
			connect.Close();
		}

		public static void unosSatiStatistika(Statistika s)
		{
			OleDbCommand cmd = new OleDbCommand("UPDATE Statistika SET Prihod = @Prihod WHERE Mesec = @Mesec AND Godina = @Godina", connect);
			cmd.Parameters.AddWithValue("@Prihod", s.Prihod);
			cmd.Parameters.AddWithValue("@Mesec", s.Mesec);
			cmd.Parameters.AddWithValue("@Godina", s.Godina);
			connect.Open();

			cmd.ExecuteNonQuery();
			connect.Close();
		}
	}
}

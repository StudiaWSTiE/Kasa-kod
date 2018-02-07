using System;
using Microsoft.Data.Sqlite;

namespace Kasa
{
    class Administracja

    {
        SqliteCommand cmd;
        bool RFID_Available;

        public bool SprawdzRFID(string RFID)
        {
            
            using (SqliteConnection conn = new SqliteConnection("Filename=Magazyn.sqlite"))
            {
                try
                {
                    conn.Open();
                    cmd = new SqliteCommand();
                    string sql = @"SELECT * FROM Produkty WHERE RFID = '" + RFID + "'";
                    cmd.CommandText = sql;
                    cmd.Connection = conn;
                    SqliteDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        RFID_Available = false;
                    }

                }  
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    RFID_Available = true;
                }
            }

            return RFID_Available;
        }

        public bool DodajProdukt(string nazwa, string RFID, string cena, string jednostka, string vat)
        {
            bool sukces;
            using (SqliteConnection conn = new SqliteConnection("Filename=Magazyn.sqlite"))
            {
                try
                {
                    conn.Open();
                    cmd = new SqliteCommand();
                    string sql = @"INSERT INTO Produkty(Name, RFID, Price, Unit, VAT) VALUES(@name, @RFID, @price, @jednostka, @vat)";
                    cmd.CommandText = sql;
                    cmd.Connection = conn;
                    cmd.Parameters.Add(new SqliteParameter("@name",nazwa));
                    cmd.Parameters.Add(new SqliteParameter("@RFID", RFID));
                    cmd.Parameters.Add(new SqliteParameter("@price", cena));
                    cmd.Parameters.Add(new SqliteParameter("@jednostka", jednostka));
                    cmd.Parameters.Add(new SqliteParameter("@vat", vat));
                    cmd.ExecuteNonQuery();
                    sukces = true;


                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    sukces = false;
                }
            }
                return sukces;
        }

         bool removed;

        public bool UsunProdukt(string RFID)
        {
            using (SqliteConnection conn = new SqliteConnection("Filename=Magazyn.sqlite"))
            {
                try
                {
                    conn.Open();
                    cmd = new SqliteCommand();
                    string sql = @"DELETE FROM Produkty WHERE RFID= '" + RFID + "'";
                    cmd.CommandText = sql;
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    removed = true;
                }
                catch (Exception e)
                {
                    removed = false; 
                    Console.WriteLine(e.Message);
                    
                }
            }

            return removed;
        }

        bool updated;

        public bool AktualizujProdukt(string nazwa, string RFID, string cena, string jednostka, string vat)
        {
            using (SqliteConnection conn = new SqliteConnection("Filename=Magazyn.sqlite"))
            {
                try
                {
                    conn.Open();
                    cmd = new SqliteCommand();
                    string sql = @"UPDATE Produkty SET Name = @name, RFID = @RFID, Price = @price, Unit = @jednostka, VAT = @vat WHERE RFID ='" + RFID + "'";
                    cmd.CommandText = sql;
                    cmd.Connection = conn;
                    cmd.Parameters.Add(new SqliteParameter("@name", nazwa));
                    cmd.Parameters.Add(new SqliteParameter("@RFID", RFID));
                    cmd.Parameters.Add(new SqliteParameter("@price", cena));
                    cmd.Parameters.Add(new SqliteParameter("@jednostka", jednostka));
                    cmd.Parameters.Add(new SqliteParameter("@vat", vat));
                    cmd.ExecuteNonQuery();
                    updated = true;
                }
                catch (Exception e)
                {
                    updated = false;
                    Console.WriteLine(e.Message);
                }
            }
            return updated;
        }
    }
}

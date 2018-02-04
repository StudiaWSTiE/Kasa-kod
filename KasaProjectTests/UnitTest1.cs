using System;
using Microsoft.Data.Sqlite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KasaProjectTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var conn = new SqliteConnection("Filename = Magazyn.sqlite"))
            {
                //var sql = @"INSERT INTO Produkty (Name, RFID, Price, Unit, VAT) values (@name, @RFID, @price, @unit, @vat)";
                var sql = String.Format(
                    $"INSERT INTO Produkty (Name, RFID, Price, Unit, VAT) values ( '{0}', '{1}', '{2}', '{3}', '{4}')",
                    "sdrgf", "sdgfsd", 345, "gfsht", "A");
                //var sql = "select * from Produkty";
                conn.Open();
                using (var command = new SqliteCommand(sql, conn))
                {
                    //command.Connection = conn;
                    //command.Connection.Open();
                    //command.Parameters.Add(new SqliteParameter("@name", Nazwa.Text));
                    //// command.Parameters.Add("@name", SqliteType.Text).Value = Nazwa.Text;
                    //command.Parameters.Add(new SqliteParameter("@RFID", RFID.Text));
                    //command.Parameters.Add(new SqliteParameter("@price", Cena.Text));
                    //command.Parameters.Add(new SqliteParameter("@unit", Jednostka.Text));
                    //command.Parameters.Add(new SqliteParameter("@vat", VATcat));
                    //db.Open();
                    object result = command.ExecuteReader();
                    //MessageBox.Show("Pomyślnie dodano produkt " + Nazwa.Text + " do bazy danych", "Dodano produkt");
                    //command.Cancel();
                    //command.Dispose();

                }
            }
        }
    }
}

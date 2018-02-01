using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using Microsoft.Data.Sqlite;


namespace Kasa
{
    public partial class AddProduct : Form
    {
        //SqliteConnection db = new SqliteConnection("Filename=Magazyn.sqlite");
        public AddProduct()
        {
            InitializeComponent();
           // db.Open();
        }
        
         
            
         
        private void AddProduct_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string VATcat = "0";
            if (radioButton1.Checked)
            {
                VATcat = "A";
            }
            else if (radioButton2.Checked)
            {
                VATcat = "B";
            }
            else
            {
                VATcat = "C";
            }

            try
            {
                using (SqliteConnection db = new SqliteConnection("Filename = Magazyn.sqlite"))
                {
                    db.Open();
                    string sqlCheck = "select * from Produkty WHERE RFID='" + RFID.Text + "'";
                    using (SqliteCommand cmd = new SqliteCommand(sqlCheck, db))
                    {
                        using (SqliteDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                MessageBox.Show("W bazie produktów jest już produkt o podanym tagu RFID", "Wykryto duplikat");
                                RFID.Clear();
                            }
                            else
                            {
                               
                                string sql = @"INSERT INTO Produkty (Name, RFID, Price, Unit, VAT) values (@name, @RFID, @price, @unit, @vat)";
                                using (SqliteCommand command = new SqliteCommand(sql, db))
                                {
                                    
                                    command.CommandText = sql;
                                    command.Connection = db;
                                    command.Parameters.Add(new SqliteParameter("@name", Nazwa.Text));
                                    command.Parameters.Add(new SqliteParameter("@RFID", RFID.Text));
                                    command.Parameters.Add(new SqliteParameter("@price", Cena.Text));
                                    command.Parameters.Add(new SqliteParameter("@unit", Jednostka.Text));
                                    command.Parameters.Add(new SqliteParameter("@vat", VATcat));
                                    command.ExecuteNonQuery();
                                    MessageBox.Show("Pomyślnie dodano produkt " + Nazwa.Text + " do bazy danych", "Dodano produkt");
                                    
                                }
                            }
                           
                        }
                        
                    }
                    db.Close();
                }
                
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            /*
            using (SqliteConnection db = new SqliteConnection("Filename = Magazyn.sqlite"))
            {
                try
                {
                    db.Open();
                    SqliteCommand cmd = new SqliteCommand();
                    string sqlCheck = "select * from Produkty WHERE RFID='" + RFID.Text + "'";
                    cmd.CommandText = sqlCheck;
                    cmd.Connection = db;
                    SqliteDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        MessageBox.Show("W bazie produktów jest już produkt o podanym tagu RFID", "Wykryto duplikat");
                        RFID.Clear();
                    }
                    else
                    {
                        db.Open();
                        SqliteCommand command = new SqliteCommand();
                        string sql =
                            @"INSERT INTO Produkty (Name, RFID, Price, Unit, VAT) values (@name, @RFID, @price, @unit, @vat)";
                        command.CommandText = sql;
                        command.Connection = db;
                        command.Parameters.Add(new SqliteParameter("@name", Nazwa.Text ));
                        command.Parameters.Add(new SqliteParameter("@RFID", RFID.Text ));
                        command.Parameters.Add(new SqliteParameter("@price", Cena.Text ));
                        command.Parameters.Add(new SqliteParameter("@unit", Jednostka.Text ));
                        command.Parameters.Add(new SqliteParameter("@vat", VATcat ));
                        command.ExecuteNonQuery();
                    }

                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    throw;
                }
            } */


          /*  string sqlCheck = "select * from Produkty WHERE RFID='" + RFID.Text + "'";
            SqliteCommand cmd = new SqliteCommand(sqlCheck, db);
            SqliteDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                MessageBox.Show("W bazie produktów jest już produkt o podanym tagu RFID", "Wykryto duplikat");
                RFID.Clear();
            }
            else
            {
              reader.Dispose();
                reader.Close();
                db.Dispose();

               
                // Dodanie produktu do bazy danych
                string sql = "INSERT INTO Produkty (Name, RFID, Price, Unit, VAT) values ('" + Nazwa.Text + "','" +
                             RFID.Text + "','" + Cena.Text + "','" + Jednostka.Text + "','" + VATcat + "');";

                cmd = new SqliteCommand(sql, db);
                db.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Pomyślnie dodano produkt " + Nazwa.Text, "Dodano produkt");

            } */
        }


    }
}

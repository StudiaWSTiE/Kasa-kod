using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace Kasa
{
    public partial class AdminPanel : Form
    {
        SqliteConnection db = new SqliteConnection("Filename=Magazyn.sqlite");

        public AdminPanel()
        {
            InitializeComponent();
            db.Open();
            button1_Click(this, null);
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            var count = 0;
            string SQLcheck = "select * from Administrator" ;
            SqliteCommand cmd = new SqliteCommand(SQLcheck, db);


            SqliteDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                count = count + 1;
            }

            if (count > 0 && textBox1 != null && !string.IsNullOrWhiteSpace(textBox1.Text))
            {
                

                string sql = "select * from Administrator WHERE Name='" + textBox1.Text + "' AND Password ='" +textBox2.Text + "'";


                SqliteCommand command = new SqliteCommand(sql, db);


                SqliteDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    MessageBox.Show(textBox1.Text + ", zostałeś pomyślnie zalogowany", "Logowanie");
                    AddProduct a = new AddProduct();
                    a.ShowDialog();
                    this.Close();
                    return;
                }
                else
                {
                    MessageBox.Show("Nie ma administratora o loginie " + textBox1.Text + " lub Twoje hasło jest niepoprawne", "Błąd logowania");
                    textBox1.Clear();
                    textBox2.Clear();
                }
            }
            else if (count == 0)
            {
                MessageBox.Show("W systemie nie istnieje konto administratora - nastąpi przekierowanie do formularza rejestracyjnego", "Pierwsze logowania - konieczna rejestracja");
                AddAdmin a = new AddAdmin();
                a.ShowDialog();
                return;
            }         
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {

        }
    }
}
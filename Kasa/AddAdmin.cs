using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace Kasa
{
    public partial class AddAdmin : Form
    {
        SqliteConnection db = new SqliteConnection("Filename=Magazyn.sqlite");
        public AddAdmin()
        {
            InitializeComponent();
            this.db.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1 != null && !string.IsNullOrWhiteSpace(textBox1.Text))
            {
                if (textBox2 != null && !string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    if (textBox2.Text == textBox3.Text)
                    {
                        string sql = "INSERT INTO Administrator (Name, Password) values ('" + textBox1.Text + "','" + textBox2.Text + "');";

                        // Umieszczenie zapytania SQL w komedzie SQLite
                        SqliteCommand command = new SqliteCommand(sql, this.db);

                        // Wykonanie zapytania na bazie danych
                        command.ExecuteReader();
                    }
                    else
                    {
                        MessageBox.Show("Hasła muszą być identyczne", "Różne hasła");
                    }
                }
                else
                {
                    MessageBox.Show("Pole hasło nie może być puste lub wypełnione spacjami", "Niepoprawna forma hasła");
                }

            }
            else
            {
                MessageBox.Show("Nazwa użytkownika nie może być pusta lub wypełniona spacjami", "Niepoprawna nazwa użytkownika");
            }

            MessageBox.Show("Pomyślnie dodano administratora systemu", "Dodawanie administatora");
        }
    }
}

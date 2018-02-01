using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace Kasa
{
    public partial class AddAdmin : Form
    {
       
        public AddAdmin()
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqliteConnection db = new SqliteConnection("Filename=Magazyn.sqlite"))
                {
                    db.Open();
                    string sql = "INSERT INTO Administrator (Name, Password) values ('" + textBox1.Text + "','" + textBox2.Text + "');";
                    using (SqliteCommand cmd = new SqliteCommand(sql, db))
                    {                                                
                            if (textBox1 != null && !string.IsNullOrWhiteSpace(textBox1.Text))
                            {
                                if (textBox2 != null && !string.IsNullOrWhiteSpace(textBox2.Text))
                                {
                                    if (textBox2.Text == textBox3.Text)
                                    {
                                        using (SqliteDataReader reader = cmd.ExecuteReader())
                                        {
                                            MessageBox.Show("Pomyślnie dodano administratora systemu", "Dodawanie administatora");
                                        }                                            
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
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }          
        }
    }
}


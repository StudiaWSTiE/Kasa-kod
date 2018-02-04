using System;
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
                            if (!string.IsNullOrWhiteSpace(textBox1?.Text))
                            {
                                if (!string.IsNullOrWhiteSpace(textBox2?.Text))
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

        private void AddAdmin_Load(object sender, EventArgs e)
        {

        }
    }
}


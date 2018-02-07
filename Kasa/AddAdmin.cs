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
        {   // Kod umożliwia założenie konta administratora
            try
            {
                using (SqliteConnection db = new SqliteConnection("Filename=Magazyn.sqlite"))
                {
                    db.Open();
                    string sql = "INSERT INTO Administrator (Name, Password) values ('" + textBox1.Text + "','" + textBox2.Text + "');";
                    using (SqliteCommand cmd = new SqliteCommand(sql, db))
                    {   // Sprawdzenie poprawności podanych danych                                       
                        if (!string.IsNullOrWhiteSpace(textBox1?.Text)) 
                            {
                            if (!string.IsNullOrWhiteSpace(textBox2?.Text))
                                {
                                if (textBox2.Text == textBox3.Text)
                                    {
                                        using (cmd.ExecuteReader())
                                        {
                                            MessageBox.Show("Pomyślnie dodano administratora systemu", "Dodawanie administatora", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                else
                                    {
                                        MessageBox.Show("Hasła muszą być identyczne", "Różne hasła", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                            }
                            else
                                {
                                    MessageBox.Show("Pole hasło nie może być puste lub wypełnione spacjami", "Niepoprawna forma hasła", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        else
                            {
                                MessageBox.Show("Nazwa użytkownika nie może być pusta lub wypełniona spacjami", "Niepoprawna nazwa użytkownika", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }                        
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                
            }          
        }

        private void AddAdmin_Load(object sender, EventArgs e)
        {

        }
    }
}


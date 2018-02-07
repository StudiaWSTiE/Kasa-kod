using System;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace Kasa
{
    public partial class AdminPanel : Form
    {
      

        public AdminPanel()
        {
            InitializeComponent();
            button1_Click(this, null);
        }

        
        private void button1_Click(object sender, EventArgs e)
        {   
            // Kod sprawdza tabelę Administrator - spełnia zadanie prostego formularza logowania lub przekierowuje do panelu rejestracji
            try
            {
                using (SqliteConnection db = new SqliteConnection("Filename=Magazyn.sqlite"))
                {
                    db.Open();
                    string SQLcheck = "select * from Administrator";
                    using (SqliteCommand cmd = new SqliteCommand(SQLcheck, db))
                    {
                        using (SqliteDataReader reader = cmd.ExecuteReader())
                        {
                            var count = 0;
                            while (reader.Read())
                            {
                                count = count + 1;
                            }

                            if (count > 0 && textBox1 != null && !string.IsNullOrWhiteSpace(textBox1.Text))
                            {
                                string sql = "select * from Administrator WHERE Name='" + textBox1.Text +
                                             "' AND Password ='" + textBox2.Text + "'";
                                using (SqliteCommand command = new SqliteCommand(sql, db))
                                {
                                    using (SqliteDataReader rdr = command.ExecuteReader())
                                    {
                                        if (rdr.Read())
                                        {
                                            MessageBox.Show(textBox1.Text + ", zostałeś pomyślnie zalogowany", "Logowanie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                         
                                            SelectPanel s = new SelectPanel();
                                           
                                            s.Show();

                                            Close();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Nie ma administratora o loginie " + textBox1.Text +" lub Twoje hasło jest niepoprawne", "Błąd logowania",MessageBoxButtons.OK,MessageBoxIcon.Error);
                                            textBox1.Clear();
                                            textBox2.Clear();                                                                                       
                                        }
                                        
                                       
                                    }
                                  
                                }
                            }
                            else if (count == 0)
                            {
                                MessageBox.Show("W systemie nie istnieje konto administratora - nastąpi przekierowanie do formularza rejestracyjnego", "Pierwsze logowania - konieczna rejestracja",MessageBoxButtons.OK, MessageBoxIcon.Information);
                                AddAdmin a = new AddAdmin();
                                a.ShowDialog();                             
                            }                                                                                
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

        private void AdminPanel_Load(object sender, EventArgs e)
        {

        }
    }
}
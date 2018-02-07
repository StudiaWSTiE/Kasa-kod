using System;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;



namespace Kasa
{
    public partial class CheckRFID : Form
    {
       
        public CheckRFID()
        {
            InitializeComponent();
           
        }
        
         
            
         
        private void AddProduct_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {   // Kod sprawdza dostępność tagu RFID w bazie danych
            try
            {
                using (SqliteConnection db = new SqliteConnection("Filename = Magazyn.sqlite"))
                {
                    db.Open();
                    string sqlCheck = $"select * from Produkty WHERE RFID='{RFID.Text}'";
                    using (SqliteCommand cmd = new SqliteCommand(sqlCheck, db))
                    {
                        using (SqliteDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                MessageBox.Show("Podany tag RFID jest już przypisany do produktu", "RFID w użyciu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                RFID.Clear();                                
                            }
                            else
                            {
                                MessageBox.Show("W bazie nie widnieje produkt o podanym tagu RFID", "Nie znaleziono powiązanego produktu",MessageBoxButtons.OK, MessageBoxIcon.Information);
                                RFID.Clear();
                                cmd.Cancel();                                                               
                            }                         
                        }                        
                    }                    
                }            
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);               
            }          
        }
    }
}

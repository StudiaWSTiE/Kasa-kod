using System;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace Kasa
{
    public partial class ParagonList : Form
    {
        public ParagonList()
        {
            InitializeComponent();
            LoadData();
        }

        private void ParagonList_Load(object sender, EventArgs e)
        {

        }

        private SqliteCommand cmd;
        // Załadowanie aktualnej tabeli paragonów
        private void LoadData()
        {
            using (SqliteConnection conn = new SqliteConnection("Filename=Magazyn.sqlite"))
            {
                try
                {
                    conn.Open();
                    cmd = new SqliteCommand();
                    string sql = @"SELECT * FROM Paragony ORDER BY id DESC";
                    cmd.CommandText = sql;
                    cmd.Connection = conn;
                    SqliteDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        dataGridParagony.Rows.Add(new object[]
                        {
                            reader.GetValue(reader.GetOrdinal("ID")),
                            reader.GetValue(reader.GetOrdinal("Suma")),
                            reader.GetValue(reader.GetOrdinal("VAT")),
                            reader.GetValue(reader.GetOrdinal("Date")),
                        });
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridParagony_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

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
using Org.BouncyCastle.Bcpg.OpenPgp;

namespace Kasa
{
    public partial class ProductList : Form
    {
        public ProductList()
        {
            InitializeComponent();
            
        }

        Administracja admin;

        private void ProductList_Load(object sender, EventArgs e)
        {
            LoadData();
            btnRemove.Enabled = false;
            rb23.Checked = true;
        }
        // Załadowanie aktualnej tabeli produktów
        private SqliteCommand cmd; 
        private void LoadData()
        {
            dataGridProducts.Rows.Clear();
            using (SqliteConnection conn = new SqliteConnection("Filename=Magazyn.sqlite"))
            {
                try
                {
                    conn.Open();
                    cmd = new SqliteCommand();
                    string sql = @"SELECT * FROM Produkty";
                    cmd.CommandText = sql;
                    cmd.Connection = conn;
                    SqliteDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        dataGridProducts.Rows.Add(new object[]
                        {
                            reader.GetValue(reader.GetOrdinal("ID")),
                            reader.GetValue(reader.GetOrdinal("Name")),
                            reader.GetValue(reader.GetOrdinal("RFID")),
                            reader.GetValue(reader.GetOrdinal("Price")),
                            reader.GetValue(reader.GetOrdinal("Unit")),
                            reader.GetValue(reader.GetOrdinal("VAT"))
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

        bool edit = false;
        private void btnEdit_Click(object sender, EventArgs e)
        {
            admin = new Administracja();
            if (!edit)
            {
                edit = true;
                btnRemove.Enabled = true;
                btnAdd.Enabled = false;
                btnEdit.Text = "Zapisz produkt";
            }
            else
            {
                edit = false;
                btnRemove.Enabled = false;
                btnAdd.Enabled = true;
                btnEdit.Text = "Aktualizuj produkt";
                string VAT;
                if (rb5.Checked)
                {
                    VAT = "A";
                }
                else if (rb8.Checked)
                {
                    VAT = "B";
                }
                else
                {
                    VAT = "C";
                }

                if (!admin.SprawdzRFID(txtRFID.Text))
                {
                    if (admin.AktualizujProdukt(txtNazwa.Text, txtRFID.Text, txtCena.Text, txtJednostka.Text, VAT))
                    {
                        MessageBox.Show("Pomyślnie zaaktualizowano produkt!", "Aktualizacja produktu", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                ClearFields();
                LoadData();
            }
        }
        // Dodanie nowego produktu
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string VAT;
            if (rb5.Checked)
            {
                VAT = "A";
            }
            else if (rb8.Checked)
            {
                VAT = "B";
            }
            else
            {
                VAT = "C";
            }

            admin = new Administracja();
            if (txtNazwa.Text != string.Empty
                && txtRFID.Text != string.Empty
                && txtCena.Text != string.Empty
                && txtJednostka.Text != string.Empty)
            {
                    if (!admin.SprawdzRFID(txtRFID.Text))
                {
                    if (admin.DodajProdukt(txtNazwa.Text, txtRFID.Text, txtCena.Text, txtJednostka.Text, VAT))
                    {
                        MessageBox.Show("Pomyślnie dodano produkt do bazy", "Dodano produkt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields();
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Podany tag RFID jest już w bazie danych!", "Wykryto duplikat RFID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtRFID.Clear();
                    }
                }
            }
            else
            {
                MessageBox.Show("Wszystkie pola muszą być wypełnione!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }
        // Funkcja czyszcząca wszytkie pola formularza
        private void ClearFields()
        {
            txtNazwa.Clear();
            txtRFID.Clear();
            txtCena.Clear();
            txtJednostka.Clear();

        }

        string nameIndex;
        private void dataGridProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (edit)
                {
                    nameIndex = dataGridProducts.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txtNazwa.Text = nameIndex;
                    txtRFID.Text = dataGridProducts.Rows[e.RowIndex].Cells[2].Value.ToString();
                    txtCena.Text = dataGridProducts.Rows[e.RowIndex].Cells[3].Value.ToString();
                    txtJednostka.Text = dataGridProducts.Rows[e.RowIndex].Cells[4].Value.ToString();
                }
                
                
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            admin = new Administracja();
            DialogResult result = MessageBox.Show("Czy napewno usunąć produkt z bazy produktów?", "Usuwanie produktu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (txtRFID.Text != string.Empty )
                {
                    if (!admin.SprawdzRFID(txtRFID.Text))
                    {
                        if (admin.UsunProdukt(txtRFID.Text))
                        {
                            MessageBox.Show("Pomyślnie usunięto produkt", "Usuwanie produktu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearFields();
                            LoadData();
                        }
                    }
                    
                }
                else
                {
                    MessageBox.Show("Nie udało się usunąć produkt!", "Błąd usuwania", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
           
        }
    }
}

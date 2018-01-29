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


namespace Kasa
{
    public partial class AddProduct : Form
    {
        public AddProduct()
        {
            InitializeComponent();
        }
        
         
            
         
        private void AddProduct_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string VATcat = "0%";
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
            }/*
            /using (var ef = new kasa())
            {
                var product = ef.Set<Produkty>();
                product.Add(new Produkty { Name = Nazwa.Text, RFID = RFID.Text, Price = Cena.Text, Unit = Jednostka.Text, VAT = VATcat });
                ef.SaveChanges();
            }
            MessageBox.Show("Pomyślnie dodano produkt " + Nazwa.Text + " do bazy danych", "Dodano nowy produkt");
            */
        }

        
    }
}

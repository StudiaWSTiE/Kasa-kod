using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO.Ports;
using System.Collections.ObjectModel;
using System.Linq;

namespace Kasa
{
    public partial class Form1 : Form
    {
        // Inicjalizacja obiektu transakcja, który przechowuje dane o zakupach
        Transakcja trans = null;

        // Flaga blokowania skanowaniu po wciśnięciu sumy
        bool need_ce = false;

        public Form1()
        {
            InitializeComponent();

            // Utworzenie obiektu transakcji, w którym będzie uzupełniana lista zakupów
            trans = new Transakcja();

            // Wypisanie nagłówka paragonu
            print_header();
        }

        // Funkcja obsługi wywołania aktualizacji tekstu w oknie ceny
        public void AppendTextBox(string value)
        {
            // Jeżeli wywołanie jest wymagane
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendTextBox), new object[] { value });
                return;
            }

            // Przypisanie wartości
            textBox1.Text = value;
        }

        // Funkcja obsługi wywołania aktualizacji tekstu w oknie paragonu
        public void AppendRichTextBox(string value)
        {
            // Jeżeli wywołanie jest wymagane
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendRichTextBox), new object[] { value });
                return;
            }

            // Dopisanie linii do istniejących linii okna
            richTextBox1.AppendText(value);
        }

        // Funkcja zamykająca paragon
        private void btnSuma_Click(object sender, EventArgs e)
        {
            if (!need_ce)
            { 
                // Polecenie obliczenia sumy cen z listy zakupionych produktów
                string sum = this.trans.get_sum();

                // Obliczanie wartosci podatku VAT dla poszczeg. stawek, zaokrąglone do 2 miejsc po przecinku (1 gr)
                double vat_A = Math.Round(this.trans.get_vat("A"), 2);
                double vat_B = Math.Round(this.trans.get_vat("B"), 2);
                double vat_C = Math.Round(this.trans.get_vat("C"), 2);

                // Sumaryczna wartość VAT
                double sum_PTU = vat_A + vat_B + vat_C;

                // Dopisanie linii separatora
                richTextBox1.AppendText(" ---------------------------------------\n");

                // Jeżeli kwota podatku VAT A nie jest zerowa, poniższa linia zostanie dopisana do paragonu
                if (vat_A > 0)
                {
                    richTextBox1.AppendText("   VAT A          " + vat_A.ToString() + "\n");
                }

                // Jeżeli kwota podatku VAT B nie jest zerowa, poniższa linia zostanie dopisana do paragonu
                if (vat_B > 0)
                {
                    richTextBox1.AppendText("   VAT B          " + vat_B.ToString() + "\n");
                }

                // Jeżeli kwota podatku VAT C nie jest zerowa, poniższa linia zostanie dopisana do paragonu
                if (vat_C > 0)
                {
                    richTextBox1.AppendText("   VAT C          " + vat_C.ToString() + "\n");
                }

                richTextBox1.AppendText("   Suma PTU:                  " + sum_PTU.ToString() + " zł\n");
            
                // Dopisanie linii separatora
                richTextBox1.AppendText(" ---------------------------------------\n");

                // Suma - należność od klienta
                richTextBox1.AppendText("   SUMA:                      " + sum + " zł");

                // Wypisanie sumy do okna cen
                this.textBox1.Text = sum + " zł";

                // Zapis paragonu do bazy danych
                trans.save_paragon(sum, sum_PTU.ToString());

                // Zablokowanie kolejnego skanowania do momentu wciśnięcia CE
                need_ce = true;
            }

            // Ustawienie focusa na polu skanowania kodów RFID
            this.textBox2.Focus();
        }

        // Funkcja usuwająca ostatnią pozycję na liscie zakupów
        private void btnStorno_Click(object sender, EventArgs e)
        {
            // Ustawianie flagi
            this.trans.storno = true;

            // Ustawienie focusa na polu skanowania kodów RFID
            this.textBox2.Focus();
        }

        // Funkcja wypisująca nagłówek paragonu
        private void print_header()
        {
            // Odczyt ostatniego numeru paragonu
            string paragon_id = trans.get_last_paragon_id();
            int _id = Convert.ToInt16(paragon_id) + 1;

            // Wypisanie domyślnego tekstu paragonu
            richTextBox1.Clear();
            richTextBox1.AppendText("\n");
            richTextBox1.AppendText(" ***************************************\n");
            richTextBox1.AppendText("            Sklep SuperSAM              \n");
            richTextBox1.AppendText("    NIP: 245-245-34-25, ul.Słoneczna 5  \n");
            richTextBox1.AppendText("                 ***                    \n");
            richTextBox1.AppendText(" Data: " + DateTime.Now.ToShortDateString() + "           " + DateTime.Now.ToShortDateString().Replace(".", "") + "/" + _id.ToString() + "\n");
            richTextBox1.AppendText(" ***************************************\n");
            richTextBox1.AppendText("\n");

            // Skasowanie ostatniej ceny
            textBox1.Text = "0,00 zł";
        }

        // Funkcja kasująca całą listę zakupów
        private void btnCe_Click(object sender, EventArgs e)
        {
            // Kasowanie listy zakupów w obiekcie transakcji
            trans.remove_all_positions();

            // Wypisanie nagłówka paragonu
            print_header();

            // Reset flagi wymuszenia kasowania transakcji
            need_ce = false;

            // Ustawienie focusa na polu skanowania kodów RFID
            this.textBox2.Focus();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Kontrola czy wprowadzono cyfry & Blokada do momentu resetu transakcji
            if (this.textBox2.Text.All(char.IsDigit) & (!need_ce))
            {
                // Kontrola czy cyfr jest dokładnie 10
                if (this.textBox2.Text.Length == 10)
                {
                    // Przepisanie zeskanowanego numeru do zmiennej
                    string rfid = this.textBox2.Text;

                    // Dodanie produktu (o odczytanym numerze RFID) do lity zakupów
                    if (trans.add_product_to_list(rfid, this.trans.storno))
                    {
                        // Przechwycenie ceny zwróconej z bazy danych
                        string cena = this.trans.get_price(rfid);

                        // Przechwycenie nazwy produktu zwróconego z bazy danych
                        string nazwa = this.trans.get_name(rfid);

                        // Wypisanie ceny na ekran (okno ceny) 
                        AppendTextBox(cena + " zł");

                        // Wypisanie ceny i nazwy na ekran (okno paragonu)
                        AppendRichTextBox("   " + nazwa + "1x\t" + cena + "\tzł\n");

                        // Kasowanie flagi storno
                        this.trans.storno = false;
                    }
                    // Kasowanie ostatniego zeskanowanego numeru - po dodaniu produktu
                    this.textBox2.Text = "";
                }
            }
            else
            {
                // Kasowanie znaków nie będących cyframi
                this.textBox2.Text = "";
            }
        }

        // Funkcja zmienia focus na czytnik RFID
        private void textBox1_Click(object sender, EventArgs e)
        {
            // Ustawienie focusa na polu skanowania kodów RFID
            this.textBox2.Focus();
        }

        // Funkcja zmienia focus na czytnik RFID
        private void richTextBox1_Click(object sender, EventArgs e)
        {
            // Ustawienie focusa na polu skanowania kodów RFID
            this.textBox2.Focus();
        }

        // Funkcja zmienia focus na czytnik RFID
        private void Form1_Click(object sender, EventArgs e)
        {
            // Ustawienie focusa na polu skanowania kodów RFID
            this.textBox2.Focus();
        }
    }
}

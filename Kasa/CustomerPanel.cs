﻿using System;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Kasa
{
    public partial class CustomerPanel : Form
    {
        // Inicjalizacja obiektu transakcja, który przechowuje dane o zakupach
        Transakcja trans = null;

        // Flaga blokowania skanowaniu po wciśnięciu sumy
        bool need_ce = false;

        public CustomerPanel()
        {
            InitializeComponent();

            // Utworzenie obiektu transakcji, w którym będzie uzupełniana lista zakupów
            trans = new Transakcja();

            // Wypisanie nagłówka paragonu
            Print_header();
        }

        // Funkcja obsługi wywołania aktualizacji tekstu w oknie ceny
        public void AppendTextBox(string value)
        {
            // Jeżeli wywołanie jest wymagane
            if (InvokeRequired)
            {
                Invoke(new Action<string>(AppendTextBox), new object[] { value });
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
                Invoke(new Action<string>(AppendRichTextBox), new object[] { value });
                return;
            }

            // Dopisanie linii do istniejących linii okna
            richTextBox1.AppendText(value);
        }

        // Funkcja zamykająca paragon
        private void BtnSuma_Click(object sender, EventArgs e)
        {
            if (!need_ce)
            { 
                // Polecenie obliczenia sumy cen z listy zakupionych produktów
                string sum = trans.get_sum();

                // Obliczanie wartosci podatku VAT dla poszczeg. stawek, zaokrąglone do 2 miejsc po przecinku (1 gr)
                double vat_A = Math.Round(trans.get_vat("A"), 2);
                double vat_B = Math.Round(trans.get_vat("B"), 2);
                double vat_C = Math.Round(trans.get_vat("C"), 2);

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

                richTextBox1.AppendText("   Suma PTU:                  " + sum_PTU.ToString() + " zl\n");
            
                // Dopisanie linii separatora
                richTextBox1.AppendText(" ---------------------------------------\n");

                // Suma - należność od klienta
                richTextBox1.AppendText("   SUMA:                      " + sum + " zl");

                // Wypisanie sumy do okna cen
                textBox1.Text = sum + " zl";

                // Zapis paragonu do bazy danych
                trans.save_paragon(sum, sum_PTU.ToString());

                // Zablokowanie kolejnego skanowania do momentu wciśnięcia CE
                need_ce = true;

                // Pobranie nr ID paragonu w celu jego zapisu       

                string ParagonId = trans.get_last_paragon_id();
                int TransId = Convert.ToInt16(ParagonId);

                // Zapis paragonu do pliku .PDF
                Document doc = new Document();
                var font = FontFactory.GetFont(BaseFont.CP1257, BaseFont.TIMES_ROMAN);
                PdfWriter.GetInstance(doc, new FileStream("../Paragony/" + TransId + "-" + DateTime.Now.ToShortDateString()+".pdf", FileMode.Create));
                doc.Open();                
                Paragraph p1 = new Paragraph(richTextBox1.Text, font);
                doc.Add(p1);
                doc.Close();
               
            }

            // Ustawienie focusa na polu skanowania kodów RFID
            textBox2.Focus();
        }

        // Funkcja usuwająca ostatnią pozycję na liscie zakupów
        private void BtnStorno_Click(object sender, EventArgs e)
        {
            // Ustawianie flagi
            trans.storno = true;

            // Ustawienie focusa na polu skanowania kodów RFID
            textBox2.Focus();
        }

        // Funkcja wypisująca nagłówek paragonu
        public void Print_header()
        {
            // Odczyt ostatniego numeru paragonu
            string paragon_id = trans.get_last_paragon_id();
            int _id = Convert.ToInt16(paragon_id) + 1;

            // Wypisanie domyślnego tekstu paragonu
            richTextBox1.Clear();
            richTextBox1.AppendText("\n");
            richTextBox1.AppendText(" ***************************************\n");
            richTextBox1.AppendText("            Sklep SuperSAM              \n");
            richTextBox1.AppendText("    NIP: 245-245-34-25, ul.Studencka 1  \n");
            richTextBox1.AppendText("                 ***                    \n");
            richTextBox1.AppendText(" Data: " + DateTime.Now.ToShortDateString() + "           " + DateTime.Now.ToShortDateString().Replace(".", "") + "/" + _id.ToString() + "\n");
            richTextBox1.AppendText(" ***************************************\n");
            richTextBox1.AppendText("\n");

            // Skasowanie ostatniej ceny
            textBox1.Text = "0,00 zl";
        }

        // Funkcja kasująca całą listę zakupów
        private void BtnCe_Click(object sender, EventArgs e)
        {
            // Kasowanie listy zakupów w obiekcie transakcji
            trans.remove_all_positions();

            // Wypisanie nagłówka paragonu
            Print_header();

            // Reset flagi wymuszenia kasowania transakcji
            need_ce = false;

            // Ustawienie focusa na polu skanowania kodów RFID
            textBox2.Focus();
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            // Kontrola czy wprowadzono cyfry & Blokada do momentu resetu transakcji
            if (textBox2.Text.All(char.IsDigit) & (!need_ce))
            {
                // Kontrola czy cyfr jest dokładnie 10
                if (textBox2.Text.Length == 10)
                {
                    // Przepisanie zeskanowanego numeru do zmiennej
                    string rfid = textBox2.Text;

                    // Dodanie produktu (o odczytanym numerze RFID) do lity zakupów
                    if (trans.add_product_to_list(rfid, trans.storno))
                    {
                        // Przechwycenie ceny zwróconej z bazy danych
                        string cena = trans.get_price(rfid);

                        // Przechwycenie nazwy produktu zwróconego z bazy danych
                        string nazwa = trans.get_name(rfid);

                        // Wypisanie ceny na ekran (okno ceny) 
                        AppendTextBox(cena + " zl");

                        // Wypisanie ceny i nazwy na ekran (okno paragonu)
                        AppendRichTextBox("   " + nazwa + "1x\t" + cena + "\tzl\n");

                        // Kasowanie flagi storno
                        trans.storno = false;
                    }
                    // Kasowanie ostatniego zeskanowanego numeru - po dodaniu produktu
                    textBox2.Text = "";
                }
            }
            else
            {
                // Kasowanie znaków nie będących cyframi
                textBox2.Text = "";
            }
        }

        // Funkcja zmienia focus na czytnik RFID
        private void textBox1_Click(object sender, EventArgs e)
        {
            // Ustawienie focusa na polu skanowania kodów RFID
            textBox2.Focus();
        }

        // Funkcja zmienia focus na czytnik RFID
        private void richTextBox1_Click(object sender, EventArgs e)
        {
            // Ustawienie focusa na polu skanowania kodów RFID
            textBox2.Focus();
        }

        // Funkcja zmienia focus na czytnik RFID
        private void Form1_Click(object sender, EventArgs e)
        {
            // Ustawienie focusa na polu skanowania kodów RFID
            textBox2.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

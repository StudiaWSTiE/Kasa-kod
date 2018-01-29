using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace Kasa
{
    // Klasa reprezentująca pojedynczy produkt w zamówieniu
    public class Produkt
    {
        // Pola publiczne
        public string name;
        public string price;
        public string RFID;
        public string vat_category;

        // Konstruktor
        public Produkt(string nazwa, string cena, string _rfid, string _vat)
        {
            name = nazwa;
            price = cena;
            RFID = _rfid;
            vat_category = _vat;
        }
    }

    // Klasa reprezentująca całą transakcję
    class Transakcja
    {
        // Utworzenie klasy konektora do bazy SQLite, wraz ze wstkazaniem pliku
        SqliteConnection db = new SqliteConnection("Filename=Magazyn.sqlite");

        // Utworzenie listy produktów
        List<Produkt> zakupy = new List<Produkt>();

        // Inicjalizacja pola sumy
        double suma = 0;

        // Inicjalizacaja pól wartosci VAT
        public float vat_A = 0;
        public float vat_B = 0;
        public float vat_C = 0;

        // Wskaźnik Storno - do odejmowania produktów od rachunku
       public bool storno = false;

        // Kontruktor
        public Transakcja(){
            // Otwarcie połączenia do bazy danych
            this.db.Open();
        }

        // Funkcja zwraca nazwę produktu uzupełnioną spacjami do stałej szerokości 20 znaków
        public string formated_name(string name)
        {
            string pause = "";
            for (int x = 0; x < 20 - name.Length; x++)
            {
                pause += " ";
            }

            // Funkcja zwraca informację sformatowaną jako string
            return name + pause;
        }

        // Funkcja zwraca ostatni numer ID paragonu zapisanego w bazie
        public string get_last_paragon_id()
        {
            // Wyszukanie w bazie paragonów ostatniego ID
            // Zapytanie SQL:
            string sql = "SELECT ID FROM Paragony ORDER BY id DESC LIMIT 1";

            // Umieszczenie zapytania SQL w komedzie SQLite
            SqliteCommand command = new SqliteCommand(sql, this.db);

            // Wykonanie zapytania na bazie danych
            SqliteDataReader reader = command.ExecuteReader();

            // Odczyt rezultatu zapytania z bazy danych
            if (reader.Read())
            {

                return reader["ID"].ToString();
            }
            else
            {
                return "Null";
            }
        }

        // Rejestruje paragon w bazie danych
        public void save_paragon(string suma, string vat)
        {
            // Data
            string data = DateTime.Now.ToShortDateString();

            // Zapytanie SQL:
            string sql = "INSERT INTO Paragony (Suma, VAT, Date) values ('" + suma + "','" + vat +"','" + data + "');";

            // Umieszczenie zapytania SQL w komedzie SQLite
            SqliteCommand command = new SqliteCommand(sql, this.db);

            // Wykonanie zapytania na bazie danych
            SqliteDataReader reader = command.ExecuteReader();
        }

        // Funkcja dodaje zeskanowany produkt do listy produktów
        public bool add_product_to_list(string RFID, bool storno)
        {
            // Wyszukanie w bazie danych produktu oznaczonego zeskanowanym tagiem RFID
            // Zapytanie SQL:
            string sql = "select * from Produkty where RFID like '%" + RFID + "%'";

            // Umieszczenie zapytania SQL w komedzie SQLite
            SqliteCommand command = new SqliteCommand(sql, this.db);

            // Wykonanie zapytania na bazie danych
            SqliteDataReader reader = command.ExecuteReader();

            // Odczyt rezultatu zapytania z bazy danych
            if (reader.Read())
            {
                string prefix = "";
                if (storno)
                {
                    prefix = "-";
                }
                
                // Utworzenie obiektu pojedynczego produktu na podstawie dancy z bazy danych
                Produkt p = new Produkt(reader["Name"].ToString(), prefix + reader["Price"].ToString(), reader["RFID"].ToString(), reader["VAT"].ToString());

                // Dodanie produktu do listy zakupów
                zakupy.Add(p);

                // Zwraca true jeżeli się powiodło
                return true;
            }
            else
            {
                // Zwraca false, jeśli się nie powiodło
                return false;
            }
        }

        // Funkcja zwracająca cenę produktu o danym tagu RFID z lity zakupów
        public string get_price(string rfid)
        {
            // Zapytanie LINQ  do listy o obiekt o wartości pola RFID przekazanej w parametrze funkcji
            Produkt p = zakupy.LastOrDefault(s => s.RFID.ToString() == rfid.ToString());

            // Funkcja zwraca cenę sformatowaną jako string
            return p.price.ToString();
        }

        // Funkcja zwracająca nazwę produktu o danym tagu RFID z lity zakupów
        public string get_name(string rfid)
        {
            // Zapytanie LINQ  do listy o obiekt o wartości pola RFID przekazanej w parametrze funkcji
            Produkt p = zakupy.FirstOrDefault(s => s.RFID.ToString() == rfid.ToString());

            // Funkcja zwraca nazwę sformatowaną jako string
            return formated_name(p.name.ToString());
        }

        // Funkcja zwracająca obliczoną sumę cen produktów
        public string get_sum()
        {
            // Dla każdego produktu na liście zakupów...
            foreach (Produkt p in this.zakupy){
                // ...dodaj jego cenę do sumy
                this.suma += Convert.ToDouble(p.price);
            }

            // Funkcja zwraca sumę sformatowaną jako string
            return this.suma.ToString();
        }

        // Obliczenie wartości vat dla sumy cen produktów z zadanej kategorii
        public double count_vat_for_category(double price, double vat)
        {
            // Oblicenie vat
            return price - ((price * 100) / (100 + vat));
        }

        // Funkcja zlicza sumę cen produktów w danej kategorii stawki VAT
        public double count_price_sum_in_vat_category(string category)
        {
            // Inicjalizacja
            double price_sum = 0;

            // Pętla zliczająca pobiera w każdym przebiegu po jednym produkcie z listy
            foreach (Produkt p in this.zakupy)
            {
                // Kontrola oczekiwanej kategorii stawki VAT
                if (p.vat_category == category)
                {
                    // Sumowanie
                    price_sum += Convert.ToDouble(p.price);
                }
            }

            return price_sum;
        }

        // Zwraca wartość VAT
        public double get_vat(string category)
        {
            // Inicjalizacja
            double product_price_sum = 0;

            // Przełącznik kategorii stawki VAT
            switch (category)
            {
                // Obliczenia dla stawki A
                case "A":

                    // Suma cen produktów w tej kategorii
                    product_price_sum = count_price_sum_in_vat_category("A");
                    
                    // Zwraca kwotę VAT
                    return count_vat_for_category(product_price_sum, 5.00);

                // Obliczenia dla stawki B
                case "B":

                    // Suma cen produktów w tej kategorii
                    product_price_sum = count_price_sum_in_vat_category("B");

                    // Zwraca kwotę VAT
                    return count_vat_for_category(product_price_sum, 8.00);

                // Obliczenia dla stawki AB
                case "C":

                    // Suma cen produktów w tej kategorii
                    product_price_sum = count_price_sum_in_vat_category("C");

                    // Zwraca kwotę VAT
                    return count_vat_for_category(product_price_sum, 23.00);

                default:
                    return 0;
            }
        }

        // Funkcja usuwa wszystkie zakupy z listy
        public bool remove_all_positions()
        {
            // Kasowanie listy zakupów
            this.zakupy.Clear();

            // Zerowanie wartości VAT
            this.vat_A = 0;
            this.vat_B = 0;
            this.vat_C = 0;

            // Zerowanie sumy należności
            this.suma = 0;

            // Kasowanie flagi storno
            this.storno = false;

            // Zwraca true
            return true;
        }
    }

}

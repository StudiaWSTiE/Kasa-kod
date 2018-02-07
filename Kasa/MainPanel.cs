using System;
using System.Windows.Forms;

namespace Kasa
{
    public partial class MainPanel : Form
    {
        // Ekran powitalny aplikacji
        public MainPanel()
        {
            InitializeComponent();

        }

        private void CustomerPanel_Click(object sender, EventArgs e)
        {
            // Przekierowanie do panelu klienta i symulacji zakupów w sklepie
            CustomerPanel f = new CustomerPanel() ;
            f.Show();
            WindowState = FormWindowState.Minimized;
        }

        private void MainPanel_Load(object sender, EventArgs e)
        {

        }

        private void AdminPanel_Click(object sender, EventArgs e)
        {
            // Przekierowanie do panelu administrtora, z którego można zarządzać bazą danych
            AdminPanel a = new AdminPanel();
            a.Show();
            WindowState = FormWindowState.Minimized;

        }
    }
}

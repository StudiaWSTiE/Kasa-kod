using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kasa
{
    public partial class MainPanel : Form
    {
        
        public MainPanel()
        {
            InitializeComponent();

        }

        private void CustomerPanel_Click(object sender, EventArgs e)
        {

            Form1 f = new Form1() ;
            f.Show();
            this.WindowState = FormWindowState.Minimized;
        }

        private void MainPanel_Load(object sender, EventArgs e)
        {

        }

        private void AdminPanel_Click(object sender, EventArgs e)
        {
            AdminPanel a = new AdminPanel();
            a.Show();
            this.WindowState = FormWindowState.Minimized;

        }
    }
}

using System;
using System.Windows.Forms;

namespace Kasa
{
    public partial class SelectPanel : Form
    {
        public SelectPanel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckRFID c = new CheckRFID();
            c.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProductList p = new ProductList();
            p.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ParagonList pp = new ParagonList();
            pp.Show();
        }

        private void SelectPanel_Load(object sender, EventArgs e)
        {

        }
    }
}

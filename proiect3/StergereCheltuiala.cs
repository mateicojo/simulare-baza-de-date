using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proiect3
{
    
    public partial class StergereCheltuiala : Form
    {
        cheltuiala[] cheltuieli;
        int nrCheltuieli;
        public StergereCheltuiala(cheltuiala[] cheltuieli, int nrCheltuieli)
        {
            this.nrCheltuieli = nrCheltuieli;
            this.cheltuieli = cheltuieli;
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            int val = Int32.Parse(textBox1.Text);//va primi numarul de ordine a cheltuielii de sters;
            for (int i = val; i < nrCheltuieli; i++)
            {
                cheltuieli[i] = cheltuieli[i + 1];
            }
            nrCheltuieli--;
            
            System.Windows.Forms.MessageBox.Show($"Cheltuiala numarul {val} a fost stearsa!");
            this.Close();
        }

    }
}

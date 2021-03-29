using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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
        public void scriereInFisier()
        {
            File.WriteAllText("C:/Users/mok_a/source/repos/proiect3/proiect3/bazaDeDate.txt", String.Empty);
            StreamWriter sw = new StreamWriter("C:/Users/mok_a/source/repos/proiect3/proiect3/bazaDeDate.txt");
            for (int i = 0; i < nrCheltuieli; i++)
            {
                sw.WriteLine($"{cheltuieli[i].ziua},{cheltuieli[i].luna},{cheltuieli[i].suma},{cheltuieli[i].tip}");
            }
            sw.Close();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {

            //int val = Int32.Parse(textBox1.Text);
            int val;
            if(Int32.TryParse(textBox1.Text, out val))
            {
                if (val >= nrCheltuieli)
                {
                    System.Windows.Forms.MessageBox.Show($"Valoarea precizata nu exista!");
                    this.Close();
                    return;
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show($"Data introdusa nu este un numar intreg!");
                this.Close();
                return;
            }
            for (int i = val; i < nrCheltuieli; i++)
            {
                cheltuieli[i] = cheltuieli[i + 1];
            }
            nrCheltuieli--;
            scriereInFisier();
            System.Windows.Forms.MessageBox.Show($"Cheltuiala numarul {val} a fost stearsa!");
            this.Close();
        }

    }
}

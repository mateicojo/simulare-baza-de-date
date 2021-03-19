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
    struct cheltuiala
    {
        public int ziua;
        public int luna;
        public int suma;
        public string tip;
    }
    partial class Form1 : Form
    {
        int nrCheltuieli = 0;
        public cheltuiala[] cheltuieli = new cheltuiala[50];
        private void curataStruct()//FIXME: daca apar probleme uita te aici
        {
            for (int i = 0; i < cheltuieli.Length; i++)
            {
                cheltuieli[i] = new cheltuiala();
            }
            nrCheltuieli = 0;
        }

        private void citireDinFisier()//FIXME: tipul primeste si un \n
        {
            string readText = File.ReadAllText("C:/Users/mok_a/source/repos/proiect3/proiect3/bazaDeDate.txt");
            this.curataStruct();
            string[] args = readText.Split('\n');

            for(int i = 0; i < args.Length-1; i++)
            {
                string[] temp = args[i].Split(',');
                cheltuieli[i].ziua = Int32.Parse(temp[0]);
                cheltuieli[i].luna = Int32.Parse(temp[1]);
                cheltuieli[i].suma = Int32.Parse(temp[2]);
                
                cheltuieli[i].tip = temp[3].Trim(new char[] {'\n',' '});
                nrCheltuieli++;
            }
        }

        public Form1()
        {
            ;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e) //6
        {
            Form2 Tabel = new Form2();
            Tabel.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void citireButton_Click(object sender, EventArgs e)//10
        {
            Form2 Tabel = new Form2();
            Tabel.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)//2
        {
            citireDinFisier();
            for(int i = 0; i < nrCheltuieli; i++)
            {
                Console.WriteLine((i + 1) + " " + cheltuieli[i].ziua + " " + cheltuieli[i].luna + " " + cheltuieli[i].suma + " " + cheltuieli[i].tip);
            }
        }
    }
}

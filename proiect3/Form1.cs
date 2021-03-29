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
    public struct cheltuiala
    {
        public int ziua;
        public int luna;
        public int suma;
        public string tip;
    }
    partial class Form1 : Form
    {
        public cheltuiala aux;
        public int nrCheltuieli = 0;
        public cheltuiala[] cheltuieli = new cheltuiala[50];
        private void curataStruct()//FIXME: daca apar probleme uita te aici
        {
            for (int i = 0; i < cheltuieli.Length; i++)
            {
                cheltuieli[i] = new cheltuiala();
            }
            nrCheltuieli = 0;
        }

        private void curataFisier()
        {
            File.WriteAllText("C:/Users/mok_a/source/repos/proiect3/proiect3/bazaDeDate.txt", String.Empty);
        }

        private void scriereInFisier()
        //TODO: functie de curatare fisierul bazaDeDate.txt si scrierea datelor din struct despartite prin "\n" + ", " dupa fiecare element;
        {
            citireDinFisier();//updateaza din nou struct ul just to be sure;
            curataFisier(); //dezactivat pana se rezolva ca sa nu stearga textul din fisier fara sa scrie nimic
            StreamWriter sw = new StreamWriter("C:/Users/mok_a/source/repos/proiect3/proiect3/bazaDeDate.txt");
            for (int i = 0; i < nrCheltuieli; i++)
            {
                //aici apare eroarea;
                sw.WriteLine($"{cheltuieli[i].ziua},{cheltuieli[i].luna},{cheltuieli[i].suma},{cheltuieli[i].tip}");
            }
            sw.Close();
        }
        private void citireDinFisier()
        //FIXME: tipul primeste si un \n -> line 67
        //
        //Apeleaza mereu la operatii pe vector de cheltuieli(updateaza datele) (pare sa fie fixed)
        //
        //FIXME2: fisierul ramane deschis si nu poate fi folosit de alt proces;
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
                temp[3] = temp[3].Remove(temp[3].Length - 1, 1);//pare sa functioneze
                cheltuieli[i].tip = temp[3];
                nrCheltuieli++;
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e) //6
        {
            AdaugaCheltuiala Tabel = new AdaugaCheltuiala();
            Tabel.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)//10
        {
            System.Windows.Forms.Application.Exit();
        }

        private void citireButton_Click(object sender, EventArgs e)
        {
            AdaugaCheltuiala Tabel = new AdaugaCheltuiala();
            Tabel.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)//2
        {
            citireDinFisier();
            for(int i = 0; i < nrCheltuieli; i++)
            {
                Console.WriteLine((i + 1) + " " + cheltuieli[i].ziua + " " + cheltuieli[i].luna + " " + cheltuieli[i].suma + " " + cheltuieli[i].tip);
            }
            TableForm tf = new TableForm(cheltuieli,nrCheltuieli);
            tf.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)//afisarea facturilor
        {

        }

        private void button4_Click(object sender, EventArgs e)//4 ordonarea
        {
            //TODO: scriere in fisier (line35): curata bazaDeDate.txt si scrie elementele struct-ului astfel incat sa poata fi afisate din nou;
            citireDinFisier();
            for(int i = 0; i < nrCheltuieli; i++)//ordonarea merge bine
            {
                for(int j = i + 1; j < nrCheltuieli; j++)
                {
                    if (String.Compare(cheltuieli[i].tip, cheltuieli[j].tip, StringComparison.Ordinal) > 0)
                    {
                        aux = cheltuieli[i];
                        cheltuieli[i] = cheltuieli[j];
                        cheltuieli[j] = aux;
                    }
                    if(String.Equals(cheltuieli[i].tip,cheltuieli[j].tip, StringComparison.OrdinalIgnoreCase))
                        if (cheltuieli[i].suma < cheltuieli[j].suma)
                        {
                            aux = cheltuieli[i];
                            cheltuieli[i] = cheltuieli[j];
                            cheltuieli[j] = aux;
                        }
                }
            }
            scriereInFisier();
            for (int i = 0; i < nrCheltuieli; i++)//afisare in consola
            {
                Console.WriteLine((i + 1) + " " + cheltuieli[i].ziua + " " + cheltuieli[i].luna + " " + cheltuieli[i].suma + " " + cheltuieli[i].tip);
            }
            System.Windows.Forms.MessageBox.Show("Datele au fost sortate!");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Proiect realizat de: Closca Teodora, Cojocariu Matei si Cotor Ioana");
        }

        private void button5_Click(object sender, EventArgs e)//stergere cheltuiala
        {
            citireDinFisier();
            //FIXME: transmite valoarea din formul StergereCheltuiala
            StergereCheltuiala form3 = new StergereCheltuiala(cheltuieli, nrCheltuieli);
            form3.ShowDialog();


        }

        private void button8_Click(object sender, EventArgs e)//suma cheltuielilor
        {
            citireDinFisier();
            int suma=0;
            for(int i = 0; i < nrCheltuieli; i++)
            {
                suma += cheltuieli[i].suma;
            }
            System.Windows.Forms.MessageBox.Show($"S-au efectuat cheltuieli in valoare de {suma} lei");
        }
    }
}

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
    public partial class Form2 : Form
    {
        public static string ziua = "";
        public static string luna = "";
        public static string suma = "";
        public static string tip = "";
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)//buton de submit
        {

            ziua = textBox1.Text;
            luna = textBox2.Text;
            suma = textBox3.Text;
            tip = textBox4.Text;
            Validator validatorDate = new Validator();
            if (validatorDate.isInputValid(ziua, luna, suma, tip))
            {
                using (StreamWriter outputFile = new StreamWriter("C:/Users/mok_a/source/repos/proiect3/proiect3/bazaDeDate.txt", true))
                {
                    outputFile.WriteLine(ziua + "," + luna + "," + suma + "," + tip);
                }
                Console.WriteLine("Datele au fost introduse!");//pop up
                this.Close();
            }
            else
            {
                Console.WriteLine("Eroare: Datele sunt invalide!");//pop up
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";            }
        }

        public string[] transferFormData()
        {
            string[] rez = new string[4];
            rez[0] = ziua;
            rez[1] = luna;
            rez[2] = suma;
            rez[3] = tip;
            System.Windows.Forms.Application.Exit();
            return rez;
        }

    }
}

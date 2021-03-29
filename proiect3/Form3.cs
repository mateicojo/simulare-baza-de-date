using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//butonu 3

namespace proiect3
{
    public partial class Form3 : Form
    {
        cheltuiala[] cheltuieli;
        int nrCheltuieli;
        public Form3(cheltuiala[] cheltuieli, int nrCheltuieli)
        {
            this.cheltuieli = cheltuieli;
            this.nrCheltuieli = nrCheltuieli;
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TableForm_Load(object sender, EventArgs e)
        {
            DataTable dtt = new DataTable();
            dtt.Columns.Add("Nr", Type.GetType("System.Int32"));
            dtt.Columns.Add("Ziua", Type.GetType("System.Int32"));
            dtt.Columns.Add("Luna", Type.GetType("System.Int32"));
            dtt.Columns.Add("Suma", Type.GetType("System.Int32"));
            int k = 1;
            for (int i = 0; i < nrCheltuieli; i++)
            {
                dtt.Rows.Add(k, cheltuieli[i].ziua, cheltuieli[i].luna, cheltuieli[i].suma, " ");
            }
            dataGridView1.DataSource = dtt;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

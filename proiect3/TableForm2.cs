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
    public partial class TableForm2 : Form
    {
        cheltuiala[] cheltuieli;
        int nrCheltuieli;
        public TableForm2(cheltuiala[] cheltuieli, int nrCheltuieli)
        {
            this.cheltuieli = cheltuieli;
            this.nrCheltuieli = nrCheltuieli;
            InitializeComponent();
        }

        private void TableForm2_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Nr");
            dt.Columns.Add("Ziua");
            dt.Columns.Add("Luna");
            dt.Columns.Add("Suma");
            int k = 1;
            cheltuiala[] facturi=new cheltuiala[30];
            int y = 0;
            for(int i = 0; i < nrCheltuieli; i++)
            {
                if (cheltuieli[i].tip == "factura" || cheltuieli[i].tip == "Factura")
                    facturi[y++] = cheltuieli[i];
            }
            for (int i = 0; i < y; i++)
            {
                    dt.Rows.Add(i+1, facturi[i].ziua, facturi[i].luna, facturi[i].suma);
            }
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

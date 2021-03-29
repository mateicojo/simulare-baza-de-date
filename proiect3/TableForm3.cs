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
    public partial class TableForm3 : Form
    {
        cheltuiala[] cheltuieli = new cheltuiala[30];
        int nrCheltuieli;
        public TableForm3(cheltuiala[] cheltuieli,int nrCheltuieli)
        {
            this.nrCheltuieli = nrCheltuieli;
            this.cheltuieli = cheltuieli;
            InitializeComponent();
        }
        private void TableForm3_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Luna");
            dt.Columns.Add("Ziua");
            dt.Columns.Add("Suma");
            dt.Columns.Add("Tipul");
            cheltuiala[] v=new cheltuiala[12];
            string[] luni = { "ianuarie", "februarie", "martie", "aprilie", "mai", "iunie", "iulie", "august", "septembrie", "octombrie", "noiembrie", "decembrie" };
            for(int i = 0; i < 12; i++)
            {
                v[i].suma = -1;
            }
            for(int i = 0; i < nrCheltuieli; i++)
            {
                if (cheltuieli[i].suma < v[cheltuieli[i].luna - 1].suma || v[cheltuieli[i].luna - 1].suma == -1)
                    v[cheltuieli[i].luna - 1] = cheltuieli[i];
            }
            for(int i = 0; i < 12; i++)
            {
                if(v[i].suma!=-1)
                    dt.Rows.Add(luni[i], v[i].ziua, v[i].suma, v[i].tip);
            }
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

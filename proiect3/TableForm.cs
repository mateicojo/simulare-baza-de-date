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
    public partial class TableForm : Form
    {
        cheltuiala[] cheltuieli;
        int nrCheltuieli;
        public TableForm(cheltuiala[] cheltuieli, int nrCheltuieli)
        {

            this.cheltuieli = cheltuieli;
            this.nrCheltuieli = nrCheltuieli;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableForm));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1155, 481);
            this.dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(157, 492);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(323, 51);
            this.button1.TabIndex = 1;
            this.button1.Text = "Inchide";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TableForm
            // 
            this.ClientSize = new System.Drawing.Size(692, 555);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TableForm";
            this.Text = "Tabel Cheltuieli";
            this.Load += new System.EventHandler(this.TableForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        private void TableForm_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Nr",Type.GetType("System.Int32"));
            dt.Columns.Add("Ziua", Type.GetType("System.Int32"));
            dt.Columns.Add("Luna", Type.GetType("System.Int32"));
            dt.Columns.Add("Suma", Type.GetType("System.Int32"));
            dt.Columns.Add("Tip", Type.GetType("System.String"));
            for(int i = 0; i < nrCheltuieli; i++)
            {
                dt.Rows.Add(i+1, cheltuieli[i].ziua, cheltuieli[i].luna, cheltuieli[i].suma, cheltuieli[i].tip);
            }
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

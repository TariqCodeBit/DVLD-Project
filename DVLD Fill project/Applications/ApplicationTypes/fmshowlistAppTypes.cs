using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business_Logic;

namespace DVLD_Fill_project.ApplicationTypes
{
    public partial class fmshowlistAppTypes : Form
    {
        private  DataTable _dtAppTypes;
        public fmshowlistAppTypes()
        {
            InitializeComponent();
        }

        private void fmshowlistAppTypes_Load(object sender, EventArgs e)
        {
            _dtAppTypes = ClsApplicationTypes.GetAllApplicationTrpes();
            dataGridView1.DataSource = _dtAppTypes;
            labRecord.Text = dataGridView1.Rows.Count.ToString();
            if(dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns[0].HeaderText = "ID";
                dataGridView1.Columns[0].Width = 120;

                dataGridView1.Columns[1].HeaderText = "Titel";
                dataGridView1.Columns[1].Width = 260;

                dataGridView1.Columns[2].HeaderText = "Fees";
                dataGridView1.Columns[2].Width = 120;


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmEditApplicationTypes fmEdit = new fmEditApplicationTypes((int)dataGridView1.CurrentRow.Cells[0].Value);
            fmEdit.ShowDialog();
            fmshowlistAppTypes_Load(null, null);
        }
    }
}

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

namespace DVLD_Fill_project.Applications.TestType
{
    public partial class fmShowListTestTypes : Form
    {
        DataTable _DataT;
        public fmShowListTestTypes()
        {
            InitializeComponent();
        }

        private void fmShowListTestTypes_Load(object sender, EventArgs e)
        {
           

            _DataT = ClsTestTypes.GetAllTestType();
            dataGListData.DataSource = _DataT;
            labRecord.Text = dataGListData.Rows.Count.ToString();

            if (dataGListData.Rows.Count > 0)
            {
                dataGListData.Columns[0].HeaderText = "ID";
                dataGListData.Columns[0].Width = 90;

                dataGListData.Columns[1].HeaderText = "Title";
                dataGListData.Columns[1].Width = 120;

                dataGListData.Columns[2].HeaderText = "Description";
                dataGListData.Columns[2].Width = 270;

                dataGListData.Columns[3].HeaderText = "Fees";
                dataGListData.Columns[3].Width = 90;
             }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmEditTestTypes edit = new fmEditTestTypes((ClsTestTypes.enTestType)dataGListData.CurrentRow.Cells[0].Value);
            edit.ShowDialog();
            fmShowListTestTypes_Load(null, null);
        }
    }
}

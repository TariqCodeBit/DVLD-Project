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

namespace DVLD_Fill_project.Users
{
    public partial class fmShowListUsers : Form
    {

        private static DataTable _dtAllUsers;

        public fmShowListUsers()
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fmAddNewUser fmaddUser = new fmAddNewUser();
            fmaddUser.ShowDialog();
        }
      
        private void fmShowListUsers_Load(object sender, EventArgs e)
        {
            _dtAllUsers = ClsUsers.GetAllDataUsers();
            dataGridView1.DataSource = _dtAllUsers;
            ComFilter.SelectedIndex = 0;
            labRecordes.Text = dataGridView1.Rows.Count.ToString();
            if(dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns[0].HeaderText = "User ID";
                dataGridView1.Columns[0].Width = 70;

                dataGridView1.Columns[1].HeaderText = "Person ID";
                dataGridView1.Columns[1].Width = 70;

                dataGridView1.Columns[2].HeaderText = "Full Name";
                dataGridView1.Columns[2].Width = 200;

                dataGridView1.Columns[3].HeaderText = "User Name";
                dataGridView1.Columns[3].Width = 120;

                dataGridView1.Columns[4].HeaderText = "Is Active";
                dataGridView1.Columns[4].Width = 80;



            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fmUserInfo fmUserinfo = new fmUserInfo((int)dataGridView1.CurrentRow.Cells[0].Value);
            fmUserinfo.ShowDialog();
            fmShowListUsers_Load(null, null);
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmAddNewUser fmAdduser = new fmAddNewUser();
            fmAdduser.ShowDialog();
            fmShowListUsers_Load(null, null);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            // update Mode 
            fmAddNewUser fmAddorUpdate = new fmAddNewUser((int)dataGridView1.CurrentRow.Cells[0].Value);
            fmAddorUpdate.ShowDialog();
            fmShowListUsers_Load(null, null);

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            if(MessageBox.Show("Do you Want Delete this User {"+ (string)dataGridView1.CurrentRow.Cells[2].Value+"}","Question",MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {

                if (ClsUsers.DeleteUser((int)dataGridView1.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("This User Deleted Sucesfully {" + (string)dataGridView1.CurrentRow.Cells[2].Value + "}", "fd", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fmShowListUsers_Load(null, null);
                }
                else
                {
                    MessageBox.Show("User is not delted due to data connected to it.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
            

        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmChangePassword fchangePassword = new fmChangePassword((int)dataGridView1.CurrentRow.Cells[0].Value);
            fchangePassword.ShowDialog();
        }

        private void ComFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ComFilter.Text== "Is Active")
            {
                TBSerche.Visible = false;
                ComIsActive.Visible = true;
                ComIsActive.Focus();
                ComIsActive.SelectedIndex = 0;
            }
            else
            {
                TBSerche.Visible = (ComFilter.Text != "None");
                ComIsActive.Visible = false;
                TBSerche.Text = "";
                TBSerche.Focus();
            }
        }

        private void TBSerche_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(ComFilter.Text == "Person ID" || ComFilter.Text=="User ID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void TBSerche_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (ComFilter.Text)
            {
                case "User ID":
                    FilterColumn = "UserID";
                    break;
                case "UserName":
                    FilterColumn = "UserName";
                    break;

                case "Person ID":
                    FilterColumn = "PersonID";
                    break;


                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            if(TBSerche.Text.Trim()=="" && FilterColumn== "None")
            {
                _dtAllUsers.DefaultView.RowFilter = "";
                labRecordes.Text = dataGridView1.Rows.Count.ToString();
                return;
            }
            if(FilterColumn !="FullName" && FilterColumn != "UserName")
                _dtAllUsers.DefaultView.RowFilter = string.Format(" [{0}] = {1}", FilterColumn, TBSerche.Text.Trim());
            else
                _dtAllUsers.DefaultView.RowFilter = string.Format(" [{0}] LIKE '{1}%' ", FilterColumn, TBSerche.Text.Trim());

            labRecordes.Text = dataGridView1.Rows.Count.ToString();

        }

        private void ComIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FelterColumnIsActive = "IsActive";
            string FelterValue = ComIsActive.Text;

            switch(FelterValue)
            {
                case "All":
                    break;
                case "Yes":
                    FelterValue = "1";
                    break;
                case "No":
                    FelterValue = "0";
                    break;
            }

            if (FelterValue == "All")
                _dtAllUsers.DefaultView.RowFilter = "";
            else
                _dtAllUsers.DefaultView.RowFilter = string.Format(" [{0}] = {1}", FelterColumnIsActive, FelterValue);

            labRecordes.Text = dataGridView1.Rows.Count.ToString();
        }
    }
}

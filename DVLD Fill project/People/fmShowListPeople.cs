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
using DVLD_Fill_project.People;

namespace DVLD_Fill_project
{
    public partial class fmShowListPeople : Form
    {
        private DataTable _AllDataPeople;
        private DataTable _DataPeopleFilter;
        public fmShowListPeople()
        {
            InitializeComponent();

            _AllDataPeople = ClsPerson.GetAllPeople();

            _DataPeopleFilter = _AllDataPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                       "FirstName", "SecondName", "ThirdName", "LastName",
                                                       "Gender", "DateOfBirth", "CountryName",
                                                       "Phone", "Email");
        }

        
        private void _RefreshPeoplList()
        {
            _AllDataPeople = ClsPerson.GetAllPeople();
            _DataPeopleFilter=_AllDataPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                       "FirstName", "SecondName", "ThirdName", "LastName",
                                                       "Gender", "DateOfBirth", "CountryName",
                                                       "Phone", "Email");


            dataGridView1.DataSource = _DataPeopleFilter;
            label2.Text ="# Records : "+dataGridView1.Rows.Count.ToString();

        }

          
            
        
        private void ManagePeople_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _DataPeopleFilter;
            ComBFilter.SelectedIndex = 0;
            label2.Text = "# Records : " + dataGridView1.Rows.Count.ToString();
            if(dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns[0].HeaderText = "Person ID";
                dataGridView1.Columns[0].Width = 70;

                dataGridView1.Columns[1].HeaderText = "National No.";
                dataGridView1.Columns[1].Width = 70;


                dataGridView1.Columns[2].HeaderText = "First Name";
                dataGridView1.Columns[2].Width = 70;

                dataGridView1.Columns[3].HeaderText = "Second Name";
                dataGridView1.Columns[3].Width = 120;


                dataGridView1.Columns[4].HeaderText = "Third Name";
                dataGridView1.Columns[4].Width = 70;

                dataGridView1.Columns[5].HeaderText = "Last Name";
                dataGridView1.Columns[5].Width = 70;

                dataGridView1.Columns[6].HeaderText = "Gendor";
                dataGridView1.Columns[6].Width = 50;

                dataGridView1.Columns[7].HeaderText = "Date Of Birth";
                dataGridView1.Columns[7].Width = 80;

                dataGridView1.Columns[8].HeaderText = "Nationality";
                dataGridView1.Columns[8].Width = 60;


                dataGridView1.Columns[9].HeaderText = "Phone";
                dataGridView1.Columns[9].Width = 70;


                dataGridView1.Columns[10].HeaderText = "Email";
                dataGridView1.Columns[10].Width = 140;
            }

        }

     

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addpepol_Click(object sender, EventArgs e)
        {
            fmAddUpdatePerson person = new fmAddUpdatePerson();
            person.ShowDialog();
            _RefreshPeoplList();
        }

       

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPersonDetails person = new ShowPersonDetails((int)dataGridView1.CurrentRow.Cells[0].Value);
            person.ShowDialog();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmAddUpdatePerson person = new fmAddUpdatePerson();
            person.ShowDialog();
            _RefreshPeoplList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmAddUpdatePerson per = new fmAddUpdatePerson((int)dataGridView1.CurrentRow.Cells[0].Value);
            per.ShowDialog();
            _RefreshPeoplList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Are You sure want to delete Person " + (int)dataGridView1.CurrentRow.Cells[0].Value, "Deleted", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)==DialogResult.OK)
            {
               if(ClsPerson.DeletePerson((int)dataGridView1.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person Deleted Succesfully", "Succesfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshPeoplList();
                }
                else
                    MessageBox.Show("Person was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
           
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void TBFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (ComBFilter.Text)
            {
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;

                case "First Name":
                    FilterColumn = "FirstName";
                    break;

                case "Second Name":
                    FilterColumn = "SecondName";
                    break;

                case "Third Name":
                    FilterColumn = "ThirdName";
                    break;

                case "Last Name":
                    FilterColumn = "LastName";
                    break;

                case "Nationality":
                    FilterColumn = "CountryName";
                    break;

                case "Gendor":
                    FilterColumn = "GendorCaption";
                    break;

                case "Phone":
                    FilterColumn = "Phone";
                    break;

                case "Email":
                    FilterColumn = "Email";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }
            if (TBFilter.Text.Trim() == "" || FilterColumn == "None")
            {
                _DataPeopleFilter.DefaultView.RowFilter = "";
                label2.Text = "# Records : " + dataGridView1.Rows.Count.ToString();

                return;
            }
            if (FilterColumn == "PersonID")
            {
                _DataPeopleFilter.DefaultView.RowFilter = string.Format("[{0}]={1}", FilterColumn, TBFilter.Text.Trim());
            }
            else
                _DataPeopleFilter.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, TBFilter.Text.Trim());

            label2.Text = "# Records : " + dataGridView1.Rows.Count.ToString();
        }

        private void TBFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ComBFilter.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void ComBFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            TBFilter.Visible = (ComBFilter.Text != "None");
            if (TBFilter.Visible)
            {
                TBFilter.Text = "";
                TBFilter.Focus();
            }
        }
    }
}

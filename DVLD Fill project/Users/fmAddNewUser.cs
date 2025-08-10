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
using DVLD_Fill_project.People.Controls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DVLD_Fill_project.Users
{
    public partial class fmAddNewUser : Form
    {

        enum enMode { AddNew, Updata }
        enMode _Mode;
        private int _UserID=-1;
        ClsUsers _Users;

        public fmAddNewUser()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public fmAddNewUser(int UserID)
        {
            InitializeComponent();
            _Mode = enMode.Updata;
            _UserID = UserID;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void _ResetDefualtValues()
        {
            if (_Mode == enMode.AddNew)
            {
                labModeScren.Text = "Add New User";
                this.Text = "Add New User";
                _Users = new ClsUsers();
                tpLoginInfo.Enabled = false;
                ctrlShowPerosnCardWithFilter2.FilterFocus();
            }
            else
            {
                labModeScren.Text = "Updata User";
                this.Text = "Updata User";
                tpLoginInfo.Enabled = true;
                ButtSave.Enabled = true;
            }
            TBPassword.Text = "";
            TBConfirmPassword.Text = "";
            TBUsername.Text = "";
            checkBoxisActive.Checked = true;

        }
        private void _LodeUserinfo()
        {
            _Users = ClsUsers.GetUserByUserID(_UserID);
            ctrlShowPerosnCardWithFilter2.FilterEnabled = false;
            if (_Users == null)
            {
                MessageBox.Show("No User with ID = " + _UserID, "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            TBUsername.Text = _Users.UserName;
            TBPassword.Text = _Users.Password;
            TBConfirmPassword.Text = _Users.Password;
            checkBoxisActive.Checked = _Users.isActive;
            labUserID.Text = _Users.UserID.ToString();
            ctrlShowPerosnCardWithFilter2.loadePersonInfo(_Users.PersonID);
        }
        private void fmAddNewUser_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();
            if (_Mode == enMode.Updata)
                _LodeUserinfo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Updata)
            {
                ButtSave.Enabled = true;
                tpLoginInfo.Enabled = true;
                tabLogininfoo.SelectedTab = tabLogininfoo.TabPages["tpLoginInfo"];
                return;
            }

            if(ctrlShowPerosnCardWithFilter2._personID != -1)
            {
                if (ClsUsers.IsExistUseerByPersonID(ctrlShowPerosnCardWithFilter2._personID))
                {
                    MessageBox.Show("Selected Person already has a user, choose another one.", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ctrlShowPerosnCardWithFilter2.FilterFocus();
                }
                else
                {
                    ButtSave.Enabled = true;
                    tpLoginInfo.Enabled = true;
                    tabLogininfoo.SelectedTab = tabLogininfoo.TabPages["tpLoginInfo"];
                }

            }
            else

            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlShowPerosnCardWithFilter2.FilterFocus();

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the error",
                   "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _Users.PersonID = ctrlShowPerosnCardWithFilter2._personID;
            _Users.UserName = TBUsername.Text.Trim();
            _Users.Password = TBConfirmPassword.Text.Trim();
            _Users.isActive = checkBoxisActive.Checked;


            if (_Users.Save())
            {
                labModeScren.Text = "Update User";
                _Mode = enMode.Updata;
                this.Text = "Update User";
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TBUsername_Validating(object sender, CancelEventArgs e)
        {
            if( string.IsNullOrEmpty(TBUsername.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(TBUsername, "Username cannot be blank");
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(TBUsername, null);
            }

            if (_Mode == enMode.AddNew)
            {
                if (ClsUsers.IsExistUser(TBUsername.Text.Trim()))
                {
                    e.Cancel = true;

                    errorProvider1.SetError(TBUsername, "username is used by another user");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(TBUsername, null);
                }
            }
            else
            {
               // us Updata Mode;
                            if (_Users.UserName != TBUsername.Text.Trim())
                            {

                                e.Cancel = true;
                                errorProvider1.SetError(TBUsername, "Username cannot be blank");
                                return;

                            }
                            else
                            {
                                e.Cancel = false;
                                errorProvider1.SetError(TBUsername, null);
                            }



            }
            

        }

        private void TBPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TBPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(TBPassword, "Password cannot be blank");
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(TBPassword, null);
            }
        }

        private void TBConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            


            if(TBConfirmPassword.Text.Trim() != TBPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(TBConfirmPassword, "Password Confirmation does not match Password!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(TBConfirmPassword, null);
            }
        }

        private void fmAddNewUser_Activated(object sender, EventArgs e)
        {
            ctrlShowPerosnCardWithFilter2.FilterFocus();
        }
    }
}

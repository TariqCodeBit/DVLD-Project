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
    public partial class fmChangePassword : Form
    {
        private int UserID = -1;
        private ClsUsers _User;
        public fmChangePassword(int UserId)
        {
            InitializeComponent();
            UserID = UserId;
        }

        private void _ResetTextboxs()
        {
            TBConfirmPassword.Text = "";
            TBCurrentPassword.Text = "";
            TBNewPassword.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TBCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TBCurrentPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(TBCurrentPassword, "Password cannot be blank")
                ;return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(TBCurrentPassword, null);
            }


            if(TBCurrentPassword.Text.Trim() != _User.Password)
            {
                e.Cancel = true;
                errorProvider1.SetError(TBCurrentPassword, "Current password is wrong! ")
                ; return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(TBCurrentPassword, null);
            }
        }

        private void TBNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TBNewPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(TBNewPassword, "New Password cannot be blank");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(TBNewPassword, null);
            }
        }

        private void TBConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if(TBNewPassword.Text.Trim() != TBConfirmPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(TBConfirmPassword, "Password Confirmation does not match New Password! ")
                ; return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(TBConfirmPassword, null);
            }
        }

        private void fmChangePassword_Load(object sender, EventArgs e)
        {
            _User = ClsUsers.GetUserByUserID(UserID);
            if(_User == null)
            {
                _ResetTextboxs();
                MessageBox.Show("Could not Find User with ID = " + _User.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            ctlrUserCard1._LoadUserinfo(_User.UserID);
        }

        private void Busave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _User.Password = TBConfirmPassword.Text.Trim();
            if (_User.Save())
            {
                MessageBox.Show("Password Changed Successfully.",
                   "Saved.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _ResetTextboxs();
            }
            else
            {
                MessageBox.Show("An Erro Occured, Password did not change.",
                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

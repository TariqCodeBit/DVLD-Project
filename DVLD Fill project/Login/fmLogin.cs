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
using DVLD_Fill_project.Global_Classes;

namespace DVLD_Fill_project.Login
{
    public partial class fmLogin : Form
    {
        ClsUsers _User;
        public fmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void btnLogin_Click(object sender, EventArgs e)
        {
            _User = ClsUsers.GetUserbyUsernameAndPassword(TBusername.Text.Trim(), TBPassword.Text.Trim());
           if(_User != null)
            {
                if (chkRememberMe.Checked)
                {
                    ClsGlobal.RememberUsernameAndPassword(TBusername.Text.Trim(), TBPassword.Text.Trim());
                }
                else
                {
                    ClsGlobal.RememberUsernameAndPassword("", "");
                }
                if (!_User.isActive)
                {
                    TBusername.Focus();
                    MessageBox.Show("Your accound is not Active, Contact Admin.", "In Active Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                ClsGlobal.CurintUserinfo = _User;
                this.Hide();
                fmMain fm = new fmMain(this); 
                fm.ShowDialog();


            }
            else
            {
                TBusername.Focus();
                MessageBox.Show("Invalid Username/Password.", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fmLogin_Load(object sender, EventArgs e)
        {
            string Username = "", Password = "";
            if (ClsGlobal.GetStoredCredential(ref Username, ref Password))
            {
                TBPassword.Text = Password;
                TBusername.Text = Username;
                chkRememberMe.Checked = true;
            }
            else
                chkRememberMe.Checked = false;
        }
    }
}

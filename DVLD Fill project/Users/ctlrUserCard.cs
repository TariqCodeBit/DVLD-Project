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
    public partial class ctlrUserCard : UserControl
    {

        private int _UserID;
        private ClsUsers User;

        public ctlrUserCard()
        {
            InitializeComponent();
        }

        public void _LoadUserinfo(int UserID)
        {
            _UserID = UserID;
            User = ClsUsers.GetUserByUserID(_UserID);
            if(User == null)
            {
                _ResetPersonInfoAndUserInfo();
                MessageBox.Show("No User with UserID = " + _UserID.ToString(), "Errer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillUsercontrol();
        }
        public void _FillUsercontrol()
        {
            ctrlShowPersonCard1._LoidinfoDate(User.PersonID);

            labUserID.Text = User.UserID.ToString();
            labUserName.Text = User.UserName;
            labIsActive.Text = (User.isActive) ? "Yes" : "No";
        }

        

        public void _ResetPersonInfoAndUserInfo()
        {
            ctrlShowPersonCard1.ResetPersonInfo();

            labUserID.Text = "[???]";
            labUserName.Text = "[???]";
            labIsActive.Text = "[???]";

        }
    }
}

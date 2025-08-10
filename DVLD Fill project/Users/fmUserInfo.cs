using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Fill_project.Users
{
    public partial class fmUserInfo : Form
    {
        private int _UserID = -1;
        public fmUserInfo(int UserID)
        {
           
            InitializeComponent(); 
            _UserID = UserID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fmUserInfo_Load(object sender, EventArgs e)
        {
            ctlrUserCard1._LoadUserinfo(_UserID);
        }
    }
}

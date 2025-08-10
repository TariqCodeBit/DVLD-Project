using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Fill_project.Applications.Local_Driving_License
{
    public partial class frmLocalDrivingLicenseApplicationInfo : Form
    {
        int _ApplicationID = -1;
        public frmLocalDrivingLicenseApplicationInfo(int ApplicationID)
        {
            
            InitializeComponent();
            _ApplicationID = ApplicationID;
        }

        private void button1_Click(object sender, EventArgs e) 
        {
            this.Close();
        }

        private void frmLocalDrivingLicenseApplicationInfo_Load(object sender, EventArgs e)
        {
            ctrlDrivingLicenseApplicationInfo1._LoadeDataInfoByLocalLicenseID(_ApplicationID);
        }
    }
}

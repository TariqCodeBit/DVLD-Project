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
using DVLD_Fill_project.Licenses.Local_Licenses;

namespace DVLD_Fill_project.Applications.Local_Driving_License
{
    public partial class ctrlDrivingLicenseApplicationInfo : UserControl
    {
        int _LicenseID;

        clsLocalDrivingLicenseApplication _DrivingLicenseApplicationInfo;

         private int _LocalDrivingLicenseApplicationID = -1;

        public int LocalDrivingLicenseApplicationID
        {
            get { return _LocalDrivingLicenseApplicationID; }
        }
        public ctrlDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }
        void _ResateDataInfo()
        {
            _LicenseID = -1;

            lblAppliedFor.Text = "[????]";
            ctrlApplicationBasicInfo1._ResetAppBasecData();
            lblLocalDrivingLicenseApplicationID.Text = "[????]";
            lblPassedTests.Text = "[????]";
        }
        public void _LoadeDataInfoByLocalLicenseID(int LDrivingLicenseApplicationID)
        {
            _DrivingLicenseApplicationInfo = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LDrivingLicenseApplicationID);
            if (_DrivingLicenseApplicationInfo == null)
            {
                _ResateDataInfo();

                MessageBox.Show("No Application with ApplicationID = " + LocalDrivingLicenseApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillLocalDrivingLicenseApplicationInfo();
        }

        public void _LoadeDataInfoByApplicationID(int ApplicationID)
        {
            _DrivingLicenseApplicationInfo = clsLocalDrivingLicenseApplication.FindByApplicationID(ApplicationID);
            if (_DrivingLicenseApplicationInfo == null)
            {
                _ResateDataInfo();

                MessageBox.Show("No Application with ApplicationID = " + ApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillLocalDrivingLicenseApplicationInfo();
        }

        void _FillLocalDrivingLicenseApplicationInfo()
        {
            _LicenseID = _DrivingLicenseApplicationInfo.GetActiveLicenseID();

            //incase there is license enable the show link.
            llShowLicenceInfo.Enabled = (_LicenseID != -1);


            lblLocalDrivingLicenseApplicationID.Text = _DrivingLicenseApplicationInfo.LocalDrivingLicenseApplicationID.ToString();
            lblAppliedFor.Text = clsLicenseClass.Find(_DrivingLicenseApplicationInfo.LicenseClassID).ClassName;
            lblPassedTests.Text = _DrivingLicenseApplicationInfo.GetPassedTestCount().ToString() + "/3";
            ctrlApplicationBasicInfo1._LoadeApplicationBasecData(_DrivingLicenseApplicationInfo.ApplicationID);
        }



        private void llShowLicenceInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_DrivingLicenseApplicationInfo.GetActiveLicenseID());
            frm.ShowDialog();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Fill_project.Applications.International_License;
using DVLD_Fill_project.Applications.Local_Driving_License;
using DVLD_Fill_project.Applications.Renew_Local_License;
using DVLD_Fill_project.Applications.ReplaceLostOrDamagedLicense;
using DVLD_Fill_project.Applications.Rlease_Detained_License;
using DVLD_Fill_project.Applications.TestType;
using DVLD_Fill_project.ApplicationTypes;
using DVLD_Fill_project.Drivers;
using DVLD_Fill_project.Global_Classes;
using DVLD_Fill_project.Licenses.Detain_License;
using DVLD_Fill_project.Login;
using DVLD_Fill_project.Users;

namespace DVLD_Fill_project
{
    public partial class fmMain : Form
    {
        fmLogin login;
        public fmMain(fmLogin fmlog)
        {
            InitializeComponent();
            login = fmlog;
        }

     

      

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmShowListPeople People = new fmShowListPeople();
            People.ShowDialog();

        }

        private void uesersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmShowListUsers fmUsers = new fmShowListUsers();
            fmUsers.ShowDialog();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmUserInfo fmUserinfo = new fmUserInfo(ClsGlobal.CurintUserinfo.UserID);
            fmUserinfo.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // int n = ClsGlobal.CurintUserinfo.UserID;
            fmChangePassword fmchange = new fmChangePassword(ClsGlobal.CurintUserinfo.UserID);
            fmchange.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsGlobal.CurintUserinfo = null;
            login.Show();
            this.Close();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmshowlistAppTypes fmAppTypes = new fmshowlistAppTypes();
            fmAppTypes.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmShowListTestTypes TestTypes = new fmShowListTestTypes();
            TestTypes.ShowDialog();
        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListLocalDrivingLicesnseApplications fmLDLAPPlist = new frmListLocalDrivingLicesnseApplications();
            fmLDLAPPlist.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLicesnseApplication fmAddUpdateApp = new frmAddUpdateLocalDrivingLicesnseApplication();
            fmAddUpdateApp.ShowDialog();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListLocalDrivingLicesnseApplications fmList = new frmListLocalDrivingLicesnseApplications();
            fmList.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewLocalDrivingLicenseApplication fmRenew = new frmRenewLocalDrivingLicenseApplication();
            fmRenew.ShowDialog();

        }

        private void replacementForLostOrDamagedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplaceLostOrDamagedLicenseApplication fmReplaceLostorDamaged = new frmReplaceLostOrDamagedLicenseApplication();
            fmReplaceLostorDamaged.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListDrivers fmListDr = new frmListDrivers();
            fmListDr.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainLicenseApplication frm = new frmDetainLicenseApplication();
            frm.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicenseApplication frm = new frmReleaseDetainedLicenseApplication();
            frm.ShowDialog();
        }

        private void manageDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListDetainedLicenses frm = new frmListDetainedLicenses();
            frm.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewInternationalLicenseApplication frm = new frmNewInternationalLicenseApplication();
            frm.ShowDialog();
        }

        private void internationalLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListInternationalLicesnseApplications frm = new frmListInternationalLicesnseApplications();
            frm.ShowDialog();
        }

        private void releaseDetalnedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicenseApplication frm = new frmReleaseDetainedLicenseApplication();
            frm.ShowDialog();
        }
    }
}

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
using DVLD_Fill_project.Licenses;
using DVLD_Fill_project.Licenses.Local_Licenses;
using DVLD_Fill_project.Testes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD_Fill_project.Applications.Local_Driving_License
{
    public partial class frmListLocalDrivingLicesnseApplications : Form
    {
        DataTable _DtAllLocalDLApplications;
        public frmListLocalDrivingLicesnseApplications()
        {
            InitializeComponent();
        }

        private void frmListLocalDrivingLicesnseApplications_Load(object sender, EventArgs e)
        {
             _DtAllLocalDLApplications = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();
            DGVListData.DataSource = _DtAllLocalDLApplications;
            labRecotds.Text = DGVListData.Rows.Count.ToString();
            
            if(DGVListData.Rows.Count > 0)
            {
                DGVListData.Columns[0].HeaderText = "L.D.L.AppID";
                DGVListData.Columns[0].Width = 100;

                DGVListData.Columns[1].HeaderText = "Calss Name";
                DGVListData.Columns[1].Width = 200;

                DGVListData.Columns[2].HeaderText = "National No";
                DGVListData.Columns[2].Width = 100;

                DGVListData.Columns[3].HeaderText = "Full Name";
                DGVListData.Columns[3].Width = 200;

                DGVListData.Columns[4].HeaderText = "Application Data"
                    ; DGVListData.Columns[4].Width = 150;

                DGVListData.Columns[5].HeaderText = "Passed Test count";
                DGVListData.Columns[5].Width = 100;

                DGVListData.Columns[6].HeaderText = "Status";
                DGVListData.Columns[6].Width = 140;
            }
            CBFilterBy.SelectedIndex = 0;
        }


        private void Buclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CBFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
       
            
            TBFilterText.Visible = (CBFilterBy.Text != "None");

            if (TBFilterText.Visible)
            {
                TBFilterText.Text = "";
                TBFilterText.Focus();
            }
            _DtAllLocalDLApplications.DefaultView.RowFilter = "";
            labRecotds.Text = DGVListData.Rows.Count.ToString();
        }

        private void TBFilterText_TextChanged(object sender, EventArgs e)
        {

            string FilterCoulen = "";


            //None
            // L.D.L.AppID
            // National No.
            //Full Name
            //Status
            switch (CBFilterBy.Text)
            {
                case "National No.":
                    FilterCoulen = "NationalNo";
                    break;
                case "L.D.L.AppID":
                    FilterCoulen = "LocalDrivingLicenseApplicationID";
                    break;
                case "Full Name":
                    FilterCoulen = "FullName";
                    break;
                case "Status":
                    FilterCoulen = "Status";
                    break;
                default:
                    FilterCoulen = "None";
                    break;
            }

            if (TBFilterText.Text.Trim() == "" || FilterCoulen == "None")
            {
                _DtAllLocalDLApplications.DefaultView.RowFilter = "";
                labRecotds.Text = DGVListData.Rows.Count.ToString();
                return;
            }
            if (FilterCoulen == "LocalDrivingLicenseApplicationID")
            {
                _DtAllLocalDLApplications.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterCoulen, TBFilterText.Text.Trim());
            }
            else
            {
                _DtAllLocalDLApplications.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterCoulen, TBFilterText.Text.Trim());
            }
            labRecotds.Text = DGVListData.Rows.Count.ToString();

        }

        private void TBFilterText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (CBFilterBy.Text == "L.D.L.AppID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLicesnseApplication frmAddUpdateLDLAPP = new frmAddUpdateLocalDrivingLicesnseApplication();
            frmAddUpdateLDLAPP.ShowDialog();
            frmListLocalDrivingLicesnseApplications_Load(null, null);
        }

        private void showApplicationDetilseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalDrivingLicenseApplicationInfo frmApplicationInfo = new frmLocalDrivingLicenseApplicationInfo((int)DGVListData.CurrentRow.Cells[0].Value);
            frmApplicationInfo.ShowDialog();
        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLicesnseApplication frmAddUpdateinfo = new frmAddUpdateLocalDrivingLicesnseApplication((int)DGVListData.CurrentRow.Cells[0].Value);
            frmAddUpdateinfo.ShowDialog();
            frmListLocalDrivingLicesnseApplications_Load(null, null);
        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure do want to delete this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            clsLocalDrivingLicenseApplication LocalDLApplication = clsLocalDrivingLicenseApplication.FindByApplicationID((int)DGVListData.CurrentRow.Cells[0].Value);

            if (LocalDLApplication != null)
            {
                if (LocalDLApplication.Delete())
                {
                    MessageBox.Show("Application Deleted Successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //refresh the form again.
                    frmListLocalDrivingLicesnseApplications_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Could not delete applicatoin, other data depends on it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void _LoadScheduleType(ClsTestTypes.enTestType _TestType)
        {
            frmListTestAppointments fmTestAppointments = new frmListTestAppointments((int)DGVListData.CurrentRow.Cells[0].Value, _TestType);
            fmTestAppointments.ShowDialog();
            frmListLocalDrivingLicesnseApplications_Load(null, null);
        }
  

        private void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _LoadScheduleType(ClsTestTypes.enTestType.VisionTest);
        }

        private void scheduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _LoadScheduleType(ClsTestTypes.enTestType.WrittenTest);
        }

        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _LoadScheduleType(ClsTestTypes.enTestType.StreetTest);
        }

        private void sechduleTestsToolStripMenuItem_Click(object sender, EventArgs e)
        {

             
            frmIssueDriverLicenseFirstTime frm = new frmIssueDriverLicenseFirstTime((int)DGVListData.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            //refresh
            frmListLocalDrivingLicesnseApplications_Load(null, null);
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)DGVListData.CurrentRow.Cells[0].Value;

            int LicenseID = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(
               LocalDrivingLicenseApplicationID).GetActiveLicenseID();

            if (LicenseID != -1)
            {
                frmShowLicenseInfo frm = new frmShowLicenseInfo(LicenseID);
                frm.ShowDialog();

            }
            else
            {
                MessageBox.Show("No License Found!", "No License", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)DGVListData.CurrentRow.Cells[0].Value;
            clsLocalDrivingLicenseApplication localDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);

            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(localDrivingLicenseApplication.ApplicantPersonID);
            frm.ShowDialog();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)DGVListData.CurrentRow.Cells[0].Value;
            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication =
                    clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID
                                                    (LocalDrivingLicenseApplicationID);

            int TotalPassedTests = (int)DGVListData.CurrentRow.Cells[5].Value;

            bool LicenseExists = LocalDrivingLicenseApplication.IsLicenseIssued();

            //Enabled only if person passed all tests and Does not have license. 
            sechduleTestsToolStripMenuItem.Enabled = (TotalPassedTests == 3) && !LicenseExists;

            showLicenseToolStripMenuItem.Enabled = LicenseExists;
            editApplicationToolStripMenuItem.Enabled = !LicenseExists && (LocalDrivingLicenseApplication.ApplicationStatus == ClsApplication.enApplicationStatus.New);
            toolStripMenuItem1.Enabled = !LicenseExists;

            //Enable/Disable Cancel Menue Item
            //We only canel the applications with status=new.
            cancelApplicationToolStripMenuItem.Enabled = (LocalDrivingLicenseApplication.ApplicationStatus == ClsApplication.enApplicationStatus.New);

            //Enable/Disable Delete Menue Item
            //We only allow delete incase the application status is new not complete or Cancelled.
            deleteApplicationToolStripMenuItem.Enabled =
                (LocalDrivingLicenseApplication.ApplicationStatus == ClsApplication.enApplicationStatus.New);



            //Enable Disable Schedule menue and it's sub menue
            bool PassedVisionTest = LocalDrivingLicenseApplication.DoesPassTestType(ClsTestTypes.enTestType.VisionTest); ;
            bool PassedWrittenTest = LocalDrivingLicenseApplication.DoesPassTestType(ClsTestTypes.enTestType.WrittenTest);
            bool PassedStreetTest = LocalDrivingLicenseApplication.DoesPassTestType(ClsTestTypes.enTestType.StreetTest);

            toolStripMenuItem1.Enabled = (!PassedVisionTest || !PassedWrittenTest || !PassedStreetTest) && (LocalDrivingLicenseApplication.ApplicationStatus == ClsApplication.enApplicationStatus.New);

            if (toolStripMenuItem1.Enabled)
            {
                //To Allow Schdule vision test, Person must not passed the same test before.
                scheduleVisionTestToolStripMenuItem.Enabled = !PassedVisionTest;

                //To Allow Schdule written test, Person must pass the vision test and must not passed the same test before.
                scheduleWrittenTestToolStripMenuItem.Enabled = PassedVisionTest && !PassedWrittenTest;

                //To Allow Schdule steet test, Person must pass the vision * written tests, and must not passed the same test before.
                scheduleStreetTestToolStripMenuItem.Enabled = PassedVisionTest && PassedWrittenTest && !PassedStreetTest;

            }


        }
    }
}

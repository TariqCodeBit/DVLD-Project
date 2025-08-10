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

namespace DVLD_Fill_project.Applications.Local_Driving_License
{
    public partial class frmAddUpdateLocalDrivingLicesnseApplication : Form
    {
        enum enMode { AddNew,Update};
        enMode _Mode = enMode.AddNew;
        int _DVLAppID = -1;
        int _SelectrPersonID = -1;
        clsLocalDrivingLicenseApplication _LDLAInfo;
        public frmAddUpdateLocalDrivingLicesnseApplication()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public frmAddUpdateLocalDrivingLicesnseApplication(int LDID)
        {
            InitializeComponent();
            _DVLAppID = LDID;
            _Mode = enMode.Update;
        }
        private void _FillDatainCombox()
        {

            DataTable _dtLicenseClasses =clsLicenseClass.GetAllLicenseClasses();

            foreach (DataRow Row in _dtLicenseClasses.Rows)
            {
                cbLicenseClass.Items.Add(Row["ClassName"]);
            }
        }
        private void _ResetDefultValues()
        {
            _FillDatainCombox();
            if (_Mode == enMode.AddNew)
            {
               labModeScrena.Text = "New Local Driving License Application";
                this.Text = "New Local Driving License Application";
                _LDLAInfo = new clsLocalDrivingLicenseApplication();
                ctrlShowPerosnCardWithFilter1.FilterFocus();
                tpApplicationInfo.Enabled = false;

                cbLicenseClass.SelectedIndex = 2;
                lblFees.Text = ClsApplicationTypes.Find((int)ClsApplication.enApplicationType.NewDrivingLicense).ApplicationFees.ToString();
                lblApplicationDate.Text = DateTime.Now.ToShortDateString();
                lblCreatedByUser.Text = ClsGlobal.CurintUserinfo.UserName;
            }else
            {
                labModeScrena.Text = "Update Local Driving License Application";
                this.Text = "Update Local Driving License Application";

                tpApplicationInfo.Enabled = true;
                BuSave.Enabled = true;
            }

        }

        private void _LodaData()
        {
            ctrlShowPerosnCardWithFilter1.FilterEnabled = false;

            _LDLAInfo = clsLocalDrivingLicenseApplication.FindByApplicationID(_DVLAppID);
            if(_LDLAInfo == null)
            {
                MessageBox.Show("No Application with ID = " + _DVLAppID, "Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

           ctrlShowPerosnCardWithFilter1.loadePersonInfo(_LDLAInfo.ApplicantPersonID);
            lblLocalDrivingLicebseApplicationID.Text =_LDLAInfo.LocalDrivingLicenseApplicationID.ToString();
            lblApplicationDate.Text = Format.DateToShort(_LDLAInfo.ApplicationDate);
            cbLicenseClass.SelectedIndex = cbLicenseClass.FindString(clsLicenseClass.Find(_LDLAInfo.LicenseClassID).ClassName);
            lblFees.Text = _LDLAInfo.PaidFees.ToString();
            lblCreatedByUser.Text = ClsUsers.GetUserByUserID(_LDLAInfo.CreatedByUserID).UserName;
        }
        private void frmAddUpdateLocalDrivingLicesnseApplication_Load(object sender, EventArgs e)
        {
            _ResetDefultValues();

            ctrlShowPerosnCardWithFilter1.OnPersonSelected += ctrlPersonCardWithFilter1_OnPersonSelected;
            if (_Mode == enMode.Update)
            {
                _LodaData();

            }

        }

        private void BuSave_Click(object sender, EventArgs e)
        {
           // int LicenseClassID = clsLicenseClass.Find(cbLicenseClass.Text).LicenseClassID;


            int ActiveApplicationID = ClsApplication.GetActiveApplicationIDForLicenseClass(_SelectrPersonID, ClsApplication.enApplicationType.NewDrivingLicense, 2);///

            if (ActiveApplicationID != -1)
            {
                MessageBox.Show("Choose another License Class, the selected Person Already have an active application for the selected class with id=" + ActiveApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbLicenseClass.Focus();
                return;
            }

            //if (clsLicense.IsLicenseExistByPersonID(ctrlPersonCardWithFilter1.PersonID, LicenseClassID))
            //{

            //    MessageBox.Show("Person already have a license with the same applied driving class, Choose diffrent driving class", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            _LDLAInfo.ApplicantPersonID =ctrlShowPerosnCardWithFilter1._personID; ;
            _LDLAInfo.ApplicationDate = DateTime.Now;
            _LDLAInfo.ApplicationTypeID = 1;
            _LDLAInfo.ApplicationStatus = ClsApplication.enApplicationStatus.New;
            _LDLAInfo.LastStatusDate = DateTime.Now;
            _LDLAInfo.PaidFees = Convert.ToDecimal(lblFees.Text);
            _LDLAInfo.CreatedByUserID = ClsGlobal.CurintUserinfo.UserID;
            _LDLAInfo.LicenseClassID = 2;//


            if (_LDLAInfo.Save())
            {
                lblLocalDrivingLicebseApplicationID.Text = _LDLAInfo.LocalDrivingLicenseApplicationID.ToString();
                //change form mode to update.
                _Mode = enMode.Update;
                labModeScrena.Text = "Update Local Driving License Application";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void ctrlPersonCardWithFilter1_OnPersonSelected(int personId)
        {
            _SelectrPersonID = personId;

            // Any other action...
        }

        private void frmAddUpdateLocalDrivingLicesnseApplication_Activated(object sender, EventArgs e)
        {
            ctrlShowPerosnCardWithFilter1.FilterFocus();
        }

        private void btnApplicationInfoNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                BuSave.Enabled = true;
                tpApplicationInfo.Enabled = true;
                tcApplicationInfo.SelectedTab = tcApplicationInfo.TabPages["tpApplicationInfo"];
                return;
            }


            //incase of add new mode.
            if (ctrlShowPerosnCardWithFilter1._personID!= -1)
            {

                BuSave.Enabled = true;
                tpApplicationInfo.Enabled = true;
                tcApplicationInfo.SelectedTab = tcApplicationInfo.TabPages["tpApplicationInfo"];

            }

            else

            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
               ctrlShowPerosnCardWithFilter1.FilterFocus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

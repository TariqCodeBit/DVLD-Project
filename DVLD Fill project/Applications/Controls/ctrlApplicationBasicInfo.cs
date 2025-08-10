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
using DVLD_Fill_project.People;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Fill_project.Applications.Controls
{
    public partial class ctrlApplicationBasicInfo : UserControl
    {

        int _ApplictionID ;
        ClsApplication _ApplicationData;
        public ctrlApplicationBasicInfo()
        {
            InitializeComponent();
        }

        public int  ApplicationId{
            get
            {
                return _ApplictionID;
            }
         }
         public void _ResetAppBasecData()
        {
            _ApplictionID = -1;
            lblApplicant.Text = "[????]";
            lblApplicationID.Text = "[????]";
            lblCreatedByUser.Text = "[????]";
            lblDate.Text = "[????]";
            lblStatus.Text = "[????]";
            lblStatusDate.Text = "[????]";
            lblType.Text = "[????]";
            lblFees.Text = "[????]";
            
        }
        public void _LoadeApplicationBasecData(int ApplactionID)
        {
            _ApplicationData = ClsApplication.FindBaseApplication(ApplactionID);
            if(_ApplicationData == null)
            {
                _ResetAppBasecData();

               
                MessageBox.Show("No Application with ApplicationID = " + ApplactionID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            _FullDataApplacation();


        }

        void _FullDataApplacation()
        {
            lblFees.Text = _ApplicationData.ApplicationTypeInfo.ApplicationFees.ToString();
             lblFees.Text = ClsApplicationTypes.Find(_ApplicationData.ApplicationTypeID).ApplicationFees.ToString();
            _ApplictionID = _ApplicationData.ApplicationID;
            lblFees.Text = _ApplicationData.PaidFees.ToString();
            lblDate.Text =Format.DateToShort( _ApplicationData.ApplicationDate);
            lblCreatedByUser.Text = _ApplicationData.CreatedByUserInfo.UserName;
            lblApplicationID.Text = _ApplicationData.ApplicationID.ToString();
            lblStatus.Text = _ApplicationData.StatusText;
            lblStatusDate.Text =Format.DateToShort( _ApplicationData.LastStatusDate);
            lblType.Text = _ApplicationData.ApplicationTypeInfo.ApplicationTypesTitel;
            lblApplicant.Text = _ApplicationData.ApplicantFullName;
            
        }

        private void llViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowPersonDetails fmDataPerson = new ShowPersonDetails(_ApplicationData.ApplicantPersonID);
            fmDataPerson.ShowDialog();
        }
    }
}

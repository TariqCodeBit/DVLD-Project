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

namespace DVLD_Fill_project.Testes
{
    public partial class frmScheduleTest : Form
    {

        private int _LocalDrivingLicenseApplicationID = -1;
        private ClsTestTypes.enTestType _TestTypeID = ClsTestTypes.enTestType.VisionTest;
        private int _AppointmentID = -1;
        public frmScheduleTest(int LDLApp_ID,ClsTestTypes.enTestType Type,int AppID=-1)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LDLApp_ID;
            _TestTypeID = Type;
            _AppointmentID = AppID;
        }

        private void crlScheduleTest1_Load(object sender, EventArgs e)
        {
            crlScheduleTest1.TestTypeID = _TestTypeID;
            crlScheduleTest1.LoadInfo(_LocalDrivingLicenseApplicationID, _AppointmentID);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

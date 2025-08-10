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

namespace DVLD_Fill_project.Applications.TestType
{
    public partial class fmEditTestTypes : Form
    {

        private ClsTestTypes.enTestType IDTest=ClsTestTypes.enTestType.VisionTest;
        ClsTestTypes _TestTypes;
        public fmEditTestTypes(ClsTestTypes.enTestType ID)
        {
            InitializeComponent();
            IDTest = ID;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fmEditTestTypes_Load(object sender, EventArgs e)
        {
            _TestTypes = ClsTestTypes.Find(IDTest);
            if(_TestTypes != null)
            {
                labID.Text = ((int)IDTest).ToString();
                TBDescription.Text = _TestTypes.TestTypeDescription;
                TBFees.Text = _TestTypes.TestTypeFees.ToString();
                TBtitel.Text = _TestTypes.TestTypeTitle;
                

            }
            else
            {
                return;
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("some fileds are not valide ! ,put the mouse over the red icon(s) ","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }


            _TestTypes.TestTypeDescription = TBDescription.Text.Trim();
            _TestTypes.TestTypeTitle = TBtitel.Text.Trim();
            _TestTypes.TestTypeFees = Convert.ToDecimal(TBFees.Text.Trim());

            if (_TestTypes.Save())
            {
                MessageBox.Show("Save Data Successfully ", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Error : Data is Not Save Successfully. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void TBtitel_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TBtitel.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(TBtitel, "Title cannot by Empty!");
            }else
            {
                e.Cancel = false;
                errorProvider1.SetError(TBtitel, null);
            }
        }

        private void TBDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TBDescription.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(TBDescription, "Description cannot by Empty!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(TBDescription, null);
            }
        }

        private void TBFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void TBFees_Validating(object sender, CancelEventArgs e)
        {
            if (!ClsValdtion.ISNumber(TBFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(TBFees, "Valid Number");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(TBFees, null);
            }
        }
    }
}

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

namespace DVLD_Fill_project.ApplicationTypes
{
    public partial class fmEditApplicationTypes : Form
    {
        private int _AppID=-1;
        ClsApplicationTypes _AppType;
        public fmEditApplicationTypes(int ID)
        {
            InitializeComponent();
            _AppID = ID;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fmEditApplicationTypes_Load(object sender, EventArgs e)
        {
            _AppType = ClsApplicationTypes.Find(_AppID);

            if(_AppType != null)
            {
                labID.Text = _AppType.ID.ToString();
                TBtitel.Text = _AppType.ApplicationTypesTitel;
                TBfees.Text = _AppType.ApplicationFees.ToString();
            }
            else
            {
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("some fileds are not valide ! ,put the mouse over the red icon(s) ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                


            _AppType.ApplicationTypesTitel = TBtitel.Text.Trim();

            _AppType.ApplicationFees = Convert.ToDecimal(TBfees.Text.Trim());
            

            if (_AppType.Save())
            {
                MessageBox.Show("Save Data Successfully ", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Error : Data is Not Save Successfully. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);





        }

        private void TBfees_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void TBtitel_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TBtitel.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(TBtitel, "Title cannot by Empty!");

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(TBtitel, null);
            }
        }

        private void TBfees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TBfees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(TBfees, "");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(TBfees, null);
            }



            if(!ClsValdtion.ISNumber(TBfees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(TBfees, "Invaled Number");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(TBfees, null);
            }
        }
    }
}

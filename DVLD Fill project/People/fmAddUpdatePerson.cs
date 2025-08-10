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
using DVLD_Fill_project.Properties;
using System.IO;
using DVLD.Classes;

namespace DVLD_Fill_project.People
{
    public partial class fmAddUpdatePerson : Form
    {
        public delegate void DataBackEventHandler(object sender, int PersonID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;

        enum enMode { Addnew,Update};
        enum enGendor { Male=0,FeMale=1}
        enMode Mode;
        int IDperson;
        ClsPerson _ClassPerosn;
        public fmAddUpdatePerson()
        {
            InitializeComponent();
            Mode = enMode.Addnew;
        }
        public fmAddUpdatePerson(int personID)
        {
            InitializeComponent();
            Mode = enMode.Update;
            IDperson = personID;
        }
        private void _FillCountresInComobox()
        {
           DataTable DataTCountry = ClsCountry.Getallcountry();
            foreach(DataRow row in DataTCountry.Rows)
            {
                CBCountry.Items.Add(row["CountryName"]);
            }
        }
        private void _ResetDefiltValuse()
        {
            _FillCountresInComobox();

            if (Mode == enMode.Addnew)
            {
                Modescren.Text = "Add New Person";
                _ClassPerosn = new ClsPerson();
            }
            else
                Modescren.Text = "Update Person";

            if (redMale.Checked)
                PicImagePerson.Image = Resources.profile_3135715;
            else
                PicImagePerson.Image = Resources.profile_3135789;

            linkRemove.Visible = (PicImagePerson.ImageLocation != null);

            dateTimePicker1.MaxDate = DateTime.Now.AddYears(-18);
            dateTimePicker1.Value = dateTimePicker1.MaxDate;
            dateTimePicker1.MinDate = DateTime.Now.AddYears(-100);

            CBCountry.SelectedIndex = CBCountry.FindString("Egypt");

            TBFirstName.Text = "";
            TBSecondName.Text = "";
            TBThirdName.Text = "";
            TBLastName.Text = "";
            TBEmail.Text = "";
            TBPhone.Text = "";
            redMale.Checked = true;
            TBAddress.Text = "";
            TBNational.Text = "";
            
        }
        private void _LodeDate()
        {
            _ClassPerosn = ClsPerson.Find(IDperson);

            if (_ClassPerosn == null)
            {
                MessageBox.Show("No Person With ID = " + IDperson + "person Not Found","Validation Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                this.Close();
                return;
            }


            IntID.Text = IDperson.ToString();
                TBFirstName.Text = _ClassPerosn.FirstName;
                TBSecondName.Text = _ClassPerosn.secondName;
                TBThirdName.Text = _ClassPerosn.ThirdName;
                TBLastName.Text = _ClassPerosn.lastName;
                TBAddress.Text = _ClassPerosn.Addrese;
                TBEmail.Text = _ClassPerosn.Email;
                TBPhone.Text = _ClassPerosn.phone;
                TBNational.Text = _ClassPerosn.NationalNO;
                if (_ClassPerosn.Gendor==0)
                {
                    redfemale.Checked = true;
                }
                else
                    redMale.Checked = true;

                dateTimePicker1.Value = _ClassPerosn.DateOfBirth;
                CBCountry.SelectedIndex = CBCountry.FindString(_ClassPerosn.countryInfo.NameCountry);

            if(_ClassPerosn.imagePath != "")
            {
                PicImagePerson.ImageLocation = _ClassPerosn.imagePath;
            }

            linkRemove.Visible = (_ClassPerosn.imagePath != "");
               

            
        }
        private void fmAddUpdatePerson_Load(object sender, EventArgs e)
        {
            _ResetDefiltValuse();
            if (Mode == enMode.Update)
                _LodeDate();


        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files |*.jpg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                PicImagePerson.Load(openFileDialog1.FileName);
                linkRemove.Visible = true;
            }
        }

        private void redMale_CheckedChanged(object sender, EventArgs e)
        {
            if (PicImagePerson.ImageLocation==null)
                PicImagePerson.Image = Resources.profile_3135715;
        }


        private void redfemale_CheckedChanged(object sender, EventArgs e)
        {
            if(PicImagePerson.ImageLocation==null)
            PicImagePerson.Image = Resources.profile_3135789;
        }
        private bool _handelImage()
        {
            if(_ClassPerosn.imagePath != PicImagePerson.ImageLocation)
            {
                if(_ClassPerosn.imagePath != ""){
                    try
                    {
                        File.Delete(_ClassPerosn.imagePath);
                    }
                    catch(IOException)
                    {

                    }
                }if(PicImagePerson.ImageLocation != null)
                {
                    string resources = PicImagePerson.ImageLocation.ToString();
                    if(clsUtil.CopyImageToProjectImagesFolder(ref resources))
                    {
                        PicImagePerson.ImageLocation = resources;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            return true;
            
        }
        private void butSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (!_handelImage()){
                return;
            }
            


            _ClassPerosn.FirstName = TBFirstName.Text.Trim();
            _ClassPerosn.secondName = TBSecondName.Text.Trim();
            _ClassPerosn.ThirdName = TBThirdName.Text.Trim();
            _ClassPerosn.lastName = TBLastName.Text.Trim();
            _ClassPerosn.phone = TBPhone.Text.Trim();
            _ClassPerosn.Email = TBEmail.Text.Trim();
            _ClassPerosn.Nationalty = ClsCountry.Finde(CBCountry.Text).ID;
            _ClassPerosn.NationalNO = TBNational.Text.Trim();
            _ClassPerosn.Addrese = TBAddress.Text.Trim();
            _ClassPerosn.DateOfBirth = dateTimePicker1.Value;
            if (redfemale.Checked)
            {
                _ClassPerosn.Gendor = (short)enGendor.FeMale;
            }
            else
                _ClassPerosn.Gendor = (short)enGendor.Male;

            if (PicImagePerson.ImageLocation != null)
            {
                _ClassPerosn.imagePath = PicImagePerson.ImageLocation;
            }
            else
                _ClassPerosn.imagePath = "";

            DataBack?.Invoke(this, IDperson);


            if (_ClassPerosn.Save())
            {
                IntID.Text = _ClassPerosn.PersonID.ToString();
                Mode = enMode.Update;
                Modescren.Text = "Update";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);


                // Trigger the event to send data back to the caller form.
                DataBack?.Invoke(this, _ClassPerosn.PersonID);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);




        }

    

        private void linkRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PicImagePerson.ImageLocation = null;

            if (redfemale.Checked)
            {
                PicImagePerson.Image = Resources.profile_3135789;
            }
            else
                PicImagePerson.Image = Resources.profile_3135715;

                linkRemove.Visible = false;
        }

   

        private void TBNational_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TBNational.Text.Trim()) )
            {
                e.Cancel = true;
                errorProvider1.SetError(TBNational, "This field is required!");
            }
            else
                errorProvider1.SetError(TBNational, null);

            if (TBNational.Text.Trim() != _ClassPerosn.NationalNO && ClsPerson.IsPersonExist(TBNational.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(TBNational, "National Number is used for another person!");
            }
            else
                errorProvider1.SetError(TBNational, null);

        }

        private void TBEmail_Validating(object sender, CancelEventArgs e)
        {
            if (TBEmail.Text.Trim() == "") return;

            if (!ClsValdtion.ValidateEmail(TBEmail.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(TBEmail, "Invalid Email Address Format!");
            } else
                errorProvider1.SetError(TBEmail, null);
        }
    }
}

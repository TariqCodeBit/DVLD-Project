using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business_Logic;
using DVLD_Fill_project.Global_Classes;
using DVLD_Fill_project.Properties;

namespace DVLD_Fill_project.People.Controls
{
    public partial class ctrlShowPersonCard : UserControl
    {
       
        ClsPerson _Person;
        int IDPerson = -1;


        public int PersonID
        {
            get { return IDPerson;  }
        }

        public ClsPerson SelectedPersonInfo
        {
            get { return _Person; }
        }


        public ctrlShowPersonCard()
        {
            InitializeComponent();
        }

      public void _LoidinfoDate(int PersoonID)
        {
           
            _Person = ClsPerson.Find(PersoonID);

            
                if (_Person == null)
                {
                    ResetPersonInfo();
                    MessageBox.Show("No Person with PersonID = " + PersoonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            _FillPersonInfo();

        }
        public void _LoidinfoDate(string NationalID)
        {
            _Person = ClsPerson.Finde(NationalID);
            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person With NationalNO = " + NationalID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillPersonInfo();



        }

        private void _FillPersonInfo()
        {
            IDPerson = _Person.PersonID;

            lblPersonID.Text = _Person.PersonID.ToString();
            lblFullName.Text = _Person.FullName;
            lblEmail.Text = _Person.Email;
            lblDateOfBirth.Text =Format.DateToShort( _Person.DateOfBirth);
            lblCountry.Text = ClsCountry.Finde(_Person.Nationalty).NameCountry;
            lblAddress.Text = _Person.Addrese;
            lblPersonID.Text = IDPerson.ToString();
            lblPhone.Text = _Person.phone;
            PresintImage();
            lblGendor.Text = (_Person.Gendor == 0) ? "Male" : "Female";
            lblNationalNo.Text = _Person.NationalNO;




        }
        private void PresintImage()
        {
            if (_Person.Gendor == 0)
            {pictureBox1.Image = Resources.profile_3135715;
               
            }
            else
                 pictureBox1.Image = Resources.profile_3135789;

            string imagepath = _Person.imagePath;
            if(imagepath != ""){
                if (File.Exists(imagepath))
                {
                    pictureBox1.ImageLocation = imagepath;
                    
                }
                else
                    MessageBox.Show("Could not find this image: = " + imagepath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       public void ResetPersonInfo()
        {
            
            lblFullName.Text = "[????]";
            lblEmail.Text = "[????]";
            lblGendor.Text = "[????]";
            lblDateOfBirth.Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblPersonID.Text = "[????]";
            lblPhone.Text = "[????]";
            lblAddress.Text = "[????]";
            pictureBox1.Image = Resources.profile_3135789;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fmAddUpdatePerson aduod = new fmAddUpdatePerson(IDPerson);
                aduod.ShowDialog();
            _LoidinfoDate(IDPerson);
            
        }

     
    }
}

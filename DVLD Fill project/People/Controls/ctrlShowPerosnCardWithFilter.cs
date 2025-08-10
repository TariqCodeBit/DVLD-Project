using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using Business_Logic;

namespace DVLD_Fill_project.People.Controls
{
    public partial class ctrlShowPerosnCardWithFilter : UserControl

    {


        public event Action<int> OnPersonSelected;
        // Create a protected method to raise the event with a parameter
        protected virtual void PersonSelected(int PersonID)
        {
            Action<int> handler = OnPersonSelected;
            if (handler != null)
            {
                handler(PersonID); // Raise the event with the parameter
            }
        }
        public ctrlShowPerosnCardWithFilter()
        {
            InitializeComponent();
        }
        private int PersonID = -1;
        public int _personID
        {
            get { return ctrlShowPersonCard1.PersonID; }
        }
        public ClsPerson SelectPersonInfo
        {
            get { return ctrlShowPersonCard1.SelectedPersonInfo; }
            
        }
        private bool _BttumAdd = true;
        public bool BttumAdd
        {
            get
            {
                return _BttumAdd;
            }
            set
            {
                _BttumAdd = value;
                BUadd.Enabled = _BttumAdd;
            }
        }

        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
               groupBox1.Enabled = _FilterEnabled;

            }
        }
        public void loadePersonInfo(int PersonID)
        {
            comboBox1.SelectedIndex = 0;
            textBox1.Text = PersonID.ToString();
            FindNew();
        }
        private void FindNew()
        {
            switch (comboBox1.Text) {

                case "Person ID":
                    ctrlShowPersonCard1._LoidinfoDate(int.Parse(textBox1.Text));
                    break;
                case "National No":
                    ctrlShowPersonCard1._LoidinfoDate(textBox1.Text);

                    break;
                default:
                    break;



            }
            if (OnPersonSelected != null && FilterEnabled)
                // Raise the event with a parameter
                OnPersonSelected(ctrlShowPersonCard1.PersonID);

        }
        private void Bufind_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            FindNew();
        }

        private void BUadd_Click(object sender, EventArgs e)
        {
            fmAddUpdatePerson fmadd = new fmAddUpdatePerson();
            fmadd.DataBack += DatabackDeleget;   
            fmadd.ShowDialog();

        }
        private void DatabackDeleget(object sender,int PersonID)
        {
            comboBox1.SelectedIndex = 0;
            textBox1.Text = PersonID.ToString();
            ctrlShowPersonCard1._LoidinfoDate(PersonID);
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            //if (string.IsNullOrEmpty(textBox1.Text.Trim()))
            //{
            //    e.Cancel = true;
            //    errorProvider1.SetError(textBox1, " This field is required!");

            //}
            //else
            //    errorProvider1.SetError(textBox1, null);
        }

        private void ctrlShowPerosnCardWithFilter_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 1;
            textBox1.Focus();
        }
        public void FilterFocus()
        {
            textBox1.Focus();
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {

                Bufind.PerformClick();
            }

            //this will allow only digits if person id is selected
            if (comboBox1.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        
    }
}

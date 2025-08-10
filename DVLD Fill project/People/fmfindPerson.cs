using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Fill_project.People.Controls
{
    public partial class fmfindPerson : Form
    {

        public delegate void DataBackHandel(object se, int PersonID);

        public event DataBackHandel DataBack;
        public fmfindPerson()
        {
            InitializeComponent();
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            DataBack?.Invoke(this, ctrlShowPerosnCardWithFilter1._personID);

        }

       
    }
}

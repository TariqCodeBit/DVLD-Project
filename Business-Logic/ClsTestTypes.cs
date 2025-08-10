using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace Business_Logic
{
    public class ClsTestTypes
    {
        enum enMode { Addnew,Updata};
        enMode _Mode = enMode.Updata;

        public enum enTestType { VisionTest=1,WrittenTest=2,StreetTest=3}



        //public int TestTypeID { get; set; }
        public string TestTypeTitle { get; set; }

        public ClsTestTypes.enTestType ID { get; set; }
        public string TestTypeDescription { get; set; }

        public decimal TestTypeFees { get; set; }

        public ClsTestTypes()
        {
            this.ID = enTestType.VisionTest;
            this.TestTypeTitle = "";
            this.TestTypeDescription = "";
            this.TestTypeFees = -1;


            _Mode = enMode.Addnew;
        }
        private ClsTestTypes(ClsTestTypes.enTestType ID,string Title,string Description,decimal Fees)
        {
            this.ID= ID;
            this.TestTypeTitle = Title;
            this.TestTypeFees = Fees;
            this.TestTypeDescription = Description;

            _Mode = enMode.Updata;
        }

        public static DataTable GetAllTestType()
        {
            return ClsTestTypesData.GetAllTestTypes();
        }
        public static ClsTestTypes Find(ClsTestTypes.enTestType ID)
        {
            string Title = "";string Description = "";decimal Fees = -1;

            if(ClsTestTypesData.FindByID((int)ID,ref Title,ref Description,ref Fees))
                return new ClsTestTypes(ID, Title, Description, Fees);

            
            return null;

        }
        private bool _UpdateTestType()
        {
            return ClsTestTypesData.UpdateTestTypes((int) this.ID, this.TestTypeTitle, this.TestTypeDescription, this.TestTypeFees);
        }
        private bool _AddNewTestType()
        {
            this.ID =(ClsTestTypes.enTestType) ClsTestTypesData.AddTestTypes(this.TestTypeTitle, this.TestTypeDescription, this.TestTypeFees);


            return (this.TestTypeTitle != "");
        }

        public bool Save()
        {
            switch (_Mode) {
                case enMode.Addnew:
                    if (_AddNewTestType())
                    {
                        _Mode = enMode.Updata;
                        return true;
                    }
                    else
                        return false;

                case enMode.Updata:
                    return _UpdateTestType();

            
            
            }

            return false;

        }


    }
}

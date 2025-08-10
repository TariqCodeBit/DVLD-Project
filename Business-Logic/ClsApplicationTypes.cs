using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace Business_Logic
{
    public class ClsApplicationTypes
    {
        enum enMode { AddNew,Update};
        enMode _Mode;
        public int ID { get; set; }
        public string ApplicationTypesTitel { get; set; }

        public decimal ApplicationFees { get; set; }

        public ClsApplicationTypes()
        {
            this.ApplicationTypesTitel = "";
            this.ApplicationFees = -1;
            _Mode = enMode.AddNew;
        }
        private ClsApplicationTypes(int ID,string ApplicationTypesTirel,decimal ApplicationFees)
        {
            this.ID = ID;
            this.ApplicationTypesTitel = ApplicationTypesTirel;
            this.ApplicationFees = ApplicationFees;

            _Mode = enMode.Update;
        }

        public static DataTable GetAllApplicationTrpes()
        {
            return ClsApplicationTypesData.GetAllAppType();
        }

        private bool _UpdataAppTypes()
        {
            return ClsApplicationTypesData.UpdateDataApp(this.ID, this.ApplicationTypesTitel, this.ApplicationFees);
        }
        private bool _AddNewAppTypes()
        {
            this.ID = ClsApplicationTypesData.AddNewAppTypes(this.ApplicationTypesTitel, this.ApplicationFees);
            return (this.ID != 0);
        }
        public static ClsApplicationTypes Find(int ID)
        {
            string Titel = "";decimal Fees = -1;

            if (ClsApplicationTypesData.GetAppTypersByID(ID, ref Titel, ref Fees))
                return new ClsApplicationTypes(ID, Titel, Fees);

            return null;
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewAppTypes())
                    {
                        _Mode = enMode.Update;
                        return true;

                    }
                    else
                        return false;
                case enMode.Update:
                    return _UpdataAppTypes();


            }

            return false;
        }
       


    }
}

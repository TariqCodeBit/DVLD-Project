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
    public class ClsPerson
    {
        enum enMode { Addnew=0,Update=1};
        enMode Mode;

       public int PersonID { get; set; }
       public string NationalNO { get; set; }
       public string FirstName { get; set; }
       public string secondName { get; set; }
       public string ThirdName { get; set; }

        public string lastName { get; set; }
        public string FullName
        {
            get
            {
               return  FirstName+" "+ secondName +" "+ ThirdName +" " + lastName;
            }
        }
        public short Gendor { get; set; }

        public DateTime DateOfBirth { get; set; }
        public int Nationalty { get; set; }
        public string phone { get; set; }
        public string Email { get; set; }
        public ClsCountry countryInfo;
         public string imagePath { get; set; }
        public string Addrese { get; set; }
        public ClsPerson()
        {
            PersonID = -1;
            NationalNO = "";
            FirstName = "";
            lastName = "";
            secondName = "";
            ThirdName = "";
            Gendor =-1;
            DateOfBirth = DateTime.Now;
            Nationalty = -1;
            phone = "";
            Email = "";
            imagePath = "";
            Addrese = "";


            Mode = enMode.Addnew;


        }
        ClsPerson(int PersonID,string NatiionalON,string FirstName,string SecondName,string ThirdName,string lastName
            ,short Gendor,DateTime DateOfBirth,int Nationalty,string Phone,string Email,string Address,string imagepath)
        {
            this.PersonID =PersonID;
            this.NationalNO = NatiionalON;
            this.FirstName = FirstName;
            this.secondName = SecondName;
            this.ThirdName = ThirdName;
            this.lastName = lastName;
            this.Gendor = Gendor;
            this.DateOfBirth = DateOfBirth;
            this.Nationalty = Nationalty;
            this.phone = Phone;
            this.Email = Email;
            this.countryInfo = ClsCountry.Finde(Nationalty);
            this.Addrese = Address;
            this.imagePath = imagepath;
            

            Mode = enMode.Update;
        }

        public static DataTable GetAllPeople()
        {
            return DataAccessLayer.ClsPersonData.GetAllPeople();
        }
         private bool _AddnewPerson()
        {
            this.PersonID = DataAccessLayer.ClsPersonData.AddNewPerson(this.NationalNO, this.FirstName, this.secondName, this.ThirdName,
                this.lastName, this.DateOfBirth, this.Gendor, this.Addrese, this.phone, this.Email, this.Nationalty, this.imagePath);

            return this.PersonID != -1;
        }
        private bool _UpdatePerson()
        {
            return DataAccessLayer.ClsPersonData.UpdatePerson(this.PersonID, this.NationalNO, this.FirstName, this.secondName, this.ThirdName,
                this.lastName, this.DateOfBirth, this.Gendor, this.Addrese, this.phone, this.Email, this.Nationalty, this.imagePath);
        }

        public static bool IsPersonExist(int personID)
        {
            return DataAccessLayer.ClsPersonData.IsPersonExist(personID);
        }
        public static bool IsPersonExist(string NationalNO)
        {
            return ClsPersonData.IsPersonExist(NationalNO);
        }
        public static ClsPerson Find(int PersonId)
        {
            string NationalNo = "", Firstname = "", secondName = "", ThirdName = "",lastName="", Phone = "", Email = "", Addrese = "", imagePath = "";
            short Gendor = 0 ;int Nationalty = -1;DateTime DateOfBirth = DateTime.Now;
            if(DataAccessLayer.ClsPersonData.GetPersonInfoByID(PersonId, ref NationalNo,ref Firstname,ref secondName,ref ThirdName,ref lastName,ref DateOfBirth,
                ref Gendor,ref Addrese,ref Phone,ref Email,ref Nationalty,ref imagePath))
            {
                return new ClsPerson(PersonId, NationalNo, Firstname, secondName, ThirdName, lastName, Gendor, DateOfBirth, Nationalty
                    , Phone, Email, Addrese, imagePath);
            }
            return null;
        }

        public static ClsPerson Finde(string NationalNo)
        {
            int ID=-1; string Firstname = "", secondName = "", ThirdName = "", lastName = "", Phone = "", Email = "", Addrese = "", imagePath = "";
            short Gendor =0; int Nationalty = -1; DateTime DateOfBirth = DateTime.Now;

            if (DataAccessLayer.ClsPersonData.GetPersonInfoBynationalNo(NationalNo,ref ID,ref Firstname,ref secondName,ref ThirdName,ref lastName,
                ref DateOfBirth,ref Gendor ,ref Addrese,ref Phone, ref Email,ref Nationalty,ref imagePath))
            {
                return new ClsPerson(ID, NationalNo, Firstname, secondName, ThirdName, lastName, Gendor, DateOfBirth, Nationalty
                    , Phone, Email, Addrese, imagePath);
            }
            return null;
        }
        public static bool DeletePerson(int ID)
        {
            return DataAccessLayer.ClsPersonData.DeletePerson(ID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Addnew:
                    if (_AddnewPerson())
                    {
                        Mode = enMode.Update;
                        return true;

                    }
                    else
                        return false;

                case enMode.Update:

                    return _UpdatePerson();

            }
                return false;

            }







    }
}

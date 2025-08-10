using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace Business_Logic
{
    public class ClsUsers
    {
        enum enMode { AddNew,Update};
        enMode _Mode = enMode.AddNew;

        public int UserID { get; set; }
        public int PersonID { get; set; }
        public bool isActive { get; set; }
        public ClsPerson PersonInfo;
        public string UserName { get; set; }
        public string Password { get; set; }

       public ClsUsers()
        {
            UserID = -1;
            PersonID = -1;
            isActive = false;
            UserName = "";
            Password = "";

            _Mode = enMode.AddNew;
        }

        private ClsUsers(int UserID,int PersonID,bool isActiv,string UserName,string Password)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.isActive = isActiv;
            this.UserName = UserName;
            PersonInfo = ClsPerson.Find(PersonID);
            this.Password = Password;

            _Mode = enMode.Update;
        }
        public static bool DeleteUser(int UserID)
        {
            return ClsUsersData.DeleteUser(UserID);
        }
        public static ClsUsers GetUserByUserID(int UserID)
        {
            int  PersonID = -1;
            bool isActiv = false; string UserName="", Password="";

            if(ClsUsersData.GetUserbyUserID(UserID,ref PersonID,ref UserName,ref Password,ref isActiv))
            {
              return  new ClsUsers(UserID, PersonID, isActiv, UserName, Password);
            }
            return null;
        }
        public static ClsUsers GetUserByPersonID(int PersonID)
        {
            int UserID = -1;
            bool isActiv = false; string UserName = "", Password = "";
            if(ClsUsersData.GetUserbyPersonID(PersonID,ref UserID,ref UserName,ref Password,ref isActiv))
            {
                return new ClsUsers(UserID, PersonID, isActiv, UserName, Password);
            }
            return null;

        }
        public static ClsUsers GetUserbyUsernameAndPassword(string UsetName,string Password)
        {
            int UserID = -1;
            int PersonID = -1;
            bool isActiv = false;
            if(ClsUsersData.GetUserbyUsernameAndPassword(UsetName,Password,ref PersonID,ref UserID,ref isActiv))
            {
                return new ClsUsers(UserID, PersonID, isActiv, UsetName, Password);
            }
            return null;
        }
      
        public  static DataTable GetAllDataUsers()
        {
            return ClsUsersData.GetAllDataUsers();
        }
        private  bool _AddNewUser()
        {
            this.UserID = ClsUsersData.AddNewUser(this.PersonID, this.UserName, this.Password, this.isActive);

            return this.UserID != -1;
        }
        private bool _UpdateDataUser()
        {
            return ClsUsersData.UpdateUser(this.UserID, this.UserName, this.Password, this.isActive);
        }

        public static bool IsExistUser(int UserID)
        {
            return ClsUsersData.IsUserExist(UserID);
        }
        public static bool IsExistUseerByPersonID(int personID)
        {
            return ClsUsersData.IsUserExistForPersonID(personID);
        }
        public static bool IsExistUser(string UserName)
        {
            return ClsUsersData.IsUserExist(UserName);
        }

        public static bool ChangePassword(int UserID,string NewPassword)
        {
            return ClsUsersData.ChangePassword(UserID, NewPassword);
        }
        public bool Save()
        {
            switch (_Mode) {

                case enMode.AddNew:
                    if (_AddNewUser())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;


                case enMode.Update:
                            return _UpdateDataUser();


                           


                        }
            return false;
        }







        


    }
}

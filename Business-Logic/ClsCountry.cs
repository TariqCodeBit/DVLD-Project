using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace Business_Logic
{
    public class ClsCountry
    {
        
        public int ID { get; set; }
        public string NameCountry { get; set; }
        public ClsCountry()
        {
            this.ID = -1;
            this.NameCountry = "";
        }
       ClsCountry(int ID,string namecountry)
        {
            this.ID = ID;
            this.NameCountry = namecountry;
        }
      

        public static ClsCountry Finde(int ID)
        {
            string countryName = "";
            if (ClsCountryData.GetCountryByID(ID, ref countryName)){
                return new  ClsCountry(ID, countryName);
            }
            return null;
        }

        public static ClsCountry Finde(string CountryName)
        {
            int ID = -1;
            if(ClsCountryData.GetCountryByName(CountryName,ref ID))
            {
                return new ClsCountry(ID, CountryName);
            }
            return null;
        }
        public static DataTable Getallcountry()
        {
            return ClsCountryData.GetAllCountry();
        }









    }
}

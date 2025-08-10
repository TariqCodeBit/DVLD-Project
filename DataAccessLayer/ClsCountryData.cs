using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ContactsDataAccessLayer;
namespace DataAccessLayer
{
  public class ClsCountryData
    {
      public static DataTable GetAllCountry()
        {
            DataTable DataT = new DataTable();
            SqlConnection connection = new SqlConnection(ClsDataAccessSetting.Connection);
            string query = @"select * from Countries";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    DataT.Load(reader);
                    reader.Close();
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return DataT;

        }
        public static bool GetCountryByID(int ID, ref string Namecountry)
        {
            bool isfinde = false;
            SqlConnection connection = new SqlConnection(ClsDataAccessSetting.Connection);
            string query = @"select * from Countries where CountryID=@CountryID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountryID", ID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isfinde = true;
                    Namecountry = (string)reader["CountryName"];

                }
                else
                    isfinde = false;


                    reader.Close();
            }catch(Exception ex)
            {
                isfinde = false;
            }
            finally
            {
                connection.Close();
            }


            return isfinde;
        }


        public static bool GetCountryByName(string NameCountry,ref int ID)
        {
            bool isFinde = false;


            SqlConnection connection = new SqlConnection(ClsDataAccessSetting.Connection);
            string query = @"select * from Countries where CountryName=@CountryName;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountryName", NameCountry);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFinde = true;
                    ID = (int)reader["CountryID"];

                } else
                    isFinde = false;

                reader.Close();
            }catch(Exception ex)
            {
                isFinde = false;
            }
            finally
            {
                connection.Close();

            }
            return isFinde;



        }






    }
}

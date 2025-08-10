using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactsDataAccessLayer;

namespace DataAccessLayer
{
   public class ClsApplicationTypesData
    {
        public static DataTable GetAllAppType()
        {
            DataTable DataT = new DataTable();


            SqlConnection connection = new SqlConnection(ClsDataAccessSetting.Connection);

            string query = @"select * from ApplicationTypes";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader Reader = command.ExecuteReader();
                if(Reader.HasRows)
                DataT.Load(Reader);

                Reader.Close();

            }catch(Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return DataT;
        }

        public static bool UpdateDataApp(int ID,string AppTypeTitel,decimal AppFees)
        {
            int rowAfff = 0;
            SqlConnection connection = new SqlConnection(ClsDataAccessSetting.Connection);

            string query = @"Update ApplicationTypes
set ApplicationTypeTitle=@AppTypeTitel,
ApplicationFees=@AppFees
where ApplicationTypeID=@ID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AppTypeTitel", AppTypeTitel);
            command.Parameters.AddWithValue("@AppFees", AppFees);
            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();


                rowAfff = command.ExecuteNonQuery();

            }catch(Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();

            }

            return rowAfff > 0;

        }

        public static int AddNewAppTypes(string titel,decimal Fees)
        {
            int EndIDAdd = 0;
            SqlConnection connection = new SqlConnection(ClsDataAccessSetting.Connection);

            string query = @"INSERT INTO ApplicationTypes
           (ApplicationTypeTitle
           ,ApplicationFees)
     VALUES
           (@titel,@fees);select SCOPE_IDENTITY();
";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@titel", titel);
            command.Parameters.AddWithValue("@fees", Fees);

            try
            {
                connection.Open();

                object ans = command.ExecuteScalar();

                if(ans != null && int.TryParse(ans.ToString() , out int result))
                    EndIDAdd = result;

                

            }catch(Exception ex)
            {
                return -1;
            }
            finally
            {
                connection.Close();
            }
            return EndIDAdd;

        }
       
        public static bool GetAppTypersByID(int ID,ref string Titel,ref decimal Fees)
        {
            bool isFind = false;
            SqlConnection connection = new SqlConnection(ClsDataAccessSetting.Connection);

            string query = @"select * from ApplicationTypes where ApplicationTypeID=@ID ;" ;
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFind = true;
                    Titel = (string)reader["ApplicationTypeTitle"];
                    Fees = (decimal)reader["ApplicationFees"];
                }
                reader.Close();

            }catch(Exception ex)
            {
                return false;
            }
            finally
            {

                connection.Close();
                   
            }
            return isFind;
        }
    }
}
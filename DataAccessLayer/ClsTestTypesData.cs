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
    public class ClsTestTypesData
    {
        public static DataTable GetAllTestTypes()
        {

            DataTable DataT = new DataTable();
            SqlConnection connection = new SqlConnection(ClsDataAccessSetting.Connection);

            string query = @"select * from TestTypes;";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    DataT.Load(reader);

                }
                reader.Close();
            }catch(Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return DataT;

        }


        public static bool UpdateTestTypes(int ID,string Title,string Description,decimal Fees)
        {
            int rowAff = 0;
            SqlConnection connection = new SqlConnection(ClsDataAccessSetting.Connection);

            string query = @"update TestTypes
set TestTypeTitle=@Title,
TestTypeDescription=@Description,
TestTypeFees=@Fees
where TestTypeID=@ID ;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Title", Title);
            command.Parameters.AddWithValue("@Description", Description);
            command.Parameters.AddWithValue("@Fees", Fees);
            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();
                rowAff = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
            return (rowAff > 0);


        }



        public static bool FindByID(int ID,ref string Title,ref string Description,ref decimal Fees)
        {

            bool isFind = false;

            SqlConnection connection = new SqlConnection(ClsDataAccessSetting.Connection);

            string query = @"select * from TestTypes where TestTypeID=@ID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);


            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFind = true;
                    Title = (string)reader["TestTypeTitle"];
                    Description = (string)reader["TestTypeDescription"];
                    Fees = (decimal)reader["TestTypeFees"];
                }
                
                

                reader.Close();
            }
            catch(Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
            return isFind;



        }


        public static int AddTestTypes(string Title,string Description,decimal Fees)
        {
            int newID = -1;

            SqlConnection connection = new SqlConnection(ClsDataAccessSetting.Connection);

            String query = @"insert into TestTypes
(TestTypeTitle,TestTypeDescription,TestTypeFees)
Values
(@Title,@Description,@Fees);
select SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Title", Title);
            command.Parameters.AddWithValue("@Description", Description);
            command.Parameters.AddWithValue("@Fees", Fees);


            try
            {
                connection.Open();

                object ans = command.ExecuteScalar();

                if (ans != null && int.TryParse(ans.ToString(), out int result))
                    newID = result;


            }catch(Exception ex)
            {
                return -1;
            }
            finally
            {
                connection.Close();
            }
            return newID;
        }

    }
}

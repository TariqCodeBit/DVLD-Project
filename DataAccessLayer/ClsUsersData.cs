using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ContactsDataAccessLayer;

namespace DataAccessLayer
{
    public class ClsUsersData
    {
        public static DataTable GetAllDataUsers()
        {
            DataTable DataT = new DataTable();

            SqlConnection connection = new SqlConnection(ClsDataAccessSetting.Connection);
            string query = @"select UserID,P.PersonID,FullName=P.FirstName+' ' + P.SecondName +' '+ P.ThirdName +' '+ P.LastName , UserName,IsActive from Users
inner join People as P on Users.PersonID=P.PersonID;";

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


        public static int AddNewUser(int PersonID,string UserName,string Password,bool IsActive)
        {
            int UserID = -1;
            SqlConnection connection = new SqlConnection(ClsDataAccessSetting.Connection);
            string query = @"insert into Users
(PersonID,UserName,Password,IsActive)
Values (@PersonID,@UserName,@Password,@IsActive);select SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);

            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();
                if(Result !=null && int.TryParse(Result.ToString(),out int ans))
                {
                    UserID = ans;
                }
            }catch(Exception ex)
            {
                UserID = -1;
            }
            finally
            {
                connection.Close();
            }

            return UserID;
        }


        public static bool UpdateUser(int UserID,string Username,string Password,bool IsActive)
        {
            int rowAffict = 0;
            SqlConnection connection = new SqlConnection(ClsDataAccessSetting.Connection);
            string query = @"update Users
                            set UserName=@UserName,
                            Password=@Password,
                            IsActive=@IsActive
                            where UserID=@UserID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", Username);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();

                rowAffict = command.ExecuteNonQuery();


            }catch(Exception ex)
            {
                rowAffict = -1;
            }
            finally
            {
                connection.Close();
            }
            return (rowAffict > 0);
        }

        public static bool IsUserExist(int UserID)
        {
            bool isFind = false;
            SqlConnection connection = new SqlConnection(ClsDataAccessSetting.Connection);
            string query = @"select x=1 from Users where UserID=@UserID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                SqlDataReader read = command.ExecuteReader();
                isFind = read.HasRows;
                read.Close();

            }catch(Exception ex)
            {
                isFind = false;

            }
            finally
            {
                connection.Close();
            }
            return isFind;

        }
        public static bool IsUserExist(string Username)
        {
            bool isFind = false;
            SqlConnection connection = new SqlConnection(ClsDataAccessSetting.Connection);
            string query = @"select x=1 from Users where UserName=@UserName";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", Username);

            try
            {
                connection.Open();
                SqlDataReader read = command.ExecuteReader();
                isFind = read.HasRows;
                read.Close();

            }
            catch (Exception ex)
            {
                isFind = false;

            }
            finally
            {
                connection.Close();
            }
            return isFind;
        }
        public static bool IsUserExistForPersonID(int PersonID)
        {
            bool isFind = false;
            SqlConnection connection = new SqlConnection(ClsDataAccessSetting.Connection);
            string query = @"select x=1 from Users where PersonID=@PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader read = command.ExecuteReader();
                isFind = read.HasRows;
                read.Close();

            }
            catch (Exception ex)
            {
                isFind = false;

            }
            finally
            {
                connection.Close();
            }
            return isFind;
        }

        public static bool GetUserbyUserID(int UserID,ref int PersonID,ref string Username,ref string Password,ref bool IsActive)
        {
            bool isfind = false;


            SqlConnection connection = new SqlConnection(ClsDataAccessSetting.Connection);
            string query = @"select * from Users where UserID=@UserID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isfind = true;
                    PersonID = (int)reader["PersonID"];
                    Username = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["IsActive"];

                }
                reader.Close();
            }
            catch(Exception ex)
            {
                isfind = false;
            }
            finally
            {
                connection.Close();
            }
            return isfind;

        }
        public static bool GetUserbyPersonID(int PersonID,ref int UserID,ref string Username,ref string Password,ref bool IsActive)
        {
            bool isFind = false;
            SqlConnection connection = new SqlConnection(ClsDataAccessSetting.Connection);
            string query = @"select * from Users where PersonID=@PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFind = true;
                    PersonID = (int)reader["PersonID"];
                    Username = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["IsActive"];

                }
                reader.Close();
            }catch(Exception ex)
            {
                isFind = false;
            }
            finally
            {
                connection.Close();
            }
            return isFind;
        }

        public static bool GetUserbyUsernameAndPassword( string Username, string Password,ref int PersonID, ref int UserID,   ref bool IsActive)
        {
            bool isFind = false;
            SqlConnection connection = new SqlConnection(ClsDataAccessSetting.Connection);
            string query = @"select * from Users where UserName=@UserName and Password=@Password ;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", Username);
            command.Parameters.AddWithValue("@Password", Password);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFind = true;
                    PersonID = (int)reader["PersonID"];
                    UserID = (int)reader["UserID"];
                    IsActive = (bool)reader["IsActive"];

                }
                reader.Close();
            }catch(Exception ex)
            {
                isFind = false;
            }
            finally
            {
                connection.Close();
            }
            return isFind;
        }
        public static bool DeleteUser(int UserID)
        {
            int rowAffict = 0;

            SqlConnection connection = new SqlConnection(ClsDataAccessSetting.Connection);

            string query = @"DELETE FROM Users
      WHERE UserID=@UserID;";
            SqlCommand comman = new SqlCommand(query, connection);
            comman.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                rowAffict = comman.ExecuteNonQuery();

            }catch(Exception ex)
            {
                rowAffict = 0;
            }
            finally
            {
                connection.Close();

            }
            return (rowAffict > 0);
        }

        public static bool ChangePassword(int UserID,string NewPassword)
        {
            int rowAfficting = 0;
            SqlConnection connection = new SqlConnection(ClsDataAccessSetting.Connection);
            string query = @"UPDATE Users
   SET
      Password = @Password
      
 WHERE UserID=@UserID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Password", NewPassword);
            command.Parameters.AddWithValue("@UserID", UserID);


            try
            {
                connection.Open();

                rowAfficting = command.ExecuteNonQuery();

            }catch(Exception ex)
            {
                rowAfficting = 0;
            }
            finally
            {
                connection.Close();
            }
            return rowAfficting > 0;
        }
      
    }
}

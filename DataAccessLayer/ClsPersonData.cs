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
    public class ClsPersonData
    {

        public static DataTable GetAllPeople()
        {
            DataTable DTable = new DataTable();
            SqlConnection connection = new SqlConnection(ClsDataAccessSetting.Connection);
            string query = @"
select PersonID , NationalNo , FirstName,SecondName , ThirdName,LastName,  CASE 
        WHEN Gendor = 0 THEN 'Male' 
        WHEN Gendor = 1 THEN 'Female' 
        ELSE 'Unknown'
    END AS Gender,DateOfBirth,c.CountryName,Phone,Email from People
inner join Countries as c on People.NationalityCountryID=c.CountryID";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    DTable.Load(reader);
                }
                reader.Close();
                connection.Close();

            }
            catch(Exception ex)
            {

            }
            finally
            {
                connection.Close();

            }
            return DTable;
        }

        public static int AddNewPerson(string NationalNO,string FirstName,
            string SecondName,string ThirdName,string LastName,DateTime DateOfBirth,
           short Gendor , string Address,string Phone,string Email,int NationalityCountryID ,
           string ImagePath)
        {
            int Idrecord = -1;
            SqlConnection connection = new SqlConnection(ClsDataAccessSetting.Connection);
            string query = @"INSERT INTO People
           (NationalNo
           ,FirstName
           ,SecondName
           ,ThirdName
           ,LastName
           ,DateOfBirth
           ,Gendor
           ,Address
           ,Phone
           ,Email
           ,NationalityCountryID
           ,ImagePath)
     VALUES  (@NationalNo,@FirstName,@SecondName,@ThirdName,@LastName,@DateOfBirth,@Gendor,@Address,@Phone,@Email,@NationalityCountryID,@ImagePath)
; SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNO);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            if (ThirdName != "" && ThirdName != null)
            {
                command.Parameters.AddWithValue("@ThirdName", ThirdName);
            }
            else
                command.Parameters.AddWithValue("@ThirdName", System.DBNull.Value);

                command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);
            if (Email != "" && Email != null)
            {
                command.Parameters.AddWithValue("@Email", Email);
            }
            else
                command.Parameters.AddWithValue("@Email", System.DBNull.Value);

                command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            if (ImagePath != "" && ImagePath != null)
            {
                command.Parameters.AddWithValue("ImagePath", ImagePath);
               
            }
            else
                 command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);

            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();
                if(Result !=null &&  int.TryParse(Result.ToString() ,out int idPerson))
                {
                    Idrecord = idPerson;
                }
            }catch(Exception ex)
            {
                Idrecord = -1;
            }finally
            {
                connection.Close();
            }

            return Idrecord;





        }


        public static bool UpdatePerson(int ID,string NationalNO, string FirstName,
            string SecondName, string ThirdName, string LastName, DateTime DateOfBirth,
           short Gendor, string Address, string Phone, string Email, int NationalityCountryID,
           string ImagePath)
        {

            int recordAffict = 0;
            SqlConnection connection = new SqlConnection(ClsDataAccessSetting.Connection);
            string query = @"UPDATE People
   SET NationalNo= @NationalNo
      ,FirstName= @FirstName
      ,SecondName = @SecondName
      ,ThirdName = @ThirdName
      ,LastName = @LastName
      ,DateOfBirth = @DateOfBirth
      ,Gendor = @Gendor
      ,Address = @Address
      ,Phone = @Phone
      ,Email =@Email
      ,NationalityCountryID =@NationalityCountryID
      ,ImagePath = @ImagePath
 WHERE  PersonID=@ID ;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@NationalNo", NationalNO);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            if (ThirdName != "" && ThirdName != null)
            {
                command.Parameters.AddWithValue("@ThirdName", ThirdName);

            }
            else
                command.Parameters.AddWithValue("ThirdName", System.DBNull.Value);


            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);
            if (Email != "" && Email != null)
            {
                command.Parameters.AddWithValue("@Email", Email);
            }
            else
                command.Parameters.AddWithValue("@Email", System.DBNull.Value);
              
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            if (ImagePath != "" && ImagePath != null)
            {
                command.Parameters.AddWithValue("ImagePath", ImagePath);
               
            }
            else
                 command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);

            try
            {
                connection.Open();
                recordAffict = command.ExecuteNonQuery();

            }catch(Exception ex)
            {
                recordAffict = 0;
            }
            finally
            {
                connection.Close();
            }
            return (recordAffict > 0);




        }

        public static bool IsPersonExist(int ID)
        {
            bool isFinde = false;
            SqlConnection connection = new SqlConnection(ClsDataAccessSetting.Connection);
            string qurye = @"select x=1 from People where PersonID=@ID";

            SqlCommand command = new SqlCommand(qurye, connection);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isFinde = reader.HasRows;
                reader.Close();
            }
            catch ( Exception ex)
            {
                isFinde = false;
            }
            finally {
                connection.Close();
            }

            return isFinde;

        }

        public static bool IsPersonExist(string NationalNo)
        {
            bool isFinde = false;

            SqlConnection connection = new SqlConnection(ClsDataAccessSetting.Connection);
            String query = @"select x=1 from People where NationalNo=@NationalNO;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("NationalNo", NationalNo);
            try
            {
                connection.Open();
                SqlDataReader read = command.ExecuteReader();
                isFinde = read.HasRows;

                read.Close();
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

        public static bool GetPersonInfoByID(int ID,ref string NationalNO,ref string FirstName,
           ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth,
           ref short Gendor, ref string Address, ref string Phone, ref string Email, ref int NationalityCountryID,
           ref string ImagePath)
        {
            bool isfinde = false;

            SqlConnection connection = new SqlConnection(ClsDataAccessSetting.Connection);

            string query = @"select * from People where PersonID=@ID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isfinde = true;
                    NationalNO = (string)reader["NationalNo"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    if (reader["ThirdName"] != System.DBNull.Value)
                        ThirdName = (string)reader["ThirdName"];
                    else
                        ThirdName = "";
                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = (byte)reader["Gendor"];
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];
                    if (reader["Email"] != DBNull.Value)
                        Email = (string)reader["Email"];
                    else
                        Email = "";
                        NationalityCountryID = (int)reader["NationalityCountryID"];
                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }
                    else
                        ImagePath = "";

                } else
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


        public static bool GetPersonInfoBynationalNo(string NationalNO,ref int ID, ref string FirstName,
           ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth,
           ref short Gendor, ref string Address, ref string Phone, ref string Email, ref int NationalityCountryID,
           ref string ImagePath)
        {

            bool isfinde = false;

            SqlConnection connection = new SqlConnection(ClsDataAccessSetting.Connection);

            string query = @"select * from People where NationalNo='@NationalNo';";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNO);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isfinde = true;
                    ID = (int)reader["PersonID"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    if (reader["ThirdName"] != System.DBNull.Value)
                        ThirdName = (string)reader["ThirdName"];
                    else
                        ThirdName = "";
                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = (short)reader["Gendor"];
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];
                    if (reader["Email"] != DBNull.Value)
                        Email = (string)reader["Email"];
                    else
                        Email = "";
                    NationalityCountryID = (int)reader["NationalityCountryID"];
                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }
                    else
                        ImagePath = "";

                }
                else
                    isfinde = false;

                reader.Close();

            }
            catch (Exception ex)
            {
                isfinde = false;
            }
            finally
            {
                connection.Close();
            }

            return isfinde;





        }
        

        public static bool DeletePerson(int PersonID)
        {
            int rowAffic = 0;

            SqlConnection connection = new SqlConnection(ClsDataAccessSetting.Connection);
            string query = @"Delete from People where PersonID=@PersonID; ";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                rowAffic = command.ExecuteNonQuery();

            }
            catch
            {
                rowAffic = 0;
            }
            finally
            {
                connection.Close();
            }
            return (rowAffic != 0);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Audiogram.Model;
using AutoMapper;


namespace Audiogram.DataAccess
{
    public class UserRepository
    {

        public static string ValidateCredentials(string username, string password)
        {
            string UserId;
            string user = username;
            bool isUserActive;

            var connection = DBConnection.GetConnection();

            using (SqlCommand cmd = new SqlCommand("Login", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Username", user);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.Add("@userId", SqlDbType.Int);
                cmd.Parameters["@userId"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("@IsUserActive", SqlDbType.Bit);
                cmd.Parameters["@IsUserActive"].Direction = ParameterDirection.Output;
                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }

                catch (SqlException ex)
                {
                    Logger.logging.log.Error(ex.StackTrace);
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }

                isUserActive = Convert.ToBoolean(cmd.Parameters["@IsUserActive"].Value.ToString());
                UserId = cmd.Parameters["@userId"].Value.ToString();

                return isUserActive + "|" + UserId;


            }
        }

        public static DataTable GetSessionDetails(int userId)
        {

            var connection = DBConnection.GetConnection();
            DataTable dataTable = new DataTable();
            using (SqlCommand cmd = new SqlCommand("GetSessionDetails", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", userId);
                try
                {
                    connection.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    dataAdapter.Fill(dataTable);
                }

                catch (SqlException ex)
                {
                    Logger.logging.log.Error(ex.StackTrace);
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }

                return dataTable;


            }



        }
        
        public static string Hash(string password)
        {
            string stringshPassword;
            string plainpass = password;
            //hashing password 
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(plainpass);
            SHA1 sha = new SHA1CryptoServiceProvider();
            byte[] shPassword = sha.ComputeHash(bytes);
            stringshPassword = BitConverter.ToString(shPassword);
            return stringshPassword;
        }
        
        public static bool IsValidUser(string User, int AccountHolderId)
        {

            var connection = DBConnection.GetConnection();
            
            DataTable dataTable = new DataTable();

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }


                SqlCommand command = new SqlCommand("usp_validateUser", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@User", User);
                command.Parameters.AddWithValue("@AccountHolderId", AccountHolderId);

                DataRow dataRow = dataTable.NewRow();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataTable);
                dataRow = dataTable.Rows[0];
                if (Convert.ToInt32(dataRow["IsUserExist"]) != 0)
                {

                    return true;
                }

                else
                {
                    return false;
                }
            }
            catch (SqlException ex)
            {

                throw ex;

            }

            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }


        }
        
        public static User GetUserDetails(int userId)
        {

            var connection = DBConnection.GetConnection();
            List<User> UserInfo = new List<User>();
            DataTable dataTable = new DataTable();
            using (SqlCommand cmd = new SqlCommand("usp_getUserInfo", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", userId);
                try
                {
                    connection.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    dataAdapter.Fill(dataTable);
                    UserInfo = AutoMapper.Mapper.DynamicMap<IDataReader, List<User>>(dataTable.CreateDataReader());
                }

                catch (SqlException ex)
                {
                    Logger.logging.log.Error(ex.StackTrace);
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }

                return UserInfo[0];


            }



        }

    }
}

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
    public class DriverRepository
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

        public static List<string> SuggestionCompanies(string Customers)
        {
            List<string> customers = new List<string>();
            using (var connection = DBConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand("usp_searchAccountHolder", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AccountHolderName", Customers);
                try
                {
                    connection.Open();

                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {

                            string a = sdr["AccountHolderName"].ToString();
                            string b = sdr["AccountHolderId"].ToString();
                            customers.Add(a + "|" + b);

                        }
                    }




                }
                catch (SqlException ex)
                {
                    Logger.logging.log.Error(ex.StackTrace);
                    throw ex;
                }
                return customers;
            }
        }

        public static object GetDriverList(string SearchDriver, int RecordFrom, string JSorting, int RecordTo,bool forDropDown = false)
        {
            string[] words = JSorting.Split(' ');
            string jtsortColumn = words[0];
            string jtsortOrder = words[1];
            var connection = DBConnection.GetConnection();

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                SqlCommand command = new SqlCommand("usp_searchDrivers", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@SearchDriver", SearchDriver);
                command.Parameters.AddWithValue("@recordsFrom", RecordFrom);
                command.Parameters.AddWithValue("@recordsTo", RecordTo);
                command.Parameters.AddWithValue("@lSortCol", jtsortColumn);
                command.Parameters.AddWithValue("@SortOrder", jtsortOrder);
                DataSet dataset = new DataSet();
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = command;
                dataAdapter.Fill(dataset);
                Mapper.CreateMap<IDataReader, Driver>();
                IDataReader dataReader = command.ExecuteReader();
                List<Driver> lstDriver = Mapper.Map<List<Driver>>(dataReader);
                
                if (forDropDown)
                    {
                        lstDriver = lstDriver.Where(x => x.Status == 0).ToList();
                        Driver temp = new Driver();
                        temp.ID = 0;
                        temp.Name = "--SELECT--";
                        lstDriver.Insert(0, temp);
                    }


                int totalCount = Convert.ToInt32((dataset.Tables[1].Rows[0] as DataRow).ItemArray[0]);
                return new { Result = "OK", Records = lstDriver, TotalRecordCount = totalCount };

            }
            catch (Exception ex)
            {
                Logger.logging.log.Error("error:" + ex.Message);
                return new { Result = "ERROR", Message = "Could not connect to database. Please contact the System Administrator." };
            }

            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public static object CreateDriver(Driver addedRecord)
        {

            //int IsCreated = 0;
            var connection = DBConnection.GetConnection();
            DataTable dataTable = new DataTable();
           
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }


                SqlCommand command = new SqlCommand("usp_CreateDriver", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", addedRecord.Name);
                command.Parameters.AddWithValue("@CurrentAddress", addedRecord.CurrentAddress);
                command.Parameters.AddWithValue("@FatherName", addedRecord.FatherName);
                if (addedRecord.DOB.ToString() == "1/1/0001 12:00:00 AM" || addedRecord.DOB == null)
                {
                    command.Parameters.AddWithValue("@DOB", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@DOB", addedRecord.DOB);
                }
                command.Parameters.AddWithValue("@NIC", addedRecord.NIC);
                command.Parameters.AddWithValue("@Address", addedRecord.Address);
                command.Parameters.AddWithValue("@IsActive", addedRecord.IsActive);
                command.Parameters.AddWithValue("@Cell", addedRecord.Cell);
                command.Parameters.AddWithValue("@License", addedRecord.License);
                if (addedRecord.LicenseExpiryDate.ToString() == "1/1/0001 12:00:00 AM" || addedRecord.LicenseExpiryDate == null)
                {
                    command.Parameters.AddWithValue("@LicenseExpiryDate", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@LicenseExpiryDate", addedRecord.LicenseExpiryDate);
                }
                if (addedRecord.NICExpiryDate.ToString() == "1/1/0001 12:00:00 AM" || addedRecord.NICExpiryDate == null)
                {
                    command.Parameters.AddWithValue("@NICExpiryDate", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NICExpiryDate", addedRecord.NICExpiryDate);
                }

                DataRow dataRow = dataTable.NewRow();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataTable);
                dataRow = dataTable.Rows[0];

                if (Convert.ToInt32(dataRow["IsCreated"]) == 0)
                {
                    return new { Result = "ERROR", Message = dataRow["CreatedMessage"] };
                }

                else
                {
                    addedRecord.ID = Convert.ToInt32(dataRow["ID"]);
                    return new { Result = "OK", Record = addedRecord };
                }
            }
            catch (Exception ex)
            {
                Logger.logging.log.Error(ex.StackTrace);
                return new { Result = "ERROR", Message = "Could not save Driver. Please contact the System Administrator." };
            }

            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public static object UpdateDriver(Driver updatedRecord)
        {
            int IsUpdated = 0;
            var connection = DBConnection.GetConnection();
            DataTable dataTable = new DataTable();
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                SqlCommand command = new SqlCommand("usp_UpdateDriver", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", updatedRecord.ID);
                command.Parameters.AddWithValue("@Name", updatedRecord.Name);
                command.Parameters.AddWithValue("@FatherName", updatedRecord.FatherName);
                command.Parameters.AddWithValue("@CurrentAddress", updatedRecord.CurrentAddress);
                if (updatedRecord.DOB.ToString() == "1/1/0001 12:00:00 AM" || updatedRecord.DOB == null)
                {
                    command.Parameters.AddWithValue("@DOB", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@DOB", updatedRecord.DOB);
                }
                command.Parameters.AddWithValue("@NIC", updatedRecord.NIC);
                command.Parameters.AddWithValue("@Address", updatedRecord.Address);
                command.Parameters.AddWithValue("@IsActive", updatedRecord.IsActive);
                command.Parameters.AddWithValue("@Cell", updatedRecord.Cell);
                command.Parameters.AddWithValue("@License", updatedRecord.License);
                if (updatedRecord.LicenseExpiryDate.ToString() == "1/1/0001 12:00:00 AM" || updatedRecord.LicenseExpiryDate == null)
                {
                    command.Parameters.AddWithValue("@LicenseExpiryDate", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@LicenseExpiryDate", updatedRecord.LicenseExpiryDate);
                }
                if (updatedRecord.NICExpiryDate.ToString() == "1/1/0001 12:00:00 AM" || updatedRecord.NICExpiryDate == null)
                {
                    command.Parameters.AddWithValue("@NICExpiryDate", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NICExpiryDate", updatedRecord.NICExpiryDate);
                }
                DataRow dataRow = dataTable.NewRow();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataTable);
                dataRow = dataTable.Rows[0];
                IDataReader dataReader = command.ExecuteReader();
                IsUpdated = Convert.ToInt32(dataRow["IsUpdated"]);
                if (IsUpdated == 0)
                { return new { Result = "ERROR", Message = "This Driver already exists." }; }
                else
                {
                    return new { Result = "OK" };
                }
            }
            catch (Exception ex)
            {

                Logger.logging.log.Error(ex.StackTrace);
                return new { Result = "ERROR", Message = "Could not connect to database. Please contact the System Administrator." };
            }

            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

        }

        public static object DeleteDriver(int Id)
        {
            int error = 0;
            var connection = DBConnection.GetConnection();
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                SqlCommand command = new SqlCommand("usp_DeleteDriver", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", Id);
                command.Parameters.Add("@err_message", SqlDbType.Int);
                command.Parameters["@err_message"].Direction = ParameterDirection.Output;
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                IDataReader dataReader = command.ExecuteReader();
                error = Convert.ToInt32(command.Parameters["@err_message"].Value);
                if (error == 1)
                { return new { Result = "ERROR", Message = "Unable to delete driver." }; }
                else
                {
                    return new { Result = "OK" };
                }

            }
            catch (Exception ex)
            {

                Logger.logging.log.Error(ex.StackTrace);
                return new { Result = "ERROR", Message = "Could not connect to database. Please contact the System Administrator." };

            }

            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
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
       
        public static List<string> SuggestDriver(string Driver, int AccountHolderId)
        {
            DriverRepository UserRepo = new DriverRepository();
            List<string> customers = new List<string>();
            using (var connection = DBConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand("usp_SuggestDriver", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Driver", Driver);

                try
                {
                    connection.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            string a = sdr["UserName"].ToString();
                            customers.Add(a);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Logger.logging.log.Error(ex.StackTrace);
                    throw ex;
                }
                return customers;
            }
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

        public static Driver GetDriverDetail(int driverId)
        {

            var connection = DBConnection.GetConnection();
            List<Driver> UserInfo = new List<Driver>();
            DataTable dataTable = new DataTable();
            using (SqlCommand cmd = new SqlCommand("usp_getDriverInfo", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DriverId", driverId);
                try
                {
                    connection.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    dataAdapter.Fill(dataTable);
                    UserInfo = AutoMapper.Mapper.DynamicMap<IDataReader, List<Driver>>(dataTable.CreateDataReader());
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

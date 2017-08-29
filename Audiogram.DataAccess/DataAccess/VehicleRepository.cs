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
    public class VehicleRepository
    {

        public static object GetVehicleList(string SearchVehicle, int RecordFrom, string JSorting, int RecordTo,string status = "",bool forDropDown = false)
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

                SqlCommand command = new SqlCommand("usp_SearchVehicle", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@SearchVehicle", SearchVehicle);
                command.Parameters.AddWithValue("@recordsFrom", RecordFrom);
                command.Parameters.AddWithValue("@recordsTo", RecordTo);
                command.Parameters.AddWithValue("@lSortCol", jtsortColumn);
                command.Parameters.AddWithValue("@SortOrder", jtsortOrder);
                DataSet dataset = new DataSet();
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = command;
                dataAdapter.Fill(dataset);
                Mapper.CreateMap<IDataReader, Vehicle>();
                IDataReader dataReader = command.ExecuteReader();
                List<Vehicle> lstVehicles = Mapper.Map<List<Vehicle>>(dataReader);

                if (status == "active")
                {
                    lstVehicles = lstVehicles.Where(x => x.Status == 1).ToList();
                }
                else if (status == "idle")
                {
                    lstVehicles = lstVehicles.Where(x => x.Status == 0).ToList();
                }

                if (forDropDown)
                {
                    lstVehicles = lstVehicles.Where(x => x.Status == 0).ToList();
                    Vehicle temp = new Vehicle();
                    temp.ID = 0;
                    temp.Make = "--SELECT--";
                    lstVehicles.Insert(0, temp);
                }

                int totalCount = Convert.ToInt32((dataset.Tables[1].Rows[0] as DataRow).ItemArray[0]);
                return new { Result = "OK", Records = lstVehicles, TotalRecordCount = totalCount };

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

        public static object CreateVehicle(Vehicle addedRecord)
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


                SqlCommand command = new SqlCommand("usp_CreateVehicle", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Make", addedRecord.Make);
                command.Parameters.AddWithValue("@Model", addedRecord.Model);
                command.Parameters.AddWithValue("@Version", addedRecord.Version);
                command.Parameters.AddWithValue("@Year", addedRecord.Year);
                command.Parameters.AddWithValue("@CC", addedRecord.CC);
                command.Parameters.AddWithValue("@NumberPlate", addedRecord.NumberPlate);
                command.Parameters.AddWithValue("@Color", addedRecord.Color);
                command.Parameters.AddWithValue("@IsActive", addedRecord.IsActive);
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
                return new { Result = "ERROR", Message = "Could not save Vehicle. Please contact the System Administrator." };
            }

            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public static object UpdateVehicle(Vehicle updatedRecord)
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

                SqlCommand command = new SqlCommand("usp_UpdateVehicle", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", updatedRecord.ID);
                command.Parameters.AddWithValue("@Make", updatedRecord.Make);
                command.Parameters.AddWithValue("@Model", updatedRecord.Model);
                command.Parameters.AddWithValue("@Version", updatedRecord.Version);
                command.Parameters.AddWithValue("@Year", updatedRecord.Year);
                command.Parameters.AddWithValue("@CC", updatedRecord.CC);
                command.Parameters.AddWithValue("@NumberPlate", updatedRecord.NumberPlate);
                command.Parameters.AddWithValue("@Color", updatedRecord.Color);
                command.Parameters.AddWithValue("@IsActive", updatedRecord.IsActive);
                DataRow dataRow = dataTable.NewRow();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataTable);
                dataRow = dataTable.Rows[0];
                IDataReader dataReader = command.ExecuteReader();
                IsUpdated = Convert.ToInt32(dataRow["IsUpdated"]);
                if (IsUpdated == 0)
                { return new { Result = "ERROR", Message = "This Vehicle already exists." }; }
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

        public static object DeleteVehicle(int Id)
        {
            int error = 0;
            var connection = DBConnection.GetConnection();
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                SqlCommand command = new SqlCommand("usp_DeleteVehicle", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", Id);
                command.Parameters.Add("@err_message", SqlDbType.Int);
                command.Parameters["@err_message"].Direction = ParameterDirection.Output;
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                IDataReader dataReader = command.ExecuteReader();
                error = Convert.ToInt32(command.Parameters["@err_message"].Value);
                if (error == 1)
                { return new { Result = "ERROR", Message = "Unable to delete vehicle." }; }
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

    }
}

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
using Audiogram.DataAccess.Model;


namespace Audiogram.DataAccess
{
    public class TireRepository
    {
        public static object GetTireList(int vehicleId, int RecordFrom, string JSorting, int RecordTo)
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

                SqlCommand command = new SqlCommand("usp_searchTires", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@vehicleId", vehicleId);
                command.Parameters.AddWithValue("@recordsFrom", RecordFrom);
                command.Parameters.AddWithValue("@recordsTo", RecordTo);
                command.Parameters.AddWithValue("@lSortCol", jtsortColumn);
                command.Parameters.AddWithValue("@SortOrder", jtsortOrder);
                DataSet dataset = new DataSet();
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = command;
                dataAdapter.Fill(dataset);
                Mapper.CreateMap<IDataReader, Tire>();
                IDataReader dataReader = command.ExecuteReader();
                List<Tire> lstAccountHolder = Mapper.Map<List<Tire>>(dataReader);
                int totalCount = Convert.ToInt32((dataset.Tables[1].Rows[0] as DataRow).ItemArray[0]);
                return new { Result = "OK", Records = lstAccountHolder, TotalRecordCount = totalCount };

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

        public static object DeleteTire(int Id)
        {
            int error = 0;
            var connection = DBConnection.GetConnection();
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                SqlCommand command = new SqlCommand("usp_DeleteTire", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", Id);
                command.Parameters.Add("@err_message", SqlDbType.Int);
                command.Parameters["@err_message"].Direction = ParameterDirection.Output;
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                IDataReader dataReader = command.ExecuteReader();
                error = Convert.ToInt32(command.Parameters["@err_message"].Value);
                if (error == 1)
                { return new { Result = "ERROR", Message = "Unable to delete tire." }; }
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

        public static object CreateTire(Model.Tire tire)
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


                SqlCommand command = new SqlCommand("usp_CreateTire", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Number", tire.Number);
                command.Parameters.AddWithValue("@Pattern", tire.Pattern);
                command.Parameters.AddWithValue("@LotNumber", tire.LotNumber);
                if (tire.TireAddOn.ToString() == "1/1/0001 12:00:00 AM" || tire.TireAddOn == null)
                {
                    command.Parameters.AddWithValue("@TireAddOn", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@TireAddOn", tire.TireAddOn);
                }
                if (tire.TireRemoveOn.ToString() == "1/1/0001 12:00:00 AM" || tire.TireRemoveOn == null)
                {
                    command.Parameters.AddWithValue("@TireRemoveOn", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@TireRemoveOn", tire.TireRemoveOn);
                }
                command.Parameters.AddWithValue("@VehicleId", tire.VehicleId);

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
                    tire.ID = Convert.ToInt32(dataRow["ID"]);
                    return new { Result = "OK", Record = tire };
                }
            }
            catch (Exception ex)
            {
                Logger.logging.log.Error(ex.StackTrace);
                return new { Result = "ERROR", Message = "Could not save tire. Please contact the System Administrator." };
            }

            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }


        }

        public static object UpdateTire(Model.Tire tire)
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


                SqlCommand command = new SqlCommand("usp_UpdateTire", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", tire.ID);
                command.Parameters.AddWithValue("@Number", tire.Number);
                command.Parameters.AddWithValue("@Pattern", tire.Pattern);
                command.Parameters.AddWithValue("@LotNumber", tire.LotNumber);
                if (tire.TireAddOn.ToString() == "1/1/0001 12:00:00 AM" || tire.TireAddOn == null)
                {
                    command.Parameters.AddWithValue("@TireAddOn", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@TireAddOn", tire.TireAddOn);
                }
                if (tire.TireRemoveOn.ToString() == "1/1/0001 12:00:00 AM" || tire.TireRemoveOn == null)
                {
                    command.Parameters.AddWithValue("@TireRemoveOn", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@TireRemoveOn", tire.TireRemoveOn);
                }

                DataRow dataRow = dataTable.NewRow();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataTable);
                dataRow = dataTable.Rows[0];

                if (Convert.ToInt32(dataRow["IsUpdated"]) == 0)
                {
                    return new { Result = "ERROR", Message = "Tire Updated Successfully !" };
                }

                else
                {
                    return new { Result = "OK", Record = tire };
                }
            }
            catch (Exception ex)
            {
                Logger.logging.log.Error(ex.StackTrace);
                return new { Result = "ERROR", Message = "Could not update tire. Please contact the System Administrator." };
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

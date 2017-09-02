using Audiogram.DataAccess.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audiogram.DataAccess
{
    public class SettlementRepository
    {

        public static object GetSettlementList(int TripId, int RecordFrom, string JSorting, int RecordTo, string status = "", bool forDropDown = false)
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

                SqlCommand command = new SqlCommand("usp_SearchSettlements", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@TripId", TripId);
                command.Parameters.AddWithValue("@recordsFrom", RecordFrom);
                command.Parameters.AddWithValue("@recordsTo", RecordTo);
                command.Parameters.AddWithValue("@lSortCol", jtsortColumn);
                command.Parameters.AddWithValue("@SortOrder", jtsortOrder);
                DataSet dataset = new DataSet();
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = command;
                dataAdapter.Fill(dataset);
                Mapper.CreateMap<IDataReader, Settlement>();
                IDataReader dataReader = command.ExecuteReader();
                List<Settlement> lstSettlements = Mapper.Map<List<Settlement>>(dataReader);

                int totalCount = Convert.ToInt32((dataset.Tables[1].Rows[0] as DataRow).ItemArray[0]);
                return new { Result = "OK", Records = lstSettlements, TotalRecordCount = totalCount };

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

        public static object CreateSettlement(Settlement addedRecord)
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


                SqlCommand command = new SqlCommand("usp_CreateSettlement", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PreviousPeshgi", addedRecord.PreviousPeshgi);
                command.Parameters.AddWithValue("@CashAdvDeposit", addedRecord.CashAdvDeposit);
                command.Parameters.AddWithValue("@PurchoonFrieghtUp", addedRecord.PurchoonFrieghtUp);
                command.Parameters.AddWithValue("@PurchoonFrightReturn", addedRecord.PurchoonFrightReturn);
                command.Parameters.AddWithValue("@PumpCashLoan", addedRecord.PumpCashLoan);
                command.Parameters.AddWithValue("@MiscCashLoan", addedRecord.MiscCashLoan);
                command.Parameters.AddWithValue("@SetMisc1", addedRecord.SetMisc1);
                command.Parameters.AddWithValue("@SetMisc2", addedRecord.SetMisc2);
                command.Parameters.AddWithValue("@SetMisc3", addedRecord.SetMisc3);
                command.Parameters.AddWithValue("@SetMisc4", addedRecord.SetMisc4);
                command.Parameters.AddWithValue("@TripId", addedRecord.TripId);

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
                return new { Result = "ERROR", Message = "Could not save Data. Please contact the System Administrator." };
            }

            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public static object UpdateSettlement(Settlement updatedRecord)
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

                SqlCommand command = new SqlCommand("usp_UpdateSettlement", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", updatedRecord.ID);
                command.Parameters.AddWithValue("@PreviousPeshgi", updatedRecord.PreviousPeshgi);
                command.Parameters.AddWithValue("@CashAdvDeposit", updatedRecord.CashAdvDeposit);
                command.Parameters.AddWithValue("@PurchoonFrieghtUp", updatedRecord.PurchoonFrieghtUp);
                command.Parameters.AddWithValue("@PurchoonFrightReturn", updatedRecord.PurchoonFrightReturn);
                command.Parameters.AddWithValue("@PumpCashLoan", updatedRecord.PumpCashLoan);
                command.Parameters.AddWithValue("@MiscCashLoan", updatedRecord.MiscCashLoan);
                command.Parameters.AddWithValue("@SetMisc1", updatedRecord.SetMisc1);
                command.Parameters.AddWithValue("@SetMisc2", updatedRecord.SetMisc2);
                command.Parameters.AddWithValue("@SetMisc3", updatedRecord.SetMisc3);
                command.Parameters.AddWithValue("@SetMisc4", updatedRecord.SetMisc4);
                DataRow dataRow = dataTable.NewRow();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataTable);
                dataRow = dataTable.Rows[0];
                IDataReader dataReader = command.ExecuteReader();
                IsUpdated = Convert.ToInt32(dataRow["IsUpdated"]);
                if (IsUpdated == 0)
                { return new { Result = "ERROR", Message = "This Data already exists." }; }
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

        public static object DeleteSettlement(int Id)
        {
            int error = 0;
            var connection = DBConnection.GetConnection();
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                SqlCommand command = new SqlCommand("usp_DeleteSettlement", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", Id);
                command.Parameters.Add("@err_message", SqlDbType.Int);
                command.Parameters["@err_message"].Direction = ParameterDirection.Output;
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                IDataReader dataReader = command.ExecuteReader();
                error = Convert.ToInt32(command.Parameters["@err_message"].Value);
                if (error == 1)
                { return new { Result = "ERROR", Message = "Unable to delete Data." }; }
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

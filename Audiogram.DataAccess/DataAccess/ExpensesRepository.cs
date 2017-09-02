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
    public class ExpensesRepository
    {

        public static object GetExpensesList(int TripId, int RecordFrom, string JSorting, int RecordTo, string status = "", bool forDropDown = false)
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

                SqlCommand command = new SqlCommand("usp_SearchExpenses", connection);
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
                Mapper.CreateMap<IDataReader, Expenses>();
                IDataReader dataReader = command.ExecuteReader();
                List<Expenses> lstExpenses = Mapper.Map<List<Expenses>>(dataReader);

                int totalCount = Convert.ToInt32((dataset.Tables[1].Rows[0] as DataRow).ItemArray[0]);
                return new { Result = "OK", Records = lstExpenses, TotalRecordCount = totalCount };

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

        public static object CreateExpenses(Expenses addedRecord)
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


                SqlCommand command = new SqlCommand("usp_CreateExpenses", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Fix", addedRecord.Fix);
                command.Parameters.AddWithValue("@Pallytaree", addedRecord.Pallytaree);
                command.Parameters.AddWithValue("@ToolTax", addedRecord.ToolTax);
                command.Parameters.AddWithValue("@ContPort", addedRecord.ContPort);
                command.Parameters.AddWithValue("@Munshiana", addedRecord.Munshiana);
                command.Parameters.AddWithValue("@Food", addedRecord.Food);
                command.Parameters.AddWithValue("@Godown", addedRecord.Godown);
                command.Parameters.AddWithValue("@Tyre", addedRecord.Tyre);
                command.Parameters.AddWithValue("@Accident", addedRecord.Accident);
                command.Parameters.AddWithValue("@Police", addedRecord.Police);
                command.Parameters.AddWithValue("@PartsMaint", addedRecord.PartsMaint);
                command.Parameters.AddWithValue("@LabourMaint", addedRecord.LabourMaint);
                command.Parameters.AddWithValue("@Salary", addedRecord.Salary);
                command.Parameters.AddWithValue("@Misc1", addedRecord.Misc1);
                command.Parameters.AddWithValue("@Misc2", addedRecord.Misc2);
                command.Parameters.AddWithValue("@Misc3", addedRecord.Misc3);
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

        public static object UpdateExpenses(Expenses updatedRecord)
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

                SqlCommand command = new SqlCommand("usp_UpdateExpenses", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", updatedRecord.ID);
                command.Parameters.AddWithValue("@Fix", updatedRecord.Fix);
                command.Parameters.AddWithValue("@Pallytaree", updatedRecord.Pallytaree);
                command.Parameters.AddWithValue("@ToolTax", updatedRecord.ToolTax);
                command.Parameters.AddWithValue("@ContPort", updatedRecord.ContPort);
                command.Parameters.AddWithValue("@Munshiana", updatedRecord.Munshiana);
                command.Parameters.AddWithValue("@Food", updatedRecord.Food);
                command.Parameters.AddWithValue("@Godown", updatedRecord.Godown);
                command.Parameters.AddWithValue("@Tyre", updatedRecord.Tyre);
                command.Parameters.AddWithValue("@Accident", updatedRecord.Accident);
                command.Parameters.AddWithValue("@Police", updatedRecord.Police);
                command.Parameters.AddWithValue("@PartsMaint", updatedRecord.PartsMaint);
                command.Parameters.AddWithValue("@LabourMaint", updatedRecord.LabourMaint);
                command.Parameters.AddWithValue("@Salary", updatedRecord.Salary);
                command.Parameters.AddWithValue("@Misc1", updatedRecord.Misc1);
                command.Parameters.AddWithValue("@Misc2", updatedRecord.Misc2);
                command.Parameters.AddWithValue("@Misc3", updatedRecord.Misc3);
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

        public static object DeleteExpenses(int Id)
        {
            int error = 0;
            var connection = DBConnection.GetConnection();
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                SqlCommand command = new SqlCommand("usp_DeleteExpenses", connection);
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

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
    public class DACLRepository
    {

        public static object GetDACLList(int TripId, int RecordFrom, string JSorting, int RecordTo)
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

                SqlCommand command = new SqlCommand("searchDACL", connection);
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
                Mapper.CreateMap<IDataReader, DiesalAndCashLoan>();
                IDataReader dataReader = command.ExecuteReader();
                List<DiesalAndCashLoan> lstAccountHolder = Mapper.Map<List<DiesalAndCashLoan>>(dataReader);
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

        public static object DeleteDACL(int Id)
        {
            int error = 0;
            var connection = DBConnection.GetConnection();
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                SqlCommand command = new SqlCommand("DeleteDACL", connection);
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

        public static object CreateDACL(DiesalAndCashLoan DACL)
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

                SqlCommand command = new SqlCommand("CreateDACL", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Date", DACL.Date);
                command.Parameters.AddWithValue("@SlipNo", DACL.SlipNo);
                command.Parameters.AddWithValue("@Pump", DACL.Pump);
                command.Parameters.AddWithValue("@Qty_Ltr", DACL.Qty_Ltr);
                command.Parameters.AddWithValue("@Amount", DACL.Amount);
                command.Parameters.AddWithValue("@CashLoan", DACL.CashLoan);
                command.Parameters.AddWithValue("@TripId", DACL.TripId);
                command.Parameters.AddWithValue("@Remarks", DACL.Remarks);
<<<<<<< HEAD

=======
>>>>>>> 00040d4974a2d930000de265de705184fd565ab0

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
                    DACL.ID = Convert.ToInt32(dataRow["ID"]);
                    return new { Result = "OK", Record = DACL };
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

        public static object UpdateDACL(DiesalAndCashLoan DACL)
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


                SqlCommand command = new SqlCommand("UpdateDACL", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", DACL.ID);
                command.Parameters.AddWithValue("@Date", DACL.Date);
                command.Parameters.AddWithValue("@SlipNo", DACL.SlipNo);
                command.Parameters.AddWithValue("@Pump", DACL.Pump);
                command.Parameters.AddWithValue("@Qty_Ltr", DACL.Qty_Ltr);
                command.Parameters.AddWithValue("@Amount", DACL.Amount);
                command.Parameters.AddWithValue("@CashLoan", DACL.CashLoan);
                command.Parameters.AddWithValue("@Remarks", DACL.Remarks);
<<<<<<< HEAD

=======
>>>>>>> 00040d4974a2d930000de265de705184fd565ab0

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
                    return new { Result = "OK", Record = DACL };
                }
            }
            catch (Exception ex)
            {
                Logger.logging.log.Error(ex.StackTrace);
                return new { Result = "ERROR", Message = "Could not update Record. Please contact the System Administrator." };
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

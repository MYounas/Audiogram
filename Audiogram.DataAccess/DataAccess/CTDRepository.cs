using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AutoMapper;
using Audiogram.DataAccess.Model;


namespace Audiogram.DataAccess
{
    public class CTDRepository
    {
        public static object GetCTDList(int TripId, int RecordFrom, string JSorting, int RecordTo)
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

                SqlCommand command = new SqlCommand("searchCTD", connection);
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
                Mapper.CreateMap<IDataReader, CashTransactionDetail>();
                IDataReader dataReader = command.ExecuteReader();
                List<CashTransactionDetail> lstAccountHolder = Mapper.Map<List<CashTransactionDetail>>(dataReader);
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

        public static object DeleteCTD(int Id)
        {
            int error = 0;
            var connection = DBConnection.GetConnection();
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                SqlCommand command = new SqlCommand("DeleteCTD", connection);
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

        public static object CreateCTD(CashTransactionDetail CTD)
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
                
                SqlCommand command = new SqlCommand("CreateCTD", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Date", CTD.Date);
                command.Parameters.AddWithValue("@SourceType", CTD.SourceType);
                command.Parameters.AddWithValue("@SourceValue", CTD.SourceValue);
                command.Parameters.AddWithValue("@TrDetail", CTD.TrDetail);
                command.Parameters.AddWithValue("@Debit", CTD.Debit);
                command.Parameters.AddWithValue("@Credit", CTD.Credit);
                command.Parameters.AddWithValue("@TripId", CTD.TripId);
                command.Parameters.AddWithValue("@Remarks", CTD.Remarks);


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
                    CTD.ID = Convert.ToInt32(dataRow["ID"]);
                    return new { Result = "OK", Record = CTD };
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

        public static object UpdateCTD(CashTransactionDetail CTD)
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


                SqlCommand command = new SqlCommand("UpdateCTD", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", CTD.ID);
                command.Parameters.AddWithValue("@Date", CTD.Date);
                command.Parameters.AddWithValue("@SourceType", CTD.SourceType);
                command.Parameters.AddWithValue("@SourceValue", CTD.SourceValue);
                command.Parameters.AddWithValue("@TrDetail", CTD.TrDetail);
                command.Parameters.AddWithValue("@Debit", CTD.Debit);
                command.Parameters.AddWithValue("@Credit", CTD.Credit);
                command.Parameters.AddWithValue("@Remarks", CTD.Remarks);


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
                    return new { Result = "OK", Record = CTD };
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



        public static object GetSourceType()
        {
            var connection = DBConnection.GetConnection();

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                SqlCommand command = new SqlCommand("GetSourceType", connection);
                command.CommandType = CommandType.StoredProcedure;
                DataSet dataset = new DataSet();
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = command;
                dataAdapter.Fill(dataset);
                Mapper.CreateMap<IDataReader, DropDownItem>();
                IDataReader dataReader = command.ExecuteReader();
                List<DropDownItem> lstSourceType = Mapper.Map<List<DropDownItem>>(dataReader);

                lstSourceType.Insert(0, new DropDownItem(0, "--SELECT--"));

                return new { Result = "OK", Options = lstSourceType};

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

        public static object GetSourceValue(int sourceType)
        {
            var connection = DBConnection.GetConnection();

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                SqlCommand command = new SqlCommand("GetSourceValue", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@SourceType", sourceType);
                DataSet dataset = new DataSet();
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = command;
                dataAdapter.Fill(dataset);
                Mapper.CreateMap<IDataReader, DropDownItem>();
                IDataReader dataReader = command.ExecuteReader();
                List<DropDownItem> lstSourceValue = Mapper.Map<List<DropDownItem>>(dataReader);

                lstSourceValue.Insert(0, new DropDownItem(0, "--SELECT--"));

                return new { Result = "OK", Options = lstSourceValue };

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
    }
}

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
    public class TripRepository
    {

        //public static int CreateTrip(Trip trip)
        public static void CreateTrip(Trip trip)
        {
            int returnId = 0;
            //int IsCreated = 0;
            var connection = DBConnection.GetConnection();
            DataTable dataTable = new DataTable();
           
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }


                SqlCommand command = new SqlCommand("usp_CreateTrip", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@VehicleID", trip.VehicleID);
                command.Parameters.AddWithValue("@FirstDriverID", trip.FirstDriverID);
                command.Parameters.AddWithValue("@SecondDriverID", trip.SecondDriverID);
                if (trip.StartDate.ToString() == "1/1/0001 12:00:00 AM" || trip.StartDate == null)
                {
                    command.Parameters.AddWithValue("@DOB", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@DOB", trip.StartDate);
                }
                command.Parameters.AddWithValue("@RouteDetail", trip.RouteDetail);
                command.Parameters.AddWithValue("@Fix", trip.Fix);
                command.Parameters.AddWithValue("@Pallytaree", trip.Pallytaree);
                command.Parameters.AddWithValue("@ToolTax", trip.ToolTax);
                command.Parameters.AddWithValue("@ContPort", trip.ContPort);
                command.Parameters.AddWithValue("@Munshiana", trip.Munshiana);
                command.Parameters.AddWithValue("@Food", trip.Food);
                command.Parameters.AddWithValue("@Godown", trip.Godown);
                command.Parameters.AddWithValue("@Tyre", trip.Tyre);
                command.Parameters.AddWithValue("@Accident", trip.Accident);
                command.Parameters.AddWithValue("@Police", trip.Police);
                command.Parameters.AddWithValue("@PartsMaint", trip.PartsMaint);
                command.Parameters.AddWithValue("@LabourMaint", trip.LabourMaint);
                command.Parameters.AddWithValue("@Salary", trip.Salary);
                command.Parameters.AddWithValue("@Misc1", trip.Misc1);
                command.Parameters.AddWithValue("@Misc2", trip.Misc2);
                command.Parameters.AddWithValue("@Misc3", trip.Misc3);
                command.Parameters.AddWithValue("@PreviousPeshgi", trip.PreviousPeshgi);
                command.Parameters.AddWithValue("@CashAdvDeposit", trip.CashAdvDeposit);
                command.Parameters.AddWithValue("@PurchoonFrieghtUp", trip.PurchoonFrieghtUp);
                command.Parameters.AddWithValue("@PurchoonFrightReturn", trip.PurchoonFrightReturn);
                command.Parameters.AddWithValue("@PumpCashLoan", trip.PumpCashLoan);
                command.Parameters.AddWithValue("@MiscCashLoan", trip.MiscCashLoan);
                command.Parameters.AddWithValue("@SetMisc1", trip.SetMisc1);
                command.Parameters.AddWithValue("@SetMisc2", trip.SetMisc2);
                command.Parameters.AddWithValue("@SetMisc3", trip.SetMisc3);
                command.Parameters.AddWithValue("@SetMisc4", trip.SetMisc4);
                //command.Parameters.AddWithValue("@No", trip.No);
                command.Parameters.AddWithValue("@Client", trip.Client);
                command.Parameters.AddWithValue("@Station", trip.Station);
                command.Parameters.AddWithValue("@Destination", trip.Destination);
                command.Parameters.AddWithValue("@Quantity", trip.Quantity);
                command.Parameters.AddWithValue("@Scale", trip.Scale);
                command.Parameters.AddWithValue("@Freight", trip.Freight);
                command.Parameters.AddWithValue("@paidOrNot", trip.paidOrNot);

                //returnId = (int)command.ExecuteScalar();

                DataRow dataRow = dataTable.NewRow();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataTable);
                dataRow = dataTable.Rows[0];

             
            }
            catch (Exception ex)
            {
            }

            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }


            //return returnId;

        }

        public static object GetTrips(int RecordFrom, string JSorting, int RecordTo)
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

                SqlCommand command = new SqlCommand("usp_searchTrip", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@recordsFrom", RecordFrom);
                command.Parameters.AddWithValue("@recordsTo", RecordTo);
                command.Parameters.AddWithValue("@lSortCol", jtsortColumn);
                command.Parameters.AddWithValue("@SortOrder", jtsortOrder);
                DataSet dataset = new DataSet();
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = command;
                dataAdapter.Fill(dataset);
                Mapper.CreateMap<IDataReader, Trip>();
                IDataReader dataReader = command.ExecuteReader();
                List<Trip> lstAccountHolder = Mapper.Map<List<Trip>>(dataReader);
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

        public static object GetOneTrip(int TripId,int RecordFrom, string JSorting, int RecordTo)
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

                SqlCommand command = new SqlCommand("getOneTrip", connection);
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
                Mapper.CreateMap<IDataReader, Trip>();
                IDataReader dataReader = command.ExecuteReader();
                List<Trip> lstAccountHolder = Mapper.Map<List<Trip>>(dataReader);
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

        public static Trip GetTripById(int TripId)
        {
            var connection = DBConnection.GetConnection();

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                SqlCommand command = new SqlCommand("getOneTrip", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@TripId", TripId);
                command.Parameters.AddWithValue("@recordsFrom", 0);
                command.Parameters.AddWithValue("@recordsTo", 1);
                command.Parameters.AddWithValue("@lSortCol", "");
                command.Parameters.AddWithValue("@SortOrder", "");
                DataSet dataset = new DataSet();
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = command;
                dataAdapter.Fill(dataset);
                Mapper.CreateMap<IDataReader, Trip>();
                IDataReader dataReader = command.ExecuteReader();
                List<Trip> lstTrip = Mapper.Map<List<Trip>>(dataReader);
                return lstTrip.First();

            }
            catch (Exception ex)
            {
                Logger.logging.log.Error("error:" + ex.Message);
                return null;
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

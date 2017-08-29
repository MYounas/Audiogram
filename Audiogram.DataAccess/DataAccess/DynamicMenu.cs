using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Audiogram.DataAccess
{
    public class DynamicMenu
    {
        /// <summary>
        /// Method to get user based dynamic menu 
        /// </summary>
        /// <returns>it will return the Category data into Datatable</returns>
        public DataTable GetMenuByUserId(int userId)
        {
            DataTable datatable;
            SqlConnection connection = DBConnection.GetConnection();
            try
            {
                datatable = new DataTable();
                connection.Open();

                SqlCommand command = new SqlCommand("GetMenuByUser", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@UserId", userId));
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(datatable);
                return datatable;
            }
            catch (Exception ex)
            {
                //log here ex.message
                Logger.logging.log.Error(ex.StackTrace);
                return datatable = null;
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
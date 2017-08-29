using Audiogram.DataAccess;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;
using System.Collections.Generic;

namespace Audiogram.Modules.Trip
{
    public partial class Expenses_Settlement : System.Web.UI.UserControl
    {
        static int TripId;
        protected List<String> allValues, allKeys;protected int sumSettl = 0,sumExpens=0; 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                TripId = Convert.ToInt32(Request.QueryString["id"]);

            }

            var connection = DBConnection.GetConnection();

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            SqlCommand command = new SqlCommand("getSett_EXPEN", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@TripId", TripId);

            allValues=new List<String>();
            allKeys = new List<String>();
            
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                allKeys.Add(reader["Description"].ToString());
                allValues.Add(reader["Amount"].ToString());
            }

            for (int i = 0; i < 16; i++)
            {
                sumExpens += Convert.ToInt16(allValues[i]);
            }

            for (int i = 16; i < 26; i++)
            {
                sumSettl += Convert.ToInt16(allValues[i]);
            }

            connection.Close();

        }
    }
}
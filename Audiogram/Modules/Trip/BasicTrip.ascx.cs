using Audiogram.DataAccess;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace Audiogram.Modules.Trip
{
    public partial class BasicTrip : System.Web.UI.UserControl
    {
        static int TripId;
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

            SqlCommand command = new SqlCommand("getBaseTrip", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@TripId", TripId);

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                firstDriver.Text = reader["FirstDriver"].ToString();
                secondDriver.Text = reader["SecondDriver"].ToString();
                vehicle.Text = reader["Vehicle"].ToString();
                routeDetail.Value = reader["RouteDetail"].ToString();
                startDate.Text = reader["StartDate"].ToString().Split(' ')[0];
            }
            
            connection.Close();

        }
        
    }
}
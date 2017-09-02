using Audiogram.Modules.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;
using System.Reflection;
using Audiogram.DataAccess;
using Audiogram.Model;
using System.Security.Cryptography;
using System.Globalization;
using Audiogram.Enumeration;

using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;
using Audiogram.DataAccess.Model;


namespace Audiogram.Modules.Trip
{
    public partial class StartTrip : System.Web.UI.Page
    {
        private int tripId;
        private string Mode
        {
            get
            {
                return ViewState["MODE"].ToString();
            }
            set
            {
                ViewState["MODE"] = value;
            }
        }
       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    Mode = "Edit";
                }
                else
                {
                    Mode = "Add";
                }


                object obj = VehicleRepository.GetVehicleList("",0, "Name ASC", 50,"",true);
                List<Vehicle> lstVehicles = ((List<Vehicle>)obj.GetType().GetProperty("Records").GetValue(obj, null));
                Utility.BindDropDown(drpVehicle, lstVehicles, "Name", "ID");

                object obj1 = DriverRepository.GetDriverList("", 0, "Name ASC", 50,true);
                List<Driver> lstDrivers = ((List<Driver>)obj1.GetType().GetProperty("Records").GetValue(obj1, null));
                Utility.BindDropDown(drpFirstDriver, lstDrivers, "Name", "ID");

                Utility.BindDropDown(drpFirstDriver,lstDrivers,"Name","ID");

                if (Mode == "Edit") LoadData();

            }

        }

        private void LoadData()
        {
            DataAccess.Model.Trip trip = TripRepository.GetTripById(tripId);
        }

        protected void btnStartTest_Click(object sender, EventArgs e)
        {
            if (Mode == "Add")
            {
                DataAccess.Model.Trip trip = new DataAccess.Model.Trip();
                trip.VehicleID = Convert.ToInt32(drpVehicle.SelectedValue);
                trip.FirstDriverID = Convert.ToInt32(drpFirstDriver.SelectedValue);
                //trip.SecondDriverID = Convert.ToInt32(drpSecondDriver.SelectedValue);
                trip.StartDate = Convert.ToDateTime(startDate.Value);
                trip.RouteDetail = txtRouteDetail.Value;

                SetExpensesAndSettlements(trip);
                TripRepository.CreateTrip(trip);

                clear();

                string message = "Your details have been saved successfully.";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);

                Response.Redirect("TripManagement.aspx", false);
            }
            else if (Mode == "Edit")
            {

            }

        }

        private void SetExpensesAndSettlements(DataAccess.Model.Trip trip)
        {
            foreach (Control c in pnlexpenes.Controls)
            {
                if (c is TextBox)
                {
                    string property = c.ID.Replace("txt", "");
                    TextBox txtBox = (TextBox)c;
                    trip[property] = Utility.GetSafeInteger(txtBox.Text);
                }
            }

            foreach (Control c in pnlsettlement.Controls)
            {
                if (c is TextBox)
                {
                    string property = c.ID.Replace("txt", "");
                    TextBox txtBox = (TextBox)c;
                    trip[property] = Utility.GetSafeInteger(txtBox.Text);
                }
            }
        }

        protected void clear()
        {
            drpVehicle.SelectedIndex = drpFirstDriver.SelectedIndex = drpSecondDriver.SelectedIndex = 0;
            txtRouteDetail.Value = "";
            foreach (Control c in pnlexpenes.Controls)
            {
                if (c is TextBox)
                {
                    TextBox txtBox = (TextBox)c;
                    txtBox.Text = "0";
                }
            }

            foreach (Control c in pnlsettlement.Controls)
            {
                if (c is TextBox)
                {
                    TextBox txtBox = (TextBox)c;
                    txtBox.Text = "0";
                }
            }
        }



    }

}
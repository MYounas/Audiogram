using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.Services;
using Audiogram.DataAccess;
using Audiogram.DataAccess.Model;


namespace Audiogram.Modules.Managment
{
    public partial class AddCTD : Page
    {

        static int TripId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                
                TripId = Convert.ToInt32(Request.QueryString["id"]);


                DataAccess.Model.Trip trip = TripRepository.GetTripById(TripId);
                txtDrivers.Text = trip.FirstDriver + " and " + trip.SecondDriver;
                txtRouteDetail.InnerText = trip.RouteDetail;
                txtVehicle.Text = trip.Vehicle;

                //txtDrivers.Enabled = txtVehicle.Enabled = false;
                //txtRouteDetail.Disabled = true;

                //TripRepository repo = new TripRepository();
                //object obj = TripRepository.GetTrips(0, "FirstDriver ASC", 50);
                //List<DataAccess.Model.Trip> lstTrips = ((List<DataAccess.Model.Trip>)obj.GetType().GetProperty("Records").GetValue(obj, null));
                //DataAccess.Model.Trip temp = new DataAccess.Model.Trip();
                //temp.ID = 0;
                //temp.FirstDriver = "--SELECT--";
                //lstTrips.Insert(0, temp);
                //drpTrip.DataSource = lstTrips;
                //drpTrip.DataTextField = "FirstDriver";
                ////drpTrip.DataTextField = "RouteDetail";
                //drpTrip.DataValueField = "ID";
                //drpTrip.DataBind();

                //drpTrip.SelectedValue = TripId.ToString();
            }
        }


        [WebMethod(EnableSession = true)]
        public static object RecordList(int jtStartIndex, int jtPageSize, string jtSorting)
        {
            int recordTo = jtPageSize + jtStartIndex;
            //return CTDRepository.GetCTDList(TripId);
            return CTDRepository.GetCTDList(TripId, jtStartIndex, jtSorting, recordTo);


        }

        [WebMethod(EnableSession = true)]
        public static object GetSourceType()
        {
            return CTDRepository.GetSourceType();
        }

        [WebMethod(EnableSession = true)]
        public static object GetSourceValue(int sourceTypeId)
        {
            return CTDRepository.GetSourceValue(sourceTypeId);
        }
        //[WebMethod(EnableSession = true)]
        //public static object RecordList()
        //{
        //    //int recordTo = jtPageSize + jtStartIndex;
        //    return DACLRepository.GetDACLList(TripId);

        //}

        [WebMethod(EnableSession = true)]
        public static object CreateRecord(CashTransactionDetail record)
        {
            record.TripId = TripId;
            return CTDRepository.CreateCTD(record);
        }

        [WebMethod(EnableSession = true)]
        public static object UpdateRecord(CashTransactionDetail record)
        {
            return CTDRepository.UpdateCTD(record);
        }

        [WebMethod(EnableSession = true)]
        public static object DeleteRecord(int ID)
        {
            return CTDRepository.DeleteCTD(ID);
        }

        protected void drpTrip_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TripId = Convert.ToInt32(drpTrip.SelectedValue);
        }
        
    }
}
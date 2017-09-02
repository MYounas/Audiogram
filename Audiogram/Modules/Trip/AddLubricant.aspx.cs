using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.Services;
using Audiogram.DataAccess;
using Audiogram.DataAccess.Model;


namespace Audiogram.Modules.Trip
{
    public partial class AddLubricant : Page
    {

        static int TripId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
                TripId = Convert.ToInt32(Request.QueryString["id"]);

                TripRepository repo = new TripRepository();
                object obj = TripRepository.GetTrips(0, "FirstDriver ASC", 50);
                List<DataAccess.Model.Trip> lstTrips = ((List<DataAccess.Model.Trip>)obj.GetType().GetProperty("Records").GetValue(obj, null));
                DataAccess.Model.Trip temp = new DataAccess.Model.Trip();
                temp.ID = 0;
                temp.FirstDriver = "--SELECT--";
                lstTrips.Insert(0, temp);
                drpTrip.DataSource = lstTrips;
                drpTrip.DataTextField = "FirstDriver";
                //drpTrip.DataTextField = "RouteDetail";
                drpTrip.DataValueField = "ID";
                drpTrip.DataBind();

                drpTrip.SelectedValue = TripId.ToString();
            }
        }


        [WebMethod(EnableSession = true)]
        public static object RecordList(int jtStartIndex, int jtPageSize, string jtSorting)
        {
            int recordTo = jtPageSize + jtStartIndex;
            return LORepository.GetLOList(TripId, jtStartIndex, jtSorting, recordTo);

        }

        //[WebMethod(EnableSession = true)]
        //public static object RecordList()
        //{
        //    //int recordTo = jtPageSize + jtStartIndex;
        //    return LORepository.GetLOList(TripId);

        //}

        [WebMethod(EnableSession = true)]
        public static object CreateRecord(LubricantOil record)
        {
            record.TripId = TripId;
            return LORepository.CreateLO(record);
        }

        [WebMethod(EnableSession = true)]
        public static object UpdateRecord(LubricantOil record)
        {
            return LORepository.UpdateLO(record);
        }

        [WebMethod(EnableSession = true)]
        public static object DeleteRecord(int ID)
        {
            return LORepository.DeleteLO(ID);
        }

        protected void drpTrip_SelectedIndexChanged(object sender, EventArgs e)
        {
            TripId = Convert.ToInt32(drpTrip.SelectedValue);
        }
        
    }
}
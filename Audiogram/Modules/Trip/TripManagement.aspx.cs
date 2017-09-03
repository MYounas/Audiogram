using System;
using System.Web.UI;
using System.Web.Services;
using Audiogram.DataAccess;


namespace Audiogram.Modules.Trip
{
    public partial class TripManagement : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {

            }
        }


        [WebMethod(EnableSession = true)]
        public static object RecordList(int jtStartIndex, int jtPageSize, string jtSorting)
        {
            int recordTo = jtPageSize + jtStartIndex;
            return  TripRepository.GetTrips(jtStartIndex, jtSorting, recordTo);

        }

        protected void btnStart_Click(object sender, EventArgs e)
        {
            string s = SelectedId.Value;
            Response.Redirect("StartTrip.aspx",false);
        }

   
    }
}
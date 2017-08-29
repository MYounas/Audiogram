using Audiogram.DataAccess;
using System;
using System.Web.Services;
using System.Web.UI;

namespace Audiogram.Modules.Trip
{
    public partial class Report : Page
    {
        static int TripId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                TripId = Convert.ToInt32(Request.QueryString["id"]);
                
            }

        }

        [WebMethod(EnableSession = true)]
        public static object LORecordList(int jtStartIndex, int jtPageSize, string jtSorting)
        {
            int recordTo = jtPageSize + jtStartIndex;
            return LORepository.GetLOList(TripId, jtStartIndex, jtSorting, recordTo);

        }

        [WebMethod(EnableSession = true)]
        public static object CTDRecordList(int jtStartIndex, int jtPageSize, string jtSorting)
        {
            int recordTo = jtPageSize + jtStartIndex;
            return CTDRepository.GetCTDList(TripId, jtStartIndex, jtSorting, recordTo);
            
        }

        [WebMethod(EnableSession = true)]
        public static object DACLRecordList(int jtStartIndex, int jtPageSize, string jtSorting)
        {
            int recordTo = jtPageSize + jtStartIndex;
            return DACLRepository.GetDACLList(TripId, jtStartIndex, jtSorting, recordTo);

        }

        [WebMethod(EnableSession = true)]
        public static object TMRecordList(int jtStartIndex, int jtPageSize, string jtSorting)
        {
            int recordTo = jtPageSize + jtStartIndex;
            return TripRepository.GetOneTrip(TripId,jtStartIndex, jtSorting, recordTo);

        }

    }
}
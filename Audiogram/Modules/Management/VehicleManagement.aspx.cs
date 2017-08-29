using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.Services;
using System.Data;
using Audiogram.DataAccess;
using Audiogram.Model;
using System.Web.Security;
using Audiogram.Modules.Common;


namespace Audiogram.Modules.Management
{
    public partial class VehicleManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionDetails sd = Session["sessionDetails"] as SessionDetails;
            if (sd != null && sd.UserId != 0)
            {

            }
        }

      #region Customertable



        [WebMethod(EnableSession = true)]
        public static object RecordList(string Make, int jtStartIndex, int jtPageSize, string jtSorting)
        {
            int recordTo = jtPageSize + jtStartIndex;
            if (Make == null)
            {
                Make = string.Empty;
            }

            return VehicleRepository.GetVehicleList(Make, jtStartIndex, jtSorting, jtPageSize);

        }

        [WebMethod(EnableSession = true)]
        public static object RecordListOnTrip(string Make, int jtStartIndex, int jtPageSize, string jtSorting)
        {
            int recordTo = jtPageSize + jtStartIndex;
            if (Make == null)
            {
                Make = string.Empty;
            }

            return VehicleRepository.GetVehicleList(Make, jtStartIndex, jtSorting, jtPageSize,"active");

        }

        [WebMethod(EnableSession = true)]
        public static object RecordListIdle(string Make, int jtStartIndex, int jtPageSize, string jtSorting)
        {
            int recordTo = jtPageSize + jtStartIndex;
            if (Make == null)
            {
                Make = string.Empty;
            }

            return VehicleRepository.GetVehicleList(Make, jtStartIndex, jtSorting, jtPageSize,"idle");

        }


        [WebMethod(EnableSession = true)]
        public static object CreateRecord(Vehicle record)
        {
            return VehicleRepository.CreateVehicle(record);
        }


        [System.Web.Services.WebMethod]
        public static void Redirect(int Id)
        {
            
     
        }

        [WebMethod(EnableSession = true)]
        public static object UpdateRecord(Vehicle record)
        {
            return VehicleRepository.UpdateVehicle(record);

        }


        [WebMethod(EnableSession = true)]
        public static object DeleteRecord(int ID)
        {

            return VehicleRepository.DeleteVehicle(ID);
        }

        #endregion
    }
}


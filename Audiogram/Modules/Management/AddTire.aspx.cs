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
using System.Web.Security;
using System.Security.Cryptography;
using Audiogram.Modules.Common;
using Audiogram.Model;
using Audiogram.DataAccess;
using Newtonsoft.Json;
using Audiogram.Enumeration;
using Audiogram.DataAccess.Model;


namespace Audiogram.Modules.Managment
{
    public partial class AddTire : System.Web.UI.Page
    {
        static int vehicleId;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
              
                vehicleId = Convert.ToInt32(Request.QueryString["id"]);

                VehicleRepository repo = new VehicleRepository();
                object obj = VehicleRepository.GetVehicleList("", 0, "Name ASC", 50);
                List<Vehicle> lstVehicles = ((List<Vehicle>)obj.GetType().GetProperty("Records").GetValue(obj, null));
                Vehicle temp = new Vehicle();
                temp.ID = 0;
                temp.Make = "--SELECT--";
                lstVehicles.Insert(0, temp);
                drpVehicle.DataSource = lstVehicles;
                drpVehicle.DataTextField = "Name";
                drpVehicle.DataValueField = "ID";
                drpVehicle.DataBind();

                drpVehicle.SelectedValue = vehicleId.ToString();
            }
        }


        [WebMethod(EnableSession = true)]
        public static object RecordList(int jtStartIndex, int jtPageSize, string jtSorting)
        {
            int recordTo = jtPageSize + jtStartIndex;
            //Id = Id.Replace(@"\", " ");
            //dynamic json = JsonConvert.DeserializeObject(Id);
            //string SearchUser = json.searchWord == "null" ? "" : json.searchWord;

            return TireRepository.GetTireList(vehicleId, jtStartIndex, jtSorting, recordTo);

        }

        [WebMethod(EnableSession = true)]
        public static object CreateRecord(Tire record)
        {
            record.VehicleId = vehicleId;
            return TireRepository.CreateTire(record);
        }

        [WebMethod(EnableSession = true)]
        public static object UpdateRecord(Tire record)
        {
            return TireRepository.UpdateTire(record);
        }

        [WebMethod(EnableSession = true)]
        public static object DeleteRecord(int ID)
        {
            return TireRepository.DeleteTire(ID);
        }

        protected void drpVehicle_SelectedIndexChanged(object sender, EventArgs e)
        {
            vehicleId = Convert.ToInt32(drpVehicle.SelectedValue);
        }


    }
}
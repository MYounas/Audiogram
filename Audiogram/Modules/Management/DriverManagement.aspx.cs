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




namespace Audiogram.Modules.Managment
{
    public partial class DriverManagement : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionDetails sd = Session["sessionDetails"] as SessionDetails;
            if(!(sd != null && sd.UserId != 0))
            {
                Response.Redirect("~/Login.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }           
        }

        [System.Web.Services.WebMethod]
        public static List<string> GetDrivers(string Drivers)
        { 
            List<string> lstDrivers = new List<string>();
        try
        {
            lstDrivers = DriverRepository.SuggestionCompanies(Drivers);
            
        }
        catch(Exception ex)
        {
            Logger.logging.log.Error("error:"+ex.Message);   
        }

        return lstDrivers;
        
        }


        //function for j table

        #region Userstable
        [WebMethod(EnableSession = true)]
        public static object RecordList(string Id, int jtStartIndex, int jtPageSize, string jtSorting)
       {
           int recordTo = jtPageSize + jtStartIndex;
           Id = Id.Replace(@"\", " ");
           dynamic json = JsonConvert.DeserializeObject(Id);
           string SearchUser = json.searchWord == "null" ? "" : json.searchWord;

           return DriverRepository.GetDriverList(SearchUser, jtStartIndex, jtSorting, recordTo);
        
       }

       [WebMethod(EnableSession = true)]
       public static object CreateRecord(Driver record)
        {
           return DriverRepository.CreateDriver(record);
        }

       [WebMethod(EnableSession = true)]
       public static object UpdateRecord(Driver record)
       {
           return DriverRepository.UpdateDriver(record);
       }

       [WebMethod(EnableSession = true)]
       public static object DeleteRecord(int ID)
       {
           return DriverRepository.DeleteDriver(ID);
       }

        #endregion

   
    }
}
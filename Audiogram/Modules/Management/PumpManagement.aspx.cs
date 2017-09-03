using System;
using System.Web.Services;
using Audiogram.DataAccess;
using Audiogram.Model;
using Audiogram.Modules.Common;
using Newtonsoft.Json;

namespace Audiogram.Modules.Managment
{
    public partial class PumpManagement : System.Web.UI.Page
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

        //[System.Web.Services.WebMethod]
        //public static List<string> GetDrivers(string Drivers)
        //{ 
        //    List<string> lstDrivers = new List<string>();
        //try
        //{
        //    lstDrivers = DriverRepository.SuggestionCompanies(Drivers);
            
        //}
        //catch(Exception ex)
        //{
        //    Logger.logging.log.Error("error:"+ex.Message);   
        //}

        //return lstDrivers;
        
        //}


        //function for j table

        #region Userstable
        [WebMethod(EnableSession = true)]
        public static object RecordList(string Id, int jtStartIndex, int jtPageSize, string jtSorting)
       {
           int recordTo = jtPageSize + jtStartIndex;
           Id = Id.Replace(@"\", " ");
           dynamic json = JsonConvert.DeserializeObject(Id);
           string SearchUser = json.searchWord == "null" ? "" : json.searchWord;

           return PumpRepository.GetPumpList(SearchUser, jtStartIndex, jtSorting, recordTo);
        
       }

       [WebMethod(EnableSession = true)]
       public static object CreateRecord(Pump record)
        {
           return PumpRepository.CreatePump(record);
        }

       [WebMethod(EnableSession = true)]
       public static object UpdateRecord(Pump record)
       {
           return PumpRepository.UpdatePump(record);
       }

       [WebMethod(EnableSession = true)]
       public static object DeleteRecord(int ID)
       {
           return PumpRepository.DeletePump(ID);
       }

        #endregion

   
    }
}
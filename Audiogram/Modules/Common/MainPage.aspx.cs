using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Audiogram.Modules.Common
{
    public partial class MainPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionDetails sd = Session["sessionDetails"] as SessionDetails;
            if (sd != null && sd.UserId != 0)
            {
                Session["RoleId"] = sd.RoletypeId.ToString();
                hdnRoleType.Value = sd.RoletypeId.ToString();
            }
        }

        [System.Web.Services.WebMethod]
        public static string SetClientTimeZoneOffset(string timeOffset)
        {
            HttpContext.Current.Session["timeZoneOffset"] = timeOffset;
            return timeOffset;
        }
    }
}
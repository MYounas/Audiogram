using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Audiogram.DataAccess;
using Audiogram.Modules.Common;
using Newtonsoft.Json;
using Audiogram.Enumeration;

namespace Audiogram
{
    public partial class Audiogram : System.Web.UI.MasterPage
    {
        SessionDetails sessionDetails;
        //static protected EasyMenu mainEM;
        //static protected List<EasyMenu> lstChildEM;

        protected void Page_Load(object sender, EventArgs e)
        {
            sessionDetails = Session["sessionDetails"] as SessionDetails;
            if (sessionDetails != null)
            {
                if (sessionDetails.UserId != 0) 
                {
                    if (sessionDetails.TestStart == true)
                    {

                        sessionDetails.TestStart = false;

                    }
                    Logger.logging.log.Info("Page Load of Master");
                    if (sessionDetails.DTable == null)
                    {
                        DynamicMenu dm = new DynamicMenu();
                        sessionDetails.DTable = dm.GetMenuByUserId(sessionDetails.UserId);
                    }



                    //if (!IsAccessible(sessionDetails.DTable)
                    //    //&& !this.Request.Url.AbsolutePath.ToLower().Contains("MainPage.aspx".ToLower())
                    //    )
                    //{
                    //    Response.Redirect("~/Modules/Common/MainPage.aspx", false);
                    //    Context.ApplicationInstance.CompleteRequest();
                    //}



                    lblUser.Text = sessionDetails.UserName;
                    //lblCustomer.Text = sessionDetails.CustomerName;
                    if (sessionDetails.RoletypeId == Convert.ToInt32(enRole.AccountHolder))
                    {
                        lblCustomer.Text = sessionDetails.AccountHolderName;
                    }
                    else if (sessionDetails.RoletypeId != Convert.ToInt32(enRole.AccountHolder))
                    {
                        lblCustomer.Text = sessionDetails.FirstName + ' ' + sessionDetails.LastName;
                    }

                    if (sessionDetails.DTable.Rows.Count > 0)
                    {
                        BuildMenu(sessionDetails.DTable);
                        if (!Page.IsPostBack)
                        {
                        }
                        if (Page.IsPostBack)
                        {

                        }
                    }
                    else
                    {
                        //do nothing
                    }
                }
                else
                {
                    Response.Redirect("~/Login.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }

        private bool IsAccessible(DataTable dTable)
        {

            foreach (DataRow row in dTable.Rows)
            {
                string url = row["PageURL"].ToString().ToLower();
                string[] urlParts = url.Split('?');
                string pageTitle = row["PageTitle"].ToString();
                string IsCustomerGlobal = Request.QueryString["IsCustomerGlobal"];
                string IsGlobal = Request.QueryString["IsGlobal"];
                string currentUrl = this.Request.Url.AbsoluteUri.ToLower();
                if (IsCustomerGlobal == "true")
                {
                    if (urlParts.Count() > 1)
                    {
                        if (currentUrl.Contains(urlParts[0]) && currentUrl.Contains(urlParts[1]) && url != null && url != "" && url.Contains(IsCustomerGlobal))
                        {
                            return (SetTitle(row));
                        }
                    }
                }
                else if (IsGlobal == "true")
                {
                    if (urlParts.Count() > 1)
                    {
                        if (currentUrl.Contains(urlParts[0]) && currentUrl.Contains(urlParts[1]) && url != null && url != "" && url.Contains(IsGlobal))
                        {
                            return (SetTitle(row));
                        }
                    }
                }
                else
                {
                    if (currentUrl.Contains("addtire"))
                    {
                        return true;
                    }

                    if (currentUrl.Contains(urlParts[0]) && url != null && url != "")
                    {
                        return (SetTitle(row));
                    }
                }


            }
            
            return false;

        }

        protected bool SetTitle(DataRow row)
        {
            try
            {

                Page.Title = row["PageTitle"].ToString();

                lblPageTitle.Text = row["PageTitle"].ToString();
                hdnPageTitle.Value = lblPageTitle.Text;

                return true;
            }
            catch (Exception ex)
            {

                Logger.logging.log.Error(ex.StackTrace);
                return false;
            }

        }

        public void BuildMenu(DataTable dt)
        {
            Dictionary<int, Model.MenuItem> dict =
             dt.Rows.Cast<DataRow>().Where(r => r.Field<bool>("Visible") != false)
              .Select(r => new Model.MenuItem
              {
                  id = Convert.ToString(r.Field<int>("Id")),
                  pid = Convert.ToString(r.Field<int>("ParentFunctionId")),
                  name = r.Field<string>("FunctionName"),
                  url = (r.Field<string>("PageUrl")) == null ? "" : r.Field<string>("PageUrl")

              })
             .ToDictionary(m => Convert.ToInt32(m.id));


            List<Model.MenuItem> rootMenu = new List<Model.MenuItem>();

            foreach (var kvp in dict)
            {
                List<Model.MenuItem> menu = rootMenu;
                Model.MenuItem item = kvp.Value;
                if (Convert.ToInt32(item.pid) > 0)
                {
                    menu = dict[Convert.ToInt32(item.pid)].children;
                }
                menu.Add(item);
            }

            string menuJson = JsonConvert.SerializeObject(rootMenu, Formatting.Indented);
            menuJson = menuJson.Replace("[]", "\"\"");
            menudata.Value = menuJson;
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Logger.logging = null;
            Session.Clear();
            Response.Redirect("~/Login.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
        
    }
}
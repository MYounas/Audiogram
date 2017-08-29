using Audiogram.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Configuration;
using System.Security.Cryptography;
using Audiogram.Modules.Common;
using System.Data;
using Audiogrm.Modules.Common;


namespace Audiogram.Web
{
    public partial class Login : BasePage
    {
        SessionDetails sessionDetails;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null && Request.Cookies["CheckBoxValue"] != null)
                {
                    try
                    {
                        txtUserName.Value = Request.Cookies["UserName"].Value;
                        txtPassword.Attributes["value"] = Request.Cookies["Password"].Value;
                        //chkRememberme.Checked = Request.Cookies["CheckBoxValue"].Value == null ? false : Convert.ToBoolean(Request.Cookies["CheckBoxValue"].Value);
                    }
                    catch (Exception ex)
                    {
                        //lblunSuccessfulLogin.Text = "There was an error in login. Please Contact System Administrator.";
                        Logger.logging.log.Info(ex.Message);

                    }
                }
            }
            Session["templateInformation"] = null;

            if (Session["sessionDetails"] == null)
            {
                Session["sessionDetails"] = new SessionDetails();
                sessionDetails = Session["sessionDetails"] as SessionDetails;
                if (Logger.logging == null)
                {
                    Logger.logging = new Logging();
                }
                else
                {
                    //do nothing
                }
            }
            else
            {
                sessionDetails = Session["sessionDetails"] as SessionDetails;
            }
            if (sessionDetails.UserId != 0)
            {
                Response.Redirect("~/Modules/Common/MainPage.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            Logger.logging.log.Info("Page Load of Login");

        }

        private string Hash(string password)
        {
            string stringshPassword;
            string plainpass = password;
            //hashing password 
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(plainpass);
            SHA1 sha = new SHA1CryptoServiceProvider();
            byte[] shPassword = sha.ComputeHash(bytes);
            stringshPassword = BitConverter.ToString(shPassword);
            return stringshPassword;
        }

        protected void onlogin_click(object sender, EventArgs e)
        {
            string userId = null;
            string loginResponse = string.Empty;
            string[] responseArray = null;
            string userName = txtUserName.Value;
            string password = txtPassword.Value;
            string stringshPassword;
            bool isUserActive;

            stringshPassword = Hash(password);

            if (true)//chkRememberme.Checked)
            {

                Response.Cookies["userName"].Value = userName;
                Response.Cookies["Password"].Value = password;
                Response.Cookies["CheckBoxValue"].Value = "true";
                Response.Cookies["userName"].Expires = DateTime.Now.AddDays(30);
                Response.Cookies["CheckBoxValue"].Expires = DateTime.Now.AddDays(30);
                Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);


            }
            else
            {
                Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["CheckBoxValue"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["CheckBoxValue"].Value = "false";

            }
            try
            {
                //function for validation which returns user id from database
                loginResponse = UserRepository.ValidateCredentials(userName, stringshPassword);
                responseArray = loginResponse.Split('|');

                isUserActive = Convert.ToBoolean(responseArray[0].ToString());
                userId = responseArray[1];// UserRepository.ValidateCredentials(userName, stringshPassword);

                if (!isUserActive)
                {
                    //lblunSuccessfulLogin.Text = "The user you are trying to log in is currently inactive. Please Contact System Administrator for further assistance.";
                    return;
                }
                if (userId != null && userId != "")
                {
                    sessionDetails.UserId = Convert.ToInt32(userId);
                    DataTable sessionDataTable = UserRepository.GetSessionDetails(Convert.ToInt32(userId));


                    GetSessionDetailsFromDataTable(sessionDataTable);
                }
                else
                {
                    //lblunSuccessfulLogin.Text = "User name or password is incorrect.";
                }
            }
            catch (Exception ex)
            {
                //lblunSuccessfulLogin.Text = "There was an error in login. Please Contact System Administrator for further assistance.";
                Logger.logging.log.Info(ex.Message);
            }
            if (userId != null && userId != "")
            {
                Response.Redirect("~/Modules/Common/MainPage.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }

        private void GetSessionDetailsFromDataTable(DataTable dataTable)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                sessionDetails.Password = row["Password"].ToString();
                sessionDetails.UserName = row["UserName"].ToString();
            }
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SignUp.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }

    }
}
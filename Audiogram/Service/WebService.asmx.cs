using Audiogram.DataAccess;
using Audiogram.Model;
using Audiogram.Modules.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Security.Cryptography;
using Newtonsoft.Json;
using System.Globalization;
using System.Threading;


namespace Audiogram.Service
{
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        //[WebMethod(EnableSession = true)]
        //public string EditUser(string FirstName, string LastName, string BirthdateCreate, string emailCreate, string contactnoCreate, string Password, bool IsPaswordChange)
        //{
        //    try
        //    {
        //        SessionDetails sd = Session["sessionDetails"] as SessionDetails;
        //        User record = new User();
        //        if (IsPaswordChange)
        //        {
        //            string stringshPassword = "";
        //            stringshPassword = UserRepository.Hash(Password);
        //            record.Password = stringshPassword;
        //        }
        //        else
        //        {
        //            record.Password = Password;

        //        }
        //        record.UserId = sd.UserId;
        //        record.UserNameCreate = sd.UserName;

        //        record.FirstName = FirstName;
        //        record.LastName = LastName;
        //        if (BirthdateCreate == "null" || BirthdateCreate == "")
        //        {
        //            record.BirthdateCreate = DateTime.MinValue;
                    
        //        }
        //        else
        //        {
        //            record.BirthdateCreate = DateTime.ParseExact(BirthdateCreate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
        //        }
        //        //if (record.BirthdateCreate.ToString() != "" && record.BirthdateCreate != DateTime.MinValue)
        //        //    record.BirthdateCreate = DateTime.ParseExact(BirthdateCreate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
        //        //else
        //        //    record.BirthdateCreate = DateTime.MinValue;

        //        record.EmailCreate = emailCreate;
        //        record.IsActive = true;
        //        record.TelephoneNumberCreate = contactnoCreate;
        //        record.Notes = null;
        //        string ResultJson = (UserRepository.UpdateUser(record)).ToString();
        //        // return ResultJson.Result=="OK" ? "information updated succesfully" : "There is an Error in updating info please try again";
        //        if (ResultJson.Contains("OK"))
        //        {
        //            return "Information updated succesfully";
        //        }
        //        else
        //        {
        //            return "There is an Error in updating info please try again";
        //        }
        //    }
        //    catch
        //    {
        //        return "There is an Error in updating info please try again";
        //    }


        //}

        //[WebMethod(EnableSession = true)]
        //public User GetUserInfo()
        //{
        //    SessionDetails sd = Session["sessionDetails"] as SessionDetails;
        //    int userId = sd.UserId;
        //    User UserInfo = UserRepository.GetUserDetails(Convert.ToInt32(userId));

        //    return UserInfo;
        //}

        [WebMethod(EnableSession = true)]
        public void SendMessage(string Message, string Email, string Name)
        {
            new Thread(x => sendEmail(Message, Email, Name)).Start();

        }

        public void sendEmail(string Message, string Email, string Name)
        {
            try
            {
                string toEmailAddress = System.Configuration.ConfigurationManager.AppSettings["toEmailAddressOfContactUs"].ToString();
                MailMessage mailMessage = new MailMessage()
                {
                    Subject = "Feedback of Audiogram",
                    Body = Message.Trim()+"<br/><br/> Regards,<br/>"+Name.Trim(),
                    IsBodyHtml = false
                };
                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add(new MailAddress(toEmailAddress));
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.SendAsync(mailMessage, null);

                //MailMessage mm = new MailMessage("sghori0@gmail.com", "frodo10131@gmail.com");
                //mm.Subject = "Subject";
                //mm.Body = "Name: " + Name + "<br /><br />Email: " + Email + "<br /><br />Message: " + Message;
                //mm.IsBodyHtml = true;
                //SmtpClient smtp = new SmtpClient();
                //smtp.Host = "smtp.gmail.com";
                //smtp.EnableSsl = true;
                //System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                //NetworkCred.UserName = "compagilo@gmail.com";
                //NetworkCred.Password = "agilosoft";
                //smtp.UseDefaultCredentials = true;
                //smtp.Credentials = NetworkCred;
                //smtp.Port = 587;
                //smtp.Send(mm);

            }
            catch
            {

            }
        }

    }
}

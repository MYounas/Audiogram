using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Audiogram.Model
{
    public class User
    {

        public int UserId { get; set; }
        public string UserNameCreate { get; set; }
        public Boolean IsActive { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TelephoneNumberCreate { get; set; }
        public string Password { get; set; }
        public int AccountHolderId { get; set; }
        public string AccountHolderName { get; set; }
        public bool IsPasswordChange { get; set; }
        public DateTime? BirthdateCreate { get; set; }
        public string EmailCreate { get; set; }
        public string Notes { get; set; }



       
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Audiogram.Model;

namespace Audiogram.Modules.Common
{
    public class SessionDetails
    {
        private int userId;
        private DataTable dTable;
        private int customerId;
        private string customerName;
        private string userName;
        private int roleTypeId;
        private string Role;
        private string firstName;
        private string lastName;
        private string password;
        private string birthdate;
        private string email;
        private string telephoneNumber;
        private bool? testId;
        private int accountHolderId;
        private int memberShipId;
        private string memberShipType;
        private string accountHolderName;

        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string Birthdate
        {
            get { return birthdate; }
            set { birthdate = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string TelephoneNumber
        {
            get { return telephoneNumber; }
            set { telephoneNumber = value; }

        }
        public bool? TestStart
        {
            get { return testId; }
            set { testId = value; }

        }
  

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
       

        public int RoletypeId
        {
            get { return roleTypeId; }
            set { roleTypeId = value; }
        }

        public int CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }
        public int UserId
        {
            get
            {
                return userId;
            }
            set
            {
                userId = value;
            }
        }
        public DataTable DTable
        {
            get
            {
                return dTable;
            }
            set
            {
                dTable = value;
            }
        }

        public int AccountHolderId
        {
            get { return accountHolderId; }
            set { accountHolderId = value; }
        }

        public int MemberShipId
        {
            get { return memberShipId; }
            set { memberShipId = value; }
        }

        public string MemberShipType
        {
            get { return memberShipType; }
            set { memberShipType = value; }
        }

        public string AccountHolderName
        {
            get { return accountHolderName; }
            set { accountHolderName = value; }
        }
    }
}
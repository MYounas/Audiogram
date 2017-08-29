using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Audiogram.Model
{
    public class Driver
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string CurrentAddress { get; set; }
        public DateTime DOB { get; set; }
        public string FatherName { get; set; }
        public Boolean IsActive { get; set; }
        public Boolean IsDeleted { get; set; }
        public string NIC { get; set; }
        public string Address { get; set; }
        public string Cell { get; set; }
        public string License { get; set; }
        public DateTime LicenseExpiryDate { get; set; }
        public DateTime NICExpiryDate { get; set; }
        public int Status { get; set; }
        
    }
}
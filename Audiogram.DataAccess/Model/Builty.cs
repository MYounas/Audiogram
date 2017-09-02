using System;
using System.ComponentModel.DataAnnotations;

namespace Audiogram.DataAccess.Model
{
    public class Builty
    {
        public int No { get; set; }

        public string Client { get; set; }

        public string Station { get; set; }

        public string Destination { get; set; }

        public string Quantity { get; set; }

        public string Scale { get; set; }

        public string Freight { get; set; }

        public string paidOrNot { get; set; }

        public int TripId { get; set; }

    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace Audiogram.DataAccess.Model
{
    public class DiesalAndCashLoan
    {
        public int ID { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public string SlipNo { get; set; }

        public string Pump { get; set; }

        public int Qty_Ltr { get; set; }

        public int Amount { get; set; }

        public int CashLoan { get; set; }

        public int TripId { get; set; }

        public string Remarks { get; set; }

    }
}

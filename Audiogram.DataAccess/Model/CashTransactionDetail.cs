using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audiogram.DataAccess.Model
{
    public class CashTransactionDetail
    {
        public int ID { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        public string TrSource { get; set; }

        public string TrDetail { get; set; }

        public int Debit { get; set; }

        public int Credit { get; set; }

        public int? TripId { get; set; }

        public string Remarks { get; set; }

    }

}

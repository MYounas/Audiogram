﻿using System;
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

        public int SourceType { get; set; }

        public int SourceValue { get; set; }

        public string TrDetail { get; set; }

        public int Debit { get; set; }

        public int Credit { get; set; }

        public int? TripId { get; set; }

        public string Remarks { get; set; }

<<<<<<< HEAD
=======

>>>>>>> 00040d4974a2d930000de265de705184fd565ab0
    }

}

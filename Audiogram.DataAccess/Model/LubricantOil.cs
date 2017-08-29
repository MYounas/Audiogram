using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audiogram.DataAccess.Model
{
    public class LubricantOil
    {
        public int ID { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public string Workshop_Brand { get; set; }

        public int Qty_Ltr { get; set; }

        public int Amount { get; set; }

        public int TripId { get; set; }

        public string Remarks { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audiogram.DataAccess.Model
{
    public class Tire
    {
        public int ID { get; set; }
        public int VehicleId { get; set; }
        public string Number { get; set; }
        public string Pattern { get; set; }
        public string LotNumber { get; set; }
        public DateTime TireAddOn { get; set; }
        public DateTime TireRemoveOn { get; set; }

}   
    
}

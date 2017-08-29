using System;

namespace Audiogram.Model
{
    public class Vehicle
    {
        public int ID { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Version { get; set; }
        public int Year { get; set; }
        public int CC { get; set; }
        public string NumberPlate { get; set; }
        public string Color { get; set; }
        public Boolean IsActive { get; set; }
        public Boolean IsDeleted { get; set; }
        public int Status { get; set; }
        public string Name {
            get
            {
                return Make + " " + Model + " " + Version;
            }
        }

    }
}
using System;

namespace Audiogram.DataAccess.Model
{
    public class Trip
    {
        // Basic
        public int ID { get; set; }
        public int VehicleID { get; set; }
        public int FirstDriverID { get; set; }
        public int SecondDriverID { get; set; }
        public DateTime StartDate { get; set; }
        public string RouteDetail { get; set; }

        //Expenses
        public int Fix { get; set; }
        public int Pallytaree { get; set; }
        public int ToolTax { get; set; }
        public int ContPort { get; set; }
        public int Munshiana { get; set; }
        public int Food { get; set; }
        public int Godown { get; set; }
        public int Tyre { get; set; }
        public int Accident { get; set; }
        public int Police { get; set; }
        public int PartsMaint { get; set; }
        public int LabourMaint { get; set; }
        public int Salary { get; set; }
        public int Misc1 { get; set; }
        public int Misc2 { get; set; }
        public int Misc3 { get; set; }

        // Settlement

        public int PreviousPeshgi { get; set; }
        public int CashAdvDeposit { get; set; }
        public int PurchoonFrieghtUp { get; set; }
        public int PurchoonFrightReturn { get; set; }
        public int PumpCashLoan { get; set; }
        public int MiscCashLoan { get; set; }
        public int SetMisc1 { get; set; }
        public int SetMisc2 { get; set; }
        public int SetMisc3 { get; set; }
        public int SetMisc4 { get; set; }

        //Builty

        public string No { get; set; }

        public string Client { get; set; }

        public string Station { get; set; }

        public string Destination { get; set; }

        public string Quantity { get; set; }

        public string Scale { get; set; }

        public string Freight { get; set; }

        public string paidOrNot { get; set; }




        public object this[string propertyName]
        {
            get { return this.GetType().GetProperty(propertyName).GetValue(this, null); }
            set { this.GetType().GetProperty(propertyName).SetValue(this, value, null); }
        }

        // Grid Fields
        public string Vehicle { get; set; }
        public string FirstDriver { get; set; }
        public string SecondDriver { get; set; }
        public int Expenses { get; set; }
        public int Settlement { get; set; }
        

    }
}

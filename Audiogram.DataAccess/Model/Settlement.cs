using System;

namespace Audiogram.DataAccess.Model
{
    public class Settlement
    {
        public int ID { get; set; }
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
        public int TripId { get; set; }

    }
}

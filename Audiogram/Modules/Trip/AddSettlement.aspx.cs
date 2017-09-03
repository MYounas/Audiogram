using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.Services;
using Audiogram.DataAccess;
using Audiogram.DataAccess.Model;


namespace Audiogram.Modules.Trip
{
    public partial class AddSettlement : Page
    {

        static int TripId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
                TripId = Convert.ToInt32(Request.QueryString["id"]);

                List<Settlement> allRecords = SettlementRepository.getSettlementByTripID(TripId);
                Settlement oneRecord = null;
                if (allRecords.Count != 0)
                {
                    oneRecord = allRecords[0];
                    txtPreviousPeshgi.Text = oneRecord.PreviousPeshgi.ToString();
                    txtCashAdvDeposit.Text = oneRecord.CashAdvDeposit.ToString();
                    txtPurchoonFrieghtUp.Text = oneRecord.PurchoonFrieghtUp.ToString();
                    txtPurchoonFrightReturn.Text = oneRecord.PurchoonFrightReturn.ToString();
                    txtPumpCashLoan.Text = oneRecord.PumpCashLoan.ToString();
                    txtMiscCashLoan.Text = oneRecord.MiscCashLoan.ToString();
                    txtSetMisc1.Text = oneRecord.SetMisc1.ToString();
                    txtSetMisc2.Text = oneRecord.SetMisc2.ToString();
                    txtSetMisc3.Text = oneRecord.SetMisc3.ToString();
                    txtSetMisc4.Text = oneRecord.SetMisc4.ToString();

                }

                TripRepository repo = new TripRepository();
                object obj = TripRepository.GetTrips(0, "FirstDriver ASC", 50);
                List<DataAccess.Model.Trip> lstTrips = ((List<DataAccess.Model.Trip>)obj.GetType().GetProperty("Records").GetValue(obj, null));
                DataAccess.Model.Trip temp = new DataAccess.Model.Trip();
                temp.ID = 0;
                temp.FirstDriver = "--SELECT--";
                lstTrips.Insert(0, temp);
                drpTrip.DataSource = lstTrips;
                drpTrip.DataTextField = "FirstDriver";
                //drpTrip.DataTextField = "RouteDetail";
                drpTrip.DataValueField = "ID";
                drpTrip.DataBind();

                drpTrip.SelectedValue = TripId.ToString();
            }
        }


        [WebMethod(EnableSession = true)]
        public static object RecordList(int jtStartIndex, int jtPageSize, string jtSorting)
        {
            int recordTo = jtPageSize + jtStartIndex;
            //return CTDRepository.GetCTDList(TripId);
            return SettlementRepository.GetSettlementList(TripId, jtStartIndex, jtSorting, recordTo);

        }

        //[WebMethod(EnableSession = true)]
        //public static object RecordList()
        //{
        //    //int recordTo = jtPageSize + jtStartIndex;
        //    return DACLRepository.GetDACLList(TripId);

        //}

        [WebMethod(EnableSession = true)]
        public static object CreateRecord(Settlement record)
        {
            record.TripId = TripId;
            return SettlementRepository.CreateSettlement(record);
        }

        [WebMethod(EnableSession = true)]
        public static object UpdateRecord(Settlement record)
        {
            return SettlementRepository.UpdateSettlement(record);
        }

        [WebMethod(EnableSession = true)]
        public static object DeleteRecord(int ID)
        {
            return SettlementRepository.DeleteSettlement(ID);
        }

        protected void drpTrip_SelectedIndexChanged(object sender, EventArgs e)
        {
            TripId = Convert.ToInt32(drpTrip.SelectedValue);
        }

        protected void btnStartTest_Click(object sender, EventArgs e)
        {

            List<Settlement> allRecords = SettlementRepository.getSettlementByTripID(TripId);
            Settlement oneRecord = null;
            Settlement exp = new Settlement();
            if (allRecords.Count != 0)
            {
                oneRecord = allRecords[0];
                exp.ID = oneRecord.ID;
            }

            exp.PreviousPeshgi = Convert.ToInt32(txtPreviousPeshgi.Text);
            exp.CashAdvDeposit = Convert.ToInt32(txtCashAdvDeposit.Text);
            exp.PurchoonFrieghtUp = Convert.ToInt32(txtPurchoonFrieghtUp.Text);
            exp.PurchoonFrightReturn = Convert.ToInt32(txtPurchoonFrightReturn.Text);
            exp.PumpCashLoan = Convert.ToInt32(txtPumpCashLoan.Text);
            exp.MiscCashLoan = Convert.ToInt32(txtMiscCashLoan.Text);
            exp.SetMisc1 = Convert.ToInt32(txtSetMisc1.Text);
            exp.SetMisc2 = Convert.ToInt32(txtSetMisc2.Text);
            exp.SetMisc3 = Convert.ToInt32(txtSetMisc3.Text);
            exp.SetMisc4 = Convert.ToInt32(txtSetMisc4.Text);
            exp.TripId = TripId;

            if (oneRecord != null)
            {
                SettlementRepository.UpdateSettlement(exp);
            }
            else
            {
                SettlementRepository.CreateSettlement(exp);
            }

            Response.Redirect("TripManagement.aspx", false);
        }
    }
}
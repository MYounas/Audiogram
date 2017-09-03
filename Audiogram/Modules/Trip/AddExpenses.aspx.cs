using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.Services;
using Audiogram.DataAccess;
using Audiogram.DataAccess.Model;


namespace Audiogram.Modules.Trip
{
    public partial class AddExpenses : Page
    {

        static int TripId;
        static int JI=0, RT = 0; static string JS = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
                TripId = Convert.ToInt32(Request.QueryString["id"]);
                List<Expenses> allRecords = ExpensesRepository.getExpensesByTripID(TripId);
                Expenses oneRecord = null;
                if (allRecords.Count != 0)
                {
                    oneRecord = allRecords[0];
                    txtFix.Text = oneRecord.Fix.ToString();
                    txtPallytaree.Text = oneRecord.Pallytaree.ToString();
                    txtToolTax.Text = oneRecord.ToolTax.ToString();
                    txtContPort.Text = oneRecord.ContPort.ToString();
                    txtMunshiana.Text = oneRecord.Munshiana.ToString();
                    txtFood.Text = oneRecord.Food.ToString();
                    txtGodown.Text = oneRecord.Godown.ToString();
                    txtTyre.Text = oneRecord.Tyre.ToString();
                    txtAccident.Text = oneRecord.Accident.ToString();
                    txtPolice.Text = oneRecord.Police.ToString();
                    txtPartsMaint.Text = oneRecord.PartsMaint.ToString();
                    txtLabourMaint.Text = oneRecord.LabourMaint.ToString();
                    txtSalary.Text = oneRecord.Salary.ToString();
                    txtMisc1.Text = oneRecord.Misc1.ToString();
                    txtMisc2.Text = oneRecord.Misc2.ToString();
                    txtMisc3.Text = oneRecord.Misc3.ToString();

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
            RT = recordTo;JI = jtStartIndex;JS = jtSorting;
            return ExpensesRepository.GetExpensesList(TripId, jtStartIndex, jtSorting, recordTo);

        }
        

        [WebMethod(EnableSession = true)]
        public static object CreateRecord(Expenses record)
        {
            record.TripId = TripId;
            return ExpensesRepository.CreateExpenses(record);
        }

        [WebMethod(EnableSession = true)]
        public static object UpdateRecord(Expenses record)
        {
            return ExpensesRepository.UpdateExpenses(record);
        }

        [WebMethod(EnableSession = true)]
        public static object DeleteRecord(int ID)
        {
            return ExpensesRepository.DeleteExpenses(ID);
        }

        protected void drpTrip_SelectedIndexChanged(object sender, EventArgs e)
        {
            TripId = Convert.ToInt32(drpTrip.SelectedValue);
        }


        protected void btnStartTest_Click(object sender, EventArgs e)
        {
            List<Expenses> allRecords = ExpensesRepository.getExpensesByTripID(TripId);
            Expenses oneRecord=null;
            Expenses exp = new Expenses();
            if (allRecords.Count != 0)
            {
                oneRecord = allRecords[0];
                exp.ID = oneRecord.ID;
            }

            exp.Fix = Convert.ToInt32(txtFix.Text);
            exp.Pallytaree = Convert.ToInt32(txtPallytaree.Text);
            exp.ToolTax = Convert.ToInt32(txtToolTax.Text);
            exp.ContPort = Convert.ToInt32(txtContPort.Text);
            exp.Munshiana = Convert.ToInt32(txtMunshiana.Text);
            exp.Food = Convert.ToInt32(txtFood.Text);
            exp.Godown = Convert.ToInt32(txtGodown.Text);
            exp.Tyre = Convert.ToInt32(txtTyre.Text);
            exp.Accident = Convert.ToInt32(txtAccident.Text);
            exp.Police = Convert.ToInt32(txtPolice.Text);
            exp.PartsMaint = Convert.ToInt32(txtPartsMaint.Text);
            exp.LabourMaint = Convert.ToInt32(txtLabourMaint.Text);
            exp.Salary = Convert.ToInt32(txtSalary.Text);
            exp.Misc1 = Convert.ToInt32(txtMisc1.Text);
            exp.Misc2 = Convert.ToInt32(txtMisc2.Text);
            exp.Misc3= Convert.ToInt32(txtMisc3.Text);
            exp.TripId = TripId;

            if (oneRecord != null)
            {
                ExpensesRepository.UpdateExpenses(exp);
            }
            else
            {
                ExpensesRepository.CreateExpenses(exp);
            }

            Response.Redirect("TripManagement.aspx", false);
        }
    }
}
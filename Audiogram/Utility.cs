using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Audiogram
{
    public static class Utility
    {
        public static void BindDropDown(DropDownList dropDown, Object list, string TextField, string ValueField)
        {
               dropDown.DataSource = list;
                dropDown.DataTextField = TextField;
                dropDown.DataValueField = ValueField;
                dropDown.DataBind();
        }

        public static int GetSafeInteger(object value)
        {
            try
            {
                return Convert.ToInt32(value);
            }
            catch
            {
                return 0;
            }
        }
    }
}
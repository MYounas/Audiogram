using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Audiogram.DataAccess
{
    public class Utility
    {
        //used to format the selected data to be format in xml to prase into sp

        public static string ConvertToXml(ArrayList gridIds,string key)
        {    

           //gridIds.  
            string xml = string.Empty;

            if (gridIds != null)
            {


                xml += "<Root>";
                foreach (Hashtable oRecord in gridIds)
                {
                    xml += "<Value>" + oRecord[key] + "</Value>";


                }
                xml += "</Root>";

            }
            else
            {
               return null;
            }

            return xml;

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
        public static string ConvertDataToHtml(string data)
        {

            data = "<li>" + data + "</li>";

            return data;
        }
        public static string ConvertDataToHtmlForCategoryGlobalContentToolTip(string data,string column)
        {
            if (data == "0")
            {
                if(column == "Image")
                    data = "<font color=\"black\"><b>Image:</b> <i>Not Found</i></font>" + "</br>";
                else if(column == "Video")
                    data = "<font color=\"black\"><b>YouTube Video:</b> <i>Not Found</i></font>" + "</br>";
                else if(column == "Description")
                    data = "<font color=\"black\"><b>Description:</b> <i>Not Found</i></font>" + "</br>";
            }
            else
            {
                if (column == "Image")
                    data = "<b>Image:</b> <i>Found</i>" + "</br>";
                else if (column == "Video")
                    data = "<b>YouTube Video:</b> <i>Found</i>" + "</br>";
                else if (column == "Description")
                    data = "<b>Description:</b> <i>Found</i>" + "</br>";
            }
            return data;
        }
        //New location ToolTip work
        //public static string ConvertDataToHtmlForLocationToolTip(string data, int locationId,string column)
        //{

        //    if (column != "Country")
        //    {
        //        data = string.Empty;
        //        DataTable dataTable = LocationParentsForToolTip.SearchParentsForLocation(locationId, column+"Id");
        //        if (column == "State")
        //        {
        //            foreach (DataRow r in dataTable.Rows)
        //            {
        //                data += "<li>" + r["Country"].ToString() + "</li>";
        //                data += "<li>&nbsp&nbsp&nbsp&nbsp&nbsp" + r[column].ToString() + "</li>";
        //            }
        //        }
        //        else if (column == "County")
        //        {
        //            foreach (DataRow r in dataTable.Rows)
        //            {
        //                data += "<li>" + r["Country"].ToString() + "</li>";
        //                data += "<li>&nbsp&nbsp&nbsp&nbsp&nbsp" + r["State"].ToString() + "</li>";
        //                data += "<li>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp" + r[column].ToString() + "</li>";
        //            }

        //        }
        //        else if (column == "City")
        //        {
        //            foreach (DataRow r in dataTable.Rows)
        //            {
        //                data += "<li>" + r["Country"].ToString() + "</li>";
        //                data += "<li>&nbsp&nbsp&nbsp&nbsp&nbsp" + r["State"].ToString() + "</li>";
        //                data += "<li>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp" + r["County"].ToString() + "</li>";
        //                data += "<li>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp" + r[column].ToString() + "</li>";
        //            }

        //        }
        //        else if (column == "Zip")
        //        {
        //            foreach (DataRow r in dataTable.Rows)
        //            {
        //                data += "<li>" + r["Country"].ToString() + "</li>";
        //                data += "<li>&nbsp&nbsp&nbsp&nbsp&nbsp" + r["State"].ToString() + "</li>";
        //                data += "<li>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp" + r["County"].ToString() + "</li>";
        //                data += "<li>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp" + r["City"].ToString() + "</li>";
        //                data += "<li>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp" + r[column].ToString() + "</li>";
        //            }
        //        }

        //    }
        //    //data = "<li>" + data + "</li>";

        //    return data;
        //}

  
    }
}

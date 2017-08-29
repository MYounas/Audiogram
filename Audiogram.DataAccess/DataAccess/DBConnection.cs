using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace Audiogram.DataAccess
{
    public class DBConnection
    {
        /// <summary>
        /// This is used to initialize the Connection string to use across Application
        /// </summary>
        /// <returns>Connection of Database</returns>
        public static SqlConnection GetConnection()
        {

            return new SqlConnection(ConfigurationManager.AppSettings["connectionString"]);
        }
    }
}
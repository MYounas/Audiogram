using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;

namespace Audiogram.DataAccess
{
    public class Logging
    {
        public readonly ILog log = LogManager.GetLogger(typeof(Logging));
        public Logging()
        {
            log4net.Config.XmlConfigurator.Configure();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Audiogram.Model
{
    public class MenuItem
    {
        public MenuItem()
        {
            children = new List<MenuItem>();
        }

        //[JsonIgnore]
        public string id { get; set; }
        //[JsonIgnore]
        public string pid { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public List<MenuItem> children { get; set; }
    }
}
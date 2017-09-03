using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audiogram.DataAccess.Model
{
    public class DropDownItem
    {
        public int Value { get; set; }
        public string DisplayText { get; set; }

        public DropDownItem(int Value, string DisplayText)
        {
            this.DisplayText = DisplayText;
            this.Value = Value;
        }

        public DropDownItem()
        {
        }
            

    }
}

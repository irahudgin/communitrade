using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace communiTrade.MVVM.Model
{
    public class Item
    {
        public int itemID { get; set; }
        public int sellerID { get; set; }
        public string itemName { get; set; }
        public string description { get; set; }
    }
}

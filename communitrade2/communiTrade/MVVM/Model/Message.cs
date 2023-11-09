using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace communiTrade.MVVM.Model
{
    internal class Message
    {
        public int MessageID { get; set; }
        public int SenderID { get; set; }
        public int ReceiverID { get; set; }
        public string MessageText { get; set; }
    }
}

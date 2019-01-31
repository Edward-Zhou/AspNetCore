using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRConsoleClient
{
    public class Message
    {
        public int MessageId { get; set; }

        public List<Dictionary<string, object>> Items { get; set; }

        public List<string> TextMessages { get; set; }
    }
}

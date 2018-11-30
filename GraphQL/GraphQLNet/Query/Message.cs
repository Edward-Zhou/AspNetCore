using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLNet.Query
{
    public class Message
    {
        public string Sub { get; set; }

        public string Content { get; set; }

        public DateTime SentAt { get; set; }
    }
}

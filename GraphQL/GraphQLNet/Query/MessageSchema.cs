using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLNet.Query
{
    public class MessageSchema: Schema
    {
        public MessageSchema() : base()
        {
            Query = new MessageQuery();
        }
    }
}

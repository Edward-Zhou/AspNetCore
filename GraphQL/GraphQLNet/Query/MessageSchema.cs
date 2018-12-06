using GraphQL.Types;
using GraphQLNet.Converters.ByteValueConverter;
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
            RegisterValueConverter(new ByteValueConverter());
            Query = new MessageQuery();
        }
    }
}

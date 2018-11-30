using GraphQL.Authorization;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLNet.Query
{
    public class MessageQuery : ObjectGraphType<Message>
    {
        public MessageQuery()
        {
            Field(o => o.Content).Resolve(o => "This is Content").AuthorizeWith("Authorized");
            Field(o => o.SentAt);
            Field(o => o.Sub).Resolve(o => "This is Sub");
        }
    }
}

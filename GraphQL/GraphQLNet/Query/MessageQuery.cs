using GraphQL.Authorization;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
            //Field(o => o.Image).Resolve(o => ConvertToBytes(@"C:\Users\edwardzh\Desktop\T1.PNG"));
            Field(o => o.ImagePath).Resolve(o => Byte.Parse("Hello World"));
        }

        public byte[] ConvertToBytes(string fileName)
        {
            using (Stream stream = File.Open(fileName, FileMode.Open))
            {
                var bytes = new byte[stream.Length];
                stream.Read(bytes, 0, (int)stream.Length);
                return bytes;
            }
        }
    }
}

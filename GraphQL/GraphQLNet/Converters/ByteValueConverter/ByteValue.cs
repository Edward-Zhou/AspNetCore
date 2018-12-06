using GraphQL.Language.AST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLNet.Converters.ByteValueConverter
{
    internal class ByteValue : ValueNode<byte>
    {
        public ByteValue(byte value)
        {
            Value = value;
        }

        protected override bool Equals(ValueNode<byte> node)
        {
            return Value == node.Value;
        }
    }
}

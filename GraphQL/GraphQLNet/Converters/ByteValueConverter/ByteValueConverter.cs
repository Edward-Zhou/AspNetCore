using GraphQL.Language.AST;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLNet.Converters.ByteValueConverter
{
    internal class ByteValueConverter : IAstFromValueConverter
    {
        public bool Matches(object value, IGraphType type)
        {
            return value is byte;
        }

        public IValue Convert(object value, IGraphType type)
        {
            return new ByteValue((byte)value);
        }
    }
}

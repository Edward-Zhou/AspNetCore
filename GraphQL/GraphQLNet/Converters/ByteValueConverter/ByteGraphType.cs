using GraphQL.Language.AST;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLNet.Converters.ByteValueConverter
{
    internal class ByteGraphType : ScalarGraphType
    {
        public ByteGraphType()
        {
            Name = "Byte";
        }

        public override object Serialize(object value)
        {
            return ParseValue(value);
        }

        public override object ParseValue(object value)
        {
            if (value == null)
            {
                return null;
            }

            try
            {
                var result = Convert.ToByte(value);
                return result;
            }
            catch (FormatException)
            {
                return null;
            }
        }

        public override object ParseLiteral(IValue value)
        {
            var byteValue = value as ByteValue;
            return byteValue?.Value;
        }
    }
}

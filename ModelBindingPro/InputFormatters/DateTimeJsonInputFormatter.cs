using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.ObjectPool;
using Newtonsoft.Json;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelBindingPro.InputFormatters
{
    public class DateTimeJsonInputFormatter: JsonInputFormatter
    {
        public DateTimeJsonInputFormatter(
        ILogger logger,
        JsonSerializerSettings serializerSettings,
        ArrayPool<char> charPool,
        ObjectPoolProvider objectPoolProvider) : base(logger, serializerSettings, charPool, objectPoolProvider)
        {
        }

        public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context, Encoding encoding)
        {
            InputFormatterResult result = await base.ReadRequestBodyAsync(context, encoding);
            return result;
        }

    }
}

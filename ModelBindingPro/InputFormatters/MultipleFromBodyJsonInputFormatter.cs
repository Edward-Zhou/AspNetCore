using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.ObjectPool;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelBindingPro.InputFormatters
{
    public class MultipleFromBodyJsonInputFormatter : JsonInputFormatter
    {
        public MultipleFromBodyJsonInputFormatter(
        ILogger logger,
        JsonSerializerSettings serializerSettings,
        ArrayPool<char> charPool,
        ObjectPoolProvider objectPoolProvider) : base(logger, serializerSettings, charPool, objectPoolProvider)
        {
        }

        public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context, Encoding encoding)
        {
            var request = context.HttpContext.Request;
            using (var reader = new StreamReader(request.Body))
            {
                var content = await reader.ReadToEndAsync();
                var resource = JObject.Parse(content);
                var model = resource.Properties().FirstOrDefault(r => r.Name == context.ModelName);
                var result = JsonConvert.DeserializeObject(model.ToString());
                foreach (var property in resource.Properties())
                {
                    Console.WriteLine("{0} - {1}", property.Name, property.Value);
                }
                return await InputFormatterResult.SuccessAsync(content);
            }
            //InputFormatterResult result = await base.ReadRequestBodyAsync(context, encoding);
            //return result;
        }

    }
}

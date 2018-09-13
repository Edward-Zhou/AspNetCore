using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPro.ActionFilters
{
    public class RequestLoggerActionFilter : ActionFilterAttribute
    {
        private readonly ILogger _logger;

        public RequestLoggerActionFilter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("RequestLogger");
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var request = context.HttpContext.Request;
            request.EnableRewind();
            request.Body.Position = 0;

            using (var reader = new StreamReader(request.Body))
            {
                var bodyString = reader.ReadToEnd();
                _logger.LogInformation($"API call recevied on {request.Method.ToUpper()} {request.Path} RequestBody: {bodyString}");
            }

            base.OnActionExecuting(context);
        }
    }
}

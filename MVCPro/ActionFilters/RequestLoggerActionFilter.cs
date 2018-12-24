using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MVCPro.Models;
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
        private readonly IConfiguration _configuration;
        private readonly MVCProContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public RequestLoggerActionFilter(ILoggerFactory loggerFactory
            , IConfiguration configuration
            , MVCProContext context
            , IHttpContextAccessor httpContextAccessor)
        {
            _logger = loggerFactory.CreateLogger("RequestLogger");
            _configuration = configuration;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            var cookies = _httpContextAccessor.HttpContext.Request.Cookies;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            var cookies = context.HttpContext.Request.Cookies;
            var db = context.HttpContext.RequestServices.GetRequiredService<MVCProContext>();
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

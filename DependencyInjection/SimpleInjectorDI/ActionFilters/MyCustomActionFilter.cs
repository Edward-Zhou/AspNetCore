using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using SimpleInjectorDI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleInjectorDI.ActionFilters
{
    public class MyCustomActionFilter : IActionFilter
    {
        private readonly IMyService _myService;
        private readonly ILogger<MyCustomActionFilter> _logger;
        public MyCustomActionFilter(IMyService myService
            , ILogger<MyCustomActionFilter> logger)
        {
            _myService = myService;
            _logger = logger;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation(_myService.HelloWorld());
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //throw new NotImplementedException();
        }
    }
}

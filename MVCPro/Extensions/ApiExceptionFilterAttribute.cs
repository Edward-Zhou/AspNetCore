using Microsoft.AspNetCore.Mvc.Filters;
using MVCPro.ActionFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPro.Extensions
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly IExceptionService exceptionService;

        public ApiExceptionFilterAttribute(IExceptionService exceptionService)
        {
            this.exceptionService = exceptionService;
        }

        public override void OnException(ExceptionContext context)
        {
            Exception e = context.Exception;
            exceptionService.Save(e);
        }
    }
}

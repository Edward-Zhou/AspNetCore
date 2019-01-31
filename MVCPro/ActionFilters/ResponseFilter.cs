using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPro.ActionFilters
{
    public class ResponseFilter : IAsyncResultFilter
    {
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            // do something before the action executes
            if (context.Result is EmptyResult)
            {
                context.Result = new JsonResult(new ApiResult());
            }
            var resultContext = await next();
            // do something after the action executes; resultContext.Result will be set
        }
    }
    public class ApiResult
    {
        public int Code { get; set; }
        public object Result { get; set; }
    }
}

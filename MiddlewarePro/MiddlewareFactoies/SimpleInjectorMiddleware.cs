using Microsoft.AspNetCore.Http;
using MiddlewarePro.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewarePro.MiddlewareFactoies
{
    public class SimpleInjectorMiddleware: IMiddleware
    {
        private readonly IScopedService _scopedService;

        public SimpleInjectorMiddleware(IScopedService scopedService)
        {
            _scopedService = scopedService;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync($"This is { GetType().Name } and value is { _scopedService.GetData() } </br>");

            await next(context);
        }
        
    }
}

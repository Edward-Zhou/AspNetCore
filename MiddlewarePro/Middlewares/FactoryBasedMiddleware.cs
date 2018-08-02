using Microsoft.AspNetCore.Http;
using MiddlewarePro.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewarePro.Middlewares
{
    public class FactoryBasedMiddleware : IMiddleware
    {
        private readonly IScopedService _scopedService;
        public FactoryBasedMiddleware(IScopedService scopedService)
        {
            _scopedService = scopedService;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync($"This is From { GetType().Name }" +
                $"And Service Result is { _scopedService.GetData() } </br>");

            await next(context);
        }
    }
}

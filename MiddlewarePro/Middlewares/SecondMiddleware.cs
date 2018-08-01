using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewarePro.Middlewares
{
    public class SecondMiddleware
    {
        private readonly RequestDelegate _next;
        public SecondMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await context.Response.WriteAsync($"This is { GetType().Name }");
            await _next(context);
        }
    }
}

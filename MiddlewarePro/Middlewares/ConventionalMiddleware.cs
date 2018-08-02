using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewarePro.Middlewares
{
    public class ConventionalMiddleware
    {
        private readonly RequestDelegate _next;
        public ConventionalMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            await context.Response.WriteAsync($"This is { GetType().Name } </br>");

            await _next(context);
        }
    }
}

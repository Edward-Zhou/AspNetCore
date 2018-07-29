using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartupPro
{
    public class RequestSecondMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestSecondMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("RequestSecondMiddleware.InvokeAsync");

            await _next(context);
        }
    }
}

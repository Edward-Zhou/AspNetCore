using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartupPro
{
    public class RequestMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            Console.WriteLine($"{ this.GetType().Name }.InvokeAsync Request </br>");
            await context.Response.WriteAsync($"{ this.GetType().Name } Request </br>");
            await _next(context);
            Console.WriteLine($"{ this.GetType().Name }.InvokeAsync Response </br>");
            await context.Response.WriteAsync($"{ this.GetType().Name } Response </br>");
        }
    }
}

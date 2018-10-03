using Microsoft.AspNetCore.Http;
using Serilog.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SerilogPro.Enrichers
{
    public class UserNameEnricher
    {
        private readonly RequestDelegate next;

        public UserNameEnricher(RequestDelegate next)
        {
            this.next = next;
        }

        public Task Invoke(HttpContext context)
        {
            LogContext.PushProperty("UserName", context.User.Identity.Name);

            return next(context);
        }
    }
}

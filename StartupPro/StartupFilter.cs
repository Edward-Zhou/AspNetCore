using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartupPro
{
    public class StartupFilter
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IStartupFilter, RequestStartupFilter>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<RequestSecondMiddleware>();
            app.UseMiddleware<RequestMiddleware>();
            app.Run(async context => {
                await context.Response.WriteAsync("End </br>");
            });
        }
    }
}

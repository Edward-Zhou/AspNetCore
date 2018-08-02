using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MiddlewarePro.Middlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewarePro
{
    public class StartupMiddlewareType
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //we should add FactoryBasedMiddleware to IServiceCollection
            //Otherwise, you will receive System.InvalidOperationException
            //: No service for type 'MiddlewarePro.Middlewares.FactoryBasedMiddleware' has been registered.
            services.AddTransient<FactoryBasedMiddleware>();
        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();

            app.UseConventionalMiddleware();
            app.UseFactoryBasedMiddleware();
            app.Run(async context => {
                await context.Response.WriteAsync($"This is End");
            });
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MiddlewarePro.Middlewares;
using MiddlewarePro.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewarePro
{
    public class StartupDependency
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ISingletonService, SingletonService>();
            services.AddScoped<IScopedService, ScopedService>();
        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddlewareDependency();
        }
    }
}

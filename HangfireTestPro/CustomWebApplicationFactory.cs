using Hangfire;
using Hangfire.MemoryStorage;
using Hangfire.SqlServer;
using HangfirePro;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangfireTestPro
{
    public class CustomWebApplicationFactory<TEntryPoint> : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddSingleton<JobStorage>(x =>
                {
                    return GlobalConfiguration.Configuration.UseMemoryStorage();
                });
            });
        }

        protected override IWebHostBuilder CreateWebHostBuilder()
        {
            return base.CreateWebHostBuilder();
        }
    }
}

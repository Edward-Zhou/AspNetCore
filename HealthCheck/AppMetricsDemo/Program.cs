using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using App.Metrics.AspNetCore;
using App.Metrics.AspNetCore.Health;
using App.Metrics.Health;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AppMetricsDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureHealthWithDefaults(
                builder =>
                {
                    builder.HealthChecks.AddCheck("DatabaseConnected",
                () => new ValueTask<HealthCheckResult>(HealthCheckResult.Healthy("Database Connection OK")));
                })
                .UseHealth()
                .UseStartup<Startup>();
    }
}

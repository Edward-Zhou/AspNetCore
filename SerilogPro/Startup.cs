using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.SqlServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using SerilogPro.Enrichers;
using SerilogPro.Extensions;

namespace SerilogPro
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddSeq(Configuration.GetSection("Seq"));
                //loggingBuilder.AddSeq("http://edwardcore.westus.cloudapp.azure.com:5341", apiKey: "K5HzACIfiQxr67CKlvUj");
            });

            services.AddDistributedSqlServerCache(options => {
                options.ConnectionString = @"Server=localhost\MSSQLSERVER01;Database=IISWindows;Trusted_Connection=True;";
                options.TableName = "CacheFromCommand";
                options.SchemaName = "dbo";
            });

            //services.ConfigureSqlCache();
            services.ConfigureSqlCacheFromCommand();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IApplicationLifetime lifetime, IDistributedCache cache)
        {
            //lifetime.ApplicationStarted.Register(() =>
            //{
            //    var currentTimeUTC = DateTime.UtcNow.ToString();
            //    byte[] encodedCurrentTimeUTC = Encoding.UTF8.GetBytes(currentTimeUTC);
            //    var options = new DistributedCacheEntryOptions()
            //        .SetSlidingExpiration(TimeSpan.FromSeconds(20));
            //    cache.Set("cachedTimeUTC", encodedCurrentTimeUTC, options);
            //});
            //var output = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] {Message} {ActionName} {UserName} {NewLine}{Exception} {MachineName}";

            //Log.Logger = new LoggerConfiguration()
            //       .Enrich.FromLogContext() // Populates a 'User' property on every log entry
            //       .Enrich.WithProperty("MachineName", Environment.MachineName)
            //       .WriteTo.RollingFile("Logs/app-{Date}.txt", outputTemplate: output)
            //       .WriteTo.Seq("http://edwardcore.westus.cloudapp.azure.com:5341",apiKey: "K5HzACIfiQxr67CKlvUj")
            //       .CreateLogger();
            loggerFactory
                //.AddFile("Logs/app-{Date}.txt")
                .AddSerilog();
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseMiddleware<UserNameEnricher>();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });


            var log = new LoggerConfiguration()
                .WriteTo.RollingFile(@"Logs/app.txt")
                .CreateLogger();

            log.Information("Created logger1...");

            var log1 = new LoggerConfiguration()
            .WriteTo.RollingFile(@"Logs/app.txt")
            .CreateLogger();

            log1.Information("Created logger2...");

        }
    }
}

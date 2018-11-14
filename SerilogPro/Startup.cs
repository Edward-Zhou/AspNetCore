using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using SerilogPro.Enrichers;

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
                loggingBuilder.AddSeq();
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            var output = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] {Message} {ActionName} {UserName} {NewLine}{Exception}";

            Log.Logger = new LoggerConfiguration()
                   .Enrich.FromLogContext() // Populates a 'User' property on every log entry
                   .WriteTo.RollingFile("Logs/app-{Date}.txt",outputTemplate: output)
                   .CreateLogger();
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
        }
    }
}

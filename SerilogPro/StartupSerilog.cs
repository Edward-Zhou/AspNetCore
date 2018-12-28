using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using SerilogPro.Data;
using SerilogPro.Enrichers;
using SerilogPro.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VG.Serilog.Sinks.EntityFrameworkCore;

namespace SerilogPro
{
    public class StartupSerilog
    {
        public StartupSerilog(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc();

            services.AddSingleton<Serilog.ILogger>(x =>
            {
                return new LoggerConfiguration()
                            .WriteTo
                            .MSSqlServer(@"Data Source=CLOUDTEAM;Initial Catalog=StoreDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False",
                            "Logs", autoCreateSqlTable: true).CreateLogger();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //Log.Logger = new LoggerConfiguration()
            //                    .ReadFrom.ConfigurationSection(Configuration.GetSection("Serilog"))
            //                    //.WriteTo.MSSqlServer(@"Server=(localdb)\\mssqllocaldb;Database=aspnet-SerilogPro-2CDB919B-F9FB-4EAE-886E-EB4D35161A43;Trusted_Connection=True;MultipleActiveResultSets=true"
            //                    //    , "LogRecords"
            //                    //    , autoCreateSqlTable: true)
            //                    //.WriteTo.EntityFrameworkCoreSink(app.ApplicationServices)
            //                    .CreateLogger();
            Serilog.Debugging.SelfLog.Enable(msg =>
            {
                Debug.Print(msg);
                Debugger.Break();
            });
            loggerFactory.AddSerilog();
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
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

    }
}

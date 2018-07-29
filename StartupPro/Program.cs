using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace StartupPro
{
    public class Program
    {
        public static IHostingEnvironment HostingEnvironment { get; set; }
        public static IConfiguration Configuration { get; set; }
        public static void Main(string[] args)
        {
            //CreateWebHostBuilder(args).Build().Run();
            //CreateWebHostBuilderWithOutStartup(args).Build().Run();
            CreateWebHostBuilderWithStartupFilter(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                   .UseStartup<Startup>();

        public static IWebHostBuilder CreateWebHostBuilderWithDI(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                   .UseStartup<StartupDI>();

        public static IWebHostBuilder CreateWebHostBuilderWithOutStartup(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                   .ConfigureAppConfiguration((hostingContext, config) =>
                   {
                       HostingEnvironment = hostingContext.HostingEnvironment;
                       Configuration = config.Build();
                   })
                   .ConfigureServices(services =>
                   {
                       //Configure Services
                   })
                   .Configure(app =>
                   {
                       app.Run(async context => {
                           await context.Response.WriteAsync("Hello World!");
                       });
                   });

        public static IWebHostBuilder CreateWebHostBuilderWithStartupFilter(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                   .UseStartup<StartupFilter>();

    }
}

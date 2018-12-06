using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HostBuilderExtension
{
    public static class WebHostBuilderExtension
    {
        public static IWebHostBuilder CustomExtension(this IWebHostBuilder webHostBuilder)
        {
            return webHostBuilder.ConfigureServices(services => {
                var config = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
                var connection = config.GetConnectionString("Default");
            });
        }
        public static void CustomAction(IServiceCollection services)
        {
            var config = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
            var connection = config.GetConnectionString("Default");
        }
    }
}

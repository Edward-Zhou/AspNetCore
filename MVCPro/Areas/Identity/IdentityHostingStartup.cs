using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MVCPro.Models;

[assembly: HostingStartup(typeof(MVCPro.Areas.Identity.IdentityHostingStartup))]
namespace MVCPro.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<MVCProContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("MVCProContextConnection")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<MVCProContext>();
            });
        }
    }
}
using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RouterPro.Models;

[assembly: HostingStartup(typeof(RouterPro.Areas.Identity.IdentityHostingStartup))]
namespace RouterPro.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<RouterProContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("RouterProContextConnection")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<RouterProContext>();
            });
        }
    }
}
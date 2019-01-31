using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StaticFilePro.Models;

[assembly: HostingStartup(typeof(StaticFilePro.Areas.Identity.IdentityHostingStartup))]
namespace StaticFilePro.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<StaticFileProContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("StaticFileProContextConnection")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<StaticFileProContext>();
            });
        }
    }
}
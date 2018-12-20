using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DapperPro.Data;
using DapperPro.Models;
using DapperPro.Services;
using DapperPro.Extensions;

namespace DapperPro
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            var db = services.BuildServiceProvider().GetRequiredService<ApplicationDbContext>();
            services.AddIdentity<ApplicationUser, IdentityRole>(opt => {
                //opt.Lockout.MaxFailedAccessAttempts = db.LockoutOption.FirstOrDefault()?.MaxFailedAccessAttempts ?? 3;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            services.AddTransient<DbConnection>(serviceProvider => new DbConnection(Configuration.GetConnectionString("DefaultConnection")));
            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc();

            services.AddTransient<ISecuritySettingService, SecuritySettingService>();
            services.AddTransient<ISecuritySettingRepository, SecuritySettingRepository>();
            var _ecuritySettingService = services.BuildServiceProvider().GetRequiredService<ISecuritySettingService>();
            services.Configure<IdentityOptions>(options =>
            {
                options.Lockout.MaxFailedAccessAttempts = _ecuritySettingService.GetSecuritySetting()?.MaxFailedAccessAttempts ?? 3;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

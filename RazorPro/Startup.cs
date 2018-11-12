using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RazorPro.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;

namespace RazorPro
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddMvc()
                    .AddRazorPagesOptions(options => {
                        //options.Conventions.AddAreaPageRoute("Downloads", "/Index","");
                    }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.Configure<RazorViewEngineOptions>(options => {
                options.PageViewLocationFormats.Add("/Pages/Shared-1/{0}.cshtml");
            });

            services.AddSingleton<IPageHandlerMethodSelector, CustomDefaultPageHandlerMethodSelector>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            //app.Use(async (context, next) =>
            //{
            //    // Do work that doesn't write to the Response.
            //    if (!context.User.Identity.IsAuthenticated && context.Request.Path != "/WebUserIdentity/Account/Login")
            //    {
            //        context.Response.Redirect("/WebUserIdentity/Account/Login");
            //    }
            //    else if (context.Request.Path == "/")
            //    {
            //        context.Response.Redirect("/Downloads/Index");
            //    }
            //    await next.Invoke();
            //    // Do logging or other work that doesn't write to the Response.
            //});
            app.UseAuthentication();

            app.UseMvc();
        }
    }
}

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
using IdentityServerWithAspNetCoreIdentity.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using IdentityServerWithAspNetCoreIdentity.IdentityServer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace IdentityServerWithAspNetCoreIdentity
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
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders()
                    .AddDefaultUI();
            //services.AddIdentity<IdentityUser, IdentityRole>()
            //        .AddEntityFrameworkStores<ApplicationDbContext>()
            //        .AddDefaultTokenProviders()
            //        .AddDefaultUI();

            services.AddMvc(config => {
                //var policy = new AuthorizationPolicyBuilder()
                //         .RequireAuthenticatedUser()
                //         .Build();
                //config.Filters.Add(new AuthorizeFilter(policy));
                    })                    
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            var builder = services.AddIdentityServer(options =>
            {
                options.UserInteraction.LoginUrl = "/Identity/Account/LogIn";
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
            })
                .AddDeveloperSigningCredential()
                .AddInMemoryIdentityResources(Config.GetIdentityResources())
                .AddInMemoryApiResources(Config.GetApiResources())
                .AddInMemoryClients(Config.GetClients())
                .AddAspNetIdentity<IdentityUser>();
            //services.AddIdentityServer(opt => {
            //            opt.UserInteraction.LoginUrl = "/Identity/Account/LogIn";
            //        })
            //        .AddDeveloperSigningCredential()
            //        .AddInMemoryPersistedGrants()
            //        .AddInMemoryIdentityResources(Config.GetIdentityResources())
            //        .AddInMemoryApiResources(Config.GetApiResources())
            //        .AddInMemoryClients(Config.GetClients())
            //        .AddAspNetIdentity<IdentityUser>();

            services.AddAuthentication(config => {
                config.DefaultScheme = IdentityConstants.ApplicationScheme;
                config.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
                config.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
            })
                    .AddMicrosoftAccount(microsoftOptions =>
                    {
                        microsoftOptions.ClientId = "c73f9fe1-72df-43e7-a291-d9c3620c8667";
                        microsoftOptions.ClientSecret = "yeuboKYNMN52~?|unGO853=";
                    });
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
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            //app.UseAuthentication();
            app.UseIdentityServer();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

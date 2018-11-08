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
using RazorPageIdentity.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authorization;
using RazorPageIdentity.Models;
using RazorPageIdentity.Extensions;
using RazorPageIdentity.Custom;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection.Extensions;
using RazorPageIdentity.Requirements;

namespace RazorPageIdentity
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
            services.AddDefaultIdentity<IdentityUser>(options =>
                {
                    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+'#!/^%{}*";
                })
                .AddRoles<IdentityRole>()
                .AddRoleManager<RoleManager<IdentityRole>>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            var descriptor =
                new ServiceDescriptor(
                    typeof(CookieAuthenticationHandler),
                    typeof(CustomCookieAuthenticationHandler),
                    ServiceLifetime.Transient);
            services.Replace(descriptor);
            services.ConfigureApplicationCookie(options => {
                options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
            });
        //    services.AddAuthentication(options =>
        //    {
        //        options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
        //        options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
        //        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
        //    })
        //.AddScheme<CookieAuthenticationOptions, CustomCookieAuthenticationHandler>(
        //        CookieAuthenticationDefaults.AuthenticationScheme,
        //        null,
        //        null
        //        );
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Read", policy => policy.AddRequirements(new ReadPermission()));
                //var dbContext = SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder<ApplicationDbContext>(),
                //            Configuration.GetConnectionString("DefaultConnection")).Options;

                //var dbCon = new ApplicationDbContext(dbContext);
                ////Getting the list of application claims.
                //var applicationClaims = dbCon.ApplicationClaims.ToList();
                //var strClaimValues = string.Empty;
                //List<ApplicationClaims> lstClaimTypeVM = new List<ApplicationClaims>();
                //IEnumerable<string> lstClaimValueVM = null;// new IEnumerable<string>();

                //lstClaimTypeVM = (from dbAppClaim
                //              in dbCon.ApplicationClaims
                //                  select new ApplicationClaims
                //                  {
                //                      ClaimType = dbAppClaim.ClaimType
                //                  }).Distinct().ToList();

                //foreach (ApplicationClaims objClaimType in lstClaimTypeVM)
                //{
                //    lstClaimValueVM = (from dbClaimValues in dbCon.ApplicationClaims
                //                       where dbClaimValues.ClaimType == objClaimType.ClaimType
                //                       select dbClaimValues.ClaimValue).ToList();

                //    options.AddPolicy(objClaimType.ClaimType, policy => policy.RequireClaim(objClaimType.ClaimType, lstClaimValueVM));
                //    lstClaimValueVM = null;
                //}
            });
            services.AddSingleton<IAuthorizationHandler, PermissionHandler>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddTransient<CustomClaimsCookieSignInHelper<IdentityUser>>();
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

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areaRoute",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

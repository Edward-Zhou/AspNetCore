using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MVCPro.ActionFilters;
using MVCPro.Models;
using MVCPro.Services;
using Newtonsoft.Json;

namespace MVCPro
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

            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddSingleton<IUserResolverService, UserResolverService>();
            //services.AddScoped<TokenAuthorizeFilter>();
            services.AddSingleton<IAuthorizationPolicyProvider, LEMClaimPolicyProvider>();
            services.AddSingleton<IAuthorizationHandler, LEMClaimPolicyHandler>();
            //services.AddScoped<RequestLoggerActionFilter>();
            //services.AddTransient((serviceProvider)=> new Claim { Type = "T1", Value = "V1" });
            services.AddMvc(c =>
                            {
                                //c.Filters.Add(typeof(RequestLoggerActionFilter));
                                //c.Filters.Add(typeof(ClaimRequirementFilter));
                                //c.Filters.Add(new ClaimRequirementFilter(new Claim { Type = "T1", Value = "V1" }));
                            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseCookiePolicy();
            app.Map("/tenants", map => {
                map.Run(async context => {
                    var dbContext = context.RequestServices.GetRequiredService<MVCProContext>();
                    var tenants = await dbContext.Users.ToListAsync();
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(tenants));
                });
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MVCPro.ActionFilters;
using MVCPro.Extensions;
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
            services.AddResponseCaching(options => {
                //options.
            });
            services.AddMvc(c =>
                            {
                                c.CacheProfiles.Add("Never",
                                        new CacheProfile()
                                        {
                                            Location = ResponseCacheLocation.None,
                                            NoStore = true
                                        });
                                //c.Filters.Add(typeof(RequestLoggerActionFilter));
                                //c.Filters.Add(typeof(ClaimRequirementFilter));
                                //c.Filters.Add(new ClaimRequirementFilter(new Claim { Type = "T1", Value = "V1" }));
                            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSingleton<IExceptionService, ExceptionService>();
            services.AddSingleton<IConfigureOptions<MvcOptions>, ConfigureMvcOptions>();

            services.AddScoped(typeof(EnumFilter<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseExceptionHandler(builder =>
                //{
                //    builder.Run(async context =>
                //    {
                //        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                //        var error = context.Features.Get<IExceptionHandlerFeature>();
                //        var error1 = context.Features.Get<IExceptionHandlerFeature>() as ExceptionHandlerFeature;
                //        var error2 = context.Features.Get<IExceptionHandlerPathFeature>();
                //        var requestPath = error2.Path;
                //        if (error != null)
                //        {
                //            context.Response.ShowApplicationError(error.Error.Message, error.Error.InnerException.Message);
                //        }
                //    });
                //});
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.Use(async (context, next) => {
                var requestPath = context.Request.Path.Value;
                var cookies = context.Request.Cookies;
                if (!requestPath.StartsWith("/Home/About"))
                {
                    await next.Invoke();
                }
                else
                {
                    await context.Response.WriteAsync("Forbidden");
                }
            });

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
            app.UseResponseCaching();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

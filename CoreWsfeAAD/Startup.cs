using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.WsFederation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoreWsfeAAD
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

            services.AddAuthentication(sharedOptions =>
                    {
                        sharedOptions.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                        sharedOptions.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                        sharedOptions.DefaultChallengeScheme = WsFederationDefaults.AuthenticationScheme;
                    })
                    .AddWsFederation(options =>
                    {
                        // MetadataAddress represents the Active Directory instance used to authenticate users.
                        options.MetadataAddress = "https://login.microsoftonline.com/1ea1a051-c474-4e62-b6ad-e13daa7c67c1/federationmetadata/2007-06/federationmetadata.xml";

                        // Wtrealm is the app's identifier in the Active Directory instance.
                        // For ADFS, use the relying party's identifier, its WS-Federation Passive protocol URL:
                        //options.Wtrealm = "https://localhost:44307/";

                        // For AAD, use the App ID URI from the app registration's Properties blade:
                        options.Wtrealm = "https://taozhou.onmicrosoft.com/a231f030-43f0-4aac-8c3d-051b9219e44e";

                        //options.SaveTokens = true;
                        //options.Events.OnTicketReceived = context =>
                        //{
                        //    //var token = context.Properties.
                        //    return Task.CompletedTask;
                        //};
                        //options.Events.OnRedirectToIdentityProvider = context =>
                        //{
                        //    return Task.CompletedTask;
                        //};
                        options.Events.OnSecurityTokenValidated = context => {
                            var token = context.ProtocolMessage.GetToken();
                            var identity = new ClaimsIdentity();
                            identity.AddClaim(new Claim("token", token));
                            context.Principal.AddIdentity(identity);
                            return Task.CompletedTask;
                        };
                        options.TokenValidationParameters.SaveSigninToken = true;
                    })
                    .AddCookie();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using RouterPro.Routers;

namespace RouterPro
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

            services.TryAddTransient<MvcAttributeRouteHandler, SubDomainRouteHandler>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            var descriptor =
                            new ServiceDescriptor(
                                typeof(MvcAttributeRouteHandler),
                                typeof(SubDomainRouteHandler),
                                ServiceLifetime.Transient);
            services.Replace(descriptor);
            //var serviceDescriptor = services.First(s => s.ServiceType == typeof(MvcAttributeRouteHandler));
            //services.Remove(serviceDescriptor);
            //services.TryAddTransient<SubDomainRouteHandler>(); // Many per app

            //services.Remove(ServiceDescriptor.Transient<IServiceCollection,MvcAttributeRouteHandler>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
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

            app.UseMvc(routes =>
            {
                //routes.Routes.Insert(0, new RouterFromAppSettings(routes.DefaultHandler,Configuration));
                //routes.Routes.Insert(0, new SubDomainRouteHandler(serviceProvider.GetRequiredService<MvcAttributeRouteHandler>()));
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

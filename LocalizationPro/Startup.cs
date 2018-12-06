using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using LocalizationPro.Resources;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace LocalizationPro
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
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            //services.Configure<CookiePolicyOptions>(options =>
            //{
            //    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
            //    options.CheckConsentNeeded = context => true;
            //    options.MinimumSameSitePolicy = SameSiteMode.None;
            //});


            services.AddMvc()
                    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                    //.SetCompatibilityVersion(CompatibilityVersion.Version_2_0)
                    .AddDataAnnotationsLocalization();
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                       new CultureInfo("it-IT"),
                       new CultureInfo("en")
                };

                options.DefaultRequestCulture = new RequestCulture("it-IT");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
                options.RequestCultureProviders = new List<IRequestCultureProvider>
                {
                       new QueryStringRequestCultureProvider(),
                       new CookieRequestCultureProvider()
                };
            });
            //for configure culture dropdown lists, we need to confgiure RequestLocalizationOptions
            //services.Configure<RequestLocalizationOptions>(options =>
            //{
            //    var supportedCultures = new[]
            //    {
            //        new CultureInfo("en-US"),
            //        new CultureInfo("fr"),
            //        new CultureInfo("ar-YE")
            //    };

            //    // State what the default culture for your application is. This will be used if no specific culture
            //    // can be determined for a given request.
            //    options.DefaultRequestCulture = new RequestCulture(culture: "en-US", uiCulture: "en-US");

            //    // You must explicitly state which cultures your application supports.
            //    // These are the cultures the app supports for formatting numbers, dates, etc.
            //    options.SupportedCultures = supportedCultures;

            //    // These are the cultures the app supports for UI strings, i.e. we have localized resources for.
            //    options.SupportedUICultures = supportedCultures;
            //});
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

            var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(locOptions.Value);
            app.UseRequestLocalization();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MiddlewarePro.MiddlewareFactoies;
using MiddlewarePro.Middlewares;
using MiddlewarePro.Services;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewarePro
{
    public class StartupSimpleInjector
    {
        private Container _container = new Container();
        public void ConfigureServices(IServiceCollection services)
        {
            //replace the default middleware factory with SimpleInjectorMiddlewareFactory
            services.AddTransient<IMiddlewareFactory>(_ =>{
                return new SimpleInjectorMiddlewareFactory(_container);
            });

            //Wrap requests in a simple injector execution context
            services.UseSimpleInjectorAspNetRequestScoping(_container);

            // Provide the scoped service from the Simple 
            // Injector container whenever it's requested from 
            // the default service container.
            services.AddScoped<IScopedService>(provider =>
                _container.GetInstance<IScopedService>());

            _container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            _container.Register<IScopedService>(() =>
            {
                return new ScopedService();
            }, Lifestyle.Scoped);

            _container.Register<SimpleInjectorMiddleware>();

            _container.Verify();
        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseSimpleInjectorMiddleware();
            app.Run(async context => {
                await context.Response.WriteAsync($"This is End");
            });
        }
    }
}

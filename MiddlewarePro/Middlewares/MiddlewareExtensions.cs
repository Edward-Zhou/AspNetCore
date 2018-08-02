using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewarePro.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseConventionalMiddleware(
            this IApplicationBuilder app)
        {
            return app.UseMiddleware<ConventionalMiddleware>();
        }

        public static IApplicationBuilder UseFactoryBasedMiddleware(
            this IApplicationBuilder app)
        {
            // Passing 'option' as an argument throws a NotSupportedException at runtime.
            return app.UseMiddleware<FactoryBasedMiddleware>();
        }

        public static IApplicationBuilder UseMiddlewareDependency(
            this IApplicationBuilder app)
        {
            return app.UseMiddleware<MiddlewareDependency>();
        }

    }
}

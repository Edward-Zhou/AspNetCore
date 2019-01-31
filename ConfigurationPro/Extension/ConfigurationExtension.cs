using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigurationPro.Extension
{
    public static class ConfigurationExtension
    {
        public static IServiceCollection AddEsi(this IServiceCollection services, IConfigurationSection section)
        {
            services.Configure<EsiConfig>(section);
            return services;
        }
    }
}

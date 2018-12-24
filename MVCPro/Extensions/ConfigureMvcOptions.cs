using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MVCPro.ActionFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPro.Extensions
{
    public class ConfigureMvcOptions : IConfigureOptions<MvcOptions>
    {
        private readonly IExceptionService exceptionService;

        public ConfigureMvcOptions(IExceptionService exceptionService)
        {
            this.exceptionService = exceptionService;
        }

        public void Configure(MvcOptions options)
        {
            options.Filters.Add(new ApiExceptionFilterAttribute(exceptionService));
        }
    }
}

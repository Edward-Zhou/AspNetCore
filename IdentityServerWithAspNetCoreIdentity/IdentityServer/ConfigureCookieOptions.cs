using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerWithAspNetCoreIdentity.IdentityServer
{
    internal class ConfigureCookieOptions : IConfigureNamedOptions<CookieAuthenticationOptions>
    {
        public ConfigureCookieOptions() { }
        public void Configure(CookieAuthenticationOptions options) { }
        public void Configure(string name, CookieAuthenticationOptions options)
        {
            options.LoginPath = "/Identity/Account/LogIn";
            options.AccessDeniedPath = "/Identity/Account/LogIn";
            //Any other options you want to set/override
        }
    }
}

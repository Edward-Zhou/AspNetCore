using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace RazorPageIdentity.Custom
{
    public class CustomCookieAuthenticationHandler : CookieAuthenticationHandler
    {
        public CustomCookieAuthenticationHandler(IOptionsMonitor<CookieAuthenticationOptions> options
            , ILoggerFactory logger
            , UrlEncoder encoder
            , ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }
        protected override Task HandleChallengeAsync(AuthenticationProperties properties)
        {
            return base.HandleChallengeAsync(properties);
        }
        protected override Task HandleSignInAsync(ClaimsPrincipal user, AuthenticationProperties properties)
        {
            if (user.Identity.Name == "test@outlook.com")
            {
                properties.ExpiresUtc = Clock.UtcNow.AddMinutes(15);
            }
            else
            {
                properties.ExpiresUtc = Clock.UtcNow.AddMinutes(35);
            }
            return base.HandleSignInAsync(user, properties);
        }
    }
}

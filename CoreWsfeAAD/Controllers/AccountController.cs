using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.WsFederation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CoreWsfeAAD.Controllers
{
    public class AccountController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return RedirectToAction("UserClaims");
        }
        public IActionResult SignOut()
        {
            foreach (var key in this.HttpContext.Request.Cookies.Keys)
            {
                this.HttpContext.Response.Cookies.Delete(key);
            }

            return base.SignOut(
                 new Microsoft.AspNetCore.Authentication.AuthenticationProperties
                 {
                     RedirectUri = "https://localhost:44392/Account/UserClaims"
                 },
                 CookieAuthenticationDefaults.AuthenticationScheme,
                 WsFederationDefaults.AuthenticationScheme);
        }
        public IActionResult UserClaims()
        {
            return Ok(User.Claims.ToList());
        }
    }
}
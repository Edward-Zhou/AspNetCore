using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IdentityRoleClaims.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace IdentityRoleClaims.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public HomeController(UserManager<IdentityUser> userManager
            , RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Prepare()
        {            
            var userRole = await _roleManager.CreateAsync(new IdentityRole("User"));
            var role = await _roleManager.FindByNameAsync("User");
            var roleClaims = await _roleManager.AddClaimAsync(role, new Claim("area", "public1"));
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var roleToUser = await _userManager.AddToRoleAsync(user, "User");
            return Ok("ok");
        }
        //[Authorize(Roles = "")]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var roles = await _userManager.GetRolesAsync(user);
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roleClaims = new List<Claim>();
            foreach (var roleName in roles)
            {
                var role = await _roleManager.FindByNameAsync(roleName);
                var claims = await _roleManager.GetClaimsAsync(role);
                roleClaims.AddRange(claims);
            }
            var claims1 = User.Claims.ToList();
            return View();
        }

        public IActionResult About()
        {
            

            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

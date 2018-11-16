using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CoreJwt.Controllers
{
    [Route("api/auth")]
    public class AuthController : Controller
    {
        // GET api/values
        [HttpPost, Route("login")]
        public IActionResult Login()
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("iNivDmHLpUA223sqsfhqGbMRdRj1PVkH"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokeOptions = new JwtSecurityToken(
                issuer: "Issuer",
                audience: "Audience",
                claims: new List<Claim>() { new Claim("rol", "api_access") },
                expires: DateTime.Now.AddMinutes(25),
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return Ok(new { Token = tokenString });
        }
    }
}
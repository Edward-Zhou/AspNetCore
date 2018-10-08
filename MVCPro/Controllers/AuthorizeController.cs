using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCPro.ActionFilters;

namespace MVCPro.Controllers
{
    public class AuthorizeController : Controller
    {
        [ServiceFilter(typeof(TokenAuthorizeFilter))]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
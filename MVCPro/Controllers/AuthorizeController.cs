using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCPro.ActionFilters;

namespace MVCPro.Controllers
{
    [KeyAuthorize]
    public class AuthorizeController : Controller
    {
        [ServiceFilter(typeof(TokenAuthorizeFilter))]
        public IActionResult Index()
        {
            return Ok();
        }
        [HttpPost]
        public IActionResult KeyBody(RequestBase requestBase)
        {
            return Ok(requestBase.ApiKey);
        }
    }
    public class RequestBase
    {
        public string ApiKey { get; set; }
    }
}
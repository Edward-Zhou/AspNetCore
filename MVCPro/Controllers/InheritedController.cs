using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCPro.ActionFilters;

namespace MVCPro.Controllers
{
    public class InheritedController : BaseController
    {
        [AdminOrBranchesAccess]
        [HttpGet]
        public async Task<IActionResult> AdminOrBranchesAccess()
        {
            return Ok("AdminOrBranchesAccess");
        }
    }
}
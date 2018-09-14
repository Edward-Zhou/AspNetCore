using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RouterPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubDomainController : ControllerBase
    {
        [Route("SubDomain/{id}")]
        public async Task<IActionResult> SubDomain(string SubDomain, int id)
        {
            return Ok(SubDomain);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidationPro.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidationPro.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class CommandController : ControllerBase
    {
        [HttpPost("[action]")]
        public IActionResult Create(Command command)
        {
            if (ModelState.IsValid)
            {

            }
            return Ok();
        }
    }
}

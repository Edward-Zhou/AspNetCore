using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationTestMVC.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("test")]
        public ObjectResult Get()
        {
            return Ok("data");
        }

        [HttpPost("AddFile")]
        public async Task<IActionResult> AddFile(IFormFile file)
        {
            if (file == null)
            {
                return StatusCode(400, "A file must be supplied");
            }

            // ... code that does stuff with the file..

            return CreatedAtAction("downloadFile", new { });
        }
    }
}
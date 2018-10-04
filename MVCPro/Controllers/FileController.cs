using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MVCPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        [HttpPost("images")]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            return Ok("Work");
        }
        [HttpPost("ImportImage")]
        public async Task<IActionResult> ImportImage(IFormFile file, [FromForm]string folderName)
        {
            return Ok("Work");
        }
    }
}
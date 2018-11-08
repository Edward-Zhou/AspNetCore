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
        [HttpPost("[action]")]
        public IActionResult DocumentPage([FromForm]test _test)
        {
            return Ok("Work");
        }
    }
    public class test
    {
        public testArea MyIFormFile { get; set; } = new testArea();
        public string Name { get; set; }
        public class testArea
        {
            public string Name { get; set; }
            [FromForm]
            public List<IFormFile> ResolutionAttachedFile { get; set; } = new List<IFormFile>();
        }
    }
    public class Test
    {
        public TestArea MyIFormFile { get; set; }
        public string Name { get; set; }
    }
    public class TestArea
    {
        public string Name { get; set; }

        public List<IFormFile> ResolutionAttachedFile { get; set; } = new List<IFormFile>();
    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelBindingPro.Models;

namespace ModelBindingPro.Controllers
{
    [Produces("application/json")]
    [Route("api/Binder")]
    public class BinderController : Controller
    {
        [HttpPost("[action]")]
        public IActionResult DocumentPage(test _test)
        {
            return Ok("value");
        }
        // GET: api/Binder
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Binder/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        [HttpPost]
        [Route("[action]")]
        public JsonResult Save([FromBody]List<Document> entries, [FromBody]int projectId)
        {
            // code here
            return Json(new { entries = new List<Document>{ new Document { FileId = "F1" } } , projectId });
        }
        [HttpPost]
        [Route("[action]")]
        public JsonResult SaveBinder(List<Document> entries, int projectId)
        {
            // code here
            return Json("OK");
        }
        // POST: api/Binder
        [HttpPost]
        public void Post([FromForm]BinderModel value)
        {

        }
        [HttpPost]
        [Route("UploadDoc")]
        public async Task<IActionResult> DocumentUpload([FromForm] IList<Document> document)
        {
            return Ok();
        }
        [HttpPost]
        [Route("[action]")]
        public void FormSubProperty(Order order)
        {

        }
        // PUT: api/Binder/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class test
    {
        public testArea MyIFormFile { get; set; }
        public class testArea
        {
            public List<IFormFile> ResolutionAttachedFile { get; set; }
        }
    }
}

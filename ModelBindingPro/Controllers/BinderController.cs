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
        
        // POST: api/Binder
        [HttpPost]
        public void Post([FromForm]BinderModel value)
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
}

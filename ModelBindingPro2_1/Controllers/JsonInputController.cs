using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ModelBindingPro2_1.Controllers
{
    [Produces("application/json")]
    [Route("api/JsonInput")]
    public class JsonInputController : Controller
    {
        [HttpPost]
        public async Task<ActionResult> Post(string base64Data)
        {
            var base64 = Request.Form["base64Data"];
            return Ok();
        }
    }
}
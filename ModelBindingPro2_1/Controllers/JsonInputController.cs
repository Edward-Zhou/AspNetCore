using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelBindingPro2_1.Models;

namespace ModelBindingPro2_1.Controllers
{
    [Produces("application/json")]
    [Route("api/JsonInput")]
    [ApiController]
    public class JsonInputController : Controller
    {
        [HttpPost]
        public async Task<ActionResult> Post(string base64Data)
        {
            var base64 = Request.Form["base64Data"];
            return Ok();
        }
        [HttpPost("PostWithInValidate")]
        public async Task<IActionResult> PostWithInValidate([FromBody]InValidateVM vM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(vM);
        }
        [HttpPost("[action]")]
        public IActionResult Save([FromBody]string model)
        {
            return Challenge();
            return Json(true);
        }
    }
}
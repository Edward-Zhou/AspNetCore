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
    [Route("api/JsonInput")]
    public class JsonInputController : Controller
    {
        [HttpPut]
        public async Task PutAsync([FromBody] JsonInputModel model)
        {

        }
    }
}
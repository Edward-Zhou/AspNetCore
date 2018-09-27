using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Serilog;

namespace SerilogPro.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class SerilogController : Controller
    {
        private readonly ILogger<SerilogController> _log;
        public SerilogController(ILogger<SerilogController> log)
        {
            _log = log;
        }
        [HttpGet]
        public IEnumerable<string> Get(string password)
        {

            Log.Logger.Information("Hello, world!");
            _log.LogInformation(JsonConvert.SerializeObject(new string[] { "value1", "value2" }));
            return new string[] { "value1", "value2" };
        }
    }
}
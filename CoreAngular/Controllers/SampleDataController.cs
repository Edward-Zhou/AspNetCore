using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using CoreAngular.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CoreAngular.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        [HttpPost("Active")]
        public async Task<ActionResult> ActiveAccount([FromBody]User model)
        {
            return Ok(model);
        }
        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }
        [HttpPatch("UpdateModelWithJsonPatch/{id}")]
        public async Task<IActionResult> UpdateModelWithJsonPatch(Guid id, [FromBody]JsonPatchDocument<TestModel> modelDocument)
        {
            return Ok();
        }
        [HttpPatch("UpdateModelWithOutJsonPatch/{id}")]
        public async Task<IActionResult> UpdateModelWithOutJsonPatch(Guid id, [FromBody]TestModel modelDocument)
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Authenticate")]
        public IActionResult Authenticate([FromBody]LoginUser userParam)
        {
            return Ok(userParam);
        }
        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
        [HttpGet("{id:int}/{*subDirectotry}")]
        [ResponseCache(NoStore = true)]
        public async Task<IActionResult> Get(int id, string subDirectotry)
        {
            return Ok();
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("ListArtists")]
        public JsonResult ListArtists()
        {
            var artists = new List<Artist> {
                new Artist{ id = 1, fake = new FakeData{ id = 11, name = "F1" } },
                new Artist{ id = 2, fake = new FakeData{ id = 22, name = "F2" } }
            };
            return Json(new { results = artists });
        }
        [HttpPut("[Action]/{id}")]
        public async Task<ActionResult> LinkItemToIcon(int id, IFormFile file)
        {
            return Ok();
        }
        //[HttpGet("[action]")]
        //public IActionResult GetItems([FromQuery]FilterPagination filterPagination)
        //{
        //    var request = HttpContext.Request.Query;
        //    // ... get items from db with specified filter and pagination
        //    return Ok();
        //}

        [HttpGet("[action]")]
        public IActionResult GetItems([ModelBinder(typeof(NestedModelBinder<Filter>))]Filter filter, [ModelBinder(typeof(NestedModelBinder<Pagination>))]Pagination pagination)
        {
            var request = HttpContext.Request.Query;
            // ... get items from db with specified filter and pagination
            return Ok();
        }
        public class Artist
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int id { get; set; }
            public FakeData fake { get; set; }
        }

        public class FakeData
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int id { get; set; }
            public string name { get; set; }
        }


        public class TestModel
        {
            public string Title { get; set; }
            public string Comment { get; set; }
            public bool Qualified { get; set; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace IntegrationTestMVC.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        //private readonly ILogger _logger;
        private readonly IConfiguration _configuration;
        private IHttpClientFactory _httpClientFactory;

        public BookController(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            //_logger = logger;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }


        [HttpPost]
        public async Task<ActionResult> Post()
        {
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                string body = reader.ReadToEnd();

                var url = "http://localhost/api/v1/Author/";
                using (var content = new StringContent(body, Encoding.UTF8, "application/json"))
                {
                    var _httpClient = _httpClientFactory.CreateClient();
                    //var s = _httpClient.GetAsync("http://google.com").Result;  //works here

                    var response = await _httpClient.PostAsync(url, content);   //internal server error
                    var statusCode = response.StatusCode;
                    return StatusCode((int)statusCode);
                }

            }
        }

    }
}
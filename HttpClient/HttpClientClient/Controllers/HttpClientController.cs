using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HttpClientClient.HttpClients;
using HttpClientClient.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HttpClientClient.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HttpClientController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly ISomeClient _someClient;
        public HttpClientController(HttpClient httpClient
            , ISomeClient someClient)
        {
            _httpClient = httpClient;
            _someClient = someClient;
        }

        public async Task CallWebApi()
        {
            string url = @"https://localhost:44342/api/message/post";
            var model = new MessageVM {
                Id = 1,
                Name = "Test"
            };
            var response = await _httpClient.PostAsJsonAsync(url, model);
            var result = await response.Content.ReadAsStringAsync();
        }
    }
}
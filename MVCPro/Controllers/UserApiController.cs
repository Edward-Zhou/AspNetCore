using Microsoft.AspNetCore.Mvc;
using MVCPro.CustomResult;
using MVCPro.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MVCPro.Controllers
{
    [Route("api/User")]
    public class UserApiController : MyControllerBase
    {
        [HttpGet("[action]")]
        public async Task TaskAction()
        {
            await Task.CompletedTask;
        }
        [HttpGet("[action]")]
        public void VoidAction()
        {
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Error()
        {
            throw new Exception("Error From MVC");
        }
        [HttpPost("/someApiAction/{id}")]
        public async Task<IActionResult> SomeApiAction(string id)
        {
            return RedirectToAction("Contact", "Home", new { id = id });
        }
        [HttpGet]
        [Route("Teacher",Name = "Teacher")]
        public async Task<IEnumerable<string>> GetTeachers()
        {
            return null;
        }

        //[HttpGet("{page}/{itemsPerPage}", Name = "GetBookWithPagination")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public async Task<ActionResult> Get(int page, int itemsPerPage, string filter)
        {
            try
            {
                return null;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}/status")]
        [ProducesResponseType(200, Type = typeof(DeviceStatus))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetStatus(Guid id)
        {
            // gets the device status
            return Ok(new DeviceStatus { DeviceId = id });
        }

        [HttpPost("{id}/status/rawdata")]
        [ProducesResponseType(201, Type = typeof(DeviceStatus))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> CreateStatusFromRawData(Guid id, [FromBody]byte[] rawdata)
        {
            // some parsing logic
            return CreatedAtAction(nameof(GetStatus), new { id });
        }
        [HttpPut("{id}/status/rawdata")]
        [ProducesResponseType(200, Type = typeof(DeviceStatus))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateStatusFromRawData(Guid id, [FromBody]byte[] rawdata)
        {
            // some parsing logic
            return UpdatedAtAction(nameof(GetStatus), new { id });
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MyDTO newDTO)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }
            return Ok();
        }
        [HttpGet]
        public IActionResult Setup([FromHeader] string uuid)
        {
            InitialiseStuff(uuid); //This takes several seconds to execute
            return StatusCode(200);
        }
        public Task InitialiseStuff(string uuid)
        {
            Task.Factory.StartNew(() => {
                Thread.Sleep(TimeSpan.FromSeconds(10));
                Debug.WriteLine(uuid);
            });
            return Task.CompletedTask;
        }
        [HttpPost("InserUsers")]
        public async Task<List<ApiResponseMessage>> InserUsers()
        {
            List<User> users = new List<User> {
                new User{ Name = "Jack" },
                new User{ Name = "Tom"},
                new User{ Name = "Tony"}
            };
            List<ApiResponseMessage> list = new List<ApiResponseMessage>();
            foreach (var user in users)
            {
                var response = Insert(user);
                list.Add(new ApiResponseMessage
                {

                    Content = new { user },
                    ReasonPhrase = response.ReasonPhrase,
                    StatusCode = response.StatusCode
                });

            }
            return list;
        }

        public ApiResponseMessage Insert(User user)
        {
            // do insert and if there is error
            if (user.Name == "Tom")
            {
                return new ApiResponseMessage()
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ReasonPhrase = $"Error"
                };
            }
            else
            {
                return new ApiResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    ReasonPhrase = $"Successfully inserted"
                };
            }
        }
    }
}

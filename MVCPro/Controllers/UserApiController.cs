using Microsoft.AspNetCore.Mvc;
using MVCPro.CustomResult;
using MVCPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPro.Controllers
{
    [Route("api/User")]
    public class UserApiController : MyControllerBase
    {
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
    }
}

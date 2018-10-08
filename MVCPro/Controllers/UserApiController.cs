using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPro.Controllers
{
    [Route("api/User")]
    public class UserApiController : Controller
    {
        [HttpGet]
        [Route("Teacher",Name = "Teacher")]
        public async Task<IEnumerable<string>> GetTeachers()
        {
            return null;
        }
    }
}

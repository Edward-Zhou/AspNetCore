using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPro.Controllers
{
    public class BaseController : Controller
    {
        public int? BranchId { get => HttpContext.Session.GetInt32("BranchId") as int?; }
        public string Admin { get => HttpContext.Session.GetString("Admin") as string; }

        public BaseController() { }
    }
}

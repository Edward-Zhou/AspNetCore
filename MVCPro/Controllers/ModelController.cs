using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCPro.Models;

namespace MVCPro.Controllers
{
    public class ModelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Details(int? id)
        {
            var model = new MVCModel { NoInvoAb = 2 };
            return View(model);
        }
        [HttpGet]
        public async Task<ActionResult> Update()
        {
            return View(new MVCModel { NoInvoAb = 5 ,CreationDate = DateTime.Now });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(MVCModel viewModel)
        {
            return View(viewModel);
        }
    }
}
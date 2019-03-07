using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LocalizationPro.Models;
using Microsoft.Extensions.Localization;

namespace LocalizationPro.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStringLocalizer<HomeController> _localizer;
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;
        public HomeController(IStringLocalizer<HomeController> localizer
            , IStringLocalizer<SharedResource> sharedLocalizer)
        {
            _localizer = localizer;
            _sharedLocalizer = sharedLocalizer;
        }
        public IActionResult Index()
        {
            ViewData["Title"] = _localizer["Title"];//"Your application description page.";
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Model()
        {
            var result = _localizer["example@outlook.com"];
            return View();
        }
        public IActionResult CreateModel()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateModel(LocalizationVM vM)
        {
            var l = _sharedLocalizer["Requiredbb"];
            if (!ModelState.IsValid)
            {
                return View("Model");
            }
            var result = _localizer["example@outlook.com"];
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

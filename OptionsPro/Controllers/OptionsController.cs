using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using OptionsPro.Models;

namespace OptionsPro.Controllers
{
    public class OptionsController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly Locations _locations;
        public OptionsController(IConfiguration configuration
            , IOptions<Locations> options)
        {
            _configuration = configuration;
            _locations = options.Value;
        }
        public IActionResult Index()
        {
            var locations = new Locations();
            _configuration.GetSection("Locations").Bind(locations);

            var items = locations.location.AsEnumerable();
            var items2 = _locations;
            return View();
        }
    }
}
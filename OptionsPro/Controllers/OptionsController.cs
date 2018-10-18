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
        private IOptions<JwtOptions> _jwtOptions;
        private readonly Shared _shared;
        public OptionsController(IConfiguration configuration
            , IOptions<Locations> options
            , IOptions<JwtOptions> jwtOptions
            , IOptions<Shared> shared)
        {
            _configuration = configuration;
            _locations = options.Value;
            _jwtOptions = jwtOptions;
            _shared = shared.Value;
        }
        public IActionResult Index()
        {
            //var testSetting = _jwtOptions.Value.Issuer;

            //var locations = new Locations();
            //_configuration.GetSection("Locations").Bind(locations);

            //var items = locations.location.AsEnumerable();
            //var items2 = _locations;
            //return View();
            return Ok(_shared.Value);
        }
    }
}
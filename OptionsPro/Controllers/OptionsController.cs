using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using OptionsPro.Extensions;
using OptionsPro.Models;

namespace OptionsPro.Controllers
{
    public class OptionsController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly Locations _locations;
        private IOptions<JwtOptions> _jwtOptions;
        private readonly Shared _shared;
        private readonly IOptionsMonitor<Locations> _locationsMonitor;
        private readonly IWritableOptions<Locations> _writableLocations;
        public OptionsController(IConfiguration configuration
            , IOptions<Locations> options
            , IOptions<JwtOptions> jwtOptions
            , IOptions<Shared> shared
            , IOptionsMonitor<Locations> locationsMonitor
            , IWritableOptions<Locations> writableLocations)
        {
            _configuration = configuration;
            _locations = options.Value;
            _jwtOptions = jwtOptions;
            _shared = shared.Value;
            _locationsMonitor = locationsMonitor;
            _writableLocations = writableLocations;
        }
        public IActionResult Index()
        {
            //var testSetting = _jwtOptions.Value.Issuer;

            //var locations = new Locations();
            //_configuration.GetSection("Locations").Bind(locations);

            //var items = locations.location.AsEnumerable();
            //var items2 = _locations;
            //return View();
            return Ok(_locationsMonitor.CurrentValue);
        }
        public IActionResult Change(string value)
        {
            //_locationsMonitor.CurrentValue.Name = value;
            //_configuration["Greeting"] = value;
            _writableLocations.Update(opt => {
                opt.Name = value;
            });
            return Ok(_locationsMonitor.CurrentValue.Name);
        }
    }
}
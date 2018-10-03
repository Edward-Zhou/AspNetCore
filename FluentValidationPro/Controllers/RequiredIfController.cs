using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidationPro.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidationPro.Controllers
{
    public class RequiredIfController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(RequiredIfViewModel vm)
        {
            if (ModelState.IsValid)
            {

            }
            return Ok();
        }

    }
}
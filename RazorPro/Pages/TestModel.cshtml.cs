using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPro.Pages
{
    public class TestModelModel : PageModel
    {
        public void OnGet()
        {

        }

        //public IActionResult OnGetModal()
        //{
        //    return new JsonResult("OnGetModal");
        //}

        //// For Edit Mode

        //public IActionResult OnGetModal(int squid)
        //{
        //    return new JsonResult("OnGetModalWithSquId");
        //}
        //Method 1:

        public IActionResult OnGetModal(int? squid)
        {
            return new JsonResult("OnGetModalWithSquId");
        }

        //Method 2:

        public IActionResult OnPostActivateDeactivate(int squid, bool isActive)
        {
            return new JsonResult("OnPostActivateDeactivate");
        }
    }
}
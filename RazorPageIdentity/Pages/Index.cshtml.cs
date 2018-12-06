using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPageIdentity.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            var claims = User.Claims.ToList();

        }
    }
}

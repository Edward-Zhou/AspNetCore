using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPro.Data;
using RazorPro.Model;

namespace RazorPro.Pages.Person
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPro.Data.ApplicationDbContext _context;

        public DetailsModel(RazorPro.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Model.Person Person { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Person = await _context.Person.FirstOrDefaultAsync(m => m.Id == id);

            if (Person == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

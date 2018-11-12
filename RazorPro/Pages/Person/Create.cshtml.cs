using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPro.Data;
using RazorPro.Model;

namespace RazorPro.Pages.Person
{
    public class CreateModel : PageModel
    {
        private readonly RazorPro.Data.ApplicationDbContext _context;

        public CreateModel(RazorPro.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }
        [BindProperty]
        public string Description { get; set; }
        [BindProperty]
        public Model.Person Person { get; set; }

        public IActionResult OnGetSubGroups(int subId)
        {            
            return new JsonResult(subId);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Person.Add(Person);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}
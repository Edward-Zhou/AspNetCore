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
    public class IndexModel : PageModel
    {
        private readonly RazorPro.Data.ApplicationDbContext _context;

        public IndexModel(RazorPro.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Model.Person> Person { get;set; }

        public async Task OnGetAsync(int? personId)
        {
            Person = await _context.Person.ToListAsync();
            //RouteData.Values.Remove("personId");
        }
    }
}

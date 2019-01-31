using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RazorPro.Pages.Pharmacyname
{
    public class PharmacynamePageModelModel : PageModel
    {
        public void OnGet()
        {

        }

        [BindProperty]
        public int SelectedPharmacy { get; set; }

        public SelectList PharmacyNameSL { get; set; }

        public void PopulatePharmacysDropDownList()
        {
            var query = new List<Pharmacy> {
                new Pharmacy{ PharmacyID = 1, Name = "P1"},
                new Pharmacy { PharmacyID = 2, Name = "P2" },
                new Pharmacy{ PharmacyID = 3, Name = "P3"}
        };

            PharmacyNameSL = new SelectList(query, "PharmacyID", "Name", new Pharmacy { PharmacyID = 3, Name = "P3" });
        }
    }
    public class Todo
    {
        public Pharmacy Pharmacy { get; set; }
    }

    public class Pharmacy
    {
        [Key]
        public int PharmacyID { get; set; }

        public string Name { get; set; }
    }
}
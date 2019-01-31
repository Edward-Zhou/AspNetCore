using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPro.Pages.Person
{
    public class InputModel : PageModel
    {
        [Remote("ValidateEmail", "Home", ErrorMessage = "This email his already used.")]
        [Required]
        [EmailAddress]
        [Display(Name = "Email *")]
        public string Email { get; set; }
        public string Name { get; set; }
        public void OnGet()
        {

        }
    }
}
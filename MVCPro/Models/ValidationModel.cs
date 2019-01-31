using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPro.Models
{

    public class ValidationModel
    {
        //[Remote("ValidateEmail", "Home", ErrorMessage = "This email his already used.")]
        //[Required]
        //[EmailAddress]
        //[Display(Name = "Email *")]
        //public string Email { get; set; }

        //public string Name { get; set; }
        public InputModel Input { get; set; }
    }
    public class InputModel
    {
        [Remote("ValidateEmail", "Home", ErrorMessage = "This email his already used.")]
        [Required]
        [EmailAddress]
        [Display(Name = "Email *")]
        public string Email { get; set; }

        public string Name { get; set; }

    }
}

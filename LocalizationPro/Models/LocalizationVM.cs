using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LocalizationPro.Models
{
    public class LocalizationVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Email", Prompt = "example@outlook.com")]
        [Required(ErrorMessage = "Requiredbb")]
        //[MaxLength(1, ErrorMessage = "RequiredAA")]
        public string Email { get; set; }
    }
}

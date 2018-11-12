using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPro.Model
{
    public class Person: IValidatableObject
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return new List<ValidationResult>() { ValidationResult.Success };
        }
    }
}

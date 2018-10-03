using FluentValidationPro.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidationPro.Models.Dto
{
    public class RequiredIfViewModel : IValidatableObject
    {
        [Display(Name = "Inscrição Isento")]
        public bool InscricaoIsento { get; set; }
        //[RequiredIf("InscricaoIsento", false, ErrorMessage = "O campo Inscrição Estadual deve ser preenchido corretamente.")]
        [Display(Name = "Insc. Estadual")]
        [Required]
        public string InscricaoEstadual { get; set; }
        public IEnumerable<ValidationResult> Validate(
            ValidationContext validationContext)
            {
                if (string.IsNullOrEmpty(InscricaoEstadual) &&
                        InscricaoIsento == false)
                    yield return new ValidationResult(
                        "O campo Inscrição Estadual deve ser preenchido corretamente.");
            }
        }
    
}

using FluentValidationPro.Models.Dto;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidationPro.Validators
{
    public class RequiredIfAttribute : ValidationAttribute, IClientModelValidator
    {
        private string _field;
        private bool _condition;

        public RequiredIfAttribute(string field, bool condition)
        {
            _field = field;
            _condition = condition;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            RequiredIfViewModel required = (RequiredIfViewModel)validationContext.ObjectInstance;

            if (required.InscricaoIsento == _condition)
            {
                return base.IsValid(value, validationContext);
            }

            return ValidationResult.Success;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPro.Validation
{
    public class AmountShouldBeLessOrEqualAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;
        public AmountShouldBeLessOrEqualAttribute(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string error = "";

            var currentValue = (decimal)value;

            var comparisonValue = GetComparisonValue(_comparisonProperty, validationContext);

            if (ErrorMessage == null && ErrorMessageResourceName == null)
            {
                ErrorMessage = "Amount is large";
            }
            else
            {
                error = string.Format(ErrorMessage ?? "", comparisonValue);
            }

            return currentValue >= comparisonValue
                ? new ValidationResult(error)
                : ValidationResult.Success;
        }

        public override string FormatErrorMessage(string name)
        {
            return base.FormatErrorMessage(name);
        }
        private decimal GetComparisonValue(string comparisonProperty, ValidationContext validationContext)
        {
            var property = validationContext.ObjectType.GetProperty(comparisonProperty);

            if (property == null)
                throw new ArgumentException("Not Found!");

            var comparisonValue = (decimal)property.GetValue(validationContext.ObjectInstance);

            return comparisonValue;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace REXELPAY.Helpers.TagHelpers
{
    public class MinMaxNumber : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int number = (int)value;

            if (number >= 1 && number <= 100)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(GetErrorMessage());

        }

        public string GetErrorMessage()
        {
            return $"Number Must be between 1 and 100";
        }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace Nika1337.Library.Presentation.Validation;

public class MinOneDayFromNowAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is DateTime returnTime)
        {
            if (returnTime < DateTime.Now.AddDays(1))
            {
                return new ValidationResult(ErrorMessage);
            }
        }
        return ValidationResult.Success;
    }
}

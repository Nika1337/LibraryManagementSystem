using System.Collections;
using System.ComponentModel.DataAnnotations;


namespace Nika1337.Library.Presentation.Validation;

public class AtLeastOneElementAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is IList list && list.Count > 0)
        {
            return ValidationResult.Success;
        }

        return new ValidationResult("At least one role must be selected.");
    }
}
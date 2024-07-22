using System.ComponentModel.DataAnnotations;

namespace Nika1337.Library.Presentation.Validation;

public class NotZeroAttribute : ValidationAttribute
{

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if ((int)(value ?? 0) != 0)
        {
            return ValidationResult.Success;
        }

        return new ValidationResult(ErrorMessage);
    }
}
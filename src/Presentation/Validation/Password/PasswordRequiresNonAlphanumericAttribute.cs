using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Nika1337.Library.Presentation.Validation.Password;

public class PasswordRequiresNonAlphanumericAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var password = value as string;
        if (!string.IsNullOrEmpty(password) && password.Any(c => !char.IsLetterOrDigit(c)))
        {
            return ValidationResult.Success;
        }

        return new ValidationResult("Password must contain at least one non-alphanumeric character.");
    }
}

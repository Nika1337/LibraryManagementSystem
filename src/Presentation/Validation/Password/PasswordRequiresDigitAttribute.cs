using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Nika1337.Library.Presentation.Validation.Password;

public class PasswordRequiresDigitAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var password = value as string;
        if (!string.IsNullOrEmpty(password) && password.Any(char.IsDigit))
        {
            return ValidationResult.Success;
        }

        return new ValidationResult("Password must contain at least one digit ('0'-'9').");
    }
}

using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Nika1337.Library.Presentation.Validation.Password;

public class PasswordRequiresUppercaseAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var password = value as string;
        if (!string.IsNullOrEmpty(password) && password.Any(char.IsUpper))
        {
            return ValidationResult.Success;
        }

        return new ValidationResult("Password must contain at least one uppercase letter ('A'-'Z').");
    }
}

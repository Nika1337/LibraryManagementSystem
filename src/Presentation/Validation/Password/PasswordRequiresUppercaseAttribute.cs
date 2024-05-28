using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Nika1337.Library.Presentation.Validation.Password;

public class PasswordRequiresUppercaseAttribute : ValidationAttribute
{
    public string GetErrorMessage() => "Password must contain at least one uppercase letter ('A'-'Z').";
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var password = value as string;
        if (!string.IsNullOrEmpty(password) && password.Any(char.IsUpper))
        {
            return ValidationResult.Success;
        }

        return new ValidationResult(GetErrorMessage());
    }
}

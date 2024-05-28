using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Nika1337.Library.Presentation.Validation.Password;

public class PasswordRequiresNonAlphanumericAttribute : ValidationAttribute
{
    public string GetErrorMessage() => "Password must contain at least one non-alphanumeric character.";
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var password = value as string;
        if (!string.IsNullOrEmpty(password) && password.Any(c => !char.IsLetterOrDigit(c)))
        {
            return ValidationResult.Success;
        }

        return new ValidationResult(GetErrorMessage());
    }
}

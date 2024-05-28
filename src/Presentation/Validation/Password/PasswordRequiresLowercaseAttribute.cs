using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace Nika1337.Library.Presentation.Validation.Password;

public class PasswordRequiresLowercaseAttribute : ValidationAttribute
{
    public string GetErrorMessage() => "Password must contain at least one lowercase letter ('a'-'z').";
   
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var password = value as string;
        if (!string.IsNullOrEmpty(password) && password.Any(char.IsLower))
        {
            return ValidationResult.Success;
        }

        return new ValidationResult(GetErrorMessage());
    }
}

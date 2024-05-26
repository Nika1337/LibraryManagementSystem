using Nika1337.Library.ApplicationCore.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Nika1337.Library.Presentation.Validation.Password;

public class PasswordCannotContainUserInfoAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var password = value as string;
        var user = (Employee)validationContext.ObjectInstance;

        if (!string.IsNullOrEmpty(password))
        {
            if (!string.IsNullOrWhiteSpace(user.Username) && password.Contains(user.Username))
            {
                return new ValidationResult("Password cannot contain the username.");
            }

            if (!string.IsNullOrWhiteSpace(user.FirstName) && password.Contains(user.FirstName, StringComparison.OrdinalIgnoreCase))
            {
                return new ValidationResult("Password cannot contain parts of the user's first name.");
            }

            if (!string.IsNullOrWhiteSpace(user.LastName) && password.Contains(user.LastName, StringComparison.OrdinalIgnoreCase))
            {
                return new ValidationResult("Password cannot contain parts of the user's last name.");
            }
        }

        return ValidationResult.Success;
    }
}

using Microsoft.AspNetCore.Identity;
using Nika1337.Library.Infrastructure.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nika1337.Library.Infrastructure.Identity;


public class EmployeePasswordValidator : IPasswordValidator<IdentityEmployee>
{
    public Task<IdentityResult> ValidateAsync(UserManager<IdentityEmployee> manager, IdentityEmployee user, string? password)
    {
        var errors = new List<IdentityError>();

        if (string.IsNullOrWhiteSpace(password))
        {
            errors.Add(new IdentityError
            {
                Code = "PasswordEmpty",
                Description = "Password cannot be empty."
            });
            return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
        }

        if (password.Length < 8)
        {
            errors.Add(new IdentityError
            {
                Code = "PasswordTooShort",
                Description = "Password must be at least 8 characters long."
            });
        }

        if (!password.Any(char.IsDigit))
        {
            errors.Add(new IdentityError
            {
                Code = "PasswordRequiresDigit",
                Description = "Password must contain at least one digit ('0'-'9')."
            });
        }

        if (!password.Any(char.IsLower))
        {
            errors.Add(new IdentityError
            {
                Code = "PasswordRequiresLowercase",
                Description = "Password must contain at least one lowercase letter ('a'-'z')."
            });
        }

        if (!password.Any(char.IsUpper))
        {
            errors.Add(new IdentityError
            {
                Code = "PasswordRequiresUppercase",
                Description = "Password must contain at least one uppercase letter ('A'-'Z')."
            });
        }

        if (!password.Any(c => !char.IsLetterOrDigit(c)))
        {
            errors.Add(new IdentityError
            {
                Code = "PasswordRequiresNonAlphanumeric",
                Description = "Password must contain at least one non-alphanumeric character."
            });
        }

        if (!password.Distinct().Any())
        {
            errors.Add(new IdentityError
            {
                Code = "PasswordRequiresUniqueChars",
                Description = "Password must contain at least one unique character."
            });
        }

        // Additional custom requirements can be added here
        // Example: Password should not contain the user's username
        if (user.UserName != null && password.Contains(user.UserName))
        {
            errors.Add(new IdentityError
            {
                Code = "PasswordContainsUserName",
                Description = "Password cannot contain the username."
            });
        }

        // Example: Password should not contain user's name parts
        if (!string.IsNullOrWhiteSpace(user.FirstName) && password.Contains(user.FirstName, StringComparison.OrdinalIgnoreCase))
        {
            errors.Add(new IdentityError
            {
                Code = "PasswordContainsFirstName",
                Description = "Password cannot contain parts of the user's first name."
            });
        }

        if (!string.IsNullOrWhiteSpace(user.LastName) && password.Contains(user.LastName, StringComparison.OrdinalIgnoreCase))
        {
            errors.Add(new IdentityError
            {
                Code = "PasswordContainsLastName",
                Description = "Password cannot contain parts of the user's last name."
            });
        }

        if (errors.Count != 0)
        {
            return Task.FromResult(IdentityResult.Failed([.. errors]));
        }

        return Task.FromResult(IdentityResult.Success);
    }
}


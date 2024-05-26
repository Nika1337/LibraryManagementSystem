using Microsoft.AspNetCore.Mvc;
using Nika1337.Library.Presentation.Validation.Password;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Nika1337.Library.Presentation.Models.EmployeeAccount;

public class ChangePasswordViewModel
{
    [Required]
    [DataType(DataType.Password)]
    [PasswordPropertyText]
    [Remote(action: "VerifyCurrentPassword", controller: "EmployeeAccount")]
    [DisplayName("Current Password")]
    public string CurrentPassword { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [PasswordPropertyText]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 8)]
    [PasswordRequiresDigit]
    [PasswordRequiresLowercase]
    [PasswordRequiresUppercase]
    [PasswordRequiresNonAlphanumeric]
    [PasswordCannotContainUserInfo]
    [DisplayName("New Password")]
    public string NewPassword { get; set; }

    [DataType(DataType.Password)]
    [Required]
    [PasswordPropertyText]
    [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
    [DisplayName("Repeat New Password")]
    public string RepeatPassword { get; set; } 
}
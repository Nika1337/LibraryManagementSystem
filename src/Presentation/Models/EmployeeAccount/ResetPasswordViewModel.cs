using Nika1337.Library.Presentation.Validation.Password;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Nika1337.Library.Presentation.Models.EmployeeAccount;

public class ResetPasswordViewModel
{
    [Required]
    [DataType(DataType.Password)]
    [PasswordPropertyText]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 8)]
    [PasswordRequiresDigit]
    [PasswordRequiresLowercase]
    [PasswordRequiresUppercase]
    [PasswordRequiresNonAlphanumeric]
    [DisplayName("New Password")]
    public string NewPassword { get; set; } = string.Empty;

    [DataType(DataType.Password)]
    [Required]
    [PasswordPropertyText]
    [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
    [DisplayName("Repeat New Password")]
    public string RepeatPassword { get; set; } = string.Empty;

    public required string Token { get; set; }
    public required string Username { get; set; }
    public string? ErrorMessage { get; set; }
}

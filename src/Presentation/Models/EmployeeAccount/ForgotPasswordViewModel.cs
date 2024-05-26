using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Nika1337.Library.Presentation.Models.EmployeeAccount;

public class ForgotPasswordViewModel
{
    [Required]
    [EmailAddress]
    [DisplayName("Email")]
    public string Email { get; set; }
    public bool WasEmailSent { get; set; }
}
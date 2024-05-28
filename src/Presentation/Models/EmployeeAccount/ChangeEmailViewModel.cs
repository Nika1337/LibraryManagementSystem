using System.ComponentModel.DataAnnotations;

namespace Nika1337.Library.Presentation.Models.EmployeeAccount;


public class ChangeEmailViewModel
{
    [Required(ErrorMessage = "New email address is required.")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    [StringLength(100, ErrorMessage = "Email address cannot be longer than 100 characters.")]
    public string NewEmail { get; set; }
    public string VerificationCode { get; set; }
    public bool CodeSent { get; set; }
    public string ErrorMessage { get; set; }
}
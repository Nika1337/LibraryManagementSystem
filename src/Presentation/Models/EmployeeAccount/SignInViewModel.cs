using System.ComponentModel.DataAnnotations;

namespace Nika1337.Library.Presentation.Models.EmployeeAccount;

public class SignInViewModel
{
    [Required]
    [Display(Name = "Username")]
    public string Username { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    public string? ErrorMessage { get; set; }
}

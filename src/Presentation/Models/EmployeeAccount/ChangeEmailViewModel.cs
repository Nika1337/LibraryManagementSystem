namespace Nika1337.Library.Presentation.Models.EmployeeAccount;


public class ChangeEmailViewModel
{
    public string NewEmail { get; set; }
    public string VerificationCode { get; set; }
    public bool CodeSent { get; set; }
    public string ErrorMessage { get; set; }
}
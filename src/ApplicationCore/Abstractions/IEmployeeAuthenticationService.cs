using Nika1337.Library.ApplicationCore.Entities;
using System.Threading.Tasks;

namespace Nika1337.Library.ApplicationCore.Abstractions;

public interface IEmployeeAuthenticationService
{
    Task RegisterEmployee(Employee employee);
    Task PasswordSignInAsync(string username, string password);
    Task ResetPasswordAsync(string username, string token, string newPassword);
    Task ForgotPasswordAsync(string email, string resetPasswordUrl);
    Task ChangePasswordAsync(string username, string currentPassword, string newPassword);
    Task ChangeEmailAsync(string username, string email, string confirmEmailUrl);
    Task ConfirmEmailAsync(string username, string token);
    Task SignOutAsync();
}

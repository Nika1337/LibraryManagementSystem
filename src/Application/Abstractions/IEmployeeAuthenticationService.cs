
using System.Threading.Tasks;

namespace Nika1337.Library.Application.Abstractions;

public interface IEmployeeAuthenticationService
{
    Task PasswordSignInAsync(string id, string password);
    Task ResetPasswordAsync(string id, string token, string newPassword);
    Task ForgotPasswordAsync(string email, string resetPasswordUrl);
    Task ChangePasswordAsync(string id, string currentPassword, string newPassword);
    Task ChangeEmailAsync(string id, string email, string confirmEmailUrl);
    Task ConfirmEmailAsync(string id, string token);
    Task SignOutAsync();
}

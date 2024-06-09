
using System.Security.Claims;
using System.Threading.Tasks;

namespace Nika1337.Library.Application.Abstractions;

public interface IEmployeeAuthenticationService
{
    Task PasswordSignInAsync(string id, string password);
    Task ResetPasswordAsync(string id, string token, string newPassword);
    Task ForgotPasswordAsync(string email, string resetPasswordUrl);
    Task ChangePasswordAsync(ClaimsPrincipal principal, string currentPassword, string newPassword);
    Task ChangeEmailAsync(ClaimsPrincipal principal, string email, string confirmEmailUrl);
    Task ConfirmEmailAsync(string id, string token);
    Task SignOutAsync();
}

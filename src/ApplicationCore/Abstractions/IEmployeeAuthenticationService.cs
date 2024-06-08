﻿using Nika1337.Library.ApplicationCore.Entities;
using System.Threading.Tasks;

namespace Nika1337.Library.ApplicationCore.Abstractions;

public interface IEmployeeAuthenticationService
{
    Task RegisterEmployee(DetailedEmployee employee);
    Task PasswordSignInAsync(string id, string password);
    Task ResetPasswordAsync(string id, string token, string newPassword);
    Task ForgotPasswordAsync(string email, string resetPasswordUrl);
    Task ChangePasswordAsync(string id, string currentPassword, string newPassword);
    Task ChangeEmailAsync(string username, string email, string confirmEmailUrl);
    Task ConfirmEmailAsync(string id, string token);
    Task SignOutAsync();
}

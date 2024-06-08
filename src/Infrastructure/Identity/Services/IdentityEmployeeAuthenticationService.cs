﻿using Microsoft.AspNetCore.Identity;
using Nika1337.Library.ApplicationCore.Abstractions;
using Nika1337.Library.ApplicationCore.Entities;
using Nika1337.Library.ApplicationCore.Exceptions;
using Nika1337.Library.Infrastructure.Identity.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Nika1337.Library.Infrastructure.Identity.Services;


internal class IdentityEmployeeAuthenticationService : IEmployeeAuthenticationService
{
    private static readonly string _temporaryPassword = "AppleOrange.1234";
    private readonly SignInManager<IdentityEmployee> _signInManager;
    private readonly UserManager<IdentityEmployee> _userManager;
    private readonly RoleManager<IdentityEmployeeRole> _roleManager;
    private readonly IEmailService _emailService;

    public IdentityEmployeeAuthenticationService(
        SignInManager<IdentityEmployee> signInManager,
        UserManager<IdentityEmployee> userManager,
        RoleManager<IdentityEmployeeRole> roleManager,
        IEmailService emailService)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _roleManager = roleManager;
        _emailService = emailService;
    }

    public async Task RegisterEmployee(DetailedEmployee employee)
    {
        var identityEmployeeWithSameUsername = await _userManager.FindByNameAsync(employee.Username);

        if (identityEmployeeWithSameUsername is not null)
        {
            throw new DuplicateException($"Employee with username '{employee.Username}' already exists");
        }

        var identityEmployeeRoleNames = employee.Roles.Select(role => role.Name);

        var identityEmployeeRoles = _roleManager.Roles.Where(role => identityEmployeeRoleNames.Contains(role.Name));


        var identityEmployee = new IdentityEmployee
        {
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            UserName = employee.Username,
            IdNumber = employee.IdNumber,
            DateOfBirth = employee.DateOfBirth,
            Salary = employee.Salary,
            StartDate = DateTime.UtcNow
        };

        var registrationResult = await _userManager.CreateAsync(identityEmployee, _temporaryPassword);

        if (!registrationResult.Succeeded)
        {
            throw new ApplicationException($"Unable to register employee with username '{identityEmployee.UserName}'");
        }

        var roleAdditionResult = await _userManager.AddToRolesAsync(identityEmployee, identityEmployeeRoleNames);

        if (!roleAdditionResult.Succeeded)
        {
            throw new ApplicationException($"Unable to Add roles to employee with username '{identityEmployee.UserName}'");
        }
    }

    public async Task PasswordSignInAsync(string username, string password)
    {
        var existingEmployee = await _userManager.FindByNameAsync(username) ?? throw new EmployeeNotFoundException(username);

        if (existingEmployee.TerminationDate != null)
        {
            throw new TerminatedEmployeeSignInException(username);
        }

        var isPasswordCorrect = await _userManager.CheckPasswordAsync(existingEmployee, password);

        if (!isPasswordCorrect)
        {
            throw new PasswordIncorrectException(username);
        }

        var signInResult = await _signInManager.PasswordSignInAsync(existingEmployee, password, true, false);

        if (!signInResult.Succeeded)
        {
            throw new ApplicationException($"Unable to Sign in employee with username '{username}'");
        }
    }

    public async Task ChangePasswordAsync(string id, string currentPassword, string newPassword)
    {
        var existingEmployee = await _userManager.FindByIdAsync(id) ?? throw new EmployeeNotFoundException(id);

        var isCurrentPasswordCorrect = await _userManager.CheckPasswordAsync(existingEmployee, currentPassword);

        if (!isCurrentPasswordCorrect)
        {
            throw new PasswordIncorrectException(id);
        }

        var newPasswordValidationResult = await new EmployeePasswordValidator().ValidateAsync(_userManager, existingEmployee, newPassword);

        if (!newPasswordValidationResult.Succeeded)
        {
            throw new PasswordStructureValidationException(newPasswordValidationResult.Errors.FirstOrDefault()?.Description ?? "");
        }

        var changePasswordResult = await _userManager.ChangePasswordAsync(existingEmployee, currentPassword, newPassword);

        if (!changePasswordResult.Succeeded)
        {
            throw new ApplicationException($"Unable to change password of employee with id '{id}'");
        }
    }


    public async Task ChangeEmailAsync(string id, string email, string confirmEmailUrl)
    {
        var existingEmployee = await _userManager.FindByIdAsync(id) ?? throw new EmployeeNotFoundException(id);

        var changeEmailResult =  await _userManager.SetEmailAsync(existingEmployee, email);

        if (!changeEmailResult.Succeeded)
        {
            throw new ApplicationException($"Unable to set email for employee with id '{id}'");
        }

        var emailConfirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(existingEmployee);

        var encodedToken = HttpUtility.UrlEncode(emailConfirmationToken);

        var confirmEmailHref = $"{confirmEmailUrl}?id={id}&token={encodedToken}";

        await _emailService.SendEmailAsync(email, 2, new { Href = confirmEmailHref });
    }
    
    public async Task ConfirmEmailAsync(string id, string token)
    {
        var existingEmployee = await _userManager.FindByIdAsync(id) ?? throw new EmployeeNotFoundException(id);

        var changeEmailResult = await _userManager.ConfirmEmailAsync(existingEmployee, token);

        if (!changeEmailResult.Succeeded)
        {
            throw new ApplicationException($"Unable to confirm email for employee with id '{id}'");
        }
    }

    public async Task ResetPasswordAsync(string id, string token, string newPassword)
    {
        var existingEmployee = await _userManager.FindByIdAsync(id) ?? throw new EmployeeNotFoundException(id);

        var newPasswordValidationResult = await new EmployeePasswordValidator().ValidateAsync(_userManager, existingEmployee, newPassword);

        if (!newPasswordValidationResult.Succeeded)
        {
            throw new PasswordStructureValidationException(newPasswordValidationResult.Errors.FirstOrDefault()?.Description ?? "");
        }


        var passwordResetResult = await _userManager.ResetPasswordAsync(existingEmployee, token, newPassword);

        if (!passwordResetResult.Succeeded)
        {
            throw new ApplicationException($"Unable to reset password for employee with Id '{id}'");
        }
    }

    public async Task SignOutAsync()
    {
        await _signInManager.SignOutAsync();
    }

    public async Task ForgotPasswordAsync(string email, string resetPasswordUrl)
    {
        var identityEmployee = await _userManager.FindByEmailAsync(email);

        if (identityEmployee is null)
        {
            return;
        }

        var resetToken = await _userManager.GeneratePasswordResetTokenAsync(identityEmployee);

        var encodedToken = HttpUtility.UrlEncode(resetToken);

        var resetPasswordHref = $"{resetPasswordUrl}?id={identityEmployee.Id}&token={encodedToken}";

        await _emailService.SendEmailAsync(email, 1, new { Href = resetPasswordHref });
    }

}
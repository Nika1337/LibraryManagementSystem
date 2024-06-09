using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.Application.DataTransferObjects;
using Nika1337.Library.ApplicationCore.Entities;
using Nika1337.Library.ApplicationCore.Exceptions;
using Nika1337.Library.Presentation.Models.EmployeeAccount;
using System;
using System.Threading.Tasks;

namespace Nika1337.Library.Presentation.Controllers;

[Authorize]
[Route("[controller]/[action]")]

public class EmployeeAccountController : Controller
{
    private readonly IEmployeeAuthenticationService _employeeAuthenticationService;
    private readonly IEmployeeService _employeeService;
    private readonly IMapper _mapper;
    public EmployeeAccountController(
        IEmployeeAuthenticationService employeeAuthenticationService,
        IEmployeeService employeeService,
        IMapper mapper)
    {
        _employeeAuthenticationService = employeeAuthenticationService;
        _employeeService = employeeService;
        _mapper = mapper;
    }

    [AllowAnonymous]
    [HttpGet]
    public IActionResult SignIn()
    {
        var model = new SignInViewModel();

        return View(model);
    }


    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> SignIn(SignInViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var passwordOrUsernameIncorrectErrorMessage = "Username or password is incorrect";

        try
        {
            await _employeeAuthenticationService.PasswordSignInAsync(model.Username, model.Password);
        }
        catch (EmployeeNotFoundException)
        {
            model.ErrorMessage = passwordOrUsernameIncorrectErrorMessage;
            return View(model);
        }
        catch (PasswordIncorrectException)
        {
            model.ErrorMessage = passwordOrUsernameIncorrectErrorMessage;
            return View(model);
        }
        catch (TerminatedEmployeeSignInException)
        {
            model.ErrorMessage = passwordOrUsernameIncorrectErrorMessage;
            return View(model);
        }


        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public new async Task<IActionResult> SignOut()
    {
        await _employeeAuthenticationService.SignOutAsync();

        return RedirectToAction(nameof(SignIn));
    }

    [HttpGet]
    public async Task<IActionResult> Profile()
    {
        var employee = await _employeeService.GetDetailedEmployeeAsync(User);

        var model = _mapper.Map<EmployeePersonalProfileViewModel>(employee);

        return View(model);
    }
    [HttpPost]
    public async Task<IActionResult> Profile(EmployeePersonalProfileViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var updateRequest = _mapper.Map<EmployeeAccountUpdateRequest>(model);

        try
        {
            await _employeeService.UpdateEmployeeAsync(updateRequest);
        }
        catch (UsernameDuplicateException)
        {
            model.ErrorMessage = $"Username '{model.Username}' is taken";
            return View(model);
        }
        


        return View(model);
    }

    [AllowAnonymous]
    [HttpGet]
    public IActionResult ForgotPassword()
    {
        var model = new ForgotPasswordViewModel();

        return View(model);
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
    {
        var baseUrl = $"{Request.Scheme}://{Request.Host}";

        var controllerName = nameof(EmployeeAccountController).Replace("Controller", "");

        var actionName = nameof(ResetPassword);


        var resetPasswordUrl = $"{baseUrl}/{controllerName}/{actionName}";

        await _employeeAuthenticationService.ForgotPasswordAsync(model.Email, resetPasswordUrl);

        return RedirectToAction(nameof(EmailSuccessfullySent));
    }

    [AllowAnonymous]
    [HttpGet]
    public IActionResult EmailSuccessfullySent()
    {
        return View();
    }

    [AllowAnonymous]
    [HttpGet]
    public IActionResult ResetPassword(string id, string token)
    {
        var model = new ResetPasswordViewModel
        {
            Token = token,
            Id = id
        };

        return View(model);
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        try
        {
            await _employeeAuthenticationService.ResetPasswordAsync(model.Id, model.Token, model.NewPassword);
        }
        catch(PasswordStructureValidationException ex)
        {
            model.ErrorMessage = ex.Message;
            return View(model);
        }

        return RedirectToAction(nameof(SignIn));
    }

    [HttpGet]
    public IActionResult ChangePassword()
    {
        var model = new ChangePasswordViewModel();

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        try
        {
            await _employeeAuthenticationService.ChangePasswordAsync(User, model.CurrentPassword, model.NewPassword);
        }
        catch (PasswordIncorrectException)
        {
            model.ErrorMessage = "Current password is incorrect";
            return View(model);
        }
        catch(PasswordStructureValidationException ex)
        { 
            model.ErrorMessage = ex.Message;
            return View(model);
        }

        return RedirectToAction(nameof(Profile));
    }

    [HttpGet]
    public IActionResult ChangeEmail()
    {
        var model = new ChangeEmailViewModel();

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> ChangeEmail(ChangeEmailViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var baseUrl = $"{Request.Scheme}://{Request.Host}";

        var controllerName = nameof(EmployeeAccountController).Replace("Controller", "");

        var actionName = nameof(ConfirmEmail);

        var resetPasswordUrl = $"{baseUrl}/{controllerName}/{actionName}";

        var existingEmployee = await _employeeService.GetDetailedEmployeeAsync(User);

        await _employeeAuthenticationService.ChangeEmailAsync(User, model.Email, resetPasswordUrl);

        return RedirectToAction(nameof(EmailSuccessfullySent));
    }

    [HttpGet]
    public async Task<IActionResult> ConfirmEmail(string id, string token)
    {
        await _employeeAuthenticationService.ConfirmEmailAsync(id, token);

        return RedirectToAction(nameof(EmailSuccessfullyConfirmed));
    }

    [HttpGet]
    public IActionResult EmailSuccessfullyConfirmed()
    {
        return View();
    }
}

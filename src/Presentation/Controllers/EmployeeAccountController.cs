using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nika1337.Library.ApplicationCore.Abstractions;
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
    private readonly IAppLogger<EmployeeAccountController> _logger;

    public EmployeeAccountController(
        IEmployeeAuthenticationService employeeAuthenticationService,
        IEmployeeService employeeService,
        IAppLogger<EmployeeAccountController> logger)
    {
        _employeeAuthenticationService = employeeAuthenticationService;
        _employeeService = employeeService;
        _logger = logger;
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

    [HttpPost]
    public async Task<IActionResult> SignOut()
    {
        base.SignOut();
        await _employeeAuthenticationService.SignOutAsync();

        return RedirectToAction("SigIn");
    }

    [HttpGet]
    public async Task<IActionResult> EmployeeProfile()
    {
        var employee = await _employeeService.GetEmployeeAsync(User);

        var model = new EmployeeProfileViewModel
        {
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Username = employee.Username,
            PhoneNumber = employee.PhoneNumber,
            Gender = employee.Gender,
            IdNumber = employee.IdNumber,
            DateOfBirth = employee.DateOfBirth,
            Email = employee.Email,
            Salary = employee.Salary,
            StartDate = employee.StartDate,
            Country = employee.Address?.Country,
            State = employee.Address?.State,
            City = employee.Address?.City,
            Street = employee.Address?.Street,
            PostalCode = employee.Address?.PostalCode,
        };

        return View(model);
    }
    [HttpPost]
    public async Task<IActionResult> EmployeeProfile(EmployeeProfileViewModel model)
    {
        var employee = await _employeeService.GetEmployeeAsync(User);

        employee.FirstName = model.FirstName;
        employee.LastName = model.LastName;
        employee.Username = model.Username;
        employee.PhoneNumber = model.PhoneNumber;
        employee.Gender = model.Gender;
        employee.Address = new Address
        {
            Country = model.Country,
            State = model.State,
            City = model.City,
            Street = model.Street,
            PostalCode = model.PostalCode,
        };

        var username = User?.Identity?.Name ?? throw new ApplicationException("Current User's name is null");

        await _employeeService.UpdateEmployee(username, employee);

        _logger.LogInformation("Employee with Username {0} updated their profile", username);

        return View(model);
    }
}

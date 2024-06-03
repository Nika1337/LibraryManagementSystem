using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nika1337.Library.ApplicationCore.Abstractions;
using Nika1337.Library.ApplicationCore.Entities;
using Nika1337.Library.ApplicationCore.Exceptions;
using Nika1337.Library.Presentation.Models;
using Nika1337.Library.Presentation.Models.EmployeeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Nika1337.Library.Presentation.Controllers;

[Authorize(Roles = "Human Resources Manager")]
[Route("[controller]/[action]")]
public class EmployeeManagementController : Controller
{
    private readonly IEmployeeAuthenticationService _employeeAuthenticationService;
    private readonly IEmployeeService _employeeService;
    public EmployeeManagementController(
        IEmployeeAuthenticationService employeeAuthenticationService,
        IEmployeeService employeeService)
    {
        _employeeAuthenticationService = employeeAuthenticationService;
        _employeeService = employeeService;
    }

    [HttpGet]
    public async Task<IActionResult> RegisterEmployee()
    {
        var avaliableRoleNames = await GetAvaliableRoleSelectListItems();

        var model = new EmployeeRegistrationViewModel
        {
            AvailableRoles = avaliableRoleNames
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> RegisterEmployee(EmployeeRegistrationViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var selectedRoles = await _employeeService.GetEmployeeRolesByRoleNames(model.SelectedRoles);

        var employee = new DetailedEmployee
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Username = model.Username,
            IdNumber = model.IdNumber,
            DateOfBirth = model.DateOfBirth,
            Salary = model.Salary,
            Roles = selectedRoles.ToArray(),
            StartDate = DateTime.UtcNow
        };


        try
        {
            await _employeeAuthenticationService.RegisterEmployee(employee);
        } catch(DuplicateException)
        {
            model.ErrorMessage = $"Username '{model.Username}' is taken";
            return View(model);
        }

        return RedirectToAction("AllEmployees");
    }

    [HttpGet("{username}")]
    public async Task<IActionResult> Profile(string username)
    {
        var employee = await _employeeService.GetDetailedEmployeeAsync(username);

        var avaliableRoleNames = await GetAvaliableRoleSelectListItems();

        var selectedRoles = employee.Roles.Select(role => role.Name);

        var model = new EmployeeProfileViewModel {
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            NewUsername = employee.Username,
            IdNumber = employee.IdNumber,
            DateOfBirth = employee.DateOfBirth,
            Salary = employee.Salary,
            StartDate = employee.StartDate,
            TerminationDate = employee.TerminationDate,
            SelectedRoles = selectedRoles.ToList(),
            AvailableRoles = avaliableRoleNames,
            Country = employee.Address?.Country,
            State = employee.Address?.State,
            City = employee.Address?.City,
            Street = employee.Address?.Street,
            PostalCode = employee.Address?.PostalCode,
            Gender = employee.Gender,
            Email = employee.Email,
            PhoneNumber = employee.PhoneNumber
        };

        return View(model);
    }

    [HttpPost("{username}")]
    public async Task<IActionResult> Profile(string username, EmployeeProfileViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var existingEmployee = await _employeeService.GetDetailedEmployeeAsync(username);

        var selectedRoles = await _employeeService.GetEmployeeRolesByRoleNames(model.SelectedRoles);

        existingEmployee.FirstName = model.FirstName;
        existingEmployee.LastName = model.LastName;
        existingEmployee.Username = model.NewUsername;
        existingEmployee.IdNumber = model.IdNumber;
        existingEmployee.DateOfBirth = model.DateOfBirth;
        existingEmployee.Salary = model.Salary;
        existingEmployee.Roles = selectedRoles.ToArray();

        try
        {
            await _employeeService.UpdateDetailedEmployee(username, existingEmployee);
        } catch (DuplicateException)
        {
            model.ErrorMessage = $"Username '{model.NewUsername}' is taken";
            return View(model);
        }

        return RedirectToAction("AllEmployees");
    }

    [HttpPost("{username}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> TerminateEmployee(string username)
    {
        var existingEmployee = await _employeeService.GetDetailedEmployeeAsync(username);

        existingEmployee.TerminationDate = DateTime.UtcNow;

        await _employeeService.UpdateDetailedEmployee(username, existingEmployee);

        return Ok();
    }

    [HttpPost("{username}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RenewEmployee(string username)
    {
        var existingEmployee = await _employeeService.GetDetailedEmployeeAsync(username);

        existingEmployee.StartDate = DateTime.UtcNow;
        existingEmployee.TerminationDate = existingEmployee.TerminationDate = null;
        await _employeeService.UpdateDetailedEmployee(username, existingEmployee);


        return Ok();
    }


    [HttpGet]
    public IActionResult AllEmployees(
        [FromQuery] string? sortedBy,
        [FromQuery] string? searchTerm,
        [FromQuery] bool shouldIncludeTerminated = true)
    {
        Expression<Func<Employee, object>>? keySelector = null;
        bool isAscending = false;

        ViewData["SortedBy"] = sortedBy;
        ViewData["SearchTerm"] = searchTerm;

        switch (sortedBy)
        {
            case null:
                keySelector = null;
                isAscending = true;
                break;
            case "username":
                keySelector = e => e.Username;
                isAscending = true;
                break;
            case "usernameDesc":
                keySelector = e => e.Username;
                isAscending = false;
                break;
            case "firstName":
                keySelector = e => e.FirstName;
                isAscending = true;
                break;
            case "firstNameDesc":
                keySelector = e => e.FirstName;
                isAscending = false;
                break;
            case "lastName":
                keySelector = e => e.LastName;
                isAscending = true;
                break;
            case "lastNameDesc":
                keySelector = e => e.LastName;
                isAscending = false;
                break;
            case "startDate":
                keySelector = e => e.StartDate;
                isAscending = true;
                break;
            case "startDateDesc":
                keySelector = e => e.StartDate;
                isAscending = false;
                break;
            default:
                throw new ApplicationException("Invalid sorted by argument");
        }

        var allEmployees = _employeeService.GetAllEmployees(keySelector, isAscending, searchTerm ?? "", shouldIncludeTerminated);

        var model = allEmployees.Select(
            employee => new EmployeeViewModel
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Username = employee.Username,
                IdNumber = employee.IdNumber,
                DateOfBirth = employee.DateOfBirth,
                PhoneNumber = employee.PhoneNumber,
                Email = employee.Email,
                StartDate = employee.StartDate,
                IsActive = employee.IsActive
            });

        return View(model);
    }

    private async Task<List<string>> GetAvaliableRoleSelectListItems()
    {
        var avaliableRoles = await _employeeService.GetAllEmployeeRolesAsync();
        return avaliableRoles.Select(role => role.Name).ToList();
    }
}

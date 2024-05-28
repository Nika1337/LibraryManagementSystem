using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nika1337.Library.ApplicationCore.Abstractions;
using Nika1337.Library.ApplicationCore.Entities;
using Nika1337.Library.ApplicationCore.Exceptions;
using Nika1337.Library.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        var employee = new Employee
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


        await _employeeAuthenticationService.RegisterEmployee(employee);

        return RedirectToAction("AllEmployees");
    }

    [HttpGet("{username}")]
    public async Task<IActionResult> Profile(string username)
    {
        var employee = await _employeeService.GetEmployeeAsync(username);

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
        Console.WriteLine($"{username} want to change to {model.NewUsername}");
        var existingEmployee = await _employeeService.GetEmployeeAsync(username);

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
            await _employeeService.UpdateEmployee(username, existingEmployee);
        } catch(DuplicateException)
        {
            model.ErrorMessage = $"Username '{model.NewUsername}' is taken";
            return View(model);
        }

        return RedirectToAction("AllEmployees");
    }

    [HttpDelete("{username}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ToggleTerminateEmployee(string username)
    {
        var existingEmployee = await _employeeService.GetEmployeeAsync(username);

        existingEmployee.TerminationDate = existingEmployee.TerminationDate == null ? DateTime.UtcNow : null;
        await _employeeService.UpdateEmployee(username, existingEmployee);


        return Ok();
    }


    [HttpGet]
    public async Task<IActionResult> AllEmployees()
    {
        var allEmployees = await _employeeService.GetAllEmployeesAsync();

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
                IsActive = employee.TerminationDate is null
            });

        return View(model);
    }

    private async Task<List<string>> GetAvaliableRoleSelectListItems()
    {
        var avaliableRoles = await _employeeService.GetAllEmployeeRolesAsync();
        return avaliableRoles.Select(role => role.Name).ToList();
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nika1337.Library.ApplicationCore.Abstractions;
using Nika1337.Library.ApplicationCore.Entities;
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
    private readonly IAppLogger<EmployeeManagementController> _logger;
    private readonly IEmployeeAuthenticationService _employeeAuthenticationService;
    private readonly IEmployeeService _employeeService;
    public EmployeeManagementController(
        IAppLogger<EmployeeManagementController> logger,
        IEmployeeAuthenticationService employeeAuthenticationService,
        IEmployeeService employeeService)
    {
        _logger = logger;
        _employeeAuthenticationService = employeeAuthenticationService;
        _employeeService = employeeService;
    }

    [HttpGet]
    public async Task<IActionResult> RegisterEmployee()
    {
        var avaliableRoleSelectListItems = await GetAvaliableRoleSelectListItems();

        var viewModel = new EmployeeRegistrationViewModel
        {
            AvailableRoles = avaliableRoleSelectListItems
        };

        return View(viewModel);
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

        _logger.LogInformation("New employee has been registered");

        return RedirectToAction("AllEmployees");
    }

    [HttpGet("{username}")]
    public async Task<IActionResult> EditEmployee(string username)
    {
        var employee = await _employeeService.GetEmployeeAsync(username);

        var avaliableRoleSelectListItems = await GetAvaliableRoleSelectListItems();

        var selectedRoles = employee.Roles.Select(role => role.Name);

        var model = new EmployeeEditViewModel {
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            NewUsername = employee.Username,
            IdNumber = employee.IdNumber,
            DateOfBirth = employee.DateOfBirth,
            Salary = employee.Salary,
            StartDate = employee.StartDate,
            TerminationDate = employee.TerminationDate,
            SelectedRoles = selectedRoles.ToList(),
            AvailableRoles = avaliableRoleSelectListItems
        };

        return View(model);
    }

    [HttpPost("{username}")]
    public async Task<IActionResult> EditEmployee(string username, EmployeeEditViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var existingEmployee = await _employeeService.GetEmployeeAsync(username);

        var selectedRoles = await _employeeService.GetEmployeeRolesByRoleNames(model.SelectedRoles);

        existingEmployee.FirstName = model.FirstName;
        existingEmployee.LastName = model.LastName;
        existingEmployee.Username = model.NewUsername;
        existingEmployee.IdNumber = model.IdNumber;
        existingEmployee.DateOfBirth = model.DateOfBirth;
        existingEmployee.Salary = model.Salary;
        existingEmployee.Roles = selectedRoles.ToArray();

        await _employeeService.UpdateEmployee(username, existingEmployee);

        _logger.LogInformation("Employee with Username {0} has been updated by {1}", existingEmployee.Username, User?.Identity?.Name ?? "Unknown HR Manager");

        return RedirectToAction("AllEmployees");
    }

    [HttpDelete("{username}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ToggleTerminateEmployee(string username)
    {
        var existingEmployee = await _employeeService.GetEmployeeAsync(username);

        existingEmployee.TerminationDate = existingEmployee.TerminationDate == null ? DateTime.UtcNow : null;
        await _employeeService.UpdateEmployee(username, existingEmployee);

        _logger.LogInformation("Employee with Username {0} has been terminated", username);

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
                TerminationDate = employee.TerminationDate,
                Roles = employee.Roles.Select(role => role.Name).ToList()
            });

        return View(model);
    }

    private async Task<List<SelectListItem>> GetAvaliableRoleSelectListItems()
    {
        var avaliableRoles = await _employeeService.GetAllEmployeeRolesAsync();
        return avaliableRoles.Select(role => new SelectListItem
        {
            Value = role.Name,
            Text = role.Name
        }).ToList();
    }
}

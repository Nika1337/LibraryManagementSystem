using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.ApplicationCore.Entities;
using Nika1337.Library.ApplicationCore.Exceptions;
using Nika1337.Library.Presentation.Models.EmployeeManagement;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Nika1337.Library.Presentation.Controllers;

[Authorize(Roles = "Human Resources Manager")]
[Route("Employees")]
public class EmployeeManagementController : Controller
{
    private readonly IEmployeeAuthenticationService _employeeAuthenticationService;
    private readonly IEmployeeService _employeeService;
    private readonly IEmployeeRoleService _employeeRoleService;
    public EmployeeManagementController(
        IEmployeeAuthenticationService employeeAuthenticationService,
        IEmployeeService employeeService,
        IEmployeeRoleService employeeRoleService)
    {
        _employeeAuthenticationService = employeeAuthenticationService;
        _employeeService = employeeService;
        _employeeRoleService = employeeRoleService;
    }


    [HttpGet("[action]")]
    public async Task<IActionResult> RegisterEmployee()
    {
        var avaliableRoleNames = await GetAvaliableRoleSelectListItems();

        var model = new EmployeeRegistrationViewModel
        {
            AvailableRoles = avaliableRoleNames
        };

        return View(model);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> RegisterEmployee(EmployeeRegistrationViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var selectedRoles = model.SelectedRoles.Select(name => new EmployeeRole { Name = name });

        var employee = new DetailedEmployee
        {
            Id = "",
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

    [HttpGet("{id}")]
    public async Task<IActionResult> Profile(string id)
    {
        var employee = await _employeeService.GetDetailedEmployeeAsync(id);

        var avaliableRoleNames = await GetAvaliableRoleSelectListItems();

        var selectedRoles = employee.Roles.Select(role => role.Name);

        var model = new EmployeeProfileViewModel {
            Id = employee.Id,
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

    [HttpPost("{id}")]
    public async Task<IActionResult> Profile(string id, EmployeeProfileViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var existingEmployee = await _employeeService.GetDetailedEmployeeAsync(id);

        var selectedRoles = model.SelectedRoles.Select(roleName => new EmployeeRole { Name = roleName });

        existingEmployee.FirstName = model.FirstName;
        existingEmployee.LastName = model.LastName;
        existingEmployee.Username = model.NewUsername;
        existingEmployee.IdNumber = model.IdNumber;
        existingEmployee.DateOfBirth = model.DateOfBirth;
        existingEmployee.Salary = model.Salary;
        existingEmployee.Roles = selectedRoles.ToArray();

        try
        {
            await _employeeService.UpdateDetailedEmployee(existingEmployee);
        } catch (DuplicateException)
        {
            model.ErrorMessage = $"Username '{model.NewUsername}' is taken";
            return View(model);
        }

        return RedirectToAction("AllEmployees");
    }

    [HttpPost("[action]/{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> TerminateEmployee(string id)
    {
        var existingEmployee = await _employeeService.GetDetailedEmployeeAsync(id);

        existingEmployee.TerminationDate = DateTime.UtcNow;

        await _employeeService.UpdateDetailedEmployee(existingEmployee);

        return Ok();
    }

    [HttpPost("[action]/{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RenewEmployee(string id)
    {
        var existingEmployee = await _employeeService.GetDetailedEmployeeAsync(id);

        existingEmployee.StartDate = DateTime.UtcNow;
        existingEmployee.TerminationDate = existingEmployee.TerminationDate = null;
        await _employeeService.UpdateDetailedEmployee(existingEmployee);


        return Ok();
    }


    [HttpGet]
    public async Task<IActionResult> AllEmployees()
    {

        var allEmployees = await _employeeService.GetAllEmployees();

        var model = allEmployees.Select(
            employee => new EmployeeViewModel
            {
                Id = employee.Id,
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

    private async Task<string[]> GetAvaliableRoleSelectListItems()
    {
        var avaliableRoles = await _employeeRoleService.GetAllEmployeeRoleNamesAsync();
        return avaliableRoles;
    }
}

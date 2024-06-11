using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.Application.DataTransferObjects;
using Nika1337.Library.ApplicationCore.Exceptions;
using Nika1337.Library.Presentation.Models.EmployeeManagement;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nika1337.Library.Presentation.Controllers;

[Authorize(Roles = "Human Resources Manager")]
[Route("Employees")]
public class EmployeeManagementController : Controller
{
    private readonly IEmployeeService _employeeService;
    private readonly IEmployeeRoleService _employeeRoleService;
    private readonly IMapper _mapper;
    public EmployeeManagementController(
        IEmployeeService employeeService,
        IEmployeeRoleService employeeRoleService,
        IMapper mapper)
    {
        _employeeService = employeeService;
        _employeeRoleService = employeeRoleService;
        _mapper = mapper;
    }


    [HttpGet("[action]")]
    public async Task<IActionResult> RegisterEmployee()
    {
        var avaliableRoleNames = await GetAvaliableRoleNames();

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

        var registrationRequest = _mapper.Map<EmployeeRegistrationRequest>(model);

        try
        {
            await _employeeService.RegisterEmployeeAsync(registrationRequest);
        }
        catch(NameDuplicateException)
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

        var avaliableRoleNames = await GetAvaliableRoleNames();

        var model = _mapper.Map<EmployeeProfileViewModel>(employee);
        model.AvailableRoles = avaliableRoleNames;

        return View(model);
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> Profile(EmployeeProfileViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var updateRequest = _mapper.Map<EmployeeManagerUpdateRequest>(model);

        try
        {
            await _employeeService.UpdateEmployeeAsync(updateRequest);
        }
        catch (NameDuplicateException)
        {
            model.ErrorMessage = $"Username '{model.Username}' is taken";
            return View(model);
        }

        return RedirectToAction(nameof(AllEmployees));
    }

    [HttpPost("[action]/{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> TerminateEmployee(string id)
    {
        await _employeeService.TerminateEmployeeAsync(id);

        return Ok();
    }

    [HttpPost("[action]/{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RenewEmployee(string id)
    {
        await _employeeService.RenewEmployeeAsync(id);

        return Ok();
    }


    [HttpGet]
    public async Task<IActionResult> AllEmployees()
    {

        var allEmployees = await _employeeService.GetAllEmployeesAsync();

        var model = _mapper.Map<IEnumerable<EmployeeViewModel>>(allEmployees);

        return View(model);
    }

    private async Task<string[]> GetAvaliableRoleNames()
    {
        var avaliableRoles = await _employeeRoleService.GetAllEmployeeRoleNamesAsync();

        return avaliableRoles;
    }
}

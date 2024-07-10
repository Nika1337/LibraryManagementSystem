using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.Application.DataTransferObjects;
using Nika1337.Library.Domain.Exceptions;
using Nika1337.Library.Presentation.Models;
using Nika1337.Library.Presentation.Models.EmployeeManagement;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nika1337.Library.Presentation.Controllers;

[Authorize(Roles = "Human Resources Manager")]
[Route("Employees")]
public class EmployeeManagementController : Controller
{
    private readonly IEmployeeService _employeeService;
    private readonly IEmployeeRoleService _employeeRoleService;
    private readonly IMapper _mapper;
    private readonly Dictionary<string, string> sortOptions = new()
        {
            { "username", "Username: A - Z" },
            { "usernameDesc", "Username: Z - A" },
            { "firstName", "First name: A - Z" },
            { "firstNameDesc", "First name: Z - A" },
            { "lastName", "Last name: A - Z" },
            { "lastNameDesc", "Last name: Z - A" },
            { "startDate", "Start Date: Ascending" },
            { "startDateDesc", "Start Date: Descending" },
            { "dateOfBirth", "Date Of Birth: Ascending" },
            { "dateOfBirthDesc", "Date Of Birth: Descending" }
        };

    private readonly FilterOption[] _filterOptions =
        [
            new BoolFilterOption {
                Name = "Include Deleted"
            },
            new RangeFilterOption {
                Name = "Date Of Birth",
                RangeFilterOptionType = RangeFilterOptionType.DateTime
            },
            new RangeFilterOption {
                Name = "Start Date",
                RangeFilterOptionType = RangeFilterOptionType.DateTime
            }
        ];

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
        var avaliableRoleNames = await GetAvailableRoleNames();

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

        var avaliableRoleNames = await GetAvailableRoleNames();

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

        return RedirectToAction(nameof(Employees));
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
    public async Task<IActionResult> Employees()
    {
        var allEmployees = await _employeeService.GetAllEmployeesAsync();

        var model = _mapper.Map<IEnumerable<EmployeeViewModel>>(allEmployees);

        return View(model);
    }

    [HttpGet("SortOptions")]
    public IActionResult GetSortOptions()
    {
        var sortOptions = this.sortOptions.Select(kvp => new
        {
            kvp.Key,
            kvp.Value
        }).ToArray();

        return Ok(sortOptions);
    }

    [HttpGet("FilterOptions")]
    public virtual IActionResult GetFilterOptions()
    {
        var filterOptions = _filterOptions.Select(option => option.ToJsonString());

        return Ok(filterOptions);
    }

    private async Task<string[]> GetAvailableRoleNames()
    {
        var avaliableRoles = await _employeeRoleService.GetAllEmployeeRoleNamesAsync();

        return avaliableRoles;
    }
}

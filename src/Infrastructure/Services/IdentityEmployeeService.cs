using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.Application.DataTransferObjects;
using Nika1337.Library.ApplicationCore.Entities;
using Nika1337.Library.ApplicationCore.Exceptions;
using Nika1337.Library.Infrastructure.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Nika1337.Library.Infrastructure.Services;

internal class IdentityEmployeeService : IEmployeeService
{
    private static readonly string _temporaryPassword = "AppleOrange.1234";

    private readonly UserManager<IdentityEmployee> _userManager;
    private readonly IMapper _mapper;

    public IdentityEmployeeService(
        UserManager<IdentityEmployee> userManager,
        IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }



    public async Task RegisterEmployeeAsync(EmployeeRegistrationRequest employee)
    {
        await ThrowIfUsernameExists(employee.Username);


        var identityEmployee = _mapper.Map<IdentityEmployee>(employee);

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine(identityEmployee.DateOfBirth);
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine(identityEmployee.StartDate);
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();

        var registrationResult = await _userManager.CreateAsync(identityEmployee, _temporaryPassword);

        if (!registrationResult.Succeeded)
        {
            throw new ApplicationException($"Unable to register employee with username '{identityEmployee.UserName}'");
        }


        var roleAdditionResult = await _userManager.AddToRolesAsync(identityEmployee, employee.Roles);

        if (!roleAdditionResult.Succeeded)
        {
            throw new ApplicationException($"Unable to Add roles to employee with username '{identityEmployee.UserName}'");
        }
    }

    public async Task<IEnumerable<EmployeeSimpleResponse>> GetAllEmployeesAsync()
    {
        var employees = await _userManager.Users
            .Select(
                identityEmployee => _mapper.Map<EmployeeSimpleResponse>(identityEmployee)
            )
            .ToListAsync();

        return employees;
    }

    public async Task<EmployeeDetailedResponse> GetDetailedEmployeeAsync(string id)
    {
        var identityEmployee = await GetEmployeesWithRoles()
            .Where(employee => employee.Id == id)
            .SingleOrDefaultAsync() ?? throw new EmployeeNotFoundException(id);


        var employee = _mapper.Map<EmployeeDetailedResponse>(identityEmployee);

        return employee;
    }

    public async Task<EmployeeDetailedResponse> GetDetailedEmployeeAsync(ClaimsPrincipal principal)
    {
        var id = GetEmployeeId(principal);

        return await GetDetailedEmployeeAsync(id);
    }

    public async Task UpdateEmployeeAsync(EmployeeManagerUpdateRequest employee)
    {
        var identityEmployee = await UpdateEmployeeAsync(employee as EmployeeUpdateRequest);

        var currentRoles = await _userManager.GetRolesAsync(identityEmployee);

        var newRoleNames = employee.RoleNames;

        var roleNamesToRemove = currentRoles.Except(newRoleNames);

        var roleNamesToAdd = newRoleNames.Except(currentRoles);


        // remove roles
        var roleRemovalResult = await _userManager.RemoveFromRolesAsync(identityEmployee, roleNamesToRemove);

        if (!roleRemovalResult.Succeeded)
        {
            throw new ApplicationException($"Unable to remove roles for employee with Id {employee.Id}");
        }


        // add roles
        var roleAdditionResult = await _userManager.AddToRolesAsync(identityEmployee, roleNamesToAdd);

        if (!roleAdditionResult.Succeeded)
        {
            throw new ApplicationException($"Unable to add roles for employee with Id {employee.Id}");
        }

    }

    public async Task UpdateEmployeeAsync(EmployeeAccountUpdateRequest employee)
    {
        await UpdateEmployeeAsync(employee as EmployeeUpdateRequest);
    }

    public async Task TerminateEmployeeAsync(string id)
    {
        var employee = await GetEmployeeWithId(id);

        if (employee.TerminationDate is not null)
        {
            throw new ApplicationException($"Can not terminate already terminated employee with id '{id}'");
        }

        employee.TerminationDate = DateTime.UtcNow;

        await _userManager.UpdateAsync(employee);
    }

    public async Task RenewEmployeeAsync(string id)
    {
        var employee = await GetEmployeeWithId(id);

        if (employee.TerminationDate is null)
        {
            throw new ApplicationException($"Can not renew active employee with id '{id}'");
        }

        employee.TerminationDate = null;
        employee.StartDate = DateTime.UtcNow;

        await _userManager.UpdateAsync(employee);
    }

    public async Task<NavigationMenuItem[]> GetNavigationMenuItemsAsync(ClaimsPrincipal principal)
    {
        var employeeId = GetEmployeeId(principal);

        var employee = await GetEmployeesWithRoles()
            .ThenInclude(role => role.PermittedNavigationMenuItems)
            .Where(employee => employee.Id == employeeId)
            .SingleOrDefaultAsync() ?? throw new EmployeeNotFoundException(principal);

        return employee.Roles
            .Select(junction => junction.Role)
            .SelectMany(role => role.PermittedNavigationMenuItems)
            .ToArray();
    }



    private async Task<IdentityEmployee> GetEmployeeWithId(string id)
    {
        return await _userManager.FindByIdAsync(id) ?? throw new EmployeeNotFoundException(id);
    }

    private string GetEmployeeId(ClaimsPrincipal principal)
    {
        return _userManager.GetUserId(principal) ?? throw new EmployeeNotFoundException(principal);
    }

    private async Task ThrowIfUsernameExists(string username)
    {
        var employee = await _userManager.FindByNameAsync(username);

        if (employee is not null)
        {
            throw new NameDuplicateException($"Employee with username '{username}' already exists");
        }
    }

    private IIncludableQueryable<IdentityEmployee, IdentityEmployeeRole> GetEmployeesWithRoles()
    {
        var employee = _userManager.Users
            .Include(employee => employee.Roles)
            .ThenInclude(junction => junction.Role);

        return employee;
    }

    private async Task<IdentityEmployee> UpdateEmployeeAsync(EmployeeUpdateRequest employee)
    {
        var identityEmployee = await GetEmployeeWithId(employee.Id);


        await ThrowIfEmployeeWithGivenUsernameHasDifferentId(employee.Username, employee.Id);


        _mapper.Map(employee, identityEmployee);


        var updateResult = await _userManager.UpdateAsync(identityEmployee);

        if (!updateResult.Succeeded)
        {
            throw new ApplicationException($"Unable to update employee with Id '{employee.Id}'");
        }

        return identityEmployee;
    }

    private async Task ThrowIfEmployeeWithGivenUsernameHasDifferentId(string username, string id)
    {
        var employee = await _userManager.FindByNameAsync(username);

        if (employee is not null && employee.Id != id)
        {
            throw new NameDuplicateException($"Employee with username '{username}' already exists");
        }
    }
}

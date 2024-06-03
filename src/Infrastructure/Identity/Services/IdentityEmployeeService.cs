using Mailjet.Client.Resources;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Nika1337.Library.ApplicationCore.Abstractions;
using Nika1337.Library.ApplicationCore.Entities;
using Nika1337.Library.ApplicationCore.Exceptions;
using Nika1337.Library.Infrastructure.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Nika1337.Library.Infrastructure.Identity.Services;

internal class IdentityEmployeeService : IEmployeeService
{
    private readonly RoleManager<IdentityEmployeeRole> _roleManager;
    private readonly UserManager<IdentityEmployee> _userManager;

    public IdentityEmployeeService(
        RoleManager<IdentityEmployeeRole> roleManager,
        UserManager<IdentityEmployee> userManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
    }

    public Task<IEnumerable<EmployeeRole>> GetAllEmployeeRolesAsync()
    {
        var identityEmployeeRoles = _roleManager.Roles
            .Include(role => role.NavigationMenuItems)
            .AsEnumerable();

        var employeeRoles = identityEmployeeRoles.ToEmployeeRoles();


        return Task.FromResult(employeeRoles);
    }

    public Task<IEnumerable<EmployeeRole>> GetEmployeeRolesByRoleNames(IEnumerable<string> roleNames)
    {
        var identityRoles = _roleManager.Roles
            .Include(role => role.NavigationMenuItems)
            .Where(role => roleNames.Contains(role.Name));

        var employeeRoles = identityRoles.ToEmployeeRoles();

        return Task.FromResult(employeeRoles);
    }

    public IEnumerable<Employee> GetAllEmployees<TKey>(
        Expression<Func<Employee, TKey>>? keySelector,
        bool isAscending,
        string searchTerm,
        bool shouldIncludeTerminated)
    {
        var employees =
            _userManager.Users
            .Select(
                identityEmployee => new Employee
                {
                    FirstName = identityEmployee.FirstName,
                    LastName = identityEmployee.LastName,
                    Username = identityEmployee.UserName!,
                    IdNumber = identityEmployee.IdNumber,
                    DateOfBirth = identityEmployee.DateOfBirth,
                    StartDate = identityEmployee.StartDate,
                    PhoneNumber = identityEmployee.PhoneNumber,
                    Email = identityEmployee.Email,
                    IsActive = identityEmployee.TerminationDate == null
                }
            );

        if (!shouldIncludeTerminated)
        {
            employees = employees.Where(e => e.IsActive);
        }

        if (!string.IsNullOrEmpty(searchTerm))
        {
            employees = employees
                .Where(e => 
                    e.FirstName.Contains(searchTerm) ||
                    e.LastName.Contains(searchTerm) ||
                    e.Username.Contains(searchTerm)
                );

        }

        if (keySelector is not null)
        {
            employees = isAscending ? employees.OrderBy(keySelector) : employees.OrderByDescending(keySelector);
        }


        return employees;
    }

    public async Task<DetailedEmployee> GetDetailedEmployeeAsync(string username)
    {
        var identityEmployee = await _userManager.FindByNameAsync(username) ?? throw new EmployeeNotFoundException(username);

        var employee = await identityEmployee.ToEmployee(_userManager, _roleManager);

        return employee;
    }

    public async Task<DetailedEmployee> GetDetailedEmployeeAsync(ClaimsPrincipal principal)
    {
        var identityEmployee = await _userManager.GetUserAsync(principal) ?? throw new EmployeeNotFoundException(principal);

        var employee = await identityEmployee.ToEmployee(_userManager, _roleManager);
        return employee;
    }

    public async Task UpdateDetailedEmployee(string oldUsername, DetailedEmployee employee)
    {
        var identityEmployee = await _userManager.FindByNameAsync(oldUsername) ?? throw new EmployeeNotFoundException(oldUsername);

        if (oldUsername != employee.Username && await _userManager.FindByNameAsync(employee.Username) is not null)
        {
            throw new DuplicateException($"Employee with username '{employee.Username}' already exists");
        }

        identityEmployee.FirstName = employee.FirstName;
        identityEmployee.LastName = employee.LastName;
        identityEmployee.UserName = employee.Username;
        identityEmployee.IdNumber = employee.IdNumber;
        identityEmployee.DateOfBirth = employee.DateOfBirth;
        identityEmployee.Salary = employee.Salary;
        identityEmployee.Gender = employee.Gender;
        identityEmployee.PhoneNumber = employee.PhoneNumber;
        identityEmployee.Email = employee.Email;
        identityEmployee.Address = employee.Address;
        identityEmployee.StartDate = employee.StartDate;
        identityEmployee.TerminationDate = employee.TerminationDate;

        var updateResult = await _userManager.UpdateAsync(identityEmployee);

        if (!updateResult.Succeeded)
        {
            throw new ApplicationException($"Unable to update employee with old username '{oldUsername}'");
        }

        var currentRoles = await _userManager.GetRolesAsync(identityEmployee);

        var newRoleNames = employee.Roles.Select(employeeRole => employeeRole.Name);

        var roleNamesToRemove = currentRoles.Except(newRoleNames);

        var roleNamesToAdd = newRoleNames.Except(currentRoles);

        // remove roles
        var roleRemovalResult = await _userManager.RemoveFromRolesAsync(identityEmployee, roleNamesToRemove);

        if (!roleRemovalResult.Succeeded)
        {
            throw new ApplicationException($"Unable to remove roles for user with new username {identityEmployee.UserName}");
        }

        // add roles
        var roleAdditionResult = await _userManager.AddToRolesAsync(identityEmployee, roleNamesToAdd);

        if (!roleAdditionResult.Succeeded)
        {
            throw new ApplicationException();
        }
    }
}

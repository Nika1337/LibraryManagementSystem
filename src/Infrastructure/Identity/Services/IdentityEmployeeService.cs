using Mailjet.Client.Resources;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Nika1337.Library.ApplicationCore.Abstractions;
using Nika1337.Library.ApplicationCore.Entities;
using Nika1337.Library.ApplicationCore.Exceptions;
using Nika1337.Library.Infrastructure.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

    public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
    {
        var identityEmployees = _userManager.Users.AsEnumerable();
        var employees = await identityEmployees.ToEmployees(_userManager, _roleManager);

        return employees;
    }

    public async Task<Employee> GetEmployeeAsync(string username)
    {
        var identityEmployee = await _userManager.FindByNameAsync(username) ?? throw new EmployeeNotFoundException(username);

        var employee = await identityEmployee.ToEmployee(_userManager, _roleManager);

        return employee;
    }

    public async Task<Employee> GetEmployeeAsync(ClaimsPrincipal principal)
    {
        var identityEmployee = await _userManager.GetUserAsync(principal) ?? throw new EmployeeNotFoundException(principal);

        var employee = await identityEmployee.ToEmployee(_userManager, _roleManager);
        return employee;
    }

    public async Task UpdateEmployee(string oldUsername, Employee employee)
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

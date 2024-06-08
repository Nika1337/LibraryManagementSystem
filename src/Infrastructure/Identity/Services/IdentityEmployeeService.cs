using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.ApplicationCore.Entities;
using Nika1337.Library.ApplicationCore.Exceptions;
using Nika1337.Library.Infrastructure.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Data;
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

    public async Task<IEnumerable<EmployeeRole>> GetAllEmployeeRolesAsync()
    {
        var identityEmployeeRoles = await _roleManager.Roles.ToListAsync();

        var employeeRoles = identityEmployeeRoles.ToEmployeeRoles();


        return employeeRoles;
    }

    public Task<IEnumerable<EmployeeRole>> GetEmployeeRolesByRoleNames(IEnumerable<string> roleNames)
    {
        var identityRoles = _roleManager.Roles
            .Where(role => roleNames.Contains(role.Name));

        var employeeRoles = identityRoles.ToEmployeeRoles();

        return Task.FromResult(employeeRoles);
    }

    public async Task<IEnumerable<Employee>> GetAllEmployees()
    {
        var employees = await _userManager.Users
            .Select(
                identityEmployee => new Employee
                {
                    Id = identityEmployee.Id,
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
            )
            .ToListAsync();



        return employees;
    }

    public async Task<DetailedEmployee> GetDetailedEmployeeAsync(string id)
    {
        var identityEmployee = await _userManager.FindByIdAsync(id) ?? throw new EmployeeNotFoundException(id);

        var employee = await identityEmployee.ToEmployee(_userManager, _roleManager);

        return employee;
    }

    public async Task<DetailedEmployee> GetDetailedEmployeeAsync(ClaimsPrincipal principal)
    {
        var identityEmployee = await _userManager.GetUserAsync(principal) ?? throw new EmployeeNotFoundException(principal);

        var employee = await identityEmployee.ToEmployee(_userManager, _roleManager);
        return employee;
    }

    public async Task UpdateDetailedEmployee(DetailedEmployee employee)
    {
        var identityEmployee = await _userManager.FindByIdAsync(employee.Id) ?? throw new EmployeeNotFoundException(employee.Id);

        var employeeWithSameName = await _userManager.FindByNameAsync(employee.Username);

        if (employeeWithSameName is not null && employeeWithSameName.Id != employee.Id)
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
            throw new ApplicationException($"Unable to update employee with Id '{employee.Id}'");
        }

        var currentRoles = await _userManager.GetRolesAsync(identityEmployee);

        var newRoleNames = employee.Roles.Select(employeeRole => employeeRole.Name);

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
            throw new ApplicationException();
        }
    }

    public async Task<NavigationMenuItem[]> GetNavigationMenuItemsFor(ClaimsPrincipal principal)
    {
        var employeeId = _userManager.GetUserId(principal) ?? throw new EmployeeNotFoundException(principal);

        var employee = await _userManager.Users
            .Include(employee => employee.Roles)
            .ThenInclude(junction => junction.Role)
            .ThenInclude(role => role.PermittedNavigationMenuItems)
            .Where(employee => employee.Id == employeeId)
            .SingleOrDefaultAsync() ?? throw new EmployeeNotFoundException(principal);

        return employee.Roles
            .Select(junction => junction.Role)
            .SelectMany(role => role.PermittedNavigationMenuItems)
            .ToArray();
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Nika1337.Library.ApplicationCore.Entities;
using Nika1337.Library.Infrastructure.Identity.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nika1337.Library.Infrastructure.Identity.Services;

internal static class Extensions
{
    internal static DetailedEmployee ToEmployee(this IdentityEmployee identityEmployee, ICollection<EmployeeRole> roles)
    {
        var employee = new DetailedEmployee
        {
            FirstName = identityEmployee.FirstName,
            LastName = identityEmployee.LastName,
            Username = identityEmployee.UserName!,
            IdNumber = identityEmployee.IdNumber,
            DateOfBirth = identityEmployee.DateOfBirth,
            Salary = identityEmployee.Salary,
            StartDate = identityEmployee.StartDate,
            PhoneNumber = identityEmployee.PhoneNumber,
            Email = identityEmployee.Email,
            Address = identityEmployee.Address,
            Gender = identityEmployee.Gender,
            TerminationDate = identityEmployee.TerminationDate,
            Roles = roles
        };

        return employee;
    }

    internal async static Task<DetailedEmployee> ToEmployee(
        this IdentityEmployee identityEmployee,
        UserManager<IdentityEmployee> userManager,
        RoleManager<IdentityEmployeeRole> roleManager)
    {
        var identityEmployeeRoleNames = await userManager.GetRolesAsync(identityEmployee);
        var identityEmployeeRoles = roleManager.Roles
            .Include(role => role.NavigationMenuItems)
            .Where(role => identityEmployeeRoleNames.Contains(role.Name!));

        var employeeRoles = identityEmployeeRoles.ToEmployeeRoles();

        var employee = identityEmployee.ToEmployee(employeeRoles.ToArray());

        return employee;
    }

    internal async static Task<IEnumerable<DetailedEmployee>> ToEmployees(
      this IEnumerable<IdentityEmployee> identityEmployees,
      UserManager<IdentityEmployee> userManager,
      RoleManager<IdentityEmployeeRole> roleManager)
    {
        var employees = new List<DetailedEmployee>();

        foreach (var identityEmployee in identityEmployees)
        {
            var employee = await identityEmployee.ToEmployee(userManager, roleManager);
            employees.Add(employee);
        }

        return employees;
    }



    internal static EmployeeRole ToEmployeeRole(this IdentityEmployeeRole identityEmployeeRole)
    {
        var employeeRole = new EmployeeRole(identityEmployeeRole.Name!, identityEmployeeRole.NavigationMenuItems);

        return employeeRole;
    }

    internal static IEnumerable<EmployeeRole> ToEmployeeRoles(this IEnumerable<IdentityEmployeeRole> identityEmployeeRoles)
    {
        return identityEmployeeRoles.Select(identityRole => identityRole.ToEmployeeRole());
    }

    internal static IdentityEmployeeRole ToIdentityEmployeeRole(this EmployeeRole employeeRole)
    {
        var identityEmployeeRole = new IdentityEmployeeRole
        {
            Name = employeeRole.Name,
            NavigationMenuItems = employeeRole.PermittedNavigationMenuItems
        };

        return identityEmployeeRole;
    }
}

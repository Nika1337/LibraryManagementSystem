

using Nika1337.Library.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Nika1337.Library.ApplicationCore.Abstractions;

public interface IEmployeeService
{
    Task<IEnumerable<EmployeeRole>> GetAllEmployeeRolesAsync();
    Task<IEnumerable<EmployeeRole>> GetEmployeeRolesByRoleNames(IEnumerable<string> roleNames);
    Task<DetailedEmployee> GetDetailedEmployeeAsync(string username);
    Task<DetailedEmployee> GetDetailedEmployeeAsync(ClaimsPrincipal principal);
    IEnumerable<Employee> GetAllEmployees<TKey>(
        Expression<Func<Employee, TKey>>? keySelector,
        bool isAscending,
        string searchTerm,
        bool shouldIncludeTerminated);
    Task UpdateDetailedEmployee(string oldUsername, DetailedEmployee employee);
}

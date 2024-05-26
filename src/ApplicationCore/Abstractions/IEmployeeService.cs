

using Nika1337.Library.ApplicationCore.Entities;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Nika1337.Library.ApplicationCore.Abstractions;

public interface IEmployeeService
{
    Task<IEnumerable<EmployeeRole>> GetAllEmployeeRolesAsync();
    Task<IEnumerable<EmployeeRole>> GetEmployeeRolesByRoleNames(IEnumerable<string> roleNames);
    Task<Employee> GetEmployeeAsync(string username);
    Task<Employee> GetEmployeeAsync(ClaimsPrincipal principal);
    Task<IEnumerable<Employee>> GetAllEmployeesAsync();
    Task UpdateEmployee(string oldUsername, Employee employee);
}

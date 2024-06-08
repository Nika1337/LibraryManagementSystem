using Nika1337.Library.ApplicationCore.Entities;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Nika1337.Library.ApplicationCore.Abstractions;

public interface IEmployeeService
{
    Task<IEnumerable<Employee>> GetAllEmployees();
    Task<DetailedEmployee> GetDetailedEmployeeAsync(string id);
    Task<DetailedEmployee> GetDetailedEmployeeAsync(ClaimsPrincipal principal);
    Task<NavigationMenuItem[]> GetNavigationMenuItemsFor(ClaimsPrincipal principal);
    Task UpdateDetailedEmployee(DetailedEmployee employee);
}

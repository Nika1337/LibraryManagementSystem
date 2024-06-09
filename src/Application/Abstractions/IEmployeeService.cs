
using Nika1337.Library.Application.DataTransferObjects;
using Nika1337.Library.ApplicationCore.Entities;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Nika1337.Library.Application.Abstractions;

public interface IEmployeeService
{
    Task RegisterEmployeeAsync(EmployeeRegistrationRequest employee);
    Task<IEnumerable<EmployeeSimpleResponse>> GetAllEmployees();
    Task<EmployeeDetailedResponse> GetDetailedEmployeeAsync(string id);
    Task<EmployeeDetailedResponse> GetDetailedEmployeeAsync(ClaimsPrincipal principal);
    Task UpdateEmployee(Employee employee);
    Task UpdateEmployee(EmployeeManagerUpdateRequest employee);
    Task UpdateEmployee(EmployeeAccountUpdateRequest employee);
    Task<NavigationMenuItem[]> GetNavigationMenuItemsFor(ClaimsPrincipal principal);
}

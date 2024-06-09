
using Nika1337.Library.Application.DataTransferObjects;
using Nika1337.Library.ApplicationCore.Entities;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Nika1337.Library.Application.Abstractions;

public interface IEmployeeService
{
    Task RegisterEmployeeAsync(EmployeeRegistrationRequest employee);
    Task<IEnumerable<EmployeeSimpleResponse>> GetAllEmployeesAsync();
    Task<EmployeeDetailedResponse> GetDetailedEmployeeAsync(string id);
    Task<EmployeeDetailedResponse> GetDetailedEmployeeAsync(ClaimsPrincipal principal);
    Task UpdateEmployeeAsync(EmployeeManagerUpdateRequest employee);
    Task UpdateEmployeeAsync(EmployeeAccountUpdateRequest employee);
    Task TerminateEmployeeAsync(string id);
    Task RenewEmployeeAsync(string id);
    Task<NavigationMenuItem[]> GetNavigationMenuItemsAsync(ClaimsPrincipal principal);
}

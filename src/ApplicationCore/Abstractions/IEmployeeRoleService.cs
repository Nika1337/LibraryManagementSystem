using Nika1337.Library.ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nika1337.Library.ApplicationCore.Abstractions;

public interface IEmployeeRoleService
{
    Task<string[]> GetAllEmployeeRoleNamesAsync();
}

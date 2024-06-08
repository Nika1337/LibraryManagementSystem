

using System.Threading.Tasks;

namespace Nika1337.Library.Application.Abstractions;

public interface IEmployeeRoleService
{
    Task<string[]> GetAllEmployeeRoleNamesAsync();
}

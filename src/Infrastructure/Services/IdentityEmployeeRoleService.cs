using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.Infrastructure.Identity.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Nika1337.Library.Infrastructure.Services;

internal class IdentityEmployeeRoleService : IEmployeeRoleService
{
    private readonly RoleManager<IdentityEmployeeRole> _roleManager;

    public IdentityEmployeeRoleService(RoleManager<IdentityEmployeeRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task<string[]> GetAllEmployeeRoleNamesAsync()
    {
        var identityRoles = _roleManager.Roles;

        var roles = identityRoles
            .Select(identityRole => identityRole.Name!);

        var rolesList = await roles.ToListAsync();

        return [.. rolesList];
    }
}

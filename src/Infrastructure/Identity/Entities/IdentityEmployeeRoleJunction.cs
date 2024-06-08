using Microsoft.AspNetCore.Identity;

namespace Nika1337.Library.Infrastructure.Identity.Entities;

internal class IdentityEmployeeRoleJunction : IdentityUserRole<string>
{
    public IdentityEmployee User { get; set; }
    public IdentityEmployeeRole Role { get; set; }
}

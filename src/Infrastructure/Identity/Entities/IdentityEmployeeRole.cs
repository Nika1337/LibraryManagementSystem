using Microsoft.AspNetCore.Identity;
using Nika1337.Library.ApplicationCore.Entities;
using System.Collections.Generic;

namespace Nika1337.Library.Infrastructure.Identity.Entities;

internal class IdentityEmployeeRole : IdentityRole
{
    public ICollection<NavigationMenuItem> PermittedNavigationMenuItems { get; } = [];
}

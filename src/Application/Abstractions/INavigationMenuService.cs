
using Nika1337.Library.ApplicationCore.Entities;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Nika1337.Library.Application.Abstractions;

public interface INavigationMenuService
{
    Task<ICollection<NavigationMenuItem>> GetPermittedNavigationMenuItemsFor(ClaimsPrincipal principal);
}

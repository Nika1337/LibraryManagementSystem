using Microsoft.AspNetCore.Mvc;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nika1337.Library.Presentation.Components;

public class NavigationViewComponent : ViewComponent
{
    private readonly INavigationMenuService _navigationMenuService;
    public NavigationViewComponent(INavigationMenuService navigationMenuService, IEmployeeService employeeService)
    {
        _navigationMenuService = navigationMenuService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        if (!UserClaimsPrincipal?.Identity?.IsAuthenticated ?? true)
        {
            return View(Enumerable.Empty<NavigationMenuItem>());
        }

        IEnumerable<NavigationMenuItem> navigationMenuItems = await _navigationMenuService.GetPermittedNavigationMenuItemsFor(UserClaimsPrincipal!);

        return View(navigationMenuItems);
    }
}

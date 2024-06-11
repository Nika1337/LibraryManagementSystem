using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.ApplicationCore.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Nika1337.Library.ApplicationCore.Services;

internal class NavigationMenuService : INavigationMenuService
{
    private readonly IEmployeeService _employeeService;

    public NavigationMenuService(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    public async Task<ICollection<NavigationMenuItem>> GetPermittedNavigationMenuItemsFor(ClaimsPrincipal principal)
    {
        var unfilteredNavigationMenuItems = await GetUnfilteredNavigationMenuItemsFor(principal);

        var filteredNavigationMenuItems = FilterNonAccessibleChildren(unfilteredNavigationMenuItems);

        return filteredNavigationMenuItems; 
    }

    private async Task<NavigationMenuItem[]> GetUnfilteredNavigationMenuItemsFor(ClaimsPrincipal principal)
    {
        return await _employeeService.GetNavigationMenuItemsAsync(principal);
    }


    private static NavigationMenuItem[] FilterNonAccessibleChildren(NavigationMenuItem[] menuItems)
    {
        var parentItems = menuItems.Where(nmi => nmi.ParentNavigationMenuItemId is null)
            .DistinctBy(item => item.Id);

        var childItems = menuItems.Where(nmi => nmi.ParentNavigationMenuItemId is not null)
            .DistinctBy(item => item.Id)
            .ToList();

        foreach (var parentItem in parentItems)
        {
            RemoveAllChildrenNotIn(parentItem, childItems);
        }
        return [.. parentItems];
    }

    private static void RemoveAllChildrenNotIn(NavigationMenuItem parentItem, List<NavigationMenuItem> childItems)
    {
        if (childItems == null || childItems.Count == 0)
        {
            parentItem.ChildNavigationMenuItems?.Clear();
            return;
        }
        else if (parentItem.ChildNavigationMenuItems == null || parentItem.ChildNavigationMenuItems.Count == 0)
        {
            return;
        }
        else
        {

            foreach (var childItem in parentItem.ChildNavigationMenuItems)
            {
                if (childItems.Remove(childItem))
                {
                    RemoveAllChildrenNotIn(childItem, childItems);
                }
                else
                {
                    parentItem.ChildNavigationMenuItems.Remove(childItem);
                }
            }

        }
    }
}

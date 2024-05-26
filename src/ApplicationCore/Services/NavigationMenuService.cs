using Nika1337.Library.ApplicationCore.Abstractions;
using Nika1337.Library.ApplicationCore.Entities;
using Nika1337.Library.ApplicationCore.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nika1337.Library.Infrastructure.Identity.Services;

public class NavigationMenuService(IEmployeeService employeeService) : INavigationMenuService
{
    private readonly IEmployeeService _employeeService = employeeService;

    public async Task<ICollection<NavigationMenuItem>> GetPermittedNavigationMenuItemsFor(string userName)
    {
        var identityEmployee = await _employeeService.GetEmployeeAsync(userName) ?? throw new EmployeeNotFoundException(userName);

        return GetPermittedNavigationMenuItemsFor(identityEmployee);
    }
    private static NavigationMenuItem[] GetPermittedNavigationMenuItemsFor(Employee employee)
    {
        var unfilteredNavigationMenuItems = GetUnfilteredNavigationMenuItemsFor(employee);
        var filteredNavigationMenuItems = FilterNonAccessibleChildren(unfilteredNavigationMenuItems);

        return filteredNavigationMenuItems;
    }

    private static NavigationMenuItem[] GetUnfilteredNavigationMenuItemsFor(Employee employee)
    {
        return employee.Roles
            .SelectMany(role => role.PermittedNavigationMenuItems).ToArray();
    }


    private static NavigationMenuItem[] FilterNonAccessibleChildren(NavigationMenuItem[] menuItems)
    {
        var parentItems = menuItems.Where(nmi => nmi.ParentNavigationMenuItemId is null);

        var childItems = menuItems.Where(nmi => nmi.ParentNavigationMenuItemId is not null).ToList();

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

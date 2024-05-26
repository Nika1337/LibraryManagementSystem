

using System.Collections.Generic;

namespace Nika1337.Library.ApplicationCore.Entities;

public class EmployeeRole
{
    public EmployeeRole(
        string name,
        ICollection<NavigationMenuItem> permittedNavigationMenuItems)
    {
        Name = name;
        PermittedNavigationMenuItems = permittedNavigationMenuItems;
    }

    public string Name { get; private set; }
    public ICollection<NavigationMenuItem> PermittedNavigationMenuItems { get; private init; }
}

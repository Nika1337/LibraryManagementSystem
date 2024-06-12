using System.Collections.Generic;

namespace Nika1337.Library.Domain.Entities;

public class NavigationMenuItem
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Route { get; set; }
    public int? ParentNavigationMenuItemId { get; set; }
    public ICollection<NavigationMenuItem> ChildNavigationMenuItems { get; set; } = [];
}

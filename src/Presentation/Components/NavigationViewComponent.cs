using Microsoft.AspNetCore.Mvc;
using Nika1337.Library.ApplicationCore.Abstractions;
using Nika1337.Library.ApplicationCore.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Nika1337.Library.Presentation.Components;

public class NavigationViewComponent : ViewComponent
{
    private readonly INavigationMenuService _navigationMenuService;
    private readonly IEmployeeService _employeeService;

    private List<NavigationMenuItem> GenerateSampleData()
    {
        var menuItems = new List<NavigationMenuItem>();

        // Top-level menu items
        var home = new NavigationMenuItem { Id = 1, Name = "Home", Route = "/home" };
        var about = new NavigationMenuItem { Id = 2, Name = "About", Route = "/about" };
        var services = new NavigationMenuItem { Id = 3, Name = "Services", Route = "/services" };

        // Nested menu items
        var products = new NavigationMenuItem { Id = 4, Name = "Products", Route = "/products" };
        var software = new NavigationMenuItem { Id = 5, Name = "Software", Route = "/software" };
        var hardware = new NavigationMenuItem { Id = 6, Name = "Hardware", Route = "/hardware" };

        hardware.ChildNavigationMenuItems.Add(home);
        // Adding nested items to "Products"
        products.ChildNavigationMenuItems.Add(software);
        products.ChildNavigationMenuItems.Add(hardware);
   

        // Building the menu structure
        menuItems.Add(home);
        menuItems.Add(about);
        menuItems.Add(services);
        menuItems.Add(products);

        return menuItems;
    }
    public NavigationViewComponent(INavigationMenuService navigationMenuService, IEmployeeService employeeService)
    {
        _navigationMenuService = navigationMenuService;
        _employeeService = employeeService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        if (!UserClaimsPrincipal?.Identity?.IsAuthenticated ?? true)
        {
            return View(Enumerable.Empty<NavigationMenuItem>());
        }

        IEnumerable<NavigationMenuItem> navigationMenuItems = await _navigationMenuService.GetPermittedNavigationMenuItemsFor(UserClaimsPrincipal!);

        //navigationMenuItems = GenerateSampleData();

        //var navigationMenuItems = GenerateSampleData();

        return View(navigationMenuItems);
    }
}

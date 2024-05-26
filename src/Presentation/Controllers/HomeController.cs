using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nika1337.Library.Presentation.Models;
using Nika1337.Library.Presentation.Models.EmployeeAccount;
using System.Diagnostics;

namespace Web.Controllers;

[Authorize]
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

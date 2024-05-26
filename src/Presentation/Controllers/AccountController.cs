using Microsoft.AspNetCore.Mvc;

namespace Nika1337.Library.Presentation.Controllers;

public class AccountController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}

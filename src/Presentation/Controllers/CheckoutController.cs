using Microsoft.AspNetCore.Mvc;

namespace Nika1337.Library.Presentation.Controllers;

public class CheckoutController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}

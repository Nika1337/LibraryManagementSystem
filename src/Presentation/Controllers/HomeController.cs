using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Authorize]
[Route("Home/[action]")]
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }


    public IActionResult Error()
    {
        var feature = HttpContext.Features.Get<IExceptionHandlerFeature>();
        return View(feature?.Error);
    }

    [AllowAnonymous]
    public IActionResult AccessDenied()
    {
        return View();
    }

    public new IActionResult StatusCode(int code)
    {
        return View(code);
    }
}

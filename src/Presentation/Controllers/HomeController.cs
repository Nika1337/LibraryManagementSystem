using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Authorize]
public class HomeController : Controller
{
    [Route("/")]
    public IActionResult Index()
    {
        return View();
    }


    [Route("Home/[action]")]
    public IActionResult Error()
    {
        var feature = HttpContext.Features.Get<IExceptionHandlerFeature>();
        return View(feature?.Error);
    }

    [Route("Home/[action]")]
    [AllowAnonymous]
    public IActionResult AccessDenied()
    {
        return View();
    }

    [Route("Home/[action]")]
    public new IActionResult StatusCode(int code)
    {
        return View(code);
    }
}

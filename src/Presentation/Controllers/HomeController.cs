using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Authorize]
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }


    [Route("Home/Error")]
    public IActionResult Error()
    {
        var feature = HttpContext.Features.Get<IExceptionHandlerFeature>();
        return View(feature?.Error);
    }

    [AllowAnonymous]
    [Route("Home/AccessDenied")]
    public IActionResult AccessDenied()
    {
        return View();
    }

    [Route("Home/StatusCode")]
    public IActionResult StatusCode(int code)
    {
        return View(code);
    }
}

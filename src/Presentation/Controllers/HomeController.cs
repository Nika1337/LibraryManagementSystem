using Microsoft.AspNetCore.Authorization;
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
    public new IActionResult NotFound()
    {
        return View();
    }

    [Route("Home/[action]")]
    [AllowAnonymous]
    public IActionResult AccessDenied()
    {
        return View();
    }

    [Route("Home/[action]")]
    public new IActionResult Error()
    {
        return View();
    }
}

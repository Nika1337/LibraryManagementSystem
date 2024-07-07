using Microsoft.AspNetCore.Mvc;
using Nika1337.Library.Application.Abstractions;
using System.Threading.Tasks;
namespace Nika1337.Library.Presentation.Controllers;

public abstract class BaseModelController : Controller
{
    private readonly IBaseModelService _service;

    protected BaseModelController(IBaseModelService service)
    {
        _service = service;
    }


    [HttpPost("Delete/{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);

        return Ok();
    }

    [HttpPost("Renew/{id:int}")]
    public async Task<IActionResult> Renew(int id)
    {
        await _service.RenewAsync(id);

        return Ok();
    }
}

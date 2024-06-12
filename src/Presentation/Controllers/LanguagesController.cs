using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.Application.DataTransferObjects.Library.Languages;
using Nika1337.Library.Domain.Exceptions;
using Nika1337.Library.Presentation.Models.Languages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nika1337.Library.Presentation.Controllers;

[Authorize(Roles = "Core Librarian")]
[Route("Books/Languages")]
public class LanguagesController : Controller
{
    private readonly IMapper _mapper;
    private readonly ILanguageService _genreService;

    public LanguagesController(
        IMapper mapper,
        ILanguageService genreService)
    {
        _mapper = mapper;
        _genreService = genreService;
    }

    [HttpGet(Name = "Languages")]
    public async Task<IActionResult> Languages()
    {
        var genres = await _genreService.GetLanguagesAsync();

        var model = _mapper.Map<IEnumerable<LanguageViewModel>>(genres);

        return View(model);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Languages(int id)
    {
        var genre = await _genreService.GetLanguageAsync(id);

        var model = _mapper.Map<LanguageDetailViewModel>(genre);

        return View("Language", model);
    }

    [HttpPost("{id:int}")]
    public async Task<IActionResult> Languages(LanguageDetailViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View("Language", model);
        }

        var request = _mapper.Map<LanguageUpdateRequest>(model);

        try
        {
            await _genreService.UpdateLanguageAsync(request);
        }
        catch (NameDuplicateException)
        {
            model.ErrorMessage = $"Language with name '{model.Name}' already exists";
            return View("Language", model);
        }

        return RedirectToRoute("Languages");
    }

    [HttpGet("[action]")]
    public IActionResult AddLanguage()
    {
        var model = new LanguageCreateViewModel();

        return View(model);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> AddLanguage(LanguageCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var request = _mapper.Map<LanguageCreateRequest>(model);

        try
        {
            await _genreService.CreateLanguageAsync(request);
        }
        catch (NameDuplicateException)
        {
            model.ErrorMessage = $"Language with name '{model.Name}' already exists";
            return View(model);
        }

        return RedirectToAction(nameof(Languages));
    }


    [HttpPost("[action]/{id:int}")]
    public async Task<IActionResult> DeleteLanguage(int id)
    {
        await _genreService.DeleteLanguageAsync(id);

        return Ok();
    }

    [HttpPost("[action]/{id:int}")]
    public async Task<IActionResult> RenewLanguage(int id)
    {
        await _genreService.RenewLanguageAsync(id);

        return Ok();
    }
}

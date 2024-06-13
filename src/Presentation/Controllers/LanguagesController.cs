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
    private readonly ILanguageService _languageService;

    public LanguagesController(
        IMapper mapper,
        ILanguageService languageService)
    {
        _mapper = mapper;
        _languageService = languageService;
    }

    [HttpGet(Name = "Languages")]
    public async Task<IActionResult> Languages()
    {
        var languages = await _languageService.GetLanguagesAsync();

        var model = _mapper.Map<IEnumerable<LanguageViewModel>>(languages);

        return View(model);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Languages(int id)
    {
        var language = await _languageService.GetLanguageAsync(id);

        var model = _mapper.Map<LanguageDetailViewModel>(language);

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
            await _languageService.UpdateLanguageAsync(request);
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
            await _languageService.CreateLanguageAsync(request);
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
        await _languageService.DeleteLanguageAsync(id);

        return Ok();
    }

    [HttpPost("[action]/{id:int}")]
    public async Task<IActionResult> RenewLanguage(int id)
    {
        await _languageService.RenewLanguageAsync(id);

        return Ok();
    }
}

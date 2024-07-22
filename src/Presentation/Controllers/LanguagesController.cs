using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.Application.DataTransferObjects.Library.Languages;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.Exceptions;
using Nika1337.Library.Domain.RequestFeatures;
using Nika1337.Library.Presentation.Models;
using Nika1337.Library.Presentation.Models.Languages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nika1337.Library.Presentation.Controllers;

[Authorize(Roles = "Librarian, Consultant")]
[Route("Languages")]
public class LanguagesController : BaseModelController<Language>
{
    private readonly IMapper _mapper;
    private readonly ILanguageService _languageService;

    protected override Dictionary<string, SortOption<Language>> SortOptions =>
     new()
     {
            { "name", new("Name: A - Z", language => language.Name) },
            { "nameDesc",new( "Name: Z - A", language => language.Name, true) }
     };


    public LanguagesController(
        IMapper mapper,
        ILanguageService languageService) : base(languageService)
    {
        _mapper = mapper;
        _languageService = languageService;
    }

    [HttpGet(Name = "Languages")]
    public async Task<IActionResult> Languages(
        int pageNumber = 1, 
        int pageSize = 10,
        string? searchTerm = null, 
        string? sortField = null,
        bool doNotIncludeDeleted = false)
    {
        var request = ConstructBaseModelPagedRequest(pageNumber, pageSize, searchTerm, sortField, !doNotIncludeDeleted);

        var languages = await _languageService.GetPagedLanguagesAsync(request);

        var model = _mapper.Map<PagedList<LanguageViewModel>>(languages);

        return View(model);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Languages(int id)
    {
        var language = await _languageService.GetLanguageAsync(id);

        var model = _mapper.Map<LanguageDetailedViewModel>(language);

        return View("Language", model);
    }

    [Authorize(Roles = "Librarian")]
    [HttpPost("{id:int}")]
    public async Task<IActionResult> Languages(LanguageDetailedViewModel model)
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

    [Authorize(Roles = "Librarian")]
    [HttpGet("[action]")]
    public IActionResult AddLanguage()
    {
        var model = new LanguageCreateViewModel();

        return View(model);
    }

    [Authorize(Roles = "Librarian")]
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


    [HttpGet("[action]")]
    public async Task<IActionResult> GetActiveLanguagePreviews()
    {
        var languages = await _languageService.GetActiveLanguagePreviewsAsync();

        return Ok(languages);
    }
}

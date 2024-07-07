using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.Application.DataTransferObjects.Library.Genres;
using Nika1337.Library.Domain.Exceptions;
using Nika1337.Library.Presentation.Models.Genres;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nika1337.Library.Presentation.Controllers;

[Authorize(Roles = "Core Librarian")]
[Route("Books/Genres")]
public class GenresController : BaseModelController
{
    private readonly IMapper _mapper;
    private readonly IGenreService _genreService;

    public GenresController(
        IMapper mapper,
        IGenreService genreService) : base(genreService)
    {
        _mapper = mapper;
        _genreService = genreService;
    }

    [HttpGet(Name = "Genres")]
    public async Task<IActionResult> Genres()
    {
        var genres = await _genreService.GetGenresAsync();

        var model = _mapper.Map<IEnumerable<GenreViewModel>>(genres);

        return View(model);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Genres(int id)
    {
        var genre = await _genreService.GetGenreAsync(id);

        var model = _mapper.Map<GenreDetailViewModel>(genre);

        return View("Genre", model);
    }

    [HttpPost("{id:int}")]
    public async Task<IActionResult> Genres(GenreDetailViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View("Genre", model);
        }

        var request = _mapper.Map<GenreUpdateRequest>(model);

        try
        {
            await _genreService.UpdateGenreAsync(request);
        }
        catch (NameDuplicateException)
        {
            model.ErrorMessage = $"Genre with name '{model.Name}' already exists";
            return View("Genre", model);
        }

        return RedirectToRoute("Genres");
    }

    [HttpGet("[action]")]
    public IActionResult AddGenre()
    {
        var model = new GenreCreateViewModel();

        return View(model);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> AddGenre(GenreCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var request = _mapper.Map<GenreCreateRequest>(model);

        try
        {
            await _genreService.CreateGenreAsync(request);
        }
        catch (NameDuplicateException)
        {
            model.ErrorMessage = $"Genre with name '{model.Name}' already exists";
            return View(model);
        }

        return RedirectToAction(nameof(Genres));
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetActiveGenrePreviews(string query)
    {
        var genres = await _genreService.GetActiveGenrePreviewsAsync();

        return Ok(genres);
    }
}

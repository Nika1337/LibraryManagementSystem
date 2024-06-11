
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.Presentation.Models.Genres;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nika1337.Library.Presentation.Controllers;

[Authorize(Roles = "Core Librarian")]
[Route("Books/Genres")]
public class GenresController : Controller
{
    private readonly IMapper _mapper;
    private readonly IGenreService _genreService;

    public GenresController(
        IMapper mapper,
        IGenreService genreService)
    {
        _mapper = mapper;
        _genreService = genreService;
    }

    [HttpGet]
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

        var model = _mapper.Map<GenreViewModel>(genre);

        return View(model);
    }

}

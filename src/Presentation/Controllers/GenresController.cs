﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.Application.DataTransferObjects.Library.Genres;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.Exceptions;
using Nika1337.Library.Domain.RequestFeatures;
using Nika1337.Library.Presentation.Models;
using Nika1337.Library.Presentation.Models.Genres;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nika1337.Library.Presentation.Controllers;

[Authorize(Roles = "Librarian, Consultant")]
[Route("Genres")]
public class GenresController : BaseModelController<Genre>
{
    private readonly IMapper _mapper;
    private readonly IGenreService _genreService;

    protected override Dictionary<string, SortOption<Genre>> SortOptions =>
     new()
     {
            { "name", new("Name: A - Z", genre => genre.Name) },
            { "nameDesc",new( "Name: Z - A", genre => genre.Name, true) }
     };

    public GenresController(
        IMapper mapper,
        IGenreService genreService) : base(genreService)
    {
        _mapper = mapper;
        _genreService = genreService;
    }

    [HttpGet(Name = "Genres")]
    public async Task<IActionResult> Genres(
        int pageNumber = 1, 
        int pageSize = 10, 
        string? searchTerm = null, 
        string? sortField = null,
        bool doNotIncludeDeleted = false)
    {
        var request = ConstructBaseModelPagedRequest(pageNumber, pageSize, searchTerm, sortField, !doNotIncludeDeleted);

        var genres = await _genreService.GetPagedGenresAsync(request);

        var model = _mapper.Map<PagedList<GenrePreviewViewModel>>(genres);

        return View(model);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Genres(int id)
    {
        var genre = await _genreService.GetGenreAsync(id);

        var model = _mapper.Map<GenreDetailViewModel>(genre);

        return View("Genre", model);
    }

    [Authorize(Roles = "Librarian")]
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

    [Authorize(Roles = "Librarian")]
    [HttpGet("[action]")]
    public IActionResult AddGenre()
    {
        var model = new GenreCreateViewModel();

        return View(model);
    }

    [Authorize(Roles = "Librarian")]
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
    public async Task<IActionResult> GetActiveGenres(string query)
    {
        var genres = await _genreService.GetActiveGenresAsync();

        return Ok(genres);
    }
}

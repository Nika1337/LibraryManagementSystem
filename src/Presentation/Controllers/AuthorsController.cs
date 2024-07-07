using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.Application.DataTransferObjects.Library.Authors;
using Nika1337.Library.Presentation.Models.Authors;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nika1337.Library.Presentation.Controllers;

[Authorize(Roles = "Core Librarian")]
[Route("Books/Authors")]
public class AuthorsController : BaseModelController
{
    private readonly IMapper _mapper;
    private readonly IAuthorService _authorService;

    public AuthorsController(
        IMapper mapper,
        IAuthorService authorService) : base(authorService)
    {
        _mapper = mapper;
        _authorService = authorService;
    }

    [HttpGet(Name = "Authors")]
    public async Task<IActionResult> Authors()
    {
        var authors = await _authorService.GetAuthorsAsync();

        var model = _mapper.Map<IEnumerable<AuthorViewModel>>(authors);

        return View(model);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Authors(int id)
    {
        var author = await _authorService.GetAuthorAsync(id);

        var model = _mapper.Map<AuthorDetailViewModel>(author);

        return View("Author", model);
    }

    [HttpPost("{id:int}")]
    public async Task<IActionResult> Authors(AuthorDetailViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View("Author", model);
        }

        var request = _mapper.Map<AuthorUpdateRequest>(model);

        await _authorService.UpdateAuthorAsync(request);

        return RedirectToRoute("Authors");
    }

    [HttpGet("[action]")]
    public IActionResult AddAuthor()
    {
        var model = new AuthorCreateViewModel();

        return View(model);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> AddAuthor(AuthorCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var request = _mapper.Map<AuthorCreateRequest>(model);

        await _authorService.CreateAuthorAsync(request);

        return RedirectToAction(nameof(Authors));
    }


    [HttpGet("[action]")]
    public async Task<IActionResult> GetActiveAuthorPreviews()
    {
        var authors = await _authorService.GetActiveAuthorPreviewsAsync();

        return Ok(authors);
    }
}

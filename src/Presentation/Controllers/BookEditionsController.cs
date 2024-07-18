
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.Application.DataTransferObjects.Library.BookEditions;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.Exceptions;
using Nika1337.Library.Domain.RequestFeatures;
using Nika1337.Library.Presentation.Models;
using Nika1337.Library.Presentation.Models.BookEditions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nika1337.Library.Presentation.Controllers;


[Authorize(Roles = "Librarian")]
[Route("Books/{bookId:int}/BookEditions")]
public class BookEditionsController : BaseModelController<BookEdition>
{
    private readonly IMapper _mapper;
    private readonly IBookEditionService _bookEditionService;
    protected override Dictionary<string, SortOption<BookEdition>> SortOptions =>
        new()
        {
            { "publicationDate", new("Publication Date: Oldest to Newest", edition => edition.PublicationDate) },
            { "publicationDateDesc", new("Publication Date: Newest to Oldest", edition => edition.PublicationDate, true) },
            { "pageCount", new("Page Count: Ascending", edition => edition.PageCount ?? 0) },
            { "pageCountDesc", new("Page Count: Descending", edition => edition.PageCount ?? 0, true) },
            { "copiesCount", new("Total Copies Count: Ascending", edition => edition.Copies.Count) },
            { "copiesCountDesc", new("Total Copies Count: Descending", edition => edition.Copies.Count, true) }
        };

    public BookEditionsController(
        IMapper mapper,
        IBookEditionService bookEditionService) : base(bookEditionService)
    {
        _mapper = mapper;
        _bookEditionService = bookEditionService;
    }

    [HttpGet(Name = "BookEditions")]
    public async Task<IActionResult> BookEditions(
        int bookId,
        int pageNumber = 1,
        int pageSize = 10,
        string? searchTerm = null,
        string? sortField = null,
        bool doNotIncludeDeleted = false)
    {
        var request = ConstructBaseModelPagedRequest(pageNumber, pageSize, searchTerm, sortField, !doNotIncludeDeleted);

        var bookEditions = await _bookEditionService.GetPagedBookEditionsAsync(bookId, request);

        var model = _mapper.Map<PagedList<BookEditionPreviewViewModel>>(bookEditions);

        return View(model);
    }

    [HttpGet("[action]")]
    public IActionResult AddBookEdition()
    {
        var model = new BookEditionCreateViewModel();

        return View(model);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> AddBookEdition(int bookId, BookEditionCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var request = _mapper.Map<BookEditionCreateRequest>(model);

        try
        {
            await _bookEditionService.CreateBookEditionAsync(bookId, request);
        }
        catch (IsbnDuplicateException)
        {
            model.ErrorMessage = $"Book Edition with Isbn '{model.Isbn}' already exists";
            return View(model);
        }

        return RedirectToAction(nameof(BookEditions));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> BookEditions(int bookId, int id)
    {
        var bookEdition = await _bookEditionService.GetBookEditionAsync(bookId, id);

        var model = _mapper.Map<BookEditionDetailedViewModel>(bookEdition);

        return View("BookEdition", model);
    }

    [HttpPost("{id:int}")]
    public async Task<IActionResult> BookEditions(int bookId, BookEditionDetailedViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View("BookEdition", model);
        }

        var request = _mapper.Map<BookEditionUpdateRequest>(model);

        try
        {
            await _bookEditionService.UpdateBookEditionAsync(bookId, request);
        }
        catch (IsbnDuplicateException)
        {
            model.ErrorMessage = $"Book Edition with Isbn '{model.Isbn}' already exists";
            return View("BookEdition", model);
        }

        return RedirectToRoute("BookEditions");
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetAvaliableBookEditions(int bookId)
    {
        var bookEditions = await _bookEditionService.GetAvaliableBookEditionsAsync(bookId);

        return Ok(bookEditions);
    }
}

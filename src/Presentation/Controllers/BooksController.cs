using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.Application.DataTransferObjects.Library;
using Nika1337.Library.Application.DataTransferObjects.Library.Books;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.RequestFeatures;
using Nika1337.Library.Presentation.Models.Books;
using System.Linq.Expressions;
using System;
using System.Threading.Tasks;

namespace Nika1337.Library.Presentation.Controllers;

[Authorize(Roles = "Librarian")]
[Route("Books")]
public class BooksController : BaseModelController
{
    private readonly IMapper _mapper;
    private readonly IBookService _bookService;

    public BooksController(
        IMapper mapper,
        IBookService bookService) : base(bookService)
    {
        _mapper = mapper;
        _bookService = bookService;
    }

    [HttpGet(Name = "Books")]
    public async Task<IActionResult> Books(int pageNumber = 1, int pageSize = 10, string? searchTerm = null, string? sortField = null)
    {
        var request = ConstructBaseModelPagedRequest(pageNumber, pageSize, searchTerm, sortField);

        var books = await _bookService.GetPagedBooksAsync(request);

        var model = _mapper.Map<PagedList<BookViewModel>>(books);

        return View(model);
    }

    [HttpGet("[action]")]
    public IActionResult AddBook()
    {
        var model = new BookCreateViewModel();

        return View(model);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> AddBook(BookCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var request = _mapper.Map<BookCreateRequest>(model);

        await _bookService.CreateBookAsync(request);

        return RedirectToRoute("Books");
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Books(int id)
    {
        var book = await _bookService.GetBookAsync(id);
        
        var model = _mapper.Map<BookDetailViewModel>(book);

        return View("Book", model);
    }

    [HttpPost("{id:int}")]
    public async Task<IActionResult> Books(BookDetailViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View("Book", model);
        }

        var request = _mapper.Map<BookUpdateRequest>(model);

        await _bookService.UpdateBookAsync(request);

        return RedirectToRoute("Books");
    }

    private static BaseModelPagedRequest<Book> ConstructBaseModelPagedRequest(int pageNumber, int pageSize, string? searchTerm, string? sortField)
    {

        Expression<Func<Book, object?>>? orderBy = null;
        bool isDescending = false;

        switch (sortField)
        {
            case "titleDesc":
                orderBy = book => book.Title;
                isDescending = true;
                break;
            case "title":
                orderBy = book => book.Title;
                isDescending = false;
                break;
            case "releaseDateDesc":
                orderBy = book => book.OriginalReleaseDate;
                isDescending = true;
                break;
            case "releaseDate":
                orderBy = book => book.OriginalReleaseDate;
                isDescending = false;
                break;
        }


        return new BaseModelPagedRequest<Book>
        {
            PageNumber = pageNumber,
            PageSize = pageSize,
            SearchTerm = searchTerm,
            OrderBy = orderBy,
            IsDescending = isDescending
        };
    }
}

﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.Application.DataTransferObjects.Library;
using Nika1337.Library.Application.DataTransferObjects.Library.Books;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.RequestFeatures;
using Nika1337.Library.Presentation.Models.Books;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Nika1337.Library.Presentation.Models;

namespace Nika1337.Library.Presentation.Controllers;

[Authorize(Roles = "Librarian")]
[Route("Books")]
public class BooksController : BaseModelController<Book>
{
    private readonly IMapper _mapper;
    private readonly IBookService _bookService;

    protected override Dictionary<string, SortOption<Book>> SortOptions =>
        new()
        {
            { "title", new("Title: A - Z", book => book.Title) },
            { "titleDesc", new("Title: Z - A", book => book.Title, true) },
            { "releaseDate", new( "Release Date: Ascending", book => book.OriginalReleaseDate) },
            { "releaseDateDesc", new( "Release Date: Descending", book => book.OriginalReleaseDate, true) }
        };

    public BooksController(
        IMapper mapper,
        IBookService bookService) : base(bookService)
    {
        _mapper = mapper;
        _bookService = bookService;
    }

    [HttpGet(Name = "Books")]
    public async Task<IActionResult> Books(int pageNumber = 1, int pageSize = 10, string? searchTerm = null, string? sortField = null, bool shouldIncludeDeleted = true)
    {
        var request = ConstructBaseModelPagedRequest(pageNumber, pageSize, searchTerm, sortField, shouldIncludeDeleted);

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
}

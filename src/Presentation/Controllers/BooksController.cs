using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.Application.DataTransferObjects.Library.Books;
using Nika1337.Library.Presentation.Models.Books;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nika1337.Library.Presentation.Controllers;

[Authorize(Roles = "Librarian")]
[Route("Books")]
public class BooksController : Controller
{
    private readonly IMapper _mapper;
    private readonly IBookService _bookService;

    public BooksController(
        IMapper mapper,
        IBookService bookService)
    {
        _mapper = mapper;
        _bookService = bookService;
    }

    [HttpGet(Name = "Books")]
    public async Task<IActionResult> Books()
    {
        var books = await _bookService.GetBooksAsync();

        var model = _mapper.Map<IEnumerable<BookViewModel>>(books);

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

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("get");
        Console.WriteLine(model.OriginalLanguageId);
        Console.WriteLine(model.AuthorIds);
        Console.WriteLine(model.GenreIds);
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();

        return View("Book", model);
    }

    [HttpPost("{id:int}")]
    public async Task<IActionResult> Books(BookDetailViewModel model)
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("post");
        Console.WriteLine(model.OriginalLanguageId);
        Console.WriteLine(model.AuthorIds);
        Console.WriteLine(model.GenreIds);
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        if (!ModelState.IsValid)
        {
            return View("Book", model);
        }

        var request = _mapper.Map<BookUpdateRequest>(model);

        await _bookService.UpdateBookAsync(request);

        return RedirectToRoute("Books");
    }


    [HttpPost("[action]/{id:int}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        await _bookService.DeleteAsync(id);

        return Ok();
    }

    [HttpPost("[action]/{id:int}")]
    public async Task<IActionResult> RenewBook(int id)
    {
        await _bookService.RenewAsync(id);

        return Ok();
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.Application.DataTransferObjects.Library.Authors;
using Nika1337.Library.Application.DataTransferObjects.Library.Books;
using Nika1337.Library.Application.DataTransferObjects.Library.Genres;
using Nika1337.Library.Application.DataTransferObjects.Library.Languages;
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
    private readonly IGenreService _genreService;
    private readonly ILanguageService _languageService;
    private readonly IAuthorService _authorService;
    public BooksController(
        IMapper mapper,
        IBookService bookService,
        IAuthorService authorService,
        ILanguageService languageService,
        IGenreService genreService)
    {
        _mapper = mapper;
        _bookService = bookService;
        _authorService = authorService;
        _languageService = languageService;
        _genreService = genreService;
    }

    [HttpGet(Name = "Books")]
    public async Task<IActionResult> Books()
    {
        var books = await _bookService.GetBooksAsync();

        var model = _mapper.Map<IEnumerable<BookViewModel>>(books);

        return View(model);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> AddBook()
    {
        var model = new BookCreateViewModel();

        ViewBag.Languages = await GetLanguages();
        ViewBag.Genres = await GetGenres();
        ViewBag.Authors = await GetAuthors();

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

        ViewBag.Languages = await GetLanguages();
        ViewBag.Genres = await GetGenres();
        ViewBag.Authors = await GetAuthors();

        return View("Book", model);
    }

    [HttpPost("{id:int}")]
    public async Task<IActionResult> Books(BookDetailViewModel model)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Languages = await GetLanguages();
            ViewBag.Genres = await GetGenres();
            ViewBag.Authors = await GetAuthors();
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

    private async Task<IEnumerable<LanguagePreviewResponse>> GetLanguages()
    {
        var languages = await _languageService.GetActiveLanguagePreviewsAsync();

        return languages;
    }

    private async Task<IEnumerable<GenrePreviewResponse>> GetGenres()
    {
        var genres = await _genreService.GetActiveGenrePreviewsAsync();

        return genres;
    }

    private async Task<IEnumerable<AuthorPreviewResponse>> GetAuthors()
    {
        var authors = await _authorService.GetActiveAuthorPreviewsAsync();

        return authors;
    }
}

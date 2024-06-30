using AutoMapper;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.Application.DataTransferObjects.Library.Books;
using Nika1337.Library.Domain.Abstractions;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.Exceptions;
using Nika1337.Library.Domain.Specifications.Authors;
using Nika1337.Library.Domain.Specifications.Books;
using Nika1337.Library.Domain.Specifications.Genres;
using Nika1337.Library.Domain.Specifications.Languages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nika1337.Library.Infrastructure.Services;

internal class BookService : BaseModelService<Book>, IBookService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Genre> _genreRepository;
    private readonly IRepository<Language> _languageRepository;
    private readonly IRepository<Author> _authorRepository;

    public BookService(
        IRepository<Book> repository,
        IMapper mapper,
        IRepository<Language> languageRepository,
        IRepository<Genre> genreRepository,
        IRepository<Author> authorRepository) : base(repository)
    {
        _mapper = mapper;
        _languageRepository = languageRepository;
        _genreRepository = genreRepository;
        _authorRepository = authorRepository;
    }

    public async Task<IEnumerable<BookPreviewResponse>> GetBooksAsync()
    {
        var specification = new BookPreviewSpecification();

        var books = await _repository.ListAsync(specification);

        var result = _mapper.Map<IEnumerable<BookPreviewResponse>>(books);

        return result;
    }

    public async Task<BookDetailedResponse> GetBookAsync(int id)
    {
        var specification = new BookDetailedByIdSpecification(id);

        var book = await _repository.SingleOrDefaultAsync(specification) ?? throw new NotFoundException<Book>(id);

        var result = _mapper.Map<BookDetailedResponse>(book);

        return result;
    }

    public async Task CreateBookAsync(BookCreateRequest request)
    {
        var book = _mapper.Map<Book>(request);


        await AddOriginalLanguage(book, request.OriginalLanguageId);

        await AddGenres(book, request.GenreIds);

        await AddAuthors(book, request.AuthorIds);


        await _repository.AddAsync(book);

        await _repository.SaveChangesAsync();
    }

    public async Task UpdateBookAsync(BookUpdateRequest request)
    { 
        var book = await GetEntityAsync(request.Id);

        _mapper.Map(request, book);


        await AddOriginalLanguage(book, request.OriginalLanguageId);

        await AddGenres(book, request.GenreIds);

        await AddAuthors(book, request.AuthorIds);

        await _repository.UpdateAsync(book);
    }



    private async Task AddOriginalLanguage(Book book, int languageId)
    {
        var specification = new LanguageWithIdSpecification(languageId);

        var language = await _languageRepository.SingleOrDefaultAsync(specification) ?? throw new NotFoundException<Language>(languageId);

        book.OriginalLanguage = language;
    }

    private async Task AddGenres(Book book, int[] genreIds)
    {
        // Fetch current genres for the book
        var specificationByBookId = new GenresByBookIdSpecification(book.Id);

        var currentGenres = await _genreRepository.ListAsync(specificationByBookId);

        // Fetch new genres
        var specificationByGenreIds = new GenresByIdsSpecification(genreIds);

        var newGenres = await _genreRepository.ListAsync(specificationByGenreIds);

        // Determine genres to add and remove
        var genresToRemove = currentGenres.Except(newGenres);

        var genresToAdd = newGenres.Except(currentGenres);


        // Remove genres
        foreach (var genre in genresToRemove)
        {
            book.Genres.Remove(genre);
        }

        // Add genres
        foreach (var genre in genresToAdd)
        {
            book.Genres.Add(genre);
        }
    }

    private async Task AddAuthors(Book book, int[] authorIds)
    {
        // Fetch current authors for the book
        var specificationByBookId = new AuthorsByBookIdSpecification(book.Id);

        var currentAuthors = await _authorRepository.ListAsync(specificationByBookId);

        // Fetch new authors
        var specificationByAuthorIds = new AuthorsByIdsSpecification(authorIds);

        var newAuthors = await _authorRepository.ListAsync(specificationByAuthorIds);

        // Determine authors to add and remove
        var authorsToRemove = currentAuthors.Except(newAuthors);

        var authorsToAdd = newAuthors.Except(currentAuthors);


        // Remove authors
        foreach (var author in authorsToRemove)
        {
            book.Authors.Remove(author);
        }

        // Add authors
        foreach (var author in authorsToAdd)
        {
            book.Authors.Add(author);
        }
    }
}

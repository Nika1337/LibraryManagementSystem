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
        var genreSpecification = new GenresWithIdsSpecification(genreIds);

        var genres = await _genreRepository.ListAsync(genreSpecification);

        if (genreIds.Length != genres.Count)
        {
            throw new NotFoundException<Genre>(genreIds);
        }

        book.Genres.Clear();
        book.Genres.AddRange(genres);
    }

    private async Task AddAuthors(Book book, int[] authorIds)
    {
        var authorSpecification = new AuthorsWithIdsSpecification(authorIds);

        var authors = await _authorRepository.ListAsync(authorSpecification);

        if (authorIds.Length != authors.Count)
        {
            throw new NotFoundException<Genre>(authorIds);
        }

        book.Authors.Clear();
        book.Authors.AddRange(authors);
    }
}

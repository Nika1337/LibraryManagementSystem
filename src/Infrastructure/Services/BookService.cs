using AutoMapper;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.Application.DataTransferObjects.Library;
using Nika1337.Library.Application.DataTransferObjects.Library.Books;
using Nika1337.Library.Domain.Abstractions;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.Exceptions;
using Nika1337.Library.Domain.RequestFeatures;
using Nika1337.Library.Domain.Specifications.Authors;
using Nika1337.Library.Domain.Specifications.Books;
using Nika1337.Library.Domain.Specifications.Genres;
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

    public async Task<IEnumerable<PrimitiveResponse>> GetAvaliableBooksAsync()
    {
        var specification = new AvaliableBooksSpecification();

        var books = await _repository.ListAsync(specification);

        var response = _mapper.Map<IEnumerable<PrimitiveResponse>>(books);

        return response;
    }

    public async Task<PagedList<BookPreviewResponse>> GetPagedBooksAsync(BaseModelPagedRequest<Book> request)
    {
        var specificationParameters = _mapper.Map<BaseModelSpecificationParameters<Book>>(request);

        var specification = new BookPreviewsSpecification(specificationParameters);


        var books = await _repository.PagedListAsync(specification, request.PageNumber, request.PageSize);

        var result = _mapper.Map<PagedList<BookPreviewResponse>>(books);

        return result;
    }

    public async Task<BookDetailedResponse> GetBookAsync(int id)
    {
        var book = await GetDetailedBookAsync(id);

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
    }

    public async Task UpdateBookAsync(BookUpdateRequest request)
    { 
        var book = await GetDetailedBookAsync(request.Id);

        _mapper.Map(request, book);

        await AddOriginalLanguage(book, request.OriginalLanguageId);

        await AddGenres(book, request.GenreIds);

        await AddAuthors(book, request.AuthorIds);


        await _repository.UpdateAsync(book);
    }



    private async Task AddOriginalLanguage(Book book, int languageId)
    {
        var language = await _languageRepository.GetByIdAsync(languageId) ?? throw new NotFoundException<Language>(languageId);

        book.OriginalLanguage = language;
    }

    private async Task AddGenres(Book book, int[] genreIds)
    {
        var currentGenres = book.Genres.ToArray();

        // Fetch new genres
        var specificationByGenreIds = new GenresByIdsSpecification(genreIds);

        var newGenres = await _genreRepository.ListAsync(specificationByGenreIds);

        if (newGenres.Count != genreIds.Length)
        {
            throw new NotFoundException<Genre>(genreIds);
        }

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
        var currentAuthors = book.Authors.ToArray();

        // Fetch new authors
        var specificationByAuthorIds = new AuthorsByIdsSpecification(authorIds);

        var newAuthors = await _authorRepository.ListAsync(specificationByAuthorIds);

        if (newAuthors.Count != authorIds.Length)
        {
            throw new NotFoundException<Author>(authorIds);
        }


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

    private async Task<Book> GetDetailedBookAsync(int id)
    {
        var specification = new BookDetailedByIdSpecification(id);

        var book = await _repository.SingleOrDefaultAsync(specification) ?? throw new NotFoundException<Book>(id);

        return book;
    }
}

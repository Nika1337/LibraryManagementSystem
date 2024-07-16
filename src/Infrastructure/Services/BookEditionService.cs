using AutoMapper;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.Application.DataTransferObjects.Library;
using Nika1337.Library.Application.DataTransferObjects.Library.BookEditions;
using Nika1337.Library.Domain.Abstractions;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.Exceptions;
using Nika1337.Library.Domain.RequestFeatures;
using Nika1337.Library.Domain.Specifications.BookEditions;
using Nika1337.Library.Domain.Specifications.BookEditions.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nika1337.Library.Infrastructure.Services;

internal class BookEditionService : BaseModelService<BookEdition>, IBookEditionService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Book> _bookRepository;
    private readonly IRepository<Language> _languageRepository;
    private readonly IRepository<Genre> _genreRepository;
    private readonly IRepository<Room> _roomRepository;
    public BookEditionService(
        IRepository<BookEdition> repository,
        IMapper mapper,
        IRepository<Book> bookRepository,
        IRepository<Language> languageRepository,
        IRepository<Genre> genreRepository,
        IRepository<Room> roomRepository) : base(repository)
    {
        _mapper = mapper;
        _bookRepository = bookRepository;
        _languageRepository = languageRepository;
        _genreRepository = genreRepository;
        _roomRepository = roomRepository;
    }

    public async Task<IEnumerable<BookEditionPrimitiveResponse>> GetAvaliableBookEditionsAsync(int bookId)
    {
        var specification = new AvailableBookEditionsSpecification(bookId);

        var bookEditions = await _repository.ListAsync(specification);

        var response = _mapper.Map<IEnumerable<BookEditionPrimitiveResponse>>(bookEditions);

        return response;
    }
    public async Task<PagedList<BookEditionPreviewResponse>> GetPagedBookEditionsAsync(int bookId, BaseModelPagedRequest<BookEdition> request)
    {
        var specificationParameters = _mapper.Map<BaseModelSpecificationParameters<BookEdition>>(request);

        var specification = new BookEditionSpecification(bookId, specificationParameters);

        var bookEditions = await _repository.PagedListAsync(specification, request.PageNumber, request.PageSize);

        var response = _mapper.Map<PagedList<BookEditionPreviewResponse>>(bookEditions);

        return response;
    }

    public async Task<BookEditionDetailedResponse> GetBookEditionAsync(int bookId, int id)
    {
        var bookEdition = await GetDetailedBookEditionAsync(bookId, id);

        var response = _mapper.Map<BookEditionDetailedResponse>(bookEdition);
        
        return response;
    }

    public Task CreateBookEditionAsync(int bookId, BookEditionCreateRequest request)
    {
        throw new System.NotImplementedException();
    }


    public Task UpdateBookEditionAsync(int bookId, BookEditionUpdateRequest request)
    {
        throw new System.NotImplementedException();
    }

    private async Task<BookEditionByIdResult> GetDetailedBookEditionAsync(int bookId, int id)
    {
        var specification = new BookEditionByIdSpecification(bookId, id);

        var bookEdition = await _repository.SingleOrDefaultAsync(specification)
            ?? throw new NotFoundException<BookEdition>($"No Book Edition Found with Book Id '{bookId}' and Id '{id}'");

        return bookEdition;
    }
}

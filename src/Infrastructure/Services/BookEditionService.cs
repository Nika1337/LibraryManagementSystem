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
using System.Linq;
using System.Threading.Tasks;

namespace Nika1337.Library.Infrastructure.Services;

internal class BookEditionService : BaseModelService<BookEdition>, IBookEditionService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Book> _bookRepository;
    private readonly IRepository<Language> _languageRepository;
    private readonly IRepository<Room> _roomRepository;
    private readonly IRepository<Publisher> _publisherRepository;
    public BookEditionService(
        IRepository<BookEdition> repository,
        IMapper mapper,
        IRepository<Book> bookRepository,
        IRepository<Language> languageRepository,
        IRepository<Room> roomRepository,
        IRepository<Publisher> publisherRepository) : base(repository)
    {
        _mapper = mapper;
        _bookRepository = bookRepository;
        _languageRepository = languageRepository;
        _roomRepository = roomRepository;
        _publisherRepository = publisherRepository;
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

    public async Task CreateBookEditionAsync(int bookId, BookEditionCreateRequest request)
    {
        await ThrowIfIsbnExistsAsync(request.Isbn);

        var bookEdition = _mapper.Map<BookEdition>(request);

        await AddBookAsync(bookEdition, bookId);
        await AddLanguageAsync(bookEdition, request.LanguageId);
        await AddPublisherAsync(bookEdition, request.PublisherId);
        await AddRoomAsync(bookEdition, request.RoomId);

        AddCopies(bookEdition, request.CopiesCount);

        await _repository.AddAsync(bookEdition);
    }
    public async Task UpdateBookEditionAsync(int bookId, BookEditionUpdateRequest request)
    {
        await ThrowIfBookEditionWithGivenIsbnHasDifferentIdAsync(request.Isbn, bookId);

        var bookEdition = await GetEntityAsync(request.Id);

        _mapper.Map(request, bookEdition);

        await AddLanguageAsync(bookEdition, request.LanguageId);
        await AddPublisherAsync(bookEdition, request.PublisherId);
        await AddRoomAsync(bookEdition, request.RoomId);

        await _repository.UpdateAsync(bookEdition);
    }



    private async Task<BookEditionByIdResult> GetDetailedBookEditionAsync(int bookId, int id)
    {
        var specification = new BookEditionByIdSpecification(bookId, id);

        var bookEdition = await _repository.SingleOrDefaultAsync(specification)
            ?? throw new NotFoundException<BookEdition>($"No Book Edition Found with Book Id '{bookId}' and Id '{id}'");

        return bookEdition;
    }

    private async Task ThrowIfIsbnExistsAsync(string isbn)
    {
        var specification = new BookEditionByIsbnSpecification(isbn);

        var isIsbnUsed = await _repository.AnyAsync(specification);

        if (isIsbnUsed)
        {
            throw new IsbnDuplicateException(isbn);
        }
    }

    private async Task ThrowIfBookEditionWithGivenIsbnHasDifferentIdAsync(string isbn, int id)
    {
        var specification = new BookEditionByIsbnSpecification(isbn);

        var bookEdition = await _repository.SingleOrDefaultAsync(specification);

        var isIsbnUsedByDifferentBookEdition = bookEdition is not null && bookEdition.Id != id;

        if (isIsbnUsedByDifferentBookEdition)
        {
            throw new IsbnDuplicateException(isbn);
        }
    }

    private async Task AddBookAsync(BookEdition bookEdition, int bookId)
    {
        var book = await _bookRepository.GetByIdAsync(bookId) ?? throw new NotFoundException<Book>(bookId);

        bookEdition.Book = book;
    }

    private async Task AddLanguageAsync(BookEdition bookEdition, int languageId)
    {
        var language = await _languageRepository.GetByIdAsync(languageId) ?? throw new NotFoundException<Language>(languageId);

        bookEdition.Language = language;
    }

    private async Task AddPublisherAsync(BookEdition bookEdition, int publisherId)
    {
        var publisher = await _publisherRepository.GetByIdAsync(publisherId) ?? throw new NotFoundException<Publisher>(publisherId);

        bookEdition.Publisher = publisher;
    }

    private async Task AddRoomAsync(BookEdition bookEdition, int roomId)
    {
        var room = await _roomRepository.GetByIdAsync(roomId) ?? throw new NotFoundException<Room>(roomId);

        bookEdition.Room = room;
    }

    private static void AddCopies(BookEdition bookEdition, int copiesCount)
    {
        var bookCopy = new BookCopy { BookEdition = bookEdition };

        var newBookCopies = Enumerable.Repeat(bookCopy, copiesCount);

        bookEdition.Copies.AddRange(newBookCopies);
    }

}

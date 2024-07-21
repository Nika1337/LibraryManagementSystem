using AutoMapper;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.Application.DataTransferObjects.Library;
using Nika1337.Library.Application.DataTransferObjects.Library.Checkouts;
using Nika1337.Library.Domain.Abstractions;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.Exceptions;
using Nika1337.Library.Domain.RequestFeatures;
using Nika1337.Library.Domain.Specifications.BookEditions;
using Nika1337.Library.Domain.Specifications.Checkouts;
using Nika1337.Library.Domain.Specifications.Checkouts.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nika1337.Library.Infrastructure.Services;

internal class CheckoutService : BaseModelService<Checkout>, ICheckoutService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Account> _accountRepository;
    private readonly IRepository<BookEdition> _bookEditionRepository;

    public CheckoutService(
        IRepository<Checkout> repository,
        IMapper mapper,
        IRepository<Account> accountRepository,
        IRepository<BookEdition> bookEditionRepository) : base(repository)
    {
        _mapper = mapper;
        _accountRepository = accountRepository;
        _bookEditionRepository = bookEditionRepository;
    }

    public async Task<PagedList<CheckoutPreviewResponse>> GetPagedCheckoutsAsync(BaseModelPagedRequest<Checkout> request)
    {
        var specificationParameters = _mapper.Map<BaseModelSpecificationParameters<Checkout>>(request);

        var specification = new CheckoutSpecification(specificationParameters);

        var checkouts = await _repository.PagedListAsync(specification, request.PageNumber, request.PageSize);

        var response = _mapper.Map<PagedList<CheckoutPreviewResponse>>(checkouts);

        return response;
    }

    public async Task<CheckoutDetailedResponse> GetCheckoutAsync(int id)
    {
        var checkout = await GetDetailedCheckoutAsync(id);

        var response = _mapper.Map<CheckoutDetailedResponse>(checkout);

        return response;
    }

    public async Task CreateCheckoutAsync(CheckoutCreateRequest request)
    {
        var checkout = _mapper.Map<Checkout>(request);

        var copies = await GetCopiesToAddIfAvailable(checkout, request.BookId, request.BookEditionId, request.CopiesCount);

        AddBookCopyCheckouts(checkout, copies);

        await AddAccountAsync(checkout, request.AccountId);


        await _repository.AddAsync(checkout);
    }

    public async Task CloseCheckoutAsync(CheckoutCloseRequest request)
    {
        var checkout = await GetCheckoutWithBookCopyCheckouts(request.Id);

        ThrowIfCopiesDontMatch(request, checkout);

        var now = DateTime.UtcNow;
        var bookCopyCheckouts = checkout.BookCopyCheckouts.ToList();

        var statusUpdates = new[]
        {
            (request.ReturnedCopiesCount, BookCopyCheckoutStatus.BookCopyReturned),
            (request.LostCopiesCount, BookCopyCheckoutStatus.BookCopyLost),
            (request.DamagedCopiesCount, BookCopyCheckoutStatus.BookCopyReturnedDamaged),
            (request.DestroyedCopiesCount, BookCopyCheckoutStatus.BookCopyReturnedDestroyed)
        };

        var index = 0;

        foreach (var (count, status) in statusUpdates)
        {
            index = SetStatus(bookCopyCheckouts, count, status, index, now);
        }

        await _repository.UpdateAsync(checkout);
    }



    private async Task<IEnumerable<BookCopy>> GetCopiesToAddIfAvailable(Checkout checkout, int bookId, int bookEditionId, int copiesCount)
    {
        var specification = new BookEditionWithAvailableCopies(bookId, bookEditionId);

        var bookEdition = await _bookEditionRepository.SingleOrDefaultAsync(specification) ?? throw new NotFoundException<BookEdition>(bookEditionId);

        if (bookEdition.Copies.Count < copiesCount)
        {
            throw new NotEnoughBookCopiesException(bookEdition.Copies.Count, copiesCount);
        }

        return bookEdition.Copies.Take(copiesCount);
    }

    private static void AddBookCopyCheckouts(Checkout checkout, IEnumerable<BookCopy> copies)
    {
        foreach (var copy in copies)
        {
            var bookCopyCheckout = new BookCopyCheckout
            {
                BookCopy = copy,
                Checkout = checkout
            };

            checkout.BookCopyCheckouts.Add(bookCopyCheckout);
        }
    }

    private async Task AddAccountAsync(Checkout checkout, int accountId)
    {
        var account = await _accountRepository.GetByIdAsync(accountId) ?? throw new NotFoundException<Account>(accountId);

        checkout.Account = account;
    }

    private static int SetStatus(IList<BookCopyCheckout> bookCopyCheckouts, int count, BookCopyCheckoutStatus status, int startIndex, DateTime closeTime)
    {
        var endIndex = startIndex + count;

        for (var i = startIndex; i < endIndex; i++)
        {
            var bookCopyCheckout = bookCopyCheckouts[i];
            bookCopyCheckout.BookCopyCheckoutStatus = status;
            bookCopyCheckout.BookCopyCheckoutCloseTime = closeTime;
        }

        return endIndex;
    }

    private void ThrowIfCopiesDontMatch(CheckoutCloseRequest request, Checkout checkout)
    {
        var expectedCount = checkout.BookCopyCheckouts.Count;

        var actualCount = request.ReturnedCopiesCount + request.LostCopiesCount + request.DestroyedCopiesCount + request.DamagedCopiesCount;

        if (actualCount != expectedCount)
        {
            throw new CheckoutCopiesMisMatchException(expectedCount, actualCount);
        }
    }

    private async Task<Checkout> GetCheckoutWithBookCopyCheckouts(int id)
    {

        var specification = new CheckoutWithBookCopyCheckoutsSpecification(id);

        var checkout = await _repository.SingleOrDefaultAsync(specification) ?? throw new NotFoundException<Checkout>(id);

        return checkout;
    }

    private async Task<CheckoutDetailedResult> GetDetailedCheckoutAsync(int id)
    {
        var specification = new CheckoutDetailedSpecification(id);

        var checkout = await _repository.SingleOrDefaultAsync(specification) ?? throw new NotFoundException<Checkout>(id);

        return checkout;
    }
}

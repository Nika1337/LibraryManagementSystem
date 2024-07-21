using AutoMapper;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.Application.DataTransferObjects.Library;
using Nika1337.Library.Application.DataTransferObjects.Library.Account;
using Nika1337.Library.Domain.Abstractions;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.Exceptions;
using Nika1337.Library.Domain.RequestFeatures;
using Nika1337.Library.Domain.Specifications;
using Nika1337.Library.Domain.Specifications.Accounts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nika1337.Library.Infrastructure.Services;

internal class AccountService : BaseModelService<Account>, IAccountService
{
    private readonly IMapper _mapper;

    public AccountService(
        IRepository<Account> repository,
        IMapper mapper) : base(repository)
    {
        _mapper = mapper;
    }

    public async Task<IEnumerable<PrimitiveResponse>> GetActiveAccountsAsync()
    {
        var specification = new NonDeletedSpecification<Account>();

        var accounts = await _repository.ListAsync(specification);

        var response = _mapper.Map<IEnumerable<PrimitiveResponse>>(accounts);

        return response;
    }

    public async Task<PagedList<AccountPreviewResponse>> GetPagedAccountsAsync(BaseModelPagedRequest<Account> request)
    {
        var specificationParameters = _mapper.Map<BaseModelSpecificationParameters<Account>>(request);

        var specification = new AccountSpecification(specificationParameters);

        var accounts = await _repository.PagedListAsync(specification, request.PageNumber, request.PageSize);

        var response = _mapper.Map<PagedList<AccountPreviewResponse>>(accounts);

        return response;
    }

    public async Task<AccountDetailedResponse> GetAccountAsync(int id)
    {
        var account = await GetDetailedAccountAsync(id);

        var response = _mapper.Map<AccountDetailedResponse>(account);

        return response;
    }

    public async Task CreateAccountAsync(AccountCreateRequest request)
    {
        await ThrowIfAccountNameExists(request.AccountName);
        await ThrowIfAccountIdentificationExists(request.CustomerIdentification);

        var account = _mapper.Map<Account>(request);

        await _repository.AddAsync(account);
    }
    
    public async Task UpdateAccountAsync(AccountUpdateRequest request)
    {
        await ThrowIfAccountWithGivenNameHasDifferentId(request.AccountName, request.Id);
        await ThrowIfAccountWithGivenIdentificationHasDifferentId(request.CustomerIdentification, request.Id);

        var account = await GetEntityAsync(request.Id);

        _mapper.Map(request, account);

        await _repository.UpdateAsync(account);
    }


    private async Task<Account> GetDetailedAccountAsync(int id)
    {
        var specification = new AccountByIdSpecification(id);

        var account = await _repository.SingleOrDefaultAsync(specification) ?? throw new NotFoundException<Account>(id);

        return account;
    }

    private async Task ThrowIfAccountNameExists(string name)
    {
        var specification = new AccountByNameSpecification(name);

        var isNameUsed = await _repository.AnyAsync(specification);

        if (isNameUsed)
        {
            throw new NameDuplicateException($"Account with name '{name}' already exists");
        }
    }

    private async Task ThrowIfAccountIdentificationExists(string identification)
    {
        var specification = new AccountByIdentificationSpecification(identification);

        var isIdentificationUsed = await _repository.AnyAsync(specification);

        if (isIdentificationUsed)
        {
            throw new DuplicateException($"Account with identification '{identification}' already exists");
        }
    }

    private async Task ThrowIfAccountWithGivenNameHasDifferentId(string name, int id)
    {
        var specification = new AccountByNameSpecification(name);

        var account = await _repository.SingleOrDefaultAsync(specification);

        var isAccountNameUsedByDifferentAccount = account is not null && account.Id != id;

        if (isAccountNameUsedByDifferentAccount)
        {
            throw new NameDuplicateException($"Account with name '{name}' already exists");
        }
    }

    private async Task ThrowIfAccountWithGivenIdentificationHasDifferentId(string identification, int id)
    {
        var specification = new AccountByIdentificationSpecification(identification);

        var account = await _repository.SingleOrDefaultAsync(specification);

        var isAccountIdentificationUsedByDifferentAccount = account is not null && account.Id != id;

        if (isAccountIdentificationUsedByDifferentAccount)
        {
            throw new DuplicateException($"Account with identification '{identification}' already exists");
        }
    }
}

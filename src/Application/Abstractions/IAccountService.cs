

using Nika1337.Library.Application.DataTransferObjects.Library;
using Nika1337.Library.Application.DataTransferObjects.Library.Account;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.RequestFeatures;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nika1337.Library.Application.Abstractions;

public interface IAccountService : IBaseModelService
{
    Task<IEnumerable<AccountPrimitiveResponse>> GetActiveAccountsAsync();
    Task<PagedList<AccountPreviewResponse>> GetPagedAccountsAsync(BaseModelPagedRequest<Account> request);
    Task<AccountDetailedResponse> GetAccountAsync(int id);
    Task CreateAccountAsync(AccountCreateRequest request);
    Task UpdateAccountAsync(AccountUpdateRequest request);
}

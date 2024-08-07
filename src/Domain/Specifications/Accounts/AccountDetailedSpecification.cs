using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.Specifications.Accounts.Results;
using System.Linq;

namespace Nika1337.Library.Domain.Specifications.Accounts;

public class AccountDetailedSpecification : BaseModelByIdSpecification<Account, AccountDetailedResult>
{
    public AccountDetailedSpecification(int id) : base(id)
    {
        Query.Select(account => new AccountDetailedResult 
        {
            Id = account.Id,
            AccountName = account.AccountName,
            AccountCreationDate = account.AccountCreationDate,
            ContactInformation = account.ContactInformation,
            CustomerIdentification = account.CustomerIdentification,
            ActiveCheckouts = account.Checkouts.Count(c => c.DeletedDate == null && c.BookCopyCheckouts.Any(bcc => bcc.BookCopyCheckoutCloseTime == null)),
            TotalCheckouts = account.Checkouts.Count(c => c.DeletedDate == null),
            DeletedDate = account.DeletedDate
        });
    }
}

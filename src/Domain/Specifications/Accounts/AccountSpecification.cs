using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.RequestFeatures;
using Nika1337.Library.Domain.Specifications.Accounts.Results;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Nika1337.Library.Domain.Specifications.Accounts;

public class AccountSpecification : BaseModelsSpecification<Account, AccountResult>
{
    protected override Expression<Func<Account, string>>[] FieldSelectors => [ac => ac.AccountName, ac => ac.ContactInformation.Email];

    public AccountSpecification(BaseModelSpecificationParameters<Account> parameters) : base(parameters)
    {
        Query.Select(ac => new AccountResult
        {
            Id = ac.Id,
            AccountName = ac.AccountName,
            AccountCreationDate = ac.AccountCreationDate,
            CustomerIdentification = ac.CustomerIdentification,
            TotalCheckoutsCount = ac.Checkouts.Count(c => c.DeletedDate == null),
            ActiveCheckoutsCount = ac.Checkouts.Count(c => c.BookCopyCheckouts.Any(bcc => bcc.BookCopyCheckoutCloseTime == null)),
            IsActive = ac.DeletedDate == null
        });
    }
}

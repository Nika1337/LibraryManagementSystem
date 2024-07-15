using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.RequestFeatures;
using System;
using System.Linq.Expressions;

namespace Nika1337.Library.Domain.Specifications.Accounts;

public class AccountSpecification : BaseModelSpecification<Account>
{
    protected override Expression<Func<Account, string>>[] FieldSelectors => [ac => ac.AccountName, ac => ac.ContactInformation.Email];

    public AccountSpecification(BaseModelSpecificationParameters<Account> parameters) : base(parameters)
    {
        Query.Include(account => account.Checkouts);
    }
}

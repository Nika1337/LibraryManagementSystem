using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;

namespace Nika1337.Library.Domain.Specifications.Accounts;

public class AccountByNameSpecification : SingleResultSpecification<Account>
{
    public AccountByNameSpecification(string name)
    {
        Query.Where(account => account.AccountName == name);
    }
}

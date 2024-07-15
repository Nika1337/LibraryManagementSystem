using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;

namespace Nika1337.Library.Domain.Specifications.Accounts;

public class AccountByIdSpecification : BaseModelByIdSpecification<Account>
{
    public AccountByIdSpecification(int id) : base(id)
    {
        Query.Include(account => account.Checkouts);
    }
}

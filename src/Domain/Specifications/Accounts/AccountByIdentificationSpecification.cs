using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;
using System.Linq;

namespace Nika1337.Library.Domain.Specifications.Accounts;

public class AccountByIdentificationSpecification : SingleResultSpecification<Account>
{
    public AccountByIdentificationSpecification(string identification)
    {
        Query.Where(account => account.CustomerIdentification == identification);
    }
}

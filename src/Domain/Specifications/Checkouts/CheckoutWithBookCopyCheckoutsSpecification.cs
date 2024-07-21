using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;

namespace Nika1337.Library.Domain.Specifications.Checkouts;

public class CheckoutWithBookCopyCheckoutsSpecification : BaseModelByIdSpecification<Checkout>
{
    public CheckoutWithBookCopyCheckoutsSpecification(int id) : base(id)
    {
        Query.Include(ch => ch.BookCopyCheckouts);
    }
}

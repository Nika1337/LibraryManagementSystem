using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;

namespace Nika1337.Library.Domain.Specifications.Checkouts;

public class CheckoutWithBookCopyCheckoutsSpecification : SingleResultSpecification<Checkout>
{
    public CheckoutWithBookCopyCheckoutsSpecification(int id) 
    {
        Query.Where(ch => ch.Id == id);

        Query.Include(ch => ch.BookCopyCheckouts);

        Query.AsTracking();
    }
}

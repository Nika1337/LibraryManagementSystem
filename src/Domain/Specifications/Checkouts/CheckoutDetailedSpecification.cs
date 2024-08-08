

using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.Specifications.Checkouts.Results;
using System.Linq;

namespace Nika1337.Library.Domain.Specifications.Checkouts;

public class CheckoutDetailedSpecification : BaseModelByIdSpecification<Checkout, CheckoutDetailedResult>
{
    public CheckoutDetailedSpecification(int id) : base(id)
    {
        Query.Include(ch => ch.Account);


        Query
            .Include(ch => ch.BookCopyCheckouts)
                .ThenInclude(bcc => bcc.BookCopy)
                    .ThenInclude(c => c.BookEdition)
                        .ThenInclude(be => be.Book);

        Query
            .Include(ch => ch.BookCopyCheckouts)
                .ThenInclude(bcc => bcc.BookCopy)
                    .ThenInclude(c => c.BookEdition)
                        .ThenInclude(be => be.Publisher);

        Query
            .Include(ch => ch.BookCopyCheckouts)
                .ThenInclude(bcc => bcc.BookCopy)
                    .ThenInclude(c => c.BookEdition)
                        .ThenInclude(be => be.Language);

        Query.Select(ch => new CheckoutDetailedResult
        {
            Id = ch.Id,
            BookTitle = ch.BookEdition.Book.Title,
            PublisherName = ch.BookEdition.Publisher.PublisherName,
            LanguageName = ch.BookEdition.Language.Name,
            CopiesCount = ch.BookCopyCheckouts.Count,
            AccountName = ch.Account.AccountName,
            CheckoutTime = ch.CheckoutTime,
            SupposedReturnTime = ch.SupposedReturnTime,
            CheckoutCloseTime = ch.BookCopyCheckouts.Any(bcc => bcc.BookCopyCheckoutCloseTime == null) ? null : ch.BookCopyCheckouts.Max(bcc => bcc.BookCopyCheckoutCloseTime),
            ReturnedCopiesCount = ch.BookCopyCheckouts.Count(bcc => bcc.BookCopyCheckoutStatus == BookCopyCheckoutStatus.BookCopyReturned),
            LostCopiesCount = ch.BookCopyCheckouts.Count(bcc => bcc.BookCopyCheckoutStatus == BookCopyCheckoutStatus.BookCopyLost),
            DamagedCopiesCount = ch.BookCopyCheckouts.Count(bcc => bcc.BookCopyCheckoutStatus == BookCopyCheckoutStatus.BookCopyReturnedDamaged),
            DestroyedCopiesCount = ch.BookCopyCheckouts.Count(bcc => bcc.BookCopyCheckoutStatus == BookCopyCheckoutStatus.BookCopyReturnedDestroyed),
            DeletedDate = ch.DeletedDate
        });
    }
}

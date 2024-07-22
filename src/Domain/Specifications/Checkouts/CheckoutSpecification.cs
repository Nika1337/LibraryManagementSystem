using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.RequestFeatures;
using Nika1337.Library.Domain.Specifications.Checkouts.Results;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Nika1337.Library.Domain.Specifications.Checkouts;



public class CheckoutSpecification : BaseModelSpecification<Checkout, CheckoutResult>
{
    protected override Expression<Func<Checkout, string>>[] FieldSelectors =>
        [
            ch => ch.Account.AccountName
        ];

    public CheckoutSpecification(
        BaseModelSpecificationParameters<Checkout> parameters) : base(parameters)
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



        Query.Select(ch => new CheckoutResult
        {
            Id = ch.Id,
            BookTitle = ch.BookCopyCheckouts.First().BookCopy.BookEdition.Book.Title,
            PublisherName = ch.BookCopyCheckouts.First().BookCopy.BookEdition.Publisher.PublisherName,
            LanguageName = ch.BookCopyCheckouts.First().BookCopy.BookEdition.Language.Name,
            CopiesCount = ch.BookCopyCheckouts.Count,
            AccountName = ch.Account.AccountName,
            CheckoutTime = ch.CheckoutTime,
            SupposedReturnTime = ch.SupposedReturnTime,
            IsClosed = ch.BookCopyCheckouts.All(bcc => bcc.BookCopyCheckoutCloseTime != null),
            IsActive = ch.DeletedDate == null
        });
    }
}

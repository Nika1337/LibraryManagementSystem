using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.RequestFeatures;
using Nika1337.Library.Domain.Specifications.Checkouts.Results;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Nika1337.Library.Domain.Specifications.Checkouts;



public class CheckoutsSpecification : BaseModelsSpecification<Checkout, CheckoutResult>
{
    protected override Expression<Func<Checkout, string>>[] FieldSelectors =>
        [
            ch => ch.Account.AccountName
        ];

    public CheckoutsSpecification(
        BaseModelSpecificationParameters<Checkout> parameters) : base(parameters)
    {


        Query.Select(ch => new CheckoutResult
        {
            Id = ch.Id,
            BookTitle = ch.BookEdition.Book.Title,
            PublisherName = ch.BookEdition.Publisher.PublisherName,
            LanguageName = ch.BookEdition.Language.Name,
            CopiesCount = ch.BookCopyCheckouts.Count,
            AccountName = ch.Account.AccountName,
            CheckoutTime = ch.CheckoutTime,
            SupposedReturnTime = ch.SupposedReturnTime,
            IsClosed = ch.BookCopyCheckouts.All(bcc => bcc.BookCopyCheckoutCloseTime != null),
            IsActive = ch.DeletedDate == null
        });
    }
}

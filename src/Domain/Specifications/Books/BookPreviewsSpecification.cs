using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.RequestFeatures;
using System;
using System.Linq.Expressions;

namespace Nika1337.Library.Domain.Specifications.Books;

public class BookPreviewsSpecification : BaseModelSpecification<Book>
{
    public BookPreviewsSpecification(BaseModelSpecificationParameters<Book> parameters) : base(parameters)
    {
        Query.Include(book => book.Authors);

        Query.Include(book => book.OriginalLanguage);

        Query.Include(book => book.Editions);

    }

    protected override Expression<Func<Book, string>>[] FieldSelectors => [book => book.Title, book => book.Summary];
}

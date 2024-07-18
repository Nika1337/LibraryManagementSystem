using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.RequestFeatures;
using Nika1337.Library.Domain.Specifications.Books.Results;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Nika1337.Library.Domain.Specifications.Books;

public class BookPreviewsSpecification : BaseModelSpecification<Book, BookPreviewResult>
{
    public BookPreviewsSpecification(BaseModelSpecificationParameters<Book> parameters) : base(parameters)
    {
        Query.Include(book => book.Authors);

        Query.Include(book => book.OriginalLanguage);

        Query.Include(book => book.Editions);

        Query.Select(book => new BookPreviewResult
        {
            Id = book.Id,
            Title = book.Title,
            OriginalReleaseDate = book.OriginalReleaseDate,
            MinimumAge = book.MinimumAge,
            OriginalLanguageName = book.OriginalLanguage.Name,
            AuthorNames = book.Authors.Select(author => author.Name).ToArray(),
            DeletedDate = book.DeletedDate,
            EditionsCount = book.Editions.Count(be => be.DeletedDate == null)
        });
    }

    protected override Expression<Func<Book, string>>[] FieldSelectors => [book => book.Title, book => book.Summary];
}

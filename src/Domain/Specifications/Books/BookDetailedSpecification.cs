

using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.Specifications.Books.Results;
using System.Linq;

namespace Nika1337.Library.Domain.Specifications.Books;

public class BookDetailedSpecification : BaseModelByIdSpecification<Book, BookDetailedResult>
{
    public BookDetailedSpecification(int id) : base(id)
    {
        Query.Include(book => book.OriginalLanguage);

        Query.Include(book => book.Genres);

        Query.Include(book => book.Authors);

        Query.Select(book => new BookDetailedResult 
        {
            Id = book.Id,
            Title = book.Title,
            Summary = book.Summary,
            OriginalReleaseDate = book.OriginalReleaseDate,
            OriginalLanguageId = book.OriginalLanguage.Id,
            MinimumAge = book.MinimumAge,
            GenreIds = book.Genres.Select(genre => genre.Id).ToArray(),
            AuthorIds = book.Authors.Select(author => author.Id).ToArray(),
            DeletedDate = book.DeletedDate
        });
    }
}

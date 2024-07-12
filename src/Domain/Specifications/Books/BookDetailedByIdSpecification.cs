

using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;

namespace Nika1337.Library.Domain.Specifications.Books;

public class BookDetailedByIdSpecification : BaseModelByIdSpecification<Book>
{
    public BookDetailedByIdSpecification(int id) : base(id)
    {
        Query.Include(book => book.OriginalLanguage);

        Query.Include(book => book.Genres);

        Query.Include(book => book.Authors);
    }
}

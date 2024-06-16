

using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;

namespace Nika1337.Library.Domain.Specifications.Books;

public class BookDetailedByIdSpecification : SingleResultSpecification<Book>
{
    public BookDetailedByIdSpecification(int id)
    {
        Query.Where(book => book.Id == id);

        Query.Include(book => book.OriginalLanguage);

        Query.Include(book => book.Genres);

        Query.Include(book => book.Authors);
    }
}

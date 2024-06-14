using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;

namespace Nika1337.Library.Domain.Specifications.Books;

public class BookWithAuthorsLanguageEditionsSpecification : Specification<Book>
{
    public BookWithAuthorsLanguageEditionsSpecification()
    {
        Query.Include(book => book.Authors);

        Query.Include(book => book.OriginalLanguage);

        Query.Include(book => book.Editions);
    }
}

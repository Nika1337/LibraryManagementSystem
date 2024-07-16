using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;

namespace Nika1337.Library.Domain.Specifications.BookEditions;

public class BookEditionByIsbnSpecification : SingleResultSpecification<BookEdition>
{
    public BookEditionByIsbnSpecification(string isbn)
    {
        Query.Where(be => be.Isbn == isbn);
    }
}

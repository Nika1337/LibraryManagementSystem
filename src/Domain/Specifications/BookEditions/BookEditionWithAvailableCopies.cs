

using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;
using System.Linq;

namespace Nika1337.Library.Domain.Specifications.BookEditions;

public class BookEditionWithAvailableCopies : SingleResultSpecification<BookEdition>
{
    public BookEditionWithAvailableCopies(int bookId, int id)
    {
        Query.Where(be => be.Book.Id == bookId && be.Id == id);

        Query.Include(be => be.Copies.AsQueryable().Where(Extensions.IsBookCopyAvaliable));

        Query.AsTracking();
    }
}

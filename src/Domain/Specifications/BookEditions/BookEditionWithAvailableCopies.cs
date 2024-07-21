

using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;
using System.Linq;

namespace Nika1337.Library.Domain.Specifications.BookEditions;

public class BookEditionWithAvailableCopies : BaseModelByIdSpecification<BookEdition>
{
    public BookEditionWithAvailableCopies(int bookId, int id) : base(id)
    {
        Query.Where(be => be.Book.Id == bookId);

        Query.Include(be => be.Copies.AsQueryable().Where(Extensions.IsBookCopyAvaliable));
    }
}

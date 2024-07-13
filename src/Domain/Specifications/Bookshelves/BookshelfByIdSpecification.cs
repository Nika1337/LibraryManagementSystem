using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;

namespace Nika1337.Library.Domain.Specifications.Bookshelves;
public class BookshelfByIdSpecification : BaseModelByIdSpecification<Bookshelf>
{
    public BookshelfByIdSpecification(int id) : base(id)
    {
        Query.Include(bookshelf => bookshelf.Shelves);
    }
}

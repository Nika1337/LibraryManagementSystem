

using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.Specifications.BookEditions.Results;
using System.Linq;

namespace Nika1337.Library.Domain.Specifications.BookEditions;

public class BookEditionDetailedSpecification : BaseModelByIdSpecification<BookEdition, BookEditionDetailedResult>
{
    public BookEditionDetailedSpecification(int bookId, int id) : base(id)
    {
        Query.Include(be => be.Book)
             .Include(be => be.Publisher)
             .Include(be => be.Language)
             .Include(be => be.Room)
             .Include(be => be.Copies)
                 .ThenInclude(c => c.BookCopyCheckouts)
                 .ThenInclude(bcc => bcc.Checkout);


        Query.Where(be => be.Book.Id == bookId);

        Query.Select(be => new BookEditionDetailedResult
        {
            Id = be.Id,
            Isbn = be.Isbn,
            PageCount = be.PageCount,
            PublicationDate = be.PublicationDate,
            BookTitle = be.Book.Title,
            LanguageId = be.Language.Id,
            PublisherId = be.Publisher.Id,
            RoomId = be.Room.Id,
            TotalCopiesCount = be.Copies.AsQueryable().Count(Extensions.ShouldIncludeBookCopyInTotal),
            AvaliableCopiesCount = be.Copies.AsQueryable().Count(Extensions.IsBookCopyAvaliable),
            DeletedDate = be.DeletedDate
        });
    }
}

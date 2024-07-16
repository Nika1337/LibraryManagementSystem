

using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.Specifications.BookEditions.Results;
using System.Linq;

namespace Nika1337.Library.Domain.Specifications.BookEditions;

public class BookEditionByIdSpecification : BaseModelByIdSpecification<BookEdition, BookEditionByIdResult>
{
    public BookEditionByIdSpecification(int bookId, int id) : base(id)
    {
        Query.Where(be => be.Book.Id == bookId);

        Query.Select(be => new BookEditionByIdResult
        {
            Id = be.Id,
            Isbn = be.Isbn,
            PageCount = be.PageCount,
            PublicationDate = be.PublicationDate,
            BookId = be.Book.Id,
            LanguageId = be.Language.Id,
            PublisherId = be.Publisher.Id,
            RoomId = be.Room.Id,
            TotalCopiesCount = be.Copies.Count(c => c.DeletedDate == null),
            AvaliableCopiesCount = be.Copies.Count(c => c.IsAvaliable()),
            DeletedDate = be.DeletedDate
        });
    }
}

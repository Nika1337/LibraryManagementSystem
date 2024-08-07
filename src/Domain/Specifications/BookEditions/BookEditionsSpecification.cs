

using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.RequestFeatures;
using Nika1337.Library.Domain.Specifications.BookEditions.Results;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Nika1337.Library.Domain.Specifications.BookEditions;

public class BookEditionsSpecification : BaseModelsSpecification<BookEdition, BookEditionResult>
{
    protected override Expression<Func<BookEdition, string>>[] FieldSelectors =>
    [
        be => be.Isbn,
        be => be.Book.Title,
        be => be.Publisher.PublisherName,
        be => be.Language.Name,
        be => be.Room.RoomNumber
    ];
    public BookEditionsSpecification(
        int bookId,
        BaseModelSpecificationParameters<BookEdition> parameters) : base(parameters)
    {
        Query.Include(be => be.Book)
            .Include(be => be.Publisher)
            .Include(be => be.Language)
            .Include(be => be.Room)
            .Include(be => be.Copies)
            .ThenInclude(c => c.BookCopyCheckouts)
            .ThenInclude(bcc => bcc.Checkout);

        Query.Where(be => be.Book.Id == bookId);

        Query.Select(be => new BookEditionResult
        {
            Id = be.Id,
            BookTitle = be.Book.Title,
            PublisherName = be.Publisher.PublisherName,
            LanguageName = be.Language.Name,
            RoomNumber = be.Room.RoomNumber,
            PublicationDate = be.PublicationDate,
            PageCount = be.PageCount,
            Isbn = be.Isbn,
            AvaliableCopiesCount = be.Copies.AsQueryable().Count(Extensions.IsBookCopyAvaliable),
            IsActive = be.DeletedDate == null
        });
    }
}

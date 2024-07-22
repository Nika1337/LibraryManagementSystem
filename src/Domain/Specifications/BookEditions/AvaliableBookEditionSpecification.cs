using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.Specifications.BookEditions.Results;
using System.Linq;

namespace Nika1337.Library.Domain.Specifications.BookEditions;

public class AvailableBookEditionsSpecification : NonDeletedSpecification<BookEdition, AvaliableBookEditionResult>
{
    public AvailableBookEditionsSpecification(int bookId)
    {
        Query.Include(be => be.Book);

        Query.Include(be => be.Publisher);

        Query.Include(be => be.Language);

        Query.Include(be => be.Copies)
             .ThenInclude(c => c.BookCopyCheckouts)
             .ThenInclude(bcc => bcc.Checkout);

        Query.Where(be => be.Book.Id == bookId);

        Query.Where(Extensions.IsBookEditionAvaliable);


        Query.Select(be => new AvaliableBookEditionResult
        {
            Id = be.Id,
            Isbn = be.Isbn,
            PublisherName = be.Publisher.PublisherName,
            LanguageName = be.Language.Name,
            AvaliableCopiesCount = be.Copies.AsQueryable().Count(Extensions.IsBookCopyAvaliable)
        });
    }
}
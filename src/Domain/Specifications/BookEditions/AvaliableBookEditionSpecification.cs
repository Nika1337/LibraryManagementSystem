using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.Specifications.BookEditions.Results;
using System.Linq;

namespace Nika1337.Library.Domain.Specifications.BookEditions;

public class AvailableBookEditionsSpecification : Specification<BookEdition, AvaliableBookEditionResult>
{
    public AvailableBookEditionsSpecification(int bookId)
    {
        Query.Include(be => be.Book);

        Query.Include(be => be.Publisher);

        Query.Include(be => be.Language);

        Query.Include(be => be.Copies)
             .ThenInclude(c => c.BookCopyCheckouts);

        Query.Where(be => be.Book.Id == bookId);

        Query.Where(be => be.DeletedDate == null);

        Query.Where(be => be.Copies.Any(c => IsBookCopyAvaliable(c)));


        Query.Select(be => new AvaliableBookEditionResult
        {
            Id = be.Id,
            BookTitle = be.Book.Title,
            PublisherName = be.Publisher.PublisherName,
            LanguageName = be.Language.Name,
            AvaliableCopiesCount = be.Copies.Count(c => IsBookCopyAvaliable(c))
        });
    }

    private static bool IsBookCopyAvaliable(BookCopy bookCopy)
    {
        var isCopyLentOut = bookCopy.BookCopyCheckouts.Any(bcc => bcc.BookCopyCheckoutCloseTime == null);

        var isCopyUsable = bookCopy.BookCopyCondition == BookCopyCondition.Usable;

        return !isCopyLentOut && isCopyUsable;
    }
}
using System.Collections.Generic;

namespace Nika1337.Library.Domain.Entities;

public class BookCopy : BaseModel
{
    public required BookEdition BookEdition { get; set; }
    public BookCopyCondition BookCopyCondition { get; set; } = BookCopyCondition.Usable;
    public ICollection<BookCopyCheckout> BookCopyCheckouts { get; set; } = [];
}

public enum BookCopyCondition
{
    NeedsRestoration,
    Usable,
    LostByLibrary
}
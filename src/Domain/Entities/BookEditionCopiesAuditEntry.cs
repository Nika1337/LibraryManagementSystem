

using System;
using System.Collections.Generic;

namespace Nika1337.Library.Domain.Entities;

public class BookEditionCopiesAuditEntry
{
    public required int Id { get; set; }
    public required DateTime Timestamp { get; set; }
    public required BookEditionCopiesAuditAction Action { get; set; }
    public required string Message { get; set; }
    public required BookEdition BookEdition { get; set; }
    public List<BookCopy> BookCopies { get; set; } = [];
}


public enum BookEditionCopiesAuditAction
{
    Added,
    Deleted
}
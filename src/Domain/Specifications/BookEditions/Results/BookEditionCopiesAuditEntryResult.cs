
using Nika1337.Library.Domain.Entities;
using System;

namespace Nika1337.Library.Domain.Specifications.BookEditions.Results;

public class BookEditionCopiesAuditEntryResult
{
    public required DateTime Timestamp { get; init; }
    public required BookEditionCopiesAuditAction Action { get; init; }
    public required string Message { get; init; }
    public required int ModifiedCopiesCount { get; init; }
}

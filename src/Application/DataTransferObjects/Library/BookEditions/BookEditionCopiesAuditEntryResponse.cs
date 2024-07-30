using Nika1337.Library.Domain.Entities;
using System;

namespace Nika1337.Library.Application.DataTransferObjects.Library.BookEditions;

public record BookEditionCopiesAuditEntryResponse
{
    public required DateTime Timestamp { get; init; }
    public required BookEditionCopiesAuditAction Action { get; init; }
    public required string Message { get; init; }
    public required int ModifiedCopiesCount { get; init; }
}

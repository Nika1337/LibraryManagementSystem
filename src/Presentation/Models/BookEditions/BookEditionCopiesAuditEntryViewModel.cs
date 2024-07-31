using Nika1337.Library.Domain.Entities;
using System;
using System.ComponentModel;

namespace Nika1337.Library.Presentation.Models.BookEditions;

public class BookEditionCopiesAuditEntryViewModel
{
    public required DateTime Timestamp { get; init; }
    public required BookEditionCopiesAuditAction Action { get; init; }
    public required string Message { get; init; }
    [DisplayName("Modified Copies Count")]
    public required int ModifiedCopiesCount { get; init; }
}

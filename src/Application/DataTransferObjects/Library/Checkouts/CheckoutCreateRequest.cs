

using System;

namespace Nika1337.Library.Application.DataTransferObjects.Library.Checkouts;

public record CheckoutCreateRequest
{
    public required int BookId { get; init; }
    public required int BookEditionId { get; init; }
    public required int CopiesCount { get; init; }
    public required DateTime SupposedReturnTime { get; init; }
    public required int AccountId { get; init; }
}

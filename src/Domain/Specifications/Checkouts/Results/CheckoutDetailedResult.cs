using System;

namespace Nika1337.Library.Domain.Specifications.Checkouts.Results;

public class CheckoutDetailedResult
{
    public required int Id { get; init; }
    public required string BookTitle { get; init; }
    public required string PublisherName { get; init; }
    public required string LanguageName { get; init; }
    public required int CopiesCount { get; init; }
    public required string AccountName { get; init; }
    public required DateTime CheckoutTime { get; init; }
    public required DateTime SupposedReturnTime { get; init; }
    public required DateTime? CheckoutCloseTime { get; init; }
    public required int ReturnedCopiesCount { get; init; }
    public required int LostCopiesCount { get; init; }
    public required int DamagedCopiesCount { get; init; }
    public required int DestroyedCopiesCount { get; init; }
    public required DateTime? DeletedDate { get; init; }
}

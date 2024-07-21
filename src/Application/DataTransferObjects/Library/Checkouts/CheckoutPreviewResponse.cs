

using System;

namespace Nika1337.Library.Application.DataTransferObjects.Library.Checkouts;

public record CheckoutPreviewResponse
{
    public required int Id { get; init; }
    public required string BookTitle { get; init; }
    public required string PublisherName { get; init; }
    public required string LanguageName { get; init; }
    public required int CopiesCount { get; init; }
    public required string AccountName { get; init; }
    public required DateTime CheckoutTime { get; init; }
    public required DateTime SupposedReturnTime { get; init; }
    public required bool IsClosed { get; init; }
    public required bool IsActive { get; init; }
}
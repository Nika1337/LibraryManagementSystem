

namespace Nika1337.Library.Application.DataTransferObjects.Library.Account;

public record AccountPreviewResponse
{
    public required int Id { get; init; }
    public required string AccountName { get; init; }
    public required string AccountCreationDate { get; init; }
    public required int TotalCheckouts { get; init; }
    public required int ActiveCheckouts { get; init; }
    public required bool IsActive { get; init; }
}

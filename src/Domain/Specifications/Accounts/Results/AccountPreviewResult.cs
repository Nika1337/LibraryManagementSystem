using System;

namespace Nika1337.Library.Domain.Specifications.Accounts.Results;

public class AccountPreviewResult
{
    public required int Id { get; init; }
    public required string AccountName { get; init; }
    public required DateTime AccountCreationDate { get; init; }
    public required string CustomerIdentification { get; init; }
    public required int TotalCheckoutsCount { get; init; }
    public required int ActiveCheckoutsCount { get; init; }
    public required bool IsActive { get; init; }
}

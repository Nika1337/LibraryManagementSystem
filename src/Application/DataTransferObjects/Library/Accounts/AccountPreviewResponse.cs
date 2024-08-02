﻿

using System;

namespace Nika1337.Library.Application.DataTransferObjects.Library.Account;

public record AccountPreviewResponse
{
    public required int Id { get; init; }
    public required string AccountName { get; init; }
    public required DateTime AccountCreationDate { get; init; }
    public required string CustomerIdentification { get; init; }
    public required int TotalCheckoutsCount { get; init; }
    public required int ActiveCheckoutsCount { get; init; }
    public required bool IsActive { get; init; }
}

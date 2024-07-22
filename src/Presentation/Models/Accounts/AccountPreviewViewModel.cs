﻿

using System;

namespace Nika1337.Library.Presentation.Models.Accounts;

public class AccountPreviewViewModel
{
    public required int Id { get; init; }
    public required string AccountName { get; init; }
    public required DateTime AccountCreationDate { get; init; }
    public required string CustomerIdentification { get; init; }
    public required int TotalCheckouts { get; init; }
    public required int ActiveCheckouts { get; init; }
    public required bool IsActive { get; init; }
}
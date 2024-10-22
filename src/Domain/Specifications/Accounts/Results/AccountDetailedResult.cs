﻿

using Nika1337.Library.Domain.Entities;
using System;

namespace Nika1337.Library.Domain.Specifications.Accounts.Results;

public class AccountDetailedResult
{
    public required int Id { get; init; }
    public required string AccountName { get; init; }
    public required DateTime AccountCreationDate { get; init; }
    public required ContactInformation ContactInformation { get; init; }
    public required string CustomerIdentification { get; init; }
    public required int TotalCheckouts { get; init; }
    public required int ActiveCheckouts { get; init; }
    public required DateTime? DeletedDate { get; init; }
}

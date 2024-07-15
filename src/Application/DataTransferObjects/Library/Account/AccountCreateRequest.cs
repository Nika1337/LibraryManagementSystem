

using Nika1337.Library.Domain.Entities;

namespace Nika1337.Library.Application.DataTransferObjects.Library.Account;

public abstract record AccountCreateRequest
{
    public required string AccountName { get; init; }
    public required ContactInformation ContactInformation { get; init; }
}

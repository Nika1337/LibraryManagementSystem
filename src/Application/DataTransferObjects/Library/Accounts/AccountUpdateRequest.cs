
using Nika1337.Library.Domain.Entities;

namespace Nika1337.Library.Application.DataTransferObjects.Library.Account;

public record AccountUpdateRequest
{
    public required int Id { get; init; }
    public required string AccountName { get; init; }
    public required ContactInformation ContactInformation { get; init; }
    public required string CustomerIdentification { get; init; }
}



namespace Nika1337.Library.Application.DataTransferObjects.Library.Account;

public record AccountPrimitiveResponse
{
    public required int Id { get; init; }
    public required int Name { get; init; }
}

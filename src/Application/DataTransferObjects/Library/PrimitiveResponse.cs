

namespace Nika1337.Library.Application.DataTransferObjects.Library;

public record PrimitiveResponse
{
    public required int Id { get; init; }
    public required string Name { get; init; }
}


namespace Nika1337.Library.Application.DataTransferObjects.Library.Publishers;

public record PublisherPrimitiveResponse
{
    public required int Id { get; init; }
    public required string PublisherName { get; init; }
}

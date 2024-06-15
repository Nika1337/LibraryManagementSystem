

namespace Nika1337.Library.Application.DataTransferObjects.Library.Authors;

public record AuthorPreviewResponse
{
    public required int Id { get; init; }
    public required string Name { get; init; }
}


namespace Nika1337.Library.Application.DataTransferObjects.Library.Genres;

public record GenreUpdateRequest
{
    public required int Id { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
}

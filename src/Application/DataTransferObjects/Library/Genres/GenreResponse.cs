using System;

namespace Nika1337.Library.Application.DataTransferObjects.Library.Genres;

public record GenreResponse
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required DateTime? DeletedDate { get; set; }
}
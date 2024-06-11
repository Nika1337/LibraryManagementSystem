﻿

namespace Nika1337.Library.Application.DataTransferObjects.Library.Genres;

public record GenreUpdateRequest
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
}

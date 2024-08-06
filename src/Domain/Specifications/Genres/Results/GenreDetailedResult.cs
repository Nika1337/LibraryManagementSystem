

using System;

namespace Nika1337.Library.Domain.Specifications.Genres.Results;

public class GenreDetailedResult
{
    public required int Id { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
    public required DateTime? DeletedDate { get; init; }
}

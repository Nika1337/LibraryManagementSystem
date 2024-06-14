

using Nika1337.Library.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Nika1337.Library.Application.DataTransferObjects.Library.Books;

public record BookDetailedResponse
{
    public required int Id { get; init; }
    public required string Title { get; init; }
    public required string Summary { get; init; }
    public required DateTime OriginalReleaseDate { get; init; }
    public required byte? MinimumAge { get; init; }
    public required Language OriginalLanguage { get; init; }
    public required DateTime? DeletedDate { get; init; }
    public required ICollection<Genre> Genres { get; init; }
    public required ICollection<Author> Authors { get; init; }
}

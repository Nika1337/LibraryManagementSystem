
using Nika1337.Library.Application.DataTransferObjects.Library.Languages;
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
    public required int OriginalLanguageId { get; init; }
    public required ICollection<int> GenreIds { get; init; }
    public required ICollection<int> AuthorIds { get; init; }
    public required DateTime? DeletedDate { get; init; }
}

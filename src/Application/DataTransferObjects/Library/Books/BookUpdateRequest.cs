
using System;

namespace Nika1337.Library.Application.DataTransferObjects.Library.Books;
public record BookUpdateRequest
{
    public required int Id { get; init; }
    public required string Title { get; init; }
    public required string Summary { get; init; }
    public required DateTime OriginalReleaseDate { get; init; }
    public required byte? MinimumAge { get; init; }
    public required int OriginalLanguageId { get; init; }
    public required int[] GenreIds { get; init; }
    public required int[] AuthorIds { get; init; }
}

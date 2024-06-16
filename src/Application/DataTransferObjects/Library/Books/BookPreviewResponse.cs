

using Nika1337.Library.Application.DataTransferObjects.Library.Authors;
using Nika1337.Library.Application.DataTransferObjects.Library.Languages;
using System;
using System.Collections.Generic;

namespace Nika1337.Library.Application.DataTransferObjects.Library.Books;

public record BookPreviewResponse
{
    public required int Id { get; init; }
    public required string Title { get; init; }
    public required DateTime OriginalReleaseDate { get; init; }
    public required byte? MinimumAge { get; init; }
    public required int EditionsCount { get; init; }
    public required LanguagePreviewResponse OriginalLanguage { get; init; }
    public required ICollection<AuthorPreviewResponse> Authors { get; init; }
    public required DateTime? DeletedDate { get; init; }
}

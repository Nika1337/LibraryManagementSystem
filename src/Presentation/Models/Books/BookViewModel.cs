

using System;

namespace Nika1337.Library.Presentation.Models.Books;

public class BookViewModel
{
    public required int Id { get; set; }
    public required string Title { get; set; }
    public required DateTime OriginalReleaseDate { get; set; }
    public required byte? MinimumAge { get; set; }
    public required int EditionsCount { get; set; }
    public required string OriginalLanguageName { get; set; }
    public required string[] AuthorNames { get; set; }
    public required DateTime? DeletedDate { get; set; }
}

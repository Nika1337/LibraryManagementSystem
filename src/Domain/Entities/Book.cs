using System;
using System.Collections.Generic;

namespace Nika1337.Library.Domain.Entities;
public class Book : BaseModel
{
    public required string Title { get; set; }
    public required string Summary { get; set; }
    public required DateTime OriginalReleaseDate { get; set; }
    public byte? MinimumAge { get; set; }
    public required Language OriginalLanguage { get; set; }
    public ICollection<Genre> Genres { get; set; } = [];
    public ICollection<Author> Authors { get; set; } = [];
    public ICollection<BookEdition> Editions { get; set; } = [];
}
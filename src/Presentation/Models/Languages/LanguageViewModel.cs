

using System;

namespace Nika1337.Library.Presentation.Models.Languages;

public class LanguageViewModel
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required DateTime? DeletedDate { get; set; }
}

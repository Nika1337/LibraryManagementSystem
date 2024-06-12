using System;

namespace Nika1337.Library.Application.DataTransferObjects.Library.Languages;

public record LanguageResponse
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required DateTime? DeletedDate { get; set; }
}
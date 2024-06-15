

namespace Nika1337.Library.Application.DataTransferObjects.Library.Languages;

public record LanguagePreviewResponse
{
    public required int Id { get; init; }
    public required string Name { get; init; }
}
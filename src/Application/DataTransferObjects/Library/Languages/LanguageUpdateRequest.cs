

namespace Nika1337.Library.Application.DataTransferObjects.Library.Languages;

public record LanguageUpdateRequest
{
    public required int Id { get; set; }
    public required string Name { get; set; }
}

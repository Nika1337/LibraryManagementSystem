

using Nika1337.Library.Application.DataTransferObjects.Library.Languages;
using Nika1337.Library.Application.DataTransferObjects.Library.Publishers;

namespace Nika1337.Library.Application.DataTransferObjects.Library.BookEditions;

public record BookEditionsPreviewResponse
{
    public required int Id { get; set; }
    public required string Title { get; set; }
    public required LanguagePreviewResponse Language { get; set; }
    public required PublisherPreviewResponse Publisher { get; set; }
}

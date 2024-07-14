
namespace Nika1337.Library.Application.DataTransferObjects.Library.BookEditions;

public record BookEditionPrimitiveResponse
{
    public required int Id { get; init; }
    public required string BookName { get; init; }
    public required string PublisherName { get; init; }
    public required string LanguageName { get; init; }
}

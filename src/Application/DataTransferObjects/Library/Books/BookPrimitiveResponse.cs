
namespace Nika1337.Library.Application.DataTransferObjects.Library.Books;

public record BookPrimitiveResponse
{
    public required int Id { get; init; }
    public required string Title { get; init; }
    public required string[] AuthorNames { get; init; }
}

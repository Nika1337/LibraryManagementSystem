
namespace Nika1337.Library.Domain.Specifications.Books.Results;

public class AvaliableBookResult
{
    public required int Id { get; init; }
    public required string Title { get; init; }
    public required string[] AuthorNames { get; init; }
}

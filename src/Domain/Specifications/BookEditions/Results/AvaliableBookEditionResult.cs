


namespace Nika1337.Library.Domain.Specifications.BookEditions.Results;

public class AvaliableBookEditionResult
{
    public required int Id { get; init; }
    public required string BookTitle { get; init; }
    public required string PublisherName { get; init; }
    public required string LanguageName { get; init; }
    public required int AvaliableCopiesCount { get; init; }
}

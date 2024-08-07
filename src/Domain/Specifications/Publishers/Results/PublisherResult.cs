

namespace Nika1337.Library.Domain.Specifications.Publishers.Results;

public class PublisherResult
{
    public required int Id { get; init; }
    public required string PublisherName { get; init; }
    public required string? WebsiteAddress { get; init; }
    public required int PublishedBookEditionsCount { get; init; }
    public required bool IsActive { get; init; }
}

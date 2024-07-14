

using Nika1337.Library.Domain.Entities;

namespace Nika1337.Library.Application.DataTransferObjects.Library.Publishers;

public record PublisherUpdateRequest
{
    public required int Id { get; init; }
    public required string PublisherName { get; init; }
    public required ContactInformation ContactInformation { get; init; }
    public required string? WebsiteAddress { get; init; }
}

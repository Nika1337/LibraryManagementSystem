

using Nika1337.Library.Domain.Entities;
using System;

namespace Nika1337.Library.Domain.Specifications.Publishers.Results;

public class PublisherDetailedResult
{
    public required int Id { get; init; }
    public required string PublisherName { get; init; }
    public required ContactInformation ContactInformation { get; init; }
    public required string? WebsiteAddress { get; init; }
    public required int PublishedBookEditionsCount { get; init; }
    public required DateTime? DeletedDate { get; init; }
}

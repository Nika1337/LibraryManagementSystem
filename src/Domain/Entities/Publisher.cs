using System.Collections.Generic;

namespace Nika1337.Library.Domain.Entities;

public class Publisher : BaseModel
{
    public required string PublisherName { get; set; }
    public required ContactInformation ContactInformation { get; set; }
    public string? WebsiteAddress { get; set; }
    public ICollection<BookEdition> PublishedBookEditions { get; } = [];
}
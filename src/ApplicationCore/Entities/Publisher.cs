using System.Collections.Generic;

namespace Nika1337.Library.ApplicationCore.Entities;

public class Publisher : BaseModel
{
    public required string PublisherName { get; set; }
    public required ContactInformation ContactInformation { get; set; }
    public string? WebsiteAddress { get; set; }
    public ICollection<BookEdition> PublishedBooks { get; } = [];
}
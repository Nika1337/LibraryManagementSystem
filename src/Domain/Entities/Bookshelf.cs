using System.Collections.Generic;

namespace Nika1337.Library.Domain.Entities;
public class Bookshelf : BaseModel
{
    public required Room Room { get; set; }
    public int SectionId { get; set; }
    public ICollection<Shelf> Shelves { get; } = [];
}
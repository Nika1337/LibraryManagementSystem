using System.Collections.Generic;

namespace Nika1337.Library.Domain.Entities;
public class Shelf : BaseModel
{
    public required Bookshelf Bookshelf { get; set; }
    public int? MaxCapacityOfBooks { get; set; }
    public ICollection<BookEdition> BookEditions { get; } = [];
}
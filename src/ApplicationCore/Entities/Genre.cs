using System.Collections;
using System.Collections.Generic;

namespace Nika1337.Library.ApplicationCore.Entities;

public class Genre : BaseModel
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public ICollection<Book> Books { get; } = [];
}
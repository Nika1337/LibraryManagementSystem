using System.Collections.Generic;

namespace Nika1337.Library.Domain.Entities;

public class Room : BaseModel
{
    public required int Floor { get; set; }
    public required string RoomNumber { get; set; }
    public int? MaxCapacityOfPeople { get; set; }
    public ICollection<BookEdition> BookEditions { get; } = [];
}
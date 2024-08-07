using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.Specifications.Rooms.Results;
using System.Linq;

namespace Nika1337.Library.Domain.Specifications.Rooms;

public class RoomDetailedSpecification : BaseModelByIdSpecification<Room, RoomDetailedResult>
{
    public RoomDetailedSpecification(int id) : base(id)
    {
        Query.Select(room => new RoomDetailedResult
        {
            Id = room.Id,
            RoomNumber = room.RoomNumber,
            MaxCapacityOfPeople = room.MaxCapacityOfPeople,
            Floor = room.Floor,
            EditionsCount = room.BookEditions.Count(be => be.DeletedDate == null),
            DeletedDate = room.DeletedDate
        });
    }
}

using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;

namespace Nika1337.Library.Domain.Specifications.Rooms;

public class RoomByRoomNumberSpecification : SingleResultSpecification<Room>
{
    public RoomByRoomNumberSpecification(string roomNumber)
    {
        Query.Where(room => room.RoomNumber == roomNumber);
    }
}

using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;

namespace Nika1337.Library.Domain.Specifications.Rooms;
public class RoomByIdSpecification : BaseModelByIdSpecification<Room>
{
    public RoomByIdSpecification(int id) : base(id)
    {
        Query.Include(room => room.Bookshelves);
    }
}

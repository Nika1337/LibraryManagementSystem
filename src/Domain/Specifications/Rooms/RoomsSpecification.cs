using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.RequestFeatures;
using System;
using System.Linq.Expressions;

namespace Nika1337.Library.Domain.Specifications.Rooms;

public class RoomsSpecification : BaseModelSpecification<Room>
{
    protected override Expression<Func<Room, string>>[] FieldSelectors => [room => room.RoomNumber.ToString()];

    public RoomsSpecification(BaseModelSpecificationParameters<Room> parameters) : base(parameters)
    {
        Query.Include(room => room.Bookshelves);
    }
}

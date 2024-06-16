using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;

namespace Nika1337.Library.Domain.Specifications;

public class NonDeletedSpecification<T> : Specification<T> where T : BaseModel
{
    public NonDeletedSpecification()
    {
        Query.Where(entity => entity.DeletedDate == null);
    }
}

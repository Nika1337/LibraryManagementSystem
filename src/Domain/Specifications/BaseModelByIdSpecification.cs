using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;
using System.Linq;

namespace Nika1337.Library.Domain.Specifications;

public abstract class BaseModelByIdSpecification<T> : SingleResultSpecification<T> where T : BaseModel
{
    protected BaseModelByIdSpecification(int id)
    {
        Query.Where(entity => entity.Id == id);
    }
}

using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;
using System.Linq;

namespace Nika1337.Library.Domain.Specifications;

public abstract class BaseModelByIdSpecification<T> : BaseModelByIdSpecification<T, T> where T : BaseModel
{
    protected BaseModelByIdSpecification(int id) : base(id)
    {
    }
}


public abstract class BaseModelByIdSpecification<T, TResult> : SingleResultSpecification<T, TResult> where T : BaseModel
{
    protected BaseModelByIdSpecification(int id)
    {
        Query.Where(entity => entity.Id == id);
    }
}
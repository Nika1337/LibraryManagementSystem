using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;

namespace Nika1337.Library.Domain.Specifications;


public class NonDeletedSpecification<T> : NonDeletedSpecification<T, T> where T : BaseModel
{
    public NonDeletedSpecification() : base()
    {
    }
}



public class NonDeletedSpecification<T, TResult> : Specification<T, TResult> where T : BaseModel
{
    public NonDeletedSpecification()
    {
        Query.Where(entity => entity.DeletedDate == null);
    }
}

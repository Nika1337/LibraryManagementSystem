using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.RequestFeatures;

namespace Nika1337.Library.Domain.Specifications;

public abstract class BaseModelSpecification<T> : Specification<T> where T : BaseModel
{
    protected abstract Expression<Func<T, string>>[] FieldSelectors { get; }

    public BaseModelSpecification(BaseModelSpecificationParameters<T> parameters)
    {
        if (parameters.OrderBy != null)
        {
            Query.OrderBy(parameters.OrderBy);
        }

        if (!string.IsNullOrWhiteSpace(parameters.SearchTerm) && FieldSelectors.Length != 0)
        {
            var lowerCaseTerm = parameters.SearchTerm.Trim().ToLower();
            Query.Where(BuildSearchPredicate(lowerCaseTerm));
        }

        if (!parameters.ShouldIncludeDeleted)
        {
            Query.Where(entity => entity.DeletedDate == null);
        }
    }

    private Expression<Func<T, bool>> BuildSearchPredicate(string searchTerm)
    {
        var parameter = Expression.Parameter(typeof(T), "x");
        Expression body = Expression.Constant(false);

        foreach (var selector in FieldSelectors)
        {
            var selectorBody = Expression.Invoke(selector, parameter);
            var toLowerCall = Expression.Call(selectorBody, typeof(string).GetMethod("ToLower", Type.EmptyTypes));
            var containsCall = Expression.Call(
                toLowerCall,
                typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                Expression.Constant(searchTerm)
            );

            body = Expression.OrElse(body, containsCall);
        }

        return Expression.Lambda<Func<T, bool>>(body, parameter);
    }
}
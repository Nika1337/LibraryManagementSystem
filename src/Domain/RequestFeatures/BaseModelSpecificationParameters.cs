
using System.Linq.Expressions;
using System;

namespace Nika1337.Library.Domain.RequestFeatures;

public class BaseModelSpecificationParameters<T>
{
    public bool ShouldIncludeDeleted { get; set; }

    public string? SearchTerm { get; set; }

    public Expression<Func<T, object?>>? OrderBy { get; set; }
    public bool IsDescending { get; set; }
}

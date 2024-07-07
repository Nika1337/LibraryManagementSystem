

using System.Linq.Expressions;
using System;

namespace Nika1337.Library.Application.DataTransferObjects.Library;

public record BaseModelPagedRequest<T>
{
    const int maxPageSize = 50;
    public int PageNumber { get; set; } = 1;

    private int _pageSize = 10;
    public int PageSize
    {
        get
        {
            return _pageSize;
        }
        set
        {
            _pageSize = (value > maxPageSize) ? maxPageSize : value;
        }
    }

    public bool ShouldIncludeDeleted { get; set; } = true;

    public string? SearchTerm { get; set; } = null;

    public Expression<Func<T, object?>>? OrderBy { get; set; } = null;
    public bool IsDescending { get; set; } = false;
}

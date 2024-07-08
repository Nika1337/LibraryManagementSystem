
using System;
using System.Linq.Expressions;

namespace Nika1337.Library.Application.DataTransferObjects;

public record PagedRequest<T> where T : class
{
    const int maxPageSize = 50;
    public int PageNumber { get; init; } = 1;

    private int _pageSize = 10;
    public int PageSize
    {
        get
        {
            return _pageSize;
        }
        init
        {
            _pageSize = (value > maxPageSize) ? maxPageSize : value;
        }
    }
    public string? SearchTerm { get; init; } = null;

    public Expression<Func<T, object?>>? OrderBy { get; init; } = null;
    public bool IsDescending { get; init; } = false;
}

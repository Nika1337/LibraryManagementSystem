using System;
using System.Collections.Generic;
using System.Linq;

namespace Nika1337.Library.Domain.RequestFeatures;

public class PagedList<T> : List<T>
{
    public MetaData MetaData { get; private set; }


    public PagedList(
        List<T> items,
        MetaData metaData)
    {
        MetaData = metaData;

        AddRange(items);
    }
    public PagedList(
        List<T> items,
        int count,
        int pageNumber,
        int pageSize)
    {

        MetaData = new MetaData
        {
            CurrentPage = pageNumber,
            TotalPages = (int)Math.Ceiling(count / (double)pageSize),
            PageSize = pageSize,
            TotalCount = count
        };

        AddRange(items);
    }

    public static PagedList<T> ToPagedList(IEnumerable<T> source, int pageNumber, int pageSize)
    {
        var count = source.Count();

        var items = source
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        return new PagedList<T>(items, count, pageNumber, pageSize);
    }
}

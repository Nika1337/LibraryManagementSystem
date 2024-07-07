using AutoMapper;
using Nika1337.Library.Domain.RequestFeatures;
using System.Collections.Generic;
using System.Linq;

namespace Nika1337.Library.Infrastructure.Mapping.RequestFeatures;

public class PagedListConverter<TSource, TDestination> : ITypeConverter<PagedList<TSource>, PagedList<TDestination>>
{
    public PagedList<TDestination> Convert(PagedList<TSource> source, PagedList<TDestination> destination, ResolutionContext context)
    {
        var mappedItems = context.Mapper.Map<List<TDestination>>(source.ToList());
        return new PagedList<TDestination>(mappedItems, source.MetaData);
    }
}
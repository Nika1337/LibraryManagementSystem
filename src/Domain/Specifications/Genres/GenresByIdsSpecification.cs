using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Nika1337.Library.Domain.Specifications.Genres;

public class GenresByIdsSpecification : Specification<Genre>
{
    public GenresByIdsSpecification(IEnumerable<int> ids)
    {
        Query.Where(genre => ids.Contains(genre.Id));
    }
}
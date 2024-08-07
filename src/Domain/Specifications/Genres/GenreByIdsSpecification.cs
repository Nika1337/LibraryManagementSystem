

using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Nika1337.Library.Domain.Specifications.Genres;

public class GenreByIdsSpecification : Specification<Genre>
{
    public GenreByIdsSpecification(IEnumerable<int> ids)
    {
        Query.Where(genre => ids.Contains(genre.Id));

        Query.AsTracking();
    }
}

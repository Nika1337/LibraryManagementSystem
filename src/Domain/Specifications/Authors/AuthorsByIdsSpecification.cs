using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Nika1337.Library.Domain.Specifications.Authors;

public class AuthorsByIdsSpecification : Specification<Author>
{
    public AuthorsByIdsSpecification(IEnumerable<int> ids)
    {
        Query.Where(author => ids.Contains(author.Id));

        Query.AsTracking();
    }
}
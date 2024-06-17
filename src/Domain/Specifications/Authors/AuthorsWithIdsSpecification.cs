using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;
using System.Linq;

namespace Nika1337.Library.Domain.Specifications.Authors;

public class AuthorsWithIdsSpecification : Specification<Author>
{
    public AuthorsWithIdsSpecification(int[] ids)
    {
        Query.Where(author => ids.Contains(author.Id));
    }
}
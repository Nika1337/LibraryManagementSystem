using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;
using System.Linq;
namespace Nika1337.Library.Domain.Specifications.Genres;

public class GenresWithIdsSpecification : Specification<Genre>
{
    public GenresWithIdsSpecification(int[] ids)
    {
        Query
            .Where(genre => ids.Contains(genre.Id));
    }
}
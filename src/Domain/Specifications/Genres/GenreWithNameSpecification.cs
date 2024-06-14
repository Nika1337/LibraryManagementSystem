using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;
using System.Linq;

namespace Nika1337.Library.Domain.Specifications.Genres;

public class GenreWithNameSpecification : SingleResultSpecification<Genre>
{
    public GenreWithNameSpecification(string name)
    {
        Query
            .Where(et => et.Name == name);
    }
}
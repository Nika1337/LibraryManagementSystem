using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;
using System.Linq;

namespace Nika1337.Library.Domain.Specifications.Genres;

public class GenreByNameSpecification : SingleResultSpecification<Genre>
{
    public GenreByNameSpecification(string name)
    {
        Query
            .Where(et => et.Name == name);
    }
}
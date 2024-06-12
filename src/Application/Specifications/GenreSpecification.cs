using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;
using System.Linq;

namespace Nika1337.Library.Application.Specifications;

public class GenreSpecification : SingleResultSpecification<Genre>
{
    public GenreSpecification(string name)
    {
        Query
            .Where(et => et.Name == name);
    }

    public GenreSpecification(string name, int id)
    {
        Query
            .Where(et => et.Name == name && et.Id != id);
    }
}
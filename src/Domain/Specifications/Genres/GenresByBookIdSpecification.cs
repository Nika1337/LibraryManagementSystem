using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;
using System.Linq;

namespace Nika1337.Library.Domain.Specifications.Genres;
public class GenresByBookIdSpecification : Specification<Genre>
{
    public GenresByBookIdSpecification(int id)
    {
        Query.Where(genre => genre.Books.Any(book => book.Id == id));
    }
}
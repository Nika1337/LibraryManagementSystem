using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;
using System.Linq;

namespace Nika1337.Library.Domain.Specifications.Authors;

public class AuthorsByBookIdSpecification : Specification<Author>
{
    public AuthorsByBookIdSpecification(int id)
    {
        Query.Where(author => author.Books.Any(book => book.Id == id));
    }
}
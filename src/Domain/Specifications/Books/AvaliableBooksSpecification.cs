

using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.Specifications.Books.Results;
using System.Linq;

namespace Nika1337.Library.Domain.Specifications.Books;

public class AvaliableBooksSpecification : Specification<Book, AvaliableBookResult>
{
    public AvaliableBooksSpecification()
    {
        Query.Where(Extensions.IsBookAvaliable);


        Query.Select(b => new AvaliableBookResult
        {
            Id = b.Id,
            Title = b.Title,
            AuthorNames = b.Authors.Select(au => au.Name).ToArray()
        });
    }
}

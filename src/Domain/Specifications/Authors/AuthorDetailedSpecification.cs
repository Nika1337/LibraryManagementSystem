

using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.Specifications.Authors.Results;

namespace Nika1337.Library.Domain.Specifications.Authors;

public class AuthorDetailedSpecification : BaseModelByIdSpecification<Author, AuthorDetailedResult>
{
    public AuthorDetailedSpecification(int id) : base(id)
    {
        Query.Select(author => new AuthorDetailedResult
        {
            Id = author.Id,
            Name = author.Name,
            IsAlive = author.IsAlive,
            DeletedDate = author.DeletedDate,
            DateOfBirth = author.DateOfBirth,
            Biography = author.Biography,
        });
    }
}

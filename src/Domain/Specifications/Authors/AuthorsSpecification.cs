

using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.RequestFeatures;
using Nika1337.Library.Domain.Specifications.Authors.Results;
using System;
using System.Linq.Expressions;

namespace Nika1337.Library.Domain.Specifications.Authors;

public class AuthorsSpecification : BaseModelSpecification<Author, AuthorResult>
{
    protected override Expression<Func<Author, string>>[] FieldSelectors => [author => author.Biography, author => author.Name];

    public AuthorsSpecification(BaseModelSpecificationParameters<Author> parameters) : base(parameters)
    {
        Query.Select(au => new AuthorResult
        {
            Id = au.Id,
            Name = au.Name,
            Biography = au.Biography,
            IsAlive = au.IsAlive,
            IsActive = au.DeletedDate == null,
            DateOfBirth = au.DateOfBirth,
        });
    }
}
